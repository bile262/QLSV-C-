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
    public partial class Form1 : Form
    {
        private List<MonHoc> mh;
        private List<LopHP> lop;
        private List<CTLopHP> ds;
        public Form1()
        {
            InitializeComponent();
            mh = MonHoc.GetListFromDB();
            foreach (MonHoc s in mh)
            {
                cmbMonhoc.Items.Add(s.tenmh);
            }
             cmbMonhoc.SelectedIndex = 0;
            Load1();
                


        }
        public void Load1()
        {
           
           
            dataGridView1.AutoGenerateColumns = false;
            var ma = MonHoc.GetMaMH(cmbMonhoc.SelectedItem.ToString());
            lop = LopHP.GetListFromDB(ma);
            bindingSource1.DataSource = lop;
            var t = (LopHP)bindingSource1.Current;
            label5.Text = t.malhp;
            label6.Text = t.dmsv.ToString();
            label8.Text = t.gv;
            ds = CTLopHP.GetListFromDB(t.malhp);
            bindingSource2.DataSource = ds;
            label7.Text = ds.Count.ToString();
        }
        private void CmbMonhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ma = MonHoc.GetMaMH(cmbMonhoc.SelectedItem.ToString());
            lop = LopHP.GetListFromDB(ma);
            bindingSource1.DataSource = lop;
            var t = (LopHP)bindingSource1.Current;
            label5.Text = t.malhp;
            label6.Text = t.dmsv.ToString();
            label8.Text = t.gv;
            ds = CTLopHP.GetListFromDB(t.malhp);
            bindingSource2.DataSource = ds;
            label7.Text = ds.Count.ToString();
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
          
            var t = (LopHP)bindingSource1.Current;
            label5.Text = t.malhp;
            label6.Text = t.dmsv.ToString();
            label8.Text = t.gv;
            ds = CTLopHP.GetListFromDB(t.malhp);
            bindingSource2.DataSource = ds;
            label7.Text = ds.Count.ToString();
        }

        private void ToolStripLabel2_Click(object sender, EventArgs e)
        {
            var f = new ThemLHP(MonHoc.GetMaMH(cmbMonhoc.SelectedItem.ToString()));
            f.ShowDialog();
            Load1();
        }

        private void ToolStripLabel3_Click(object sender, EventArgs e)
        { var t = (LopHP)bindingSource1.Current;
            var f = new SuaLHP(MonHoc.GetMaMH(cmbMonhoc.SelectedItem.ToString()), t);
            f.ShowDialog();
            Load1();
        }

        private void ToolStripLabel4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                var t = (LopHP)bindingSource1.Current;
                LopHP.Remove(t);
                MessageBox.Show("Xóa thành công ", "Thông báo",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Load1();
            }
        }

        private void ToolStripLabel7_Click(object sender, EventArgs e)
        {
            int a = Int32.Parse(label7.Text);
            var t = (LopHP)bindingSource1.Current;
            ds = CTLopHP.GetListFromDB(t.malhp);
            if (a < t.dmsv)
            {  
            var f = new DK(MonHoc.GetMaMH(cmbMonhoc.SelectedItem.ToString()),t.malhp);
            f.ShowDialog();
            Load1();
            }
            else
            {
                MessageBox.Show("Lớp học phần đã đầy");
            }
        }

        private void ToolStripLabel8_Click(object sender, EventArgs e)
        {
            var t = (CTLopHP)bindingSource2.Current;
            if (t != null) {
                if (MessageBox.Show("Bạn có thực sự muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    CTLopHP.Remove(t);
                    MessageBox.Show("Xóa thành công ", "Thông báo",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Load1();
                }
            }
            else
            {
                MessageBox.Show("Thao tác không thực hiện được");
            }
        }

        private void ToolStripLabel6_Click(object sender, EventArgs e)
        {  
            var t = (CTLopHP)bindingSource2.Current;
            if (t!=null)
                { 
            var f = new SuaSV(t, MonHoc.GetMaMH(cmbMonhoc.SelectedItem.ToString()), t.malhp);
            f.ShowDialog();
            Load1();
            }
            else
            {
                MessageBox.Show("Thao tác không thực hiện được");
            }
        }
    }
}
