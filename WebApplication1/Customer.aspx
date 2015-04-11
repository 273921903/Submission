<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="COFCOsubmission.Custter" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>客户档案信息</title>
<%--<link href="css/Customer.css" rel="stylesheet" />--%>
<style type="text/css">
        body{font-size:50px;}
        input{font-size:40px;}
    </style>
<script src="Scripts/jquery-1.7.1.min.js"></script>
<script>
        $(function () {
            $("#SearchText").click(function () {
                $(this).val("");
            })

            $("#CustGiv tr").find("th:eq(0)").css("display", "none");
            $("#CustGiv tr").find("th:eq(1)").css("display", "none");
            $("#CustGiv tr").find("th:eq(3)").css("display", "none");

            $("#CustGiv tr").find("td:eq(0)").css("display", "none");
            $("#CustGiv tr").find("td:eq(1)").css("display", "none");
            $("#CustGiv tr").find("td:eq(3)").css("display", "none");

            $("#CustGiv tr td").click(function () {
                //td 序号从0开始
                //客商编码
                window.opener.document.getElementById("custcode").value = $(this).parent().find("td:eq(1)").text();
                //买方
                window.opener.document.getElementById("payfang").value = $(this).text();
                //传真
                window.opener.document.getElementById("Buyfax").value = $(this).parent().find("td:eq(3)").text();
                
                alert($(this).parent().find("td:eq(1)").text());
                //发货地址下框清空项
                window.opener.document.getElementById("BuyAdes1").options.length = 0;
                $.ajax({
                    type: "GET",
                    contentType: "application/json; charset=utf-8",
                    url: "Customer.aspx/queryAddress?custcode='" + $(this).parent().find("td:eq(1)").text() + "'",
                    dataType:"json",
                    success: function (data) {
                        //返回的数据用data.d获取内容
                        alert(data.d);
                        window.opener.document.getElementById("BuyAdes1").innerHTML = data.d
                        
                        window.close();
                    },
                    error: function (err) {
                        alert(err);
                    }
                });// end ajax
            });
        });
    </script>
</head>
<body>
<form id="form2" runat="server">
  <table align="center" width="100%" style="margin-top:0px" cellpadding="0px" cellspacing="0px">
    <tr style="background-color:#2461BF; text-align:center; height:40px;">
      <td align="right" colspan="2">
          <input type="button" value="关闭" onClick="javascript: window.close();"/>
      </td>
    </tr>
      <tr><td style="height:10px;"></td></tr>
    <tr>
      <td align="left" style="height: 26px" colspan="2"> 客户名称:
        <asp:TextBox ID="SearchText" runat="server" Text="请输入查询关键字" AutoPostBack="True" OnTextChanged="SearchText_TextChanged"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="查询" OnClick="Button1_Click" />              
	 </td>
    </tr>
    <tr>
      <td colspan="2"><table>
          <tr>
            <td colspan="2"><div class="Menu">
                <asp:GridView ID="CustGiv" runat="server" AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" Width="100%">
                  <AlternatingRowStyle BackColor="White" />
                  <Columns>
                  <asp:BoundField DataField="pk_supplier" HeaderText="标示符" ReadOnly="True" />
                  <asp:BoundField DataField="custcode" HeaderText="客商编码" />
                  <asp:BoundField DataField="custname" HeaderText="客商名称" ReadOnly="True">
                    <HeaderStyle Font-Size="50px" HorizontalAlign="Center" />
                    <ItemStyle Font-Size="50px" />                  </asp:BoundField>
                  <asp:BoundField DataField="remark" HeaderText="传真" />
                  </Columns>
                  <EditRowStyle BackColor="#2461BF" />
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" VerticalAlign="Middle" />
                  <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
              </div></td>
          </tr>
        </table></td>
    </tr>
  </table>
</form>
</body>
</html>
