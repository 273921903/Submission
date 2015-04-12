<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="COFCOsubmission._Default" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>中粮北京科技手机订单系统</title>
    <style type="text/css">
        body {
            font-size:15px;

        }
        input {
            font-size:15px;
        }
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0" />
</head>
<body>
    <form id="form1" runat="server">
        <table align="center">
            <tr>
                <td colspan="2" align="center" valign="middle">手机订单系统
        <hr />
                    <br />
                </td>
            </tr>
            <tr>
                <td>用户名:</td>
                <td>
                    <asp:TextBox ID="userName" runat="server" MaxLength="18" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td>密&nbsp;&nbsp;码:</td>
                <td>
                    <asp:TextBox ID="userPassword" runat="server" TextMode="Password" MaxLength="18" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td height="10px">验证码：</td>
                <td>
                    <asp:TextBox ID="checkImg" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Image width="100%" ID="Image1" runat="server" ImageUrl="~/image.aspx" /></td>
                <td>
                    <asp:LinkButton ID="ChangeCode" runat="server" OnClick="ChangeCode_Click1">看不清楚？换一个验证码</asp:LinkButton> </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button1" runat="server" Text="登 录" OnClick="landbutton1_Click" Width="100px" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
