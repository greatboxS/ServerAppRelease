using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EF_CONFIG.Models;
using EF_CONFIG.Data;
using EF_CONFIG.Exports;


namespace AutoTune.ControlView
{
    public partial class NotOkLogs : UserControl
    {
        public NotOkLogs()
        {
            InitializeComponent();
        }


        private ECheckingDaily ECheckDaily;
        private CheckingPerson EPerson;
        private Data_Services Data_Services;
        private DataContext DataContext;
        private ECheckItem ECheckItem;
        private ECheckArea EArea;
        private ECheckNoteExtension ECheckNoteExtension;
        private NoteDetailForm NoteDetailForm;

        public NotOkLogs(ECheckingDaily echeckDaily, int place)
        {
            InitializeComponent();
            DataContext = new DataContext();
            Data_Services = new Data_Services(DataContext);
            ECheckDaily = echeckDaily;
            EPerson = Data_Services.Get_CheckPerson((int)ECheckDaily.CheckingPersonId);
            ECheckItem = Data_Services.Get_ECheckItem(ECheckDaily.ECheckItemCode);
            EArea = Data_Services.Get_ECheckArea((int)ECheckDaily.ECheckAreaId);

            lbPlace.Text = place.ToString();
            lbArea.Text = EArea.AreaName;
            lbPerson.Text = EPerson.Name;
            lbCheckTime.Text = ECheckDaily.TimeStr;
            lbItem.Text = ECheckItem.CheckName;
            lbStatus.Text = echeckDaily.Status == 0x00 ? "Not OK" : "OK";

            if(place%2==0)
            {
                this.BackColor = Color.LightBlue;
            }
            else
            {
                this.BackColor = Color.LightGray;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (ECheckDaily.Status != 0xFF)
            {
                ECheckNoteExtension = Data_Services.Get_ECheckNoteExtension(ECheckDaily);
                if (NoteDetailForm == null || NoteDetailForm.IsDisposed)
                    NoteDetailForm = new NoteDetailForm(ECheckNoteExtension, EPerson.Name,
                        EArea.AreaName, ECheckDaily.TimeStr, ECheckItem.CheckName);

                NoteDetailForm.Show();
                NoteDetailForm.BringToFront();
            }
        }
    }
}
