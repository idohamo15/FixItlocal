using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        protected override BaseEntity newEntity()
        {
            return new User();
        }

        protected override void CreateModel(BaseEntity entity)
        {
            User u = (User)entity;
            u.UserId = Convert.ToInt32(dataReader["ID"]);
            u.FullName = dataReader["FullName"].ToString();
            u.Email = dataReader["Email"].ToString();
            u.PasswordHash = dataReader["PasswordHash"].ToString();
            u.Phone = dataReader["Phone"].ToString();
            u.UserType = dataReader["UserType"].ToString();
            u.CreatedAt = Convert.ToDateTime(dataReader["CreatedAt"]);
        }

        public List<User> SelectAll()
        {
            cmd.CommandText = "SELECT * FROM UserTBL";
            return base.Select().Cast<User>().ToList();
        }

        public User Login(string email, string password)
        {
            cmd.CommandText = $"SELECT * FROM UserTBL WHERE Email = '{email}' AND PasswordHash = '{password}'";
            List<User> list = base.Select().Cast<User>().ToList();
            return list.FirstOrDefault();
        }

        public override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            User u = (User)entity;
            cmd.CommandText = "INSERT INTO UserTBL (FullName, Email, PasswordHash, Phone, UserType, CreatedAt) " +
                             "VALUES (@FullName, @Email, @PasswordHash, @Phone, @UserType, @CreatedAt)";

            cmd.Parameters.AddWithValue("@FullName", u.FullName ?? "");
            cmd.Parameters.AddWithValue("@Email", u.Email ?? "");
            cmd.Parameters.AddWithValue("@PasswordHash", u.PasswordHash ?? "");
            cmd.Parameters.AddWithValue("@Phone", u.Phone ?? "");
            cmd.Parameters.AddWithValue("@UserType", u.UserType ?? "Client");
            cmd.Parameters.AddWithValue("@CreatedAt", u.CreatedAt != default ? u.CreatedAt : DateTime.Now);
        }

        public override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
        {
            User u = (User)entity;
            cmd.CommandText = "UPDATE UserTBL SET FullName = @FullName, Email = @Email, Phone = @Phone, UserType = @UserType " +
                             "WHERE ID = @ID";

            cmd.Parameters.AddWithValue("@FullName", u.FullName ?? "");
            cmd.Parameters.AddWithValue("@Email", u.Email ?? "");
            cmd.Parameters.AddWithValue("@Phone", u.Phone ?? "");
            cmd.Parameters.AddWithValue("@UserType", u.UserType ?? "Client");
            cmd.Parameters.AddWithValue("@ID", u.UserId);
        }

        public override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
        {
            User u = (User)entity;
            cmd.CommandText = "DELETE FROM UserTBL WHERE ID = @ID";
            cmd.Parameters.AddWithValue("@ID", u.UserId);
        }

        public User GetById(int id)
        {
            return (User)SelectById("UserTBL", id);
        }
    }
}
