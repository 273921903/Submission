/// <reference path="jquery-1.7.1.min.js" />

$(function () {

    //$.ajax({
    //    type: "POST",
    //    contentType: "application/json; charset=utf-8",
    //    url: "WebService.asmx/getName",
    //    data: "",
    //    dataType: "json",
    //    success: function (data) {
    //        //alert(data.d);
    //        $("#Selldb").val(data.d);

    //    },
    //    error: function (err) {
    //        alert(err);
    //    }
    //})



    $("#httable").show();
    $("#BuyTable").hide();
    $("#SellTable").hide();
    $(".Merchants").hide();
    $(".tab ul").find("li").eq(0).css("background-color", "#808080");

    $(".tab ul li").click(function () {
        var i = $(this).index();
        
        $(".tab ul li").each(function () {
            var n = $(this).index();
            if (n == i) {
                $(this).css("background-color", "#808080");
            } else {
                $(this).css("background-color", "#1b2a52");
            }
        })

        $(".List table").each(function () {
            var n = $(this).index();
            if (n == i) {
                $(this).show(300);
            } else {
                $(this).hide();
            }
        })

        /////根据客商编码带出客商传真
        //if (i == 1) {
        //    $.ajax({
        //        //要用post方式 
        //        type: "POST",
        //        contentType: "application/json; charset=utf-8",
        //        //方法所在页面和方法名     
        //        url: "WebService.asmx/getFax",
        //        data: "",
        //        dataType: "json",
        //        success: function (data) {
        //            //返回的数据用data.d获取内容
        //            alert(data.d);
        //            $("#Buyfax").val(data.d);

        //        },
        //        error: function (err) {
        //            alert(err);
        //        }
        //    });
        //}
    })


    

    /*选择客商*/
    $("#buyerM").click(function () {
        window.open("Customer.aspx", "客商信息", "height=100%, width=100%, top=0, left=0,toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no")
        //window.open("Customer.aspx", "客商信息","height=500px, width=600px");
    })




    /*客商模糊查询*/
    $("#SearchText").keydown(function (e) {
        if (e.keyCode == 13)
        {
            var str = $(this).val();
            //alert(str);
            $.ajax({
                //要用GET方式 
                type: "GET",
                contentType: "application/json; charset=utf-8",
                //方法所在页面和方法名     
                url: "Contract.aspx/GetMerInfo?str='"+str+"'",
                //data: "{'str':'" + str + "'}",
                //dataType: "json",
                success: function (data) {
                    //返回的数据用data.d获取内容

                    $(".Menu").html(data.d);

                },
                error: function (err) {
                    alert(err);
                }
            });
        }
    })

    $("#SearchText").mousedown(function () {
        $(this).val(null);
    })

    //$("#BuyinfoNext").click(function () {

    //    var contract = {};

    //    //相当于:WebService.asmx/MainInfo?param=1,2,3
    //    var param = $("#maif").val() + "￥";
    //    param += $("#payfang").val() + "￥";
    //    param += $("#hetongNum").val() + "￥";
    //    param += $("#qianyuePlace").val() + "￥";
    //    param += $("#jiaohuoTime").val() + "￥";
    //    param += $("#jiaohuoPlace").val() + "￥";
    //    param += $("#feiyong").val() + "￥";
    //    param += $("#fukuan").val() + "￥";
    //    param += $("#lvxingTime").val() + "￥";
    //    param += $("#Buydb").val() + "￥";
    //    param += $("#BuyAde").val() + "￥";
    //    param += $("#BuyPhone").val() + "￥";
    //    param += $("#Buyfax").val() + "￥";
    //    param += $("#Buybank").val() + "￥";
    //    param += $("#BuyNumber").val() + "￥";
    //    param += $("#BuyTime").val() + "￥";
    //    param += $("#Selldb").val() + "￥";
    //    param += $("#SellAde").val() + "￥";
    //    param += $("#SellPhone").val() + "￥";
    //    param += $("#Sellfax").val() + "￥";
    //    param += $("#Sellbank").val() + "￥";
    //    param += $("#SellNumber").val() + "￥";
    //    param += $("#SellTime").val();


    //    var x = 0;
    //    $(".mation input").each(function () {
    //        if ($(this).val() == "") {
    //            x++;
    //        }
    //    })


        

    //    if (x == 0) {
    //        $.ajax({
    //            type: "POST",
    //            contentType: "application/json; charset=utf-8",
    //            //url: "WebService.asmx/MainInfo",
    //            url: "Contract.aspx",
    //            data:"param=tt",
    //            //data: "{contract:'" + param + "'}",
    //            //dataType: "json",
    //            //traditional: true,
    //            success: function (data) {
    //                //返回的数据用data.d获取内容
    //                if (data.d == "") {
    //                    alert("合同信息添加成功！");
                        
    //                } else {
    //                    alert(data.d);
    //                }
    //            },
    //            error: function (err) {
    //                alert(err);
    //            }
    //        });
    //    } else {
    //        alert("请将信息填写完整")
    //    }



    //})
    
})