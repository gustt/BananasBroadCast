using System;
using System.Collections.Generic;
using System.Text;
using DBLayers.DAL;
using DBLayers.BLL.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DBLayers.DAL.Entidades
{
    public class Programa
    {
        #region Propriedades Publicas
        public int Codigo { get; set; }
        public string NomePrograma { get; set; }
        public string Descricao { get; set; }
        public byte[] Arquivo { get; set; }
        public string NomeArquivo { get; set; }
        public bool Ativo { get; set; }
        #endregion
    }
}
