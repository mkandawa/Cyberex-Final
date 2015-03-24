using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ChatRecord
{
    public partial class Form1 : Form
    {
        private TreeNode Root;
        private readonly string[] SearchStrings;
        private int MaxTreeDepth;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //db.BeginTransaction();
            try
            {
                DBManager db = new DBManager("odbc");
                db.Open();
                string strsql ="select description from chats";
                IDataReader reader  ;
                reader =  db.ExecuteReader(CommandType.Text, strsql);
                StringBuilder sb = new StringBuilder();
                while (reader.Read())
                { 
                    sb.Append(reader.GetValue(0));
                }
                string searchTerm = "loo";
                string[] source = sb.ToString().Split(new char[] { '.', '?', '!', ' ', ';', ':', ',','/','\n' }, StringSplitOptions.RemoveEmptyEntries);
                var matchQuery = from word in source
                                 where word.ToLowerInvariant().Contains(searchTerm.ToLowerInvariant())
                                 select word;
                int wordCount = matchQuery.Count();
                int wordcount = wordCount;
                string searchterm = searchTerm;
            }
            catch (Exception ex)
            { 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          //  char[] splitchar = { ' ' };
          //  string tbd = textBox1.Text + ' ' + textBox2.Text + ' ' + textBox3.Text + ' ' + textBox4.Text + ' ' +
          //               textBox5.Text + ' ' + textBox6.Text + ' ' + textBox7.Text + ' ' + textBox8.Text + ' ';

            //string[] txtSearchArray = tbd.Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
            //string[] txtCountArray = new string[txtSearchArray.Length];
            //// the recordset loop will come here
            //// for (int i=0;i<txtSearchArray.Length;i++)
            ////{
            //string mSQL = "Select ";
            //for (int i = 0; i < txtSearchArray.Length; i++)
            //{
            //    if (txtSearchArray[i].Length > 0)
            //    {
            //        mSQL += "'" + (txtSearchArray[i].Trim()) + "' AS Term" + i + ", SUM((LENGTH(Description) - LENGTH(REPLACE(Description, " + "'" + txtSearchArray[i].ToLower() + "'" + ", ''))) / LENGTH(" +
            //                "'" + txtSearchArray[i].ToLower() + "'" + ")) AS Expr" + i + ",";
            //    }
            //}
            //mSQL = mSQL.Substring(0, mSQL.Length - 1) + " From Chats";
        }
    }
}
