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

// created on 03/17/2007 at 20:09

using System;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MonoTranslate.Translator
{
	public class BabelfishTranslator : AbstractTranslator
	{
		public BabelfishTranslator()
		{
			request = WebRequest.Create("http://babelfish.altavista.com/tr");
			request.Method = "POST";
		}
		
		
		public override string TranslateText(string text, string langPair)
		{
			string postData = "trtext=" + text + "&lp=" + langPair;
			byte[] byteArray = Encoding.UTF8.GetBytes (postData);
			request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
                        
            dataStream = request.GetRequestStream ();
            dataStream.Write (byteArray, 0, byteArray.Length);
            dataStream.Close ();

            // Get the response.
            WebResponse response = request.GetResponse ();

            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream ();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader (dataStream);
         
               // Read the content.
            string responseFromServer = reader.ReadToEnd ();
         
         
            // Clean up the streams.
            reader.Close ();
            dataStream.Close ();
            response.Close ();
            
			return GetTranslatedText(responseFromServer);				
		}
		
		protected override string GetTranslatedText(string serverResponse)
		{			
			Match m = Regex.Match(serverResponse, "<td bgcolor=white class=s><div style=padding:10px;>.*</div></td>");
				
			string aux = Regex.Replace(m.ToString(), "<.*?>", "");
			
			return aux;
		}
	}
}