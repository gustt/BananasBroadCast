var quadro;
var lastObj;

var setQuadroComunicados = function (_control) {
    try {
        quadro = _control;
        quadro.createInnerMsg = function (userid, hora, minuto, segundo, msg) {
            try {
                var divBox = document.createElement('div');

                var table = document.createElement('table');
                var trUserMsg = document.createElement('tr');
                var trHora = document.createElement('tr');

                //Hora ---------------------------------
                var tdHora = document.createElement('th');
                var lHora = document.createElement('label');
                lHora.innerText = (hora < 10 ? '0' + hora : hora) + ':' +
                             (minuto < 10 ? '0' + minuto : minuto) + ':' +
                             (segundo < 10 ? '0' + segundo : segundo);

                tdHora.appendChild(lHora);

                //User ------------------------------------
                var tdUser = document.createElement('th');
                var lUser = document.createElement('label');
                lUser.innerText = userid;

                tdUser.appendChild(lUser);

                //Msg ------------------------------------
                var tdMsg = document.createElement('td');
                tdMsg.setAttribute('rowspan', '2');

                var lMsg = document.createElement('label');
                lMsg.innerText = msg;

                tdMsg.appendChild(lMsg);

                //Append table
                trHora.appendChild(tdHora);

                trUserMsg.appendChild(tdUser);
                trUserMsg.appendChild(tdMsg);

                table.appendChild(trUserMsg);
                table.appendChild(trHora);


                if (lastObj == null) {
                    lastObj = table;
                    this.appendChild(table);
                }
                else {
                    this.insertBefore(table, lastObj);
                    lastObj = table;
                }
            } catch (e) {
                alert(e);
            }
        };
    } catch (e) {
        alert(e);
    }
};

var checkMsg = function () {
    try {
        var currentDate = new Date();
        var querystring = "timerequest=" + currentDate.getDate() + "/" + currentDate.getMonth() + "/" + currentDate.getYear() + " "
                                            + currentDate.getHours() + ":" + currentDate.getMinutes() + ":" + currentDate.getSeconds();
        querystring = querystring + '&rnd=' + Math.random() * currentDate.getSeconds();

        var oAjax_Comunicados = createAjax();

        oAjax_Comunicados.OpenGet("./Service/service_comunicado.aspx", querystring, preencherMsgs);

        setTimeout("checkMsg()", 10000);
    } catch (e) {
        alert(e);
    }
}

var preencherMsgs = function (value) {
    try {
        if (value != null && value != undefined) {
            var xmlDoc = new ActiveXObject("Msxml2.DOMDocument.3.0");
            xmlDoc.loadXML(value);

            for (var i = 0; i < xmlDoc.childNodes.length; i++) {
                if (xmlDoc.childNodes[i].nodeType != 1)
                    continue;
                for (var ii = 0; ii < xmlDoc.childNodes[i].childNodes.length; ii++) {
                    if (xmlDoc.childNodes[i].childNodes[ii].nodeType != 1)
                        continue;

                    var msg = xmlDoc.childNodes[i].childNodes[ii].text;
                    var hora;
                    var minuto;
                    var segundo;
                    var user;

                    for (var a = 0; a < xmlDoc.childNodes[i].childNodes[ii].attributes.length; a++) {
                        if (xmlDoc.childNodes[i].childNodes[ii].attributes[a].name == 'hora')
                            hora = xmlDoc.childNodes[i].childNodes[ii].attributes[a].value;
                        if (xmlDoc.childNodes[i].childNodes[ii].attributes[a].name == 'minuto')
                            minuto = xmlDoc.childNodes[i].childNodes[ii].attributes[a].value;
                        if (xmlDoc.childNodes[i].childNodes[ii].attributes[a].name == 'segundo')
                            segundo = xmlDoc.childNodes[i].childNodes[ii].attributes[a].value;
                        if (xmlDoc.childNodes[i].childNodes[ii].attributes[a].name == 'userid')
                            user = xmlDoc.childNodes[i].childNodes[ii].attributes[a].value;
                    }
                    quadro.createInnerMsg(user, hora, minuto, segundo, msg);
                }
            }
        }
    } catch (e) {
        alert(e);
    }
};

var createComunicado = function (msg, hora, minuto, segundo, user) {
    try {
        alert(msg);
    } catch (e) {
        alert(e);
    }
};