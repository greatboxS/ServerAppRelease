using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CONFIG.Models
{
    public class ECheckSubmit
    {
        public int Area_Id { get; set; }
        public int CheckPerson_Id { get; set; }
        public List<EItem> CheckItems { get; set; }
    }

    public class EItem
    {
        public int Item { get; set; }
        public int Status { get; set; }
        public int Note { get; set; }
    }
}
