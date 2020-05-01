namespace EF_CONFIG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("ECheckNoteExtension")]
    public class ECheckNoteExtension
    {
        public int Id { get; set; }
        public int? ECheckingDailyId { get; set; }
        public int? ECheckAreaId { get; set; }
        public int? ECheckItemId { get; set; }
        public int? ECheckNoteId { get; set; }
        public int? ECheckPersonId { get; set; }

        public string NoteDetail { get; set; }
        public string NoteRemark { get; set; }
        public string CheckTime { get; set; }
        public string NoteReason { get; set; }
        public string Solution { get; set; }
        public bool Resolved { get; set; } = false;
        public DateTime? CheckTime_ { get; set; } = DateTime.Now;
        public string NoteProgress { get; set; }
        public DateTime? NoteHandledTime { get; set; }
    }
}
