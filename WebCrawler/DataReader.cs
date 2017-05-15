using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlScrawler
{
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    class DataReader
    {
        private IList<HtmlData> _htmlDataList;

        public DataReader(IList<HtmlData> htmlDataList)
        {
            this._htmlDataList = htmlDataList;
        }

        public IList<HtmlData> ReadHtmlData(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.Load(sr);
                var nodess = doc.DocumentNode.DescendantsAndSelf("div").Where(tag => tag.Id.Contains("questionid"));

                foreach (var node in nodess)
                {
                    var htmlData = new HtmlData
                                       {
                                           Question = node.FirstChild.InnerText,
                                           Option1 = node.FirstChild.NextSibling.NextSibling.InnerText,
                                           Option2 =
                                               node.FirstChild.NextSibling.NextSibling.NextSibling.InnerText,
                                           Option3 =
                                               node.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling
                                               .InnerText,
                                           Option4 =
                                               node.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling
                                               .NextSibling.InnerText,
                                           CorrectAnswer =
                                               node.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling
                                               .NextSibling.NextSibling.Attributes["value"].Value
                                       };




                    this._htmlDataList.Add(htmlData);
                }
                sr.Close();

                return this._htmlDataList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in reading htmlData", ex);
            }
        }
    }
}
