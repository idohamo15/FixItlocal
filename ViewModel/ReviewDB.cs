using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace ViewModel
{
    internal class ReviewDB : BaseDB
    {
        public override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
        {
            Review r = (Review)entity;
            cmd.CommandText = "DELETE FROM ReviewsTBL WHERE ReviewID = @ID";
            cmd.Parameters.AddWithValue("@ID", r.Id);
        }

        public override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            Review r = (Review)entity;
            cmd.CommandText = "INSERT INTO ReviewsTBL (CallID, Rating, Comment, CreatedAt) " +
                             "VALUES (@CallID, @Rating, @Comment, @CreatedAt)";

            cmd.Parameters.AddWithValue("@CallID", r.CallID > 0 ? (object)r.CallID : DBNull.Value);
            cmd.Parameters.AddWithValue("@Rating", r.Rating);
            cmd.Parameters.AddWithValue("@Comment", r.Comment ?? "");
            cmd.Parameters.AddWithValue("@CreatedAt", r.CreatedAt != default ? r.CreatedAt : DateTime.Now);
        }

        public override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
        {
            Review r = (Review)entity;
            cmd.CommandText = "UPDATE ReviewsTBL SET Rating = @Rating, Comment = @Comment WHERE ReviewID = @ID";

            cmd.Parameters.AddWithValue("@Rating", r.Rating);
            cmd.Parameters.AddWithValue("@Comment", r.Comment ?? "");
            cmd.Parameters.AddWithValue("@ID", r.Id);
        }

        protected override void CreateModel(BaseEntity entity)
        {
            Review r = (Review)entity;

            r.Id = Convert.ToInt32(dataReader["ReviewID"]);

            if (dataReader["CallID"] != DBNull.Value)
                r.CallID = Convert.ToInt32(dataReader["CallID"]);

            if (dataReader["Rating"] != DBNull.Value)
                r.Rating = Convert.ToInt32(dataReader["Rating"]);

            r.Comment = dataReader["Comment"] != DBNull.Value ? dataReader["Comment"].ToString() : "";

            if (dataReader["CreatedAt"] != DBNull.Value)
                r.CreatedAt = Convert.ToDateTime(dataReader["CreatedAt"]);
        }

        protected override BaseEntity newEntity()
        {
            return new Review();
        }

        public List<Review> SelectAll()
        {
            cmd.CommandText = "SELECT * FROM ReviewsTBL";
            return base.Select().Cast<Review>().ToList();
        }

        public List<Review> SelectByProvider(int providerId)
        {
            cmd.CommandText = "SELECT ReviewsTBL.* " +
                             "FROM ReviewsTBL INNER JOIN ServiceCallsTBL ON ReviewsTBL.CallID = ServiceCallsTBL.CallID " +
                             $"WHERE ServiceCallsTBL.ProviderID = {providerId}";
            return base.Select().Cast<Review>().ToList();
        }

        public Review GetById(int id)
        {
            return (Review)SelectById("ReviewsTBL", id);
        }
    }
}
