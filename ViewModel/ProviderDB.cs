using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace ViewModel
{
    public class ProviderDB : BaseDB
    {
        protected override BaseEntity newEntity()
        {
            return new Provider();
        }

        protected override void CreateModel(BaseEntity entity)
        {
            Provider p = (Provider)entity;

            p.Id = Convert.ToInt32(dataReader["ProviderID"]);

            if (dataReader["Bio"] != DBNull.Value)
                p.Bio = dataReader["Bio"].ToString();

            if (dataReader["HourlyRate"] != DBNull.Value)
                p.HourlyRate = Convert.ToDouble(dataReader["HourlyRate"]);

            if (dataReader["ServiceArea"] != DBNull.Value)
                p.ServiceArea = dataReader["ServiceArea"].ToString();

            if (dataReader["ProfileImagePath"] != DBNull.Value)
                p.ProfileImagePath = dataReader["ProfileImagePath"].ToString();

            if (dataReader["IsVerified"] != DBNull.Value)
                p.IsVerified = Convert.ToBoolean(dataReader["IsVerified"]);
        }

        public List<Provider> SelectAll()
        {
            cmd.CommandText = "SELECT UserTBL.*, ProivdersTBL.* " +
                             "FROM UserTBL INNER JOIN ProivdersTBL ON UserTBL.UserID = ProivdersTBL.ProviderID";
            return base.Select().Cast<Provider>().ToList();
        }

        public override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            Provider p = (Provider)entity;
            cmd.CommandText = "INSERT INTO ProivdersTBL (ProviderID, Bio, HourlyRate, ServiceArea, ProfileImagePath, IsVerified) " +
                             "VALUES (@ProviderID, @Bio, @HourlyRate, @ServiceArea, @ProfileImagePath, @IsVerified)";

            cmd.Parameters.AddWithValue("@ProviderID", p.Id);
            cmd.Parameters.AddWithValue("@Bio", p.Bio ?? "");
            cmd.Parameters.AddWithValue("@HourlyRate", p.HourlyRate);
            cmd.Parameters.AddWithValue("@ServiceArea", p.ServiceArea ?? "");
            cmd.Parameters.AddWithValue("@ProfileImagePath", p.ProfileImagePath ?? "");
            cmd.Parameters.AddWithValue("@IsVerified", p.IsVerified);
        }

        public override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
        {
            Provider p = (Provider)entity;
            cmd.CommandText = "UPDATE ProivdersTBL SET Bio = @Bio, HourlyRate = @HourlyRate, " +
                             "ServiceArea = @ServiceArea, ProfileImagePath = @ProfileImagePath, IsVerified = @IsVerified " +
                             "WHERE ProviderID = @ID";

            cmd.Parameters.AddWithValue("@Bio", p.Bio ?? "");
            cmd.Parameters.AddWithValue("@HourlyRate", p.HourlyRate);
            cmd.Parameters.AddWithValue("@ServiceArea", p.ServiceArea ?? "");
            cmd.Parameters.AddWithValue("@ProfileImagePath", p.ProfileImagePath ?? "");
            cmd.Parameters.AddWithValue("@IsVerified", p.IsVerified);
            cmd.Parameters.AddWithValue("@ID", p.Id);
        }

        public override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
        {
            Provider p = (Provider)entity;
            cmd.CommandText = "DELETE FROM ProivdersTBL WHERE ProviderID = @ID";
            cmd.Parameters.AddWithValue("@ID", p.Id);
        }

        public Provider GetById(int id)
        {
            return (Provider)SelectById("ProivdersTBL", id);
        }
    }
}