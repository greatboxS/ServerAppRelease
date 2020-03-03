using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace EF_CONFIG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("ECheckItem")]
    public class ECheckItem
    {
        public ECheckItem()
        {

        }

        public ECheckItem(ECheckItemDef code, string name)
        {
            ECheckItemCode = (int)code;
            CheckName = name;
        }
        public int id { get; set; }
        public int ECheckItemCode { get; set; }
        public string CheckName { get; set; }
        public virtual List<EChecking> ECheckings { get; set; }
        public virtual List<ECheckingDaily> ECheckingDailys { get; set; }
    }
}
