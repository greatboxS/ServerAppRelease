using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EF_CONFIG.Data;
using EF_CONFIG.Models;
using Newtonsoft.Json;

namespace AutoTune
{
    public class AutoCheck_Handle
    {
        public int UpdateHour { get; set; }
        public int UpdateMin { get; set; }
        public bool UpdateDone { get; set; }
        public CheckingPerson CheckingPerson { get; set; }

        [JsonIgnore]
        private int updateIndex;
        [JsonIgnore]
        private int[] shufArr;
        [JsonIgnore]
        private List<ECheckArea> CheckAreas = new List<ECheckArea>();
        [JsonIgnore]
        private Data_Services Data_Services = new Data_Services(new DataContext());

        public AutoCheck_Handle()
        {
            UpdateDone = false;
            UpdateHour = 0;
        }
        public AutoCheck_Handle(CheckingPerson person, int hour, int min)
        {
            CheckingPerson = person;
            UpdateHour = hour;
            UpdateMin = min;
            UpdateDone = false;
            updateIndex = 0;

            CheckAreas = Data_Services.Get_ECheckAreas();

            List<int> temp_arr = new List<int>();

            temp_arr.AddRange(new int[] { 1, 2, 3 });

            int[] suf_arr = CheckAreas.Where(i => i.id > 3).Select(i => i.AreaCode).ToArray();

            suf_arr = suf_arr.OrderBy(n => Guid.NewGuid()).ToArray();

            temp_arr.AddRange(suf_arr);

            shufArr = temp_arr.ToArray();
        }

        public int Get_CurrentArea_Id()
        {
            return updateIndex;
        }

        public ECheckArea Get_NextArea()
        {
            if (updateIndex < shufArr.Length)
            {
                int area_code = shufArr[updateIndex];
                var area = CheckAreas.Where(i => i.AreaCode == area_code).FirstOrDefault();
                return area;
            }
            else
            {
                UpdateDone = true;
                return null;
            }
        }

        public void IncreaseIndex()
        {
            updateIndex++;
        }
    }

    public class AutoCheck_Queue
    {
        public List<AutoCheck_Handle> AutoList = new List<AutoCheck_Handle>();
        public string CheckDate { get; set; } = DateTime.Now.ToString("dd/MM/yy");

        [JsonIgnore]
        private AutoCheck_Handle CurrentCheck = new AutoCheck_Handle();
        [JsonIgnore]
        private bool IsPosting = false;
        public void Add_NewQueue(CheckingPerson person, int hour, int min)
        {
            AutoList.Add(new AutoCheck_Handle(person, hour, min));
        }

        public void Get_HandleToPost(DateTime Time)
        {
            if (!IsPosting)
            {
                var current = AutoList.Where(i => i.UpdateHour == Time.Hour && i.UpdateMin == Time.Minute && !i.UpdateDone)
                    .FirstOrDefault();

                if (current != null)
                {
                    CurrentCheck = current;
                    IsPosting = true;
                }
            }
        }

        public int GetCurrentArea_Id()
        {
            if (CurrentCheck != null)
            {
                return CurrentCheck.Get_CurrentArea_Id();
            }
            else return -1;
        }

        public void Submit_Next()
        {
            if (IsPosting)
                Submit_NextCheck();
        }

        public bool IsFinished()
        {
            int finish = AutoList.Where(i => i.UpdateDone).Count();
            return finish < AutoList.Count ? false : true;
        }

        public int Get_Finish()
        {
            return AutoList.Where(i => i.UpdateDone).Count();
        }

        public void Submit_NextCheck()
        {
            if (CurrentCheck != null)
            {
                var area = CurrentCheck.Get_NextArea();

                if (area == null || CurrentCheck.UpdateDone)
                {
                    CurrentCheck = new AutoCheck_Handle();
                    IsPosting = false;
                    return;
                }

                ECheckSubmit eCheckSubmit = new ECheckSubmit
                {
                    Area_Id = area.id,
                    CheckPerson_Id = CurrentCheck.CheckingPerson.id,
                };

                eCheckSubmit.CheckItems = new List<EItem>();
                foreach (var item in area.ECheckings)
                {
                    eCheckSubmit.CheckItems.Add(new EItem
                    {
                        Item = item.ECheckItemCode,
                        Status = 0xFF,
                    });
                }

                string url = Properties.Settings.Default.Url;

                //var request = (HttpWebRequest)WebRequest.Create("http://10.10.10.2:32760/echecklist/post");
                //var request = (HttpWebRequest)WebRequest.Create("http://10.4.3.41:32760/echecklist/post");
                var request = (HttpWebRequest)WebRequest.Create(url);
                var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(eCheckSubmit));

                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;


                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (responseString.ToLower().IndexOf("true") > -1)
                {
                    CurrentCheck.IncreaseIndex();
                }
            }
        }
    }

}