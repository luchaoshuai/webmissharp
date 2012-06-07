using System.Collections.Generic;
using System.Data;

namespace IDAL
{
    public interface IDAL<T> where T : new()
    {
        IList<T> FindAll();
        IList<T> FindAllByPageDesc(int start, int limit, string conditions);
        IList<T> FindAllByPageAsc(int start, int limit, string conditions);
        IList<T> FindByProcPage(int start, int limit, string conditions, int orderby);
        string GetTotalCount(string conditions);
        T FindById(string id);
        bool Add(T _T);
        bool Update(T _T);
        bool UpdateByConditions(string sets, string conditions);
        bool Del(T _T);
        bool DelByConditions(string conditions);
        IList<T> FindTopNRecords(string n, int AoD = 0, string Conditions = null, string OrderBy = null);
        IList<T> FindByCondition(string conditions);
        int RunTransaction(List<string> sqlist);
        DataSet ExecuteSql(string sql);
        int RunProcdure(string procName, IDataParameter[] para);
    }
}
