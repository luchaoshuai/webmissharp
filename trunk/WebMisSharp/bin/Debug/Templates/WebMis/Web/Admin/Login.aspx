<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%= ConfigurationManager.AppSettings["SoftName"] %></title>
    <link rel="stylesheet" href="Plugin/Tencent/msgbox.css" />
    <script type="text/javascript" src="Plugin/Tencent/msgbox.js"></script>
    <style type="text/css">
        body
        {
            color: #032c7e;
            font-size: 12px;
            font-family: 微软雅黑,Arial;
            margin: 0px auto;
            padding: 0px auto;
            background: #032c7e url(images/loginbg.jpg) repeat-x;
            text-align: center;
        }
        .main
        {
            margin: 154px auto;
            background: url(images/loginmain.jpg) center center no-repeat;
            height: 59px;
            width: 882px;
            padding: 208px 0px 0px 0px;
        }
        .Txt
        {
            background-color: #FFF;
            border: 1px solid #032c7e;
        }
        .header
        {
            font-size: 11px;
            font-family: Arial;
            color: #CCC;
            text-align: center;
        }
        a
        {
            color: #CCC;
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
        <table align="center">
            <tr>
                <td align="right">
                    用户名：
                </td>
                <td>
                    <asp:TextBox ID="TxtUserName" CssClass="Txt" runat="server" Width="84px"></asp:TextBox>
                </td>
                <td width="42px" align="right">
                    密 码：
                </td>
                <td>
                    <asp:TextBox ID="TxtPwd" CssClass="Txt" TextMode="Password" runat="server" Width="87px"></asp:TextBox>
                </td>
                <td align="right" width="57px">
                    <asp:ImageButton ID="ImgBtnLogin" runat="server" ImageUrl="images/login.png" OnClick="ImgBtnLogin_Click" />
                </td>
            </tr>
        </table>
        <div class="header">
            <br />
            <br />
            <br />
            <br />
            <a href="http://yj.ChinaCloudTech.com" target="_blank">技术支持</a> QQ:710782046 Email:JackChain@ChinaCloudTech.com
        </div>
    </div>
    </form>
</body>
</html>
