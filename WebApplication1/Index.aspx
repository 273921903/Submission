<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="COFCOsubmission.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/index.css" rel="stylesheet" />
</head>
<body onselectstart="return false">
    <form id="form1" runat="server">

    <div class="box1">
            <div class="meaniu">
                <ul>
                    <li>
                        <a id="placeOrder" href="Contract.aspx">
                            <img src="img/pencil.png" />
                            <span>我要下单</span>
                        </a>
                    </li>
                    <li>
                        <a>
                            <img src="img/layout.png"/>
                            <span>我的订单</span>
                        </a>
                    </li>
                    <li>
                        <a>
                            <img src="img/docs.png" />
                            <span>生产计划</span>
                        </a>
                    </li>
                </ul>
            </div>
        </div>

    </form>
</body>
</html>
