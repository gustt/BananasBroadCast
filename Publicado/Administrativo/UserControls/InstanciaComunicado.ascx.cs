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
    public partial class InstanciaComunicado : References.Web.UI.UserControlBase,
        References.Web.Interfaces.IInstanciaUserControlBase
    {
        #region Propiedades
        public DBLayers.DAL.Entidades.StreamComunicados Instancia
        {
            get
            {
                DBLayers.DAL.Entidades.StreamComunicados instancia = new DBLayers.DAL.Entidades.StreamComunicados();
                instancia.Codigo = int.Parse(string.IsNullOrEmpty(txtCodigo.Text) ? "0" : txtCodigo.Text);
                instancia.UserId = this.UsuarioLogado.UserID;
                instancia.Mensagem = txtMensagem.Text;

                return instancia;
            }
            set
            {
                txtCodigo.Text = value.Codigo.ToString();
                txtMensagem.Text = value.Mensagem;
            }
        }
        #endregion
        #region Metodos
        public void FillUserControl(int CodigoStreamComunicado)
        {
            if (!IsPostBack)
            {
                DBLayers.BLL.Regras.StreamComunicados comunicado = new DBLayers.BLL.Regras.StreamComunicados();
                comunicado.Select(CodigoStreamComunicado);
                this.Instancia = comunicado.Instancia;
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
                DBLayers.BLL.Regras.StreamComunicados comunicado = new DBLayers.BLL.Regras.StreamComunicados();
                comunicado.Instancia = this.Instancia;
                this.Instancia.Codigo = comunicado.Insert();

                //por enquanto limpa tudo
                this.Instancia = new DBLayers.DAL.Entidades.StreamComunicados();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete()
        {
            //TODO: Implementar
        }
        public void Clear()
        {
            
        }
        #endregion
    }
}