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
using EF_CONFIG.Models;
using AutoTune.ControlView;
namespace AutoTune
{
    public partial class ELogs : Form
    {
        private SelectLog_Area SelectLog_Area;
        private SelectLog_People SelectLog_People;
        private SelectLog_Status SelectLog_Status;
        private SelectLog_Time SelectLog_Time;

        private Data_Services Data_Services;
        private CheckingPerson EPerson;
        private ECheckArea EArea;

        Dictionary<string, List<ECheckingDaily>> GroupECheckDaily = new Dictionary<string, List<ECheckingDaily>>();

        List<ECheckingDaily> ECheckingDailies = new List<ECheckingDaily>();

        public ELogs()
        {
            InitializeComponent();

            Data_Services = new Data_Services(new DataContext());

            DS_AREA.DataSource = Data_Services.Get_ECheckAreas();
            DS_PERSON.DataSource = Data_Services.Get_CheckPersons();

        }

        private void ELogs_Load(object sender, EventArgs e)
        {

        }

        private void btnViewLogs_Click(object sender, EventArgs e)
        {
            if (rbTimeAll.Checked)
                SelectLog_Time = SelectLog_Time.LOG_TIME_ALL;

            if (rbMonth.Checked)
                SelectLog_Time = SelectLog_Time.LOG_TIME_MONTH;

            if (rbWeek.Checked)
                SelectLog_Time = SelectLog_Time.LOG_TIME_WEEK;

            if (rbToday.Checked)
                SelectLog_Time = SelectLog_Time.LOG_TIME_TODAY;


            if (rbOneArea.Checked)
                SelectLog_Area = SelectLog_Area.LOG_AREA_ONE;

            if (rbAllArea.Checked)
                SelectLog_Area = SelectLog_Area.LOG_AREA_ALL;

            if (rbOnePeople.Checked)
                SelectLog_People = SelectLog_People.LOG_PERSON_ONE;

            if (rbAllPeople.Checked)
                SelectLog_People = SelectLog_People.LOG_PEOPLE_ALL;

            if (rbStatusAll.Checked)
                SelectLog_Status = SelectLog_Status.LOG_STATUS_ALL;

            if (rbStatusOk.Checked)
                SelectLog_Status = SelectLog_Status.LOG_STATUS_OK;

            if (rbStatusNotOk.Checked)
                SelectLog_Status = SelectLog_Status.LOG_STATUS_NOT_OK;

            EPerson = cbxPeople.SelectedItem as CheckingPerson;
            EArea = cbxArea.SelectedItem as ECheckArea;

            try
            {
                ECheckingDailies = Data_Services.Get_ECheckDailyLogs(
                    SelectLog_Time,
                    SelectLog_Area,
                    SelectLog_People,
                    SelectLog_Status,
                    EPerson,
                    EArea);

                if (SelectLog_Status == SelectLog_Status.LOG_STATUS_NOT_OK)
                {
                    var group = ECheckingDailies.GroupBy(i => i.ECheckNotesId);

                    cbxGroupNotes.Items.Clear();
                    cbxGroupNotes.Items.Add("None");
                    cbxGroupNotes.Enabled = true;

                    foreach (var item in group)
                    {
                        var note = Data_Services.Get_ECheckNote((int)item.Key);
                        
                        GroupECheckDaily.Add(note.NoteName, item.ToList());

                        cbxGroupNotes.Items.Add($"{note.NoteName} ({note.AreaName}, Total: {item.Count()})");
                    }
                }
                Update_ContainerPanel(ECheckingDailies);
            }
            catch { }
        }

        List<ECheckingDaily> Get_GroupItemList(int itemIndex)
        {
            try
            {
                return GroupECheckDaily.ElementAt(itemIndex).Value;
            }
            catch { return null; }
        }

        private void Update_ContainerPanel(List<ECheckingDaily> EChecks)
        {
            ContainerPanel.Controls.Clear();

            for (int i = 0; i < EChecks.Count; i++)
            {
                NotOkLogs NotOkForm = new NotOkLogs(EChecks[i], i + 1);
                ContainerPanel.Controls.Add(NotOkForm);
            }
        }

        private void rbOneArea_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOneArea.Checked)
                cbxArea.Enabled = true;
            else
                cbxArea.Enabled = false;
        }

        private void rbOnePeople_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOnePeople.Checked)
                cbxPeople.Enabled = true;
            else
                cbxPeople.Enabled = false;
        }

        private void Update_Filter()
        {
            try
            {
                if (cbxGroupNotes.Text == "None")
                {
                    Update_ContainerPanel(ECheckingDailies);
                }
                else
                {
                    int index = cbxGroupNotes.SelectedIndex >= 1 ? cbxGroupNotes.SelectedIndex - 1 : 0;

                    var tempList = Get_GroupItemList(index);
                    Update_ContainerPanel(tempList);
                }
            }
            catch { }
        }

        private void cbxGroupNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Update_Filter();
        }
    }
}
