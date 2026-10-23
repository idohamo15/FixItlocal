using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace ViewModel
{
    public class PaymentDB : BaseDB
    {
        protected override BaseEntity newEntity()
        {
            return new Payment();
        }

        protected override void CreateModel(BaseEntity entity)
        {
            Payment payment = (Payment)entity;
            payment.ID = Convert.ToInt32(dataReader["ID"]);
            payment.CallID = Convert.ToInt32(dataReader["CallID"]);
            payment.Amount = Convert.ToDouble(dataReader["Amount"]);
            payment.PaymentMethod = dataReader["PaymentMethod"].ToString();
            payment.PaymentStatus = dataReader["PaymentStatus"].ToString();
            payment.PaymentDate = Convert.ToDateTime(dataReader["PaymentDate"]);
        }

        public override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            Payment payment = (Payment)entity;
            cmd.CommandText = "INSERT INTO PaymentsTBL (CallID, Amount, PaymentMethod, PaymentStatus, PaymentDate) VALUES (@CallID, @Amount, @PaymentMethod, @PaymentStatus, @PaymentDate)";
            cmd.Parameters.AddWithValue("@CallID", payment.CallID);
            cmd.Parameters.AddWithValue("@Amount", payment.Amount);
            cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
            cmd.Parameters.AddWithValue("@PaymentStatus", payment.PaymentStatus);
            cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
        }

        public override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
        {
            Payment payment = (Payment)entity;
            cmd.CommandText = "UPDATE PaymentsTBL SET CallID = @CallID, Amount = @Amount, PaymentMethod = @PaymentMethod, PaymentStatus = @PaymentStatus, PaymentDate = @PaymentDate WHERE ID = @ID";
            cmd.Parameters.AddWithValue("@CallID", payment.CallID);
            cmd.Parameters.AddWithValue("@Amount", payment.Amount);
            cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
            cmd.Parameters.AddWithValue("@PaymentStatus", payment.PaymentStatus);
            cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
            cmd.Parameters.AddWithValue("@ID", payment.ID);
        }

        public override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
        {
            Payment payment = (Payment)entity;
            cmd.CommandText = "DELETE FROM PaymentsTBL WHERE ID = @ID";
            cmd.Parameters.AddWithValue("@ID", payment.ID);
        }

        public List<Payment> SelectAll()
        {
            cmd.CommandText = "SELECT * FROM PaymentsTBL";
            return Select().Cast<Payment>().ToList();
        }

        public Payment GetById(int id)
        {
            return (Payment)SelectById("PaymentsTBL", id);
        }
    }
}
