/*
 Copyright (C) 2007 Johan.Hernandez <thepumpkin1979@gmail.com>

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
		
using System;
using Gtk;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using Mono.Unix;

namespace MonoTranslateGtk
{
public class AppAboutDialog : Gtk.AboutDialog
	{
		public AppAboutDialog() : base ()
		{
			AboutDialog.SetUrlHook (delegate(Gtk.AboutDialog dialog, string link)
			{
				MainClass.tryBrowse(link);
			});
			
			string [] authors = {"Johan Alexander Hernandez Torrenegra <thepumpkin1979@gmail.com> | http://johansoft.blogspot.com",
								"Juan Emilio Gabito <gabitoju@internet.com.uy>"};

			Name = "Mono Translate";
			//Logo = new Gdk.Pixbuf(null,"monkey-big.png");
			
			
			Comments = Catalog.GetString ("MonoTranslate is an easy to use translation tool written using the MONO Framework and Tango Project User Interface.");
			
			Assembly asm = Assembly.GetCallingAssembly();
			AssemblyName asmname = asm.GetName ();
			
					using (Stream stream = asm.GetManifestResourceStream("COPYING"))
			{
				StreamReader reader = new StreamReader(stream);
				License = reader.ReadToEnd ();
				reader.Close ();
			}
			WrapLicense = true;
			
			Copyright = "Copyright \u00a9 2007 Juan E. Gabito & Johan A. Hernandez T.";
			
			Version = asmname.Version.ToString ();
			Authors = authors;
			Website = "http://code.google.com/p/monotranslate";
			WebsiteLabel = "Mono Translate Official Web Site";
		}
	}
}
