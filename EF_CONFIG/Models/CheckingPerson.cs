using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CONFIG.Models
{
   public class CheckingPerson
    {
        public int id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<ECheckingDaily> ECheckingDaily{ get; set; }
    }
}
