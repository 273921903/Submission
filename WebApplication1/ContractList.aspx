<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractList.aspx.cs" Inherits="COFCOsubmission.ContractList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#GridView1 tr").find("th:eq(0)").css("display", "none");
            $("#GridView1 tr").find("td:eq(0)").css("display", "none");

            $("#GridView1 tr").click(function () {
                var id = $(this).find("td:eq(0)").text();
                location.href = "Contract.aspx?id=" +id;
            })
        })
    </script>
    <title>我的订单</title>
    <style type="text/css">
        body {
            background-color:#5CA3D8;
            margin:0 0;
            position:absolute;
            height:100%;
            width:100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="contranctList" style="width:100%; position:absolute; border-collapse:collapse; height:100%;">
        <tr class="header" style="width:100%; height:5%;background-color:#2365C4;">
            <td style="width:30%;">
                <a href="Index.aspx"><img alt="" src="img/home.png" style="height:5%;position:absolute;top:0px;" /></a></td>
            <td style="width:40%; text-align:center; color:white;">我的订单</td>
            <td style="width:30%;"></td>
        </tr>
        <tr style="overflow-y:scroll; position:absolute;height:95%; width:100%;">
            <td colspan="3" style="width:100%; vertical-align:top; width:100%; position:absolute;">
                <asp:GridView ID="GridView1" runat="server" Height="100%" Width="100%" AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="编号" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="buyer" HeaderText="买方名称" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="deliveryTime" HeaderText="签约时间" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="amountMoney" HeaderText="合同金额">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="状态">
                            <ItemTemplate>
                                <%# Handler(Eval("submitting").ToString()) %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
