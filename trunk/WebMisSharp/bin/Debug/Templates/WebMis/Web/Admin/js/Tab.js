function createExampleTab(id, url){
    var tab, hostName, node;
    node = exampleTree.getNodeById(id);
    hostName = window.location.protocol + "//" + window.location.host;
    tab = CenterPanel.add(new Ext.Panel({
        id: id,
        title: node.text,
        iconCls: "defaulticon",
        layout: 'fit',
        autoLoad: {
            showMask: true,
            scripts: false,
            mode: "iframe",
            url: hostName+url
        },
        listeners: {
            deactivate: {
                fn: function(el) {
                    if (this.sWin && this.sWin.isVisible()) {
                        this.sWin.hide();
                    }
                }
            }
        },
        closable: true
    }));
    CenterPanel.setActiveTab(tab);
}

function IPhoneButtoncreateTab(id, url, name) {
    var tab = CenterPanel.getComponent(id);
    if (tab) {
        CenterPanel.setActiveTab(tab);
        return;
    }
    var tab, hostName, node;
    hostName = window.location.protocol + "//" + window.location.host;
    tab = CenterPanel.add(new Ext.Panel({
        id: id,
        title: name,
        iconCls: "defaulticon",
        layout: 'fit',
        autoLoad: {
            showMask: true,
            scripts: false,
            mode: "iframe",
            url: hostName + url
        },
        listeners: {
            deactivate: {
                fn: function (el) {
                    if (this.sWin && this.sWin.isVisible()) {
                        this.sWin.hide();
                    }
                }
            }
        },
        closable: true
    }));
    CenterPanel.setActiveTab(tab);
}

function WatchUserInfo() {
    var tab = CenterPanel.getComponent(id);
    if (tab) {
        CenterPanel.setActiveTab(tab);
        return;
    }
    var tab, hostName;
    hostName = window.location.protocol + "//" + window.location.host;
    tab = CenterPanel.add(new Ext.Panel({
        id: "UserINFOMgr",
        title: "个人信息",
        iconCls: "defaulticon",
        layout: 'fit',
        autoLoad: {
            showMask: true,
            scripts: false,
            mode: "iframe",
            url: hostName + "/Admin/Core/UserSelfInfo.aspx"
        },
        listeners: {
            deactivate: {
                fn: function (el) {
                    if (this.sWin && this.sWin.isVisible()) {
                        this.sWin.hide();
                    }
                }
            }
        },
        closable: true
    }));
    CenterPanel.setActiveTab(tab);
}