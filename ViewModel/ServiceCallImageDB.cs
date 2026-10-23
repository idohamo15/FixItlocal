using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace ViewModel
{
    public class ServiceCallImageDB : BaseDB
    {
        protected override BaseEntity newEntity()
        {
            return new ServiceCallImage();
        }

        protected override void CreateModel(BaseEntity entity)
        {
            ServiceCallImage img = (ServiceCallImage)entity;
            img.ID = Convert.ToInt32(dataReader["ID"]);
            img.CallID = Convert.ToInt32(dataReader["CallID"]);
            img.ImagePath = dataReader["ImagePath"].ToString();
        }

        public override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            ServiceCallImage img = (ServiceCallImage)entity;
            cmd.CommandText = "INSERT INTO ServiceCallImagesTBL (CallID, ImagePath) VALUES (@CallID, @ImagePath)";
            cmd.Parameters.AddWithValue("@CallID", img.CallID);
            cmd.Parameters.AddWithValue("@ImagePath", img.ImagePath);
        }

        public override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
        {
            ServiceCallImage img = (ServiceCallImage)entity;
            cmd.CommandText = "UPDATE ServiceCallImagesTBL SET CallID = @CallID, ImagePath = @ImagePath WHERE ID = @ID";
            cmd.Parameters.AddWithValue("@CallID", img.CallID);
            cmd.Parameters.AddWithValue("@ImagePath", img.ImagePath);
            cmd.Parameters.AddWithValue("@ID", img.ID);
        }

        public override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
        {
            ServiceCallImage img = (ServiceCallImage)entity;
            cmd.CommandText = "DELETE FROM ServiceCallImagesTBL WHERE ID = @ID";
            cmd.Parameters.AddWithValue("@ID", img.ID);
        }

        public List<ServiceCallImage> SelectAll()
        {
            cmd.CommandText = "SELECT * FROM ServiceCallImagesTBL";
            return Select().Cast<ServiceCallImage>().ToList();
        }

        public List<ServiceCallImage> GetByCallID(int callId)
        {
            cmd.CommandText = $"SELECT * FROM ServiceCallImagesTBL WHERE CallID = {callId}";
            return Select().Cast<ServiceCallImage>().ToList();
        }

        public ServiceCallImage GetById(int id)
        {
            return (ServiceCallImage)SelectById("ServiceCallImagesTBL", id);
        }
    }
}

