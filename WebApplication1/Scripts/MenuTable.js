/// <reference path="jquery-1.7.1.min.js" />

$(function () {
    /*单击客商列表*/
    $("#MenuTable td").click(function () {

        var payNun = $(this).text();

        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "Contract.aspx/savePayNum?str='"+payNun+"'",
            //data: "{str:'" + payNun + "'}",
            //dataType: "json",
            success: function (data) {
                //返回的数据用data.d获取内容
                $("#Buyfax").val(data.d);
            },
            error: function (err) {
                alert(err);
            }
        });


        $(".mation").show(300);
        $(".Merchants").hide();
        $("#payfang").val($(this).text());
    })


    $("#MenuTable tr").each(function () {
        $(this).find("th:first").css("display", "none");
        $(this).find("td:first").css("display", "none");
    })
})