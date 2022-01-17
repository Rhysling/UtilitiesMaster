using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UtilitiesMaster.TextClean
{
	public static class CleanInputText
	{
		public static string StripNonAlphaNumeric(string strIn)
		{
			string strExpr = @"\W";
			var re = new Regex(strExpr);
		  return re.Replace(strIn, "");
		}

		public static string CleanInputNumber(string inp)
		{
		  string pattern  = @"[\s\$,\)]";
		  var res = Regex.Replace(inp, pattern, "");

		  pattern = @"\(";
		  res = Regex.Replace(res, pattern, "-");

			return res;

		}

		public static string CleanURL(string inp)
		{
			string pattern = @"^[^\d\w]*(http://)*";
			var res = Regex.Replace(inp, pattern, "");

			pattern = @"[^\d\w]*$";
			res = Regex.Replace(res, pattern, "");

			return res;
		}

	}
}

//Public Shared Function CleanPhone(ByVal Phone As String) As String
//    Dim strPhoneExpr As String = "^\D*1?\D*([2-9]\d{2})\D*(\d{3})\D*(\d{4})$"
//    Dim re As New Regex(strPhoneExpr)
//    Dim m As Match = re.Match(Phone)
//    If m.Success Then
//      Return m.Groups(1).Value + "-" + m.Groups(2).Value + "-" + m.Groups(3).Value
//    Else
//      Return Phone
//    End If
//  End Function

//  Public Shared Function CleanInputNumber(ByVal Inp As String) As String

//    Dim pattern As String = "[\s\$,\)]"
//    Dim res = Regex.Replace(Inp, pattern, "")

//    pattern = "\("
//    res = Regex.Replace(res, pattern, "-")

//    Return res

//  End Function

//  Public Shared Function CleanInputNumberFull(ByVal Inp As String) As String

//    Dim pattern As String = "[^\d\.\(\-]"
//    Dim res = Regex.Replace(Inp, pattern, "")

//    pattern = "\("
//    res = Regex.Replace(res, pattern, "-")

//    Return res

//  End Function


//  Public Shared Function PercentToSingle(ByVal strIn As String, ByVal scale As Integer, ByRef IsValid As Boolean) As Single

//    Dim IsPercent As Boolean = False
//    Dim rv As Single = 0

//    strIn = strIn.Trim
//    If strIn.EndsWith("%") Then
//      strIn = strIn.Substring(0, strIn.Length - 1)
//      IsPercent = True
//    Else
//      IsPercent = False
//    End If
//    If IsNumeric(strIn) Then
//      Try
//        If IsPercent Then
//          rv = Convert.ToSingle(System.Math.Round(Convert.ToSingle(strIn), scale) / 100)
//        Else
//          rv = Convert.ToSingle(System.Math.Round(Convert.ToSingle(strIn), scale + 2))
//        End If
//        IsValid = True
//      Catch
//        IsValid = False
//      End Try
//    Else
//      IsValid = False
//    End If

//    Return rv

//  End Function


//  Public Shared Function StripPath(ByVal fileName As String) As String
//    Dim strExpr As String = "(\\|\/)(?<fn>\w+.\w{3,4})$"
//    Dim re As New System.Text.RegularExpressions.Regex(strExpr, RegexOptions.Compiled)
//    If re.Match(fileName).Success Then
//      Return re.Match(fileName).Result("${fn}")
//    Else
//      Return ""
//    End If

//  End Function

//  Public Shared Function StripQuotes(ByVal strIn As String) As String
//    Dim strExpr As String = "(""|')"
//    Dim re As New Regex(strExpr)
//    Return re.Replace(strIn, "")
//  End Function

//  Public Shared Function StripSpaces(ByVal strIn As String) As String
//    Dim strExpr As String = "\s"
//    Dim re As New Regex(strExpr)
//    Return re.Replace(strIn, "")
//  End Function

//  Public Shared Function StripNonDigits(ByVal strIn As String) As String
//    Dim strExpr As String = "\D"
//    Dim re As New Regex(strExpr)
//    Return re.Replace(strIn, "")
//  End Function
