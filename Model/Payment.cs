using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Payment : BaseEntity
    {
        public int CallID { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payment(int callID, double amount, string paymentMethod, string paymentStatus, DateTime paymentDate)
        {
            CallID = callID;
            Amount = amount;
            PaymentMethod = paymentMethod;
            PaymentStatus = paymentStatus;
            PaymentDate = paymentDate;
        }

        public Payment(int id, int callID, double amount, string paymentMethod, string paymentStatus, DateTime paymentDate)
        {
            Id = id;
            CallID = callID;
            Amount = amount;
            PaymentMethod = paymentMethod;
            PaymentStatus = paymentStatus;
            PaymentDate = paymentDate;
        }

        public int ID
        {
            get => Id;
            set => Id = value;
        }

        public Payment()
        {
        }
    }
}
