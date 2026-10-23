using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace ViewModel
{
    internal class ProviderCategoryDB : BaseDB
    {
        public override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
        {
            ProviderCategory pc = (ProviderCategory)entity;
            cmd.CommandText = "DELETE FROM ProviderCategoriesTBL WHERE ID = @ID";
            cmd.Parameters.AddWithValue("@ID", pc.Id);
        }

        public override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            ProviderCategory pc = (ProviderCategory)entity;
            cmd.CommandText = "INSERT INTO ProviderCategoriesTBL (ProviderID, CategoryID) " +
                             "VALUES (@ProviderID, @CategoryID)";

            cmd.Parameters.AddWithValue("@ProviderID", pc.ProviderID);
            cmd.Parameters.AddWithValue("@CategoryID", pc.CategoryID);
        }

        public override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
        {
            ProviderCategory pc = (ProviderCategory)entity;
            cmd.CommandText = "UPDATE ProviderCategoriesTBL SET ProviderID = @ProviderID, CategoryID = @CategoryID " +
                             "WHERE ID = @ID";

            cmd.Parameters.AddWithValue("@ProviderID", pc.ProviderID);
            cmd.Parameters.AddWithValue("@CategoryID", pc.CategoryID);
            cmd.Parameters.AddWithValue("@ID", pc.Id);
        }

        protected override void CreateModel(BaseEntity entity)
        {
            ProviderCategory pc = (ProviderCategory)entity;

            pc.Id = Convert.ToInt32(dataReader["ID"]);
            pc.ProviderID = Convert.ToInt32(dataReader["ProviderID"]);
            pc.CategoryID = Convert.ToInt32(dataReader["CategoryID"]);
        }

        public List<ProviderCategory> SelectAll()
        {
            cmd.CommandText = "SELECT * FROM ProviderCategoriesTBL";
            return base.Select().Cast<ProviderCategory>().ToList();
        }

        public List<ProviderCategory> SelectByProvider(int providerId)
        {
            cmd.CommandText = $"SELECT * FROM ProviderCategoriesTBL WHERE ProviderID = {providerId}";
            return base.Select().Cast<ProviderCategory>().ToList();
        }
        protected override BaseEntity newEntity()
        {
            return new ProviderCategory();
        }

        public ProviderCategory GetById(int id)
        {
            return (ProviderCategory)SelectById("ProviderCategoriesTBL", id);
        }
    }
}
