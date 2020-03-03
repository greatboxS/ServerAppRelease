using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CONFIG.Models
{
    [Table("ESubmit")]
    public class ESubmit
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public int PersonId { get; set; }
        public  string UpdateTime { get; set; } = DateTime.Now.ToString("hh:MM tt, dd/MM/yy");
        public DateTime Date { get; set; } = DateTime.Now;
        public List<ECheckingDaily> ECheckingDailys { get; set; }
    }
}
