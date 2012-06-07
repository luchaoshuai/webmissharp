<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="Template.aspx.cs"
    Inherits="Web.Admin.Template" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WebMisSharp-云极</title>
    <style type="text/css">
        .x-table-layout{width: 100%;}
        .x-table-layout-cell{padding: 0px 0px 0px 5px;}
    </style>
    <script src="/Admin/js/WMS.js" type="text/javascript"></script>
    <script type="text/javascript">
        function SetWinData(index) {
            var record = {TABLENAME}_MainStore.getAt(index);
            {TABLENAME}_MainForm.reset();
            {TABLENAME}_MainForm.getForm().loadRecord(record);
            {TABLENAME}_Win.show();
        }
    </script>
</head>
<body>
    <form id="MainForm" runat="server">
    <ext:ResourceManager ID="Main_ResourceManager" ViewStateMode="Disabled" runat="server" />
    <!--WMS_NOTICE表页面主数据元，自动生成-->
    <ext:Store runat="server" ID="{TABLENAME}_MainStore" OnRefreshData="{TABLENAME}_DataBind"
        AutoLoad="true">
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="{AutoID}">
                <Fields>
                    {RecordField}
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw">
            </ext:Parameter>
            <ext:Parameter Name="limit" Value="getCookie('PageSize')" Mode="Raw">
            </ext:Parameter>
        </BaseParams>
    </ext:Store>
    <!--WMS_NOTICE页面主表格-->
    <ext:Viewport ID="MainViewPort" runat="server">
        <Items>
            <ext:FitLayout>
                <Items>
                    <ext:GridPanel ID="{TABLENAME}_Grid" Layout="fit" SelectionMemory="Disabled" TrackMouseOver="true"
                        runat="server" StoreID="{TABLENAME}_MainStore" StripeRows="true" Header="false"
                        Border="false" Collapsible="true">
                        <TopBar>
                            <ext:Toolbar ID="MainToolBar" runat="server">
                                <Items>
                                    <ext:Button Text="添加" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{{TABLENAME}_MainForm}.getForm().reset();#{{TABLENAME}_Win}.show();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarSeparator />
                                    <ext:Button Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{{TABLENAME}_MainStore}.reload();" />
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
                                            <Click Handler="if(#{{TABLENAME}_Grid}.getSelectionModel().getCount()<=0) {Msg('请选择要删除的记录','E');return false;}" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <ColumnModel>
                            <Columns>
                                <ext:RowNumbererColumn Width="30" />
                                {Columns}
                            </Columns>
                        </ColumnModel>
                        <Listeners>
                            <RowDblClick Handler="SetWinData(rowIndex);" />
                        </Listeners>
                        <Plugins>
                            <ext:GridFilters runat="server" FiltersText="查找" ID="{TABLENAME}_Filter">
                                <Filters>
                                    {StringFilter}
                                </Filters>
                            </ext:GridFilters>
                        </Plugins>
                        <LoadMask ShowMask="true" Msg="正在加载..." />
                        <SelectionModel>
                            <ext:CheckboxSelectionModel />
                        </SelectionModel>
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar" StoreID="{TABLENAME}_MainStore" PageSize="20"
                                runat="server">
                                <Items>
                                    <ext:ToolbarSeparator />
                                    <ext:Label Text="分页数:" />
                                    <ext:ComboBox Width="60" SelectedIndex="1">
                                        <Items>
                                            <ext:ListItem Text="10" />
                                            <ext:ListItem Text="20" />
                                            <ext:ListItem Text="30" />
                                            <ext:ListItem Text="50" />
                                        </Items>
                                        <Listeners>
                                            <Select Handler="#{PagingToolBar}.pageSize = parseInt(this.getValue());setCookie('PageSize',this.getValue());#{PagingToolBar}.doLoad();" />
                                            <Render Handler="this.setValue(getCookie('PageSize'));" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                            </ext:PagingToolbar>
                        </BottomBar>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Items>
    </ext:Viewport>
    <!--WMS_NOTICE表修改，添加主窗体-->
    <ext:Window ID="{TABLENAME}_Win" Collapsible="true" Hidden="true" Modal="true" Maximizable="true"
        runat="server" Border="false" Title="编辑记录" Icon="Pencil" Width="630" AutoHeight="true"
        Resizable="true">
        <Items>
            <ext:FormPanel ID="{TABLENAME}_MainForm" Padding="10" Border="false" AutoHeight="true"
                LabelWidth="65">
                <Items>
                    <ext:TableLayout ColumnWidth="0.5" Columns="{TableColumns}">
                        <Cells>
                            {Cells}
                        </Cells>
                    </ext:TableLayout>
                </Items>
            </ext:FormPanel>
        </Items>
        <Buttons>
            <ext:Button Text="提交" runat="server" Icon="Disk">
                <DirectEvents>
                    <Click OnEvent="BtnSave_Click">
                        <EventMask ShowMask="true" Msg="正在提交，请等候 ..." />
                    </Click>
                </DirectEvents>
                <Listeners>
                    <Click Handler="if (#{{TABLENAME}_MainForm}.getForm().isValid()) {;}else{Msg('您填写的信息不正确，请您确认！','E');return false;}" />
                </Listeners>
            </ext:Button>
            <ext:Button Text="取消" Icon="Decline">
                <Listeners>
                    <Click Handler="#{{TABLENAME}_Win}.hide();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    </form>
</body>
</html>
