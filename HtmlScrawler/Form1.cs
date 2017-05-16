using System;
using System.Linq;
using System.Windows.Forms;

namespace HtmlScrawler
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Make it generic

            var dataReader = new DataReader();
            var htmlData = dataReader.ReadHtmlData(@"http://www.bcsprep.com/bcsquestionsbyyear.php?id=33");




            var dataWriter = new SqlWriter(datas, @"D:\tempData.sql");
            dataWriter.WriteData();



        }
    }
}
