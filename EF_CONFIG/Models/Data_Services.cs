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
            catch(Exception ex)
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
                    if(item.Date.Day == submitDate.Day 
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
    }
}
