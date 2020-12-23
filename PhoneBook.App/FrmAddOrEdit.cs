using PhoneBook.DataLayer.UnitOFWork;
using System;
using System.Windows.Forms;
using PhoneBook.DataLayer;

namespace PhoneBook.App
{
    public partial class FrmAddOrEdit : Form
    {
        public int Id = 0;
        public FrmAddOrEdit()
        {
            InitializeComponent();
        }
        private void FrmAddOrEdit_Load_1(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                if (Id != 0)
                {
                    this.Text = "Edit Person";
                    btnSave.Text = "Edit";
                    var phoneBookInfo = db.PhoneBookRepository.GetPhoneInfoById(Id);
                    txtName.Text = phoneBookInfo.Name;
                    txtMobile.Text = phoneBookInfo.Mobile;
                    txtAddress.Text = phoneBookInfo.Address;
                }
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                phonebook phoneBookInfo = new phonebook()
                {
                    Name = txtName.Text,
                    Mobile = txtMobile.Text,
                    Address = txtAddress.Text
                };
                if (Id == 0)
                {
                    db.PhoneBookRepository.InserNewPhoneInfo(phoneBookInfo);
                }
                else
                {
                    phoneBookInfo.ID = Id;
                    db.PhoneBookRepository.UpdatePhoneInfo(phoneBookInfo);
                }
                db.Save();
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSave_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (int) Keys.Enter)
            {
                btnSave_Click_1(sender , e);
            }
        }
    }
}