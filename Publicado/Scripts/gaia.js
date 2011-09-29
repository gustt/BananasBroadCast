var play;
var setPlay = function (_control) {
    try {
        play = _control;
    } catch (e) {
        alert(e);
    }
};

function initXMLHttpClient() {
    var xmlhttp;
    try {
        // Mozilla / Safari / IE7
        xmlhttp = new XMLHttpRequest();
    } catch (e) {
        // IE
        var XMLHTTP_IDS = new Array('MSXML2.XMLHTTP.5.0',
                                     'MSXML2.XMLHTTP.4.0',
                                     'MSXML2.XMLHTTP.3.0',
                                     'MSXML2.XMLHTTP',
                                     'Microsoft.XMLHTTP');
        var success = false;
        for (var i = 0; i < XMLHTTP_IDS.length && !success; i++) {
            try {
                xmlhttp = new ActiveXObject(XMLHTTP_IDS[i]);
                success = true;
            } catch (e) { }
        }
        if (!success) {
            throw new Error('Unable to create XMLHttpRequest.');
        }
    }
    return xmlhttp;
}

var createAjax = function () {
    try {
        //Instancia obj ajax
        var oAjax = initXMLHttpClient();

        oAjax.OpenGet = function (_url, _querystring, _onloadcomplete) {
            try {
                this.onloadcomplete = _onloadcomplete;
                if (_querystring != null && _querystring != undefined)
                    this.open("GET", _url + "?" + _querystring, true);
                this.send(null);
            } catch (e) {
                alert(e);
            }
        };
        oAjax.onreadystatechange = _my_onreadystatechange;
        return oAjax;
    } catch (e) {
        alert(e);
    }
};

var _my_onreadystatechange = function () {
    try {
        switch (this.readyState) {
            case 4:
                if (this.onloadcomplete != null)
                    this.onloadcomplete(this.responseText);
                break;
        }
    } catch (e) {
        alert(e);
    }
};


var $id = function (id) {
    try {
        return document.getElementById(id);
    } catch (e) {
        alert(e);
    }
};

var $name = function (name) {
    try {
        return document.getElementsByName(name);
    } catch (e) {
        alert(e);
    }
};

var $tag = function (tag) {
    try {
        return document.getElementsByTagName(tag);
    } catch (e) {
        alert(e);
    }
};


var url_active = new String();
var url1 = "http://cdn.upx.net.br/listen/00210.m3u";
var url2 = "http://cdn.upx.net.br/listen/00211.m3u";

var playRadio = function () {
    try {
        alterUrl();
        play.innerHTML = "<OBJECT id=\"VIDEO\" width=\"100%\" height=\"100%\" " +
                                	"CLASSID=\"CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6\" " +
                                	"type=\"application/x-oleobject\"> " +
                                	"<PARAM NAME=\"URL\" VALUE=\"" + url_active + "\"> " +
                                	"<PARAM NAME=\"SendPlayStateChangeEvents\" VALUE=\"True\"> " +
                                	"<PARAM NAME=\"AutoStart\" VALUE=\"True\"> " +
                                	"<PARAM name=\"uiMode\" value=\"none\"> " +
                                	"<PARAM name=\"PlayCount\" value=\"9999\"> " +
                                "</OBJECT>";
    }
    catch (e) {
        alert(e);
    }
};

var alterUrl = function () {
    if (url_active.length == 0 || url_active == url2) {
        url_active = url1;
    }
    else if (url_active == url1) {
        url_active = url2;
    }
};