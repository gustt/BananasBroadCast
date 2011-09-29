using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using References.DAL;

namespace DBLayers.DAL
{
    public class ProgramacaoPL : IDisposable
    {
        #region Procedures
        public List<Entidades.Programacao> SP_CONSULTAR_PROGRAMACAO(int CodigoPrograma)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            List<Entidades.Programacao> retorno = new List<Entidades.Programacao>();
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                            new Property() { NomeCampo = "CodigoPrograma", Value = CodigoPrograma });

                retorno =
                    Mapping.Mapping<Entidades.Programacao>.ConvertReaderToIEnumerable(
                        db.ExecuteDataReader("SP_CONSULTAR_PROGRAMACAO", ref qParameters)).ToList();
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

        public void SP_DELETAR_PROGRAMACAO(int Codigo)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            DAL.Entidades.Programacao retorno = new Entidades.Programacao();
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                    new Property() { NomeCampo = "Codigo", Value = Codigo });

                db.ExecuteNonQuery("SP_DELETAR_PROGRAMACAO", ref qParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SP_SALVAR_PROGRAMACAO(Entidades.Programacao entidade)
        {
            int Codigo = 0;
            Queue<SqlParameter> qParameter = null;
            Database db = null;
            try
            {
                db = new Database();

                CreateParameters(ref qParameter,
                    new References.DAL.Property() { NomeCampo = "Codigo", Value = entidade.Codigo, Direction = ParameterDirection.Output },
                    new References.DAL.Property() { NomeCampo = "CodigoPrograma", Value = entidade.CodigoPrograma },
                    new References.DAL.Property() { NomeCampo = "Descricao", Value = entidade.Descricao },
                    new References.DAL.Property() { NomeCampo = "Titulo", Value = entidade.Titulo },
                    new References.DAL.Property() { NomeCampo = "Situacao", Value = entidade.Situacao }
                );

                Codigo = db.ExecuteNonQuery("[dbo].[SP_SALVAR_PROGRAMACAO]", ref qParameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (qParameter != null)
                    GC.SuppressFinalize(qParameter);
                if (db != null)
                    db.Dispose();
            }
            return Codigo;
        }
        public DAL.Entidades.Programacao SP_SELECIONAR_PROGRAMACAO(int Codigo)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            DAL.Entidades.Programacao retorno = new Entidades.Programacao();
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                    new Property() { NomeCampo = "Codigo", Value = Codigo });

                List<DAL.Entidades.Programacao> rMapping =
                    Mapping.Mapping<DAL.Entidades.Programacao>.ConvertReaderToIEnumerable(
                            db.ExecuteDataReader("SP_SELECIONAR_PROGRAMACAO", ref qParameters)).ToList();

                if (rMapping.ToList().Count > 0)
                    retorno = rMapping.ElementAt(0);
            }
            catch (Exception ex)
            {
                throw ex;
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
