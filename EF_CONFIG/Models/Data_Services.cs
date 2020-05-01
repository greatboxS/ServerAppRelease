using EF_CONFIG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CONFIG.Models
{
    public class Data_Services
    {
        private readonly DataContext DataContext;
        public Data_Services(DataContext DataContext)
        {
            this.DataContext = DataContext;
        }

        public CheckingPerson Get_CheckPerson(int Id)
        {
            try
            {
                return DataContext.CheckingPerson.Find(Id);
            }
            catch
            {
                return null;
            }
        }

        public List<CheckingPerson> Get_CheckPersons()
        {
            try
            {
                return DataContext.CheckingPerson.ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool Update_ECheckDaily(ECheckingDaily data)
        {
            try
            {
                DataContext.ECheckingDaily.Add(data);
                DataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update_ESubmit(ESubmit ESubmit)
        {
            try
            {
                ESubmit = DataContext.ESubmit.Add(ESubmit);
                DataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ECheckingDaily> Get_ECheckDaily(int Area_Id)
        {
            try
            {
                string time = DateTime.Now.ToString("hh:mm tt, dd/MM/yy");

                return DataContext.ECheckingDaily
                    .Where(i => i.ECheckAreaId == Area_Id && i.TimeStr == time)
                    .ToList();
            }
            catch
            {
                return null;
            }
        }

        public ECheckArea Get_ECheckArea(int AreadId)
        {
            try
            {
                return DataContext.ECheckArea.Include("ECheckings")
                    .Where(i => i.AreaCode == AreadId)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            { return null; }
        }

        public ECheckNotes Get_ECheckNote(int NoteId)
        {
            try
            {
                return DataContext.ECheckNotes.Find(NoteId);
            }
            catch (Exception ex)
            { return null; }
        }

        public List<ECheckArea> Get_ECheckAreas()
        {
            try
            {
                return DataContext.ECheckArea.ToList();
            }
            catch (Exception ex)
            { return null; }
        }

        public ECheckItem Get_ECheckItem(int ItemCode)
        {
            try
            {
                return DataContext.ECheckItem
                    .Where(i => i.ECheckItemCode == ItemCode)
                    .FirstOrDefault();
            }
            catch { return null; }
        }

        public List<ESubmit> GetSubmitOnDate(DateTime submitDate, ECheckAreaDef area_id)
        {
            try
            {
                var submits = DataContext.ESubmit
                    .Include("ECheckingDailys")
                    .Where(i => i.AreaId == (int)area_id)
                    .ToList();
                var result = new List<ESubmit>();
                foreach (var item in submits)
                {
                    if (item.Date.Day == submitDate.Day
                        && item.Date.Month == submitDate.Month
                        && item.Date.Year == submitDate.Year)
                    {
                        result.Add(item);
                    }
                }

                return result;
            }
            catch { return null; }
        }

        public ESubmit GetLastSumbit()
        {
            try
            {
                return DataContext.ESubmit.OrderByDescending(i => i.Id).FirstOrDefault();
            }
            catch { return null; }
        }

        public ECheckNotes GetEcheckNote(int area_id, int note_id)
        {
            try
            {
                return DataContext.ECheckNotes.Where(i => i.AreaId == area_id && i.NoteId == note_id).FirstOrDefault();
            }
            catch { return null; }
        }

        public bool Update_NoteExtension(ECheckNoteExtension NoteExtension)
        {
            try
            {
                NoteExtension = DataContext.ECheckNoteExtension.Add(NoteExtension);
                DataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DateTime FirstDayOfWeek(DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var FormatedFirstDate = culture.DateTimeFormat.FirstDayOfWeek;

            if (FormatedFirstDate != DayOfWeek.Monday)
                FormatedFirstDate = DayOfWeek.Monday;

            var diff = dt.DayOfWeek - FormatedFirstDate;
            if (diff < 0)
                diff += 7;

            return dt.AddDays(-diff).Date;
        }

        public static DateTime FirstDayOfMonth(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        public ECheckNoteExtension Get_ECheckNoteExtension(ECheckingDaily echeckDaily)
        {
            try
            {
                var NoteExtension = DataContext.ECheckNoteExtension
                    .Where(i => i.ECheckingDailyId == echeckDaily.id)
                    .FirstOrDefault();

                if (NoteExtension == null)
                {
                    NoteExtension = new ECheckNoteExtension
                    {
                        ECheckAreaId = echeckDaily.ECheckAreaId,
                        ECheckItemId = echeckDaily.ECheckItemId,
                        ECheckingDailyId = echeckDaily.id,
                        ECheckNoteId = echeckDaily.ECheckNotesId,
                        ECheckPersonId = echeckDaily.CheckingPersonId,
                        CheckTime = echeckDaily.TimeStr,
                        CheckTime_ = echeckDaily.Time,
                    };

                    if (Update_NoteExtension(NoteExtension))
                        return NoteExtension;
                    else
                        return null;
                }
                else
                    return NoteExtension;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Edit_NoteExtension(ECheckNoteExtension noteExtension)
        {
            try
            {
                DataContext.Entry(noteExtension).State = System.Data.Entity.EntityState.Modified;
                DataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ECheckingDaily> Get_ECheckDailyLogs(SelectLog_Time log_time, SelectLog_Area log_area,
            SelectLog_People log_people, SelectLog_Status log_status, CheckingPerson person, ECheckArea area)
        {
            List<ECheckingDaily> CheckingDailys = new List<ECheckingDaily>();
            List<ECheckingDaily> Results = new List<ECheckingDaily>();

            try
            {
                switch (log_status)
                {
                    case SelectLog_Status.LOG_STATUS_OK:
                        CheckingDailys = DataContext.ECheckingDaily.Where(i => i.Status == 0xFF).ToList();
                        break;
                    case SelectLog_Status.LOG_STATUS_NOT_OK:
                        CheckingDailys = DataContext.ECheckingDaily.Where(i => i.Status == 0x00).ToList();
                        break;
                    case SelectLog_Status.LOG_STATUS_ALL:
                        CheckingDailys = DataContext.ECheckingDaily.Where(i => (i.Status == 0xFF || i.Status == 0x00)).ToList();
                        break;
                }

                switch (log_people)
                {
                    case SelectLog_People.LOG_PERSON_ONE:
                        if (person == null)
                            break;

                        CheckingDailys = CheckingDailys
                            .Where(i => i.CheckingPersonId == person.id)
                            .ToList();
                        break;
                    case SelectLog_People.LOG_PEOPLE_ALL:
                        break;
                }

                switch (log_area)
                {
                    case SelectLog_Area.LOG_AREA_ONE:
                        if (area == null)
                            break;

                        CheckingDailys = CheckingDailys
                            .Where(i => i.ECheckAreaId == area.id)
                            .ToList();
                        break;
                    case SelectLog_Area.LOG_AREA_ALL:
                        break;
                }

                DateTime FirstDateOfWeek = FirstDayOfWeek(DateTime.Now);
                DateTime FirstDateOfMonth = FirstDayOfMonth(DateTime.Now);
                DateTime EndDate = DateTime.Now;

                switch (log_time)
                {
                    case SelectLog_Time.LOG_TIME_TODAY:
                        foreach (var item in CheckingDailys)
                        {
                            if (item.Time.Year == DateTime.Now.Year &&
                                item.Time.Month == DateTime.Now.Month &&
                                item.Time.Day == DateTime.Now.Day)

                                Results.Add(item);
                        }
                        break;
                    case SelectLog_Time.LOG_TIME_WEEK:

                        EndDate = FirstDateOfWeek.AddDays(7);
                        foreach (var item in CheckingDailys)
                        {
                            if (FirstDateOfWeek <= item.Time && EndDate >= item.Time)
                                Results.Add(item);
                        }
                        break;
                    case SelectLog_Time.LOG_TIME_MONTH:
                        int Add_Days = 30;

                        if (FirstDateOfMonth.Month == 1 ||
                            FirstDateOfMonth.Month == 3 ||
                            FirstDateOfMonth.Month == 5 ||
                            FirstDateOfMonth.Month == 7 ||
                            FirstDateOfMonth.Month == 8 ||
                            FirstDateOfMonth.Month == 10 ||
                            FirstDateOfMonth.Month == 12)
                            Add_Days = 31;

                        if (FirstDateOfMonth.Month == 2)
                            if (FirstDateOfMonth.Year % 4 == 0)
                                Add_Days = 29;
                            else
                                Add_Days = 28;

                        EndDate = FirstDateOfMonth.AddDays(Add_Days);

                        foreach (var item in CheckingDailys)
                        {
                            if (FirstDateOfMonth <= item.Time && EndDate >= item.Time)
                                Results.Add(item);
                        }
                        break;
                    case SelectLog_Time.LOG_TIME_ALL:
                        Results.AddRange(CheckingDailys);
                        break;
                    default:
                        break;
                }

                return Results;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    public enum SelectLog_Time
    {
        LOG_TIME_TODAY,
        LOG_TIME_WEEK,
        LOG_TIME_MONTH,
        LOG_TIME_ALL,
    }

    public enum SelectLog_Area
    {
        LOG_AREA_ONE,
        LOG_AREA_ALL,
    }

    public enum SelectLog_People
    {
        LOG_PERSON_ONE,
        LOG_PEOPLE_ALL,
    }

    public enum SelectLog_Status
    {
        LOG_STATUS_OK,
        LOG_STATUS_NOT_OK,
        LOG_STATUS_ALL,
    }
}
