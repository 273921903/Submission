<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="COFCOsubmission.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table id="Information" class="Information" width="100%" border="0">
        <tr class="header">
            <td style="text-align:left"><img src="img/home.png" title="主页" width="70" height="70"/></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td  style="text-align:right">
              <input id="Button1" onclick="Goahed();" runat="server" type="button" value="明细" />
            <asp:Button ID="Button2" runat="server" Text="保存" OnClick="Btn_Save_Click"/>
            <asp:Button ID="Button3" runat="server" Text="提交" />
          </td>
        </tr>
        <tr>
            <td colspan="4" class="tab">
                <ul>
                    <li>合同</li>
                    <li>买方</li>
                    <li>卖方</li>
                </ul>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table id="httable" width="100%" border="0">
                    <tr>
                            <td>卖方名称:</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="id" runat="server" type="text" style="display: none" />
                            <input id="custcode" runat="server" type="text" style="display: none" />
                            <input id="hetongNum" runat="server" type="text" style="display: none" />
                            <input id="maif" runat="server" type="text" value="中粮(北京)饲料科技有限公司" />
                        </td>
                    </tr>
                    <tr>
                        <td>买方名称：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="payfang" runat="server" type="text" />
                            <img style="cursor: pointer; width: 50px; height: 50px;" alt="选择客户" id="buyerM"
                                src="img/BuyerM.png" />
                        </td>
                    </tr>
                    <tr>
                        <td>发货地址：</td>
                    </tr>
                    <tr>
                        <td>
                            <select id="BuyAdes1" onchange="getvalue(this)" style="font-size: 40px;">
                                <%=ViewState["address"]  %>
                            </select>
                            <input type="hidden" runat="server" id="BuyAdes" />
                        </td>
                    </tr>
                    <tr>
                        <td>联系电话：</td>
                    </tr>
                    <tr>
                        <td>
                            <input runat="server" id="BuyPhone" type="text" /></td>
                    </tr>
                    <tr>
                        <td>运输费用：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="feiyong" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>付款方式：</td>
                    </tr>
                    <tr>
                        <td>
                            <select runat="server" id="fukuan">
                                <option>1111</option>
                                <option>2222</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>履行期限：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="lvxingTime" runat="server" type="text" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
