using Onthi.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onthi.DAL
{
    class OnthiDB : DbContext
    {
        public OnthiDB():base("Data Source=.;Initial Catalog=OnthiDB;Persist Security Info=True;User ID=sa;Password=123")
        {

        }
        public DbSet<MonHoc> MonHocDbSet { get; set; }
        public DbSet<LopHP> LopHPDbSet { get; set; }
        public DbSet<CTLopHP> CTLopHPDbSet { get; set; }
    }
}
