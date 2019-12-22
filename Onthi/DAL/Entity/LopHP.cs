using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onthi.DAL.Entity
{
    class LopHP
    {
        [Key]
        public string malhp { get; set; }
       
        public string tenlhp { get; set; }
       
        public string gv { get; set; }
        public int dmsv { get; set; }
        public string mamh { get; set; }
        [ForeignKey("mamh")]

        public virtual MonHoc MonHoc { get; set; }

        public static List<LopHP> GetListFromDB( string mamh)
        {
            return new OnthiDB().LopHPDbSet.Where(e => e.mamh == mamh).OrderBy(e => e.tenlhp).ToList(); ;
        }
        public static List<LopHP> GetListFromDB1(string tenlhp)
        {
            return new OnthiDB().LopHPDbSet.Where(e => e.mamh == tenlhp).ToList();
        }
        public static void Add(LopHP lop)
        {
            var db = new OnthiDB();
            db.LopHPDbSet.Add(lop);
            db.SaveChanges();

        }
        public static int CheckMa(string ma)
        {
            var db = new OnthiDB();
            var result = db.LopHPDbSet.Where(e => e.malhp == ma).FirstOrDefault();
            if (result != null)
            {
                return 1;

            }
            return 0;

        }
        public static int CheckTen(string ten)
        {
            var db = new OnthiDB();
            var result = db.LopHPDbSet.Where(e => e.tenlhp == ten).FirstOrDefault();
            if (result != null)
            {
                return 1;

            }
            return 0;

        }
        public static void Remove(LopHP ten)
        {
            var db = new OnthiDB();
            var ojbSV = db.LopHPDbSet.Where(e => e.malhp == ten.malhp).FirstOrDefault();
            if (ojbSV != null)
            {
                db.LopHPDbSet.Remove(ojbSV);

            }
            db.SaveChanges();
        }
        public static void Update(LopHP sv)
        {
            var db = new OnthiDB();

            var result = db.LopHPDbSet.Where(e => e.malhp == sv.malhp).FirstOrDefault();
            if (result != null)
            {
                result.malhp = sv.malhp;
                result.tenlhp = sv.tenlhp;
                result.gv = sv.gv;
                result.dmsv = sv.dmsv;
                result.mamh = sv.mamh;

            }
            db.SaveChanges();
        }
    }
}
