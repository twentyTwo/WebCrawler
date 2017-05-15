using System;
using System.Collections.Generic;

namespace HtmlScrawler
{
    using System.IO;

    class SqlWriter : IDataWriter
    {
        private IList<HtmlData> _htmlDatas;

        private string _filePath;
        public SqlWriter(IList<HtmlData> datas, string filePath )
        {
            _htmlDatas = datas;
            this._filePath = filePath;
        }

        public void WriteData()
        {
            using (StreamWriter writetext = new StreamWriter(this._filePath))
            {
                string header =
                    "DECLARE @tempTable TABLE (Question NVARCHAR(MAX), Ans1 NVARCHAR(MAX), Ans2 NVARCHAR(MAX), Ans3 NVARCHAR(MAX), Ans4 NVARCHAR(MAX), CorrectAnswer NVARCHAR(MAX))\n\n";
                writetext.Write(header);

                string SQLQuery=String.Empty;

                foreach (var data in this._htmlDatas)
                {
                    SQLQuery = $"INSERT INTO @tempTable VALUES( N'{data.Question.Substring(3).Trim()}', N'{data.Option1}', N'{data.Option2}', N'{data.Option3}', N'{data.Option4}', '{data.CorrectAnswer}')";
                    writetext.WriteLine(SQLQuery);
                }
            }
            
        }
    }
}
