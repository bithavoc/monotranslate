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
// created on 03/18/2007 at 14:24

using System.Collections;
using System.Xml;
using MonoTranslate.Translator;
using MonoTranslate.Interfaces;

namespace MonoTranslate.Engine
{

	/*
	 * Class TranslatorEngine
	 * This class implements the Facade pattern.
	 * It is the entry point to the system. It is designed in a way that all call are done by this
	 * class, so there is less connection between the UI and the translators.
	 */
	public class TranslatorEngine
	{
	
		private IDictionary langpairs; //match between the lang pair and the service code (Spanish to English = es_en)
		private string configFile; //the configuration file path and name
		private IList results; //the list of translations results

		public TranslatorEngine() 
		{
			langpairs = new Hashtable();
			results = new ArrayList();
			LoadHistory l = new LoadHistory();
			results = l.Load();
		}	
			
		public TranslatorEngine(string confFile)
		{
			langpairs = new Hashtable();
			configFile = confFile;
			results = new ArrayList();
			LoadLangPairs();
			LoadHistory l = new LoadHistory();
			results = l.Load();			
		}
		
		public string Translate(string text, string langpair, string translator)
		{
			Result r = null;
			ITranslator t = TranslatorFactoy.GetTranslator(translator);
			string val = (string)((IDictionary)langpairs[translator])[langpair];
			string ret = t.TranslateText(text, val);
			r = new Result(text, ret, translator, langpair);
			results.Add(r);
			WriteHistory w = WriteHistory.GetInstance();
			w.WriteToHistory(r);
			return ret;
		}
		
		public IList GetTranslators()
		{
			IList ret = new ArrayList();
			IDictionaryEnumerator o = langpairs.GetEnumerator();
			while (o.MoveNext())
			{
				ret.Add(o.Key);
			}
			return ret;
		}
		
		public IList GetLanguages(string translator)
		{
			IList ret = new ArrayList();
			IDictionary d = (IDictionary)langpairs[translator];
			IDictionaryEnumerator o = d.GetEnumerator();
			while (o.MoveNext())
			{
				ret.Add(o.Key);
			}			
			return ret;
		}
		
		public IList GetResults()
		{
			return results;
		}
		
		public void SetConfigFile(string confFile)
		{
			configFile = confFile;
			LoadLangPairs();
		}

		public string GetConfigFile()
		{
			return configFile;
		}		
		
		private void checkConfigFile()
		{
			//if(string.IsNullOrEmpty(GetConfigFile()))
			if (GetConfigFile() == null)
				throw new System.NullReferenceException("The Engine configuration file is empty or null");
			if (!System.IO.File.Exists(GetConfigFile()))
				throw new System.IO.FileNotFoundException("Engine configuration file could not be loaded");				
		}
						
		private void LoadLangPairs()
		{
			checkConfigFile();
			XmlDocument doc = new XmlDocument();
			doc.Load(GetConfigFile());
			
			XmlNodeList nodeList = doc.SelectNodes("configuration/translator");
			IEnumerator nodeEnum = nodeList.GetEnumerator();
			while (nodeEnum.MoveNext())
			{
				IDictionary lp = new Hashtable();
				
				XmlNode n = (XmlNode)nodeEnum.Current;
				XmlNode nodeName = n.SelectSingleNode("name");
				string name = nodeName.InnerText;
				
				XmlNodeList pairs = n.SelectNodes("languagePairs/pair");
				IEnumerator pairsEnum = pairs.GetEnumerator();
				while (pairsEnum.MoveNext())
				{
					XmlNode pair = (XmlNode)pairsEnum.Current;
					string language = pair.InnerText;
					XmlNode value = pair.Attributes.GetNamedItem("value");
					string val = value.InnerText;
					lp.Add(language, val);
				}
				
				langpairs.Add(name, lp);
			}

		}
		
	}
}