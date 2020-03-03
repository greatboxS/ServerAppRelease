namespace EF_CONFIG.Models
{
    using EF_CONFIG.Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("EChecking")]
    public class EChecking
    {
        public EChecking()
        {

        }
        public EChecking(DataContext dataContext, ECheckItemDef itemcode, ECheckAreaDef areacode)
        {
            try
            {
                var item = dataContext.ECheckItem.Where(i => i.ECheckItemCode == (int)itemcode).First();
                var area = dataContext.ECheckArea.Where(i => i.AreaCode == (int)areacode).First();

                ECheckItemId = item.id;
                ECheckItemCode = item.ECheckItemCode;
                ECheckAreaCode = area.AreaCode;
                ECheckAreaId = area.id;
            }
            catch { }
        }
        public int id { get; set; }
        public virtual ECheckItem ECheckItem { get; set; }
        public int? ECheckItemId { get; set; }
        public int ECheckItemCode { get; set; }
        public virtual ECheckArea ECheckArea { get; set; }
        public int? ECheckAreaId { get; set; }
        public int ECheckAreaCode { get; set; }
    }
}
