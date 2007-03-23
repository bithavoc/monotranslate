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

using MonoTranslate.Interfaces;

namespace MonoTranslate.Translator
{
	public class TranslatorFactoy
	{
	
		public static ITranslator GetTranslator(string translator)
		{
			ITranslator t = null;
			
			if (translator == "Babelfish")
				return (t = new BabelfishTranslator());
			return t;
		}
	
	} 
}