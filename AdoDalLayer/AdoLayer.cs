using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDal;
using ICustomerInterface;
using System.Data;
using System.Data.SqlClient;
using AbstractDal;
using FactoryMiddlayer;
namespace AdoDalLayer
{
    

    public abstract class AdoAbstractTemplate<IBo> : AbstractDal<IBo>
    {

        SqlConnection objConnection;
        protected SqlCommand objCommand;
       
        void Open()
        {
            
            objConnection = new SqlConnection(@"Data Source=localhost\SQL2008;Initial Catalog=DbCustomer;Integrated Security=True");
            objConnection.Open();
            objCommand = new SqlCommand();
            objCommand.Connection = objConnection;
        }
        void Close()
        {
                objConnection.Close();

        }
        protected abstract void ExecuteQuery(IBo obj);
        protected abstract List<IBo> ExecuteNonQuery();
        // Design pattern :- Template pattern
        public void Execute(IBo obj)
        {
            Open();
            ExecuteQuery(obj);
            Close();
        }
        public List<IBo> ExecuteRead()
        {
            List<IBo> obj = new List<IBo>();
            Open();
            obj = ExecuteNonQuery();
            Close();
            return obj;
        }
        public override void Save()
        {
            foreach (IBo i in Collection)
            {
                Execute(i);
            }
        }
    }
    
    public class CustomerDal : AdoAbstractTemplate<ICustomer>
    {

        public override List<ICustomer> Get()
        {
            return ExecuteRead();
        }
        protected override List<ICustomer> ExecuteNonQuery()
        {
            List<ICustomer> o = new List<ICustomer>();
            objCommand.CommandText = "select * from tblcust";
            SqlDataReader rd = objCommand.ExecuteReader();
            while (rd.Read())
            {
                ICustomer i = Factory<ICustomer>.Create(rd["CustomerType"].ToString());
                i.Type = rd["CustomerType"].ToString();
                i.CustomerName = rd["CustomerName"].ToString();
                i.PhoneNumber = rd["PhoneNumber"].ToString();
                i.BillDate = Convert.ToDateTime(rd["BillDate"].ToString());
                i.Address = rd["Address"].ToString();
                i.Id = Convert.ToInt16(rd["Id"].ToString());
                i.BillAmount = Convert.ToDecimal(rd["BillAmount"].ToString());
                o.Add(i);
            }
            return o;
        }
        protected override void ExecuteQuery(ICustomer obj)
        {
            objCommand.CommandText = "insert into tblcust values('"
                                    + obj.CustomerName +
                                    "','" + obj.PhoneNumber
                                    + "'," + obj.BillAmount
                                    + ",'" + obj.BillDate + "','" +
                                    obj.Address + "','" 
                                    + obj.Type + "')";
            objCommand.ExecuteNonQuery();
        }   
    }

    
}
