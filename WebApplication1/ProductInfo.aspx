<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductInfo.aspx.cs" Inherits="COFCOsubmission.ProductInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>存货档案信息</title>
<%--    <link href="css/Customer.css" rel="stylesheet" />--%>
    <style type="text/css">
        body {
            background-color:#5CA3D8;
            margin:0 0;
            position:absolute;
            height:100%;
            width:100%;
        }
        
        .header {
            background-color:#2365C4;
        }
    </style>
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script>
        $(function () {
            $("#SearchText").click(function () {
                $(this).val("");
            })

            $("#CustGiv tr").find("th:eq(0)").css("display", "none");
            $("#CustGiv tr").find("td:eq(0)").css("display", "none");

            $("#CustGiv tr td").click(function () {
                
                var rMeCode = $(this).parent().find("td:eq(0)").text();
                var rMecodeName = $(this).parent().find("td:eq(1)").text();
                var measname = $(this).parent().find("td:eq(2)").text();
                var mainmeasrate = $(this).parent().find("td:eq(3)").text();
                var rMeSpecName = $(this).parent().find("td:eq(4)").text();

                var str = rMeCode+"@"+rMecodeName+"@"+measname+"@"+mainmeasrate+"@"+rMeSpecName;
                
                window.opener.location.href = "ContractInfo.aspx?param=" + str;
                window.close();
                /*
                $.ajax({
                    type: "GET",
                    contentType: "application/json; charset=utf-8",
                    url: "ContractInfo.aspx/AddProductInData?str='" + str + "'",
                    dataType: "json",
                    success: function (data) {
                        if (data.d == true) {
                            window.close();
                        } else {
                            alert("选择失败！")
                        }
                    },
                    error: function (err){
                        alert(err.tostring());
                    }

                })
                */
                
                
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table1" style="width:100%; height:100%; border-collapse:collapse; position:absolute;">
            <tr  class="header" style="height:5%;">
                <td style="width:25%;">
                </td>
                <td style="width:50%; text-align:center;">
                    <span style="font-size:50px;text-align:center;height:100%;">存货档案信息</span>
                </td>
                <td style="text-align:right;width:25%;">
                    <input id="btnCloss"  style="font-size:40px;" type="button" value="关闭" />
                </td>
            </tr>
            <tr style="height:5%;">
                <td><span style="font-size:50px; color:white;">存货名称:</span></td>
                <td><asp:TextBox Font-Size="45px" Width="100%" ID="SearchText" runat="server" Text="请输入查询关键字" AutoPostBack="True" OnTextChanged="SearchText_TextChanged">请输入查询关键字</asp:TextBox></td>
                <td style="text-align:right;width:25%;"><asp:Button Font-Size="40px" ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" /></td>
            </tr>
            <tr style="overflow-y:scroll; width:100%; height:90%; position:absolute;">
                <td colspan="3" style="width:100%;height:100%;position:absolute;">
                    <asp:GridView ID="CustGiv" runat="server" AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" Width="100%" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="rMeCode" HeaderText="存货编码" />
                            <asp:BoundField DataField="rMecodeName" HeaderText="存货名称" ReadOnly="True">
                            <HeaderStyle Font-Size="50px" HorizontalAlign="Center" />
                            <ItemStyle Font-Size="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="measname" HeaderText="单位" >
                                <HeaderStyle Font-Size="50px" HorizontalAlign="Center" />
                                <ItemStyle Font-Size="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="mainmeasrate" HeaderText="转换率">
                                <HeaderStyle Font-Size="50px" HorizontalAlign="Center" />
                                <ItemStyle Font-Size="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="rMeSpecName" HeaderText="规格" ReadOnly="True">
                                <HeaderStyle Font-Size="50px" HorizontalAlign="Center" />
                                <ItemStyle Font-Size="50px" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    <%--<div id="header">
            <div class="gohome radius20">
                <a href="Index.aspx" id="home">
                    主页
                    <img title="" alt="" src="img/home.png" />
                </a>
            </div>
            <span style="font-size:50px;text-align:center;margin-left:30%;line-height:200%;height:100%;">存货档案信息</span>
            <div class="gomenu radius20">
                <a href="#">
                    <img src="img/contact.png" />
                    关闭
                </a>
            </div>
        </div>

        <div class="mation">
                <div class="Search">
                    <span style="font-size:50px; color:white;">存货名称:</span>
                    <asp:TextBox Font-Size="45px" Width="55%" ID="SearchText" runat="server" Text="请输入查询关键字" AutoPostBack="True" OnTextChanged="SearchText_TextChanged">请输入查询关键字</asp:TextBox>
                    <asp:Button Font-Size="40px" ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
                </div>
                <div class="Menu">
                    <asp:GridView ID="CustGiv" runat="server" AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" Width="100%" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="rMeCode" HeaderText="存货编码" />
                            <asp:BoundField DataField="rMecodeName" HeaderText="存货名称" ReadOnly="True">
                            <HeaderStyle Font-Size="50px" HorizontalAlign="Center" />
                            <ItemStyle Font-Size="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="measname" HeaderText="单位" >
                                <HeaderStyle Font-Size="50px" HorizontalAlign="Center" />
                                <ItemStyle Font-Size="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="mainmeasrate" HeaderText="转换率">
                                <HeaderStyle Font-Size="50px" HorizontalAlign="Center" />
                                <ItemStyle Font-Size="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="rMeSpecName" HeaderText="规格" ReadOnly="True">
                                <HeaderStyle Font-Size="50px" HorizontalAlign="Center" />
                                <ItemStyle Font-Size="50px" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
        </div>--%>
    </form>
</body>
</html>
