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

// created on 03/17/2007 at 20:08

using System;
using System.Net;
using System.IO;
using MonoTranslate.Interfaces;

namespace MonoTranslate.Translator
{
    /*
     * Abstract Class AbstractTranslator
     * This class implements ITranslator. All translators class will derive
     * from this one.
	 */
	public abstract class AbstractTranslator : ITranslator 
	{
	
		//The request object that comunicates with the server
		protected WebRequest request;
		//The object that sends data to the server
		protected Stream dataStream;

		public abstract string TranslateText(string text, string langPair);
		
		/*
		 * This function parses the content returned by the translator and returns
		 * the translated text.
		 */
		protected abstract string GetTranslatedText(string serverResponse);

	}

}