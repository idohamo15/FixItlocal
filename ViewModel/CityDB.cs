using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class CityDB : BaseDB
    {
        private static CityList cityList;

        protected override void CreateModel(BaseEntity entity)
        {
            City city = entity as City;
            city.Id = (int)dataReader["ID"];
            city.Name = dataReader["Name"].ToString();
        }


        protected override BaseEntity newEntity()
        {
            return new City();
        }


        public CityList SelectAll()
        {
            cmd.CommandText = @"SELECT * FROM CityTbl";
            return new CityList(base.Select());
        }

        public static City SelectById(int id)
        {
            if (cityList == null)
            {
                CityDB cityDB = new CityDB();
                cityList = cityDB.SelectAll();
            }

            City city = cityList.Find(c => c.Id == id);
            return city;
        }


        public override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            City city = entity as City;
            cmd.CommandText = "INSERT INTO CityTbl (Namee) VALUES (@CityName)";
            cmd.Parameters.Add(new OleDbParameter("@CityName", city.Name));
        }

        public override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
        {
            City city = entity as City;
            cmd.CommandText =
                "UPDATE CityTbl SET Namee = @CityName " +
                "WHERE ID=@CityId";
            cmd.Parameters.Add(new OleDbParameter("@CityName", city.Name));
            cmd.Parameters.Add(new OleDbParameter("@CityId", city.Id));
        }

        public override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
        {
            //string str = $"DELETE FROM CityTbl WHERE ID={entity.Id}";
            cmd.CommandText = $"DELETE FROM CityTbl WHERE ID=@CityId";
            cmd.Parameters.Add(new OleDbParameter("@CityId", entity.Id));

        }

        public City GetById(int id)
        {
            return (City)SelectById("CityTBL", id);
        }
    }
}