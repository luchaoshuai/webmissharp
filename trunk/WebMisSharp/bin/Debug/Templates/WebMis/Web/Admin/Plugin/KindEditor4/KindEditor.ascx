<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KindEditor.ascx.cs" Inherits="Web.Admin.Plugin.KindEditor4.KindEditor" %>
<link rel="stylesheet" href="/Admin/Plugin/KindEditor4/themes/default/default.css" />
	<link rel="stylesheet" href="/Admin/Plugin/KindEditor4/plugins/code/prettify.css" />
	<script type="text/javascript" charset="utf-8" src="/Admin/Plugin/KindEditor4/kindeditor.js"></script>
	<script type="text/javascript" charset="utf-8" src="/Admin/Plugin/KindEditor4/lang/zh_CN.js"></script>
	<script type="text/javascript" charset="utf-8" src="/Admin/Plugin/KindEditor4/plugins/code/prettify.js"></script>
	<script type="text/javascript">
	    var editor;
	    KindEditor.ready(function (K) {
	        editor = K.create('#<%= EditorContent.ClientID %>', {
	            cssPath: '/Admin/Plugin/KindEditor4/plugins/code/prettify.css',
	            uploadJson: '/Admin/Plugin/KindEditor4/upload_json.ashx',
	            fileManagerJson: '/Admin/Plugin/KindEditor4/file_manager_json.ashx',
	            allowFileManager: true
	        });
	        prettyPrint();
	    });
	    function EditorSumbit() {
	        editor.sync();
	    }
	</script>
    <textarea id="EditorContent" cols="100" rows="8" style="width:100%;height:400px;visibility:hidden;" runat="server"></textarea>