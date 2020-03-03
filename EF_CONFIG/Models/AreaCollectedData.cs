using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_CONFIG.Data;
using Newtonsoft.Json;

namespace EF_CONFIG.Models
{
    public class AreaCollectedData
    {
        public string EOP { get; set; }
        public List<Areas> CheckAreas { get; set; }
    }
    public class ItemData
    {
        public int ItemCode { get; set; }
        public int Status { get; set; }
    }

    public class Areas
    {
        public Exception_t Exception { get; set; }
        public int AreaCode { get; set; }
        public List<ItemData> ItemDatas { get; set; }
        public int CheckingPerson { get; set; }
        public int LastUpdate { get; set; }

        [JsonIgnore]
        public CheckingPerson Person
        {
            get
            {
                try
                {
                    using (var db = new DataContext())
                    {
                        return db.CheckingPerson.Where(i => i.id == CheckingPerson).First();
                    }
                }
                catch { return null; }
            }
        }

        [JsonIgnore]
        public string UpdateTime
        {
            get
            {
                if (Exception == Exception_t.RESP_OK)
                    return DateTime.Now.ToString();
                else
                    return null;
            }
        }

        [JsonIgnore]
        public string AreaName
        {
            get
            {
                try
                {
                    using (var db = new DataContext())
                    {
                        return db.ECheckArea.Where(i => i.AreaCode == AreaCode).First().AreaName;
                    }
                }
                catch { return null; }
            }
        }
    }
}
