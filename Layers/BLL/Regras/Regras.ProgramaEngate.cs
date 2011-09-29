using System;
using System.Collections.Generic;
using System.Text;
using DBLayers.DAL;
using DBLayers.BLL.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DBLayers.BLL.Regras
{
    public class ProgramaEngate : IDataRecordDBLayers, IDisposable
    {
        public DAL.Entidades.ProgramaEngate Instance { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<DBLayers.DAL.Entidades.ProgramaEngate> List(int CodigoPrograma)
        {
            throw new NotImplementedException("Método não necessário");
        }
        public DBLayers.DAL.Entidades.ProgramaEngate SelectLast(int CodigoPrograma)
        {
            ProgramaEngatePL pl = null;
            try
            {
                pl = new ProgramaEngatePL();
                return pl.SP_CONSULTAR_ULTIMO_PROGRAMAENGATE();
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
        }
        public int Insert()
        {
            ProgramaEngatePL pl = null;
            try
            {
                pl = new ProgramaEngatePL();
                return pl.SP_SALVAR_PROGRAMAENGATE(this.Instance);
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
        public void Delete()
        {
            throw new NotImplementedException();
        }
        public bool IsNew()
        {
            return (this.Instance.Codigo == 0);
        }
        public static ProgramaEngate SelectNewInstance()
        {
            return new ProgramaEngate();
        }
        public void Select(int Codigo)
        {
            ProgramaEngatePL pl = null;
            try
            {
                pl = new ProgramaEngatePL();
                this.Instance = pl.SP_SELECIONAR_PROGRAMAENGATE(Codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
