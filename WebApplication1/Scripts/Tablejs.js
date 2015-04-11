/// <reference path="jquery-1.7.1.min.js" />
$(function () {


    


    //$("tr").each(function () {
    //    $(this).find("th:first").css("display", "none");
    //    $(this).find("td:first").css("display", "none");
    //    $(this).find("td").eq(1).css("width", "55%");
    //    $(this).find("td").eq(2).css("width", "15%");
    //    $(this).find("td").eq(3).css("width", "15%");
    //    $(this).find("td").eq(3).css("width", "15%");

    //})

    //$(".product #Confirmation").click(function () {
    //    var $tr = $(this).parent().parent();
    //    var producId = $tr.find("td").eq(0).html();
    //    var num = $tr.find("td").eq(3).find("#productNum").val();
    //})

    $(".MerInfo tr").each(function () {
        $(this).find("th:first").css("display", "none");
        $(this).find("td:first").css("display", "none");
        $(this).find("td").eq(1).css("width", "15%");
        $(this).find("td").eq(1).css("text-align", "center");
        $(this).find("td").eq(2).css("width", "85%");


    })

    $(".List").animate({ "top": 0 });


    /*存货项确认按钮事件*/
    $(".product #Confirmation").click(function () {
        var $tr = $(this).parent().parent();
        var producId = $tr.find("td").eq(0).html();
        var num = $tr.find("td").eq(3).find("#productNum").val();
        if (num == 0) {
            alert("请输入数量！")
        } else {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/insertDetail",
                data: "{producId:'" + producId + "',num:'" + num + "'}",
                dataType: "json",
                success: function (data) {
                    //alert(data.d);
                },
                error: function (err) {
                    alert(err);
                }
            })
        }
    })


    $("#SureGiv #proNum").keyup(function () {
        var num = $(this).val();
        var price = $(this).parents().parents().find("#prace").val();
        if (!IsNum($(this).val())) {
            num = 0;
        }

        if (!IsNum(price)) {
            price = 0;
        }
        $(this).parents().parents().find("td").eq(5).html(num * price);
        
    })


    $("#SureGiv #prace").keyup(function () {
        var price = $(this).val();
        var num = $(this).parents().parents().find("#proNum").val();
        if (!IsNum($(this).val())) {
            price = 0;
        }

        if (!IsNum(num)) {
            num = 0;
        }
        $(this).parents().parents().find("td").eq(5).html(num * price);
    })

    function IsNum(num){
        var reNum=/^\d*$/;
        return(reNum.test(num));
    }
   
})