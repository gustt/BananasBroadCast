using System;
using System.Collections.Generic;
using System.Text;
using DBLayers.DAL;
using DBLayers.BLL.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DBLayers.BLL.Regras
{
    public class StreamComunicados : IDataRecordDBLayers, IDisposable
    {
        public DAL.Entidades.StreamComunicados Instancia { get; set; }
        public List<DAL.Entidades.StreamComunicados> List(string sessionid, DateTime timerequest)
        {
            StreamComunicadosPL pl = null;
            try
            {
                pl = new StreamComunicadosPL();
                return pl.SP_CONSULTAR_COMUNICADOS(sessionid, timerequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(pl != null)
                    pl.Dispose();
            }
        }
        public int Insert()
        {
            StreamComunicadosPL pl = null;
            try
            {
                pl = new StreamComunicadosPL();
                return pl.SP_SALVAR_COMUNICADO(this.Instancia);
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
        public int Update()
        {
            throw new NotImplementedException();
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }
        public void Select(int Codigo)
        {
            //TODO: IMPLEMENTAR O SELECT DA ENTIDADE
            this.Instancia = new DAL.Entidades.StreamComunicados();
        }
        public bool IsNew()
        {
            throw new NotImplementedException();
        }
        public static DAL.Entidades.StreamComunicados SelectNewInstance()
        {
            return new DAL.Entidades.StreamComunicados();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
