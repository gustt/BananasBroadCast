var containerUsuarios;

var oUsuario = function () {
    var UserId;
    var NomeUsuario;
    var TipoPerfil;
};

var setContainerUsuarios = function (_container) {
    try {
        containerUsuarios = _container;
    } catch (e) {
        alert(e);
    }
};

var validateUsuarios = function (value) {
    if (value != null && value != undefined) {
        var xmlDoc = new ActiveXObject("Msxml2.DOMDocument.3.0");
        xmlDoc.loadXML(value);

        if (containerUsuarios != null)
            containerUsuarios.innerHTML = "";


        for (var i = 0; i < xmlDoc.childNodes.length; i++) {
            if (xmlDoc.childNodes[i].nodeType != 1)
                continue;

            for (var ii = 0; ii < xmlDoc.childNodes[i].childNodes.length; ii++) {
                if (xmlDoc.childNodes[i].childNodes[ii].nodeType != 1)
                    continue;

                for (var a = 0; a < xmlDoc.childNodes[i].childNodes[ii].attributes.length; a++) {
                    if (xmlDoc.childNodes[i].childNodes[ii].attributes[a].name == "userid")
                        oUsuario.UserId = xmlDoc.childNodes[i].childNodes[ii].attributes[a].value;

                    if (xmlDoc.childNodes[i].childNodes[ii].attributes[a].name == "nomeusuario")
                        oUsuario.NomeUsuario = xmlDoc.childNodes[i].childNodes[ii].attributes[a].value;

                    if (xmlDoc.childNodes[i].childNodes[ii].attributes[a].name == "tipoperfil")
                        oUsuario.TipoPerfil = xmlDoc.childNodes[i].childNodes[ii].attributes[a].value;
                }

                //add usuario no container
                addUsuarioContainer(oUsuario);
            }
        }
    }
};

var addUsuarioContainer = function (usr) {
    try {
        if (containerUsuarios != null)
            containerUsuarios.innerHTML += "<li>" + usr.NomeUsuario + "</li>";
    } catch (e) {
        alert(e);
    }
};

var syncUsuariosAtivos = function () {
    try {
        var currentDate = new Date(); //tempo do cliente, usado apenas para que não retorne cache da parte do servidor
        var querystring = "timerequest=" + currentDate;
        var oAjax_Usuarios = createAjax();
        oAjax_Usuarios.OpenGet("./Service/service_usuariosativos.aspx", querystring, validateUsuarios);

        setTimeout("syncUsuariosAtivos()", 20000);
    } catch (e) {
        alert(e);
    }
};