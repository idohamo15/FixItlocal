using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace ViewModel
{
    public class WorkingDaysDB : BaseDB
    {
        public override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
        {
            WorkingDay item = (WorkingDay)entity;
            cmd.CommandText = "INSERT INTO WorkingDaysTBL (ProviderID, DayOfWeek, StartTime, EndTime) VALUES (@ProviderID, @DayOfWeek, @StartTime, @EndTime)";
            cmd.Parameters.AddWithValue("@ProviderID", item.ProviderID);
            cmd.Parameters.AddWithValue("@DayOfWeek", item.DayOfWeek);
            cmd.Parameters.AddWithValue("@StartTime", item.StartTime);
            cmd.Parameters.AddWithValue("@EndTime", item.EndTime);
        }

        public override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            WorkingDay item = (WorkingDay)entity;
            cmd.CommandText = "INSERT INTO WorkingDaysTBL (ProviderID, DayOfWeek, StartTime, EndTime) VALUES (@ProviderID, @DayOfWeek, @StartTime, @EndTime)";
            cmd.Parameters.AddWithValue("@ProviderID", item.ProviderID);
            cmd.Parameters.AddWithValue("@DayOfWeek", item.DayOfWeek);
            cmd.Parameters.AddWithValue("@StartTime", item.StartTime);
            cmd.Parameters.AddWithValue("@EndTime", item.EndTime);
        }

        public override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
        {
            WorkingDay item = (WorkingDay)entity;
            cmd.CommandText = "UPDATE WorkingDaysTBL SET ProviderID = @ProviderID, DayOfWeek = @DayOfWeek, StartTime = @StartTime, EndTime = @EndTime WHERE ID = @ID";
            cmd.Parameters.AddWithValue("@ProviderID", item.ProviderID);
            cmd.Parameters.AddWithValue("@DayOfWeek", item.DayOfWeek);
            cmd.Parameters.AddWithValue("@StartTime", item.StartTime);
            cmd.Parameters.AddWithValue("@EndTime", item.EndTime);
            cmd.Parameters.AddWithValue("@ID", item.ID);
        }

        protected override void CreateModel(BaseEntity entity)
        {
            WorkingDay item = (WorkingDay)entity;
            item.ID = Convert.ToInt32(dataReader["ID"]);
            item.ProviderID = Convert.ToInt32(dataReader["ProviderID"]);
            item.DayOfWeek = Convert.ToInt32(dataReader["DayOfWeek"]);
            item.StartTime = dataReader["StartTime"].ToString();
            item.EndTime = dataReader["EndTime"].ToString();
        }

        protected override BaseEntity newEntity()
        {
            return new WorkingDay();
        }

        public List<WorkingDay> SelectAll()
        {
            cmd.CommandText = "SELECT * FROM WorkingDaysTBL";
            return Select().Cast<WorkingDay>().ToList();
        }

        public List<WorkingDay> GetByProvider(int providerId)
        {
            cmd.CommandText = $"SELECT * FROM WorkingDaysTBL WHERE ProviderID = {providerId}";
            return Select().Cast<WorkingDay>().ToList();
        }

        public WorkingDay GetById(int id)
        {
            return (WorkingDay)SelectById("WorkingDaysTBL", id);
        }
    }
}

