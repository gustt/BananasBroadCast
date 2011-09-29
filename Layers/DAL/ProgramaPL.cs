using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using References.DAL;

namespace DBLayers.DAL
{
    public class ProgramaPL : IDisposable
    {
        #region Procedures
        public DAL.Entidades.Programa SP_ABRIR_PROGRAMA_ENGATADO()
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            Entidades.Programa retorno = new Entidades.Programa();
            try
            {
                db = new Database();

                List<Entidades.Programa> rProcedure =
                    Mapping.Mapping<Entidades.Programa>.ConvertReaderToIEnumerable(
                        db.ExecuteDataReader("SP_ABRIR_PROGRAMA_ENGATADO")).ToList();

                if (rProcedure != null && rProcedure.Count > 0)
                    retorno = rProcedure.ElementAt(0);
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
        public List<Entidades.Programa> SP_CONSULTAR_PROGRAMA(string NomePrograma)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            List<Entidades.Programa> retorno = new List<Entidades.Programa>();
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                            new Property() { NomeCampo = "NomePrograma", Value = NomePrograma });

                retorno =
                    Mapping.Mapping<Entidades.Programa>.ConvertReaderToIEnumerable(
                        db.ExecuteDataReader("SP_CONSULTAR_PROGRAMA", ref qParameters)).ToList();
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
        public int SP_SALVAR_PROGRAMA(Entidades.Programa entidade)
        {
            int Codigo = 0;
            Queue<SqlParameter> qParameter = null;
            Database db = null;
            try
            {
                db = new Database();

                CreateParameters(ref qParameter,
                    new References.DAL.Property() { NomeCampo = "Codigo", Value = entidade.Codigo, Direction = ParameterDirection.Output },
                    new References.DAL.Property() { NomeCampo = "NomePrograma", Value = entidade.NomePrograma },
                    new References.DAL.Property() { NomeCampo = "Descricao", Value = entidade.Descricao },
                    new References.DAL.Property() { NomeCampo = "Arquivo", Value = entidade.Arquivo },
                    new References.DAL.Property() { NomeCampo = "NomeArquivo", Value = entidade.NomeArquivo },
                    new References.DAL.Property() { NomeCampo = "Ativo", Value = entidade.Ativo }
                );

                Codigo = db.ExecuteNonQuery("[dbo].[SP_SALVAR_PROGRAMA]", ref qParameter);
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
        public void SP_DELETAR_PROGRAMA(int Codigo)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            DAL.Entidades.Programa retorno = new Entidades.Programa();
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                    new Property() { NomeCampo = "Codigo", Value = Codigo });

                db.ExecuteNonQuery("SP_DELETAR_PROGRAMA", ref qParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DAL.Entidades.Programa SP_SELECIONAR_PROGRAMA(int Codigo)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            DAL.Entidades.Programa retorno = null;
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                    new Property() { NomeCampo = "Codigo", Value = Codigo });

                List<DAL.Entidades.Programa> rMapping =
                    Mapping.Mapping<DAL.Entidades.Programa>.ConvertReaderToIEnumerable(
                            db.ExecuteDataReader("SP_SELECIONAR_PROGRAMA", ref qParameters)).ToList();

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
