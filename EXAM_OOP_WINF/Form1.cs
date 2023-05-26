using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
namespace EXAM_OOP_WINF
{
    public partial class Form1 : Form
    {
        private List<string> teams = new List<string>();
        private NotifyIcon trayIcon;
        private int index_tab1;
        private int index_tab2;
        private int index_tab3;
        private int count_i_team = 1;
        private int count_team;
        private int count_team_table;
        public Form1()
        {
            InitializeComponent();

            index_tab1 = tabControl1.TabPages.IndexOf(tabPage1);
            tabControl1.TabPages.Remove(tabPage1);
            index_tab2 = tabControl1.TabPages.IndexOf(tabPage2);
            tabControl1.TabPages.Remove(tabPage2);
            index_tab3 = tabControl1.TabPages.IndexOf(tabPage3);
            tabControl1.TabPages.Remove(tabPage3);
            // ������� ������ � ����
            trayIcon = new NotifyIcon();
            trayIcon.Text = "My App";
            trayIcon.Icon = new Icon("C:\\Users\\Admin\\source\\repos\\EXAM_OOP_WINF\\EXAM_OOP_WINF\\Anonymous_emblem.svg.ico");
            trayIcon.Visible = true;

            listBox_team.DataSource = teams;
            // ��������� ���������� ��� �������� ������ �� ������ � ����
            trayIcon.DoubleClick += TrayIcon_DoubleClick;

            // ��������� ���������� ��� ����� �� ������ � ����
            trayIcon.MouseClick += TrayIcon_MouseClick;
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            // ���������� ������� ���� ����������
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show("������� ��� ���� ���, ���� ���� �� ���������� ���� �� ����������� :)");
            }
            else if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("������� ��� ���� ���, ���� ���� �� ���������� ���� �� ����������� :)");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
          
            e.Cancel = true;
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ������� �� ����������
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // ���������, ��� ������� ����� � ������
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("������� ����� � ������");
                return;
            }

            // ��������� ����� � ������ �� ������������
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                TabPage selectedTab = tabControl1.SelectedTab;
                // ������� ��������� �������
                tabControl1.TabPages.Remove(selectedTab);
                // ������������ ������� � TabControl
                tabControl1.TabPages.Insert(index_tab1 - 1, tabPage1);
                // ������������� �� ����� �������
                tabControl1.SelectedTab = tabPage1;
                // ���������� ��������� �� �������� �����������
                MessageBox.Show("����������� ������ �������");
            }
            else
            {
                // ���������� ��������� �� ������ �����������
                MessageBox.Show("�������� ����� ��� ������");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // ������� �� ����������
            Application.Exit();
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            // ������� �� ����������
            Application.Exit();
        }
        private void btnExit2_Click(object sender, EventArgs e)
        {
            // ������� �� ����������
            Application.Exit();
        }
        private void btnExit3_Click(object sender, EventArgs e)
        {
            // ������� �� ����������
            Application.Exit();
        }

        public static class InputDialog
        {
            public static string Show(string caption, string prompt)
            {
                Form promptForm = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label promptLabel = new Label()
                {
                    Left = 50,
                    Top = 20,
                    Text = prompt
                };
                TextBox textBox = new TextBox()
                {
                    Left = 50,
                    Top = 50,
                    Width = 400
                };
                Button confirmButton = new Button()
                {
                    Text = "OK",
                    Left = 350,
                    Width = 100,
                    Top = 80,
                    DialogResult = DialogResult.OK
                };
                confirmButton.Click += (sender, e) => promptForm.Close();
                promptForm.Controls.Add(promptLabel);
                promptForm.Controls.Add(textBox);
                promptForm.Controls.Add(confirmButton);
                promptForm.AcceptButton = confirmButton;
                return promptForm.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

        private void size_array_team_Click(object sender, EventArgs e)
        {
            string result = InputDialog.Show("��������� ����", "������� ��������:");
            int intValue;
            if (int.TryParse(result, out intValue))
            {
                if (intValue % 2 != 0)
                {
                    MessageBox.Show("���������� ������ ������ ���� ������! ���������� ��� ���: ");
                }
                else
                {
                    // ������������ ������� � TabControl
                    tabControl1.TabPages.Insert(index_tab2 - 1, tabPage2);
                    // ������������� �� ����� �������
                    tabControl1.SelectedTab = tabPage2;
                    index_tab1 = tabControl1.TabPages.IndexOf(tabPage1);
                    tabControl1.TabPages.Remove(tabPage1);
                    MessageBox.Show("���������� ������:" + result);
                    count_team = intValue;
                    count_team_table = intValue;
                }
            }
            else
            {
                MessageBox.Show("������� �� ����� �����");
            }
        }

        private void button_add_team_Click(object sender, EventArgs e)
        {
            if (count_team > 0)
            {
                string team = InputDialog.Show("������� �������� �������", string.Format("������� �{0}", count_i_team));
                if (!string.IsNullOrEmpty(team))
                {
                    teams.Add(team);
                    listBox_team.DataSource = null;
                    listBox_team.DataSource = teams;
                    count_i_team++;
                    count_team--;
                    if (count_team > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("������� ��� �������");
                    }
                }
            }
            else
            {
                MessageBox.Show("������� ��� �������");

            }

        }

        private void button_dell_team_Click(object sender, EventArgs e)
        {
            string name = InputDialog.Show("������� �������� ������� ��� ��������", "�������� �������");
            if (!string.IsNullOrEmpty(name))
            {
                if (teams.Contains(name))
                {
                    teams.Remove(name);
                    listBox_team.DataSource = null;
                    listBox_team.DataSource = teams;
                    count_team++;
                    count_i_team--;
                    MessageBox.Show("������� �������.", "�������� �������");
                }
                else
                {
                    MessageBox.Show("������� �� �������.", "�������� �������");
                }
            }
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            if (count_team == 0)
            {
                // ������������ ������� � TabControl
                tabControl1.TabPages.Insert(index_tab3 - 1, tabPage3);
                // ������������� �� ����� �������
                tabControl1.SelectedTab = tabPage3;
                index_tab2 = tabControl1.TabPages.IndexOf(tabPage2);
                tabControl1.TabPages.Remove(tabPage2);
                //
                //
                label1.Text = "\n���������� �����:\n";

                for (int i = 1; i <= count_team_table - 1; i++)
                {
                    label1.Text += string.Format("��� {0}:\n", i);

                    for (int j = 0; j < count_team_table / 2; j++)
                    {
                        label1.Text += string.Format("{0} - {1}\n", teams[j], teams[count_team_table - j - 1]);
                    }

                    teams.Insert(1, teams[count_team_table - 1]);
                    teams.RemoveAt(count_team_table);
                }
            }


            else
            {
                MessageBox.Show("������� �� ��� �������, �������� ����� ����������");
            }
        }

      
    }

}