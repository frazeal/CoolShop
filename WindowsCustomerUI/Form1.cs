using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FactoryMiddlayer;
using ICustomerInterface;
using FactoryDalLib;
using IDal;
using System.Transactions;
using Facade;
using ICustomerInterface;
using FactoryMiddlayer;
namespace WindowsCustomerUI
{
    public partial class Form1 : Form
    {
        CustomerUiFacade Fac = new CustomerUiFacade("AdoCustDal");
        ICustomer icust = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            try
            {
                 icust = Fac.Get(cmbCustomerType.Text);

                
                icust.CustomerName = txtCustomerName.Text;
                icust.Address = txtAddress.Text;
                icust.PhoneNumber = txtPhoneNumber.Text;
                icust.BillDate = Convert.ToDateTime(txtBillingDate.Text);
                icust.BillAmount = Convert.ToDecimal(txtBillingAmount.Text);

                Fac.Save(icust);
            }
            catch (Exception ex)
            {

            }
            dataGridView1.DataSource = Fac.GetCustomers(); ;
            Clear();
        }
        private void Clear()
        {
            txtAddress.Text = "";
            txtBillingAmount.Text = "";
            txtBillingDate.Text = "";
            txtCustomerName.Text = "";
            txtPhoneNumber.Text = "";
            cmbCustomerType.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
           
           // dataGridView1.DataSource = Fac.GetCustomers();
        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            icust = Factory<ICustomer>.Create(cmbCustomerType.Text);
            txtBillingDate.Text = DateTime.Now.ToString();
            txtBillingAmount.Text = "0";
        }

        private void comboRepository_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fac = new CustomerUiFacade(comboRepository.Text);
            dataGridView1.DataSource = Fac.GetCustomers();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            icust = Fac.Revert();
            LoadData();
        }
        private void LoadData()
        {
            txtAddress.Text = icust.Address;
            txtBillingAmount.Text = icust.BillAmount.ToString();
            txtBillingDate.Text = icust.BillDate.ToString();
            txtCustomerName.Text = icust.CustomerName;
            txtPhoneNumber.Text = icust.PhoneNumber;
            cmbCustomerType.Text = icust.Type;
        }
        

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //icust = Fac.Select(e.RowIndex);
            //LoadData(); 
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                icust = Factory<ICustomer>.Create(cmbCustomerType.Text);
                icust.CustomerName = txtCustomerName.Text;
                icust.Address = txtAddress.Text;
                icust.PhoneNumber = txtPhoneNumber.Text;
                icust.BillDate = Convert.ToDateTime(txtBillingDate.Text);
                icust.BillAmount = Convert.ToDecimal(txtBillingAmount.Text);
                icust.Validate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

       
    }
}
