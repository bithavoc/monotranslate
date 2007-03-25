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
using System.Collections;
using Gtk;
using MonoTranslate.Engine;
using MonoTranslateGtk;
namespace MonoTranslateGtk
{
	
	
	public partial class AppWindow : Gtk.Window
	{
			//Local Window Translator Instance.
		private TranslatorEngine engine = null;
		private StatusIcon icon; 
		public AppWindow() : 
				base(Gtk.WindowType.Toplevel)
		{
					Build ();
	
			initUI();
			initEngine();
		}

				
	//cosole debug method(emitted only on DEBUG)
	[System.Diagnostics.Conditional("DEBUG")]
	private static void debug(string text,params object[] prms )
	{
		text = string.Format(text,prms);
		Console.WriteLine("[custom debug]:{0}",text);
	}
	
#region App Methods
	private void initUI()
	{
		/*this.icon = new MonoTranslateGtk.TrayIcon(this);
		this.icon.ShowAll();
		 * */
		this.icon = new StatusIcon(Gdk.Pixbuf.LoadFromResource ("address-book-new.png"));
		this.icon.Tooltip = this.Title;
		this.icon.Activate+=delegate
		{
			this.Visible = !this.Visible;
		};
		this.txtTranslatedText.Editable = false;
		prepareComboBox(this.cmbLanguages);
		prepareComboBox(this.cmbTranslators);
	}
	//Init engine instance and values.
	private void initEngine()
	{
		this.engine = new TranslatorEngine();
		initEngineUI();
	}
	private static void prepareComboBox(ComboBoxEntry cmb)
	{
		ListStore listMOdel = new ListStore(typeof(string));
		cmb.Model = listMOdel;
		/*CellRendererText cmb_cell = new CellRendererText();
		cmb_cell.Alignment = Pango.Alignment.Left;
		cmb.PackStart(cmb_cell,true);
		cmb.AddAttribute(cmb_cell,"text",0);*/
	}
	
	//Clean combo box items.
	private static void clearComboBoxItems(ComboBoxEntry cmb)
	{
		((ListStore)(cmb.Model)).Clear();
	}

	public void showMessage(string text)
	{
		MainClass.showMessage(this,text);
	}
	private void initEngineUI()
	{
		loadTranslators();
	}
	
	//Fill the Translators List
	private void loadTranslators()
	{
		IEnumerator i = engine.GetTranslators().GetEnumerator();
		while (i.MoveNext())
		{
			string value = (string)i.Current;
			this.cmbTranslators.AppendText(value);
			debug("appending value {0}",value);
			this.cmbLanguages.Active = 0;
		}
	}
	
	//Fill the Language List.
	private void loadLanguages(string translator)
	{
		//Clean language list.
		clearComboBoxItems(cmbLanguages);
		if(string.IsNullOrEmpty(translator))
			return;
		
			string trans = (string)translator;
			IList l = engine.GetLanguages(trans);
			IEnumerator i = l.GetEnumerator();
			while (i.MoveNext())
			{
				this.cmbLanguages.AppendText(i.Current.ToString());
			}
		this.cmbLanguages.Active = 0;
	}
	
	private bool validateInput()
	{

				if (this.txtOriginalText.Buffer.Text.Trim() == string.Empty)
				{
				//Gtk.MessageDialog msg = new MessageDialog(this, DialogFlags.
					showMessage("Please, enter a text to translate");
					return false;
				}
				if (this.cmbTranslators.Entry == null)
				{
					showMessage("Please, select a translator");
					return false;
				}
				if (this.cmbLanguages.Entry == null)
				{
					showMessage("Please, select languages");
					return false;
				}				
				return true;

	}
	private void translate()
	{
		try
		{
			string translator = this.cmbTranslators.Entry.Text;
			string language = this.cmbLanguages.Entry.Text;
			string sourceText = this.txtOriginalText.Buffer.Text;
			string translatedData = this.engine.Translate(sourceText,language,translator);
			this.txtTranslatedText.Buffer.Text = translatedData;
		}
		catch (System.Net.WebException ex)
		{
			showMessage("An error has ocurred. Check your Internet connection.");				
		}	
	}
#endregion
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnShown(object sender, System.EventArgs e)
	{
		
	}

	protected virtual void OnCmbTranslatorsChanged(object sender, System.EventArgs e)
	{
		Entry entry = this.cmbTranslators.Entry;
		if(entry != null)
		{
			this.loadLanguages(entry.Text);
		}
	}

	protected virtual void OnAboutActivated(object sender, System.EventArgs e)
	{
		using(AppAboutDialog dialog = new AppAboutDialog())
		{
			dialog.Run();
				dialog.Destroy();
		}
	}

	protected virtual void OnTbtnTranslateActivated(object sender, System.EventArgs e)
	{
				debug("Let's translate!");
		if(validateInput())
		{
			translate();
		}
	}

	protected virtual void action_CloseApp(object sender, System.EventArgs e)
	{
		Application.Quit();
	}

	protected virtual void OnOnlineUserGuideActivated(object sender, System.EventArgs e)
	{
		MainClass.tryBrowse("http://code.google.com/p/monotranslate/wiki/userguide");
	}
	}
}
