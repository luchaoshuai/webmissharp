<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="UserMgr.aspx.cs"
    Inherits="Web.Admin.Core.UserMgr" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户管理</title>
    <script src="../js/WMS.js" type="text/javascript"></script>
    <script type="text/javascript">
        var GetRoleName = function (value) {
            index = S_Roles.find("roleid", value, 0, false, false);
            if (index == -1)
                return "未指定";
            else
                return S_Roles.getAt(index).get('rolename');
        }
        function SetWinData(index) {
            var record = USER_Store.getAt(index);
            RegistForm.reset();
            TxtUserName.setReadOnly(true);
            RegistForm.getForm().loadRecord(record);
            WinUser.show();
        }
        function AddNewRecord() {
            RegistForm.reset();
            TxtUserName.setReadOnly(false);
            cboRole.setValue(S_Roles.getAt(0).get('roleid'));
            WinUser.show();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager runat="server" ViewStateMode="Disabled" />
    <ext:Store runat="server" ID="S_Roles" OnRefreshData="GetAllRoles" AutoLoad="true">
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="roleid">
                <Fields>
                    <ext:RecordField Name="roleid" />
                    <ext:RecordField Name="rolename" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <Load Handler="#{cboRole}.setValue(#{S_Roles}.getAt(0).get('roleid'));#{USER_Store}.reload();" />
        </Listeners>
    </ext:Store>
    <ext:Store ID="USER_Store" runat="server" OnRefreshData="InfoBind" AutoLoad="false">
        <Reader>
            <ext:JsonReader IDProperty="userid">
                <Fields>
                    <ext:RecordField Name="userid" />
                    <ext:RecordField Name="username" />
                    <ext:RecordField Name="cn_name" />
                    <ext:RecordField Name="userdept" />
                    <ext:RecordField Name="password" />
                    <ext:RecordField Name="roleid" />
                    <ext:RecordField Name="telephone" />
                    <ext:RecordField Name="usersex" />
                    <ext:RecordField Name="address" />
                    <ext:RecordField Name="email" />
                    <ext:RecordField Name="logintime" />
                    <ext:RecordField Name="createtime" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw">
            </ext:Parameter>
            <ext:Parameter Name="limit" Value="30" Mode="Raw">
            </ext:Parameter>
        </BaseParams>
    </ext:Store>
    <ext:Viewport runat="server">
        <Items>
            <ext:FitLayout>
                <Items>
                    <ext:GridPanel ID="USERINFO_Grid" Layout="fit" TrackMouseOver="true" SelectionMemory="Disabled"
                        runat="server" StoreID="USER_Store" StripeRows="true" Header="false" Border="false"
                        Collapsible="true">
                        <TopBar>
                            <ext:Toolbar>
                                <Items>
                                    <ext:Button Text="添加" Icon="Add">
                                        <Listeners>
                                            <Click Handler="AddNewRecord();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarSeparator />
                                    <ext:TextField ID="TxtKeys" runat="server" Width="150" EmptyText="输入：登录名\用户名 查询" />
                                    <ext:Button Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{S_Roles}.reload();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarFill />
                                    <ext:Button runat="server" Text="删除" Icon="Decline">
                                        <DirectEvents>
                                            <Click OnEvent="BtnDel_Click">
                                                <Confirmation ConfirmRequest="true" Title="确认" Message="确实要删除吗?" />
                                                <EventMask ShowMask="true" Msg="正在删除数据，请等候 ..." />
                                            </Click>
                                        </DirectEvents>
                                        <Listeners>
                                            <Click Handler="if(#{USERINFO_Grid}.getSelectionModel().getCount()<=0) {Msg('请选择要删除的记录','E');return false;}" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <ColumnModel>
                            <Columns>
                                <ext:RowNumbererColumn />
                                <ext:Column Header="用户ID" Sortable="true" Hidden="true" DataIndex="userid" />
                                <ext:Column Header="登录名" Sortable="true" DataIndex="username" />
                                <ext:Column Header="用户名" Sortable="true" DataIndex="cn_name" />
                                <ext:Column Header="性别" Sortable="true" DataIndex="usersex" />
                                <ext:Column Header="部门" Sortable="true" DataIndex="userdept" />
                                <ext:Column Header="电话" Sortable="true" DataIndex="telephone" />
                                <ext:Column Header="地址" Sortable="true" DataIndex="address" />
                                <ext:Column Header="邮箱" Sortable="true" DataIndex="email" />
                                <ext:Column Header="最后登录" Sortable="true" DataIndex="logintime" />
                                <ext:Column Header="创建时间" Sortable="true" DataIndex="createtime" />
                                <ext:Column Header="角色" Sortable="true" DataIndex="roleid">
                                    <Renderer Fn="GetRoleName" />
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <Listeners>
                            <RowDblClick Handler="SetWinData(rowIndex);" />
                        </Listeners>
                        <LoadMask ShowMask="true" Msg="正在加载..." />
                        <SelectionModel>
                            <ext:CheckboxSelectionModel />
                        </SelectionModel>
                        <BottomBar>
                            <ext:PagingToolbar StoreID="USER_Store" PageSize="30" runat="server" />
                        </BottomBar>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Items>
    </ext:Viewport>
    <ext:Window ID="WinUser" Collapsible="true" Hidden="true" Border="false" Modal="true"
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
                            <ext:TextField ID="TxtUserName" DataIndex="username" AnchorHorizontal="92%" runat="server"
                                AllowBlank="false" EmptyText="该项不可为空" FieldLabel="登录名" />
                            <ext:TextField ID="Txtuserdept" DataIndex="userdept" AnchorHorizontal="92%" runat="server"
                                FieldLabel="部门" />
                            <ext:TextField ID="TxtTel" DataIndex="telephone" AnchorHorizontal="92%" runat="server"
                                FieldLabel="电话" />
                            <ext:TextField ID="TxtAddress" DataIndex="address" AnchorHorizontal="92%" runat="server"
                                FieldLabel="地址" />
                        </Items>
                    </ext:Panel>
                    <ext:Panel Border="false" Header="false" ColumnWidth=".5" Layout="Form">
                        <Items>
                            <ext:TextField ID="Txtusernamec" DataIndex="cn_name" AnchorHorizontal="92%" runat="server"
                                AllowBlank="false" EmptyText="该项不可为空" FieldLabel="用户名" />
                            <ext:ComboBox ID="cboSex" DataIndex="usersex" AnchorHorizontal="92%" FieldLabel="性别"
                                Editable="false" SelectedIndex="0" runat="server">
                                <Items>
                                    <ext:ListItem Text="男" />
                                    <ext:ListItem Text="女" />
                                </Items>
                            </ext:ComboBox>
                            <ext:TextField ID="TxtEmail" DataIndex="email" AnchorHorizontal="92%" runat="server"
                                FieldLabel="邮箱" Vtype="email" />
                            <ext:ComboBox ID="cboRole" DataIndex="roleid" AnchorHorizontal="92%" StoreID="S_Roles"
                                runat="server" FieldLabel="角色" TypeAhead="true" Editable="false" ForceSelection="true"
                                DisplayField="rolename" ValueField="roleid">
                            </ext:ComboBox>
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:FormPanel>
        </Items>
        <Buttons>
            <ext:Button Text="重置密码" ID="BtnResetPwd" runat="server" Icon="Key">
                <DirectEvents>
                    <Click OnEvent="BtnResetPwd_Click">
                        <EventMask ShowMask="true" Msg="正在重置密码，请等候 ..." />
                    </Click>
                </DirectEvents>
            </ext:Button>
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
