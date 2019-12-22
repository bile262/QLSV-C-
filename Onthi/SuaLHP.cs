using Onthi.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Onthi
{
    public partial class SuaLHP : Form
    {
        private string mamon;
        private string malop;
        private LopHP lopht;
        public SuaLHP(string mh,object t)
        {
            InitializeComponent();
            mamon = mh;
            lopht = (LopHP)t;
            malop = lopht.malhp;
            textBox2.Text = lopht.tenlhp;
            textBox3.Text = lopht.dmsv.ToString();
            textBox4.Text = lopht.gv;
        }

        private void Button2_Click(object sender, EventArgs e)
        {

                if ( textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                }
                if (LopHP.CheckTen(textBox2.Text) == 1)
                {
                MessageBox.Show("Tên này đã tồn tại");
                }

            var lop = new LopHP
                {
                    malhp = malop,
                    tenlhp = textBox2.Text,
                    dmsv = Int32.Parse(textBox3.Text),
                    gv = textBox4.Text,
                    mamh = mamon,
                };
                LopHP.Update(lop);
                MessageBox.Show("Đã Sửa Lớp Học phần có tên là: " + lop.tenlhp, "Thông báo",
             MessageBoxButtons.OK,
             MessageBoxIcon.Information);
                DialogResult = System.Windows.Forms.DialogResult.OK;

           
         
        }
    }
}
