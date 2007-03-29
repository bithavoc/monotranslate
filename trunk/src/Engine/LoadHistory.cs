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
// created on 03/29/2007 at 11:22

using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections;

namespace MonoTranslate.Engine
{
	/*
	 * Class LoadHistory
	 * This class is use to load the user translation history. 
	 */
	public class LoadHistory
	{
			private IsolatedStorageFileStream history;
			private StreamReader reader;
			
			public LoadHistory()
			{
				history = new IsolatedStorageFileStream("mts-history.mts", FileMode.Open);
				reader = new StreamReader(history);
			}
			
			public IList Load()
			{
				IList ret = new ArrayList();
				string line;
				do
				{
					line = reader.ReadLine();
					if (line != null)
					{
						string[] parts = line.Split(':');
						Result r = new Result(parts[0], parts[1], parts[2], parts[3]);
						ret.Add(r);
					}				
				} while (line != null);
				reader.Close();
				history.Close();
				return ret;
			}
	}
}