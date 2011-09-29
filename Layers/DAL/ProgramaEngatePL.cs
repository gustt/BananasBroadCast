using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using References.DAL;

namespace DBLayers.DAL
{
    public class ProgramaEngatePL : IDisposable
    {
        #region Procedures
        public Entidades.ProgramaEngate SP_CONSULTAR_ULTIMO_PROGRAMAENGATE()
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            Entidades.ProgramaEngate retorno = new Entidades.ProgramaEngate();
            try
            {
                db = new Database();

                qParameters = new Queue<SqlParameter>();

                List<Entidades.ProgramaEngate> retornoproceudre = Mapping.Mapping<DAL.Entidades.ProgramaEngate>.ConvertReaderToIEnumerable(
                                    db.ExecuteDataReader("SP_CONSULTAR_ULTIMO_PROGRAMAENGATE", ref qParameters)).ToList();

                if (retornoproceudre != null && retornoproceudre.Count > 0)
                    retorno = retornoproceudre.ElementAt(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                    db.Dispose();

                if (qParameters != null)
                {
                    GC.SuppressFinalize(qParameters);
                    qParameters = null;
                }
            }

            return retorno;
        }
        public int SP_SALVAR_PROGRAMAENGATE(Entidades.ProgramaEngate entidade)
        {
            int Codigo = 0;
            Queue<SqlParameter> qParameters = null;
            Database db = null;
            try
            {
                db = new Database();
                CreateParameters(ref qParameters,
                        new Property() { NomeCampo = "CodigoPrograma", Value = entidade.CodigoPrograma },
                        new Property() { NomeCampo = "Data", Value = entidade.Data },
                        new Property() { NomeCampo = "TipoEngate", Value = entidade.TipoEngate },
                       new Property() { NomeCampo = "UserID", Value = entidade.UserID }
                    );

                Codigo = db.ExecuteNonQuery("SP_SALVAR_PROGRAMAENGATE", ref qParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (qParameters != null)
                    GC.SuppressFinalize(qParameters);
                if (db != null)
                    db.Dispose();
            }
            return Codigo;
        }
        public Entidades.ProgramaEngate SP_SELECIONAR_PROGRAMAENGATE(int Codigo)
        {
            Queue<SqlParameter> qParameters = null;
            Database db = null;
            Entidades.ProgramaEngate retorno = null;
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                    new Property() { NomeCampo = "Codigo", Value = Codigo });

                List<Entidades.ProgramaEngate> retornoprocedure = 
                    DAL.Mapping.Mapping<Entidades.ProgramaEngate>.ConvertReaderToIEnumerable(
                        db.ExecuteDataReader("SP_SELECIONAR_PROGRAMAENGATE", ref qParameters)).ToList();

                if (retornoprocedure != null && retornoprocedure.Count > 0)
                    retorno = retornoprocedure.ElementAt(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (qParameters != null)
                    GC.SuppressFinalize(qParameters);
                if (db != null)
                    db.Dispose();
            }
            return retorno;
        }
        #endregion
        #region Parameters
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
        #endregion
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
