<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="UserSelfInfo.aspx.cs" Inherits="Web.Admin.Core.UserSelfInfo" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户个人信息编辑</title>
</head>
<body>
    <form id="form1" runat="server">
     <ext:ResourceManager runat="server" ViewStateMode="Disabled" />
     <ext:Window ID="WinUser" Collapsible="true" Border="false" Modal="true"
        TitleCollapse="true" Maximizable="false" runat="server" Title="编辑用户信息" Icon="User"
        Width="500" AutoHeight="true" Resizable="false">
        <Items>
            <ext:FormPanel ID="RegistForm" LabelWidth="50" Frame="true" runat="server" Border="false"
                Height="120" ButtonAlign="Right" Icon="UserAdd" Layout="Column">
                <Items>
                    <ext:Panel Border="false" Header="false" ColumnWidth=".5" Layout="Form">
                        <Items>
                            <ext:Hidden ID="Hid" DataIndex="userid" runat="server">
                            </ext:Hidden>
                            <ext:TextField ID="TxtUserName" ReadOnly="true" AnchorHorizontal="92%" runat="server"
                                AllowBlank="false" EmptyText="该项不可为空" FieldLabel="登录名" />
                            <ext:TextField ID="Txtuserdept" AnchorHorizontal="92%" runat="server"
                                FieldLabel="部门" />
                            <ext:TextField ID="TxtTel" AnchorHorizontal="92%" runat="server"
                                FieldLabel="电话" />
                            <ext:TextField ID="TxtAddress" AnchorHorizontal="92%" runat="server"
                                FieldLabel="地址" />
                        </Items>
                    </ext:Panel>
                    <ext:Panel Border="false" Header="false" ColumnWidth=".5" Layout="Form">
                        <Items>
                            <ext:TextField ID="Txtusernamec" AnchorHorizontal="92%" runat="server"
                                AllowBlank="false" EmptyText="该项不可为空" FieldLabel="用户名" />
                            <ext:ComboBox ID="cboSex" DataIndex="usersex" AnchorHorizontal="92%" FieldLabel="性别"
                                Editable="false" SelectedIndex="0" runat="server">
                                <Items>
                                    <ext:ListItem Text="男" />
                                    <ext:ListItem Text="女" />
                                </Items>
                            </ext:ComboBox>
                            <ext:TextField ID="TxtEmail" AnchorHorizontal="92%" runat="server"
                                FieldLabel="邮箱" Vtype="email" />
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:FormPanel>
        </Items>
        <Buttons>
            <ext:Button Text="提交" ID="BtnSave" runat="server" Icon="Disk">
                <DirectEvents>
                    <Click OnEvent="BtnSave_Click">
                        <EventMask ShowMask="true" Msg="正在提交，请等候 ..." />
                    </Click>
                </DirectEvents>
                <Listeners>
                    <Click Handler="if (#{RegistForm}.getForm().isValid()) {;}else{Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '您填写的信息不正确，请您确认！', buttons:Ext.Msg.OK});return false;}" />
                </Listeners>
            </ext:Button>
            <ext:Button Text="取消" Icon="Decline">
                <Listeners>
                    <Click Handler="#{WinUser}.hide();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    </form>
</body>
</html>
