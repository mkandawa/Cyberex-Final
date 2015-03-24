using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ChatRecord
{
    public static class DBChat_2
    {
        public static string title { get; set; }        
        public static string description { get; set; }                
        public static int sharecodeid { get; set; }
        public static string sharecode { get; set; }
        public static string creator { get; set; }
        public static int channelid { get; set; }
        public static string pubdate { get; set; }
        public static string pubdateFull { get; set; }
        public static string lastBuildDate { get; set; }
        public static string TemplateName { get; set; }
        public static string author { get; set; }

        public static Int32 InsertChannel()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            string str = description.Replace("'", "");
            str = sharecode + " " + str;
            string strDate = DateTime.Now.ToString("yyyy/MM/dd HH:MM:ss");
            string strLastBuild = DateTime.Now.ToString("dd/MM/yyyy HH:MM:ss");
            string strsql = "insert into channel2 (title,description,CreateDate,sharecodeid,lastBuildDate)  values ('" + title + "','" + str + "',  '" + strDate + "'," + sharecodeid + ",'"+ strLastBuild +"')";

            db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);

            //string strsql2 = "select max(ID) from channel";
            string strsql2 = "select LAST_INSERT_ID()";
            int ID = Convert.ToInt32(db.ExecuteScalar(System.Data.CommandType.Text, strsql2));
            db.Close();
            return ID;
        }
        public static DataTable GetChatDBByChannelID()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "select *  from channel2 where  id  =  " + channelid + "";

            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }
        public static DataTable GetAllChannel()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "select *  from channel2  ORDER BY 1 ";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }
          public static int  GetChannelIDByBuildDate()
        {
            
            DBManager db = new DBManager("odbc");
            db.Open();
            DataSet ds = new DataSet();

            string strsql = "select ID  from channel2 where lastBuildDate =  '" + lastBuildDate + "'  ORDER BY 1 DESC LIMIT 1";

            int i  = Convert.ToInt32( db.ExecuteScalar(CommandType.Text, strsql));
            db.Close();
            return i;
        }
        public static bool  InsertChats()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            string str = description.Replace("'", "");
            
            string strsql = "insert into chats2 (title,description,pubdate,channelid,creator,PubDateFull)  values ('" + title + "','" + description + "',  '" + pubdate + "'," + channelid  + ",'"+ creator +"','"+ pubdateFull +"')";

            db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);
            return true;
        }
        public static DataTable GetAuthors()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = " select distinct creator  from  Chats2 order by 1";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
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
            string strsql = "select distinct lastBuildDate , id from channel2 where sharecodeid = " + sharecodeid + " order by id desc ";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }

        public static string GetChatDBByBuildDate()
        {
            StringBuilder str = new StringBuilder();
            DBManager db = new DBManager("odbc");
            db.Open();
            DataSet ds = new DataSet();

            string strsql = "select *  from channel2 where lastBuildDate =  '" + lastBuildDate + "'  ORDER BY 1 DESC LIMIT 1";

            ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    DBChat.channelid = channelid;
                    str.Append(dr[1].ToString() + Environment.NewLine);
                    str.Append(dr[2].ToString() + Environment.NewLine);
                   // str.Append(dr[3].ToString() + Environment.NewLine);
                   // str.Append(dr[4].ToString() + Environment.NewLine);
                    str.Append(dr[5].ToString() + Environment.NewLine);
                   // str.Append(dr[6].ToString() + Environment.NewLine);
                    //str.Append(dr[7].ToString() + Environment.NewLine);
                    str.Append(Environment.NewLine);
                    break;
                }
            }
            DataTable dtDetail = DBChat_2.GetChatDetailBySearch();
            if (dtDetail.Rows.Count > 0)
            {

                foreach (DataRow dr in dtDetail.Rows)
                {
                    str.Append(dr[1].ToString() + Environment.NewLine);
                    str.Append(dr[2].ToString() + Environment.NewLine);
                    str.Append(dr[3].ToString() + Environment.NewLine);
                    str.Append(Environment.NewLine);
                    str.Append(dr[5].ToString() + Environment.NewLine);
                    str.Append(Environment.NewLine);

                    // str.Append(Environment.NewLine);
                }
            }
            return str.ToString();


        }
        public static DataTable GetChatDB()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "select *  from channel2 where description like '" + sharecode + "%'  ORDER BY 1 DESC LIMIT 1";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }
        public static DataTable GetChatDetail()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "select *  from chats2 where channelid = " + channelid + "";
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
                        txt += " and  ( chats2.description LIKE '%" + dr[1].ToString() + "%'";
                    }
                    else
                    {
                        txt += " or chats2.description LIKE '%" + dr[1].ToString() + "%' ";
                    }

                    idx++;
                }

                txt += " )";



                DataTable dt = new DataTable();
                string strsql = " select *  from chats2  inner join channel2 on channel2.id = chats2.channelid ";
                strsql += "  inner join  sharecode on channel2.sharecodeid =  sharecode.id where channel2.id = " + channelid + "";
                strsql += "  and sharecode.sharecodetext = '" + sharecode + "' ";
                strsql += txt;
                ds = db.ExecuteDataSet(CommandType.Text, strsql);
                db.Close();

            }
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
                        txt += " and  ( chats2.description LIKE '%" + dr[1].ToString() + "%'";
                    }
                    else
                    {
                        txt += " or chats2.description LIKE '%" + dr[1].ToString() + "%' ";
                    }

                    idx++;
                }

                txt += " )";



                DataTable dt = new DataTable();
                string strsql = " select *  from chats2  where channelid = " + channelid + " ";
                //strsql += "  inner join  sharecode on channel.sharecodeid =  sharecode.id where channel.id = " + channelid + "";
                //strsql += "  and sharecode.sharecodetext = '" + sharecode + "' ";
                strsql += txt;
                ds = db.ExecuteDataSet(CommandType.Text, strsql);
                db.Close();

            }
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
        public static string GetChatDetailBySearchChatBoxXML()
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
                        txt += " and  ( chats2.description LIKE '%" + dr[1].ToString() + "%'";
                    }
                    else
                    {
                        txt += " or chats2.description LIKE '%" + dr[1].ToString() + "%' ";
                    }

                    idx++;
                }

                txt += " )";



                DataTable dt = new DataTable();
                string strsql = " select creator, description, DATE_FORMAT(pubDate,'%d-%m-%Y') pubDate from chats2 where channelid = " + channelid + "";
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
                        txt += " where ( chats2.description LIKE '%" + dr[1].ToString() + "%'";
                    }
                    else
                    {
                        txt += " or chats2.description LIKE '%" + dr[1].ToString() + "%' ";
                    }

                    idx++;
                    //txt += " chats.description LIKE '%" + dr[1].ToString() + "%' or  chats.description LIKE '%" + term2 + "%' or chats.description LIKE '%" + term3 + "%'";
                    //txt += " or chats.description LIKE '%" + term4 + "%' or  chats.description LIKE '%" + term5 + "%' or chats.description LIKE '%" + term6 + "%'";
                    //txt += " or chats.description LIKE '%" + term7 + "%' or  chats.description LIKE '%" + term8 + "%'";
                }

                txt += " )";
                txt += " and sharecode.sharecodetext = '" + sharecode + "'";                            
                string strsql = " select count(channel2.id) as Counter, sharecode.sharecodetext , channel2.sharecodeid,chats2.creator, DATE_FORMAT(chats2.pubDate, '%d/%m/%Y') as pubDate from channel2  ";
                strsql += " inner join chats2 on chats2.channelid =channel2.id  inner join sharecode on channel2.sharecodeid = sharecode.id  ";
                strsql += txt;
                strsql += " group by chats2.pubdate, chats2.creator,sharecodetext having chats2.creator ='" + author + "' ";

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
                        txt += " where ( chats2.description LIKE '%" + dr[1].ToString() + "%'";
                    }
                    else
                    {
                        txt += " or chats2.description LIKE '%" + dr[1].ToString() + "%' ";
                    }

                    idx++;
                    //txt += " chats.description LIKE '%" + dr[1].ToString() + "%' or  chats.description LIKE '%" + term2 + "%' or chats.description LIKE '%" + term3 + "%'";
                    //txt += " or chats.description LIKE '%" + term4 + "%' or  chats.description LIKE '%" + term5 + "%' or chats.description LIKE '%" + term6 + "%'";
                    //txt += " or chats.description LIKE '%" + term7 + "%' or  chats.description LIKE '%" + term8 + "%'";
                }

                txt += " )";
                txt += " and sharecode.sharecodetext = '" + sharecode + "'";

                string strsql = " select  sharecode.sharecodetext , channel2.sharecodeid,chats2.creator, chats2.pubDateFull as pubDate from channel2  ";
                strsql += " inner join chats2 on chats2.channelid =channel2.id  inner join sharecode on channel2.sharecodeid = sharecode.id  ";
                strsql += txt;
                strsql += " and  chats2.creator ='" + author + "' order by chats2.pubdate desc ";


                //string strsql = " select count(channel2.id) as Counter, sharecode.sharecodetext , channel2.sharecodeid,chats2.creator, DATE_FORMAT(chats2.pubDate, '%d/%m/%Y') as pubDate from channel2  ";
                //strsql += " inner join chats2 on chats2.channelid =channel2.id  inner join sharecode on channel2.sharecodeid = sharecode.id  ";
                //strsql += txt;
                //strsql += " group by chats2.pubdate, chats2.creator,sharecodetext having chats2.creator ='" + author + "' ";


                dsN = db.ExecuteDataSet(CommandType.Text, strsql);
            }
            db.Close();
            return dsN.Tables[0];
        }

        public static bool DeleteChannel()
        {
            bool Result = false;
            string strsql = "Delete from channel2 where id = " + channelid;
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
