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

// created on 03/28/2007 at 18:28

using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace MonoTranslate.Engine
{
	public class WriteHistory
	{
		private IsolatedStorageFileStream history;
		private StreamWriter writer;
		private static WriteHistory instance = null;
		
		private WriteHistory()
		{
			history = new IsolatedStorageFileStream("mts-history.mts", FileMode.Create);
			writer = new StreamWriter(history);
		}
		
		public static WriteHistory GetInstance()
		{
			if (instance == null)
				instance = new WriteHistory();
			return instance;
		}
		
		public void WriteToHistory(Result r)
		{
			string line = r.GetOriginalText();
			line += ":" + r.GetTranslatedText();
			line += ":" + r.GetTranslator();
			line += ":" + r.GetLanguage();
			Console.WriteLine(Environment.SpecialFolder.ApplicationData);
			Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			writer.WriteLine(line);			
		}
		
		public void Close()
		{
			writer.Flush();
			writer.Close();
			history.Close();
		}
	}
}