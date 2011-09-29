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
    public partial class InstanciaProgramaEngate : Bananas.Administrativo.UserControl.UserControlBase,
        References.Web.Interfaces.IInstanciaUserControlBase
    {
        #region Propiedades
        public DBLayers.DAL.Entidades.ProgramaEngate Instancia
        {
            get
            {
                DBLayers.DAL.Entidades.ProgramaEngate instancia = new DBLayers.DAL.Entidades.ProgramaEngate();
                instancia.CodigoPrograma = 1;

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
        public void FillUserControl(int Codigo)
        {
            if (!IsPostBack)
            {
                DBLayers.BLL.Regras.ProgramaEngate programaengate = new DBLayers.BLL.Regras.ProgramaEngate();
                programaengate.Select(Codigo);
                this.Instancia = programaengate.Instance;
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