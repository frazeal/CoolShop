using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Stratergy;
namespace ICustomerInterface
{
    public interface IBo // Design pattern :- Composite Pattern
    {
         int Id { get; set; }
         void Validate(); 
    }
    public abstract class BoBase : IBo
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
    public interface ICustomer : IBo
    {
         IValidationStratergy<ICustomer> ValidationType { get; }
         string CustomerName { get; set; }
         string PhoneNumber { get; set; }
         decimal BillAmount { get; set; }
         DateTime BillDate { get; set; }
         string Address { get; set; }
         string Type { get; set; }
         int Id { get; set; }
         ICustomer Clone();
         
    }
    
    public abstract class CustomerBase : BoBase, ICustomer
    {
        public override void Validate()
        {
            ValidationType.Validate(this);
        }
        public void init()
        {
            CustomerName = "";
            PhoneNumber = "";
            BillAmount = 0;
            BillDate = DateTime.Now;
            Address = "";
        }
        public CustomerBase(IValidationStratergy<ICustomer> _Validate)
        {
            _ValidationType = _Validate;
            init();
        }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }
        
        [Key]
        public int Id { get; set; }
        protected string _type="B";
        public virtual string Type
        {
            get
            {
                return "B";
            }
            set
            {
                _type = value;
            }
        }
        public ICustomer Clone()
        {
            return (CustomerBase) this.MemberwiseClone();
            // Design pattern :- Prototype pattern
        }
        private IValidationStratergy<ICustomer> _ValidationType = null;
        public IValidationStratergy<ICustomer> ValidationType
        {
            get
            {
                return _ValidationType;
            }
            
        }
    }
   
}
