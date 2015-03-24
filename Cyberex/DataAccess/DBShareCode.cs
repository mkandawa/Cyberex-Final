using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ChatRecord
{
    public static  class DBShareCode
    {
        public static int ShareCodeID { get; set; }
        public static string ShareCode { get; set;}
        public static string ShareCompany { get; set; }
        public static bool CheckTemplate()
        {
            bool Result = false;
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = " select count(*) from ShareCode where sharecodetext = '" + ShareCode + "' order by 1";
            int i = Convert.ToInt32(db.ExecuteScalar(CommandType.Text, strsql));

            db.Close();
            if (i > 0)
                Result = true;
            return Result;
        }

        public static DataTable GetShareCodeList()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = " select ID, shareCodeText, company  from ShareCode order by 2";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }
        public static DataTable GetTotalShareCode()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "  select    sharecode.ShareCodeText  , count(*) as TotalShare  from chats  inner join channel on channel.id = chats.channelid  ";
                   strsql+= "  inner join  sharecode on channel.sharecodeid =  sharecode.id group by  sharecode.ShareCodeText order by 1";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }
        public static DataTable GetTotalShareCodeChat2()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "  select    sharecode.ShareCodeText  , count(*) as TotalShare  from chats2  inner join channel2 on channel2.id = chats2.channelid  ";
            strsql += "  inner join  sharecode on channel2.sharecodeid =  sharecode.id group by  sharecode.ShareCodeText order by 1";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }
        public static DataTable GetTotalAuthors()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "  SELECT AUTHOR,  COUNT( AUTHOR) as TotalAuthor FROM CHATS  GROUP BY AUTHOR order by 1  ";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }
        public static DataTable GetTotalAuthorsChat2()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = "  SELECT Creator,  COUNT( Creator) as TotalAuthor FROM CHATS2  GROUP BY Creator order by 1  ";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strsql);
            db.Close();
            return ds.Tables[0];
        }
        public static string  GetTotalPosts()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = " SELECT COUNT(*) as Total FROM CHATS";
            Int32 i  = Convert.ToInt32( db.ExecuteScalar(CommandType.Text, strsql));
            db.Close();
            return i.ToString();
        }
        public static string GetTotalPostsChat2()
        {
            DBManager db = new DBManager("odbc");
            db.Open();
            DataTable dt = new DataTable();
            string strsql = " SELECT COUNT(*) as Total FROM CHATS2";
            Int32 i = Convert.ToInt32(db.ExecuteScalar(CommandType.Text, strsql));
            db.Close();
            return i.ToString();
        }
        public static  bool  InsertShareCode()
        {
            bool Result = false;
            DBManager db = new DBManager("odbc");
            db.Open();
            string strsql = "insert into sharecode (sharecodetext,Company) values ('" + ShareCode + "','"+ShareCompany+"')";
            db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);
            Result = true;
            return Result;
        }

        public static bool UpdateShareCode()
        {
            bool Result = false;
            DBManager db = new DBManager("odbc");
            db.Open();
            string strsql = "update sharecode set sharecodeText = '" + ShareCode + "', Company = '" + ShareCompany + "' where ID = " + ShareCodeID + "";
            db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);
            Result = true;
            return Result;
        }

        public static bool DeleteShareCode()
        {
            bool Result = false;
            DBManager db = new DBManager("odbc");
            db.Open();
            string strsql = "Delete from sharecode where ID = " + ShareCodeID + "";
            db.ExecuteNonQuery(System.Data.CommandType.Text, strsql);
            Result = true;
            return Result;
        }
    }

}
