using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Domain
{
    public interface IRepositoryBase<T> where T : class
    {
        #region CRUD Operations
        bool Add(T entity);
        bool Update(int id,object values);
        bool Delete(int id);
        List<T> GetAll();
        T GetById(int id);
        List<T> GetByColumn(Expression<Func<T,object>> properyselector,object value,string sqloperator = "=");
        List<T> GetByColumn(Expression<Func<T, object>> properyselector, Expression<Func<T, object>> prop, string sqloperator = "=");
        #endregion
    }
}
