var oRelogio = function () { };
oRelogio.Hora = 0;
oRelogio.Minuto = 0;
oRelogio.Segundo = 0;
oRelogio.OutPutControl = null;
oRelogio.TimeCount = function () {
    if (this.Segundo < 59)
        this.Segundo++;
    else {
        this.Segundo = 0;
        if (this.Minuto < 59)
            this.Minuto++;
        else {
            this.Minuto = 0;
            if (this.Hora < 23)
                this.Hora++;
            else
                this.Hora = 0;
        }
    }

    if (this.OutPutControl != null && this.OutPutControl != undefined)
        this.OutPutControl.innerHTML =
                                    (this.Hora < 10 ? ("0" + this.Hora) : this.Hora) + ":" +
                                    (this.Minuto < 10 ? ("0" + this.Minuto) : this.Minuto) + ":" +
                                    (this.Segundo < 10 ? ("0" + this.Segundo) : this.Segundo);
};
var setRelogio = function (_control) {
    try {
        oRelogio.OutPutControl = _control;
    } catch (e) {
        alert(e);
    }
};

var syncServer = function () {
    try {
        var currentDate = new Date(); //tempo do cliente, usado apenas para que não retorne cache da parte do servidor
        var querystring = "timerequest=" + currentDate;
        var oAjax_Hour = createAjax();
        oAjax_Hour.OpenGet("./Service/service_horaatual.aspx", querystring, validateHour);
    } catch (e) {
        alert(e);
    }
};

var validateHour = function (value) {
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

                    for (var a = 0; a < xmlDoc.childNodes[i].childNodes[ii].attributes.length; a++) {
                        if (xmlDoc.childNodes[i].childNodes[ii].attributes[a].name == "hora")
                            oRelogio.Hora = xmlDoc.childNodes[i].childNodes[ii].attributes[a].value;

                        if (xmlDoc.childNodes[i].childNodes[ii].attributes[a].name == "minuto")
                            oRelogio.Minuto = xmlDoc.childNodes[i].childNodes[ii].attributes[a].value;

                        if (xmlDoc.childNodes[i].childNodes[ii].attributes[a].name == "segundo")
                            oRelogio.Segundo = xmlDoc.childNodes[i].childNodes[ii].attributes[a].value;
                    }
                }
            }
        }

        setInterval("oRelogio.TimeCount()", 995);
    } catch (e) {
        alert(e);
    }
};