using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionLib
{
    public static class ExtensionLibExtensions
    {
        public static string ToTitleCase(this string inputString, bool forceLower)
        {
            inputString = inputString.Trim();
            if (inputString == "")
            {
                return "";
            }
            if (forceLower)
            {
                inputString = inputString.ToLower();
            }
            string[] inputStringAsArray = inputString.Split(' ');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < inputStringAsArray.Length; i++)
            {
                if (inputStringAsArray[i].Length > 0)
                {
                    sb.AppendFormat(" {0}{1} ",
                    inputStringAsArray[i].Substring(0, 1).ToUpper(),
                    inputStringAsArray[i].Substring(1));
                }
            }
            return sb.ToString(0, sb.Length - 1);
        }

        public static string ReverseString (this string inputString)
        {
            return new string(inputString.ToCharArray().Reverse().ToArray());
        }

        public static string ToStringReversed(this object inputObject)
        {
            return inputObject.ToString().ReverseString();
        }
    }
}
