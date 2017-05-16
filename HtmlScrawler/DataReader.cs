using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlScrawler
{
    using System.IO;
    using System.Net;

    using HtmlAgilityPack;

    internal class DataReader
    {
        private readonly IList<HtmlData> _htmlDatas;

        private int _sourceUrl;



        public HtmlDocument ReadHtmlData(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();

                var getResponseStream = response.GetResponseStream();

                if (getResponseStream == Stream.Null)
                {
                    throw new ArgumentNullException($"No response found for the web request which called {url}");
                }

                var streamReader = new StreamReader(response.GetResponseStream());
                var htmlDocument = new HtmlDocument();
                htmlDocument.Load(streamReader);
                streamReader.Close();
                return htmlDocument;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in reading htmlData", ex);
            }
        }

    }
}
