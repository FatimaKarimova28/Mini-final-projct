using System;
using System.Text.RegularExpressions;

namespace Core.Extentions
{
	public static class ProjectExtensions
	{
        public static bool IsEmail(this string text)
        {

            return Regex.IsMatch(text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

        }


        public static bool IsCorrectMobileNumber(this string text)
        {


            return Regex.IsMatch(text, @"994[0-9]{9}$");


        }
    }
}

