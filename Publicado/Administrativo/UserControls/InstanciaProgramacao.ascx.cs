﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayers.BLL;
using DBLayers.DAL;

namespace Bananas.Administrativo.UserControls
{
    public partial class InstanciaProgramacao : References.Web.UI.UserControlBase,
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
        public int CodigoProgramacao
        {
            get
            {
                if (ViewState["CodigoProgramacao"] == null)
                    ViewState.Add("CodigoProgramacao", 0);

                return int.Parse(ViewState["CodigoProgramacao"].ToString());
            }
            set
            {
                if (ViewState["CodigoProgramacao"] == null)
                    ViewState.Add("CodigoProgramacao", value);
                else
                    ViewState["CodigoProgramacao"] = value;
            }
        }
        public DBLayers.DAL.Entidades.Programacao Instancia
        {
            get
            {

                DBLayers.DAL.Entidades.Programacao instancia = new DBLayers.DAL.Entidades.Programacao();

                instancia.Codigo = this.CodigoProgramacao;
                instancia.CodigoPrograma = this.CodigoPrograma;
                instancia.Titulo = txtTitulo.Text;
                instancia.Descricao = txtDescricao.Text;
                instancia.Situacao = true;

                return instancia;
            }
            set
            {
                this.CodigoPrograma = value.CodigoPrograma;
                this.CodigoProgramacao = value.Codigo;
                txtTitulo.Text = value.Titulo;
                txtDescricao.Text = value.Descricao;
                
            }
        }
        #endregion
        #region Metodos
        public void FillUserControl(int Codigo)
        {
            if (!IsPostBack)
            {
                this.CodigoProgramacao = Codigo;
                DBLayers.BLL.Regras.Programacao programacao = new DBLayers.BLL.Regras.Programacao();
                programacao.Select(Codigo);
                this.Instancia = programacao.Instance;
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
                DBLayers.BLL.Regras.Programacao programacao = new DBLayers.BLL.Regras.Programacao();
                programacao.Instance = this.Instancia;
                this.CodigoProgramacao = programacao.Insert();
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
                DBLayers.BLL.Regras.Programacao programacao = new DBLayers.BLL.Regras.Programacao();
                programacao.Instance = this.Instancia;
                programacao.Delete();
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