/*
 Copyright (C) 2007 Juan Emilio Gabito
 gabitoju@interntet.com.uy

 This file is part of MonoTranslate.

 MonoTranslate is free software; you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation; either version 2 of the License, or
 (at your option) any later version.

 MonoTranslate is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with MonoTranslate; if not, write to the Free Software
 Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/
// created on 03/26/2007 at 19:31

using System;

namespace MonoTranslate.Engine
{

	/*
	 * Class Result
	 * This class represent the result of a translation request.
	 * Each line showed in the history corresponds to one Result
	 * object.
	 */
	public class Result
	{
		private string originalText;
		private string translatedText;
		private string translator;
		private string language;
		
		public Result(string oriText, string tranText, string trans, string lang)
		{
			originalText = oriText;
			translatedText = tranText;
			translator = trans;
			language = lang;
		}
		
		public void SetOriginalText(string oriText)
		{
			originalText = oriText;
		}
		
		public void SetTranslatedText(string tranText)
		{
			translatedText = tranText;
		}
		
		public void SetTranslator(string trans)
		{
			translator = trans;
		}
		
		public void SetLanguage(string lang)
		{
			language = lang;
		}
		
		public string GetOriginalText()
		{
			return originalText;
		}
		
		public string GetTranslatedText()
		{
			return translatedText;
		}
		
		public string GetTranslator()
		{
			return translator;
		}
		
		public string GetLanguage()
		{
			return language;
		}
	}
}