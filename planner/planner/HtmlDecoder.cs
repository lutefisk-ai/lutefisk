using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace planner
{
    public class HtmlDecoder
    {
        public static string getSourceCode(string uri)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse requestP = (HttpWebResponse)request.GetResponse();
                StreamReader streamReader = new StreamReader(requestP.GetResponseStream());
                string sourceCode = streamReader.ReadToEnd();
                streamReader.Close();
                requestP.Close();
                return sourceCode;
            }
            catch (Exception)
            {
                throw null;
            }
        }

        public HtmlDocument LoadHtml(string uri)
        {
            string sourceCode;
            var htmlDocument = new HtmlDocument();
            sourceCode = HtmlDecoder.getSourceCode(uri);
            if (!string.IsNullOrEmpty(sourceCode))
            {
                htmlDocument.LoadHtml("@" + sourceCode); // string containing the HTML content
                return htmlDocument;
            }
            return null;
        }
    }
}