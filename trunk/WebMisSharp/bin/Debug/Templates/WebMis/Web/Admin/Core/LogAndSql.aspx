<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false"
    CodeBehind="LogAndSql.aspx.cs" Inherits="Web.Admin.Core.LogAndSql" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>日志和SQL处理</title>
    <link href="../CSS/BackStyle.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Plugin/Tencent/msgbox.css" />
    <script type="text/javascript" src="../Plugin/Tencent/msgbox.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h3 style="color: #FF0000">
                该页面涉及整个系统数据库安全，请不要随便开放权限！</h3>
            <p>
                <asp:Label ID="LbSqlInfo" runat="server"></asp:Label>
            </p>
            <div style="float: right; width: 420px;">
                <strong>日志列表(Log.txt为正在使用日志，无法操作)：</strong><br />
                <table class="Tmain">
                    <tr>
                        <th width="40px">
                            序号
                        </th>
                        <th width="100px">
                            文件名
                        </th>
                        <th width="120px">
                            日期
                        </th>
                        <th width="80px">
                            大小
                        </th>
                        <th width="40px">
                            删除
                        </th>
                    </tr>
                    <asp:Repeater ID="RPLogs" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Container.ItemIndex+1 %>
                                </td>
                                <td>
                                    <a href="/Logs/<%# Eval("filename").ToString() %>" target="_blank"><%# Eval("filename").ToString() %></a>
                                </td>
                                <td>
                                    <%# Eval("filedate").ToString() %>
                                </td>
                                <td>
                                    <%# Eval("filesize").ToString() %>
                                </td>
                                <th>
                                    <asp:ImageButton ID="imgbtnDel" ImageUrl="../images/cross-circle.png" CommandName='<%# Eval("filename").ToString()  %>'
                                                OnCommand="imgbtnDel_Click" OnClientClick='javascript:return confirm( "您确定删除该条记录吗? ")'
                                               runat="server" CausesValidation="False" />
                                </th>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div style="width: 400px">
                执行SQL：<br />
                <asp:TextBox ID="TxtSQL" CssClass="txt" runat="server" Height="131px" 
                    Width="390px" TextMode="MultiLine"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="BtnRunRead" CssClass="btn" runat="server" Text=" 查 询 " 
                    onclick="BtnRunRead_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnRunNoRead" CssClass="btn" runat="server" Text=" 非查询 " 
                    onclick="BtnRunNoRead_Click" />
                <br />
            </div>
            <br />
            <asp:GridView ID="GridData" CssClass="Tmain" runat="server">
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
