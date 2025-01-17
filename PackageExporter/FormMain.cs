﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;

namespace ReportExporter
{
    public partial class FormMain : Form
    {
        string _conn;

        public FormMain()
        {
            InitializeComponent();
        }

        private void itemConnect_Click(object sender, EventArgs e)
        {
            FormConnect fc = new FormConnect();
            if (fc.ShowDialog() == DialogResult.OK)
            {
                List<String> sql = new List<string>();
                sql.Add("SELECT [folderid],[parentfolderid],[foldername],'',1 as [type] FROM [msdb].[dbo].[sysssispackagefolders] WHERE [parentfolderid] = '00000000-0000-0000-0000-000000000000' ORDER BY [foldername]");
                sql.Add("SELECT [folderid],[parentfolderid],[foldername],'',1 as [type] FROM [msdb].[dbo].[sysssispackagefolders] WHERE [parentfolderid] <> '00000000-0000-0000-0000-000000000000' ORDER BY [foldername]");
                sql.Add("SELECT [id],      [folderid],      [name],    [id],2 as [type] FROM [dbo].[sysssispackages] ORDER BY [name]");
 
                try
                {
                    using (SqlConnection cnn = new SqlConnection())
                    {
                        _conn = fc.ConnectionString;
                        cnn.ConnectionString = _conn;
                        cnn.Open();

                        foreach (string s in sql)
                        {
                            SqlCommand cmd = new SqlCommand(s, cnn);
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                string key = rdr[0].ToString();
                                string parent  = rdr[1].ToString();
                                string name = rdr[2].ToString();
                                string id = rdr[3].ToString();
                                int type = Int32.Parse(rdr[4].ToString()) - 1;
                                //int type = 1; // Int32.Parse(rdr[4].ToString()) - 1;

                                if (name != "")
                                {
                                    if (key != "")
                                    {
                                        TreeNode[] nodes = tvwReports.Nodes.Find(parent, true);
                                        if (nodes.Length > 0)
                                        {
                                            nodes[0].Nodes.Add(key, name, type, type).Tag = id;
                                        }
                                        else
                                        {
                                            tvwReports.Nodes.Add(key, name, type, type).Tag = id;
                                        }
                                    }
                                    else
                                    {
                                        tvwReports.Nodes.Add(key, name, type, type).Tag = id;
                                    }
                                }
                            }
                            rdr.Close();
                        }
                        cnn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error connection!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private byte[] loadDataFromDB(string id)
        {
            byte[] data = null;
            string sql = "SELECT [packagedata] FROM [msdb].[dbo].[sysssispackages] WHERE [id] = N'" + id + "'";

            try
            {
                using (SqlConnection cnn = new SqlConnection())
                {
                    cnn.ConnectionString = _conn;
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        data = (byte[])rdr[0];
                    }
                    cnn.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Export Packages", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return data;
        }

        private void menuExport_Click(object sender, EventArgs e)
        {
            List<TreeNode> listNode = new List<TreeNode>();
            string strPath = String.Empty;
            int count = 0;

            if (fbdExport.ShowDialog() == DialogResult.OK)
            {
                strPath = fbdExport.SelectedPath;
                Checks(tvwReports.Nodes, listNode);
                foreach (TreeNode tn in listNode)
                {
                    string strFileName = strPath + "/" + tn.Text + ".dtsx";
                    byte[] data = loadDataFromDB(tn.Tag.ToString());
                    SaveData(strFileName, data);
                    count++;
                }
            }
            string message = count.ToString() + " files are exported to " + strPath + " !";
            if(count>0)
                MessageBox.Show( message, "Export Packages", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void Checks(TreeNodeCollection nodes, List<TreeNode> list)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked && node.ImageIndex == 1)
                {
                    list.Add(node);
                }
                Checks(node.Nodes, list);
            }
        }

         bool SaveData(string FileName, byte[] Data)
        {
            BinaryWriter Writer = null;
            bool result = false;

            try
            {
                Writer = new BinaryWriter(File.OpenWrite(FileName));
                Writer.Write(Data);
                Writer.Flush();
                result = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Export Packages", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (Writer != null) Writer.Close();
            }

            return result;
        }

        bool busy = false;
        private void tvwReports_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (busy) return;
            busy = true;
            try
            {
                checkNodes(e.Node, e.Node.Checked);
            }
            finally
            {
                busy = false;
            }
        }

        private void checkNodes(TreeNode node, bool check)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = check;
                checkNodes(child, check);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
