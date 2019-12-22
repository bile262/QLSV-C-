using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onthi.DAL.Entity
{
    class CTLopHP
    {
        [Key]
        public int mact { get; set; }
        public string malhp { get; set; }
        public string masv { get; set; }
        public string hodem { get; set; }
        public string ten { get; set; }
        public DateTime ngaysinh { get; set; }
        public string quequan { get; set; }
        public string mamh { get; set; }
        public virtual LopHP LopHP { get; set; }
        public static List<CTLopHP> GetListFromDB(string malhp)
        {
            return new OnthiDB().CTLopHPDbSet.Where(e => e.malhp == malhp).OrderBy(e => e.masv).ToList();
        }
        public static void Remove(CTLopHP ten)
        {
            var db = new OnthiDB();
            var ojbSV = db.CTLopHPDbSet.Where(e => e.mact == ten.mact).FirstOrDefault();
            if (ojbSV != null)
            {
                db.CTLopHPDbSet.Remove(ojbSV);

            }
            db.SaveChanges();
        }
        public static void Add(CTLopHP lop)
        {
            var db = new OnthiDB();
            db.CTLopHPDbSet.Add(lop);
            db.SaveChanges();

        }
        public static int CheckMa(string ma, string msv)
        {
            var db = new OnthiDB();
            var result = db.CTLopHPDbSet.Where(e => e.malhp == ma && e.masv==msv).FirstOrDefault();
            if (result != null)
            {
                return 1;

            }
            return 0;

        }
        public static int CheckMon(string ma, string msv)
        {
            var db = new OnthiDB();
            var result = db.CTLopHPDbSet.Where(e => e.mamh == ma && e.masv == msv).FirstOrDefault();
            if (result != null)
            {
                return 1;

            }
            return 0;

        }
    }
}
