using Program.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Program.Models
{
    public class DBModel <T>
    {
        public QLNVContext context { set; get; } = null;
        public DBModel()
        {
            context = new QLNVContext();
        }
        public List<T> getAll(string proc)
        {
            List<T> list = null;
            list = context.Database.SqlQuery<T>(proc).ToList();
            return list;
        }
        public List<T> findByKeys(string proc, string [,]keyValue)
        {
            List<T> list = null;
            object[] parameters = new SqlParameter[keyValue.GetUpperBound(0) + 1];
            for (int i = 0; i <= keyValue.GetUpperBound(0); i++)
            {
                parameters[i] = new SqlParameter(keyValue[i,0], keyValue[i,1]);
            }
            list = context.Database.SqlQuery<T>(proc, parameters).ToList();
            return list;
        }
        public ActionNotice deleteByKeys(string proc, string [,]keyValue)
        {
            object[] parameters = new SqlParameter[keyValue.GetUpperBound(0) + 1];
            for (int i = 0; i <= keyValue.GetUpperBound(0); i++)
            {
                parameters[i] = new SqlParameter(keyValue[i, 0], keyValue[i, 1]);
            }
            var result = context.Database.SqlQuery<ActionNotice>(proc, parameters).SingleOrDefault();
            return result;
        }
    }
}