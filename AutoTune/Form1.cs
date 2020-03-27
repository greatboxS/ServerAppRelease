using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EF_CONFIG.Data;
using EF_CONFIG.Exports;
using EF_CONFIG.Models;
using Newtonsoft.Json;

namespace AutoTune
{
    public partial class Form1 : Form
    {
        private DataContext DataContext;
        private Data_Services Data_Services;
        private ServerExport ServerExport;
        private AutoTuneForm autoTuneForm;
        private Timer AutoUpdateExcelTimer = new Timer { Enabled = true, Interval = 1000 * 30 };//20s timer
        string lastUpdateTime = string.Empty;
        public Form1()
        {
            InitializeComponent();

            DataBaseInitialize.Begin();

            autoTuneForm = new AutoTuneForm();

            DataContext = new DataContext();
            Data_Services = new Data_Services(DataContext);
            ServerExport = new ServerExport(DataContext);

            AutoUpdateExcelTimer.Tick += AutoUpdateExcelTimer_Tick;
            AutoUpdateExcelTimer.Start();
        }

        private void AutoUpdateExcelTimer_Tick(object sender, EventArgs e)
        {
            AutoUpdateExcelTimer.Stop();
            var last_submit = Data_Services.GetLastSumbit();
            if (last_submit != null)
            {
                if (last_submit.UpdateTime != lastUpdateTime)
                {
                    lastUpdateTime = last_submit.UpdateTime;
                    ServerExport.ExportToExcel(DateTime.Now);
                    lbLastUpdate.Text = lastUpdateTime;
                }
            }
            AutoUpdateExcelTimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SecretBtn_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dateTimePicker1.Value.Day != 31
                && dateTimePicker1.Value.Year != 2019
                && dateTimePicker1.Value.Month != 12)
                return;

            //show auto tune form
            autoTuneForm.Show();
            autoTuneForm.BringToFront();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnOpenExcelFile_Click(object sender, EventArgs e)
        {
            string log = ServerExport.ExportToExcel(dateTimePicker1.Value);
            //MessageBox.Show(log);
            System.Diagnostics.Process.Start(ServerExport.Create_ExcelFile(dateTimePicker1.Value));
        }

        private void createDatabaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (DataBaseInitialize.Begin())
                MessageBox.Show("Create database successfull");
            else
                MessageBox.Show("Database already created");
        }
    }
}
