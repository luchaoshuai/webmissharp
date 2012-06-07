<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="Web.Admin.Welcome" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>桌面</title>
    <style type="text/css">
        div.item-wrap
        {float:left;border: 1px solid transparent;margin: 5px;width: 70px;cursor: pointer;height: 80px;text-align: center;}
        div.item-wrap img{margin: 5px;width: 50px;}
        div.item-wrap h6{font-size: 12px;color: #3A4B5B;font-family: 微软雅黑,tahoma,arial,san-serif;}
        .items-view .x-view-over{height:80px;border: solid 1px #AAA;background-color:#CCC;}
        #items-ct{padding: 1px;}
        #items-ct h2{border-bottom: 2px solid #3A4B5B;height:30px;cursor: pointer;}
        #items-ct h2 div{background: transparent url(images/icons/group-expand-sprite.gif) no-repeat 3px -47px;padding: 4px 4px 4px 17px;font-family: tahoma,arial,san-serif;font-size: 12px;color: #3A4B5B;}
        #items-ct .collapsed h2 div{background-position: 3px 3px;}
        #items-ct dl{margin-left: 2px;background-color:transparent;}
        #items-ct .collapsed dl{display: none;}
    </style>
    <script type="text/javascript">
        function ShowDetails(id, type) {
            Details_Win.title = "[" + Notice_Store.getAt(id).get('norigin') + "]" + Notice_Store.getAt(id).get('ntitle');
            document.getElementById("header").innerHTML = "[" + Notice_Store.getAt(id).get('norigin') + "]-" + Notice_Store.getAt(id).get('ntitle');
            document.getElementById("content").innerHTML = Notice_Store.getAt(id).get('ncontent');
            document.getElementById("author").innerHTML = "创建：" + Notice_Store.getAt(id).get('nowner') + " 时间：" + Notice_Store.getAt(id).get('ndate');
        }
        var selectionChanged = function (dv, nodes) {
            if (nodes.length > 0) {
                var id = nodes[0].getAttribute('id');
                var url = nodes[0].getAttribute('url');
                var name = nodes[0].getAttribute('name');
                parent.IPhoneButtoncreateTab(id, url, name);
            }
        };
        var viewClick = function (dv, e) {
            var group = e.getTarget('h2', 3, true);
            if (group) {
                group.up('div').toggleClass('collapsed');
            }
        };
    </script>
</head>
<body>
    <form runat="server">
    <ext:ResourceManager runat="server" />
    <ext:Store ID="Notice_Store" runat="server" AutoLoad="true">
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
    </ext:Store>
    <ext:Menu runat="server" ID="MenuRemoveFun">
    </ext:Menu>
    <ext:Viewport ID="MainView" StyleSpec="background-color: transparent;" runat="server">
        <Items>
            <ext:FitLayout>
                <Items>
                    <ext:Panel Frame="false" Border="false" runat="server" BodyStyle="background-color: transparent;"
                        Header="false" Layout="Fit">
                        <Items>
                            <ext:Portal BodyStyle="background-color: transparent;" runat="server" Border="false"
                                Layout="Column">
                                <Items>
                                    <ext:PortalColumn runat="server" Cls="items-view" StyleSpec="padding:10px" ColumnWidth=".5"
                                        Layout="Anchor">
                                        <Items>
                                            <ext:DataView SingleSelect="true" ContextMenuID="MenuRemoveFun" StyleSpec="background-color: #FFF;"  OverClass="x-view-over" EnableViewState="false" ItemSelector="div.item-wrap">
                                                <Store>
                                                    <ext:Store ID="Favorite_Store" runat="server" AutoLoad="true">
                                                        <Reader>
                                                            <ext:JsonReader>
                                                                <Fields>
                                                                    <ext:RecordField Name="FunGroup" />
                                                                    <ext:RecordField Name="FunItems" IsComplex="true" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>
                                                <Template>
                                                    <Html>
                                                        <div id="items-ct">
                                                            <tpl for=".">
                                                                <div>
                                                                    <h2><div>{FunGroup}&nbsp;&nbsp;<span style="color:#CCCCCC;font-weight:normal;">左侧功能树右击节点可添加至收藏夹，收藏夹右击移除功能</span></div></h2>
                                                                    <dl>
                                                                        <tpl for="FunItems">
                                                                            <div class="item-wrap" id="{Funid}" url="{Funno}" name="{Funname}">
                                                                                <img src="images/menu/{Funid}.png" onerror="this.src='images/menu/none.png';" />
                                                                                <div>
                                                                                    <H6>{Funname}</H6>                                                    
                                                                                </div>
                                                                            </div>
                                                                        </tpl>
                                                                        <div style="clear:left"></div>
                                                                     </dl>
                                                                </div>
                                                            </tpl>
                                                        </div>
                                                    </Html>
                                                </Template>
                                                <Listeners>
                                                    <SelectionChange Fn="selectionChanged" />
                                                    <ContainerClick Fn="viewClick" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <ContextMenu OnEvent="DelFavorite">
                                                        <Confirmation ConfirmRequest="true" Title="确认" Message="您确认要将该功能移除收藏夹吗？" />
                                                        <EventMask Msg="正在移除，请稍后..." ShowMask="true" />
                                                        <ExtraParams>
                                                            <ext:Parameter Name="FUNID" Value="node.id" Mode="Raw" />
                                                        </ExtraParams>
                                                    </ContextMenu>
                                                </DirectEvents>
                                            </ext:DataView>
                                        </Items>
                                    </ext:PortalColumn>
                                    <ext:PortalColumn runat="server" Border="false" StyleSpec="padding:10px 10px 10px 0px"
                                        ColumnWidth=".5" Layout="Anchor">
                                        <Items>
                                            <ext:Portlet Icon="Sound" Title="通知公告" Header="false" Height="200px" Collapsible="true"
                                                Closable="true" runat="server">
                                                <Items>
                                                    <ext:GridPanel ID="News_Grid" Layout="fit" Height="200px" TrackMouseOver="true" runat="server"
                                                        StoreID="Notice_Store" StripeRows="true" Header="false" Border="false" Collapsible="false">
                                                        <ColumnModel runat="server">
                                                            <Columns>
                                                                <ext:RowNumbererColumn Width="20" />
                                                                <ext:TemplateColumn Fixed="true" Width="500" Header="通知公告">
                                                                    <Template>
                                                                        <Html>
                                                                            {ntitle}-<font color='#999999'>{norigin}-{ndate}</font>
                                                                        </Html>
                                                                    </Template>
                                                                </ext:TemplateColumn>
                                                            </Columns>
                                                        </ColumnModel>
                                                        <Listeners>
                                                            <RowDblClick Handler="ShowDetails(rowIndex,0);Details_Win.show();" />
                                                        </Listeners>
                                                        <LoadMask ShowMask="true" Msg="正在加载..." />
                                                    </ext:GridPanel>
                                                </Items>
                                            </ext:Portlet>
                                        </Items>
                                    </ext:PortalColumn>
                                </Items>
                            </ext:Portal>
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:FitLayout>
        </Items>
    </ext:Viewport>
    <ext:Window ID="Details_Win" Collapsible="true" Hidden="true" Modal="true" Maximizable="true"
        runat="server" Title="通知明细" AutoScroll="true" Icon="Sound" BodyStyle="background-color:#FFF;"
        Padding="10" Width="630" Height="400" Resizable="true">
        <Content>
            <div id="header" style="font-size: 14px; font-weight: bold; text-align: center;">
            </div>
            <hr />
            <div id="content">
            </div>
            <br />
            <br />
            <hr />
            <p align="right" id="author">
            </p>
        </Content>
    </ext:Window>
    </form>
</body>
</html>
