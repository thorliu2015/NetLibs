using Solar.Animations;
using Solar.Images;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using THOR.Utils.Files;

namespace Solar.Data.Serialization.Xml
{
	/// <summary>
	/// XML序列化
	/// </summary>
	public class XmlSModelSerialization : ISModeSerialization
	{
		public XmlSModelSerialization()
		{
		}

		static public string GetFilePath(string key)
		{
			string filename = PathUtility.GetPathByApplicationPath(String.Format("data/{0}.xml", key));
			PathUtility.CheckFile(filename);

			return filename;
		}

		static public string GetImagePath(string key)
		{
			string filename = PathUtility.GetPathByApplicationPath(String.Format("images/{0}.png", key));
			PathUtility.CheckFile(filename);

			return filename;
		}



		#region Deserialize
		/// <summary>
		/// 反序列化
		/// </summary>
		public void Deserialize(string key, List<SModel> models)
		{
			string filename = GetFilePath(key);
			XmlDocument xml = new XmlDocument();
			xml.Load(filename);

			foreach (XmlNode node in xml.DocumentElement.ChildNodes)
			{
				SModel model = GetModel(node);
				if (model == null) continue;

				models.Add(model);
			}
		}

		protected SModel GetModel(XmlNode node)
		{
			SModel model = null;

			switch (node.Name)
			{
				//图片
				case "SImage":
					model = new SImage();
					break;

				//动画
				case "SAnimation":
					model = new SAnimation();
					break;
			}

			if (model != null)
			{
				SetModel(node, model);
			}

			return model;
		}

		protected void SetModel(XmlNode node, SModel model)
		{
			//基类
			model.Id = XmlFile.LoadTextNode(node, "Id", "");
			model.EditorName = XmlFile.LoadTextNode(node, "EditorName", "");
			model.EditorDescription = XmlFile.LoadTextNode(node, "EditorDescription", "");
			model.EditorCategory = XmlFile.LoadTextNode(node, "EditorCategory", "");
			model.EditorSuffix = XmlFile.LoadTextNode(node, "EditorSuffix", "");

			SetSImage(node, model);
			SetSAnimation(node, model);
		}

		protected void SetSImage(XmlNode node, SModel model)
		{
			if (model is SImage == false) return;
			SImage image = (SImage)model;

			image.Rows = XmlFile.LoadTextNode(node, "Rows", 0);
			image.Columns = XmlFile.LoadTextNode(node, "Columns", 0);
			image.Anchor = XmlFile.LoadTextNode(node, "Anchor", new Point());

			//加载图片
			try
			{
				string imgFile = GetImagePath(model.Id);
				image.ImageSource = Image.FromFile(imgFile);
			}
			catch
			{
			}
		}

		protected void SetSAnimation(XmlNode node, SModel model)
		{
			if (model is SAnimation == false) return;

			SAnimation animation = (SAnimation)model;
			XmlNodeList stateNodes = node.SelectNodes("state");

			foreach (XmlNode stateNode in stateNodes)
			{
				SAnimationState state = new SAnimationState();

				try
				{

					string stateType = XmlFile.LoadTextNode(stateNode, "stateType", "");
					string placeType = XmlFile.LoadTextNode(stateNode, "placeType", "");
					string placeSize = XmlFile.LoadTextNode(stateNode, "placeSize", "");

					state.StateType = (SAnimationStateType)Enum.Parse(typeof(SAnimationStateType), stateType);
					state.PlaceType = (SAnimationStatePlaceType)Enum.Parse(typeof(SAnimationStatePlaceType), placeType);
					state.PlaceSize = Convert.ToInt32(placeSize);

					animation.States.Add(state);
					state.OwnerAnimation = animation;
					SetSAnimationLayer(stateNode, state);
				}
				catch
				{
				}
			}
		}

