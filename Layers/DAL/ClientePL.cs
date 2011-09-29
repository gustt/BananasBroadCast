using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using References.DAL;

namespace DBLayers.DAL
{
    public class ClientePL : IDisposable
    {
        public List<DAL.Entidades.Cliente> SP_CONSULTAR_CLIENTE(string NomeFantasia, string RazaoSocial)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            List<DAL.Entidades.Cliente> retorno = new List<Entidades.Cliente>();
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                            new Property() { NomeCampo = "NomeFantasia", Value = NomeFantasia },
                            new Property() { NomeCampo = "RazaoSocial", Value = RazaoSocial });

                retorno = Mapping.Mapping<DAL.Entidades.Cliente>.ConvertReaderToIEnumerable(
                                                        db.ExecuteDataReader("SP_CONSULTAR_CLIENTE", ref qParameters)).ToList();
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
        public DAL.Entidades.Cliente SP_SELECIONAR_CLIENTE(int Codigo)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            DAL.Entidades.Cliente retorno = new Entidades.Cliente();
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                    new Property() { NomeCampo = "Codigo", Value = Codigo });

                List<DAL.Entidades.Cliente> rMapping =
                    Mapping.Mapping<DAL.Entidades.Cliente>.ConvertReaderToIEnumerable(
                            db.ExecuteDataReader("SP_SELECIONAR_CLIENTE", ref qParameters)).ToList();

                if (rMapping.Count > 0)
                    retorno = rMapping.ElementAt(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }
        public void SP_DELETAR_CLIENTE(int Codigo)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            DAL.Entidades.Cliente retorno = new Entidades.Cliente();
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                    new Property() { NomeCampo = "Codigo", Value = Codigo });

                db.ExecuteNonQuery("SP_DELETAR_CLIENTE", ref qParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SP_SALVAR_CLIENTE(Entidades.Cliente entidade)
        {
            int Codigo = 0;
            Queue<SqlParameter> qParameter = null;
            Database db = null;
            try
            {
                db = new Database();


                using(References.Security.Crypt crp = new References.Security.Crypt())
                {
                    entidade.Password = crp.Codificar(entidade.Password);
                };

                CreateParameters(ref qParameter,
                    new References.DAL.Property() { NomeCampo = "Codigo", Value = entidade.Codigo, Direction = ParameterDirection.Output },
                    new References.DAL.Property() { NomeCampo = "RazaoSocial", Value = entidade.RazaoSocial },
                    new References.DAL.Property() { NomeCampo = "NomeFantasia", Value = entidade.NomeFantasia },
                    new References.DAL.Property() { NomeCampo = "CNPJ", Value = entidade.CNPJ },
                    new References.DAL.Property() { NomeCampo = "Email", Value = entidade.Email },
                    new References.DAL.Property() { NomeCampo = "Logradouro", Value = entidade.Logradouro },
                    new References.DAL.Property() { NomeCampo = "Cidade", Value = entidade.Cidade },
                    new References.DAL.Property() { NomeCampo = "Complemento", Value = entidade.Complemento },
                    new References.DAL.Property() { NomeCampo = "Bairro", Value = entidade.Bairro },
                    new References.DAL.Property() { NomeCampo = "UF", Value = entidade.UF },
                    new References.DAL.Property() { NomeCampo = "Responsavel", Value = entidade.Responsavel },
                    new References.DAL.Property() { NomeCampo = "TelefoneEstudio", Value = entidade.TelefoneEstudio },
                    new References.DAL.Property() { NomeCampo = "TelefoneEscritorio", Value = entidade.TelefoneEscritorio },
                    new References.DAL.Property() { NomeCampo = "QtdeCidadesAlcance", Value = entidade.QtdeCidadesAlcance },
                    new References.DAL.Property() { NomeCampo = "Ativo", Value = entidade.Ativo },
                    new References.DAL.Property() { NomeCampo = "UserID", Value = entidade.UserID },
                    new References.DAL.Property() { NomeCampo = "Password", Value = entidade.Password }
                );

                Codigo = db.ExecuteNonQuery("[dbo].[SP_SALVAR_CLIENTE]", ref qParameter);
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
