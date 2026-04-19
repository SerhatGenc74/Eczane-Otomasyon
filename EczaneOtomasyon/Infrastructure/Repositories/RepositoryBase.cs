using EczaneOtomasyon.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Infrastructure.Repositories
{
    public class RepositoryBase<Tentity> : IRepositoryBase<Tentity> where Tentity : class , new()
    {
        protected string _tablename;
        public RepositoryBase()
        {
            _tablename = typeof(Tentity).Name;
        }
        #region Helper Method
        protected PropertyInfo GetKeyProperty()
        {
            return typeof(Tentity).GetProperties().FirstOrDefault(p => Attribute.IsDefined(p,typeof(KeyAttribute)));
        }
        private string GetPropertyName(Expression<Func<Tentity, object>> expression)
        {
            MemberExpression exp;
            if (expression.Body is UnaryExpression uexp)
            {
                exp = (MemberExpression)uexp.Operand;
            }
            else
            {
                exp = (MemberExpression)expression.Body;
            }
            return exp.Member.Name;
            
        }
        private Tentity MapDataReaderToEntity(SqlDataReader dr)
        {
            Tentity obj = new Tentity();
            foreach (var prop in typeof(Tentity).GetProperties())
            {
                if (dr[prop.Name] != DBNull.Value)
                {
                    prop.SetValue(obj, dr[prop.Name]);
                }
            }
            return obj;
        }
        #endregion

        #region
        public List<Tentity> GetByColumn(Expression<Func<Tentity, object>> properyselector, object value,string sqloperator = "=")
        {
            
            var list = new List<Tentity>();
            var column = GetPropertyName(properyselector);
            using (SqlConnection conn = Connection.GetConnection())
            {

                string query = $"SELECT * FROM {_tablename} WHERE {column} {sqloperator} @val";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@val", value);
                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    list.Add(MapDataReaderToEntity(dr));
                }
            }
            return list;
        }
        public List<Tentity> GetByColumn(Expression<Func<Tentity, object>> column1, Expression<Func<Tentity, object>> column2, string sqloperator = "=")
        {

            var list = new List<Tentity>();
            var col1 = GetPropertyName(column1);
            var col2 = GetPropertyName(column2);

            using (SqlConnection conn = Connection.GetConnection())
            {

                string query = $"SELECT * FROM {_tablename} WHERE {col1} {sqloperator} {col2}";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(MapDataReaderToEntity(dr));
                }
            }
            return list;
        }


        public bool Add(Tentity entity)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                var pk_prop = GetKeyProperty();
                var props = typeof(Tentity).GetProperties().Where(p => p != pk_prop).ToList();

                string columns = string.Join(", ", props.Select(p => p.Name));
                string parameters = string.Join(", ", props.Select(p => "@" + p.Name));
                    
                
                string query = $"INSERT INTO {_tablename} ({columns}) VALUES ({parameters})";

                SqlCommand cmd = new SqlCommand(query, conn);

                foreach(var prop in props)
                {
                    cmd.Parameters.AddWithValue('@' + prop.Name, prop.GetValue(entity) ?? DBNull.Value);
                }

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                var pk_prop = GetKeyProperty();
                string query = $"DELETE FROM {_tablename} WHERE {pk_prop.Name} = @id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Update(int id, object values)
        {
            using (SqlConnection conn = Connection.GetConnection()) {
                var pk_prop = GetKeyProperty();
                var props = values.GetType().GetProperties();

                string set_clause = string.Join(", ", props.Select(p => p.Name + " = @" + p.Name));

                string query = $"UPDATE {_tablename} SET {set_clause} WHERE {pk_prop.Name} = @id";

                SqlCommand cmd = new SqlCommand(query, conn);

                foreach (var prop in props)
                {
                    cmd.Parameters.AddWithValue('@' + prop.Name, prop.GetValue(values) ?? DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@id", id);

                return cmd.ExecuteNonQuery() > 0;
            } 
        
        }

        public List<Tentity> GetAll()
        {
            List<Tentity> list = new List<Tentity>();
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = $"SELECT * FROM {_tablename}";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Tentity obj = MapDataReaderToEntity(reader);
                    list.Add(obj);
                }
            }
            return list;
        }

        public Tentity GetById(int id)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                var pkprop = GetKeyProperty();

                string query = $"SELECT * FROM {_tablename} WHERE {pkprop.Name} = @id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    return MapDataReaderToEntity(dr);
                }

                return null;
            }
        }

        #endregion

    }
}
