using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml.Linq;
using System.IO;
using System.Net.NetworkInformation;

namespace ChatRecord
{
    public partial class Home : Form
    {
        bool stopBtnClk = false;
        bool Isorted = false;
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FetchShareData("MTE");
        }
        private bool FetchSingleShareData(String shareCode) // fetch Single share chat and save to folder - Tab-1
        {
            string appPath = System.Configuration.ConfigurationManager.AppSettings["FilePath"]; // Get path of xml files
            if (!Directory.Exists(appPath))
            {
                Directory.CreateDirectory(appPath);
            }
            string getShareXML = "";
            if (ChkChat2.Checked) //fetch share chat xml file asn save to folder (chat2)
            {
                string sharecode = shareCode.Trim().ToUpper();
                getShareXML = "http://www.iii.co.uk/rss/cotn:" + sharecode + ".L.xml";

                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFileAsync(new Uri(getShareXML),
                    appPath + "\\" + sharecode + "-2.xml");
                    System.Threading.Thread.Sleep(1000); //wait 1 second for file writing
                }
            }
            else
            {

                getShareXML = "http://www.lse.co.uk/chat/" + shareCode; // Fetching xml files form url and save in local directory
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFileAsync(new Uri(getShareXML),
                    appPath + "\\" + shareCode + ".xml");
                    System.Threading.Thread.Sleep(1000);//wait 1 second for file writing

                }
            }

            return true;
        }

        private bool FetchShareData(String shareCode) // fetch bulk share chat and save to folder
        {
            string appPath = System.Configuration.ConfigurationManager.AppSettings["FilePath"]; // Get path of xml files
            if (!Directory.Exists(appPath))
            {
                Directory.CreateDirectory(appPath);
            }
            string getShareXML = "";
            if (chkChat2Bulk.Checked) //fetch share chat xml file and save to folder (chat2)
            {
                string sharecode = shareCode.Trim().ToUpper();
                getShareXML = "http://www.iii.co.uk/rss/cotn:" + sharecode + ".L.xml";

                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFileAsync(new Uri(getShareXML),
                    appPath + "\\" + sharecode + "-2.xml");
                    System.Threading.Thread.Sleep(1000); //wait 1 second for file writing
                }
            }
            else
            {

                getShareXML = "http://www.lse.co.uk/chat/" + shareCode; // Fetching xml files form url and save in local directory
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFileAsync(new Uri(getShareXML),
                    appPath + "\\" + shareCode + ".xml");
                    System.Threading.Thread.Sleep(1000);//wait 1 second for file writing

                }
            }

            return true;
        }

        public string title { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public string lastBuildDate { get; set; }
        public string copyright { get; set; }
        public string docs { get; set; }
        public string ttl { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void btnFetch_Click(object sender, EventArgs e)
        {
            DBChat.sharecode = txtShareCode.Text;
            int id = DBChat.GetShareCodeID();
            DBChat.sharecodeid = id;
            if (id > 0)
            {
                if (txtShareCode.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(txtShareCode, "Please enter share code");
                    return;
                }
                errorProvider1.Clear();

                string txt = txtShareCode.Text;
                try
                {
                    FetchSingleShareData(txt.ToLower()); // Fetch xml file for porting in database single chat
                    MessageBox.Show("File fetched successfully .............", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // string path = txtShareCode.Text + ".xml";

                    // FillTextBox(path);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Share Code not exits in database ....... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnAnalyse_Click(object sender, EventArgs e)
        {
            string txt = txtShareCode.Text + ".xml";
            FillTextBox(txt);

        }

        private void LstShareCodes_Click(object sender, EventArgs e)
        {

        }

        private void FillTextBox(string txt) // Read xml file and show in textbox
        {
            StringBuilder str = new StringBuilder();
            try
            {

                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                string path = appPath.Substring(0, appPath.Length - 9) + "XMLFiles\\" + txt;
                if (File.Exists(path))
                {
                    XDocument xDoc = XDocument.Load(path);
                    Channel channel = new Channel();
                    foreach (XElement c in xDoc.Descendants("channel"))
                    {
                        channel.title = c.Element("title").Value;
                        channel.link = c.Element("link").Value;
                        channel.description = c.Element("description").Value;
                        channel.language = c.Element("language").Value;
                        channel.lastBuildDate = c.Element("lastBuildDate").Value;
                        channel.copyright = c.Element("copyright").Value;
                        channel.docs = c.Element("docs").Value;
                        channel.ttl = c.Element("ttl").Value;

                        str.Append(c.Element("title").Value.ToString() + Environment.NewLine);
                        str.Append(c.Element("link").Value.ToString() + Environment.NewLine);
                        str.Append(c.Element("description").Value.ToString() + Environment.NewLine);
                        str.Append(c.Element("language").Value.ToString() + Environment.NewLine);
                        str.Append(c.Element("lastBuildDate").Value.ToString() + Environment.NewLine);
                        str.Append(c.Element("copyright").Value.ToString() + Environment.NewLine);
                        str.Append(c.Element("docs").Value.ToString() + Environment.NewLine);
                        str.Append(c.Element("ttl").Value.ToString() + Environment.NewLine);
                        str.Append(Environment.NewLine);
                    }


                    DataTable dt = new DataTable();
                    DataRow item = dt.NewRow();
                    dt.Columns.Add("title");
                    dt.Columns.Add("autor");
                    dt.Columns.Add("description");
                    dt.Columns.Add("link");
                    dt.Columns.Add("pubDate");
                    foreach (XElement x in xDoc.Descendants("channel").Descendants("item"))
                    {
                        str.Append(x.Element("title").Value + Environment.NewLine);
                        str.Append(Environment.NewLine);
                        str.Append(x.Element("author").Value + Environment.NewLine);
                        str.Append(Environment.NewLine);
                        str.Append(x.Element("description").Value + Environment.NewLine);
                        str.Append(Environment.NewLine);
                        str.Append(x.Element("link").Value + Environment.NewLine);
                        str.Append(Environment.NewLine);
                        str.Append(x.Element("pubDate").Value + Environment.NewLine);
                        str.Append(Environment.NewLine);

                    }
                    txtChat.Text = str.ToString();

                }
                else
                {
                    MessageBox.Show("File not found,Please fetch file for processing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PBPort.Minimum = 0;
            Int16 idx = 0;
            bool Result = false;
            //db.BeginTransaction();
            if (ChkChat2.Checked) // Routine to save chat-2 records
            {
                try
                {
                    string txt = txtShareCode.Text.Trim() + "-2.xml";
                    string appPath = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
                    string path = appPath + "\\" + txt;
                    int ChannelID = 0;
                    if (FileInUse(path) == false)
                    {
                        if (File.Exists(path))
                        {

                            //Tue, 10 Jul 2012 07:25:13 GMT


                            XDocument xDoc = XDocument.Load(path);
                            Channel channel = new Channel();

                            foreach (XElement c in xDoc.Descendants("channel"))
                            {
                                DBChat_2.sharecode = lblShareCode.Text.Trim();
                                DBChat_2.title = c.Element("title").Value.Replace("'", "").Replace(";", ""); ;
                                DBChat_2.description = c.Element("description").Value.Replace("'", "").Replace(";", ""); ;
                                DBChat_2.sharecodeid = DBChat.GetShareCodeID();// ..lastBuildDate = c.Element("lastBuildDate").Value.Replace("'", "");
                                ChannelID = DBChat_2.InsertChannel();

                            }

                            int nodes = xDoc.Descendants("channel").Descendants("item").Count();
                            PBPort.Maximum = nodes;

                            XNamespace dc = "http://purl.org/dc/elements/1.1/";



                            foreach (XElement x in xDoc.Descendants("channel").Descendants("item"))
                            {
                                try
                                {
                                    idx++;
                                    string strDate = x.Element("pubDate").Value.Replace("'", "").Replace(";", ""); ;
                                    string s = strDate.Substring(5, 11);
                                    string[] b = s.Split(' ');
                                    string _date = b[2].ToString() + "/" + getmonth(b[1].ToString()) + "/" + b[0].ToString();

                                    DBChat_2.channelid = ChannelID;
                                    DBChat_2.title = x.Element("title").Value.Replace("'", "").Replace(";", ""); ;
                                    DBChat_2.creator = x.Element(dc + "creator").Value.Replace("'", "").Replace(";", ""); ;
                                    DBChat_2.description = x.Element("description").Value.Replace("'", "").Replace(";", ""); ;
                                    DBChat_2.pubdate = _date;// x.Element("pubDate").Value.Replace("'", "");
                                    DBChat_2.pubdateFull = strDate;
                                    DBChat_2.InsertChats();
                                    PBPort.Value = idx;
                                    Result = true;
                                }
                                catch (Exception ex)
                                {

                                    if (ex.Message.ToLower().Contains("duplicate") || ex.Message.Contains("Duplicata"))
                                    {
                                        PBPort.Value = idx;
                                        // MessageBox.Show("Chat  Already Exists in Database ............", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }

                            xDoc = null;
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            if (Result == false)
                            {
                                DBChat_2.channelid = ChannelID;
                                DBChat_2.DeleteChannel();// delete master if no new  chat inserted in database.
                            }
                            MessageBox.Show("Posts have been fetched and saved to database", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                        else
                        {
                            MessageBox.Show("File not found, Please fetch file for processing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("File is in use , Plese wait a few seconds", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                    if (!ex.Message.Contains("hexadecimal value 0x3B"))
                    {
                        if (ex.Message.ToLower().Contains("duplicate") || ex.Message.Contains("Duplicate"))
                        {
                            PBPort.Value = idx;
                            // MessageBox.Show("Chat  Already Exists in Database ............", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {
                    string txt = txtShareCode.Text + ".xml";
                    string appPath = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
                    string path = appPath + "\\" + txt;
                    int ChannelID = 0;
                    if (FileInUse(path) == false)
                    {
                        if (File.Exists(path))
                        {
                            //Tue, 10 Jul 2012 07:25:13 GMT


                            XDocument xDoc = XDocument.Load(path);
                            Channel channel = new Channel();

                            foreach (XElement c in xDoc.Descendants("channel"))
                            {
                                DBChat.title = c.Element("title").Value.Replace("'", "").Replace(";", ""); ;
                                DBChat.link = c.Element("link").Value.Replace("'", "");
                                DBChat.description = c.Element("description").Value.Replace("'", "").Replace(";", ""); ;
                                DBChat.language = c.Element("language").Value.Replace("'", "").Replace(";", ""); ;
                                DBChat.lastBuildDate = c.Element("lastBuildDate").Value.Replace("'", "").Replace(";", ""); ;
                                DBChat.copyright = c.Element("copyright").Value.Replace("'", "").Replace(";", ""); ;
                                DBChat.docs = c.Element("docs").Value.Replace("'", "").Replace(";", ""); ;
                                DBChat.ttl = c.Element("ttl").Value.Replace("'", "").Replace(";", ""); ;
                                ChannelID = DBChat.InsertChannel();
                                lblChannelID.Text = ChannelID.ToString();
                            }

                            int nodes = xDoc.Descendants("channel").Descendants("item").Count();
                            PBPort.Maximum = nodes;
                            idx = 0;
                            foreach (XElement x in xDoc.Descendants("channel").Descendants("item"))
                            {
                                try
                                {
                                    idx++;
                                    string strDate = x.Element("pubDate").Value.Replace("'", "").Replace(";", ""); ;
                                    string s = strDate.Substring(5, 11);
                                    string[] b = s.Split(' ');
                                    string _date = b[2].ToString() + "/" + getmonth(b[1].ToString()) + "/" + b[0].ToString();
                                    DBChat.channelid = ChannelID;
                                    DBChat.title = x.Element("title").Value.Replace("'", "").Replace(";", ""); ;
                                    DBChat.author = x.Element("author").Value.Replace("'", "").Replace(";", ""); ;
                                    DBChat.description = x.Element("description").Value.Replace("'", "").Replace(";", ""); ;
                                    DBChat.link = x.Element("link").Value.Replace("'", "").Replace(";", ""); ;
                                    DBChat.pubDate = _date;// x.Element("pubDate").Value.Replace("'", "");
                                    DBChat.pubDateFull = strDate;
                                    DBChat.InsertChat();
                                    DBChat.channelid = ChannelID;
                                    Result = true;
                                    PBPort.Value = idx;
                                }
                                catch (Exception ex)
                                {
                                    if (ex.Message.ToLower().Contains("duplicate") || ex.Message.Contains("Duplicata"))
                                    {
                                        PBPort.Value = idx;
                                        // MessageBox.Show("Chat already exists in database ............", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            xDoc = null;
                            GC.Collect(); // free resources
                            GC.WaitForPendingFinalizers();
                            if (Result == false)
                            {
                                DBChat.channelid = ChannelID;
                                DBChat.DeleteChannel();// delete master if no new  chat inserted in database.
                            }
                            MessageBox.Show("Posts have been fetched and saved to database", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("File not found, please fetch file for processing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("File is in use , plese wait a few seconds", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                    if (!ex.Message.Contains("hexadecimal value 0x3B"))
                    {
                        if (ex.Message.ToLower().Contains("duplicate") || ex.Message.Contains("Duplicate"))
                        {
                            MessageBox.Show("Chat already exists in Database ............", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            txtShareCode.Clear();
            txtChat.Clear();

        }
        private void CreateTemplateList() // create template list header
        {
            lstTemplate.Items.Clear();
            this.lstTemplate.BackColor = Color.AliceBlue;
            ColumnHeader header1;
            header1 = new ColumnHeader();


            header1.Text = "Description";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = -2;

            lstTemplate.Columns.Add(header1);

        }
        private void CreateTotalAuthors() //create total authors  list header 
        {
            lstTemplate.Items.Clear();
            this.lstTemplate.BackColor = Color.AliceBlue;
            ColumnHeader header1, header2;
            header1 = new ColumnHeader();
            header1.Text = "Author";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 150;

            header2 = new ColumnHeader();
            header2.Text = "Total";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = -2;

            lstTotalAuthors.Columns.Add(header1);
            lstTotalAuthors.Columns.Add(header2);

        }
        private void CreateTotalShareCode() // create total share list header
        {
            lstTemplate.Items.Clear();
            this.lstTemplate.BackColor = Color.AliceBlue;
            ColumnHeader header1, header2;
            header1 = new ColumnHeader();
            header1.Text = "Share Code";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 150;

            header2 = new ColumnHeader();
            header2.Text = "Total";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = -2;

            lstTotalShareCodes.Columns.Add(header1);
            lstTotalShareCodes.Columns.Add(header2);

        }
        private string getmonth(string txt) // convert month to number of month
        {
            string month = "";
            switch (txt)
            {
                case "Jan":
                    month = "01";
                    break;
                case "Feb":
                    month = "02";
                    break;
                case "Mar":
                    month = "03";
                    break;
                case "Apr":
                    month = "04";
                    break;
                case "May":
                    month = "05";
                    break;
                case "Jun":
                    month = "06";
                    break;
                case "Jul":
                    month = "07";
                    break;
                case "Aug":
                    month = "08";
                    break;
                case "Sep":
                    month = "09";
                    break;
                case "Oct":
                    month = "10";
                    break;
                case "Nov":
                    month = "11";
                    break;
                case "Dec":
                    month = "12";
                    break;
            }
            return month;
        }
        private void myPingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            if (e.Reply == null)
            {
                MessageBox.Show("Internet connection not available", "Quiting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();

            }
            if (e.Cancelled)
                return;

            if (e.Error != null)
                return;

            if (e.Reply.Status == IPStatus.Success)
            {
                //ok connected to internet, do something
            }
            else
            {
                MessageBox.Show("Internet connection not available", "Quiting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                Application.Exit();
            }
        }

        private void checkInternet()
        {
            Ping myPing = new Ping();
            myPing.PingCompleted += new PingCompletedEventHandler(myPingCompletedCallback);
            byte[] buffer = new byte[32];
            int timeout = 1000;
            PingOptions options = new PingOptions(64, true);
            try
            {
                myPing.SendAsync("google.com", timeout, buffer, options);
            }
            catch
            {
            }
        }
        private void Home_Load(object sender, EventArgs e)
        {
            checkInternet();           

            CreateTemplateList();
            CreateChartList();
            CreateAnalyzeTemplateList();
            CreateAnalyzeShareChats();
            CreateAnalyzeAuthor();
            CreateShareCodeListTab();
            FillShareCodesListTab1();
            CreateTotalAuthors();
            CreateTotalShareCode();

        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex) // tab change routine
            {
                case 0:
                    break;
                case 1:
                    RTBAnalyze.Clear(); // Fill text box with chat
                    FillTemplateAnalse(); //Fill templates
                    FillAuthorsAnalyse();// fill authors
                    GetAllSharedChatDates(); // Get all Chat Dates
                    break;
                case 2:
                    FillTemplateList();
                    btnClearTemplate_Click(null, null);
                    break;
                case 3:
                    if (lblShareCode.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Please select share code for further processing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControl1.SelectedIndex = 0;
                        return;
                    }
                    else
                    {
                        FillChatBox();
                    }
                    break;
                case 4:
                    if (lblAuthorShare.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Please select author from analysis tab for further processing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControl1.SelectedIndex = 1;
                        return;
                    }
                    else
                    {
                        GetChart(); // Get chart
                        GetChartList(); // Get list of chats
                        break;
                    }
                case 5:

                    FillTotalShares(); //Get total shared in database
                    FillTotalAuthors(Isorted); // Get total numbers of authors in database


                    break;
                case 6:
                    setHeaderBulkPort(); // set header of bulk download 

                    FillShareCodeBulkPort();
                    break;
            }

        }

        private void setHeaderBulkPort() // set header for bulklist
        {

            //    lstBulkPort.Items.Clear();
            //    this.LstShareCodes.BackColor = Color.AliceBlue;
            //    ColumnHeader header1;
            //    header1 = new ColumnHeader();

            //    header1.Text = "Share Code";
            //    header1.TextAlign = HorizontalAlignment.Left;
            //    header1.Width = -2;


            //    lstBulkPort.s.he.Columns.Add(header1);
        }
        private void FillShareCodeBulkPort() // fill share list for bulk port
        {
            lstBulkPort.Items.Clear();
            try
            {


                DataTable dt = DBShareCode.GetShareCodeList(); // Get share code list
                foreach (DataRow dr in dt.Rows)
                {
                    var items = lstBulkPort.Items;
                    items.Add(dr[1].ToString());
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Can't connect to MySQL server"))
                {
                    MessageBox.Show("MySQL Server services not running, please start WAMP server", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void GetChart() // create chart routine
        {

            DataTable dt = new DataTable();
            chart1.BackColor = Color.LightBlue;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            if (chkChat2Analise.Checked)
            {
                dt = DBChat_2.GetChart();// chat 2 table
                chart1.DataSource = dt;
            }
            else
            {
                dt = DBChat.GetChart(); // chat 1 table
                chart1.DataSource = dt;
            }
            chart1.Series[0].XValueMember = "pubDate";
            chart1.Series[0].YValueMembers = "counter";
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart1.ChartAreas[0].Area3DStyle.Inclination = 40;


        }
        private void FillTemplateList() // fill template list
        {
            lstTemplate.Items.Clear();
            try
            {


                DataTable dt = DBChat.GetTemplates();
                foreach (DataRow dr in dt.Rows)
                {

                    string Ridx = dr[0].ToString();// lvEmployee.Items.Count + 1;
                    ListViewItem lvi = new ListViewItem(Ridx);
                    lstTemplate.Items.Add(lvi);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lstTemplate_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void lstTemplate_DoubleClick(object sender, EventArgs e) // set template items
        {
            try
            {
                txtTemplateName.ReadOnly = true;
                string txt = lstTemplate.SelectedItems[0].Text;
                DataTable dt = DBChat.GetTemplatesItems(txt);
                if (dt.Rows.Count > 0)
                {
                    btnSaveTemplate.Text = "Update";
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        switch (i)
                        {
                            case 0:
                                txtTemplateName.Text = dr[2].ToString();
                                Item1.Text = dr[1].ToString();
                                break;
                            case 1:
                                Item2.Text = dr[1].ToString();
                                break;
                            case 2:
                                Item3.Text = dr[1].ToString();
                                break;
                            case 3:
                                Item4.Text = dr[1].ToString();
                                break;
                            case 4:
                                Item5.Text = dr[1].ToString();
                                break;
                            case 5:
                                Item6.Text = dr[1].ToString();
                                break;
                            case 6:
                                Item7.Text = dr[1].ToString();
                                break;
                            case 7:
                                Item8.Text = dr[1].ToString();
                                break;
                        }
                        i++;


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnClearTemplate_Click(object sender, EventArgs e)
        {

            txtTemplateName.ReadOnly = false;
            txtTemplateName.Text = string.Empty;
            Item1.Text = string.Empty;
            Item2.Text = string.Empty;
            Item3.Text = string.Empty;
            Item4.Text = string.Empty;
            Item5.Text = string.Empty;
            Item6.Text = string.Empty;
            Item7.Text = string.Empty;
            Item8.Text = string.Empty;
        }

        private void btnSaveTemplate_Click(object sender, EventArgs e) // update template 
        {
            errorProvider1.Clear();
            if (txtTemplateName.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtTemplateName, "Input Required");
                return;
            }
            if (Item1.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(Item1, "Input Required");
                return;
            }
            if (Item2.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(Item2, "Input Required");
                return;
            }
            if (Item3.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(Item3, "Input Required");
                return;
            }
            if (Item4.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(Item4, "Input Required");
                return;
            }
            if (Item5.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(Item5, "Input Required");
                return;
            }
            if (Item6.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(Item6, "Input Required");
                return;
            }
            if (Item7.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(Item7, "Input Required");
                return;
            }
            if (Item8.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(Item8, "Input Required");
                return;
            }
            DBChat.item1 = Item1.Text;
            DBChat.item2 = Item2.Text;
            DBChat.item3 = Item3.Text;
            DBChat.item4 = Item4.Text;
            DBChat.item5 = Item5.Text;
            DBChat.item6 = Item6.Text;
            DBChat.item7 = Item7.Text;
            DBChat.item8 = Item8.Text;
            DBChat.TemplateName = txtTemplateName.Text;
            bool Result = DBChat.InsertTemplate();
            if (Result == true)
            {
                MessageBox.Show("Template sucessfully created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillTemplateList();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtTemplateName.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtTemplateName, "Input required");
                return;
            }
            else
            {
                if (DBChat.CheckTemplate(txtTemplateName.Text) == false)
                {
                    MessageBox.Show("Template not found...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var confirmResult = MessageBox.Show("Are you sure want to delete this Template?",
                                     "Confirm Delete!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                DBChat.TemplateName = txtTemplateName.Text;
                if (DBChat.DeleteTemplate() == true)
                {
                    MessageBox.Show("Template has been sucessfully deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillTemplateList();
                }
                else
                {
                    MessageBox.Show("Template not deleted...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // If 'No', do something here.
            }


        }

        private void txtTemplateName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTemplateName, "");


        }

        private void Item1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(Item1, "");

        }

        private void Item2_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(Item2, "");




        }

        private void Item3_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(Item3, "");

        }

        private void Item4_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(Item4, "");

        }

        private void Item5_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(Item5, "");

        }

        private void Item6_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(Item6, "");

        }

        private void Item7_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(Item7, "");

        }

        private void Item8_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(Item8, "");
        }


        #region SahreCode
        private void FillShareCodesListTab1()
        {
            LstShareCodes.Items.Clear();
            try
            {


                DataTable dt = DBShareCode.GetShareCodeList();
                foreach (DataRow dr in dt.Rows)
                {

                    string Ridx = dr[1].ToString();// lvEmployee.Items.Count + 1;
                    ListViewItem lvi = new ListViewItem(Ridx);
                    LstShareCodes.Items.Add(lvi);

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Can't connect to MySQL server"))
                {
                    MessageBox.Show("MySQL Server services  not running ................", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.Exit();
                }
                else if (ex.Message.Contains("IM002"))
                {
                    MessageBox.Show("Invalid ODBC Driver .........", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }

        private void FillShareCodesList()
        {

            try
            {


                DataTable dt = DBShareCode.GetShareCodeList();
                foreach (DataRow dr in dt.Rows)
                {

                    string Ridx = dr[0].ToString();// lvEmployee.Items.Count + 1;
                    ListViewItem lvi = new ListViewItem(Ridx);
                    lvi.SubItems.Add(dr[1].ToString()); ;
                    lvi.SubItems.Add(dr[2].ToString()); ;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        private void CreateShareCodeListTab() //create share code list header
        {
            LstShareCodes.Items.Clear();
            this.LstShareCodes.BackColor = Color.AliceBlue;
            ColumnHeader header1;
            header1 = new ColumnHeader();

            header1.Text = "Share Code";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = -2;


            LstShareCodes.Columns.Add(header1);
        }


        #region Chats

        private void FillChatBox() // Fill chat box with respect to share code
        {
            RTBox.Text = string.Empty;
            DBChat.sharecode = lblShareCode.Text;
            DBChat.TemplateName = lblSearchTemplate.Text;
            DBChat_2.sharecode = lblShareCode.Text;
            DBChat_2.TemplateName = lblSearchTemplate.Text;
            DataTable dt = new DataTable();
            DataTable dtDetail = new DataTable();
            if (chkChatTab2.Checked)
            {
                dt = DBChat_2.GetChatDB();


                StringBuilder str = new StringBuilder();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lblChannelID.Text = dr[0].ToString();
                        DBChat_2.channelid = Convert.ToInt32(lblChannelID.Text);
                        str.Append(dr[1].ToString() + Environment.NewLine);
                        str.Append(dr[2].ToString() + Environment.NewLine);
                        str.Append(dr[5].ToString() + Environment.NewLine);

                        str.Append(Environment.NewLine);
                        break;
                    }
                    DBChat_2.channelid = Convert.ToInt32(lblChannelID.Text);
                    dtDetail = DBChat_2.GetChatDetail();
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
                        }

                    }

                    string sqlstr = DBChat_2.GetChatDetailBySearchChatBoxXML(); // get XML Files chat box
                    RTBox.AppendText(str.ToString());
                    WB.DocumentText = sqlstr;
                }
            }
            else
            {
                dt = DBChat.GetChatDB();


                StringBuilder str = new StringBuilder();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        // str.Append(dr[0].ToString() + Environment.NewLine);
                        lblChannelID.Text = dr[0].ToString();
                        str.Append(dr[1].ToString() + Environment.NewLine);
                        str.Append(dr[2].ToString() + Environment.NewLine);
                        str.Append(dr[3].ToString() + Environment.NewLine);
                        str.Append(dr[4].ToString() + Environment.NewLine);
                        str.Append(dr[5].ToString() + Environment.NewLine);
                        //str.Append(dr[6].ToString() + Environment.NewLine);
                        // str.Append(dr[7].ToString() + Environment.NewLine);
                        str.Append(Environment.NewLine);
                        break;
                    }
                    DBChat.channelid = Convert.ToInt32(lblChannelID.Text);
                    dt = DBChat.GetChatDetail();
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            //str.Append(dr[1].ToString() + Environment.NewLine);
                            //str.Append(Environment.NewLine);
                            str.Append(dr[2].ToString() + Environment.NewLine);
                            //str.Append(Environment.NewLine);
                            str.Append(dr[3].ToString() + Environment.NewLine);
                            str.Append(Environment.NewLine);
                            str.Append(dr[4].ToString() + Environment.NewLine);
                            str.Append(Environment.NewLine);
                            //str.Append(dr[5].ToString() + Environment.NewLine);
                            //str.Append(Environment.NewLine);
                        }
                    }
                    string sqlstr = DBChat.GetChatDetailBySearchChatBoxXML();
                    RTBox.AppendText(str.ToString());
                    WB.DocumentText = sqlstr;
                }
            }
        }
        #endregion

        private void btnFindtext_Click(object sender, EventArgs e) // find text from displayed chat
        {
            if (txtFindText.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtFindText, "Input required");
                return;
            }


            string txt_Search = txtFindText.Text;
            int index = 0;
            String temp = RTBox.Text;
            RTBox.Text = "";
            RTBox.Text = temp;
            while (index < RTBox.Text.LastIndexOf(txt_Search))
            {
                RTBox.Find(txt_Search, index, RTBox.TextLength, RichTextBoxFinds.None);
                RTBox.SelectionBackColor = Color.Aqua;
                index = RTBox.Text.IndexOf(txt_Search, index) + 1;
                RTBox.Select();
            }

        }

        #region Analyze
        private void CreateAnalyzeTemplateList()
        {
            lstAnalyzeTemplate.Items.Clear();
            this.lstAnalyzeTemplate.BackColor = Color.AliceBlue;
            ColumnHeader header1;
            header1 = new ColumnHeader();


            header1.Text = "Template";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = -2;

            lstAnalyzeTemplate.Columns.Add(header1);
        }
        private void CreateChartList()
        {
            lstchart.Items.Clear();
            this.lstchart.BackColor = Color.AliceBlue;
            ColumnHeader header1;
            header1 = new ColumnHeader();
            //header2 = new ColumnHeader();

            header1.Text = "Date";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = -2;

            //header2.Text = "No Posts";
            //header2.TextAlign = HorizontalAlignment.Left;
            //header2.Width = -2;

            lstchart.Columns.Add(header1);
            //lstchart.Columns.Add(header2);
        }


        private void CreateAnalyzeShareChats()
        {
            LstSharedChatDates.Items.Clear();
            this.LstSharedChatDates.BackColor = Color.AliceBlue;
            ColumnHeader header1;
            header1 = new ColumnHeader();
            header1.Text = "Date";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = -2;

            LstSharedChatDates.Columns.Add(header1);


        }


        private void CreateAnalyzeAuthor()
        {
            lstAnalzeAuthors.Items.Clear();
            this.lstAnalzeAuthors.BackColor = Color.AliceBlue;
            ColumnHeader header1;
            header1 = new ColumnHeader();


            header1.Text = "Author";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = -2;

            lstAnalzeAuthors.Columns.Add(header1);
        }
        private void FillTemplateAnalse()
        {
            lstAnalyzeTemplate.Items.Clear();
            try
            {
                DataTable dt = DBChat.GetTemplates();
                foreach (DataRow dr in dt.Rows)
                {

                    string Ridx = dr[0].ToString();// lvEmployee.Items.Count + 1;
                    ListViewItem lvi = new ListViewItem(Ridx);
                    lstAnalyzeTemplate.Items.Add(lvi);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillAuthorsAnalyse()
        {
            lstAnalzeAuthors.Items.Clear();
            try
            {
                DataTable dt = new DataTable();
                if (chkChat2Analise.Checked)
                {
                    dt = DBChat_2.GetAuthors();//Chat1 db
                }
                else
                {
                    dt = DBChat.GetAuthors(); //Chat2 db
                }
                foreach (DataRow dr in dt.Rows)
                {

                    string Ridx = dr[0].ToString();// lvEmployee.Items.Count + 1;
                    ListViewItem lvi = new ListViewItem(Ridx);
                    //lvi.SubItems.Add(dr[0].ToString());
                    lstAnalzeAuthors.Items.Add(lvi);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        private void GetSavedChat()
        {

            DataTable dt = DBChat.GetChatDB();
            if (dt.Rows.Count > 0)
            {
                DBChat.channelid = Convert.ToInt32(dt.Rows[0][0]);// Convert.ToInt32(lblChannelID.Text);
                lblChannelID.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                DBChat.channelid = 0;
            }
            DataTable dtDetail = DBChat.GetChatDetail();
            if ((dt.Rows.Count > 0) && (dtDetail.Rows.Count > 0))
            {
                StringBuilder str = new StringBuilder();

                foreach (DataRow dr in dt.Rows)
                {

                    str.Append(dr[1].ToString() + Environment.NewLine);
                    str.Append(dr[2].ToString() + Environment.NewLine);
                    str.Append(dr[3].ToString() + Environment.NewLine);
                    str.Append(dr[4].ToString() + Environment.NewLine);
                    str.Append(dr[5].ToString() + Environment.NewLine);
                    str.Append(dr[6].ToString() + Environment.NewLine);
                    str.Append(dr[7].ToString() + Environment.NewLine);
                    str.Append(Environment.NewLine);
                    break;
                }
                foreach (DataRow dr in dtDetail.Rows)
                {
                    str.Append(dr[2].ToString() + Environment.NewLine);
                    str.Append(dr[3].ToString() + Environment.NewLine);
                    str.Append(Environment.NewLine);
                    str.Append(dr[4].ToString() + Environment.NewLine);
                    str.Append(Environment.NewLine);
                    str.Append(dr[5].ToString() + Environment.NewLine);
                    str.Append(Environment.NewLine);
                }
                txtChat.Text = str.ToString();
            }
            else
            {
                txtChat.Clear();
            }
        }
        private void LstShareCodes_MouseClick(object sender, MouseEventArgs e)
        {
            StringBuilder str = new StringBuilder();
            txtChat.Clear();
            txtShareCode.Text = LstShareCodes.SelectedItems[0].SubItems[0].Text;

            DBChat.sharecode = txtShareCode.Text;
            int ShareCodeID = DBChat.GetShareCodeID();
            lblShareCode.Text = txtShareCode.Text;
            DBChat_2.sharecode = lblShareCode.Text;

            DataTable dt = new DataTable();
            if (ChkChat2.Checked)
            {
                dt = DBChat_2.GetChatDB(); // Get Chat 2 one master table details
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lblChannelID.Text = dr[0].ToString();
                        DBChat_2.channelid = Convert.ToInt32(lblChannelID.Text);
                        str.Append(dr[1].ToString() + Environment.NewLine);
                        str.Append(dr[2].ToString() + Environment.NewLine);
                        str.Append(dr[5].ToString() + Environment.NewLine);
                        // str.Append(dr[4].ToString() + Environment.NewLine);
                        // str.Append(dr[5].ToString() + Environment.NewLine);
                        //str.Append(dr[6].ToString() + Environment.NewLine);
                        // str.Append(dr[7].ToString() + Environment.NewLine);
                        str.Append(Environment.NewLine);
                        break;
                    }
                }
                else
                {
                    DBChat_2.channelid = 0;// Convert.ToInt32(lblChannelID.Text);
                }
                DataTable dtDetail = DBChat_2.GetChatDetail(); //get Child table Chat 2 details
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
                    }

                }
            }
            else
            {
                dt = DBChat.GetChatDB(); // Get chat 1 master table details


                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lblChannelID.Text = dr[0].ToString();
                        DBChat.channelid = Convert.ToInt32(lblChannelID.Text);
                        str.Append(dr[1].ToString() + Environment.NewLine);
                        str.Append(dr[2].ToString() + Environment.NewLine);
                        str.Append(dr[3].ToString() + Environment.NewLine);
                        str.Append(dr[4].ToString() + Environment.NewLine);
                        str.Append(dr[5].ToString() + Environment.NewLine);
                        str.Append(dr[6].ToString() + Environment.NewLine);
                        str.Append(dr[7].ToString() + Environment.NewLine);
                        str.Append(Environment.NewLine);
                        break;
                    }
                }
                else
                {
                    DBChat.channelid = 0;// Convert.ToInt32(lblChannelID.Text);
                }
                DataTable dtDetail = DBChat.GetChatDetail();//Get chat1 detail table
                if (dtDetail.Rows.Count > 0)
                {

                    foreach (DataRow dr in dtDetail.Rows)
                    {

                        str.Append(dr[2].ToString() + Environment.NewLine);
                        str.Append(dr[3].ToString() + Environment.NewLine);
                        str.Append(Environment.NewLine);
                        str.Append(dr[4].ToString() + Environment.NewLine);
                        str.Append(Environment.NewLine);
                        str.Append(dr[5].ToString() + Environment.NewLine);
                        str.Append(Environment.NewLine);
                    }

                }
            }
            txtChat.Text = str.ToString();
        }
        private string WordCount(string[] source, string term)
        {
            string searchTerm = term;

            var matchQuery = from word in source
                             where word.ToLowerInvariant().Contains(searchTerm.ToLowerInvariant())
                             select word;
            int wordCount = matchQuery.Count();

            return wordCount.ToString();
        }

        private void MarkAndCountAllChats()
        {
            string s = RTBAnalyze.Text;
            RTBAnalyze.Clear();
            RTBAnalyze.AppendText(s);
            try
            {
                lblSearchTemplate.Text = lstAnalyzeTemplate.SelectedItems[0].SubItems[0].Text;
            }
            catch (Exception)
            {

            }

            DataTable dt = DBChat.GetSearchedItemsByTemplateAllChats(lblSearchTemplate.Text);
            foreach (DataRow dr in dt.Rows)
            {
                btnSerach1.Text = dr[0].ToString();
                lblSearch1.Text = GetNumber(dr[1].ToString());
                btnSerach2.Text = dr[2].ToString();
                lblSearch2.Text = GetNumber(dr[3].ToString());
                btnSerach3.Text = dr[4].ToString();
                lblSearch3.Text = GetNumber(dr[5].ToString());
                btnSerach4.Text = dr[6].ToString();
                lblSearch4.Text = GetNumber(dr[7].ToString());
                btnSerach5.Text = dr[8].ToString();
                lblSearch5.Text = GetNumber(dr[9].ToString());
                btnSerach6.Text = dr[10].ToString();
                lblSearch6.Text = GetNumber(dr[11].ToString());
                btnSerach7.Text = dr[12].ToString();
                lblSearch7.Text = GetNumber(dr[13].ToString());
                btnSerach8.Text = dr[14].ToString();
                lblSearch8.Text = GetNumber(dr[15].ToString());

            }
            int idx = 0;
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    if ((idx == 0) || (idx == 2) || (idx == 4) || (idx == 6) || (idx == 8) || (idx == 10) || (idx == 12) || (idx == 14))
                    {
                        string txt_Search = dr[idx].ToString();
                        int index = 0;
                        String temp = RTBox.Text;
                        RTBox.Text = "";
                        RTBox.Text = temp;
                        while (index < RTBAnalyze.Text.LastIndexOf(txt_Search))
                        {
                            RTBAnalyze.Find(txt_Search, index, RTBAnalyze.TextLength, RichTextBoxFinds.None);
                            RTBAnalyze.SelectionBackColor = Color.Aqua;
                            index = RTBAnalyze.Text.IndexOf(txt_Search, index) + 1;
                            RTBAnalyze.Select();
                        }
                    }
                    idx++;
                }

            }
        }

        private void lstAnalyzeTemplate_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string s = RTBAnalyze.Text;
            RTBAnalyze.Clear();
            RTBAnalyze.AppendText(s);
            try
            {
                lblSearchTemplate.Text = lstAnalyzeTemplate.SelectedItems[0].SubItems[0].Text;
            }
            catch (Exception)
            {

            }
            if (!lblShareCode.Text.Contains("All Shares"))
            {
                DataTable dt = DBChat.GetSearchedItemsByTemplate(lblSearchTemplate.Text);
                foreach (DataRow dr in dt.Rows)
                {
                    btnSerach1.Text = dr[0].ToString();
                    lblSearch1.Text = GetNumber(dr[1].ToString());
                    btnSerach2.Text = dr[2].ToString();
                    lblSearch2.Text = GetNumber(dr[3].ToString());
                    btnSerach3.Text = dr[4].ToString();
                    lblSearch3.Text = GetNumber(dr[5].ToString());
                    btnSerach4.Text = dr[6].ToString();
                    lblSearch4.Text = GetNumber(dr[7].ToString());
                    btnSerach5.Text = dr[8].ToString();
                    lblSearch5.Text = GetNumber(dr[9].ToString());
                    btnSerach6.Text = dr[10].ToString();
                    lblSearch6.Text = GetNumber(dr[11].ToString());
                    btnSerach7.Text = dr[12].ToString();
                    lblSearch7.Text = GetNumber(dr[13].ToString());
                    btnSerach8.Text = dr[14].ToString();
                    lblSearch8.Text = GetNumber(dr[15].ToString());

                }
                int idx = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        if ((idx == 0) || (idx == 2) || (idx == 4) || (idx == 6) || (idx == 8) || (idx == 10) || (idx == 12) || (idx == 14))
                        {
                            string txt_Search = dr[idx].ToString();
                            int index = 0;
                            String temp = RTBox.Text;
                            RTBox.Text = "";
                            RTBox.Text = temp;
                            while (index < RTBAnalyze.Text.LastIndexOf(txt_Search))
                            {
                                RTBAnalyze.Find(txt_Search, index, RTBAnalyze.TextLength, RichTextBoxFinds.None);
                                RTBAnalyze.SelectionBackColor = Color.Aqua;
                                index = RTBAnalyze.Text.IndexOf(txt_Search, index) + 1;
                                RTBAnalyze.Select();
                            }
                        }
                        idx++;
                    }

                }
            }
            else
            {
                btnAllShare_Click(null, null);
            }
        }

        private string GetNumber(string str)
        {
            string[] strq = str.Split('.');
            return strq[0];
        }

        private void btnAllShare_Click(object sender, EventArgs e) // Get all chats with filters
        {
            PB.Minimum = 0;
            lblShareCode.Text = "All Shares";
            if (lblSearchTemplate.Text == "Current Template")
            {
                MessageBox.Show("Please select Template for further processing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GetAllCharedChat(); // Get all chats in table on the basis of chat & chat2 tables.

        }
        private void GetAllSharedChatDates() //Fill shared build dates
        {
            try
            {
                DataTable dt = new DataTable();
                if (chkChat2Analise.Checked)   // data from chat2 db
                {
                    DBChat_2.sharecode = txtShareCode.Text;
                    int ShareCodeID = DBChat_2.GetShareCodeID();
                    DBChat_2.sharecodeid = ShareCodeID;// Convert.ToInt32(lblShareCodeID.Text);
                    dt = DBChat_2.GetShareChatDates();
                }
                else // data from chat1 db
                {
                    DBChat.sharecode = txtShareCode.Text;
                    int ShareCodeID = DBChat.GetShareCodeID();
                    DBChat.sharecodeid = ShareCodeID;// Convert.ToInt32(lblShareCodeID.Text);
                    dt = DBChat.GetShareChatDates();

                }

                LstSharedChatDates.Items.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    string Ridx = dr[0].ToString();// lvEmployee.Items.Count + 1;
                    ListViewItem lvi = new ListViewItem(Ridx);
                    LstSharedChatDates.Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("Input string was not in correct format"))
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void GetAllCharedChat()
        {
            int channelid = 0;

            DataTable dt = new DataTable();


            DataTable dtinner = new DataTable();
            DataTable dtDetail = new DataTable();
            StringBuilder str = new StringBuilder();
            Int16 idx = 0;
            if (chkChat2Analise.Checked)
            {
                dt = DBChat_2.GetAllChannel();
                PB.Minimum = 0;
                PB.Maximum = dt.Rows.Count;
                foreach (DataRow dr in dt.Rows)
                {
                    idx++;
                    PB.Value = idx;
                    DBChat_2.channelid = Convert.ToInt32(dr[0]);
                    DBChat_2.TemplateName = lblSearchTemplate.Text;
                    dtinner = DBChat_2.GetChatDBByChannelID();
                    foreach (DataRow drinner in dtinner.Rows)
                    {
                        str.Append(drinner[1].ToString() + Environment.NewLine);
                        str.Append(drinner[2].ToString() + Environment.NewLine);
                        str.Append(drinner[5].ToString() + Environment.NewLine);
                        str.Append(Environment.NewLine);
                        dtDetail = DBChat_2.GetChatDetailBySearchByChannelID(); //Getting data on searching criteria chat 2 database
                        foreach (DataRow drdetail in dtDetail.Rows)
                        {
                            str.Append(drdetail[1].ToString() + Environment.NewLine);
                            str.Append(drdetail[2].ToString() + Environment.NewLine);
                            str.Append(drdetail[3].ToString() + Environment.NewLine);
                            str.Append(Environment.NewLine);
                            str.Append(drdetail[5].ToString() + Environment.NewLine);
                            str.Append(Environment.NewLine);
                        }

                        break;
                    }
                }
            }
            else
            {
                dt = DBChat.GetAllChannel();
                PB.Minimum = 0;
                PB.Maximum = dt.Rows.Count;
                foreach (DataRow dr in dt.Rows)
                {
                    idx++;
                    PB.Value = idx;

                    DBChat.channelid = Convert.ToInt32(dr[0]);
                    DBChat.TemplateName = lblSearchTemplate.Text;
                    dtinner = DBChat.GetChatDBByChannelID();
                    foreach (DataRow drinner in dtinner.Rows)
                    {
                        str.Append(drinner[1].ToString() + Environment.NewLine);
                        str.Append(drinner[2].ToString() + Environment.NewLine);
                        str.Append(drinner[3].ToString() + Environment.NewLine);
                        str.Append(drinner[4].ToString() + Environment.NewLine);
                        str.Append(drinner[5].ToString() + Environment.NewLine);
                        str.Append(drinner[6].ToString() + Environment.NewLine);
                        str.Append(drinner[7].ToString() + Environment.NewLine);
                        str.Append(Environment.NewLine);
                        dtDetail = DBChat.GetChatDetailBySearchByChannelID();//Getting data on searching criteria Chat-1 database
                        foreach (DataRow drdetail in dtDetail.Rows)
                        {
                            str.Append(drdetail[2].ToString() + Environment.NewLine);
                            str.Append(drdetail[3].ToString() + Environment.NewLine);
                            str.Append(Environment.NewLine);
                            str.Append(drdetail[4].ToString() + Environment.NewLine);
                            str.Append(Environment.NewLine);
                            str.Append(drdetail[5].ToString() + Environment.NewLine);
                            str.Append(Environment.NewLine);
                        }

                        break;
                    }
                }



            }
            RTBAnalyze.Text = str.ToString();
            MarkAndCountAllChats();
            // SetWordCounter();
        }

        private void SetWordCounter() //split chat text for searching
        {
            string[] source = RTBAnalyze.Text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '/', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            DataTable dt = DBChat.GetTemplatesItems(lblSearchTemplate.Text);//.GetSearchedItemsByTemplate(lblSearchTemplate.Text);
            Int32 idx = 0;
            foreach (DataRow dr in dt.Rows)
            {
                idx++;
                switch (idx)
                {
                    case 1:
                        btnSerach1.Text = dr[1].ToString();
                        lblSearch1.Text = WordCount(source, dr[1].ToString());
                        break;
                    case 2:
                        btnSerach2.Text = dr[1].ToString();
                        lblSearch2.Text = WordCount(source, dr[1].ToString());
                        break;
                    case 3:
                        btnSerach3.Text = dr[1].ToString();
                        lblSearch3.Text = WordCount(source, dr[1].ToString());
                        break;
                    case 4:
                        btnSerach4.Text = dr[1].ToString();
                        lblSearch4.Text = WordCount(source, dr[1].ToString());
                        break;
                    case 5:
                        btnSerach5.Text = dr[1].ToString();
                        lblSearch5.Text = WordCount(source, dr[1].ToString());
                        break;
                    case 6:
                        btnSerach6.Text = dr[1].ToString();
                        lblSearch6.Text = WordCount(source, dr[1].ToString());
                        break;
                    case 7:
                        btnSerach7.Text = dr[1].ToString();
                        lblSearch7.Text = WordCount(source, dr[1].ToString());
                        break;
                    case 8:
                        btnSerach8.Text = dr[1].ToString();
                        lblSearch8.Text = WordCount(source, dr[1].ToString());
                        break;
                }
                string txt_Search = dr[1].ToString();
                int index = 0;
                String temp = RTBox.Text;
                RTBox.Text = "";
                RTBox.Text = temp;
                while (index < RTBAnalyze.Text.LastIndexOf(txt_Search))
                {
                    RTBAnalyze.Find(txt_Search, index, RTBAnalyze.TextLength, RichTextBoxFinds.None);
                    RTBAnalyze.SelectionBackColor = Color.Aqua;
                    index = RTBAnalyze.Text.IndexOf(txt_Search, index) + 1;
                    RTBAnalyze.Select();
                }
            }

        }

        private void LstSharedChatDates_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!lblShareCode.Text.Contains("All Share"))
            {
                string str = "";
                RTBAnalyze.Clear();
                string ShareDate = "";
                //int ChannelID = DBChat.GetChannelIDbyShareCode();
                ShareDate = LstSharedChatDates.SelectedItems[0].SubItems[0].Text;
                if ((lblSearchTemplate.Text == "Current Template") || (lblShareCode.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Please select template and share code for further processing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (chkChat2Analise.Checked)  // Get chat with template fileds
                {
                    DBChat_2.TemplateName = lblSearchTemplate.Text;
                    DBChat_2.sharecode = lblShareCode.Text;
                    ShareDate = LstSharedChatDates.SelectedItems[0].SubItems[0].Text;
                    DBChat_2.lastBuildDate = ShareDate;
                    DBChat_2.channelid = DBChat_2.GetChannelIDByBuildDate();
                    str = DBChat_2.GetChatDBByBuildDate(); // get data on date criteria
                }
                else
                {
                    DBChat.TemplateName = lblSearchTemplate.Text; // Get chat with template fileds
                    DBChat.sharecode = lblShareCode.Text;
                    ShareDate = LstSharedChatDates.SelectedItems[0].SubItems[0].Text;
                    DBChat.lastBuildDate = ShareDate;
                    DBChat.channelid = DBChat.GetChannelIDByBuildDate(); // get chat with date criteria
                    DBChat.lastBuildDate = ShareDate;
                    str = DBChat.GetChatDBByBuildDate();
                }


                RTBAnalyze.AppendText(str);


                lstAnalyzeTemplate_MouseDoubleClick(null, null);
            }
        }


        private void GetChartList()
        {
            try
            {
                DataTable dt = new DataTable();

                if (chkChat2Analise.Checked)
                {
                    dt = DBChat_2.GetChartList();
                }
                else
                {
                    dt = DBChat.GetChartList();
                }
                lstchart.Items.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    string Ridx = dr[3].ToString();// lvEmployee.Items.Count + 1;
                    ListViewItem lvi = new ListViewItem(Ridx);
                    // lvi.SubItems.Add(dr[0].ToString());
                    lstchart.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("Input string was not in correct format"))
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lstAnalzeAuthors_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Show the chart for author / Creator

            if ((lblSearchTemplate.Text == "Current Template") || (lblShareCode.Text.Trim().Length == 0))
            {
                MessageBox.Show("Please select template share code for further processing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string author = lstAnalzeAuthors.SelectedItems[0].SubItems[0].Text;

            DBChat.TemplateName = lblSearchTemplate.Text;
            DBChat.author = author;
            DBChat.sharecode = lblShareCode.Text;

            DBChat_2.TemplateName = lblSearchTemplate.Text;
            DBChat_2.author = author;
            DBChat_2.sharecode = lblShareCode.Text;

            lblAuthor.Text = author;
            lblAuthorShare.Text = lblShareCode.Text;

            tabControl1.SelectedIndex = 4;

        }

        private void btnAdhocSearch_Click(object sender, EventArgs e)
        {

            if (txtAdhocSearch.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtAdhocSearch, "Input required");
                return;
            }

            string txt_Search = txtAdhocSearch.Text;
            int index = 0;
            String temp = RTBAnalyze.Text;
            RTBAnalyze.Text = "";
            RTBAnalyze.Text = temp;
            while (index < RTBAnalyze.Text.LastIndexOf(txt_Search)) // change text color matching string
            {
                RTBAnalyze.Find(txt_Search, index, RTBAnalyze.TextLength, RichTextBoxFinds.None);
                RTBAnalyze.SelectionBackColor = Color.Aqua;
                index = RTBAnalyze.Text.IndexOf(txt_Search, index) + 1;
                RTBAnalyze.Select();
            }
        }

        private void txtAdhocSearch_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }


        private void btnSavetoDB_Click(object sender, EventArgs e)
        {
            var confirmResultr = MessageBox.Show("Are you sure wou want to commit to database ",
                                   "Confirm commit",
                                   MessageBoxButtons.YesNo);
            if (confirmResultr == DialogResult.Yes)
            {
                System.Threading.Thread.Sleep(3000); // wait 3 second to mature file writing
                btnSave_Click(null, null);
                GetSavedChat();
            }


        }

        private void txtShareCompany_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear(); // clear error icon
        }

        private void shareCodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShareCode frm = new frmShareCode();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void deleteChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeleteChat frm = new frmDeleteChat();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static DataTable resort(DataTable dt, string colName, string direction)
        {
            dt.DefaultView.Sort = colName + " " + direction;
            dt = dt.DefaultView.ToTable();
            return dt;
        }
        private void FillTotalAuthors(bool IsActive)
        {
            lstTotalAuthors.Items.Clear();
            try
            {
                DataTable dt = new DataTable();
                DataTable dtSort = new DataTable();
                if (chkChat2Information.Checked)
                {
                    if (IsActive == true)
                    {
                        dtSort = DBShareCode.GetTotalAuthorsChat2(); // get total number of authors in databse chat 2
                        dt = resort(dtSort, "Creator", "DESC");
                        Isorted = false;
                    }
                    else
                    {

                        //dt = DBShareCode.GetTotalAuthorsChat2(); // get total number of authors in databse chat 2
                        dtSort = DBShareCode.GetTotalAuthorsChat2(); // get total number of authors in databse chat 2
                        dt = resort(dtSort, "Creator", "ASC");
                        Isorted = true;
                    }
                }
                else
                {
                    if (IsActive == true)
                    {

                        dtSort = DBShareCode.GetTotalAuthors();
                        dt = resort(dtSort, "Author", "DESC");
                        Isorted = false;
                    }
                    else
                    {

                        //dt = DBShareCode.GetTotalAuthorsChat2(); // get total number of authors in databse chat 2
                        dtSort = DBShareCode.GetTotalAuthors();
                        dt = resort(dtSort, "Author", "ASC");
                        Isorted = true;
                    }

                    ; // get total number of authors in databse
                }
                foreach (DataRow dr in dt.Rows)
                {

                    string Ridx = dr[0].ToString();// lvEmployee.Items.Count + 1;
                    ListViewItem lvi = new ListViewItem(Ridx);
                    lvi.SubItems.Add(dr[1].ToString());
                    lstTotalAuthors.Items.Add(lvi);


                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Can't connect to MySQL server"))
                {
                    MessageBox.Show("MySQL Server services are not running ................", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FillTotalShares()
        {
            lstTotalShareCodes.Items.Clear();
            try
            {
                DataTable dt = new DataTable();
                if (chkChat2Information.Checked)
                {
                    lblTotalChats.Text = DBShareCode.GetTotalPostsChat2();
                    dt = DBShareCode.GetTotalShareCodeChat2();
                }
                else
                {
                    lblTotalChats.Text = DBShareCode.GetTotalPosts();
                    dt = DBShareCode.GetTotalShareCode();
                }
                foreach (DataRow dr in dt.Rows)
                {

                    string Ridx = dr[0].ToString();// lvEmployee.Items.Count + 1;
                    ListViewItem lvi = new ListViewItem(Ridx);
                    lvi.SubItems.Add(dr[1].ToString());
                    lstTotalShareCodes.Items.Add(lvi);


                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Can't connect to MySQL server"))
                {
                    MessageBox.Show("MySQL Server services  not running ................", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e) // check uncheck all items
        {
            if (chkAll.Checked)
            {

                for (int i = 0; i < lstBulkPort.Items.Count; i++)
                {
                    lstBulkPort.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < lstBulkPort.Items.Count; i++)
                {
                    lstBulkPort.SetItemChecked(i, false);
                }
            }
        }

        private void btnPortAll_Click(object sender, EventArgs e) // save folder
        {

            try
            {
                stopBtnClk = false;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = lstBulkPort.CheckedIndices.Count;//.SelectedIndices.Count;

                for (int i = 0; i < lstBulkPort.CheckedIndices.Count; i++)
                {
                    Application.DoEvents();


                    if (stopBtnClk == true)
                    {
                        break;
                    }
                    if (chkChat2Bulk.Checked)
                    {
                        string s = lstBulkPort.Items[lstBulkPort.CheckedIndices[i]].ToString(); // get selected items
                        FetchChat2ShareData(s); // Fetch chat-1 files and save them in xmlfiles folder
                        progressBar1.Value = i + 1;
                        lblbulkport.Text = "Fatching chat files : " + i.ToString();
                        lblbulkport.Refresh();

                    }
                    else
                    {
                        string s = lstBulkPort.Items[lstBulkPort.CheckedIndices[i]].ToString(); // get selected items
                        FetchShareData(s); // Fetch chat-1 files and save them in xmlfiles folder
                        progressBar1.Value = i + 1;
                        lblbulkport.Text = "Fatching chat files : " + i.ToString();
                        lblbulkport.Refresh();


                    }



                }
                lblbulkport.Text = "Files downloaded successfully";
                System.Threading.Thread.Sleep(1000);
                lblbulkport.Text = "Preparing for  dataporting,Please wait ";
                System.Threading.Thread.Sleep(1000);
                button1_Click_1(null, null);

                loopSavedChats();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loopSavedChats() // read all saved chats in folder and put them database
        {
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = lstBulkPort.CheckedIndices.Count;
            {
                for (int i = 0; i < lstBulkPort.CheckedIndices.Count; i++)
                {
                    Application.DoEvents();
                    if (stopBtnClk == true)
                    {
                        break;
                    }
                    progressBar1.Value = i + 1;
                    string s = lstBulkPort.Items[lstBulkPort.CheckedIndices[i]].ToString(); // get selected items
                    string path = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
                    if (FileInUse(path + "\\" + s) == false)
                    {
                        if (chkChat2Bulk.Checked)
                        {
                            SaveChattoChat2DB(s);
                        }
                        else
                        {
                            SaveChattoDB(s);
                        }
                        lblbulkport.Text = "Porting chat files in database : " + i.ToString();
                        lblbulkport.Refresh();
                        System.Threading.Thread.Sleep(1500);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2500);
                    }
                }
            }

            lblbulkport.Text = "All Files Ported Successfully";
            progressBar1.Value = 0;
        }
        private bool FileInUse(string path) // check file open mode
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    bool i = fs.CanWrite;
                }
                return false;
            }
            catch (IOException ex)
            {
                return true;
            }
        }


        private void SaveChattoDB(string sharecode) // saving chat to database routine
        {
            try
            {
                bool Result = false;
                string txt = sharecode + ".xml";
                DBChat.sharecode = sharecode;
                int ShareCodeID = DBChat.GetShareCodeID();// DBChat.GetChannelIDbyShareCode();
                if (ShareCodeID > 0)
                {
                    //int ShareCodeID = Convert.ToInt32(dt.Rows[0][0]);
                    DBChat.sharecodeid = ShareCodeID;
                    string appPath = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
                    string path = appPath + "\\" + txt;
                    int ChannelID = 0;
                    if (File.Exists(path))
                    {
                        //Tue, 10 Jul 2012 07:25:13 GMT


                        XDocument xDoc = XDocument.Load(path);
                        Channel channel = new Channel();

                        foreach (XElement c in xDoc.Descendants("channel"))
                        {
                            DBChat.title = c.Element("title").Value.Replace("'", "").Replace(";", ""); ;
                            DBChat.link = c.Element("link").Value.Replace("'", "").Replace(";", ""); ;
                            DBChat.description = c.Element("description").Value.Replace("'", "").Replace(";", ""); ;
                            DBChat.language = c.Element("language").Value.Replace("'", "").Replace(";", ""); ;
                            DBChat.lastBuildDate = c.Element("lastBuildDate").Value.Replace("'", "").Replace(";", ""); ;
                            DBChat.copyright = c.Element("copyright").Value.Replace("'", "").Replace(";", ""); ;
                            DBChat.docs = c.Element("docs").Value.Replace("'", "").Replace(";", ""); ;
                            DBChat.ttl = c.Element("ttl").Value.Replace("'", "").Replace(";", ""); ;
                            ChannelID = DBChat.InsertChannel();
                           
                            lblChannelID.Text = ChannelID.ToString();
                        }

                        int nodes = xDoc.Descendants("channel").Descendants("item").Count();
                        PBPort.Maximum = nodes;
                        Int16 idx = 0;
                        foreach (XElement x in xDoc.Descendants("channel").Descendants("item"))
                        {
                            try
                            {

                                idx++;
                                string strDate = x.Element("pubDate").Value.Replace("'", "").Replace(";", ""); ;
                                string s = strDate.Substring(5, 11);
                                string[] b = s.Split(' ');
                                string _date = b[2].ToString() + "/" + getmonth(b[1].ToString()) + "/" + b[0].ToString();
                                DBChat.channelid = ChannelID;
                                DBChat.title = x.Element("title").Value.Replace("'", "").Replace(";", ""); ;
                                DBChat.author = x.Element("author").Value.Replace("'", "").Replace(";", ""); ;
                                DBChat.description = x.Element("description").Value.Replace("'", "").Replace(";", ""); ;
                                DBChat.link = x.Element("link").Value.Replace("'", "").Replace(";", ""); ;
                                DBChat.pubDate = _date;// x.Element("pubDate").Value.Replace("'", "");
                                DBChat.pubDateFull = strDate;
                                DBChat.InsertChat();
                                Result = true;                               
                                PBPort.Value = idx;
                            }
                            catch (Exception ex)
                            {

                                if (ex.Message.ToLower().Contains("duplicate") || ex.Message.Contains("Duplicata"))
                                {
                                    PBPort.Value = idx;
                                    // MessageBox.Show("Chat  Already Exists in Database ............", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        xDoc = null;
                        if (Result == false)
                        {
                            DBChat.channelid = ChannelID; 
                            DBChat.DeleteChannel(); // delete master if no new  chat inserted in database.
                        }
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        // MessageBox.Show("Post has been fatched * ported in database", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        MessageBox.Show("File not found, please fetch file for processing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            catch (Exception ex)
            {

            }
        }

        private void btnStopworking_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to stop processing", "Information", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                stopBtnClk = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

        }

        private void ChkChat2_CheckedChanged(object sender, EventArgs e)
        {
            if (lblShareCode.Text.Trim().Length > 0)
            {
                LstShareCodes_MouseClick(null, null);
            }
            if (ChkChat2.Checked)
            {
                chkChat2Analise.Checked = true;
                chkChatTab2.Checked = true;
                chkChat2Information.Checked = true;
            }
            else
            {
                chkChat2Analise.Checked = false;
                chkChatTab2.Checked = false;
                chkChat2Information.Checked = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void chkChat2Bulk_CheckedChanged(object sender, EventArgs e)
        {

        }

        #region Chat2
        private void FetchChat2ShareData(string sharecode)
        {
            string appPath = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
            if (!Directory.Exists(appPath))
            {
                Directory.CreateDirectory(appPath);
            }
            string getShareXML = "http://www.iii.co.uk/rss/cotn:" + sharecode.Trim().ToUpper() + ".L.xml";

            using (WebClient Client = new WebClient())
            {
                Client.DownloadFileAsync(new Uri(getShareXML),
                appPath + "\\" + sharecode.Trim() + "-2.xml");
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void SaveChattoChat2DB(string sharecode) // saving chats to ChatDB-2
        {
            bool Result = false;
            try
            {
                string txt = sharecode.Trim().ToUpperInvariant() + "-2.xml";
                string appPath = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
                string path = appPath + "\\" + txt;
                int ChannelID = 0;
                if (File.Exists(path))
                {
                    //Tue, 10 Jul 2012 07:25:13 GMT


                    XDocument xDoc = XDocument.Load(path);
                    Channel channel = new Channel();

                    foreach (XElement c in xDoc.Descendants("channel"))
                    {
                        DBChat_2.sharecode = sharecode.Trim().ToUpper();
                        DBChat.sharecode = sharecode.Trim().ToUpper();
                        DBChat_2.title = c.Element("title").Value.Replace("'", "").Replace(";", "");
                        DBChat_2.description = c.Element("description").Value.Replace("'", "").Replace(";", "");
                        DBChat_2.sharecodeid = DBChat.GetShareCodeID();// ..lastBuildDate = c.Element("lastBuildDate").Value.Replace("'", "");
                        ChannelID = DBChat_2.InsertChannel();

                    }

                    int nodes = xDoc.Descendants("channel").Descendants("item").Count();
                    PBPort.Maximum = nodes;
                    Int16 idx = 0;
                    XNamespace dc = "http://purl.org/dc/elements/1.1/";
                    foreach (XElement x in xDoc.Descendants("channel").Descendants("item"))
                    {
                        try
                        {


                            idx++;
                            string strDate = x.Element("pubDate").Value.Replace("'", "");
                            string s = strDate.Substring(5, 11);
                            string[] b = s.Split(' ');
                            string _date = b[2].ToString() + "/" + getmonth(b[1].ToString()) + "/" + b[0].ToString();

                            DBChat_2.channelid = ChannelID;
                            DBChat_2.title = x.Element("title").Value.Replace("'", "").Replace(";", "");
                            DBChat_2.creator = x.Element(dc + "creator").Value.Replace("'", "").Replace(";", "");
                            DBChat_2.description = x.Element("description").Value.Replace("'", "").Replace(";", "");
                            DBChat_2.pubdate = _date;// x.Element("pubDate").Value.Replace("'", "");
                            DBChat_2.pubdateFull = strDate;// _date;// x.Element("pubDate").Value.Replace("'", "");
                            DBChat_2.InsertChats();
                            Result = true;
                            PBPort.Value = idx;
                        }
                        catch (Exception ex)
                        {

                            if (ex.Message.ToLower().Contains("duplicate") || ex.Message.Contains("Duplicata"))
                            {
                                PBPort.Value = idx;
                                // MessageBox.Show("Chat  Already Exists in Database ............", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    xDoc = null;
                    if (Result == false)
                    {
                        DBChat_2.channelid = ChannelID;
                        DBChat_2.DeleteChannel();// delete master if no new  chat inserted in database.
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                }
                else
                {
                    MessageBox.Show("File not found,Please fetch file for processing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("hexadecimal value 0x3B"))
                {
                    if (ex.Message.ToLower().Contains("duplicate") || ex.Message.Contains("Duplicata"))
                    {
                        MessageBox.Show("Chat  Already Exists in Database ............", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Chat2Analize
        private void chkChat2Analise_CheckedChanged(object sender, EventArgs e)
        {

            FillAuthorsAnalyse();      // Fill Authors//Creators     
            GetAllSharedChatDates(); // Fill lastbuild chat dates

        }

        #endregion

        private void chkChatTab2_CheckedChanged(object sender, EventArgs e)
        {
            FillChatBox();           // fill chat box
        }

        private void chhChat2Information_CheckedChanged(object sender, EventArgs e)
        {
            FillTotalShares(); // total share
            FillTotalAuthors(Isorted); // total authors
        }

        private void lstTotalAuthors_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                FillTotalAuthors(Isorted);
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {



        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";

            // Determine if the user selected a file name from the saveFileDialog. 
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                RTBAnalyze.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
