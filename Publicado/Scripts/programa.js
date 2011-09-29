var containerPrograma;
var containerProgramacao;

var setContainerPrograma = function (_control) {
    try {
        containerPrograma = _control;
    } catch (e) {
        alert(e);
    }
};

var setContainerProgramacao = function (_control) {
    try {
        containerProgramacao = _control;
    } catch (e) {
        alert(e);
    }
};

var rProgramaEndatado = function () {
    var NomePrograma;
    var CaminhoImagem;
};

var checkProgramaEngatado = function () {
    try {
        var currentDate = new Date();
        var querystring = "timerequest=" + currentDate;
        var oAjax_Progama = createAjax();
        oAjax_Progama.OpenGet("./Service/service_programa.aspx", querystring, preparaXml);

    } catch (e) {
        alert(e);
    }
};

var preparaXml = function (value) {
    try {
        if (value != null && value != undefined) {
            var xmlDoc = new ActiveXObject("Msxml2.DOMDocument.3.0");
            xmlDoc.loadXML(value);

            //limpa containers
            if (containerProgramacao != null)
                containerProgramacao.innerHTML = '';
            if (containerPrograma != null)
                containerPrograma.innerHTML = '';

            for (var i = 0; i < xmlDoc.childNodes.length; i++) {
                if (xmlDoc.childNodes[i].nodeType == 1) {

                    for (var aroot = 0; aroot < xmlDoc.childNodes[i].attributes.length; aroot++) {
                        if (xmlDoc.childNodes[i].attributes[aroot].name == 'nome')
                            rProgramaEndatado.NomePrograma = xmlDoc.childNodes[i].attributes[aroot].value;
                        if (xmlDoc.childNodes[i].attributes[aroot].name == 'img')
                            rProgramaEndatado.CaminhoImagem = xmlDoc.childNodes[i].attributes[aroot].value;
                    }

                    var titulo;

                    for (var ci = 0; ci < xmlDoc.childNodes[i].childNodes.length; ci++) {
                        //att
                        if (xmlDoc.childNodes[i].childNodes[ci].nodeType == 1) {
                            for (var ac = 0; ac < xmlDoc.childNodes[i].childNodes[ci].attributes.length; ac++) {
                                if (xmlDoc.childNodes[i].childNodes[ci].attributes[ac].name == 'titulo')
                                    titulo = xmlDoc.childNodes[i].childNodes[ci].attributes[ac].value;
                            }
                        }

                        //adiciona programacao na tela
                        addProgramacao(titulo, xmlDoc.childNodes[i].childNodes[ci].text);
                    }
                }
            }
        }

        //Seta o programa
        setPrograma();
    } catch (e) {
        alert(e);
    }
};

var addProgramacao = function (titulo, descricao) {
    if (containerProgramacao != null) {
        containerProgramacao.innerHTML = containerProgramacao.innerHTML + "<li>" + titulo + ": " + descricao + "</li>";
    }
};

var setPrograma = function () {
    if (containerPrograma != null)
        containerPrograma.innerHTML = "<img src=\"" + rProgramaEndatado.CaminhoImagem  + "\" alt=\"" + rProgramaEndatado.NomePrograma + "\" style=\"width: 200px;height: 120px;\" />";
};

var clearPrograma = function () {
    if (containerPrograma != null)
        containerPrograma.innerHTML = '';
    if (containerProgramacao != null)
        containerProgramacao.innerHTML = '';
};