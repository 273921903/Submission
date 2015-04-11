<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contract.aspx.cs" Inherits="COFCOsubmission.Contract" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>合同信息</title>
<%--<link href="css/index.css" rel="stylesheet" />--%>
<script src="Scripts/jquery-1.7.1.min.js"></script>
<script src="Scripts/jquery-ui-datepicker.js"></script>
<script src="Scripts/contract.js"></script>
<link rel="stylesheet" type="text/css" href="css/jquery-ui.css" />


<script>
        //地址下拉框选择事件
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

            table span {
                margin-left:4%;
            }

        .Information {
            height:100%;
        }
        .header {
            background-color:#2365C4;
            height:5%;
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
            margin-left:4%;
        }

        #payfang {
            width:80%;
        }

        #BuyAdes1 {
            width:90%;
            font-size:50px;
            overflow:hidden;
            margin-left:4%;
        }

        #fukuan {
            width:90%;
            font-size:50px;
            margin-left:4%;
        }

        #BuyTable img {
            width:60px;
            height:60px;
            float: right;
        }

    </style>
</head>
<body>
<form id="form1" runat="server" onkeypress="if(event.keyCode==13){return false;}" >
    <table  class="Information" width="100%" border="0" style="border-style: none; border-width: medium; padding: 0px; margin: 0px;">
        <tr class="header">
            <td style="text-align:left; height:100%;"><img src="img/home.png" title="主页"/></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td  style="text-align:right">
              <input id="Btn_Details" onclick="Goahed();" runat="server" type="button" value="明细" />
            <asp:Button ID="Btn_Save" runat="server" Text="保存" OnClick="Btn_Save_Click"/>
            <asp:Button ID="Btn_Commit" runat="server" Text="提交" OnClick="Btn_Commit_Click" />
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
                            <td><span>卖方名称:</span></td>
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
                        <td><span>买方名称：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input id="payfang" runat="server" type="text" />
                            
                            <img style="cursor: pointer; width: 60px; height: 60px; position:absolute;" alt="选择客户" id="buyerM"
                                src="img/serc.png" />
                        </td>
                    </tr>
                    <tr>
                        <td><span>发货地址：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <select id="BuyAdes1" onchange="getvalue(this)" style="font-size: 50px;">
                                <%=ViewState["address"]  %>
                            </select>
                            <input type="hidden" runat="server" id="BuyAdes" />
                        </td>
                    </tr>
                    <tr>
                        <td><span>联系电话：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input runat="server" id="BuyPhone" type="text" /></td>
                    </tr>
                    <tr>
                        <td><span>运输费用：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input id="feiyong" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td><span>付款方式：</span></td>
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
                        <td><span>履行期限：</span></td>
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
                        <td><span>交货时间：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input id="jiaohuoTime" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td><span>交货地点：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input id="jiaohuoPlace" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td><span>签约时间：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input id="BuyTime" runat="server" type="text"  style="width:80%" />
                        </td>
                    </tr>
                    <tr>
                        <td><span>签约地点：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input id="qianyuePlace" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td><span>签约代表：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input id="Buydb" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td><span>传真：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input id="Buyfax" runat="server" type="text" /></td>
                    </tr>
                    <tr>
                        <td><span>开户行：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input id="Buybank" runat="server" type="text" /></td>
                    </tr>
                    <tr>
                        <td><span>账号：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input id="BuyNumber" runat="server" type="text" /></td>
                    </tr>
                </table>

                <table id="SellTable" width="100%">
                    <tr>
                        <td><span>卖方地址：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input id="SellAde" runat="server" type="text" value="北京市海淀区中关村南大街12号信息楼3层" /></td>
                    </tr>
                    <tr>
                        <td><span>联系电话：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input id="SellPhone" type="text" runat="server" value="010-62166116" /></td>
                    </tr>
                    <tr>
                        <td><span>签约时间：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input id="SellTime" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td><span>签约代表：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input id="Selldb" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td><span>传真：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input id="Sellfax" type="text" runat="server" value="010-62166156" /></td>
                    </tr>
                    <tr>
                        <td><span>开户行：</span></td>
                    </tr>
                    <tr>
                        <td>
                            <input id="Sellbank" type="text" runat="server" value="农行北京白石桥支行" /></td>
                    </tr>
                    <tr>
                        <td><span>账号：</span></td>
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
