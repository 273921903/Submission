/// <reference path="jquery-1.7.1.min.js" />
$(function () {
    /*文本框单击事件*/
    $("#SearchText").mousedown(function () {
        $(this).val(null);
    })

    /*模糊查询*/
    $("#SearchText").keydown(function (e) {
        if (e.keyCode == 13) {
            var str = $(this).val();
            //alert(str);
            $.ajax({
                //要用post方式 
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //方法所在页面和方法名     
                url: "WebService.asmx/Getdata",
                data: "{str:'" + str + "'}",
                dataType: "json",
                success: function (data) {
                    //返回的数据用data.d获取内容

                    $(".List").html(data.d);

                },
                error: function (err) {
                    alert(err);
                }
            });
        }
    })

    $(".order").show();
    $(".trolley").hide();
    $(".tab ul").find("li").eq(0).css("background-color", "#808080");

    /*选卡切换*/
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

        $(".items>div").each(function () {
            var n = $(this).index();
            if (n == i) {
                $(this).show(300);
            } else {
                $(this).hide();
            }
        })

        if (i == 1) {
            $.ajax({
                //要用post方式 
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //方法所在页面和方法名     
                url: "WebService.asmx/DetailHtml",
                data: "{str:'" + str + "'}",
                dataType: "json",
                success: function (data) {
                    //返回的数据用data.d获取内容

                    $(".trolley").html(data.d);

                },
                error: function (err) {
                    alert(err);
                }
            });
        }
    })



})