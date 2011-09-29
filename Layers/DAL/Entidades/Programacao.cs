namespace DBLayers.DAL.Entidades
{
    public class Programacao
    {
        #region Propriedades Publicas
        public int Codigo { get; set; }
        public int CodigoPrograma { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        #endregion
    }
}
