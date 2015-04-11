/// <reference path="jquery-1.7.1.js" />
/// <reference path="jquery-1.7.1.intellisense.js" />
/// <reference path="jquery-1.7.1.min.js" />



$(function () {

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/getName",
        data: "",
        dataType: "json",
        success: function (data) {
            //alert(data.d);
            $("#Selldb").val(data.d);

        },
        error: function (err) {
            alert(err);
        }
    })


    $("div .Information").show();
    $("div .Merchants").hide();
    $("div .order").hide();
    $("div .SureBox").hide();
    $("div .myorder").show();
    $("div .OrderDetail").hide();


    var height = $(window).height();
    $(".swiper-container").height(height);
    var width = $(".swiper-container").width();
    var marginBottom = parseInt($(".List").css("bottom"));//list距离底部距离
    

    $("#placeOrder").click(function () {
        $(".Information #maif").val("中粮（北京）饲料科技有限公司");
        $(".Information payfang").val("");
        $(".Information hetongNum").val("");
        $(".Information #qianyuePlace").val("");
        $(".Information #jiaohuoTime").val("");
        $(".Information #jiaohuoPlace").val("");
        $(".Information #feiyong").val("");
        $(".Information #lvxingTime").val("");
        $(".Information #Selldb").val("");
        $(".Information #SellAde").val("");
        $(".Information #SellPhone").val("");
        $(".Information #Sellfax").val("");
        $(".Information #Sellbank").val("");
        $(".Information #SellNumber").val("");
        $(".Information #SellTime").val("");
        $(".Information #Buydb").val("");
        $(".Information #BuyAde").val("北京市海淀区中关村南大街12号信息楼3层");
        $(".Information #BuyPhone").val("010-62166116");
        $(".Information #Buyfax").val("010-62166156");
        $(".Information #Buybank").val("农行北京白石桥支行");
        $(".Information #BuyNumber").val("11-050501040016046");
        $(".Information #BuyTime").val("");


        var i = 0;
        var boxs = $(".box");
        $.each(boxs, function () {
            var top = 0 - height * i;
            var left = width * i - width;
            $(this).css("top", top);
            $(this).animate({
                left: left
            });
            i++;
        })
    })


    $("#home").click(function () {
        var i = 0;
        var boxs = $(".box");
        $.each(boxs, function () {
            var top = 0 - height * i;
            var left = width * i;
            $(this).css("top", top);
            $(this).animate({
                left:left
            });
            i++;
        })
    })


    var i = 0;
    var boxs = $(".box");
    $.each(boxs, function () {
        var top = 0 - height * i;
        var left = width * i;
        $(this).css("top", top);
        $(this).css("left", left);
        i++;
    })

    window.onresize = function () {
        var height = $(window).height();
        var width = $(".swiper-container").width();
        $(".List").animate({ "top": 0 });//list复位
        marginBottom = parseInt($(".List").css("bottom"));//随时获取List距离底部的距离
        $(".swiper-container").height(height)
        var i = 0;
        var boxs = $(".box");
        $.each(boxs, function () {
            if ($(this).position().left == 0)
            {
                var y = 0;
                $.each(boxs, function () {
                    var v = y - i;
                    $(this).css("left", v * width);
                    var top = 0 - height * y;
                    $(this).css("top", top);
                    y++;
                })
            }       
            i++;
        })
    }


