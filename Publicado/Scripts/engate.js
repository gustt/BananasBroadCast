var contador;
var legenda;

var setLegenda = function (_control) {
    try {
        legenda = _control;
    } catch (e) {
        alert(e);
    }
};

var setContador = function (_control) {
    try {
        contador = _control;
    } catch (e) {
        alert(e);
    }
};


var checkEng = function () {
    try {
        var currentDate = new Date();
        var querystring = "timerequest=" + currentDate;
        var oAjax_Engate = createAjax();
        oAjax_Engate.OpenGet("./Service/service_engate.aspx", querystring, validaEngate);

        setTimeout("checkEng()", "8000");
    } catch (e) {
        alert(e);
    }
};

var validaEngate = function (value) {
    try {
        if (value != null && value != undefined) {
            var xmlDoc = new ActiveXObject("Msxml2.DOMDocument.3.0");
            xmlDoc.loadXML(value);

            var isEngate = false;
            var isEnabled = false;
            var H;
            var M;
            var S;

            for (var i = 0; i < xmlDoc.childNodes.length; i++) {
                if (xmlDoc.childNodes[i].nodeType == 1) {
                    for (var ii = 0; ii < xmlDoc.childNodes[i].childNodes.length; ii++) {
                        for (var a = 0; a < xmlDoc.childNodes[i].childNodes[ii].attributes.length; a++) {
                            //Verificar se é engate
                            if (xmlDoc.childNodes[i].childNodes[ii].attributes[a].name == 'type' &&
                                    xmlDoc.childNodes[i].childNodes[ii].attributes[a].value == 'engate')
                                isEngate = true;
                            //Se é pra ativar o engate
                            if (xmlDoc.childNodes[i].childNodes[ii].attributes[a].name == 'enabled' &&
                                    xmlDoc.childNodes[i].childNodes[ii].attributes[a].value == 'True')
                                isEnabled = true;
                            //se o engate esta ativo busca horario de engate
                            if (isEnabled) {
                                if (xmlDoc.childNodes[i].childNodes[ii].attributes[a].name == 'h')
                                    H = xmlDoc.childNodes[i].childNodes[ii].attributes[a].value;
                                if (xmlDoc.childNodes[i].childNodes[ii].attributes[a].name == 'm')
                                    M = xmlDoc.childNodes[i].childNodes[ii].attributes[a].value;
                                if (xmlDoc.childNodes[i].childNodes[ii].attributes[a].name == 's')
                                    S = xmlDoc.childNodes[i].childNodes[ii].attributes[a].value;
                            }
                        }
                    }
                }
            }
        }
        //após termino de recuperacao de dados do XML chama ativa ou nao engate
        if (isEnabled) {
            legenda.innerHTML =
                (isEngate ? "Engate" : "Desengate") + " (seg)";
            if (isEngate)
                ativaEngate(H, M, S);
            else if (!isEngate && isEnabled)
                ativaDesengate(H, M, S);
        }
    } catch (e) {
        alert(e);
    }
};

var ativaDesengate = function (H, M, S) {
    try {
        if (contador.innerHTML.indexOf('FORA', 0) > -1) {
            if (legenda.innerHTML.indexOf('Situação', 0) == -1)
                legenda.innerHTML = "Situação:"
            return;
        }

        var current = new Date();
        var target = new Date();
        current.setHours(oRelogio.Hora, oRelogio.Minuto, oRelogio.Segundo, 0);
        target.setHours(H, M, S, 0);

        var secondsDifference = Math.floor((target.getTime() - current.getTime()) / 1000);
        contador.innerHTML = "<span style='color: Red;'>" + secondsDifference + "</span>";

        if (secondsDifference <= 0) {
            legenda.innerHTML = "Situação:"
            contador.innerHTML = "<span style='color: Red;'>FORA</span>";

            //Limpa programacao
            clearPrograma();
        }
        else
            setTimeout("ativaDesengate('" + H + "', '" + M + "', '" + S + "')", 1000);
    } catch (e) {
        alert(e);
    }
};

var ativaEngate = function (H, M, S) {
    try {
        if (contador.innerHTML.indexOf('NO AR', 0) > -1) {
            if (legenda.innerHTML.indexOf('NO AR', 0) == -1)
                legenda.innerHTML = "Situação:";
            return;
        }
        var current = new Date();
        var target = new Date();
        current.setHours(oRelogio.Hora, oRelogio.Minuto, oRelogio.Segundo, 0);
        target.setHours(H, M, S, 0)

        var secondsDifference = Math.floor((target.getTime() - current.getTime()) / 1000);

        contador.innerHTML = "<span style='color: Green;'>" + secondsDifference + "</span>";
        if (secondsDifference <= 0) {
            legenda.innerHTML = "Situação:";
            contador.innerHTML = "<span style='color: Green;'>NO AR</span>";

            //Chama o programa engatado
            checkProgramaEngatado();
        }
        else
            setTimeout("ativaEngate('" + H + "', '" + M + "', '" + S + "')", 1000);
    } catch (e) {
        alert(e);
    }
};