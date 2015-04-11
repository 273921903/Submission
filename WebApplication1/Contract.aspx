<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contract.aspx.cs" Inherits="COFCOsubmission.Contract" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title></title>
<%--<link href="css/index.css" rel="stylesheet" />--%>
<script src="Scripts/jquery-1.7.1.min.js"></script>
<script src="Scripts/contract.js"></script>
    <script src="Scripts/jquery-ui-datepicker.js"></script>
    <link href="css/jquery-ui.css" rel="stylesheet" />
<script type="text/javascript">
        function getvalue(obj) {
            var value = obj.options[obj.selectedIndex].value
            if (value != "") {
                var items = new Array();
                items = value.split("|");
                document.getElementById("BuyAdes").value = items[0];
                document.getElementById("BuyPhone").value = items[1] + "|" + items[2];
            }
          
        }
    //明细
        function Goahed() {
            window.location.href = "ContractInfo.aspx?from=main&id=<%=ViewState["id"]%>";
        }

    $(function () {
        $("#BuyTime").datepicker({
            showOn: "button",
            buttonImage: "img/calendar.gif",
            buttonImageOnly: true,
            width: "100px"
        });
    })
    </script>
    <style type="text/css">
        body {
            margin:0 0;
            height:100%;
            background-color:#5CA3D8;
        }
        table {
            border:none;
            border-collapse:collapse;
            overflow:hidden;
        }
        .Information {
            height:100%;
        }
        .header {
            background-color:#2365C4;
            
        }
            .header input {
                font-size:35px;
            }
            .header img {
                width:65px;
            }
        ul {
            float:left;
            margin-left:0;
            margin:0 0;
            width:100%;
            display:table;
            
        }
        ul li {
            display:table;
            float:left;
            margin-right:1%;
            background-color:#1b2a52;
            width:15%;
            text-align:center;
        }

        .List {
            font-size:50px;
        }

        .List input{
            font-size:50px;
            width:85%;
            margin-left:2%;
        }

        #payfang {
            width:85%;
        }

        #BuyAdes1 {
            width:90%;
            font-size:50px;
            overflow:hidden;
            margin-left:2%;
        }

        #fukuan {
            width:90%;
            font-size:40px;
            margin-left:2%;
        }

        #BuyTable img {
            width:60px;
            height:60px;
            float: right;
        }

    </style>
</head>
<body>
<form id="form1" runat="server" onKeyPress="if(event.keyCode==13){return false;}">
    <table  class="Information" width="100%" border="0" style="border-style: none; border-width: medium; padding: 0px; margin: 0px;">
        <tr class="header">
            <td style="text-align:left; height:100%;"><img src="img/home.png" title="主页"/></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td  style="text-align:right">
              <input id="Btn_Details" onclick="Goahed();" runat="server" type="button" value="明细" />
            <asp:Button ID="Btn_Save" runat="server" Text="保存" OnClick="Btn_Save_Click"/>
            <asp:Button ID="Btn_Commit" runat="server" Text="提交" />
          </td>
        </tr>
        <tr height="5%" style="font-size:50px; color:white;">
            <td colspan="4" class="tab">
                <ul>
                    <li>合同</li>
                    <li>买方</li>
                    <li>卖方</li>
                </ul>
            </td>
        </tr>
        <tr style="background-color:#5CA3D8">
            <td colspan="4" class="List">
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
                <%-- 买方--%>
                <table id="BuyTable" width="100%">
                    <tr>
                        <td>交货时间：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="jiaohuoTime" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>交货地点：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="jiaohuoPlace" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>签约时间：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="BuyTime" runat="server" type="text" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>签约地点：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="qianyuePlace" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>签约代表：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="Buydb" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>传真：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="Buyfax" runat="server" type="text" /></td>
                    </tr>
                    <tr>
                        <td>开户行：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="Buybank" runat="server" type="text" /></td>
                    </tr>
                    <tr>
                        <td>账号：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="BuyNumber" runat="server" type="text" /></td>
                    </tr>
                </table>

                <table id="SellTable" width="100%">
                    <tr>
                        <td>卖方地址：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="SellAde" runat="server" type="text" value="北京市海淀区中关村南大街12号信息楼3层" /></td>
                    </tr>
                    <tr>
                        <td>联系电话：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="SellPhone" type="text" runat="server" value="010-62166116" /></td>
                    </tr>
                    <tr>
                        <td>签约时间：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="SellTime" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>签约代表：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="Selldb" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>传真：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="Sellfax" type="text" runat="server" value="010-62166156" /></td>
                    </tr>
                    <tr>
                        <td>开户行：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="Sellbank" type="text" runat="server" value="农行北京白石桥支行" /></td>
                    </tr>
                    <tr>
                        <td>账号：</td>
                    </tr>
                    <tr>
                        <td>
                            <input id="SellNumber" type="text" runat="server" value="11-050501040016046" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</form>
</body>
</html>
