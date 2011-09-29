using System;
using System.Collections.Generic;
using System.Text;
using DBLayers.DAL;
using DBLayers.BLL.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DBLayers.BLL.Regras
{
    public class Programa : IDataRecordDBLayers, IDisposable
    {
        public DAL.Entidades.Programa Instance { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<DBLayers.DAL.Entidades.Programa> List(string NomePrograma)
        {
            ProgramaPL pl = null;
            List<DBLayers.DAL.Entidades.Programa> retorno = new List<DAL.Entidades.Programa>();
            try
            {
                pl = new ProgramaPL();
                retorno =
                    pl.SP_CONSULTAR_PROGRAMA(NomePrograma);
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
            ProgramaPL pl = null;
            try
            {
                pl = new ProgramaPL();
                return pl.SP_SALVAR_PROGRAMA(this.Instance);
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
        public static Programa SelectNewInstance()
        {
            return new Programa();
        }
        public void Select(int Codigo)
        {
            ProgramaPL pl = null;
            try
            {
                pl = new ProgramaPL();
                this.Instance = pl.SP_SELECIONAR_PROGRAMA(Codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
