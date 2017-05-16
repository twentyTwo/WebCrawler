// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="noor.alam.shuvo@gmail.com" company="">
// //   Copyright @ 2017
// // </copyright>
// <summary>
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace HtmlScrawler
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using HtmlAgilityPack;

    internal class DataExtractor
    {
        private HtmlDocument _htmlDocument;

        public DataExtractor(HtmlDocument htmlDocument)
        {
            this._htmlDocument = htmlDocument;
        }

        public IEnumerable<HtmlNode> ExtractData(HtmlTags htmlTag, string tagId)
        {
            try
            {
                var nodes =
                this._htmlDocument.DocumentNode.DescendantsAndSelf(HtmlTags.Div)
                    .Where<HtmlNode>(tag => tag.Id.Contains(tagId));

                return nodes;
            }
            catch (Exception ex)
            {

                throw new Exception("Error in extracting data.", ex);
            }
        }

        void a(IEnumerable<HtmlNode> nodes)
        {
            foreach (var node in nodes)
            {
                var htmlData = new HtmlData
                {
                    Question = node.FirstChild.InnerText,
                    Option1 = node.FirstChild.NextSibling.NextSibling.InnerText,
                    Option2 = node.FirstChild.NextSibling.NextSibling.NextSibling.InnerText,
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

                // this._htmlDatas.Add(htmlData);
            }
        }
    }
}