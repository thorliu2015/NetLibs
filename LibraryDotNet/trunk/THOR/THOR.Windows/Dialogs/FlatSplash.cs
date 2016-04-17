using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using THOR.Windows.Components.Drawing;
using THOR.Windows.Utils;

namespace THOR.Windows.Dialogs
{
	/// <summary>
	/// 启动窗体基类
	/// </summary>
	public partial class FlatSplash : THOR.Windows.Dialogs.FlatForm
	{
		/// <summary>
		/// 是否已经启动
		/// </summary>
		protected bool Started = false;

		protected System.Windows.Forms.Timer DelayTimer = new System.Windows.Forms.Timer();

		/// <summary>
		/// 构造
		/// </summary>
		public FlatSplash()
			: base()
		{
			InitializeComponent();

			InitSplashForm();

			Screen scr = Screen.FromControl(this);
			Point p = new Point();
			p.X = (scr.WorkingArea.Width - this.Width) / 2;
			p.Y = (scr.WorkingArea.Height - this.Height) / 2;
			Location = p;


			lblProgressValue.ForeColor =
			lblProgressInfo.ForeColor =
			lblProgressDetail.ForeColor =
			lblProductVersion.ForeColor =
			lblProductName.ForeColor =
			lblProductCopyright.ForeColor = ThorColors.WindowText;

		}

		/// <summary>
		/// 初始化窗体
		/// </summary>
		protected override void Init()
		{
			base.Init();
			canMove = false;
		}

		/// <summary>
		/// 初始化窗体内容
		/// </summary>
		protected virtual void InitSplashForm()
		{
			lblProductName.Text = ApplicationUtils.ProductName;
			lblProductVersion.Text = ApplicationUtils.ProductVersion;
			lblProductCopyright.Text = ApplicationUtils.ProductCopyright;

			SetProgressInfo(0, 0, "", "");

			DelayTimer.Enabled = false;
			DelayTimer.Interval = 3000;
			DelayTimer.Tick += DelayTimer_Tick;

			canMove = false;
			canResize = false;
		}





		#region 绘制
		protected override int MeasureFormButtonCount()
		{
			return 0;
		}

		protected override void DrawButtons(PaintEventArgs e)
		{

		}

		protected override void DrawTitleText(PaintEventArgs e)
		{

		}
		#endregion

		#region 动画
		protected int nLoadingAniFrame = 0;
		private void timerLoadingAni_Tick(object sender, EventArgs e)
		{
			picLoadingAni.Image = imageList.Images[nLoadingAniFrame];
			nLoadingAniFrame++;
			if (nLoadingAniFrame >= imageList.Images.Count) nLoadingAniFrame = 0;
		}
		#endregion

		/// <summary>
		/// 设置进度信息
		/// </summary>
		/// <param name="currentProgress"></param>
		/// <param name="totalProgress"></param>
		/// <param name="info"></param>
		/// <param name="detail"></param>
		public virtual void SetProgressInfo(int currentProgress, int totalProgress, string info, string detail)
		{
			lblProgressInfo.Text = String.Format(info, currentProgress, totalProgress);
			lblProgressDetail.Text = String.Format(detail, currentProgress, totalProgress);

			if (currentProgress == totalProgress && totalProgress <= 0)
			{
				lblProgressValue.Visible = false;
			}
			else
			{
				lblProgressValue.Text = GetProgressValue(currentProgress, totalProgress);
			}

			Application.DoEvents();
		}


		/// <summary>
		/// 格式化进度信息
		/// </summary>
		/// <param name="currentProgress"></param>
		/// <param name="totalProgress"></param>
		/// <returns></returns>
		protected virtual string GetProgressValue(int currentProgress, int totalProgress)
		{
			float v = (currentProgress * 1.0f) / (totalProgress * 1.0f);
			float mv = (MainProgressCurrent * 1.0f) / (MainProgressTotal * 1.0f);
			float sv = 1.0f / (MainProgressTotal * 1.0f);

			v = mv + (sv * v);

			v = v * 100;

			return String.Format("{0}%", Convert.ToInt32(v));
		}

		/// <summary>
		/// 显示窗体时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (!Started)
			{
				Started = true;
				Loading();
				DelayTimer.Enabled = true;
				DelayTimer.Start();
			}
		}

		/// <summary>
		/// 加载数据
		/// </summary>
		protected virtual void Loading()
		{
			for (int i = 1; i <= 100; i++)
			{
				SetProgressInfo(i, 100, "Loading ... {0}/{1}", "waitting ...");
				Thread.Sleep(10);
			}

		}

		/// <summary>
		/// 延迟计时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DelayTimer_Tick(object sender, EventArgs e)
		{
			DelayTimer.Enabled = false;
			DelayTimer.Stop();
			this.Hide();
			Startup();
		}


		/// <summary>
		/// 启动
		/// </summary>
		protected virtual void Startup()
		{

		}


		public int MainProgressCurrent { get; set; }
		public int MainProgressTotal { get; set; }
	}
}
