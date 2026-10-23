using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using static ViewModel.BaseDB;

namespace ViewModel
{
    public delegate void CreateSql(BaseEntity entity, OleDbCommand cmd);

    public class ChangeEntity
    {
        private CreateSql createSql;
        private BaseEntity entity;
        private bool isNew;

        public ChangeEntity(CreateSql createSql, BaseEntity entity, bool isNew = false)
        {
            this.Entity = entity;
            this.createSql = createSql;
            this.isNew = isNew;
        }


        public BaseEntity Entity
        {
            get => entity;
            set => entity = value;
        }

        public CreateSql CreateSql
        {
            get => createSql;
            set => createSql = value;
        }

        public bool IsNew
        {
            get => isNew;
            set => isNew = value;
        }
    }
}