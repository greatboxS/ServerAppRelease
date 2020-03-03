namespace EF_CONFIG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("ECheckArea")]
    public class ECheckArea
    {
        public ECheckArea()
        {

        }
        public ECheckArea(ECheckAreaDef code, string name)
        {
            AreaCode = (int)code;
            AreaName = name;
        }
        public int id { get; set; }
        public int AreaCode { get; set; }
        public string AreaName { get; set; }

        public virtual List<EChecking> ECheckings { get; set; }
        public virtual List<ECheckingDaily> ECheckingDailys { get; set; }
    }
}
