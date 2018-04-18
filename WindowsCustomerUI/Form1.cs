using CustomerLibrary;
using FactoryCustomer;
using ICustomerInterface;
using System;
using System.Windows.Forms;

namespace WindowsCustomerUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            ICustomer icust = null;
            icust = Factory.Create(cmbCustomerType.SelectedIndex);

            icust.CustomerName = txtCustomerName.Text;
            icust.Address = txtAddress.Text;
            icust.PhoneNumber = txtPhoneNumber.Text;
            icust.BillDate = Convert.ToDateTime(txtBillingDate.Text);
            icust.BillAmount = Convert.ToDecimal(txtBillingAmount.Text);
        }
    }
}
