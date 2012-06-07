<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="Favorite.aspx.cs"
    Inherits="Web.Admin.Core.Favorite" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>功能收藏夹</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="MainResourceMgr" ViewStateMode="Disabled" runat="server" />
    <ext:Store runat="server" ID="WMS_FAVORITES_MainStore" OnRefreshData="WMS_FAVORITES_DataBind"
        AutoLoad="true">
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="Fid">
                <Fields>
                    <ext:RecordField Name="Fid" />
                    <ext:RecordField Name="funname" />
                    <ext:RecordField Name="funno" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <!--WMS_FAVORITES页面主表格-->
    <ext:Viewport ID="MainViewPort" runat="server">
        <Items>
            <ext:FitLayout>
                <Items>
                    <ext:GridPanel ID="WMS_FAVORITES_Grid" Layout="fit" TrackMouseOver="true" runat="server"
                        StoreID="WMS_FAVORITES_MainStore" StripeRows="true" Header="false" Border="false"
                        Collapsible="true">
                        <TopBar>
                            <ext:Toolbar>
                                <Items>
                                    <ext:Button ID="BtnDel" runat="server" Text="删除" Icon="Delete">
                                        <DirectEvents>
                                            <Click OnEvent="BtnDel_Click">
                                                <Confirmation ConfirmRequest="true" Title="确认" Message="您确定要删除吗?" />
                                                <EventMask ShowMask="true" Msg="正在删除数据，请等候 ..." />
                                            </Click>
                                        </DirectEvents>
                                        <Listeners>
                                            <Click Handler="if(#{WMS_FAVORITES_Grid}.getSelectionModel().getCount()<=0) {Msg('请选择要删除的记录','E');return false;}" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarSeparator />
                                    <ext:Button ID="BtnReload" runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{WMS_FAVORITES_MainStore}.reload();" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <ColumnModel ID="WMS_FAVORITES_ColumnMode" runat="server">
                            <Columns>
                                <ext:RowNumbererColumn Width="20" />
                                <ext:Column Header="主键" Sortable="true" Hidden="true" DataIndex="Fid" />
                                <ext:Column Header="URL" Hidden="true" Sortable="true" DataIndex="funno" />
                                <ext:Column Header="功能名称" Sortable="true" DataIndex="funname" />
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" Msg="正在加载..." />
                        <SelectionModel>
                            <ext:CheckboxSelectionModel ID="CheckBoxGrid" runat="server" />
                        </SelectionModel>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
