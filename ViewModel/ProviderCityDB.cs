using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace ViewModel
{
    public class ProviderCityDB : BaseDB
    {
        protected override BaseEntity newEntity()
        {
            return new ProviderCity();
        }

        protected override void CreateModel(BaseEntity entity)
        {
            ProviderCity pc = (ProviderCity)entity;
            pc.ID = Convert.ToInt32(dataReader["ID"]);
            pc.ProviderID = Convert.ToInt32(dataReader["ProviderID"]);
            pc.CityID = Convert.ToInt32(dataReader["CityID"]);
        }

        public override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            ProviderCity pc = (ProviderCity)entity;
            cmd.CommandText = "INSERT INTO ProviderCityTBL (ProviderID, CityID) VALUES (@ProviderID, @CityID)";
            cmd.Parameters.AddWithValue("@ProviderID", pc.ProviderID);
            cmd.Parameters.AddWithValue("@CityID", pc.CityID);
        }

        public override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
        {
            ProviderCity pc = (ProviderCity)entity;
            cmd.CommandText = "UPDATE ProviderCityTBL SET ProviderID = @ProviderID, CityID = @CityID WHERE ID = @ID";
            cmd.Parameters.AddWithValue("@ProviderID", pc.ProviderID);
            cmd.Parameters.AddWithValue("@CityID", pc.CityID);
            cmd.Parameters.AddWithValue("@ID", pc.ID);
        }

        public override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
        {
            ProviderCity pc = (ProviderCity)entity;
            cmd.CommandText = "DELETE FROM ProviderCityTBL WHERE ID = @ID";
            cmd.Parameters.AddWithValue("@ID", pc.ID);
        }

        public List<ProviderCity> SelectAll()
        {
            cmd.CommandText = "SELECT * FROM ProviderCityTBL";
            return Select().Cast<ProviderCity>().ToList();
        }

        public List<ProviderCity> GetCitiesByProvider(int providerId)
        {
            cmd.CommandText = $"SELECT * FROM ProviderCityTBL WHERE ProviderID = {providerId}";
            return Select().Cast<ProviderCity>().ToList();
        }
        public ProviderCity GetById(int id)
        {
            return (ProviderCity)SelectById("ProviderCityTBL", id);
        }
    }
}
