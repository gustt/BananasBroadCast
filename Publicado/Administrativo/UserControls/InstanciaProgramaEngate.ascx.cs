using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayers.BLL;
using DBLayers.DAL;
using References.Common;
using References.Web.UI;

namespace Bananas.Administrativo.UserControls
{
    public partial class InstanciaProgramaEngate : References.Web.UI.UserControlBase,
        References.Web.Interfaces.IInstanciaUserControlBase
    {
        #region Propiedades
        public DBLayers.DAL.Entidades.ProgramaEngate Instancia
        {
            get
            {
                DBLayers.DAL.Entidades.ProgramaEngate instancia = new DBLayers.DAL.Entidades.ProgramaEngate();
                instancia.CodigoPrograma = ddlProgramas.SelectedValue.ToInt();

                instancia.UserID = this.UsuarioLogado.UserID;

                if (rblTipoEngate.SelectedIndex > -1)
                    instancia.TipoEngate = int.Parse(rblTipoEngate.SelectedValue);

                DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                    int.Parse(txtHora.Text), int.Parse(txtMinuto.Text), int.Parse(txtSegundo.Text));

                instancia.Data = now;

                return instancia;
            }
            set
            {

            }
        }
        #endregion
        #region Metodos
        public void FillUserControl()
        {
            BuscarProgramas();
        }
        protected void BuscarProgramas()
        {
            try
            {
                if (ddlProgramas.Items.Count > 0)
                    return;

                DBLayers.BLL.Regras.Programa rProg = new DBLayers.BLL.Regras.Programa();
                ddlProgramas.DataSource = rProg.List();
                ddlProgramas.DataTextField = "NomePrograma";
                ddlProgramas.DataValueField = "Codigo";
                ddlProgramas.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Save()
        {
            try
            {
                DBLayers.BLL.Regras.ProgramaEngate programaengate = new DBLayers.BLL.Regras.ProgramaEngate();
                programaengate.Instance = this.Instancia;
                programaengate.Insert();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete()
        {
            //try
            //{
            //    this.CodigoCliente = CodigoCliente;
            //    DBLayers.BLL.Regras.Cliente cliente = new DBLayers.BLL.Regras.Cliente();
            //    cliente.Delete(Codigo: CodigoCliente);

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        public void Clear()
        {

        }
        #endregion
    }
}