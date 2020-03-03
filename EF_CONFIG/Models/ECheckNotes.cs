using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CONFIG.Models
{
    public class ECheckNotes
    {
        public int Id { get; set; }
        public string NoteName { get; set; }
        public List<ECheckingDaily> ECheckingDailys { get; set; }
    }
}
