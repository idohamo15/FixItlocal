using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace ViewModel
{
    internal class ServiceCallDB : BaseDB
    {
        protected override void CreateModel(BaseEntity entity)
        {
            ServiceCall sc = (ServiceCall)entity;

            sc.Id = Convert.ToInt32(dataReader["CallID"]);
            sc.ClientID = Convert.ToInt32(dataReader["ClientID"]);

            if (dataReader["ProviderID"] != DBNull.Value)
                sc.ProviderID = Convert.ToInt32(dataReader["ProviderID"]);

            if (dataReader["CategoryID"] != DBNull.Value)
                sc.CategoryID = Convert.ToInt32(dataReader["CategoryID"]);

            sc.Description = dataReader["Description"] != DBNull.Value ? dataReader["Description"].ToString() : "";

            if (dataReader["ImagePath"] != DBNull.Value)
                sc.ImagePath = dataReader["ImagePath"].ToString();

            if (dataReader["Status"] != DBNull.Value)
                sc.Status = dataReader["Status"].ToString();
        }

        protected override BaseEntity newEntity()
        {
            return new ServiceCall();
        }

        public override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            ServiceCall sc = (ServiceCall)entity;
            cmd.CommandText = "INSERT INTO ServiceCallsTBL (ClientID, ProviderID, CategoryID, Description, ImagePath, Status) " +
                             "VALUES (@ClientID, @ProviderID, @CategoryID, @Description, @ImagePath, @Status)";

            cmd.Parameters.AddWithValue("@ClientID", sc.ClientID);
            cmd.Parameters.AddWithValue("@ProviderID", sc.ProviderID > 0 ? (object)sc.ProviderID : DBNull.Value);
            cmd.Parameters.AddWithValue("@CategoryID", sc.CategoryID > 0 ? (object)sc.CategoryID : DBNull.Value);
            cmd.Parameters.AddWithValue("@Description", sc.Description ?? "");
            cmd.Parameters.AddWithValue("@ImagePath", sc.ImagePath ?? "");
            cmd.Parameters.AddWithValue("@Status", sc.Status ?? "Pending");
        }

        public override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
        {
            ServiceCall sc = (ServiceCall)entity;
            cmd.CommandText = "UPDATE ServiceCallsTBL SET ProviderID = @ProviderID, CategoryID = @CategoryID, " +
                             "Description = @Description, ImagePath = @ImagePath, Status = @Status WHERE CallID = @ID";

            cmd.Parameters.AddWithValue("@ProviderID", sc.ProviderID > 0 ? (object)sc.ProviderID : DBNull.Value);
            cmd.Parameters.AddWithValue("@CategoryID", sc.CategoryID > 0 ? (object)sc.CategoryID : DBNull.Value);
            cmd.Parameters.AddWithValue("@Description", sc.Description ?? "");
            cmd.Parameters.AddWithValue("@ImagePath", sc.ImagePath ?? "");
            cmd.Parameters.AddWithValue("@Status", sc.Status ?? "Pending");
            cmd.Parameters.AddWithValue("@ID", sc.Id);
        }

        public override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
        {
            ServiceCall sc = (ServiceCall)entity;
            cmd.CommandText = "DELETE FROM ServiceCallsTBL WHERE CallID = @ID";
            cmd.Parameters.AddWithValue("@ID", sc.Id);
        }
        public List<ServiceCall> SelectAll()
        {
            cmd.CommandText = "SELECT * FROM ServiceCallsTBL";
            return base.Select().Cast<ServiceCall>().ToList();
        }

        public List<ServiceCall> SelectByClient(int clientId)
        {
            cmd.CommandText = $"SELECT * FROM ServiceCallsTBL WHERE ClientID = {clientId}";
            return base.Select().Cast<ServiceCall>().ToList();
        }

        public List<ServiceCall> SelectByProvider(int providerId)
        {
            cmd.CommandText = $"SELECT * FROM ServiceCallsTBL WHERE ProviderID = {providerId}";
            return base.Select().Cast<ServiceCall>().ToList();
        }

        public ServiceCall GetById(int id)
        {
            return (ServiceCall)SelectById("ServiceCallsTBL", id);
        }
    }
}