		protected void SetSAnimationLayer(XmlNode node, SAnimationLayer layer)
		{
			try
			{
				layer.Name = XmlFile.LoadTextNode(node, "name", "");
				layer.DirectionType = (AnimationDirectionType)Enum.Parse(typeof(AnimationDirectionType), XmlFile.LoadTextNode(node, "directionType", ""));
				layer.TargetDirections = Convert.ToInt32(XmlFile.LoadTextNode(node, "targetDirections", ""));

				//directions
				XmlNodeList directionNodes = node.SelectNodes("directions/direction");

				int directionIndex = -1;
				foreach (XmlNode directionNode in directionNodes)
				{
					directionIndex++;
					SAnimationDirection direction = layer.Directions[directionIndex];

					//frames
					XmlNodeList frameNodes = directionNode.SelectNodes("frames/frame");
					foreach (XmlNode frameNode in frameNodes)
					{
						SAnimationFrame frame = new SAnimationFrame();

						frame.ImageID = XmlFile.LoadTextNode(frameNode, "source", "");
						frame.ImageRowIndex = Convert.ToInt32(XmlFile.LoadTextNode(frameNode, "row", ""));
						frame.ImageColumnIndex = Convert.ToInt32(XmlFile.LoadTextNode(frameNode, "col", ""));
						frame.Index = Convert.ToInt32(XmlFile.LoadTextNode(frameNode, "index", ""));
						frame.Length = Convert.ToInt32(XmlFile.LoadTextNode(frameNode, "length", ""));

						frame.X = Convert.ToInt32(XmlFile.LoadTextNode(frameNode, "x", ""));
						frame.Y = Convert.ToInt32(XmlFile.LoadTextNode(frameNode, "y", ""));

						frame.ScaleX = Convert.ToInt32(XmlFile.LoadTextNode(frameNode, "scaleX", ""));
						frame.ScaleY = Convert.ToInt32(XmlFile.LoadTextNode(frameNode, "scaleY", ""));

						frame.Rotation = Convert.ToSingle(XmlFile.LoadTextNode(frameNode, "rotation", ""));
						frame.Alpha = Convert.ToSingle(XmlFile.LoadTextNode(frameNode, "alpha", ""));

						direction.Frames.Add(frame);

					}

					//shoot
					XmlNodeList shootNodes = directionNode.SelectNodes("shootPositions/point");
					foreach (XmlNode pointNode in shootNodes)
					{
						SAnimationPoint point = new SAnimationPoint();
						point.X = Convert.ToSingle(XmlFile.LoadTextNode(pointNode, "x", ""));
						point.Y = Convert.ToSingle(XmlFile.LoadTextNode(pointNode, "y", ""));

						direction.ShootPosition.Add(point);
					}
				}

				//children
				XmlNodeList childrenNodes = node.SelectNodes("children/layer");
				foreach (XmlNode layerNode in childrenNodes)
				{
					SAnimationLayer childLayer = new SAnimationLayer();
					layer.Add(childLayer);
					childLayer.OwnerAnimation = layer.OwnerAnimation;
					SetSAnimationLayer(layerNode, childLayer);
				}
			}
			catch
			{
			}
		}

		#endregion

		#region Serialize

		/// <summary>
		/// 序列化
		/// </summary>
		public void Serialize(string key, List<SModel> models)
		{
			XmlDocument xml = new XmlDocument();
			xml.LoadXml(String.Format("<?xml version=\"1.0\" encoding=\"UTF-8\"?><{0}/>", key));

			XmlNode root = xml.DocumentElement;

			foreach (SModel model in models)
			{
				XmlNode node = GetModelNode(model, root);
				root.AppendChild(node);
			}

			string filename = GetFilePath(key);
			XmlFile.Save(filename, xml);
		}

		/// <summary>
		/// 获取模型节点
		/// </summary>
		/// <param name="model"></param>
		/// <param name="parentNode"></param>
		/// <returns></returns>
		protected XmlNode GetModelNode(SModel model, XmlNode parentNode)
		{
			if (model == null)
			{
				XmlNode result = parentNode.OwnerDocument.CreateElement("null");

				return result;
			}
			else
			{
				Type type = model.GetType();
				XmlNode result = parentNode.OwnerDocument.CreateElement(type.Name);

				SetModelNode(model, result);


				return result;
			}
		}

		/// <summary>
		/// 设置模型节点
		/// </summary>
		/// <param name="model"></param>
		/// <param name="node"></param>
		protected void SetModelNode(SModel model, XmlNode node)
		{
			//基类
			XmlFile.SaveTextNode(node, "Id", model.Id);
			XmlFile.SaveTextNode(node, "EditorName", model.EditorName);
			XmlFile.SaveTextNode(node, "EditorSuffix", model.EditorSuffix);
			XmlFile.SaveTextNode(node, "EditorDescription", model.EditorDescription);
			XmlFile.SaveTextNode(node, "EditorCategory", model.EditorCategory);

			SetSImageNode(model, node);
			SetSAnimationNode(model, node);
		}

