using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtensionMethods
{

  public static class ExtensionMethods
  {

	/// <summary>
	/// Sql Server In Operator Implementation in C#
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="object"></param>
	/// <param name="values"></param>
	/// <returns>Returns True if the Value is Found in the array/list of object/string</returns>
	public static bool In<T>(this T @object, params T[] values)
	{
	  // this is LINQ expression. If you don't want to use LINQ,
	  // you can use a simple foreach and return true 
	  // if object is found in the array
	  return values.Contains(@object);
	}

	/// <summary>
	/// Sql Server In Operator Implementation in C#
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="object"></param>
	/// <param name="valueList"></param>
	/// <returns>Returns True if the Value is Found in the array/list of object/string</returns>
	public static bool In<T>(this T @object, IEnumerable<T> valueList)
	{
	  // this is LINQ expression. If you don't want to use LINQ,
	  // you can use a simple foreach and return true if object 
	  // is found in the array
	  return valueList.Contains(@object);
	}

	/// <summary>
	/// Checks string object's value to array of string values
	/// </summary>        
	/// <param name="stringValues">Array of string values to compare</param>
	/// <returns>Return true if any string value matches</returns>
	public static bool In(this string inputstring, params string[] stringValues)
	{
	  foreach (string otherValue in stringValues)
		if (string.Compare(inputstring, otherValue) == 0)
		  return true;

	  return false;
	}

	/// <summary>
	///  string Format function
	/// </summary>
	/// <param name="stringFormat"></param>
	/// <param name="stringParams"></param>
	/// <returns></returns>
	public static string ToStringFormat(this string stringFormat, params string[] stringParams)
	{
	  return string.Format(stringFormat, stringParams);
	}


	/// <summary>To Safely Convert string to Int.</summary>
	/// 
	public static int ToInt32(this string value)
	{
	  int number;

	  Int32.TryParse(value, out number);

	  return number;
	}

	/// <summary>
	/// Sql Server Between  Operator Work-around for Dates
	/// </summary>
	/// <param name="dt"></param>
	/// <param name="start"></param>
	/// <param name="end"></param>
	/// <returns></returns>
	public static bool Between(this DateTime dt, DateTime start, DateTime end)
	{
	  return dt >= start && dt <= end;
	}

	/// <summary>
	/// Sql Server Between  Operator Work-around for Numbers/Intergers
	/// </summary>
	/// <param name="num"></param>
	/// <param name="lower"></param>
	/// <param name="upper"></param>
	/// <param name="inclusive"></param>
	/// <returns></returns>
	public static bool Between(this int num, int lower, int upper, bool inclusive = false)
	{
	  return inclusive
		  ? lower <= num && num <= upper
		  : lower < num && num < upper;
	}

	/// <summary>
	/// Sql Server Between Operator Work-around for Double/Decimal values
	/// </summary>
	/// <param name="num"></param>
	/// <param name="lower"></param>
	/// <param name="upper"></param>
	/// <param name="inclusive"></param>
	/// <returns>Returns True if  value is in between the give range </returns>
	public static bool Between(this double num, double lower, double upper, bool inclusive = false)
	{
	  return inclusive
		  ? lower <= num && num <= upper
		  : lower < num && num < upper;
	}


	/// <summary>
	/// Words Count from a given string
	/// </summary>
	/// <param name="inputstring"></param>
	/// <returns>Returns Words Count from a given string</returns>
	public static int GetWordCount(this string inputstring)
	{
	  if (!string.IsNullOrEmpty(inputstring))
	  {
		string[] strArray = inputstring.Split(' ');
		return strArray.Count();
	  }
	  else
	  {
		return 0;
	  }

	}

	/// <summary>
	/// Words Count from a given string sperated by given sepratoir char (, : : etc.)
	/// </summary>
	/// <param name="inputstring"></param>
	/// <param name="Separator"></param>
	/// <returns>Word Count</returns>
	public static int GetWordCount(this string inputstring, char Separator)
	{
	  if (!string.IsNullOrEmpty(inputstring))
	  {
		string[] strArray = inputstring.Split(Separator);
		return strArray.Count();
	  }
	  else
	  {
		return 0;
	  }

	}
	/// <summary>
	/// Shorthand for Greater then Operator
	/// </summary>
	/// <param name="i"></param>
	/// <param name="value"></param>
	/// <returns>True if value is Greator then the value to be compared</returns>
	public static bool IsGreaterThan(this int i, int value)
	{
	  return i > value;
	}

	/// <summary>
	/// Shorthand for Less then Operator
	/// </summary>
	/// <param name="i"></param>
	/// <param name="value"></param>
	/// <returns>True if value is Less then the value to be compared</returns>
	public static bool IsLessThen(this int i, int value)
	{
	  return i < value;
	}

	/// <summary>
	/// short hand for TryParse for parsing string to int
	/// </summary>
	/// <param name="inputstring"></param>
	/// <returns></returns>
	public static bool isNumeric(this string inputstring)
	{
	  return int.TryParse(inputstring, out int n);
	}

	/// <summary>
	/// Short hand for Converting String to Date, short hand are used to save the coding time and to be error safge.
	/// </summary>
	/// <param name="inputstring"></param>
	/// <param name="throwExceptionIfFailed"></param>
	/// <returns>Returns Date String if succefully parsed</returns>
	public static DateTime toDate(this string inputstring, bool throwExceptionIfFailed = false)
	{
	  DateTime result;
	  var valid = DateTime.TryParse(inputstring, out result);
	  if (!valid)
		if (throwExceptionIfFailed)
		  throw new FormatException(string.Format("'{0}' cannot be converted as DateTime", inputstring));
	  return result;
	}

	/// <summary>
	/// shorthand to parse string to int
	/// </summary>
	/// <param name="inputstring"></param>
	/// <param name="throwExceptionIfFailed"></param>
	/// <returns></returns>
	public static int toInt(this string inputstring, bool throwExceptionIfFailed = false)
	{
	  int result;
	  var valid = int.TryParse(inputstring, out result);
	  if (!valid)
		if (throwExceptionIfFailed)
		  throw new FormatException(string.Format("'{0}' cannot be converted as int", inputstring));
	  return result;
	}
	/// <summary>
	/// short hand to safely parse string to double
	/// </summary>
	/// <param name="inputstring"></param>
	/// <param name="throwExceptionIfFailed"></param>
	/// <returns></returns>
	public static double toDouble(this string inputstring, bool throwExceptionIfFailed = false)
	{
	  double result;
	  var valid = double.TryParse(inputstring, NumberStyles.AllowDecimalPoint,
		new NumberFormatInfo { NumberDecimalSeparator = "." }, out result);
	  if (!valid)
		if (throwExceptionIfFailed)
		  throw new FormatException(string.Format("'{0}' cannot be converted as double", inputstring));
	  return result;
	}

	/// <summary>
	/// shorthand for Reversing any given string (i.e. RIGHt to Left)
	/// </summary>
	/// <param name="inputstring"></param>
	/// <returns>Retruns the given string in Reverse Order (RIght to Left)</returns>
	public static string Reverse(this string inputstring)
	{
	  if (string.IsNullOrWhiteSpace(inputstring)) return string.Empty;
	  char[] chars = inputstring.ToCharArray();
	  Array.Reverse(chars);
	  return new String(chars);
	}


	/// <summary>
	/// Matching all capital letters in the inputstring and seperate them with spaces to form a sentence.
	/// If the inputstring is an abbreviation text, no space will be added and returns the same inputstring.
	/// </summary>
	/// <example>
	/// inputstring : HelloWorld
	/// output : Hello World
	/// </example>
	/// <example>
	/// inputstring : BBC
	/// output : BBC
	/// </example>
	/// <param name="inputstring" />
	/// <returns>
	public static string toSentence(this string inputstring)
	{
	  if (string.IsNullOrWhiteSpace(inputstring))
		return inputstring;
	  //return as is if the inputstring is just an abbreviation
	  if (Regex.Match(inputstring, "[0-9A-Z]+$").Success)
		return inputstring;
	  //add a space before each capital letter, but not the first one.
	  var result = Regex.Replace(inputstring, "(\\B[A-Z])", " $1");
	  return result;
	}

	/// <summary>
	/// Returns the last few characters of the string with a length
	/// specified by the given parameter. If the string's length is less than the 
	/// given length the complete string is returned. If length is zero or 
	/// less an empty string is returned
	/// </summary>
	/// <param name="s">the string to process</param>
	/// <param name="length">Number of characters to return</param>
	/// <returns></returns>
	public static string Right(this string inputstring, int howMany)
	{
	  if (string.IsNullOrWhiteSpace(inputstring)) return string.Empty;
	  var value = inputstring.Trim();
	  return howMany >= value.Length ? value : value.Substring(value.Length - howMany, howMany);
	}

	/// <summary>
	/// Returns the first few characters of the string with a length
	/// specified by the given parameter. If the string's length is less than the 
	/// given length the complete string is returned. If length is zero or 
	/// less an empty string is returned
	/// </summary>
	/// <param name="s">the string to process</param>
	/// <param name="length">Number of characters to return</param>
	/// <returns></returns>
	public static string Left(this string inputstring, int howMany)
	{
	  if (string.IsNullOrWhiteSpace(inputstring)) return string.Empty;
	  var value = inputstring.Trim();
	  return howMany >= value.Length ? value : inputstring.Substring(0, howMany);

	}

	/// <summary>
	/// Checks if given string is a valid email, short hand to speed up coding
	/// </summary>
	/// <param name="inputstring"></param>
	/// <returns></returns>
	public static bool isEmail(this string inputstring)
	{
	  var match = Regex.Match(inputstring,
		@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
	  return match.Success;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="inputstring"></param>
	/// <returns></returns>
	public static bool isPhone(this string inputstring)
	{
	  var match = Regex.Match(inputstring,
		@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", RegexOptions.IgnoreCase);
	  return match.Success;
	}

	/// <summary>
	/// It Reutrns first Number from any given string
	/// </summary>
	/// <param name="inputstring"></param>
	/// <returns></returns>
	public static int extractNumber(this string inputstring)
	{
	  if (string.IsNullOrWhiteSpace(inputstring)) return 0;

	  var match = Regex.Match(inputstring, "[0-9]+", RegexOptions.IgnoreCase);
	  return match.Success ? match.Value.toInt() : 0;

	  /* Use Cases
	   * It Reutrns first Number from any given string
	   *  string s="in 100 between"
	   * var num=s.extractNumber
	   * s= "first 100 then 60 then 8 then24"
	   * 
	   * num=s.extractNumber
	   * in 
	   */
	}

	/// <summary>
	/// Short Hand Extracts Query string Parameter Value
	/// </summary>
	/// <param name="queryString"></param>
	/// <param name="paramName"></param>
	/// <returns>parameter Value for given Paramter Name from  Query String </returns>
	public static string extractQueryStringParamValue(this string queryString, string paramName)
	{
	  if (string.IsNullOrWhiteSpace(queryString) || string.IsNullOrWhiteSpace(paramName)) return string.Empty;

	  var query = queryString.Replace("?", "");
	  if (!query.Contains("=")) return string.Empty;
	  var queryValues = query.Split('&').Select(piQ => piQ.Split('=')).ToDictionary(
		piKey => piKey[0].ToLower().Trim(), piValue => piValue[1]);
	  string result;
	  var found = queryValues.TryGetValue(paramName.ToLower().Trim(), out result);
	  return found ? result : string.Empty;
	}

	public const string Date_DisplayFormat = "dd/MMM/yyyy";
	/// <summary>
	/// Converts any given Date string to dd/MMM/yyyy Format i.e 12/12/2020 to 12/Dec/2020
	/// </summary>
	/// <param name="date"></param>
	/// <returns></returns>
	public static string GetDateString(this DateTime date)  // 
	{
	  return date != DateTime.MinValue ? date.ToString(Date_DisplayFormat) : string.Empty;
	}

	/// <summary>
	/// Convers Given Date string to Passed Date Format String.
	/// </summary>
	/// <param name="date"></param>
	/// <param name="DisplayFormat"></param>
	/// <returns></returns>
	public static string GetDateString(this DateTime date, string DisplayFormat)
	{
	  return date != DateTime.MinValue ? date.ToString(DisplayFormat) : string.Empty;
	}
	/// <summary>
	/// Type Safely Converts and Return string to Date string
	/// </summary>
	/// <param name="dateString"></param>
	/// <returns></returns>
	public static DateTime GetDateFromString(this string dateString)
	{
	  if (!string.IsNullOrEmpty(dateString))
	  {
		DateTime result;
		var isValidDate = DateTime.TryParse(dateString, out result);
		return isValidDate ? result : DateTime.MinValue;
	  }
	  return DateTime.MinValue;
	}

	/// <summary>
	/// Formats the string according to the specified mask
	/// </summary>
	/// <param name="inputstring">The inputstring string.</param>
	/// <param name="mask">The mask for formatting. Like "A##-##-T-###Z"</param>
	/// <returns>The formatted string</returns>
	public static string FormatWithMask(this string inputstring, string mask)
	{
	  if (string.IsNullOrEmpty(inputstring)) return inputstring;
	  var output = string.Empty;
	  var index = 0;
	  foreach (var m in mask)
	  {
		if (m == '#')
		{
		  if (index < inputstring.Length)
		  {
			output += inputstring[index];
			index++;
		  }
		}
		else
		  output += m;
	  }
	  return output;
	}

	// Used when we want to completely remove HTML code and not encode it with XML entities.
	/// <summary>
	/// Used when we want to completely remove HTML code and not encode it with XML entities.
	/// </summary>
	/// <param name="inputstring"></param>
	/// <returns></returns>
	public static string StripHtml(this string inputstring)
	{
	  // Will this simple expression replace all tags???
	  var tagsExpression = new Regex(@"</?.+?>");
	  return tagsExpression.Replace(inputstring, " ");
	}

	/// <summary>
	/// Shorthand to Check if given string is a valid Date string or not.
	/// </summary>
	/// <param name="inputstring"></param>
	/// <returns></returns>
	public static bool IsDate(this string inputstring)
	{
	  if (!string.IsNullOrEmpty(inputstring))
	  {
		DateTime dt;
		return (DateTime.TryParse(inputstring, out dt));
	  }
	  else
	  {
		return false;
	  }
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="inputstring"></param>
	/// <returns></returns>
	public static string ToCamelCase(this string inputstring)
	{
	  if (inputstring == null || inputstring.Length < 2)
		return inputstring;

	  string[] words = inputstring.Split(
		  new char[] { },
		  StringSplitOptions.RemoveEmptyEntries);

	  string result = words[0].ToLower();
	  for (int i = 1; i < words.Length; i++)
	  {
		result +=
			words[i].Substring(0, 1).ToUpper() +
			words[i].Substring(1);
	  }

	  return result;
	}

	/// <summary>
	/// Truncates the string to a specified length and replace the truncated to a ...
	/// </summary>
	/// <param name="the_string">string that will be truncated</param>
	/// <param name="maxLength">total length of characters to maintain before the truncate happens</param>
	/// <returns>truncated string</returns>
	public static string Truncate(this string the_string, int maxLength)
	{
	  // replaces the truncated string to a ...
	  const string suffix = "...";
	  string truncatedString = the_string;

	  if (maxLength <= 0) return truncatedString;
	  int strLength = maxLength - suffix.Length;

	  if (strLength <= 0) return truncatedString;

	  if (the_string == null || the_string.Length <= maxLength) return truncatedString;

	  truncatedString = the_string.Substring(0, strLength);
	  truncatedString = truncatedString.TrimEnd();
	  truncatedString += suffix;
	  return truncatedString;
	}
	public static T Parse<T>(this string value)
	{
	  // Get default value for type so if string
	  // is empty then we can return default value.
	  T result = default(T);
	  if (!string.IsNullOrEmpty(value))
	  {
		// we are not going to handle exception here
		// if you need SafeParse then you should create
		// another method specially for that.
		TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
		result = (T)tc.ConvertFrom(value);
	  }
	  return result;
	}


	///<summary>	Checks if a given string contains any of the characters in the passed array of characters.</summary>
	public static bool ContainsAny(this string theString, char[] characters)
	{
	  foreach (char character in characters)
	  {
		if (theString.Contains(character.ToString()))
		{
		  return true;
		}
	  }
	  return false;
	}

	/// <summary>
	/// Check whether the specified string contains an array of strings for each.
	/// </summary>
	/// <param name="value"></param>
	/// <param name="values"></param>
	/// <returns></returns>
	public static bool ContainsAll(
this string value,
params string[] values)
	{
	  foreach (string one in values)
	  {
		if (!value.Contains(one))
		{
		  return false;
		}
	  }
	  return true;
	}

	///<summary>returns default value if string is null or empty or white spaces string</summary>
	///
	public static string DefaultIfEmpty(this string str, string defaultValue, bool considerWhiteSpaceIsEmpty = false)
	{
	  return (considerWhiteSpaceIsEmpty ? string.IsNullOrWhiteSpace(str) : string.IsNullOrEmpty(str)) ? defaultValue : str;
	}

	/// <summary>
	/// Converts any given string to Proper Case
	/// </summary>
	/// <param name="text"></param>
	/// <returns></returns>
	public static string ToProperCase(this string text)
	{
	  System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
	  System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;
	  return textInfo.ToTitleCase(text);
	}

	/// <summary>
	/// Checks if the given string is a Valid URL or Not
	/// </summary>
	/// <param name="text"></param>
	/// <returns></returns>
	public static bool IsValidUrl(this string text)
	{
	  Regex rx = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
	  return rx.IsMatch(text);
	}

	/// <summary>
	/// shorthand for Returning true when a given string is not null or empty
	/// </summary>
	/// <param name="input"></param>
	/// <returns>Returns true when a given string is not null or empty</returns>
	public static bool IsNotNullOrEmpty(this string input)
	{
	  return !String.IsNullOrEmpty(input);
	}
	/// <summary>
	/// shorthand for Returning true when a given string is  null or empty
	/// </summary>
	/// <param name="input"></param>
	/// <returns>Returns true when a given string is  null or empty</returns>
	public static bool IsNullOrEmpty(this string input)
	{
	  return String.IsNullOrEmpty(input);
	}


	/// <summary>
	/// shorthand for Returnings true when a given string is  null or empty or containts only white space
	/// </summary>
	/// <param name="input"></param>
	/// <returns>Returnings true when a given string is  null or empty or containts only white space</returns>
	public static bool IsNullOrEmptyOrWhiteSpace(this string input)
	{
	  return String.IsNullOrWhiteSpace(input);
	}

	/// <summary>
	/// shorthand for Returnings true when a given string is not null or empty or containts only white space
	/// </summary>
	/// <param name="input"></param>
	/// <returns>Returnings true when a given string is not null or empty or containts only white space</returns>
	public static bool IsNotNullOrEmptyOrWhiteSpace(this string input)
	{
	  return !String.IsNullOrWhiteSpace(input);
	}


	/// <summary>
	/// Returns a value indicating whether the specified <see cref="string"/> object occurs within the <paramref name="this"/> string.
	/// A parameter specifies the type of search to use for the specified string.
	/// </summary>
	/// <param name="this">The string to search in</param>
	/// <param name="value">The string to seek</param>
	/// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
	/// <exception cref="ArgumentNullException"><paramref name="this"/> or <paramref name="value"/> is <c>null</c></exception>
	/// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a valid <see cref="StringComparison"/> value</exception>
	/// <returns>
	/// <c>true</c> if the <paramref name="value"/> parameter occurs within the <paramref name="this"/> parameter, 
	/// or if <paramref name="value"/> is the empty string (<c>""</c>); 
	/// otherwise, <c>false</c>.
	/// </returns>
	/// <remarks>
	/// The <paramref name="comparisonType"/> parameter specifies to search for the value parameter using the current or invariant culture, 
	/// using a case-sensitive or case-insensitive search, and using word or ordinal comparison rules.
	/// </remarks>
	public static bool Contains(this string @this, string value, StringComparison comparisonType)
	{
	  if (@this == null)
	  {
		throw new ArgumentNullException("this");
	  }

	  return @this.IndexOf(value, comparisonType) >= 0;
	}

	/// <summary>
	/// Parse a string value to the given Enum
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="value"></param>
	/// <returns></returns>
	public static T ToEnum<T>(this string value)
   where T : struct
	{
	  return (T)Enum.Parse(typeof(T), value, true);
	}

	/// <summary>
	/// shorthand to convert type safe string to decimal
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public static decimal ToDecimal(this string value)
	{
	  decimal number;

	  Decimal.TryParse(value, out number);

	  return number;
	}

	/// <summary>
	/// Converts a string with the length of 1 to the supplied enum type
	/// </summary>
	/// <typeparam name="T">The enum type that you want to convert the string to</typeparam>
	/// <param name="string">A string, with the length of 1, that maps to a enum item on the enum type you're supplying</param>
	/// <returns>An enum of the supplied type</returns>
	public static T ToEnumChar<T>(this string @string)
	{
	  if (string.IsNullOrEmpty(@string))
	  {
		throw new ArgumentException("Argument null or empty");
	  }
	  if (@string.Length > 1)
	  {
		throw new ArgumentException("Argument length greater than one");
	  }
	  return (T)Enum.ToObject(typeof(T), @string[0]);
	}

	/// <summary>
	/// shorthand for String.Replace function
	/// </summary>
	/// <param name="originalString"></param>
	/// <param name="oldValue"></param>
	/// <param name="newValue"></param>
	/// <param name="comparisonType"></param>
	/// <returns>shorthand for string.Replace Function</returns>
	public static String Replace(this String originalString, String oldValue, String newValue, StringComparison comparisonType)
	{
	  Int32 startIndex = 0;

	  while (true)
	  {
		startIndex = originalString.IndexOf(oldValue, startIndex, comparisonType);

		if (startIndex < 0)
		{
		  break;
		}

		originalString = String.Concat(originalString.Substring(0, startIndex), newValue, originalString.Substring(startIndex + oldValue.Length));

		startIndex += newValue.Length;
	  }

	  return (originalString);
	}


	public static bool IsStrongPassword(this string s)
	{
	  bool isStrong = Regex.IsMatch(s, @"[\d]");
	  if (isStrong) isStrong = Regex.IsMatch(s, @"[a-z]");
	  if (isStrong) isStrong = Regex.IsMatch(s, @"[A-Z]");
	  if (isStrong) isStrong = Regex.IsMatch(s, @"[\s~!@#\$%\^&\*\(\)\{\}\|\[\]\\:;'?,.`+=<>\/]");
	  if (isStrong) isStrong = s.Length > 7;
	  return isStrong;
	}

	/// <summary>
	/// Tells whether a value can be coalesced into a boolean, Very usefull to check and Convert Database char/bit/boolean values
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public static bool IsBoolean(this string value)
	{
	  var val = value.ToLower().Trim();
	  if (val == "false")
		return false;
	  if (val == "f")
		return false;
	  if (val == "true")
		return true;
	  if (val == "t")
		return true;
	  if (val == "yes")
		return true;
	  if (val == "no")
		return false;
	  if (val == "y")
		return true;
	  if (val == "n")
		return false;
	  throw new ArgumentException("Value is not a boolean value.");
	}

  }
}
