namespace EF_CONFIG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("ECkeckingDaily")]
    public class ECheckingDaily
    {
        public int id { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public string TimeStr { get; set; } = DateTime.Now.ToString("hh:MM tt, dd/MM/yy");
        public int ECheckAreaCode { get; set; }
        public int ECheckItemCode { get; set; }
        public int Status { get; set; }
        public virtual ECheckArea ECheckArea { get; set; }
        public virtual ECheckItem ECheckItem { get; set; }
        public int? ECheckItemId { get; set; }
        public int? ECheckAreaId { get; set; }
        public int? ECheckNotesId { get; set; }
        public virtual ECheckNotes ECheckNotes { get; set; }
        public int? ESubmitId { get; set; }
        public virtual ESubmit ESubmit{ get; set; }

        public virtual CheckingPerson CheckingPerson { get; set; }
        public int? CheckingPersonId { get; set; }
    }
}
