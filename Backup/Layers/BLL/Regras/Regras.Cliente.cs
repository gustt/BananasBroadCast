using System;
using System.Collections.Generic;
using System.Text;
using DBLayers.DAL;
using DBLayers.BLL.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DBLayers.BLL.Regras
{
    public class Cliente : IDataRecordDBLayers, IDisposable
    {
        public DAL.Entidades.Cliente Instance { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<DAL.Entidades.Cliente> List(string NomeFantasia, string RazaoSocial)
        {
            ClientePL pl = null;
            List<DAL.Entidades.Cliente> retorno = new List<DAL.Entidades.Cliente>();
            try
            {
                pl = new ClientePL();
                retorno = 
                    pl.SP_CONSULTAR_CLIENTE(NomeFantasia, RazaoSocial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (pl != null)
                    pl.Dispose();
            }
            return retorno;
        }
        public int Insert()
        {
            ClientePL pl = null;
            try
            {
                pl = new ClientePL();
                return pl.SP_SALVAR_CLIENTE(this.Instance);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (pl != null)
                    GC.SuppressFinalize(pl);
            }
        }
        public int Update()
        {
            throw new NotImplementedException();
        }
        public int Delete()
        {
            throw new NotImplementedException();
        }
        public bool IsNew()
        {
            return (this.Instance.Codigo == 0);
        }
        public static Cliente SelectNewInstance()
        {
            return new Cliente();
        }
        public void Select(int Codigo)
        {
            ClientePL pl = null;
            try
            {
                pl = new ClientePL();
                this.Instance = pl.SP_SELECIONAR_CLIENTE(Codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
