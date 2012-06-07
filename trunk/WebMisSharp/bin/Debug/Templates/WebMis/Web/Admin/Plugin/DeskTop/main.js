var createDynamicWindow = function (app, title, url) {
    var desk = app.getDesktop();
    var w = desk.createWindow({
        title: title,
        width: 820,
        height: 500,
        maximizable: true,
        minimizable: true,
        autoLoad: {
            url: url,
            mode: "iframe",
            showMask: true
        }
    });
    w.center();
    w.show();
};
var shortstart = function (dest, id) {
    createDynamicWindow(dest, id.substring(id.lastIndexOf("|") + 1), id.substring(0, id.lastIndexOf("|")));
}