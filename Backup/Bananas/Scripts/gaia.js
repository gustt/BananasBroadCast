var transcAjax;
var contador;
var legenda;
var play;

var setPlay = function (_control) {
    try {
        play = _control;
    } catch (e) {
        alert(e);
    }
};

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

var startSys = function () {
    try {
        legenda.innerHTML = "Nenhum engate programado.";

        //Instancia obj ajax
        transcAjax = window.XMLHttpRequest ? new window.XMLHttpRequest() : new window.ActiveXObject('Microsoft.XMLHTTP');

        if (transcAjax != null) {
            //prototipa objeto ajax
            transcAjax.OpenGet = function (_url, _querystring, _onloadcomplete) {
                try {
                    this.onloadcomplete = _onloadcomplete;
                    if (!transcAjax.isSuspenso) {
                        if (_querystring != null && _querystring != undefined)
                            this.open("GET", _url + "?" + _querystring, true);
                        else
                            this.open("GET", _url + "?" + _querystring, true);

                        this.send(null);
                    }
                } catch (e) {
                    alert(e);
                }
            };
            transcAjax.isSuspenso = false;
            transcAjax.isNoAr = false;
            transcAjax.onreadystatechange = _my_onreadystatechange;
        }
    } catch (e) {
        alert(e);
    }
};

var _my_onreadystatechange = function () {
    try {
        switch (transcAjax.readyState) {
            case 4:
                if (transcAjax.onloadcomplete != null)
                    transcAjax.onloadcomplete(transcAjax.responseText);
                break;
        }
    } catch (e) {
        alert(e);
    }
};

var checkEng = function () {
    try {
        var currentDate = new Date();
        var querystring = "timerequest=" + currentDate;
        transcAjax.OpenGet("./Service/service_engate.aspx", querystring, checkEng);
        transcAjax.onloadcomplete = validaEngate;
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
            legenda.innerHTML = (isEngate ? "<span style='color: Green;'>Engate" : "<span style='color: Red;'>Desengate") + "</span> estimado em (segundos):"
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
        transcAjax.isSuspenso = true;

        var current = new Date();
        var target = new Date();
        target.setHours(H);
        target.setMinutes(M, S, 0)

        var secondsDifference = Math.floor((target.getTime() - current.getTime()) / 1000);
        contador.innerHTML = "<span style='color: Red;'>" + secondsDifference + "</span>";

        if (secondsDifference <= 0) {
            legenda.innerHTML = "Acompanhe a situação do programa:"
            contador.innerHTML = "FORA";
            play.innerHTML = "";
            transcAjax.isNoAr = false;
            transcAjax.isSuspenso = false;
        }
        else
            setTimeout("ativaDesengate('" + H + "', '" + M + "', '" + S + "')", 1000);
    } catch (e) {
        alert(e);
    }
};

var ativaEngate = function (H, M, S) {
    try {
        transcAjax.isSuspenso = true;

        var current = new Date();
        var target = new Date();
        target.setHours(H);
        target.setMinutes(M, S, 0)

        var secondsDifference = Math.floor((target.getTime() - current.getTime()) / 1000);

        contador.innerHTML = "<span style='color: Green;'>" + secondsDifference + "</span>";
        if (secondsDifference <= 0) {
            legenda.innerHTML = "Acompanhe a situação do programa:"
            contador.innerHTML = "NO AR";
            
            play.innerHTML = "<OBJECT id=\"VIDEO\" width=\"100%\" height=\"100%\" " +
                                	"CLASSID=\"CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6\" " +
                                	"type=\"application/x-oleobject\"> " +
                                	"<PARAM NAME=\"URL\" VALUE=\"http://cdn.upx.net.br/listen/00210.wmx\"> " +
                                	"<PARAM NAME=\"SendPlayStateChangeEvents\" VALUE=\"True\"> " +
                                	"<PARAM NAME=\"AutoStart\" VALUE=\"True\"> " +
                                	"<PARAM name=\"uiMode\" value=\"none\"> " +
                                	"<PARAM name=\"PlayCount\" value=\"9999\"> " +
                                "</OBJECT>";
                                
            transcAjax.isNoAr = true;
            transcAjax.isSuspenso = false;
        }
        else
            setTimeout("ativaEngate('" + H + "', '" + M + "', '" + S + "')", 1000);
    } catch (e) {
        alert(e);
    }
};