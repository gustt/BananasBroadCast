using System;
namespace DBLayers.DAL.Entidades
{
    public class ProgramaEngate
    {
        #region Propriedades Publicas
        public int Codigo { get; set; }
        public int CodigoPrograma { get; set; }
        public string UserID { get; set; }
        public DateTime Data { get; set; }
        public int TipoEngate { get; set; }
        #endregion
    }
}
