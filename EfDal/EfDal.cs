using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using AbstractDal;
using IDal;
using ICustomerInterface;
using CustomerLibrary;
namespace EfDal
{
    public class AbstractTemplateEF<Anytype> : DbContext,
                                        IDataLayer<Anytype> where Anytype : class
    {
        
        
        public void Add(Anytype obj) 
        {
            
            Set<Anytype>().Add(obj);
        }

        public void Delete(Anytype obj)
        {
            Set<Anytype>().Remove(obj);
        }

        public void Save()
        {
            SaveChanges();
           
        }
        public virtual List<Anytype> Get()
        {
                return Set<Anytype>().AsQueryable<Anytype>().ToList<Anytype>();           
        }



    }
    
    public class CustomerEfDal : AbstractTemplateEF<CustomerBase>
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerBase>().ToTable("tblCust");
            modelBuilder.Entity<CustomerBase>()
                .Map<Customer>(m => m.Requires("CustomerType").HasValue("Customer"))
                .Map<Lead>(m => m.Requires("CustomerType").HasValue("Lead"));
            modelBuilder.Entity<CustomerBase>().Ignore(t => t.Type);
           // base.OnModelCreating(modelBuilder);
        }

        
        
    }
  
   
}
