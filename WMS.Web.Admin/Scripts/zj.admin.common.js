$("#checkall").click(function () {
    var ischecked = this.checked;
    $("input:checkbox[name='ids']").each(function () {
        this.checked = ischecked;
    });
});

$("#delete").click(function () {
    var message = "你确定要删除勾选的记录吗?";
    if ($(this).attr("message"))
        message = $(this).attr("message") + "，" + message;
    if (confirm(message)) {
        //加入判断，判断是否勾选了记录
        //TODO:JingWeb
        var ids = "";
        $('input[name="ids"]:checked').each(function () {
            ids += $(this).val() + ',';
        });
        var str = ids.substring(0, ids.lastIndexOf(","));
        if (str.length <= 0) {
            alert('您没有勾选记录');
        } else {
            $("#mainForm").submit();
        }
    }
});

//TODO:zhangjing增加
$("#getCheck").click(function () {
    var message = "您确认选择勾选的记录么?";
    if ($(this).attr("message"))
        message = $(this).attr("message") + "，" + message;
    if (confirm(message)) {
        //加入判断，判断是否勾选了记录
        //TODO:JingWeb
        var ids = "";
        $('input[name="ids"]:checked').each(function () {
            ids += $(this).val() + ',';
        });
        var str = ids.substring(0, ids.lastIndexOf(","));
        if (str.length <= 0) {
            alert('您没有勾选记录');
        } else {
            $("#mainForm").submit();
        }
    }
});

//Edit Script
$(document).ready(function () {
    $("#cancel").click(function () {
        window.parent.tb_remove();
    });

    var mainForm = $("#submit").parent().parent();
    mainForm.submit(function () {
        if (mainForm.valid()) {
            $("#submitloading").show();
        } else {
            $(".validation-summary-errors").hide(8000);
        }
    });

    //$("input[type='text']").blur(function () { $(this).removeClass("highlight"); }).focus(function () { $(this).addClass("highlight"); });
    //$(".integer").numeric(false, function () { alert("只能输入数字"); this.value = ""; this.focus(); });
});
//Edit Script End