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
using System.Diagnostics;

namespace MonoTranslateGtk
{
	class MainClass
	{
		static AppWindow win;
		public static void Main (string[] args)
		{
			Application.Init ();
			win = new AppWindow ();
			win.Show ();
			Application.Run ();
		}
		
		public static void showMessage(Gtk.Window wnd,string text)
		{
			Gtk.MessageDialog msg = new MessageDialog(wnd, DialogFlags.DestroyWithParent & DialogFlags.Modal,MessageType.Error,ButtonsType.Ok,true,text);
			msg.Run();
			msg.Destroy();
		}
		public static void tryBrowse(string link)
		{
						try
				{
					Process.Start ("firefox", link);
				} 
				catch (Exception)
				{
					MonoTranslateGtk.MainClass.showMessage(win,link);
				}
		}
	}
}