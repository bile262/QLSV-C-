using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onthi.DAL.Entity
{
    class MonHoc
    {
        [Key]
        public string mamh { get; set; }
        public string tenmh { get; set; }

        public static List<MonHoc> GetListFromDB()
        {
            return new OnthiDB().MonHocDbSet.ToList();
        }
        public static string GetMaMH(string mh)
        {
            string ma=null;
            var db = new OnthiDB();

            var result = db.MonHocDbSet.Where(e => e.tenmh == mh).FirstOrDefault();
            if (result != null)
            {
                ma = result.mamh;

            }
            return ma;
        }

    }
   
}
