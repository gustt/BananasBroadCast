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
    public partial class InstanciaPrograma : Bananas.Administrativo.UserControl.UserControlBase,
        References.Web.Interfaces.IInstanciaUserControlBase
    {
        #region Propiedades
        public int CodigoPrograma
        {
            get
            {
                if (ViewState["CodigoPrograma"] == null)
                    ViewState.Add("CodigoPrograma", 0);

                return int.Parse(ViewState["CodigoPrograma"].ToString());
            }
            set
            {
                if (ViewState["CodigoPrograma"] == null)
                    ViewState.Add("CodigoPrograma", value);
                else
                    ViewState["CodigoPrograma"] = value;
            }
        }
        public DBLayers.DAL.Entidades.Programa Instancia
        {
            get
            {

                DBLayers.DAL.Entidades.Programa instancia = new DBLayers.DAL.Entidades.Programa();

                instancia.Codigo = this.CodigoPrograma;
                instancia.NomePrograma = txtNomePrograma.Text;
                instancia.Descricao = txtDescricao.Text;
                instancia.Ativo = true;

                return instancia;
            }
            set
            {
                this.CodigoPrograma = value.Codigo;
                txtNomePrograma.Text =   value.NomePrograma;
                txtDescricao.Text = value.Descricao;

            }
        }
        #endregion
        #region Metodos
        public void FillUserControl(int CodigoPrograma)
        {
            if (!IsPostBack)
            {
                this.CodigoPrograma = CodigoPrograma;
                DBLayers.BLL.Regras.Programa programa = new DBLayers.BLL.Regras.Programa();
                programa.Select(CodigoPrograma);
                this.Instancia = programa.Instance;

                //Popula UserControl Programcao
                ucListaProgramcao.FillUserControl(this.CodigoPrograma);
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
                DBLayers.BLL.Regras.Programa programa = new DBLayers.BLL.Regras.Programa();
                programa.Instance = this.Instancia;
                this.CodigoPrograma = programa.Insert();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete()
        {

        }
        public void Clear()
        {

        }
        #endregion
    }
}