using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public abstract class BaseDB
    {
        // const is static
        private const string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../../ViewModel/Database/db.accdb;Persist Security Info=True";


        protected OleDbConnection connection;
        protected OleDbCommand cmd;
        protected OleDbDataReader dataReader;

        protected static List<ChangeEntity> UpdatedChangeEntityList = new List<ChangeEntity>();
        
        protected BaseDB()
        {
            connection = new OleDbConnection(connectionString);
            cmd = new OleDbCommand( /*"SQL COMMAND", connection*/);
            cmd.Connection = connection;
        }

        protected abstract void CreateModel(BaseEntity entity);
        protected abstract BaseEntity newEntity();

        //public abstract void Insert(BaseEntity entity);
        //public abstract void Update(BaseEntity entity);
        //public abstract void Delete(BaseEntity entity);
        public abstract void CreateInsertSql(BaseEntity entity, OleDbCommand cmd);
        public abstract void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd);
        public abstract void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd);

        public List<BaseEntity> Select()
        {
            List<BaseEntity> baseEntityList = new List<BaseEntity>();
            try
            {
                cmd.Connection = connection;
                cmd.Connection.Open();
                dataReader = cmd.ExecuteReader();
                BaseEntity baseEntity;
                while (dataReader.Read())
                {
                    //baseEntity = new Student();
                    // create different object in runtime - according to derived class
                    baseEntity = newEntity();
                    CreateModel(baseEntity);
                    baseEntityList.Add(baseEntity);
                }
            }
            catch (System.Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\n" + cmd.CommandText);
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return baseEntityList;
        }

        public static int SaveChanges()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            //OleDbConnection connection = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbTransaction transaction = null;
            int affectedRows = 0;

            try
            {
                cmd.Connection = connection;
                connection.Open();
                transaction = connection.BeginTransaction();
                cmd.Transaction = transaction;

                foreach (var item in UpdatedChangeEntityList)
                {
                    cmd.Parameters.Clear();
                    item.CreateSql(item.Entity, cmd);
                    System.Diagnostics.Debug.WriteLine("Debug SQL:\n" + cmd.CommandText);
                    foreach (OleDbParameter parameter in cmd.Parameters)
                    {
                        System.Diagnostics.Debug.WriteLine($"  Name: {parameter.ParameterName}, Value: {parameter.Value ?? "NULL"}");
                    }
                    affectedRows += cmd.ExecuteNonQuery();
                    
                    if (item.IsNew)
                    {
                        cmd.CommandText = "Select @@Identity"; // Get Last Id
                        item.Entity.Id = (int)cmd.ExecuteScalar();
                    }
                }
                transaction.Commit(); 
            }
            catch (Exception e)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                    affectedRows = 0;
                }
                //System.Diagnostics.Trace.WriteLine(e.Message + "\nSQL: " + cmd.CommandText);
                System.Diagnostics.Debug.WriteLine("Exception Error: "+e.Message + "\nSQL: " + cmd.CommandText);
            }
            finally
            {
               // inserted.Clear();
                UpdatedChangeEntityList.Clear();

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return affectedRows;
        }

        //public virtual void Insert(BaseEntity entity)
        //{
        //    BaseEntity reqEntity = this.newEntity();
        //    if (entity != null && entity.GetType() == reqEntity.GetType())
        //    {
        //        inserted.Add(new ChangeEntity(this.CreateInsertSql, entity, isNew: true));
        //    }
        //}


        public virtual void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.newEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                UpdatedChangeEntityList.Add(new ChangeEntity(CreateInsertSql, entity, isNew: false));
            }
        }

        public virtual void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.newEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                UpdatedChangeEntityList.Add(new ChangeEntity(CreateUpdateSql, entity, isNew: false));
            }
        }

        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.newEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                UpdatedChangeEntityList.Add(new ChangeEntity(CreateDeleteSql, entity, isNew: false));
            }
        }

        protected BaseEntity SelectById(string tableName, int id)
        {
            cmd.CommandText = $"SELECT * FROM {tableName} WHERE ID = {id}";
            List<BaseEntity> list = Select();

            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }
    }
}