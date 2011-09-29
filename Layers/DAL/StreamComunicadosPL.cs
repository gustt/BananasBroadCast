using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using References.DAL;

namespace DBLayers.DAL
{
    public class StreamComunicadosPL : IDisposable
    {
        public List<Entidades.StreamComunicados> SP_CONSULTAR_COMUNICADOS(string sessionid, DateTime timerequest)
        {
            Database db = null;
            List<Entidades.StreamComunicados> retorno = new List<Entidades.StreamComunicados>();
            Queue<SqlParameter> qParameters = null;
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                                    new Property() { NomeCampo = "sessionid", Value = sessionid },
                                    new Property() { NomeCampo = "timerequest", Value = timerequest }
                                    );
                retorno =
                    DAL.Mapping.Mapping<Entidades.StreamComunicados>.ConvertReaderToIEnumerable(
                        db.ExecuteDataReader("SP_CONSULTAR_COMUNICADOS", ref qParameters)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                    db.Dispose();
            }
            return retorno;
        }
        public int SP_SALVAR_COMUNICADO(Entidades.StreamComunicados entity)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                        new Property() { NomeCampo = "Mensagem", Value = entity.Mensagem },
                        new Property() { NomeCampo = "UserId", Value = entity.UserId },
                        new Property() { NomeCampo = "Codigo", Value = entity.Codigo });

                return db.ExecuteNonQuery("SP_SALVAR_COMUNICADO", ref qParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                    db.Dispose();
            }
        }
        public int CreateParameters(ref Queue<SqlParameter> qParameters, params Property[] Properties)
        {
            try
            {
                if (qParameters == null)
                    qParameters = new Queue<SqlParameter>();

                foreach (Property p in Properties)
                    qParameters.Enqueue(
                        new SqlParameter()
                        {
                            ParameterName = string.Concat("@", p.NomeCampo),
                            Value = p.Value
                        }
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return qParameters.Count;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
