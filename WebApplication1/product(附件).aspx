<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product(附件).aspx.cs" Inherits="COFCOsubmission.product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/product.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script src="Scripts/product.js"></script>
</head>
<body>
    <form id="form1" runat="server" onkeypress="if(event.keyCode==13){return false;}">
        <div id="header">
            <div class="gohome radius20">
                <a href="#" id="home">
                    <img title="" alt="" src="img/home.png" />
                </a>
            </div>
            <div class="gomenu radius20">
                <a href="#">
                    <img src="img/contact.png" />
                </a>
            </div>
        </div>


        <div class="main">
            <div class="tab">
                <ul>
                    <li>存货</li>
                    <li>购物车</li>
                </ul>

                <span>保存</span>
            </div>

            <div class="items">
                <div class="order">

                    <div class="Search">
                        <input id="SearchText" type="text" value="输入查询条件" />
                    </div>

                    <div class="List">
                        
                       <%-- <table id="productInfo" style="width:100%;">
                            <tr style="background-color:#bce1ed;">
                                <td style="display: none;">存货编码</td>
                                <td style="width:50%">存货名称</td>
                                <td style="width:25%">规格</td>
                                <td style="width:25%">确认</td>
                            </tr>
                        </table>--%>
                    </div>
                </div>

                <div class="trolley">
                    <table id="trolleytable">
                        <tr>
                            <td>存货详情编号</td>
                            <td>存货名称</td>
                            <td>单价</td>
                            <td>数量</td>
                            <td>金额</td>
                            <td>
                               <a id="del" href="#">删除</a>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
