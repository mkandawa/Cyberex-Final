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
    public partial class frmShareCode : Form
    {
        public frmShareCode()
        {
            InitializeComponent();
        }


        private void btnSaveShare_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == "PassAndy2015")
            {

                if (txtShareCodeTab.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(txtShareCodeTab, "Input required");
                    return;
                }
                if (txtShareCompany.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(txtShareCompany, "Input required");
                    return;
                }
                DBShareCode.ShareCode = txtShareCodeTab.Text;
                DBShareCode.ShareCompany = txtShareCompany.Text;
                try
                {
                    if (btnSaveShare.Text == "Save")
                    {
                        if (DBShareCode.InsertShareCode() == true)
                        {
                            MessageBox.Show("Share Code has een created successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillShareCodesList();
                            txtShareCompany.Text = string.Empty;
                            txtShareCodeTab.Text = string.Empty;
                        }

                    }
                    else if (btnSaveShare.Text == "Update")
                    {
                        DBShareCode.ShareCodeID = Convert.ToInt32(lblShareCodeID.Text);
                        if (DBShareCode.UpdateShareCode() == true)
                        {
                            MessageBox.Show("Share Code has een updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillShareCodesList();

                            txtShareCompany.Text = string.Empty;
                            txtShareCodeTab.Text = string.Empty;
                        }
                    }

                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("duplicate"))
                    {
                        MessageBox.Show("Share Code Already Exists ............", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please provide password to save/update new sharecode", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnDeleteShare_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == "PassAndy2015")
            {

                try
                {


                    if (lblShareCodeID.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Please select share code form list for  deletion", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        DBShareCode.ShareCodeID = Convert.ToInt32(lblShareCodeID.Text);
                        DBShareCode.ShareCode = txtShareCodeTab.Text;
                        if (DBShareCode.CheckTemplate() == false)
                        {
                            MessageBox.Show("Share Code not found  ............", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    var confirmResult = MessageBox.Show("Are you sure to delete this Share Code ??",
                                             "Confirm Delete!!",
                                             MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        DBShareCode.ShareCode = txtShareCodeTab.Text;
                        if (DBShareCode.DeleteShareCode() == true)
                        {
                            MessageBox.Show("Share Code  has been deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillShareCodesList();
                            txtShareCompany.Text = string.Empty;
                            txtShareCodeTab.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Share Code not deleted ............", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // If 'No', do something here.
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please provide password to delete this sharecode", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnClearShare_Click(object sender, EventArgs e)
        {
            txtShareCodeTab.Clear();
            txtShareCompany.Clear();
            btnSaveShare.Text = "Save";
            errorProvider1.Clear();
            lblShareCodeID.Text = "";
        }

        private void txtShareCodeTab_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtShareCompany_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
        private void FillShareCodesList()
        {
            lstShareCode.Items.Clear();
            try
            {


                DataTable dt = DBShareCode.GetShareCodeList();
                foreach (DataRow dr in dt.Rows)
                {

                    string Ridx = dr[0].ToString();// lvEmployee.Items.Count + 1;
                    ListViewItem lvi = new ListViewItem(Ridx);
                    // lvi.SubItems.Add(dr[0].ToString());
                    lvi.SubItems.Add(dr[1].ToString()); ;
                    lvi.SubItems.Add(dr[2].ToString()); ;
                    lstShareCode.Items.Add(lvi);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreateShareCodeList()
        {
            lstShareCode.Items.Clear();
            this.lstShareCode.BackColor = Color.AliceBlue;
            ColumnHeader header1, header2, header3;
            header1 = new ColumnHeader();
            header2 = new ColumnHeader();
            header3 = new ColumnHeader();

            header1.Text = "ID";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 70;

            header2.Text = "Share Code";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 90;

            header3.Text = "Company";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = -2;


            lstShareCode.Columns.Add(header1);
            lstShareCode.Columns.Add(header2);
            lstShareCode.Columns.Add(header3);
        }
        private void frmShareCode_Load(object sender, EventArgs e)
        {
            CreateShareCodeList();
            FillShareCodesList();
        }

        private void lstShareCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int idx = Convert.ToInt32(lstShareCode.SelectedItems[0].Text);
            lblShareCodeID.Text = idx.ToString();
            txtShareCodeTab.Text = lstShareCode.SelectedItems[0].SubItems[1].Text;
            txtShareCompany.Text = lstShareCode.SelectedItems[0].SubItems[2].Text;
            btnSaveShare.Text = "Update";
           
        }
    }
}
