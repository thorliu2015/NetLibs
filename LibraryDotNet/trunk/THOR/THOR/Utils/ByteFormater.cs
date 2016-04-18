using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THOR.Utils
{
    public class ByteFormater
    {
        static public string Format(byte[] bytes, string prefix = "", bool hasChar = true, int columns = 16)
        {
            StringBuilder result = new StringBuilder();

            StringBuilder hexBuilder = new StringBuilder();
            StringBuilder charBuilder = new StringBuilder();

            int j = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                string szByte = String.Format("{0:x} ", bytes[i]).PadLeft(3, '0').ToUpper();
                string szChar = (i > 32 && i < 127) ? char.ConvertFromUtf32(bytes[i]).ToString() : ".";

                hexBuilder.Append(szByte);

                //if (j == 7 || j == 15) hexBuilder.Append(" ");

                charBuilder.Append(szChar);
                j++;
                if (j == columns)
                {
                    j = 0;
                    result.Append(hexBuilder.ToString());

                    if (hasChar)
                    {
                        result.Append(charBuilder.ToString());
                    }

                    result.Append("\r\n");

                    hexBuilder.Clear();
                    charBuilder.Clear();
                }
            }

            result.Append(hexBuilder.ToString().PadRight(16 * 3, ' '));
            result.Append(charBuilder.ToString());

            return result.ToString();
        }
    }
}
