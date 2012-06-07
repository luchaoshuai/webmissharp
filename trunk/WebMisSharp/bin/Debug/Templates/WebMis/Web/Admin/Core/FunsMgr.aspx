<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="FunsMgr.aspx.cs"
    Inherits="Web.Admin.FunsMgr" %>

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
            var record = WMS_USERFUN_MainStore.getAt(index);
            WMS_USERFUN_MainForm.reset();
            WMS_USERFUN_MainForm.getForm().loadRecord(record);
            Hid.setValue(record.get("funid"));
            WMS_USERFUN_Win.show();
        }
    </script>
</head>
<body>
    <form id="MainForm" runat="server">
    <ext:ResourceManager ID="Main_ResourceManager" ViewStateMode="Disabled" runat="server" />
    <!--WMS_NOTICE表页面主数据元，自动生成-->
    <ext:Store runat="server" ID="WMS_USERFUN_MainStore" OnRefreshData="WMS_USERFUN_DataBind"
        AutoLoad="true">
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
        <BaseParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw">
            </ext:Parameter>
            <ext:Parameter Name="limit" Value="getCookie('PageSize')" Mode="Raw">
            </ext:Parameter>
        </BaseParams>
        <Listeners>
            <Load Handler="#{PagingToolBar}.pageSize=parseInt(getCookie('PageSize'));" />
        </Listeners>
    </ext:Store>
    <!--WMS_NOTICE页面主表格-->
    <ext:Viewport ID="MainViewPort" runat="server">
        <Items>
            <ext:FitLayout>
                <Items>
                    <ext:GridPanel ID="WMS_USERFUN_Grid" Layout="fit" SelectionMemory="Disabled" TrackMouseOver="true"
                        runat="server" StoreID="WMS_USERFUN_MainStore" StripeRows="true" Header="false"
                        Border="false" Collapsible="true">
                        <TopBar>
                            <ext:Toolbar ID="MainToolBar" runat="server">
                                <Items>
                                    <ext:Button Text="添加" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{WMS_USERFUN_MainForm}.getForm().reset();#{WMS_USERFUN_Win}.show();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarSeparator />
                                    <ext:Button Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{WMS_USERFUN_MainStore}.reload();" />
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
                                            <Click Handler="if(#{WMS_USERFUN_Grid}.getSelectionModel().getCount()<=0) {Msg('请选择要删除的记录','E');return false;}" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <ColumnModel>
                            <Columns>
                                <ext:RowNumbererColumn Width="30" />
								<ext:Column Header="节点ID" Sortable="true" DataIndex="funid" />
								<ext:Column Header="功能名称" Sortable="true" DataIndex="funname" />
								<ext:Column Header="功能链接" Width="250" Sortable="true" DataIndex="funno" />
								<ext:Column Header="父节点" Sortable="true" DataIndex="fatherid" />
                            </Columns>
                        </ColumnModel>
                        <Listeners>
                            <RowDblClick Handler="SetWinData(rowIndex);" />
                        </Listeners>
                        <Plugins>
                            <ext:GridFilters runat="server" FiltersText="查找" ID="WMS_USERFUN_Filter">
                                <Filters>
									<ext:StringFilter DataIndex="funno" />
									<ext:StringFilter DataIndex="funname" />
                                </Filters>
                            </ext:GridFilters>
                        </Plugins>
                        <LoadMask ShowMask="true" Msg="正在加载..." />
                        <SelectionModel>
                            <ext:CheckboxSelectionModel />
                        </SelectionModel>
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar" StoreID="WMS_USERFUN_MainStore" PageSize="20"
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
    <ext:Window ID="WMS_USERFUN_Win" Hidden="true" Modal="true"
        runat="server" Border="false" Title="功能权限列表" Icon="FolderKey" Width="550" AutoHeight="true"
        >
        <Items>
            <ext:FormPanel ID="WMS_USERFUN_MainForm" Padding="10" Border="false" AutoHeight="true"
                LabelWidth="65">
                <Items>
                    <ext:TableLayout ColumnWidth="0.5" Columns="2">
                        <Cells>
							<ext:Cell>
								<ext:Container Layout="Form">
									<Items>
									<ext:NumberField ID="NFfunid" Width="160" FieldLabel="节点ID" runat="server" DataIndex="funid" />
									</Items>
								</ext:Container>
							</ext:Cell>
							<ext:Cell>
								<ext:Container Layout="Form">
									<Items>
									<ext:TextField ID="Txtfunno" Width="160" FieldLabel="功能链接" runat="server" DataIndex="funno" />
									</Items>
								</ext:Container>
							</ext:Cell>
							<ext:Cell>
								<ext:Container Layout="Form">
									<Items>
									<ext:TextField ID="Txtfunname" Width="160" FieldLabel="功能名称" runat="server" DataIndex="funname" />
									</Items>
								</ext:Container>
							</ext:Cell>
							<ext:Cell>
								<ext:Container Layout="Form">
									<Items>
									<ext:NumberField ID="NFfatherid" Width="160" FieldLabel="父节点" runat="server" DataIndex="fatherid" />
									</Items>
								</ext:Container>
							</ext:Cell>
                            <ext:Cell>
                                <ext:Hidden ID="Hid" runat="server"></ext:Hidden>
                            </ext:Cell>
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
                    <Click Handler="if (#{WMS_USERFUN_MainForm}.getForm().isValid()) {;}else{Msg('您填写的信息不正确，请您确认！','E');return false;}" />
                </Listeners>
            </ext:Button>
            <ext:Button Text="取消" Icon="Decline">
                <Listeners>
                    <Click Handler="#{WMS_USERFUN_Win}.hide();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    </form>
</body>
</html>
