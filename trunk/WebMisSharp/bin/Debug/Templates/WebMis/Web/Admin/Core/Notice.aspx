<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" EnableViewState="false" CodeBehind="Notice.aspx.cs"
    Inherits="Web.Admin.Core.Notice" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>通知公告</title>
    <script src="../js/WMS.js" type="text/javascript"></script>
    <script type="text/javascript">
        function SetWinData(index) {
            var record = WMS_NOTICE_MainStore.getAt(index);
            WMS_NOTICE_MainForm.reset();
            WMS_NOTICE_MainForm.getForm().loadRecord(record);
            WMS_NOTICE_Win.show();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ViewStateMode="Disabled" runat="server" />
    <!--WMS_NOTICE表页面主数据元，自动生成-->
    <ext:Store runat="server" ID="WMS_NOTICE_MainStore" OnRefreshData="WMS_NOTICE_DataBind"
        AutoLoad="true">
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="nid">
                <Fields>
                    <ext:RecordField Name="nid" />
                    <ext:RecordField Name="ntitle" />
                    <ext:RecordField Name="ncontent" />
                    <ext:RecordField Name="ndate" />
                    <ext:RecordField Name="nowner" />
                    <ext:RecordField Name="norigin" />
                    <ext:RecordField Name="nreceiver" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw">
            </ext:Parameter>
            <ext:Parameter Name="limit" Value="20" Mode="Raw">
            </ext:Parameter>
        </BaseParams>
    </ext:Store>
    <!--WMS_NOTICE页面主表格-->
    <ext:Viewport ID="MainViewPort" runat="server">
        <Items>
            <ext:FitLayout>
                <Items>
                    <ext:GridPanel ID="WMS_NOTICE_Grid" Layout="fit" SelectionMemory="Disabled" TrackMouseOver="true"
                        runat="server" StoreID="WMS_NOTICE_MainStore" StripeRows="true" Header="false"
                        Border="false" Collapsible="true">
                        <TopBar>
                            <ext:Toolbar ID="MainToolBar" runat="server">
                                <Items>
                                    <ext:Button Text="添加" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{WMS_NOTICE_MainForm}.getForm().reset();#{Hid}.setValue('');#{WMS_NOTICE_Win}.show();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarSeparator />
                                    <ext:Button ID="BtnReload" runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{WMS_NOTICE_MainStore}.reload();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarFill />
                                    <ext:Button runat="server" Text="删除" Icon="Decline">
                                        <DirectEvents>
                                            <Click OnEvent="BtnDel_Click">
                                                <Confirmation ConfirmRequest="true" Title="确认" Message="您确定要删除吗?" />
                                                <EventMask ShowMask="true" Msg="正在删除数据，请等候 ..." />
                                            </Click>
                                        </DirectEvents>
                                        <Listeners>
                                            <Click Handler="if(#{WMS_NOTICE_Grid}.getSelectionModel().getCount()<=0) {Msg('请选择要删除的记录','E');return false;}" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <ColumnModel>
                            <Columns>
                                <ext:RowNumbererColumn Width="30" />
                                <ext:Column Header="主键" Sortable="true" Hidden="true" DataIndex="nid" />
                                <ext:Column Header="来源" Width="120" Sortable="true" DataIndex="norigin" />
                                <ext:Column Header="标题" Width="250" Sortable="true" DataIndex="ntitle" />
                                <ext:Column Header="时间" Width="120" Sortable="true" DataIndex="ndate" />
                                <ext:Column Header="接收人" Sortable="true" DataIndex="nreceiver" />
                                <ext:Column Header="创建人" Sortable="true" DataIndex="nowner" />
                            </Columns>
                        </ColumnModel>
                        <Listeners>
                            <RowDblClick Handler="SetWinData(rowIndex);" />
                        </Listeners>
                        <Plugins>
                            <ext:GridFilters runat="server" FiltersText="查找" ID="WMS_NOTICE_Filter">
                                <Filters>
                                    <ext:StringFilter DataIndex="ntitle" />
                                    <ext:StringFilter DataIndex="ncontent" />
                                    <ext:StringFilter DataIndex="nowner" />
                                    <ext:StringFilter DataIndex="norigin" />
                                    <ext:StringFilter DataIndex="nreceiver" />
                                </Filters>
                            </ext:GridFilters>
                        </Plugins>
                        <LoadMask ShowMask="true" Msg="正在加载..." />
                        <SelectionModel>
                            <ext:CheckboxSelectionModel runat="server" />
                        </SelectionModel>
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar" StoreID="WMS_NOTICE_MainStore" PageSize="20"
                                runat="server" />
                        </BottomBar>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Items>
    </ext:Viewport>
    <!--WMS_NOTICE表修改，添加主窗体-->
    <ext:Window ID="WMS_NOTICE_Win" Collapsible="true" Hidden="true" Modal="true" Maximizable="true"
        runat="server" Border="false" Title="编辑记录" Icon="Pencil" Width="630" AutoHeight="true"
        Resizable="true">
        <Items>
            <ext:FormPanel ID="WMS_NOTICE_MainForm" LabelWidth="45" Frame="true" runat="server"
                Border="false" Height="350" Padding="5" Icon="UserAdd">
                <Items>
                    <ext:Hidden ID="Hid" DataIndex="nid" runat="server" />
                    <ext:TextField ID="Txtnorigin" DataIndex="norigin" AnchorHorizontal="62%" runat="server" FieldLabel="来源" />
                    <ext:TextField ID="Txtntitle" DataIndex="ntitle" AnchorHorizontal="100%" runat="server" AllowBlank="false"
                        EmptyText="该项不可为空" FieldLabel="标题" />
                    <ext:HtmlEditor ID="HtmlContent"  DataIndex="ncontent" FieldLabel="内容" Height="200" AnchorHorizontal="100%" AutoRender="true" AutoCreate="true"
                        runat="server">
                    </ext:HtmlEditor>
                    <ext:MultiCombo ID="Cbonreceiver" runat="server" DisplayField="cn_name" ValueField="username" SelectionMode="All" AnchorHorizontal="100%" FieldLabel="接收人" EmptyText="为空则发送全部人员">
                        <Store>
                            <ext:Store ID="User_Store" runat="server" AutoLoad="true">
                                <Reader>
                                    <ext:JsonReader IDProperty="username">
                                        <Fields>
                                            <ext:RecordField Name="username" />
                                            <ext:RecordField Name="cn_name" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                    </ext:MultiCombo>
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
                    <Click Handler="if (#{WMS_NOTICE_MainForm}.getForm().isValid()) {;}else{Msg('您填写的信息不正确，请您确认！','E');return false;}" />
                </Listeners>
            </ext:Button>
            <ext:Button Text="取消" Icon="Decline">
                <Listeners>
                    <Click Handler="#{WMS_NOTICE_Win}.hide();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    </form>
</body>
</html>
