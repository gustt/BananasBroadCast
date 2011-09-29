using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;

namespace DBLayers.DAL.Mapping
{
    public static class Mapping<T>
    {
        public static IEnumerable<T> ConvertReaderToIEnumerable(SqlDataReader dr)
        {
            while (dr.Read())
            {
                T instance = Activator.CreateInstance<T>();

                PropertyInfo[] pis = typeof(T).GetProperties();
                for (int index = 0; index < pis.Length; index++)
                {
                    if (dr[pis[index].Name] != DBNull.Value)
                    {
                        typeof(T).InvokeMember(pis[index].Name, BindingFlags.SetProperty, null, instance, new object[] { dr[pis[index].Name] });
                    }
                }

                yield return instance;
            }
        }
    }
}
