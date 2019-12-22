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
    public partial class ThemLHP : Form
    {
        private string mamon;
        public ThemLHP( string mh)
        {
            InitializeComponent();
            mamon = mh;
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {   

                if(textBox1.Text==""|| textBox2.Text == ""|| textBox3.Text == ""|| textBox4.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                }
                else if (LopHP.CheckMa(textBox1.Text)==1)
                {
                    MessageBox.Show("Mã này đã tồn tại");
                }
                else if (LopHP.CheckTen(textBox2.Text) == 1)
                {
                    MessageBox.Show("Tên này đã tồn tại");
                }
                else { 
                var lop = new LopHP
                {
                    malhp = textBox1.Text,
                    tenlhp = textBox2.Text,
                    dmsv = Int32.Parse(textBox3.Text),
                    gv = textBox4.Text,
                    mamh=mamon,
                };
                LopHP.Add(lop);
                MessageBox.Show("Đã thêm Lớp Học phần có tên là: " + lop.tenlhp, "Thông báo",
             MessageBoxButtons.OK,
             MessageBoxIcon.Information);
                DialogResult = System.Windows.Forms.DialogResult.OK;

            }
            }
            catch
            {
                MessageBox.Show("Dữ liệu không chính xác");
            }
        }
    }
}
