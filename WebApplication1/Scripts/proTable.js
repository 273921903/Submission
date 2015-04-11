/// <reference path="jquery-1.7.1.min.js" />
$(function () {



    //遍历查询到的存货，验证我的订单里面是否已存在
    var n = $("#productInfo tr").length;
    var code = '';
    for (var i = 1; i < n; i++) {
        if (code.length<=0) {
            code = code + $("#productInfo tr").eq(i).find("td").eq(0).text();
        } else {
            code = code + "@" + $("#productInfo tr").eq(i).find("td").eq(0).text();
        }
    }
    $.ajax({
        //要用post方式 
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //方法所在页面和方法名     
        url: "WebService.asmx/GetCheck",
        data: "{producId:'" + code + "'}",
        dataType: "json",
        success: function (data) {
            //返回的数据用data.d获取内容
            var split = new Array();
            split = data.d.split('@');
            if (split[0].length > 0)
            {
                for (var i = 0; i < split.length; i++) {
                    var y = Number(split[i]) + 1;
                    $("#productInfo tr").eq(y).find("#Confirmation").attr("src", "img/my-slbsxtbB-(1147).png")
                }
            }
            
        },
        error: function (err) {
            alert(err);
        }
    });
    
    $("#Confi").live('click',function () {
        alert("1111");
    })
    
})