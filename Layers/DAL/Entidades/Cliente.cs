﻿using System;
using System.Collections.Generic;
using System.Text;
using DBLayers.DAL;
using DBLayers.BLL.Interfaces;
using System.Data;
using System.Data.SqlClient;
using DBLayers.DAL.Mapping.Attributes;

namespace DBLayers.DAL.Entidades
{
    public class Cliente
    {
        #region Propriedades Publicas
        public int Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Responsavel { get; set; }
        public string TelefoneEstudio { get; set; }
        public int QtdeCidadesAlcance { get; set; }
        public string TelefoneEscritorio { get; set; }
        public bool Ativo { get; set; }
        [CustomMapper(false, true)]
        public string UserID { get; set; }
        [CustomMapper(false, true)]
        public string Password { get; set; }
        #endregion
    }
}
