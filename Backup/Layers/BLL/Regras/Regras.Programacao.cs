using System;
using System.Collections.Generic;
using System.Text;
using DBLayers.DAL;
using DBLayers.BLL.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DBLayers.BLL.Regras
{
    public class Programacao : IDataRecordDBLayers, IDisposable
    {
        public DAL.Entidades.Programacao Instance { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<DBLayers.DAL.Entidades.Programacao> List(int CodigoPrograma)
        {
            ProgramacaoPL pl = null;
            List<DBLayers.DAL.Entidades.Programacao> retorno = new List<DAL.Entidades.Programacao>();
            try
            {
                pl = new ProgramacaoPL();
                retorno =
                    pl.SP_CONSULTAR_PROGRAMACAO(CodigoPrograma);
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
            ProgramacaoPL pl = null;
            try
            {
                pl = new ProgramacaoPL();
                return pl.SP_SALVAR_PROGRAMACAO(this.Instance);
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
        public static Programacao SelectNewInstance()
        {
            return new Programacao();
        }
        public void Select(int Codigo)
        {
            ProgramacaoPL pl = null;
            try
            {
                pl = new ProgramacaoPL();
                this.Instance = pl.SP_SELECIONAR_PROGRAMACAO(Codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
