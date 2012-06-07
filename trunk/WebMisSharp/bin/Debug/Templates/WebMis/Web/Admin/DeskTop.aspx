<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="DeskTop.aspx.cs" Inherits="Web.Admin.DeskTop" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%= ConfigurationManager.AppSettings["SoftName"] %> 桌面版</title>
    <link href="Plugin/DeskTop/default.css" rel="stylesheet" type="text/css" />
    <script src="Plugin/DeskTop/main.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager runat="server" />
        <ext:Desktop 
            ID="MyDesktop" 
            runat="server" 
            BackgroundColor="Black" 
            ShortcutTextColor="White" 
            Wallpaper="Plugin/DeskTop/desktop.jpg">
            <StartButton Text="WebMisSharp" IconCls="start-button"/>
            <%-- 开始菜单里的东西 --%>
            <Modules>
            </Modules>  
            <%-- END开始菜单里的东西 --%>
            <%-- 桌面图标 --%>
            <Shortcuts>
            </Shortcuts>
            <%-- END桌面图标 --%>
            <Listeners>
                <ShortcutClick Handler="shortstart(#{MyDesktop},id)" />
            </Listeners>

            <StartMenu Width="300" Height="400" Icon="Computer" ToolsWidth="127" Title="WebMisSharp">
                <ToolItems>
                    <ext:MenuItem Text="标准版" Icon="Computer">
                        <Listeners>
                            <Click Handler="window.location.href='Default.aspx';" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem Text="配置" Icon="Wrench">
                        <Listeners>
                            <Click Handler="Ext.Msg.alert('配置信息', '您想做什么呢？');" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem Text="Logout" Icon="Disconnect">
                        <DirectEvents>
                            <Click OnEvent="BtnExit_Click">
                                <EventMask ShowMask="true" Msg="感谢您的使用" MinDelay="1000" />
                            </Click>
                        </DirectEvents>
                    </ext:MenuItem>
                    <ext:MenuSeparator />
                    <%-- 开始菜单右侧 --%>
                </ToolItems>
            </StartMenu>
        </ext:Desktop>
    </form>
</body>
</html>
