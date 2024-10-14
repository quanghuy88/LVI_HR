﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class ConvertNumToString
    {
        public static string NumberToWords(this int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000000) + " bilion ";
                number %= 1000000;
            }
            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }
            return words;
        }
        public static string NumberToString(this decimal number)
        {
            if (number == 0)
                return "0";

            if (number < 0)
                return "-" + NumberToString(Math.Abs(number));

            string words = "";

            if (Math.Floor(number / 1000000000) > 0)
            {
                words += Math.Floor(number / 1000000000).ToString("###,###") + " B";
                return words;
            }
            else if (Math.Floor(number / 1000000) > 0)
            {
                words += Math.Floor(number / 1000000).ToString("###,###") + " M";
                return words;
            }
            else if (Math.Floor(number / 1000) > 0)
            {
                words += Math.Floor(number / 1000).ToString("###,###") + " K";
                return words;
            }
            else 
            {
                return number.ToString();
            }
        }
        public static string ShortenNumberBillion(this decimal number)
        {
            if (Math.Floor(Math.Abs(number) / 1000000000) == 0)
                return "0";

            if (Math.Floor(number / 1000000000) < 0)
                return "-" + ShortenNumberBillion(Math.Abs(number));

            string words = "";

            if (Math.Floor(number / 1000000000) > 0)
            {
                words += Math.Floor(number / 1000000000).ToString("###,###");
            }
            return words;
        }
        public static string NumberToStringFormat(decimal number)
        {
            string words = number.ToString("###,###");

            return words;
        }
    }
}
