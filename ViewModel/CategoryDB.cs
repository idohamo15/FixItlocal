using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace ViewModel
{
    public class CategoryDB : BaseDB
    {
        protected override BaseEntity newEntity()
        {
            return new Category();
        }

        protected override void CreateModel(BaseEntity entity)
        {
            Category c = (Category)entity;

            c.Id = Convert.ToInt32(dataReader["CategoryID"]);
            c.CategoryName = dataReader["CategoryName"] != DBNull.Value ? dataReader["CategoryName"].ToString() : "";
            c.Description = dataReader["Description"] != DBNull.Value ? dataReader["Description"].ToString() : "";
        }

        public List<Category> SelectAll()
        {
            cmd.CommandText = "SELECT * FROM CategoriesTBL";
            return base.Select().Cast<Category>().ToList();
        }

        public override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            Category c = (Category)entity;
            cmd.CommandText = "INSERT INTO CategoriesTBL (CategoryName, Description) " +
                             "VALUES (@CategoryName, @Description)";

            cmd.Parameters.AddWithValue("@CategoryName", c.CategoryName ?? "");
            cmd.Parameters.AddWithValue("@Description", c.Description ?? "");
        }

        public override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
        {
            Category c = (Category)entity;
            cmd.CommandText = "UPDATE CategoriesTBL SET CategoryName = @CategoryName, Description = @Description " +
                             "WHERE CategoryID = @ID";

            cmd.Parameters.AddWithValue("@CategoryName", c.CategoryName ?? "");
            cmd.Parameters.AddWithValue("@Description", c.Description ?? "");
            cmd.Parameters.AddWithValue("@ID", c.Id);
        }

        public override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
        {
            Category c = (Category)entity;
            cmd.CommandText = "DELETE FROM CategoriesTBL WHERE CategoryID = @ID";
            cmd.Parameters.AddWithValue("@ID", c.Id);
        }

        public Category GetById(int id)
        {
            return (Category)SelectById("CategoriesTBL", id);
        }
    }
}
