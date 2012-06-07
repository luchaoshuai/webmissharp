<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="RolesMgr.aspx.cs" Inherits="Web.Admin.Core.RolesMgr" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色管理</title>
    <script src="../js/WMS.js" type="text/javascript"></script>
    <script type="text/javascript">
        var CJRoleID = -1;
        var nodeSeleted = function (node, checked) {
            node.eachChild(function (child) {
                child.ui.toggleCheck(checked);
                child.attributes.checked = checked;
            });
            parentChecked(node, checked);
        };
        var nodeState = function (node) {
            var box = node.getUI().checkbox;
            if (box.checked) {
                return 1;
            } else if (box.indeterminate) {
                return 2;
            } else {
                return 3;
            }
        };
        var siblState = function (node) {
            var state = new Array();
            var firstNode = node.parentNode.firstChild;
            if (!firstNode) {
                return false;
            }
            do {
                state.push(nodeState(firstNode));
                firstNode = firstNode.nextSibling;
            } while (firstNode != null)
            return state;
        };
        var parentState = function (node) {
            var state = siblState(node).join();
            if (state.indexOf("1") == -1 && state.indexOf("2") == -1) {
                return -1;
            } else {
                return 1;
            }
        }
        var parentChecked = function (node, checked) {
            var parentNode = node.parentNode;
            if (parentNode == null || parentNode.id == 'root') {
                return false;
            }
            var checkbox = parentNode.getUI().checkbox;
            if (typeof checkbox == 'undefined')
                return false;
            var check = parentState(node);
            if (check == 1) {
                checkbox.indeterminate = false; //半选中状态
                checkbox.checked = true;
            } else if (check == -1) {
                checkbox.checked = false;
                checkbox.indeterminate = false;
            } else {
                checkbox.checked = false;
                checkbox.indeterminate = true;
            }
            parentChecked(parentNode, checked);
        };
        var sn = "";
        function getTasks() {
            var msg = "", selNodes = TreeAllFuns.getChecked();
            Ext.each(selNodes, function (node) {
                if (node.leaf == true) {
                    if (msg.length > 0) {
                        msg += ",";
                    }
                    msg += node.id;
                }
            });
            return msg + "," + roleForfun_Grid.getSelectionModel().getSelected().id;
        }
        var GetFunName = function (value) {
            index = AllFun_Store.find("funid", value, 0, false, false);
            if (AllFun_Store.getAt(index).get('fatherid') == "0")
                return "<font color='red'>" + AllFun_Store.getAt(index).get('funname') + "</font>";
            else
                return AllFun_Store.getAt(index).get('funname');
        };
        var GetRoleName = function (value) {
            index = role_Store.find("roleid", value);
            return role_Store.getAt(index).get('rolename');
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ViewStateMode="Disabled" runat="server" />
    <ext:Store ID="role_Store" runat="server" OnRefreshData="InfoBind" AutoLoad="true"
        OnBeforeStoreChanged="HandleChanges" RefreshAfterSaving="Always">
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="roleid">
                <Fields>
                    <ext:RecordField Name="roleid" />
                    <ext:RecordField Name="rolename" />
                    <ext:RecordField Name="remark" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Store ID="AllFun_Store" runat="server" OnRefreshData="AllFunBind" AutoLoad="true">
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="funid">
                <Fields>
                    <ext:RecordField Name="funid" />
                    <ext:RecordField Name="funno" />
                    <ext:RecordField Name="funname" />
                    <ext:RecordField Name="fatherid" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Store ID="rolefun_Store" runat="server" OnRefreshData="roleForFunGridDBClick"
        AutoLoad="false">
        <Reader>
            <ext:JsonReader IDProperty="pid">
                <Fields>
                    <ext:RecordField Name="pid" />
                    <ext:RecordField Name="roleid" />
                    <ext:RecordField Name="funid" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Name="roleid" Value="CJRoleID" Mode="Raw">
            </ext:Parameter>
        </BaseParams>
    </ext:Store>
    <ext:Viewport ID="Viewport1" runat="server">
        <Items>
            <ext:FitLayout ID="FitLayout1" runat="server">
                <Items>
                    <ext:GridPanel ID="role_Grid" Layout="fit" SelectionMemory="Disabled" TrackMouseOver="true" runat="server" StoreID="role_Store"
                        StripeRows="true" Header="false" Border="false" Collapsible="true">
                        <Plugins>
                            <ext:RowEditor runat="server" SaveText="更新" CancelText="取消">
                            </ext:RowEditor>
                        </Plugins>
                        <View>
                            <ext:GridView runat="server" MarkDirty="false" />
                        </View>
                        <TopBar>
                            <ext:Toolbar >
                                <Items>
                                    <ext:Button Text="添加" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{role_Grid}.insertRecord();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarSeparator />
                                    <ext:Button runat="server" Text="保存" Icon="Disk">
                                        <Listeners>
                                            <Click Handler="#{role_Grid}.save();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarSeparator />
                                    <ext:Button Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{role_Store}.reload();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarSeparator />
                                    <ext:Button Text="功能管理" Icon="FolderKey">
                                        <Listeners>
                                            <Click Handler="#{Fun_Win}.show();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarSeparator />
                                    <ext:Button ID="BtnRoleMgr" runat="server" Text="分配权限" Icon="ShieldRainbow">
                                        <ToolTips>
                                            <ext:ToolTip Title="为角色分配功能权限">
                                            </ext:ToolTip>
                                        </ToolTips>
                                        <Listeners>
                                            <Click Handler="#{FunWin}.show();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarFill />
                                    <ext:Button runat="server" Text="清空缓存" Icon="ArrowRefresh">
                                        <DirectEvents>
                                            <Click OnEvent="BtnCacheReflash_Click"><EventMask ShowMask="true" Msg="正在清空，请等候 ..." />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:ToolbarSeparator />
                                    <ext:Button runat="server" Text="删除" Icon="Decline">
                                        <DirectEvents>
                                            <Click OnEvent="BtnDel_Click">
                                                <Confirmation ConfirmRequest="true" Title="确认" Message="您确定要删除吗?" />
                                                <EventMask ShowMask="true" Msg="正在删除数据，请等候 ..." />
                                            </Click>
                                        </DirectEvents>
                                        <Listeners>
                                            <Click Handler="if(#{role_Grid}.getSelectionModel().getCount()<=0) {Msg('请选择要删除的记录','E');return false;}" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <ColumnModel>
                            <Columns>
                                <ext:RowNumbererColumn />
                                <ext:Column Header="角色ID" Sortable="true" Hidden="true" DataIndex="roleid" />
                                <ext:Column Header="角色名称" Sortable="true" DataIndex="rolename">
                                    <Editor>
                                        <ext:TextField runat="server" AllowBlank="false">
                                        </ext:TextField>
                                    </Editor>
                                </ext:Column>
                                <ext:Column Header="角色描述" Width="400" Sortable="true" DataIndex="remark">
                                    <Editor>
                                        <ext:TextField runat="server" AllowBlank="false">
                                        </ext:TextField>
                                    </Editor>
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:CheckboxSelectionModel />
                        </SelectionModel>
                        <LoadMask ShowMask="true" Msg="正在加载..." />
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Items>
    </ext:Viewport>
    <ext:Window ID="FunWin" runat="server" Modal="true" Border="false" Hidden="true"
        Collapsible="true" Maximizable="true" Height="500" Icon="ShieldRainbow" Title="角色功能权限配置"
        Width="700" Layout="column">
        <Items>
            <ext:Panel Title="系统功能菜单" Width="200" AutoScroll="true">
                <Items>
                    <ext:TreePanel ID="TreeAllFuns" Lines="true" AutoScroll="true"
                        ContainerScroll="true" AutoHeight="true" Border="false" Header="false"
                        RootVisible="false" runat="server">
                        <Root>
                            <ext:AsyncTreeNode Text="Examples" NodeID="root" Expanded="true" Checked="False" />
                        </Root>
                        <Loader>
                            <ext:PageTreeLoader RequestMethod="GET" OnNodeLoad="GetExamplesNodes" PreloadChildren="true">
                                <EventMask ShowMask="true" Target="Parent" Msg="Loading..." />
                            </ext:PageTreeLoader>
                        </Loader>
                        <Listeners>
                            <CheckChange Handler="nodeSeleted(node,checked);" />
                            <Render Handler="this.getRootNode().expand(true);" Delay="50" />
                        </Listeners>
                    </ext:TreePanel>
                </Items>
            </ext:Panel>
            <ext:Panel Header="false" ColumnWidth="1">
                <Items>
                    <ext:RowLayout Split="true">
                        <Rows>
                            <ext:LayoutRow RowHeight="0.4">
                                <ext:GridPanel ID="roleForfun_Grid" TrackMouseOver="true" runat="server" StoreID="role_Store"
                                    StripeRows="true" Title="系统角色" Border="false" Collapsible="true">
                                    <ColumnModel ID="cmfun" runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn />
                                            <ext:Column Header="角色ID" Sortable="true" Hidden="true" DataIndex="roleid" />
                                            <ext:Column Header="角色名称" Sortable="true" DataIndex="rolename">
                                            </ext:Column>
                                            <ext:Column Header="角色备注" Sortable="true" DataIndex="remark">
                                            </ext:Column>
                                        </Columns>
                                    </ColumnModel>
                                    <Listeners>
                                        <RowDblClick Handler="CJRoleID=#{roleForfun_Grid}.store.getAt(rowIndex).get('roleid');#{rolefun_Store}.reload();" />
                                    </Listeners>
                                    <SelectionModel>
                                        <ext:CheckboxSelectionModel SingleSelect="true" ID="CheckboxSelectionModel1" runat="server" />
                                    </SelectionModel>
                                    <LoadMask ShowMask="true" Msg="正在加载..." />
                                </ext:GridPanel>
                            </ext:LayoutRow>
                            <ext:LayoutRow RowHeight="0.6">
                                <ext:GridPanel ID="funOfrole_Grid" Height="100px" TrackMouseOver="true" runat="server"
                                    StoreID="rolefun_Store" StripeRows="true" Title="角色功能列表" Border="false" Collapsible="true">
                                    <TopBar>
                                        <ext:Toolbar>
                                            <Items>
                                                <ext:Button runat="server" Text="功能授权" Icon="Add">
                                                    <DirectEvents>
                                                        <Click OnEvent="BtnGiveFuns_Click">
                                                            <EventMask ShowMask="true" Msg="正在操作，请等候 ..." />
                                                            <ExtraParams>
                                                                <ext:Parameter Name="id" Value="getTasks()" Mode="Raw" />
                                                            </ExtraParams>
                                                        </Click>
                                                    </DirectEvents>
                                                    <Listeners>
                                                        <Click Handler="if(#{roleForfun_Grid}.getSelectionModel().getCount()<=0){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '请选择被授权用户！', buttons:Ext.Msg.OK});return false;}if(#{TreeAllFuns}.getChecked().length<=0){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '请选择要授予的功能节点！', buttons:Ext.Msg.OK});return false;}" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:ToolbarSeparator />
                                                <ext:Button runat="server" Text="删除功能" Icon="Delete">
                                                    <DirectEvents>
                                                        <Click OnEvent="BtnDelFuns_Click">
                                                            <Confirmation ConfirmRequest="true" Title="确认" Message="确实要删除吗?" />
                                                            <EventMask ShowMask="true" Msg="正在删除数据，请等候 ..." />
                                                        </Click>
                                                    </DirectEvents>
                                                    <Listeners>
                                                        <Click Handler="if(#{funOfrole_Grid}.getSelectionModel().getCount()<=0) {TellAlert('请选择要删除的记录');return false;}" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <ColumnModel>
                                        <Columns>
                                            <ext:RowNumbererColumn />
                                            <ext:Column Header="主键" Sortable="true" Hidden="true" DataIndex="pid" />
                                            <ext:Column Header="角色名称" Sortable="true" DataIndex="roleid">
                                                <Renderer Fn="GetRoleName" />
                                            </ext:Column>
                                            <ext:Column Header="功能模块" Sortable="true" DataIndex="funid">
                                                <Renderer Fn="GetFunName" />
                                            </ext:Column>
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:CheckboxSelectionModel />
                                    </SelectionModel>
                                    <LoadMask ShowMask="true" Msg="正在加载..." />
                                </ext:GridPanel>
                            </ext:LayoutRow>
                        </Rows>
                    </ext:RowLayout>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Window>

     <ext:Window ID="Fun_Win" runat="server" Modal="true" Border="false" Hidden="true"
        Maximizable="true" Height="500" Icon="Folder" Title="功能节点管理"
        Width="800">
        <AutoLoad Url="FunsMgr.aspx" MaskMsg="正在加载..." Mode="IFrame" ShowMask="true"></AutoLoad>
     </ext:Window>
    </form>
</body>
</html>
