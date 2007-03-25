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
	public class TranslatorEngine
	{
	
		private IDictionary langpairs;
		private string configFile;

		public TranslatorEngine() : this(null)
		{
			
		}	
			
		public TranslatorEngine(string confFile)
		{
			langpairs = new Hashtable();
			configFile = confFile;
			LoadLangPairs();
		}
		
		public string Translate(string text, string langpair, string translator)
		{
			ITranslator t = TranslatorFactoy.GetTranslator(translator);
			string val = (string)((IDictionary)langpairs[translator])[langpair];
			string ret = t.TranslateText(text, val);
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
		
		public void SetConfigFile(string confFile)
		{
			configFile = confFile;
		}

		public string GetConfigFile()
		{
			return configFile;
		}		
		
		void checkConfigFile()
		{
			if(string.IsNullOrEmpty(GetConfigFile()))
				throw new System.NullReferenceException("The Engine Configuration file is empty or null");
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
			/*IDictionaryEnumerator o = langpairs.GetEnumerator();
			while (o.MoveNext())
			{
				System.Console.WriteLine(o.Key);
				IDictionaryEnumerator ot = ((IDictionary)o.Value).GetEnumerator();
				while (ot.MoveNext())
				{
					System.Console.WriteLine(ot.Key + " " + ot.Value);					
				}
			}*/
		}
		
	}
}