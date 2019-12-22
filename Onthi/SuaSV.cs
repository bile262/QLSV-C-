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
    public partial class SuaSV : Form
    {
        private CTLopHP c;
        private string mamon;
        private string malhp;

        public SuaSV(object ct, string mamh1, string malhp1)
        {
            InitializeComponent();
            mamon = mamh1;
            malhp = malhp1;
            c = (CTLopHP)ct;
            textBox1.Text = c.masv;
            textBox2.Text = c.hodem;
            textBox3.Text = c.ten;
            dateTimePicker1.Value = c.ngaysinh;
            textBox5.Text = c.quequan;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            CTLopHP.Remove(c);
            try
            {

                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                }
                else if (CTLopHP.CheckMa(malhp, textBox1.Text) == 1)
                {
                    MessageBox.Show("Sinh viên này đã tồn tại");
                }
                else if (CTLopHP.CheckMon(mamon, textBox1.Text) == 1)
                {
                    MessageBox.Show("Sinh viên này đã đăng kí học môn này ở lớp học phần khác");
                }
                else
                {
                    var lop = new CTLopHP
                    {
                        masv = textBox1.Text,
                        hodem = textBox2.Text,
                        ten = textBox3.Text,
                        ngaysinh = dateTimePicker1.Value,
                        mamh = mamon,
                        malhp = malhp,
                        quequan = textBox5.Text,
                    };
                    CTLopHP.Add(lop);
                    MessageBox.Show("Đã sửa Sinh viên có mã là: " + lop.masv, "Thông báo",
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
