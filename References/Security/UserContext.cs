using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using References.Common;

namespace References.Security
{
    public class UserContext
    {
        #region Propriedades
        public string NomeUsuario { get; set; }
        public string UserID { get; set; }
        public Enumerations.TipoPerfil TipoPerfil { get; set; }
        public string NomeComputador { get; set; }
        #endregion
        #region Create
        public UserContext(string _nomeusuario, string _userid, Enumerations.TipoPerfil _tipoPerfil, string _computador)
        {
            this.NomeUsuario = _nomeusuario;
            this.UserID = _userid;
            this.TipoPerfil = _tipoPerfil;
            this.NomeComputador = _computador;
        }
        public UserContext()
        {
            NomeUsuario = UserID = null;
            TipoPerfil = Enumerations.TipoPerfil.NaoDefinido;
        }
        #endregion
    }
}
