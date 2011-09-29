using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayers.BLL;

namespace Bananas.Administrativo.UserControls
{
    public partial class InstanciaAdministrador :
        Bananas.Administrativo.UserControl.UserControlBase,
        References.Web.Interfaces.IInstanciaUserControlBase
    {
        #region Propiedades 
        public string UserID
        {
            get
            {
                string userID;
                userID = txtNomeAdmin.Text.ToString(); ;
                return userID;
            }
            set
            {
                txtNomeAdmin.Text = value.ToString();
            }
        }
        public DBLayers.DAL.Entidades.Administrador Instancia
        {
            get
            {
                DBLayers.DAL.Entidades.Administrador instancia = new DBLayers.DAL.Entidades.Administrador();
                instancia.Password = txtSenha.Text;
                instancia.Situacao = true;
                instancia.UserID = this.UserID;
                instancia.TipoPerfil = 0;
                return instancia;
            }
            set
            {
            }
        }
        #endregion
        #region Metodos
        public void FillUserControl(string UserID)
        {
            if (!IsPostBack)
            {
                this.UserID = UserID;
                DBLayers.BLL.Regras.Administrador administrador = new DBLayers.BLL.Regras.Administrador();
                administrador.Select(UserID);
                this.Instancia = administrador.Instance;
            }
        }
        public void FillUserControl()
        {
            this.FillUserControl(string.Empty);
        }
        public void Save()
        {
            try
            {
                DBLayers.BLL.Regras.Administrador administrador = new DBLayers.BLL.Regras.Administrador();
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
                DBLayers.BLL.Regras.Administrador administrador = new DBLayers.BLL.Regras.Administrador();
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