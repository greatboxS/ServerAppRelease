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
using EServer.Services;
using Newtonsoft.Json;

namespace AutoTune
{
    public partial class Form1 : Form
    {
        private DataContext DataContext;
        private Data_Services Data_Services;
        private ServerExport ServerExport;
        private AutoTuneForm autoTuneForm;
        public Form1()
        {
            InitializeComponent();
            DataContext = new DataContext();
            Data_Services = new Data_Services(DataContext);
            ServerExport = new ServerExport(DataContext);
            autoTuneForm = new AutoTuneForm();
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
