using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Security;
using System.IO;

namespace References.Common
{
    public class Cryptography<T> : IDisposable
    {
        #region ..:: Propertie

        private const string _key = "GT2111";
        private T dataobj;

        #endregion

        #region ..:: Methods

        public Cryptography(T obj)
        {
            dataobj = obj;
        }

        protected string EncryptData()
        {
            DESCryptoServiceProvider _des = null;
            try
            {
                _des = new DESCryptoServiceProvider();

                _des.Key = ASCIIEncoding.ASCII.GetBytes(_key);

                ICryptoTransform encrypt = _des.CreateEncryptor();

                MemoryStream result = new MemoryStream();

                CryptoStream cryptStream = new CryptoStream(result, encrypt, CryptoStreamMode.Write);
                cryptStream.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_des != null)
                    GC.SuppressFinalize(_des);
            }
            return string.Empty;
        }

        public void Dispose()
        {

        }

        #endregion
    }
}