		/// <summary>
		/// 设置图片节点
		/// </summary>
		/// <param name="model"></param>
		/// <param name="node"></param>
		protected void SetSImageNode(SModel model, XmlNode node)
		{
			if (model is SImage == false) return;

			SImage image = (SImage)model;

			XmlFile.SaveTextNode(node, "Rows", image.Rows.ToString());
			XmlFile.SaveTextNode(node, "Columns", image.Columns.ToString());
			XmlFile.SaveTextNode(node, "Anchor", image.Anchor);


			if ((model.ChangeType & DataChangeTypes.FileChanged) == DataChangeTypes.FileChanged)
			{
				try
				{
					//save image
					string imgFile = GetImagePath(model.Id);

					image.ImageSource.Save(imgFile);
				}
				catch
				{
				}
			}
		}

		/// <summary>
		/// 设置动画节点
		/// </summary>
		/// <param name="model"></param>
		/// <param name="node"></param>
		protected void SetSAnimationNode(SModel model, XmlNode node)
		{
			if (model is SAnimation == false) return;

			SAnimation animation = (SAnimation)model;

			foreach (SAnimationState state in animation.States)
			{
				XmlNode stateNode = node.OwnerDocument.CreateElement("state");
				node.AppendChild(stateNode);

				XmlFile.SaveTextNode(stateNode, "stateType", state.StateType.ToString());
				XmlFile.SaveTextNode(stateNode, "placeType", state.PlaceType.ToString());
				XmlFile.SaveTextNode(stateNode, "placeSize", state.PlaceSize.ToString());

				SetSAnimationNodeMethod(state, stateNode);
			}
		}

		protected void SetSAnimationNodeMethod(SAnimationLayer layer, XmlNode node)
		{
			XmlFile.SaveTextNode(node, "name", layer.Name);
			XmlFile.SaveTextNode(node, "directionType", layer.DirectionType.ToString());
			XmlFile.SaveTextNode(node, "targetDirections", layer.TargetDirections.ToString());

			XmlNode directionsNode = node.OwnerDocument.CreateElement("directions");
			node.AppendChild(directionsNode);

			foreach (SAnimationDirection direction in layer.Directions)
			{
				XmlNode directionNode = node.OwnerDocument.CreateElement("direction");
				directionsNode.AppendChild(directionNode);

				//frames
				XmlNode framesNode = node.OwnerDocument.CreateElement("frames");
				directionNode.AppendChild(framesNode);
				foreach (SAnimationFrame frame in direction.Frames)
				{
					XmlNode frameNode = node.OwnerDocument.CreateElement("frame");
					framesNode.AppendChild(frameNode);

					XmlFile.SaveTextNode(frameNode, "source", frame.ImageID);
					XmlFile.SaveTextNode(frameNode, "row", frame.ImageRowIndex.ToString());
					XmlFile.SaveTextNode(frameNode, "col", frame.ImageColumnIndex.ToString());
					XmlFile.SaveTextNode(frameNode, "index", frame.Index.ToString());
					XmlFile.SaveTextNode(frameNode, "length", frame.Length.ToString());

					XmlFile.SaveTextNode(frameNode, "x", frame.X.ToString());
					XmlFile.SaveTextNode(frameNode, "y", frame.Y.ToString());
					XmlFile.SaveTextNode(frameNode, "scaleX", frame.ScaleX.ToString());
					XmlFile.SaveTextNode(frameNode, "scaleY", frame.ScaleY.ToString());
					XmlFile.SaveTextNode(frameNode, "rotation", frame.Rotation.ToString());
					XmlFile.SaveTextNode(frameNode, "alpha", frame.Alpha.ToString());
				}

				//shootposition
				XmlNode shootsNode = node.OwnerDocument.CreateElement("shootPositions");
				directionNode.AppendChild(shootsNode);

				foreach (SAnimationPoint point in direction.ShootPosition)
				{
					XmlNode pointNode = node.OwnerDocument.CreateElement("point");
					shootsNode.AppendChild(pointNode);

					XmlFile.SaveTextNode(pointNode, "x", point.X.ToString());
					XmlFile.SaveTextNode(pointNode, "y", point.Y.ToString());
				}
			}

			XmlNode childrenNode = node.OwnerDocument.CreateElement("children");
			node.AppendChild(childrenNode);
			for (int i = 0; i < layer.Count; i++)
			{
				SAnimationLayer childLayer = (SAnimationLayer)layer[i];

				XmlNode layerNode = node.OwnerDocument.CreateElement("layer");
				childrenNode.AppendChild(layerNode);

				SetSAnimationNodeMethod(childLayer, layerNode);
			}
		}

		#endregion
	}
}
