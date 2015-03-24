using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChatRecord
{
    public partial class frmDeleteChat : Form
    {
        public frmDeleteChat()
        {
            InitializeComponent();
        }
        private void FillComboBox()
        {
            DataTable dt = DBChat.GetAllShareCode();
            cmbShareCode.ValueMember = "ID";
            cmbShareCode.DisplayMember = "ShareCodeText";
            cmbShareCode.DataSource = dt;

            DataRow dr = dt.NewRow();
            dr[1] = "Select All";
            dr[0] = 0;

            dt.Rows.InsertAt(dr, 0);
            cmbShareCode.SelectedIndex = 0;
        }
        private void frmDeleteChat_Load(object sender, EventArgs e)
        {
            FillComboBox();
            chkEnableDate.CheckState = CheckState.Unchecked;
            dpFrom.Enabled = false;
            dpTo.Enabled = false;
        }


        private void BtnDeleteby_Click(object sender, EventArgs e)
        {
            int Sharecodeid = Convert.ToInt32(cmbShareCode.SelectedValue);
            bool chk = ChkChat2.Checked;
            if (txtPass.Text == "PassAndy2015")
            {
                try
                {

                    var confirmResult = MessageBox.Show("Are you sure to delete posts  from database  ??",
                                             "Confirm Delete!!",
                                             MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {

                        if ((chkEnableDate.CheckState == CheckState.Unchecked) && (Sharecodeid == 0))
                        {
                            var confirmResultd = MessageBox.Show("This will delete posts on given criteria from database",
                             "Confirm Delete!!",
                             MessageBoxButtons.YesNo);
                            if (confirmResultd == DialogResult.Yes)
                            {

                                if (DBChat.DeleteChatDetails(chk) == true)
                                {
                                    MessageBox.Show("All post  form database has been removed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }

                        }

                        if ((chkEnableDate.CheckState == CheckState.Checked) && (Sharecodeid == 0))
                        {
                            var confirmResult1 = MessageBox.Show("This will delete all posts by given date range",
                                          "Confirm Delete!!",
                                          MessageBoxButtons.YesNo);
                            if (confirmResult1 == DialogResult.Yes)
                            {
                                DBChat.stdate = dpFrom.Value.ToString("yyyy/MM/dd");
                                DBChat.endate = dpTo.Value.ToString("yyyy/MM/dd");
                                DataTable dt = DBChat.GetChannelIDbyDate(chk);
                                foreach (DataRow dr in dt.Rows)
                                {
                                    DBChat.channelid = Convert.ToInt32(dr[0]);
                                    DBChat.DeleteChatDetailsbyChannelID(chk);
                                }
                            }


                        }
                        if ((chkEnableDate.CheckState == CheckState.Unchecked) && (Sharecodeid > 0))
                        {
                            var confirmResult1 = MessageBox.Show("Are you sure to delete posts for (" + cmbShareCode.Text + ")",
                                           "Confirm Delete!!",
                                           MessageBoxButtons.YesNo);
                            if (confirmResult1 == DialogResult.Yes)
                            {
                                DBChat.sharecodeid = Sharecodeid;

                                DataTable dt = DBChat.GetChannelIDbyShareCode(chk);
                                foreach (DataRow dr in dt.Rows)
                                {
                                    DBChat.channelid = Convert.ToInt32(dr[0]);
                                    DBChat.DeleteChatDetailsbyChannelID(chk);
                                }
                            }

                        }

                        if ((chkEnableDate.CheckState == CheckState.Checked) && (Sharecodeid > 0))
                        {
                            var confirmResultr = MessageBox.Show("Are you sure to delete posts for (" + cmbShareCode.Text + ") with date range",
                                           "Confirm Delete!!",
                                           MessageBoxButtons.YesNo);
                            if (confirmResultr == DialogResult.Yes)
                            {
                                DBChat.stdate = dpFrom.Value.ToString("yyyy/MM/dd");
                                DBChat.endate = dpTo.Value.ToString("yyyy/MM/dd");
                                DataTable dt = DBChat.GetChannelIDbyDateAndShareCode(chk);
                                foreach (DataRow dr in dt.Rows)
                                {
                                    DBChat.channelid = Convert.ToInt32(dr[0]);
                                    DBChat.DeleteChatDetailsbyChannelID(chk);
                                }
                            }

                        }
                        MessageBox.Show("Post has been deleted successfully .............", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

            else
            {
                MessageBox.Show("Please provide password to delete Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void chkEnableDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableDate.CheckState == CheckState.Checked)
            {
                dpTo.Enabled = true;
                dpFrom.Enabled = true;
            }
            else
            {
                dpTo.Enabled = false;
                dpFrom.Enabled = false;
            }

        }


       
    }
}