/*横向滑动界面*/
    var moveNun = 0;//鼠标移动x轴偏移量
    var offsets = {};//移动之前DIV的位置
    var boxN = {};
    var lengh=$(".box").length;
    $(".swiper-container").mousedown(function (e) {
        $(this).css("cursor", "move");

        var boxs = $(".box");
        var i = 0;
        $.each(boxs, function () {
            offsets[i] = $(this).position().left;
            i++;
        })
        
        var x = e.pageX;
        $(document).bind("mousemove", function (ev) {
            $(".swiper-container").stop();
            var _x = ev.pageX - x;
            var i = 0;
            var offset;
            $.each(boxs, function () {
                //如果当前是第一屏且移动方向向右则跳出该循环
                if (offsets[0] == 0) {
                    if (_x > 0) {
                        return false;
                    }
                }
                //如果当前是最后一屏且移动方向向左则跳出该循环
                if (offsets[lengh - 1] == 0) {
                    if (_x < 0) {
                        return false;
                    }
                }
                offset = offsets[i];
                $(this).css("left", offset + _x);
                i++;
            })
            moveNun = _x;

            
        })
        
    })

    //释放鼠标事件
    $(document).mouseup(function (e) {


        var divWidth = $(".swiper-container").width() / 2;
        //alert(moveNun);
        var num = moveNun / divWidth;
        //alert(num);
        var i = 0;
        //向左滑动
        if (moveNun < 0) {
            if (offsets[lengh - 1] != 0) {          //判断当前最后一页的位置，如果当前显示为最后一页这不执行释放鼠标当中的动作。

                //向左滑动不超过50%则回到原位置
                if (num >= -1) {
                    var boxs = $(".box");
                    $.each(boxs, function () {
                        $(this).animate({
                            left: offsets[i]
                        })
                        i++;
                    })
                }
                //alert(num);
                //向左滑动超过50%则显示下一页面
                if (num < -1) {
                    var boxs = $(".box");
                    var moveLeft = 0;
                    $.each(boxs, function () {
                        //算出移动后DIV的left距离
                        offsets[i] = offsets[i] - divWidth * 2;
                        //moveLeft = offsets[i];
                        //alert(moveLeft);
                        $(this).animate({
                            left: offsets[i]
                        })
                        i++;
                    })
                }

            } 
        }
        //向右滑动
        if (moveNun > 0) {
            if (offsets[0] != 0) {          //判断当前显示是否为第一页，如果为第一页则不执行释放鼠标事件中的动作；

                //向右滑动不超过50%则回到原位置
                if (num <= 1) {
                    var boxs = $(".box");
                    $.each(boxs, function () {
                        $(this).animate({
                            left: offsets[i]
                        })
                        i++;
                    })
                }

                //向右滑动超过50%则显示下一页面
                if (num > 1) {
                    var boxs = $(".box");
                    //var moveLeft = 0;
                    $.each(boxs, function () {
                        //算出移动后DIV的left距离
                        offsets[i] = offsets[i] + divWidth * 2;
                        //moveLeft = offsets[i];
                        //alert(moveLeft);
                        $(this).animate({
                            left: offsets[i]
                        })
                        i++;
                    })
                }

            }
        }
        moveNun = 0;
        $(document).unbind("mousemove");
        $(".swiper-container").css("cursor", "default");

        /*页头显示*/
        if (offsets[0] + divWidth * 2 <= 0) {
            if ($("#header").position().top < 0)
            {
                $("#header").animate({
                    top:0+'px'
                })
            }
        }

        if (offsets[0] == 0)
        {
            $("#header").animate({
            top: -100 + 'px'
        })
        }
    })


    var newList;
    //列表垂直拖动
    $(".List").mousedown(function (e) {
        var offset = $(".List").offset();
        var y = e.pageY - offset.top;
        newList = $(this);
        
        $(document).bind("mousemove", function (ev) {

            $(".List").stop();
            var _y = ev.pageY - y;
            var listY = newList.position().top;
            //$(".List").css("top", _y - listY + "px");
                //alert($(".List div").height())
            //newList.css("top", _y - listY);
            newList.animate({ "top": _y - listY },100);
                
        })
    })
    $(document).mouseup(function () {
        newList.unbind("mousmove");
        var liveTop;
        liveTop = newList.position().top;
        if (liveTop >= 0) {
            newList.animate({ "top": 0 });
        }
        //var divHeight = 0 - $(".List div").height();
        //alert(liveTop);
        marginBottom = parseInt(newList.css("bottom"));
        if (newList.height() > $(".box").height() - 38 - 23 - 30) {
            
            if (marginBottom > 30) {
                var a = $(".box").height() - 38 - 23 - 30;
                newList.animate({ "top": a - newList.height() });
            }
        } else {
            if (marginBottom > 30) {
                newList.animate({ "top": 0 });
            }
        }
        
    })
    


    /*文本框内容发生改变时触发事件*/
    $("#SearchText").keyup(function () {
        var text = $("#SearchText").val();
        $.ajax({
            //要用post方式 
            type: "POST",
            contentType: "application/json; charset=utf-8",
            //方法所在页面和方法名     
            url: "WebService.asmx/Getdata",
            data: "{str:'" + text + "'}",
            dataType: "json",
            success: function (data) {
                //返回的数据用data.d获取内容
                
                $(".product").html(data.d);
                
            },
            error: function (err) {
                alert(err);
            }
        });
    })


    /*客商文本框的值发生变化的时候*/
    $("#MerchantsText").keyup(function () {
        var text = $("#MerchantsText").val();
        $.ajax({
            //要用post方式 
            type: "POST",
            contentType: "application/json; charset=utf-8",
            //方法所在页面和方法名     
            url: "WebService.asmx/GetMerInfo",
            data: "{str:'" + text + "'}",
            dataType: "json",
            success: function (data) {
                //返回的数据用data.d获取内容
                $(".MerInfo").html(data.d);
            },
            error: function (err) {
                alert(err);
            }
        });
    })



    /*存货项确认按钮事件*/
    $(".product #Confirmation").click(function () {
        var $tr = $(this).parent().parent();
        var producId = $tr.find("td").eq(0).html();
        var num =$tr.find("td").eq(3).find("#productNum").val();
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

    $(".product tr").each(function () {
        $(this).find("th:first").css("display", "none");
        $(this).find("td:first").css("display", "none");
        $(this).find("td").eq(1).css("width", "55%");
        $(this).find("td").eq(2).css("width", "15%");
        $(this).find("td").eq(3).css("width", "15%");
        $(this).find("td").eq(3).css("width", "15%");

    })

    $(".MerInfo tr").each(function () {
        $(this).find("th:first").css("display", "none");
        $(this).find("td:first").css("display", "none");
        $(this).find("td").eq(1).css("width", "15%");
        $(this).find("td").eq(1).css("text-align", "center");
        $(this).find("td").eq(2).css("width", "85%");


    })

    $(".SureBox tr").each(function () {
        $(this).find("th:first").css("display", "none");
        $(this).find("td:first").css("display", "none");
        $(this).find("td").eq(2).css("width", "55%");
        $(this).find("td").eq(2).css("text-align", "center");
        $(this).find("td").eq(3).css("text-align", "center");
        $(this).find("td").eq(3).css("width", "15%");
        $(this).find("td").eq(4).css("text-align", "center");

    })

    //function Que() {
    //    alert("111");
    //    $("List #Confirmation").each(function () {
    //        if ($(this).checked) {
    //            var $tr = $(this).parent().parent();
    //            var producName = $tr.find("td").eq(0).html();
    //            var num = $tr.find("td").eq(1).find("#productNum").val();
    //            alert(num);
    //        }
    //    })
    //}
    
    
    //客商返回到合同详情
    $("#MerUp").click(function () {
        $("div .Merchants").hide();
        $("div .Information").show();
    })
    
    /*客商确认下一步*/
    $("#MerNext").click(function () {

        var n = 0;
        var payNun = "";
        var payName = "";
        $(".MerInfo #MerCheckbox").each(function () {
            if (this.checked == true) {
                var farther = $(this).parents().parents();
                payNun = farther.find("td").eq(0).html();
                payName = farther.find("td").eq(2).html();
                n++;
            }
        })
        if (n > 1) {
            alert("只能选择一个客户");
        } else if (n == 0) {
            alert("请勾选客户");
        } else {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/savePayNum",
                data: "{str:'" + payNun + "'}",
                dataType: "json",
                success: function (data) {
                    //返回的数据用data.d获取内容
                },
                error: function (err) {
                    alert(err);
                }
            });

            $(".hetong #payfang").val(payName);
            $("div .Merchants").hide();
            $("div .Information").show();
        }
    })

    /*合同信息选择客户*/
    $("#buyerM").click(function () {

        $("div .Merchants").show();
        $("div .Information").hide();
    })

    /*合同信息下一步*/
    $("#mationNext").click(function () {

        var contract = {};

        //相当于:WebService.asmx/MainInfo?param=1,2,3
        var param = $("#maif").val()+"￥";
        param += $("#payfang").val() + "￥";
        param += $("#hetongNum").val() + "￥";
        param += $("#qianyuePlace").val() + "￥";
        param += $("#jiaohuoTime").val() + "￥";
        param += $("#jiaohuoPlace").val() + "￥";
        param += $("#feiyong").val() + "￥";
        param += $("#fukuan").val() + "￥";
        param += $("#lvxingTime").val() + "￥";
        param += $("#Selldb").val() + "￥";
        param += $("#SellAde").val() + "￥";
        param += $("#SellPhone").val() + "￥";
        param += $("#Sellfax").val() + "￥";
        param += $("#Sellbank").val() + "￥";
        param += $("#SellNumber").val() + "￥";
        param += $("#SellTime").val() + "￥";
        param += $("#Buydb").val() + "￥";
        param += $("#BuyAde").val() + "￥";
        param += $("#BuyPhone").val() + "￥";
        param += $("#Buyfax").val() + "￥";
        param += $("#Buybank").val() + "￥";
        param += $("#BuyNumber").val() + "￥";
        param += $("#BuyTime").val();


        var x=0;
        $(".mation input").each(function () {
            if ($(this).val() == "")
            {
                x++;
            }
        })


        /*
        contract["contractInfo[1].Buyer"] = $("#payfang").val();
        contract["contractInfo[1].ContractID"] = $("#hetongNum").val();
        contract["contractInfo[1].SigningAddress"] = $("#qianyuePlace").val();
        contract["contractInfo[1].DeliveryTime"] = $("#jiaohuoTime").val();
        contract["contractInfo[1].DeliveryAddress"] = $("#jiaohuoPlace").val();
        contract["contractInfo[1].Transport"] = $("#feiyong").val();
        contract["contractInfo[1].PaymentType"] = $("#fukuan").val();
        contract["contractInfo[1].PerformTime"] = $("#lvxingTime").val();
        contract["contractInfo[1].SellerRep"] = $("#Selldb").val();
        contract["contractInfo[1].SellerAddress"] = $("#SellAde").val();
        contract["contractInfo[1].SellerPhone"] = $("#SellPhone").val();
        contract["contractInfo[1].SellerFax"] = $("#Sellfax").val();
        contract["contractInfo[1].SellerOpebank"] = $("#Sellbank").val();
        contract["contractInfo[1].SellerBankId"] = $("#SellNumber").val();
        contract["contractInfo[1].SellersigTime"] = $("#SellTime").val();
        contract["contractInfo[1].BuyerRep"] = $("#Buydb").val();
        contract["contractInfo[1].BuyerAddress"] = $("#BuyAde").val();
        contract["contractInfo[1].BuyerPhone"] = $("#BuyPhone").val();
        contract["contractInfo[1].BuyerFax"] = $("#Buyfax").val();
        contract["contractInfo[1].BuyerOpebank"] = $("#Buybank").val();
        contract["contractInfo[1].BuyerBankId"] = $("#BuyNumber").val();
        contract["contractInfo[1].BuyersigTime"] = $("#BuyTime").val();

        alert(contract["contractInfo[1].Seller"]);
        */

        if (x == 0) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/MainInfo",
                data: "{contract:'" + param + "'}",
                dataType: "json",
                traditional: true,
                success: function (data) {
                    //返回的数据用data.d获取内容
                    $("div .order").show();
                    $("div .Information").hide();
                },
                error: function (err) {
                    alert(err);
                }
            });
        } else {
            alert("请将信息填写完整")
        }
        

        
    })

    /*存货菜单上一步*/
    $("#orderUp").click(function () {
        $("div .Information").show();
        $("div .order").hide();
        $("div .Merchants").hide();
    })

    /*存货菜单下一步*/
    $("#orderNext").click(function () {

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "WebService.asmx/DetailHtml",
            data: "",
            dataType: "json",
            traditional: true,
            success: function (data) {
                //返回的数据用data.d获取内容
                if (data.d == "") {
                    alert("还没有订购任何货物！")
                } else {
                    $(".SureMenu").html(data.d);
                    $("div .order").hide();
                    $("div .SureBox").show();
                }
            },
            error: function (err) {
                alert(err);
            }
        });
    })

    $("#SureUp").click(function () {
        $("div .order").show();
        $("div .SureBox").hide();
    })


    //确认数据
    $("#SureNext").click(function () {
        var tr = {};
        tr = $("#SureGiv tr");
        var input = {};
        input = $("#SureGiv input");
        var a = 0;
        input.each(function () {
            if ($(this).val() == "") {
                a++;
            }
        });
        var str = "";
        if (a == 0) {
            for (var i = 1; i < tr.length; i++) {
                var sid = tr.eq(i).find("td").eq(0).html();
                var invname = tr.eq(i).find("td").eq(1).html()
                var num = tr.eq(i).find("td").eq(3).find("input").val();
                var price = tr.eq(i).find("td").eq(4).find("input").val();
                var allprice = tr.eq(i).find("td").eq(5).html();
                //alert(tr.eq(i).html());

                str = str + sid + "￥";
                str = str + invname + "￥";
                str = str + num + "￥";
                str = str + price + "￥";
                if (i == tr.length - 1) {
                    str = str + allprice
                } else {
                    str = str + allprice + "#";
                }
                
            }

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/sureDetail",
                data: "{str:'" +str+ "'}",
                dataType: "json",
                traditional: true,
                success: function (data) {
                    //返回的数据用data.d获取内容
                    //alert(data.d)
                    if (data.d == true)
                    {
                        alert("合同添加成功")

                        var i = 0;
                        var boxs = $(".box");
                        $.each(boxs, function () {
                            var top = 0 - height * i;
                            var left = width * i - width*2;
                            $(this).css("top", top);
                            $(this).animate({
                                left: left
                            });
                            i++;
                        })

                        contractInfo();
                    }

                },
                error: function (err) {
                    //alert(err);
                    alert("合同添加失败")
                }
            });
            
        } else {
            alert("请将数据填写完整")
        }
        
        //if (str > 0) {
        //    alert()
        //}
        
    })




    /*表单行变色*/
    var background;
    $(".myOrdMain tr").mouseover(function () {
        if ($(this).index() != 0)
        {
        var div = $(this);
        background = div.attr("style");
        div.attr("style", "background-color:#2365C4");
        }
        
    });
    $(".myOrdMain tr").mouseout(function () {
        if ($(this).index() != 0)
        {
            var div = $(this);
            div.attr("style", background);
        }
        
    })


    //获取已下合同
    function contractInfo() {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "WebService.asmx/GetContract",
            data: "",
            dataType: "json",
            traditional: true,
            success: function (data) {
                //返回的数据用data.d获取内容
                //alert(data.d)
                $(".myOrdMain").html(data.d);

            },
            error: function (err) {
                alert(err);
            }
        })
    }



})

