<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractInfo.aspx.cs" Inherits="COFCOsubmission.ContractInfo1" EnableEventValidation="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0" />
    <title>合同明细</title>
    <link href="css/index.css" rel="stylesheet" />
    <style type="text/css">
        boby {
            margin:0 0;
        }
        input{
     font-size:15px;
     width:60px;
}
    </style>
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script>
        $(function () {
            //弹出存货选择页面
            $("#bntChoice").click(function () {
                window.open("productInfo.aspx", "存货信息", "height=100%, width=100%, top=0, left=0,toolbar=no, menubar=no, scrollbars=no, resizable=no, location=n o, status=no");
            })

            $("#GridView1 tr").find("th:eq(0)").css("display", "none");
            $("#GridView1 tr").find("td:eq(0)").css("display", "none");

            $("#GridView1 tr").find("th:eq(4)").css("display", "none");
            $("#GridView1 tr").find("td:eq(4)").css("display", "none");

            var oldcolor = "";

            //选行事件
            $("#GridView1 tr").click(function () {
                var index = $(this).index();
                var rows = $("#GridView1 tr").length;
                if ($(this).attr("class") != "check" && index>0)
                {
                        oldcolor = $(this).css("background-color");
                        $(this).css("background-color", "#0094ff");
                        $(this).addClass("check");
                        for (var i = 1; i < rows; i++)
                        {
                            var zt = $("#GridView1 tr").eq(i).attr("class");
                            if ( zt == "check" && index!==i)
                            {
                                $("#GridView1 tr:eq(" + i + ")").attr("class","");
                                $("#GridView1 tr:eq(" + i + ")").css("background-color", oldcolor);
                            }
                        }
                }
            })

            $(document).keydown(function () {
                if (event.keyCode == 116) {
                    event.keyCode = 0;
                    event.cancelBubble = true;
                    return false;
                }
            })
            
            //删除按钮事件
            $("#btnDelet").click(function () {
                var id = "";
                var mainid="";
                var len = $("#GridView1 tr").length;
                mainid = $("#TextBox1").val();
                
                for(var i=1;i<len;i++)
                {
                    if($("#GridView1 tr").eq(i).attr("class")=="check")
                    {
                        id = $("#GridView1 tr").eq(1).find("td").eq(0).text();
                        $.ajax({
                            type: "GET",
                            contentType: "application/json; charset=utf-8",
                            url: "ContractInfo.aspx/btnDelet_Click?code='" + id + "'",
                            //data: "{code:'" + id + "'}",
                            dataType: "json",
                            success: function (data) {
                                location.replace("ContractInfo.aspx?from=main&id=" + mainid);
                            },
                            error: function (err) {
                                alert(err);
                            }
                        })
                    }
                }
            })
            //确认
            $("#btnSubmit").click(function () {
                var mainid = $("#TextBox1").val();
                //总行数
                var len = $("#GridView1 tr").length;

                var items="";

                for (var i = 1; i < len; i++) {
                    var id = $("#GridView1 tr").eq(i).find("td").eq(0).text();
                    var num = $("#GridView1 tr").eq(i).find("td").eq(5).find("input").val();
                    var price = $("#GridView1 tr").eq(i).find("td").eq(6).find("input").val();
                    var money = $("#GridView1 tr").eq(i).find("td").eq(7).find("input").val();

                    var item = id + "@" + num + "@" + price + "@" + money;

                    items += item;
                    if (i < len - 1) {
                        items+="|"
                    }
                }
                //alert(items);
                $.ajax({
                    type: "GET",
                    contentType: "application/json; charset=utf-8",
                    url: "ContractInfo.aspx/btnSubmit_click?items='" + items+"'",
                    //data:"items="+SEND_JSON,
                    dataType: "json",
                    success: function (data) {
                        alert("保存成功!");
                        location.replace("ContractInfo.aspx?from=main&id=" + mainid);
                    },
                    error: function (err) {
                        alert(err);
                    }
                })
            })

            $("#GridView1").find("input").live('focusout',function () {
                var num = $(this).parent().parent().find("td").eq(5).find("input").val()
                var prace = $(this).parent().parent().find("td").eq(6).find("input").val()
                $(this).parent().parent().find("td").eq(7).find("input").val(num * prace)
            })


        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <table width="100%" align="center" cellpadding="0px" cellspacing="0px" style="margin-top:0px">
         
            <tr style="background-color:#2461BF; text-align:center; height:5%;">
              <td style="text-align:left">
                  <a href="Contract.aspx?id=<%=Session["id"]%>">
                  <img src="img/goback.png" title="返回" width="35px" height="35px"/>
                   </a>
              </td>
              <td  style="text-align:right">
                  <input id="bntChoice" type="button" value="新增" />
                  <input id="btnDelet" runat="server"  type="button" value="删除" />
                  <input id="btnSubmit" type="button" value="保存" />
                  <input id="TextBox1" type="text" runat="server" style="display:none" />
              </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" EnableModelValidation="True"  >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="sid" HeaderText="编码" />
                            <asp:BoundField DataField="invname" HeaderText="存货名称" />
                            <asp:BoundField DataField="measname" HeaderText="单位">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="invspec" HeaderText="规格">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="measrate" HeaderText="转换率">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="数量">
                                <ItemTemplate>
                                   <asp:TextBox ID="textNum" runat="server" Width="50px" Text='<%# Eval("num").ToString()%>'>
                                
                                   </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="单价">
                                <ItemTemplate>
                                    <asp:TextBox ID="textPrice" runat="server" Width="50px" Text='<%# Eval("price").ToString()%>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="金额">
                                <ItemTemplate>
                                    <asp:TextBox ID="textNmoney" runat="server" Width="50px" Text='<%# Eval("nmoney").ToString()%>'></asp:TextBox>
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
