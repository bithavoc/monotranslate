// project created on 03/16/2007 at 16:56
using System;
using System.Net;
using System.IO;
using System.Text;

namespace MonoTranslate.Translator
{
	public class GoogleTranslate
	{
	
		private WebRequest request;
		private Stream dataStream;

		public GoogleTranslate()
		{
			//request = WebRequest.Create("http://translate.google.com/translate");
			request = WebRequest.Create("http://babelfish.altavista.com/tr");
			request.Method = "POST";
		}
		
		public void TranslateText(string text, string langPair)
		{
			//string postData = "source=" + text + "&langpair=" + langPair;
			string postData = "trtext=" + text + "&lp=" + langPair;
			byte[] byteArray = Encoding.UTF8.GetBytes (postData);
			request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
                        
            dataStream = request.GetRequestStream ();
            dataStream.Write (byteArray, 0, byteArray.Length);
            dataStream.Close ();
            // Get the response.
            WebResponse response = request.GetResponse ();
            // Display the status.
            Console.WriteLine (((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream ();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader (dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd ();
            // Display the content.
            Console.WriteLine (responseFromServer);
            // Clean up the streams.
            reader.Close ();
            dataStream.Close ();
            response.Close ();				
		}

	}

}