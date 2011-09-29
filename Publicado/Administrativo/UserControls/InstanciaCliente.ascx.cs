using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayers.BLL;
using DBLayers.DAL;

namespace Bananas.Administrativo.UserControls
{
    public partial class InstanciaCliente : References.Web.UI.UserControlBase,
        References.Web.Interfaces.IInstanciaUserControlBase
    {
        #region Propiedades
        public int CodigoCliente
        {
            get
            {
                int codigocliente;
                if (!int.TryParse(txtCodigoCliente.Text, out codigocliente))
                    throw new Exception("Nao foi possivel converter CodigoClinte para INT");

                return codigocliente;
            }
            set
            {
                txtCodigoCliente.Text = value.ToString();
            }
        }
        public DBLayers.DAL.Entidades.Cliente Instancia
        {
            get
            {
                DBLayers.DAL.Entidades.Cliente instancia = new DBLayers.DAL.Entidades.Cliente();
                instancia.Codigo = this.CodigoCliente;
                instancia.RazaoSocial = txtRazaoSocial.Text;
                instancia.NomeFantasia = txtNomeFantasia.Text;
                instancia.Email = txtEmail.Text;
                instancia.CNPJ = txtCnpj.Text;
                instancia.Logradouro = txtLogradouro.Text;
                instancia.Bairro = txtBairro.Text;
                instancia.Complemento = txtComplemento.Text;
                instancia.Cidade = txtCidade.Text;
                instancia.UF = txtEstado.Text;
                instancia.Responsavel = txtResponsavel.Text;
                instancia.TelefoneEscritorio = txtTelefoneEscritorio.Text;
                instancia.TelefoneEstudio = txtTelefoneEstudio.Text;
                instancia.QtdeCidadesAlcance = int.Parse(txtAlcance.Text);
                instancia.Ativo = true;
                instancia.UserID = txtLogin.Text;
                instancia.Password = txtSenha.Text;
                return instancia;
            }
            set
            {
                if (value == null)
                    return;

                this.CodigoCliente = value.Codigo;
                txtRazaoSocial.Text = value.RazaoSocial;
                txtNomeFantasia.Text = value.NomeFantasia;
                txtEmail.Text = value.Email;
                txtCnpj.Text = value.CNPJ;
                txtLogradouro.Text = value.Logradouro;
                txtBairro.Text = value.Bairro;
                txtComplemento.Text = value.Complemento;
                txtCidade.Text = value.Cidade;
                txtEstado.Text = value.UF;
                txtResponsavel.Text = value.Responsavel;
                txtTelefoneEscritorio.Text = value.TelefoneEscritorio;
                txtTelefoneEstudio.Text = value.TelefoneEstudio;
                txtAlcance.Text = value.QtdeCidadesAlcance.ToString();

                if (!string.IsNullOrEmpty(value.UserID))
                {
                    DBLayers.BLL.Regras.Usuario rusr =
                        new DBLayers.BLL.Regras.Usuario();

                    DBLayers.DAL.Entidades.Usuario usr = rusr.Select(value.UserID).Instance;

                    txtLogin.Text = usr.UserID;
                }
            }
        }
        #endregion
        #region Eventos
        protected void cvLogin_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            //Valida se usuario existe
            DBLayers.BLL.Regras.Usuario usuario = new DBLayers.BLL.Regras.Usuario();
            usuario.Select(this.Instancia.UserID);

            e.IsValid = (usuario.Instance == null);
        }
        #endregion
        #region Metodos
        public void FillUserControl(int CodigoCliente)
        {
            if (!IsPostBack)
            {
                this.CodigoCliente = CodigoCliente;
                DBLayers.BLL.Regras.Cliente cliente = new DBLayers.BLL.Regras.Cliente();
                cliente.Select(CodigoCliente);
                this.Instancia = cliente.Instance;
            }
        }
        public void FillUserControl()
        {
            this.FillUserControl(0);
        }
        public void Save()
        {
            try
            {
                DBLayers.BLL.Regras.Cliente cliente = new DBLayers.BLL.Regras.Cliente();
                cliente.Instance = this.Instancia;
                this.CodigoCliente = cliente.Insert();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete()
        {
            try
            {
                DBLayers.BLL.Regras.Cliente cliente = new DBLayers.BLL.Regras.Cliente();
                cliente.Instance = this.Instancia;
                cliente.Delete();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Clear()
        {

        }
        #endregion
    }
}