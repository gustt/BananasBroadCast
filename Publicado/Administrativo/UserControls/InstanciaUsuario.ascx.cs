using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayers.BLL;

namespace Bananas.Administrativo.UserControls
{
    public partial class InstanciaUsuario :
        References.Web.UI.UserControlBase,
        References.Web.Interfaces.IInstanciaUserControlBase
    {
        #region Eventos
        protected void cvLogin_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            //Valida se usuario existe
            DBLayers.BLL.Regras.Usuario usuario = new DBLayers.BLL.Regras.Usuario();
            usuario.Select(this.Instancia.UserID);

            e.IsValid = (usuario.Instance == null);
        }
        #endregion
        #region Propiedades
        public int TipoPerfil
        {
            get
            {
                if (ViewState["TipoPefil"] == null)
                    ViewState.Add("TipoPefil", 0);

                return int.Parse(ViewState["TipoPefil"].ToString());
            }
            set
            {
                ViewState["TipoPefil"] = value;
            }
        }
        public string UserID
        {
            get
            {
                return txtLogin.Text;
            }
            set
            {
                txtLogin.Text = value;
            }
        }
        public DBLayers.DAL.Entidades.Usuario Instancia
        {
            get
            {
                DBLayers.DAL.Entidades.Usuario instancia = new DBLayers.DAL.Entidades.Usuario();
                instancia.Password = txtSenha.Text;
                instancia.Situacao = true;
                instancia.NomeAdministrador = this.txtNomeAdmin.Text;
                instancia.UserID = this.UserID;
                instancia.TipoPerfil = this.TipoPerfil; //Default 0 : Usuario
                return instancia;
            }
            set
            {
                if (value == null)
                    return;

                txtNomeAdmin.Text = value.NomeAdministrador;
                txtLogin.Text = value.UserID;
            }
        }
        #endregion
        #region Metodos
        public void FillUserControl(string UserID)
        {
            if (!IsPostBack)
            {
                this.UserID = UserID;
                DBLayers.BLL.Regras.Usuario administrador = new DBLayers.BLL.Regras.Usuario();
                administrador.Select(UserID);
                this.Instancia = administrador.Instance;

                //Não permite edicao do login
                txtLogin.Enabled = false;
            }
        }
        public void FillUserControl()
        {
            //Nao ha nada pra se carregar
        }
        public void Save()
        {
            try
            {
               DBLayers.BLL.Regras.Usuario administrador = new DBLayers.BLL.Regras.Usuario();
               administrador.Instance = this.Instancia;
               this.UserID = administrador.Insert().ToString();

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
                DBLayers.BLL.Regras.Usuario administrador = new DBLayers.BLL.Regras.Usuario();
                administrador.Instance = this.Instancia;
                administrador.Delete();
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