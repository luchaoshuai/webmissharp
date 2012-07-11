<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="Default.aspx.cs" Inherits="Web.Admin.Default" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%= ConfigurationManager.AppSettings["SoftName"] %></title>
    <script src="js/Tab.js" type="text/javascript"></script>
    <style type="text/css">
        .defaulticon{background-image:url(images/icons/default.png) !important;}
    </style>
    <script type="text/javascript">
        var loadExample = function (href, id) {
            var tab = CenterPanel.getComponent(id);
            if (tab) {
                CenterPanel.setActiveTab(tab);
            } else {
                createExampleTab(id, href);
            }
        }
        var currentNodeID = -1;
    </script>
</head>
<body style="background:#CCCCCC url(images/loading32.gif)  no-repeat center 200px;">
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" ViewStateMode="Disabled" runat="server" />
    <ext:Viewport runat="server">
        <Items>
            <ext:BorderLayout runat="server">
                <North>
                    <ext:Panel Header="false" Height="27" runat="server" >
                        <Items>
                            <ext:Toolbar ID="Toolbar2">
                                <Items>
                                    <ext:Button Text="标准版" Pressed="true" Icon="Computer">
                                        <Listeners>
                                            <Click Handler="window.location='Default.aspx';" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarSeparator />
                                    <ext:Button Text="桌面版" Icon="Application">
                                        <Listeners>
                                            <Click Handler="window.location='DeskTop.aspx';" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarFill />
                                    <ext:Button Text="个人信息" Icon="User">
                                        <Listeners>
                                            <Click Handler="WatchUserInfo();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarSeparator />
                                    <ext:Button Text="修改密码" Icon="Key">
                                        <Listeners>
                                            <Click Handler="ChangePwdWin.show();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarSeparator/>
                                    <ext:Button ID="BtnSafeExit" Icon="ControlPowerBlue" runat="server" Text="安全退出">
                                        <DirectEvents>
                                            <Click OnEvent="BtnExit_Click">
                                                <Confirmation ConfirmRequest="true" Title="确认" Message="确实要退出系统吗？退出前请注意保存数据！" />
                                                <EventMask ShowMask="true" Msg="正在退出，请等候 ..." />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Items>
                    </ext:Panel>
                </North>
                <West Split="true" Collapsible="true">
                    <ext:Panel ID="WestPanel" Title="功能菜单树" AutoScroll="true" Border="false" Icon="World" Width="200">
                        <Items>
                            <ext:Panel ID="Navigation" Border="false" BodyStyle="padding:6px;"
                                Icon="User">
                                <Items>
                                    <ext:TreePanel ID="exampleTree" Border="false" Title="Examples" AutoScroll="true"
                                        Lines="true" RootVisible="false" AutoHeight="true" Header="False" HideParent="True">
                                        <Root>
                                            <ext:AsyncTreeNode Text="Examples" NodeID="root" Expanded="true" />
                                        </Root>
                                        <Loader>
                                            <ext:PageTreeLoader RequestMethod="GET" OnNodeLoad="GetExamplesNodes" PreloadChildren="true">
                                                <EventMask ShowMask="true" Target="Parent" Msg="正在加载..." />
                                            </ext:PageTreeLoader>
                                        </Loader>
                                        <DirectEvents>
                                            <ContextMenu OnEvent="AddNode2Favorite_Click">
                                                <Confirmation Message="您确定要添加到收藏夹吗？" ConfirmRequest="true"  Title="请确认" />
                                                <ExtraParams>
                                                    <ext:Parameter Value="currentNodeID" Name="NODEID" Mode="Raw" />
                                                </ExtraParams>
                                                <EventMask Msg="正在添加到收藏夹..." ShowMask="true" Target="Page" />
                                            </ContextMenu>
                                        </DirectEvents>
                                        <Listeners>
                                            <ContextMenu Handler="if(node.isLeaf()){currentNodeID=node.id; return true;}else return false;" />
                                            <Click Handler="if(node.isLeaf()){e.stopEvent();loadExample(node.attributes.href, node.id);}" />
                                        </Listeners>
                                    </ext:TreePanel>
                                </Items>
                            </ext:Panel>
                            </Items>
                    </ext:Panel>
                </West>
                <Center>
                    <ext:TabPanel Border="false" ID="CenterPanel" Frame="true" ActiveTabIndex="0" runat="server" EnableTabScroll="true">
                        <Items>
                            <ext:Panel ID="Home" runat="server" Title="桌 面" Icon="House" Border="false">
                                <AutoLoad Url="Welcome.aspx" Mode="IFrame" ShowMask="true"></AutoLoad>
                            </ext:Panel>
                        </Items>
                        <Plugins>
                            <ext:TabCloseMenu ID="TabCloseMenu1" runat="server" CloseAllTabsText="关闭所有" CloseOtherTabsText="关闭其他"
                                CloseTabText="关闭" />
                        </Plugins>
                    </ext:TabPanel>
                </Center>
                <South>
                <ext:Panel Frame="false" Header="false" Height="27">
                        <Items>
                           <ext:Toolbar Height="27">
                                <Items>
                                    <ext:Label ID="Lbname" runat="server" Icon="User"></ext:Label>
                                    <ext:ToolbarFill></ext:ToolbarFill>
                                    <ext:ToolbarSeparator/>
                                    <ext:ComboBox ID="cbTheme" runat="server" EmptyText="切换主题" Width="100" Editable="false"
                                        TypeAhead="true">
                                        <Items>
                                            <ext:ListItem Text="Default" Value="default" />
                                            <ext:ListItem Text="Gray" Value="gray" />
                                            <ext:ListItem Text="Access" Value="access" />
                                            <ext:ListItem Text="Slate" Value="slate" />
                                        </Items>
                                        <%--<Listeners>
                                            <Select Handler="Ext.net.ResourceMgr.setTheme('/extjs/resources/css/xtheme-' + item.getValue() + '-embedded-css/ext.axd');" />
                                        </Listeners>--%>
                                        <DirectEvents>
                                            <Select OnEvent="cbTheme_changed">
                                                <EventMask ShowMask="true" Msg="正在更换皮肤,请稍后..." MinDelay="200" />
                                            </Select>
                                        </DirectEvents>
                                    </ext:ComboBox>
                                    <ext:ToolbarSeparator/>
                                    <ext:Label Html="<a href='http://yj.ChinaCloudTech.com' target='_blank'>系统支持</a>" Text="">
                                    </ext:Label>
                                </Items>
                            </ext:Toolbar>
                            </Items>
                        </ext:Panel>
                </South>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
    <ext:Window ID="ChangePwdWin" runat="server" Modal="True" Hidden="true" Collapsible="true"
        Icon="Key" Title="修改密码" HideLabel="false" BodyStyle="padding:16px;text-align:center;"
        AutoHeight="true" Width="400px" Border="false" Resizable="False">
        <Items>
            <ext:Panel Frame="true" Border="false" Layout="Form" ColumnWidth="1">
                <Items>
                    <ext:TextField ID="TxtOldPwd" AnchorHorizontal="92%" runat="server" InputType="Password"
                        AllowBlank="false" FieldLabel="请输入旧密码" />
                    <ext:TextField ID="TxtNewPwd" AnchorHorizontal="92%" runat="server" InputType="Password"
                        AllowBlank="false" FieldLabel="请输入新密码" />
                    <ext:TextField ID="TxtSurePwd" AnchorHorizontal="92%" runat="server" InputType="Password"
                        AllowBlank="false" FieldLabel="请确认新密码" />
                </Items>
            </ext:Panel>
        </Items>
        <Buttons>
            <ext:Button ID="BtnSave" runat="server" Text="提 交" Icon="Disk">
                <DirectEvents>
                   <Click OnEvent="BtnSave_Click">
                        <EventMask ShowMask="true" Msg="修改中，请稍后..." />
                    </Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Window>
    </form>
</body>
</html>
