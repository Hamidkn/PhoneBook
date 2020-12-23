using PhoneBook.DataLayer.UnitOFWork;
using System;
using System.Windows.Forms;

namespace PhoneBook.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            BindGrid();
        }

        void BindGrid()
        {
            using(UnitOfWork db = new UnitOfWork())
            {
                dataGridView1.DataSource = db.PhoneBookRepository.GetPhoneBookInfo();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    if (MessageBox.Show($"آیا از حذف {name} مطمئن هستید؟", "حذف اطلاعات شخص", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int phoneInfoId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        db.PhoneBookRepository.DeletePhoneInfoById(phoneInfoId);
                        db.Save();
                        BindGrid();
                    }
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtSearch.Text = null;
            BindGrid();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmAddOrEdit frmAddOrEdit = new FrmAddOrEdit();
            if (frmAddOrEdit.ShowDialog() == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                FrmAddOrEdit frmAddOrEdit = new FrmAddOrEdit();
                var phoneBookInfoId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                frmAddOrEdit.Id = phoneBookInfoId;
                if(frmAddOrEdit.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dataGridView1.DataSource = db.PhoneBookRepository.GetPhoneInfoByFilter(txtSearch.Text);
            }
        }
    }
}
