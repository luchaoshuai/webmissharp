//提示MessageBox，可根据API自定义修改
function Pop(value) {
    Ext.net.Notification.show({
        hideFx: {
            fxName: 'ghost',
            args: ['br', {}]
        },
        showFx: {
            fxName: 'slideIn',
            args: [
                        'br', {
                            easing: 'bounceOut',
                            duration: 1.0
                        }
                        ]
        },
        alignToCfg: {
            offset: [-20, 20],
            position: 'br-br'
        },
        html: "<font color='red'>" + value + "</font>",
        height: 50
    });
}
function Msg(value, type) {
    if (type == "E") {
        Ext.Msg.show({
            icon: Ext.MessageBox.ERROR,
            msg: value,
            buttons: Ext.Msg.OK
        });
    }
    if (type == "I") {
        Ext.Msg.show({
            icon: Ext.MessageBox.INFO,
            msg: value,
            buttons: Ext.Msg.OK
        });
    }
    if (type == "Q") {
        Ext.Msg.show({
            icon: Ext.MessageBox.QUESTION,
            msg: value,
            buttons: Ext.Msg.OK
        });
    }
    if (type == "W") {
        Ext.Msg.show({
            icon: Ext.MessageBox.WARNING,
            msg: value,
            buttons: Ext.Msg.OK
        });
    }
}
function setCookie(name, value) {
    var expires = 300;
    if (expires != null) {
        var LargeExpDate = new Date();
        LargeExpDate.setTime(LargeExpDate.getTime() + (expires * 1000 * 3600 * 24));
    }
    document.cookie = name + "=" + escape(value) + ((expires == null) ? "" : ("; expires=" + LargeExpDate.toGMTString()));
}
function getCookie(Name) {
    var search = Name + "="
    if (document.cookie.length > 0) {
        offset = document.cookie.indexOf(search)
        if (offset != -1) {
            offset += search.length
            end = document.cookie.indexOf(";", offset)
            if (end == -1) end = document.cookie.length
            return unescape(document.cookie.substring(offset, end))
        }
    }
    return "20";
}
function deleteCookie(name) {
    var expdate = new Date();
    expdate.setTime(expdate.getTime() - (86400 * 1000 * 1));
    setCookie(name, "", expdate);
}
function request(paras) {
    var url = location.href;
    var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
    var paraObj = {}
    for (i = 0; j = paraString[i]; i++) {
        paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
    }
    var returnValue = paraObj[paras.toLowerCase()];
    if (typeof (returnValue) == "undefined") {
        return "";
    } else {
        return returnValue;
    }
}