using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EF_CONFIG.Data;
using EF_CONFIG.Models;
using Newtonsoft.Json;

namespace AutoTune
{
    public partial class AutoTuneForm : Form
    {
        DataContext dataContext;
        Data_Services data_Services;
        CheckingPerson CheckingPerson;
        Timer Timer = new Timer { Enabled = true, Interval = 1000 * 10 };
        Timer PostTimer = new Timer { Enabled = true, Interval = 1000 };
        int WaitingTime = 0;

        bool StartCheck = false;

        private AutoCheck_Handle AutoCheck_Handle = new AutoCheck_Handle();
        private AutoCheck_Queue AutoCheck_Queue = new AutoCheck_Queue();
        List<AutoCheck_Queue> His = new List<AutoCheck_Queue>();
        ContextMenu Menu;

        public AutoTuneForm()
        {
            InitializeComponent();
            Menu = new ContextMenu(new MenuItem[] { new MenuItem("Delete", Delete_AutoCheckItem, Shortcut.Del) });
            QueueData.ContextMenu = Menu;

            dataContext = new DataContext();
            data_Services = new Data_Services(dataContext);
            CheckingPerson = new CheckingPerson();
            Timer.Tick += Timer_Tick;
            PostTimer.Tick += PostTimer_Tick;

            DS_PERSON.DataSource = data_Services.Get_CheckPersons();

            try
            {
                string json = Properties.Settings.Default.His;
                var his = JsonConvert.DeserializeObject<List<AutoCheck_Queue>>(json);
                His = his;
                cbxHis.Items.Clear();
                foreach (var item in His)
                {
                    cbxHis.Items.Add(item.CheckDate);
                }
            }
            catch { }
        }

        private void PostTimer_Tick(object sender, EventArgs e)
        {
            if (!StartCheck)
                return;
            Random random = new Random();

            if (WaitingTime >= random.Next(4, 15))
            {
                WaitingTime = 0;
                AutoCheck_Queue.Submit_Next();
                Update_DataGridView();

                int finish = AutoCheck_Queue.Get_Finish();

                lb_Finish.Text = $"{AutoCheck_Queue.Get_Finish()}/{AutoCheck_Queue.AutoList.Count}";

                if (AutoCheck_Queue.IsFinished())
                {
                    lbStatus.Text = "Tiến trình hoàn thành";
                    AutoCheck_Queue.AutoList.Clear();
                    Timer.Stop();
                    PostTimer.Stop();
                }
            }
            WaitingTime++;
        }

        private void Delete_AutoCheckItem(object sender, EventArgs e)
        {
            try
            {
                if (QueueData.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < QueueData.SelectedRows.Count; i++)
                    {
                        AutoCheck_Queue.AutoList.RemoveAt(QueueData.SelectedRows[i].Index);
                    }
                    Update_DataGridView();
                }
            }
            catch { }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!StartCheck)
                return;

            try
            {
                // check and update all queue
                AutoCheck_Queue.Get_HandleToPost(DateTime.Now);
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckingPerson = cbxPerson.SelectedItem as CheckingPerson;
        }

        private void btnAddQueue_Click(object sender, EventArgs e)
        {
            if (cbxHour.Text == null)
            {
                MessageBox.Show("Hour is empty");
                return;
            }

            if (txtMin.Text == string.Empty)
            {
                MessageBox.Show("Min is empty");
                return;
            }

            if (cbxPerson.SelectedItem == null)
            {
                MessageBox.Show("Check person is empty");
                return;
            }

            int hour = 0, min = 0;

            int.TryParse(cbxHour.Text, out hour);
            int.TryParse(txtMin.Text, out min);
            CheckingPerson checkingPerson = cbxPerson.SelectedItem as CheckingPerson;

            AutoCheck_Queue.Add_NewQueue(checkingPerson, hour, min);
            Update_DataGridView();
        }

        private void Update_DataGridView()
        {
            DataTable Table = new DataTable();
            Table.Columns.Add("STT");
            Table.Columns.Add("Thời gian");
            Table.Columns.Add("Người trực");
            Table.Columns.Add("Tiến trình");

            int index = 0;
            foreach (var item in AutoCheck_Queue.AutoList)
            {
                index++;
                Table.Rows.Add(new object[] {
                    index,
                    $"{item.UpdateHour}:{item.UpdateMin}",
                    item.CheckingPerson.Name,
                    item.UpdateDone ? "Hoàn thành" : "Đàng chờ"
                });
            }

            QueueData.DataSource = Table;
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            try
            {
                if (His == null)
                    His = new List<AutoCheck_Queue>();
                His.Add(AutoCheck_Queue);
                Properties.Settings.Default.His = JsonConvert.SerializeObject(His);
                Properties.Settings.Default.Save();

                cbxHis.Items.Clear();
                foreach (var item in His)
                {
                    cbxHis.Items.Add(item.CheckDate);
                }

                MessageBox.Show("Save new setting successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save new setting fail");
            }
        }

        private void btnOpenHis_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxHis.SelectedItem != null)
                {
                    var queue = His.Where(i => i.CheckDate == cbxHis.Text).FirstOrDefault();
                    AutoCheck_Queue = queue;
                    Update_DataGridView();
                }
            }
            catch { }
        }

        private void cbxHis_DropDown(object sender, EventArgs e)
        {
            try
            {
                string json = Properties.Settings.Default.His;
                var his = JsonConvert.DeserializeObject<List<AutoCheck_Queue>>(json);
                His = his;
                cbxHis.Items.Clear();
                foreach (var item in His)
                {
                    cbxHis.Items.Add(item.CheckDate);
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartCheck = !StartCheck;

            if (StartCheck)
            {
                if (AutoCheck_Queue.AutoList.Count == 0 || AutoCheck_Queue.IsFinished())
                {
                    MessageBox.Show("Thêm tiến trình vào hàng đợi trước");
                    StartCheck = false;
                    return;
                }

                button1.Text = "Đang chạy check tự động";
                Timer.Start();
                PostTimer.Start();
                lbStatus.Text = "";
            }
            else
            {

                if (AutoCheck_Queue.IsFinished())
                {
                }
                else
                {
                    if (MessageBox.Show("Your progress is starting, make sure you want to stop", "",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        StartCheck = true;
                        return;

                    }


                }
                Timer.Stop();
                PostTimer.Stop();
                button1.Text = "Bắt đầu check tự động";
            }
        }

        private void AutoTuneForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
