using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace fpzs.dal
{
    public class SqliteHelper
    {
        private SQLiteConnection conn = null;
        private SQLiteTransaction tr = null;
        public SqliteHelper(string dataSource, string password) 
        {
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.DataSource = dataSource;
            builder.Password = password;
            builder.FailIfMissing = true;
            String connectionString = builder.ToString();
            conn = new SQLiteConnection(connectionString);
            conn.Open();
        }

        public SQLiteDataReader ExecuteReader(string sql, params SQLiteParameter[] ps)
        {
            SQLiteCommand cmd = conn.CreateCommand();
            if (tr != null)
                cmd.Transaction = tr;
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(ps);
            return cmd.ExecuteReader();
        }

        public bool ExecuteInsert(string sql, params SQLiteParameter[] ps)
        {
            SQLiteCommand cmd = conn.CreateCommand();
            if (tr != null)
                cmd.Transaction = tr;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(ps);
            int r = cmd.ExecuteNonQuery();
            if (r == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void BeginTransaction()
        {
            tr = conn.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (tr != null)
                tr.Commit();
        }

        public void RollbackTransaction()
        {
            if (tr != null)
                tr.Rollback();
        }
    }
}
