using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ChatRecord
{
    public static class DBChat
    {
        public static string title { get; set; }
        public static string link { get; set; }
        public static string description { get; set; }
        public static string language { get; set; }
        public static string lastBuildDate { get; set; }
        public static string copyright { get; set; }
        public static string docs { get; set; }
        public static string ttl { get; set; }
        public static int sharecodeid { get; set; }

        public static int channelid { get; set; }
        public static string author { get; set; }
        public static string pubDate { get; set; }
        public static string pubDateFull { get; set; }

        public static string item1 { get; set; }
        public static string item2 { get; set; }
        public static string item3 { get; set; }
        public static string item4 { get; set; }
        public static string item5 { get; set; }
        public static string item6 { get; set; }
        public static string item7 { get; set; }
        public static string item8 { get; set; }

        public static string sharecode { get; set; }

        public static string TemplateName { get; set; }

        public static string stdate { get; set; }
        public static string endate { get; set; }

        public static Int32 InsertChannel()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            string str = description.Replace("'", "");           
            string strDate = DateTime.Now.ToString("yyyy/MM/dd");
            string strsql = "insert into channel (title,link,description,language,lastBuildDate,copyright,docs,ttl,CreateDate, sharecodeid)  values ('" + title + "','" + link + "','" + str + "','" + language + "','" + lastBuildDate + "','" + copyright + "','" + docs + "','" + ttl + "', '" + strDate + "'," + sharecodeid + ")";

            db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);

            //string strsql2 = "select max(ID) from channel";
            string strsql2 = "select LAST_INSERT_ID()";
            int ID = Convert.ToInt32(db.ExecuteScalar(System.Data.CommandType.Text, strsql2));
            db.Close();
            return ID;
        }

        public static void InsertChat()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            string strsql = "insert into chats   (ChannelID, title, author, description, link, pubDate, pubDateFull )values (" + channelid + ",'" + title + "','" + author + "','" + description + "','" + link + "','" + pubDate + "','"+ pubDateFull +"' )";
            //string strsql = "insert into chats values (" + 1 + "," + 1 + ",'" + "AAAA" + "','" + "BBBB" + "','" + "CCCCC" + "','" + "DDDD" + "','" + "EEEE" + "')";
            db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);
            db.Close();

        }

        public static DataTable GetTemplates()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = " select distinct TemplateName  from Template order by 1";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }
        public static DataTable GetAuthors()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = " select distinct Author  from  Chats order by 1";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }

        public static DataTable GetChart()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            DataSet dsN = new DataSet();
            //string TemplateName =  TemplateName
            string strsql1 = " select * from Template where TemplateName = '" + TemplateName + "' order by 1";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string txt = "";
                int idx = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (idx == 0)
                    {
                        txt += " where ( chats.description LIKE '%" + dr[1].ToString() + "%'";
                    }
                    else
                    {
                        txt += " or chats.description LIKE '%" + dr[1].ToString() + "%' ";
                    }

                    idx++;
                    //txt += " chats.description LIKE '%" + dr[1].ToString() + "%' or  chats.description LIKE '%" + term2 + "%' or chats.description LIKE '%" + term3 + "%'";
                    //txt += " or chats.description LIKE '%" + term4 + "%' or  chats.description LIKE '%" + term5 + "%' or chats.description LIKE '%" + term6 + "%'";
                    //txt += " or chats.description LIKE '%" + term7 + "%' or  chats.description LIKE '%" + term8 + "%'";
                }

                txt += " )";
                txt += " and sharecode.sharecodetext = '" + sharecode + "'";

                string strsql = " select count(channel.id) as Counter, sharecode.sharecodetext , channel.sharecodeid,chats.author, DATE_FORMAT(chats.pubDate, '%d/%m/%Y') as pubDate from channel  ";
                strsql += " inner join chats on chats.channelid =channel.id  inner join sharecode on channel.sharecodeid = sharecode.id  ";
                strsql += txt;
                strsql += " group by chats.pubdate, chats.author,sharecodetext having chats.author ='" + author + "' ";


                dsN = db.ExecuteDataSet(CommandType.Text, strsql);
            }
            db.Close();
            return dsN.Tables[0];
        }
        public static DataTable GetChartList()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            DataSet dsN = new DataSet();
            //string TemplateName =  TemplateName
            string strsql1 = " select * from Template where TemplateName = '" + TemplateName + "' order by 1";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string txt = "";
                int idx = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (idx == 0)
                    {
                        txt += " where ( chats.description LIKE '%" + dr[1].ToString() + "%'";
                    }
                    else
                    {
                        txt += " or chats.description LIKE '%" + dr[1].ToString() + "%' ";
                    }

                    idx++;
                    //txt += " chats.description LIKE '%" + dr[1].ToString() + "%' or  chats.description LIKE '%" + term2 + "%' or chats.description LIKE '%" + term3 + "%'";
                    //txt += " or chats.description LIKE '%" + term4 + "%' or  chats.description LIKE '%" + term5 + "%' or chats.description LIKE '%" + term6 + "%'";
                    //txt += " or chats.description LIKE '%" + term7 + "%' or  chats.description LIKE '%" + term8 + "%'";
                }

                txt += " )";
                txt += " and sharecode.sharecodetext = '" + sharecode + "'";

                string strsql = " select  sharecode.sharecodetext , channel.sharecodeid,chats.author,chats.pubDateFull as pubDate from channel  ";
                strsql += " inner join chats on chats.channelid =channel.id  inner join sharecode on channel.sharecodeid = sharecode.id  ";
                strsql += txt;
                strsql += " and chats.author ='" + author + "' order by chats.pubdate desc ";


                dsN = db.ExecuteDataSet(CommandType.Text, strsql);
            }
            db.Close();
            return dsN.Tables[0];
        }
        public static DataTable GetTemplatesItems(string TemplateName)
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = " select * from Template where TemplateName = '" + TemplateName + "' order by 1";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }

        public static DataTable GetSearchedItemsByTemplate(string TemplateName)
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = " select * from Template where TemplateName = '" + TemplateName + "' order by 1";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                // string term1, term2, term3, term4, term5, term6, term7, term8;
                char[] splitchar = { ';' };
                string txt = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txt += dr[1].ToString() + ';';
                }
                string[] txtSearchArray = txt.Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
                string[] txtCountArray = new string[txtSearchArray.Length];
                // the recordset loop will come here
                // for (int i=0;i<txtSearchArray.Length;i++)
                //{
                string mSQL = "Select ";
                for (int i = 0; i < txtSearchArray.Length; i++)
                {
                    if (txtSearchArray[i].Length > 0)
                    {
                        mSQL += "'" + (txtSearchArray[i].Trim()) + "' AS Term" + i + ", SUM((LENGTH(Description) - LENGTH(REPLACE(Description, " + "'" + txtSearchArray[i].Trim() + "'" + ", ''))) / LENGTH(" +
                                "'" + txtSearchArray[i].Trim() + "'" + ")) AS Expr" + i + ",";
                    }
                }
                mSQL = mSQL.Substring(0, mSQL.Length - 1) + " From Chats where  channelid = " + channelid + "";
                ds = db.ExecuteDataSet(CommandType.Text, mSQL);
            }
            db.Close();
            return ds.Tables[0];
        }

        public static DataTable GetSearchedItemsByTemplateAllChats(string TemplateName)
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = " select * from Template where TemplateName = '" + TemplateName + "' order by 1";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                // string term1, term2, term3, term4, term5, term6, term7, term8;
                char[] splitchar = { ';' };
                string txt = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txt += dr[1].ToString() + ';';
                }
                string[] txtSearchArray = txt.Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
                string[] txtCountArray = new string[txtSearchArray.Length];
                // the recordset loop will come here
                // for (int i=0;i<txtSearchArray.Length;i++)
                //{
                string mSQL = "Select ";
                for (int i = 0; i < txtSearchArray.Length; i++)
                {
                    if (txtSearchArray[i].Length > 0)
                    {
                        mSQL += "'" + (txtSearchArray[i].Trim()) + "' AS Term" + i + ", SUM((LENGTH(Description) - LENGTH(REPLACE(Description, " + "'" + txtSearchArray[i].Trim() + "'" + ", ''))) / LENGTH(" +
                                "'" + txtSearchArray[i].Trim() + "'" + ")) AS Expr" + i + ",";
                    }
                }
                mSQL = mSQL.Substring(0, mSQL.Length - 1) + " From Chats ";
                ds = db.ExecuteDataSet(CommandType.Text, mSQL);
            }
            db.Close();
            return ds.Tables[0];
        }
        public static bool CheckTemplate(string TemplateName)
        {
            bool Result = false;
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = " select count(*) from Template where TemplateName = '" + TemplateName + "' order by 1";
            int i = Convert.ToInt32(db.ExecuteScalar(CommandType.Text, strsql));

            db.Close();
            if (i > 0)
                Result = true;
            return Result;
        }

        public static bool InsertTemplate()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            bool Result = false;
            try
            {

                db.BeginTransaction();

                string strsql = " delete from template where TemplateName ='" + TemplateName + "'";
                db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);

                strsql = "insert into template (TemplateText,TemplateName)values ('" + item1 + "','" + TemplateName + "')";
                db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);

                strsql = "insert into template (TemplateText,TemplateName)values ('" + item2 + "','" + TemplateName + "')";
                db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);

                strsql = "insert into template (TemplateText,TemplateName)values ('" + item3 + "','" + TemplateName + "')";
                db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);

                strsql = "insert into template (TemplateText,TemplateName)values ('" + item4 + "','" + TemplateName + "')";
                db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);

                strsql = "insert into template (TemplateText,TemplateName)values ('" + item5 + "','" + TemplateName + "')";
                db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);

                strsql = "insert into template (TemplateText,TemplateName)values ('" + item6 + "','" + TemplateName + "')";
                db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);

                strsql = "insert into template (TemplateText,TemplateName)values ('" + item7 + "','" + TemplateName + "')";
                db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);

                strsql = "insert into template (TemplateText,TemplateName)values ('" + item8 + "','" + TemplateName + "')";
                db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);

                db.Transaction.Commit();
                Result = true;
                db.Close();
            }
            catch (Exception)
            {
                db.Transaction.Rollback();
                Result = false;
            }

            return Result;

        }
        public static bool UpdateTemplate()
        {
            bool Result = false;
            DBManager db = new DBManager("odbc");
            db.Open();
            return Result;
        }


        public static bool DeleteTemplate()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            bool Result = false;
            try
            {
                string strsql = " delete from template where TemplateName ='" + TemplateName + "'";
                db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);
                Result = true;
            }
            catch (Exception ex)
            {
            }
            return Result;
        }

        public static DataTable GetChatDB()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "select *  from channel where description like '" + sharecode + "%'  ORDER BY 1 DESC LIMIT 1";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }

        public static DataTable GetAllShareCode()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "select *  from sharecode Order BY 1 ";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }
        public static DataTable GetChannelIDbyShareCode(bool chk)
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "";
            if (chk == false)
            {
                strsql = "select id from channel where sharecodeid = " + sharecodeid + "";
            }
            else
            {
                strsql = "select id from channel2 where sharecodeid = " + sharecodeid + "";
            }
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }

        public static DataTable GetChannelIDbyDateAndShareCode(bool chk)
        {
          //  string[] stdt = stdate.Split('/');

           //string [] ent =  endate.Split('/');

            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "";
            if (chk == false)
            {
                strsql += " select id from channel where sharecodeid = " + sharecodeid + "";
                strsql += " and  CreateDate between '" + stdate + "' and '" + endate + "'";
            }

            else
            {
                strsql += " select id from channel2 where sharecodeid = " + sharecodeid + "";
                strsql += " and  CreateDate between '" + stdate + "' and '" + endate + "'";
            }
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }
        public static DataTable GetChannelIDbyDate(bool chk)
        {
            //  string[] stdt = stdate.Split('/');

            //string [] ent =  endate.Split('/');

            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "";
            if (chk == false)
            {
                strsql += " select id from channel where ";
                strsql += "   CreateDate between '" + stdate + "' and '" + endate + "'";
            }
            else
            {
                strsql += " select id from channel2 where ";
                strsql += "   CreateDate between '" + stdate + "' and '" + endate + "'";
            }
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }


        public static bool DeleteChatDetails  (bool chk)
        {
            bool Result = false;
            try
            {
                string strsql = "";
                string str = "";
                if (chk == true)
                {
                    strsql = "delete from chats2";
                    str = " delete from channel2";
                }
                else
                {
                    strsql = "delete from chats";
                    str = " delete from channel";
                }
                DBManager db = new DBManager("odbc");
                db.Open();
                db.ExecuteNonQuery(CommandType.Text, strsql);
                db.ExecuteNonQuery(CommandType.Text, str);
                Result = true;
            }
            catch (Exception ex)
            {

            }
            return Result;
        }

        public static int  GetChannelIDByBuildDate()
        {
            
            DBManager db = new DBManager("odbc");
            db.Open();
            DataSet ds = new DataSet();

            string strsql = "select ID  from channel where lastBuildDate =  '" + lastBuildDate + "'  ORDER BY 1 DESC LIMIT 1";

            int i  = Convert.ToInt32( db.ExecuteScalar(CommandType.Text, strsql));
            db.Close();
            return i;
        }

        public static string GetChatDBByBuildDate()
        {
            StringBuilder str = new StringBuilder();
            DBManager db = new DBManager("odbc");
            db.Open();
            DataSet ds = new DataSet();

            string strsql = "select *  from channel where lastBuildDate =  '" + lastBuildDate + "'  ORDER BY 1 DESC LIMIT 1";

            ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    DBChat.channelid = channelid;
                    str.Append(dr[1].ToString() + Environment.NewLine);
                    str.Append(dr[2].ToString() + Environment.NewLine);
                    str.Append(dr[3].ToString() + Environment.NewLine);
                    str.Append(dr[4].ToString() + Environment.NewLine);
                    str.Append(dr[5].ToString() + Environment.NewLine);
                    str.Append(dr[6].ToString() + Environment.NewLine);
                    //str.Append(dr[7].ToString() + Environment.NewLine);
                    str.Append(Environment.NewLine);
                    break;
                }
            }
            DataTable dtDetail = DBChat.GetChatDetailBySearch();
            if (dtDetail.Rows.Count > 0)
            {

                foreach (DataRow dr in dtDetail.Rows)
                {
                    str.Append(dr[6].ToString() + Environment.NewLine);
                    str.Append(dr[2].ToString() + Environment.NewLine);
                    str.Append(dr[3].ToString() + Environment.NewLine);
                    str.Append(Environment.NewLine);
                    str.Append(dr[4].ToString() + Environment.NewLine);
                    str.Append(Environment.NewLine);
                   
                    // str.Append(Environment.NewLine);
                }
            }
            return str.ToString();


        }
        public static DataTable GetChatDetail()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "select *  from chats where channelid = " + channelid + "";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }

        public static DataTable GetChatDetailBySearch()
        {
            DBManager db = new DBManager("odbc");
            db.Open();

            string strsql1 = " select * from Template where TemplateName = '" + TemplateName + "' order by 1";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string txt = "";
                int idx = 0;
                txt += " and sharecode.sharecodetext = '" + sharecode + "'";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (idx == 0)
                    {
                        txt += " and  ( chats.description LIKE '%" + dr[1].ToString() + "%'";
                    }
                    else
                    {
                        txt += " or chats.description LIKE '%" + dr[1].ToString() + "%' ";
                    }

                    idx++;
                }

                txt += " )";



                DataTable dt = new DataTable();
                string strsql = " select *  from chats  inner join channel on channel.id = chats.channelid ";
                strsql += "  inner join  sharecode on channel.sharecodeid =  sharecode.id where channel.id = " + channelid + "";
                strsql += "  and sharecode.sharecodetext = '" + sharecode + "' ";
                strsql += txt;
                ds = db.ExecuteDataSet(CommandType.Text, strsql);
                db.Close();

            }
            return ds.Tables[0];
        }

        public static int GetShareCodeID()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "select ID from sharecode where  sharecodetext = '" + sharecode + "'";
            int ID = Convert.ToInt32(db.ExecuteScalar(CommandType.Text, strsql));
            db.Close();
            return ID;
        }


        public static DataTable GetShareChatDates()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "select distinct lastBuildDate , id from channel where sharecodeid = " + sharecodeid + " order by id desc ";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }

        private static string GetShareHolderName()
        {
            string a = "";
            string test = "";
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "SELECT sharecode.Company FROM sharecode where ShareCodeText='" + sharecode + "'";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                a = ds.Tables[0].Rows[0][0].ToString();
            }
            try
            {
                string[] ssize = a.Split(new char[0]);
                test = ssize[0].ToString() + " " + "Share Chat:";
            }
            catch (Exception)
            {


            }

            return test;
        }
        public static string GetHtml()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            
            string strsql = "select author, description, pubDate from chats where channelid = " + channelid + "";

            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            StringBuilder str = new StringBuilder();

            str.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
            str.Append("<head> <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />");
            str.Append("<title>Untitled Document</title>");
            str.Append("<head>");
            str.Append("</head> <body>");
            string title = GetShareHolderName();
            str.Append("<html>");
            str.Append("<table cellspacing='0' width='100%'>");
            str.Append("<tr style='background-color:#6566a2; color:white'> <td colspan='2'<strong>");
            str.Append(title);
            str.Append("</strong> </td>");
            str.Append("</tr>");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    str.Append("<tr style='background-color:#e6e5f4'> <td width='50%' style= 'pedding-left:30px;text-align:left;' >");
                    str.Append("<strong>");
                    str.Append(dr[0].ToString());
                    str.Append("</strong>");
                    str.Append("</td>");
                    str.Append("<td width='50%' style= 'pedding-right:130px;text-align:right;' >");
                    str.Append(dr[2].ToString());
                    str.Append("</td>");
                    str.Append("</tr>");
                    str.Append("<tr>");
                    str.Append("<td colspan='2'>");
                    str.Append(dr[1].ToString());
                    str.Append("</td>");
                    str.Append("</tr>");
                }
                str.Append("</table>");

                str.Append("</body> </html>");
            }
            string html = str.ToString().Replace("\n", "");

            db.Close();

            return html;
        }
        public static DataTable GetAllChannel()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "select *  from channel  ORDER BY 1 ";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }
        public static DataTable GetChatDBByChannelID()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "select *  from channel where  id  =  " + channelid + "";

            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }
        public static DataTable GetChatDetailBySearchByChannelID()
        {
            DBManager db = new DBManager("odbc");
            db.Open();

            string strsql1 = " select * from Template where TemplateName = '" + TemplateName + "' order by 1";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string txt = "";
                int idx = 0;
                // txt += " and sharecode.sharecodetext = '" + sharecode + "'";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (idx == 0)
                    {
                        txt += " and  ( chats.description LIKE '%" + dr[1].ToString() + "%'";
                    }
                    else
                    {
                        txt += " or chats.description LIKE '%" + dr[1].ToString() + "%' ";
                    }

                    idx++;
                }

                txt += " )";



                DataTable dt = new DataTable();
                string strsql = " select *  from chats  where channelid = " + channelid + " ";
                //strsql += "  inner join  sharecode on channel.sharecodeid =  sharecode.id where channel.id = " + channelid + "";
                //strsql += "  and sharecode.sharecodetext = '" + sharecode + "' ";
                strsql += txt;
                ds = db.ExecuteDataSet(CommandType.Text, strsql);
                db.Close();

            }
            return ds.Tables[0];
        }
        public static bool DeleteChatDetailsbyChannelID(bool chk)
        {
            bool Result = false;
            try
            {
                string strsql = "";
                string str = "";
                if (chk == false)
                {
                    strsql = "delete from chats where channelid = " + channelid + "";
                    str = " delete from channel where id = " + channelid + "";
                }
                else
                {
                    strsql = "delete from chats2 where channelid = " + channelid + "";
                    str = " delete from channel2 where id = " + channelid + "";
                }
                DBManager db = new DBManager("odbc");
                db.Open();
                db.ExecuteNonQuery(CommandType.Text, strsql);
                db.ExecuteNonQuery(CommandType.Text, str);
                Result = true;
            }
            catch (Exception ex)
            {

            }
            return Result;
        }

        public static string  GetChatDetailBySearchChatBoxXML()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            string XML = "";
            string strsql1 = " select * from Template where TemplateName = '" + TemplateName + "' order by 1";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string txt = "";
                int idx = 0;
               // txt += " and sharecode.sharecodetext = '" + sharecode + "'";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (idx == 0)
                    {
                        txt += " and  ( chats.description LIKE '%" + dr[1].ToString() + "%'";
                    }
                    else
                    {
                        txt += " or chats.description LIKE '%" + dr[1].ToString() + "%' ";
                    }

                    idx++;
                }

                txt += " )";



                DataTable dt = new DataTable();
                string strsql = " select author, description, DATE_FORMAT(pubDate,'%d-%m-%Y') pubDate  from chats where channelid = " + channelid + "";              
               // strsql += "  and sharecode.sharecodetext = '" + sharecode + "' ";
                strsql += txt;
                ds = db.ExecuteDataSet(CommandType.Text, strsql);
                StringBuilder str = new StringBuilder();

                str.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
                str.Append("<head> <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />");
                str.Append("<title>Untitled Document</title>");
                str.Append("<head>");
                str.Append("</head> <body>");
                string title = GetShareHolderName();
                str.Append("<html>");
                str.Append("<table cellspacing='0' width='100%'>");
                str.Append("<tr style='background-color:#6566a2; color:white'> <td colspan='2'<strong>");
                str.Append(title);
                str.Append("</strong> </td>");
                str.Append("</tr>");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        str.Append("<tr style='background-color:#e6e5f4'> <td width='50%' style= 'pedding-left:30px;text-align:left;' >");
                        str.Append("<strong>");
                        str.Append(dr[0].ToString());
                        str.Append("</strong>");
                        str.Append("</td>");
                        str.Append("<td width='50%' style= 'pedding-right:130px;text-align:right;' >");
                        str.Append(dr[2].ToString());
                        str.Append("</td>");
                        str.Append("</tr>");
                        str.Append("<tr>");
                        str.Append("<td colspan='2'>");
                        str.Append(dr[1].ToString());
                        str.Append("</td>");
                        str.Append("</tr>");
                    }
                    str.Append("</table>");

                    str.Append("</body> </html>");
                }
                 XML = str.ToString().Replace("\n", "");
                db.Close();

            }
            return XML;
        }

        public static bool DeleteChannel()
        {
            bool Result = false;
            string strsql = "Delete from channel where id = " + channelid;
            try
            {
                DBManager db = new DBManager("odbc");
                db.Open();
                db.ExecuteNonQuery(CommandType.Text, strsql);
                Result = true;
            }
            catch (Exception)
            {

            }
            return Result;
        }
    }
}
