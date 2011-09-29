using System;
using System.Collections.Generic;
using System.Text;
using DBLayers.DAL;
using DBLayers.BLL.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DBLayers.DAL.Entidades
{
    public class StreamComunicados
    {
        #region Propriedades publicas
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataPostagem { get; set; }
        public string UserId { get; set; }
        #endregion
    }
}