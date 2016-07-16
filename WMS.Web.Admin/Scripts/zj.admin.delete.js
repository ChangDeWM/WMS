/* ZhangJing Add For Delete Script
 *
 *
 *
 *
 *
 */
$("#deleteUser").click(function () {
    bootbox.confirm("您确认要删除选择的记录么?", function (result) {
        if (result) {
            var idList = "";
            $('input[name="ids"]:checked').each(function () {
                idList += $(this).val() + ',';
            });
            var str = idList.substring(0, idList.lastIndexOf(","));
            if (str.length <= 0) {
                //alert('您没有勾选记录');
                bootbox.alert({ message: "您没有勾选记录!",size:"small"});
            } else {
                $.getJSON("/Sys/User/DeleteUser", { 'ids': str },
                    function (data) {
                        if (data == "OK") {
                            var tab = document.getElementById("usertable");
                            var rowLen = tab.rows.length;
                            for (var i = rowLen - 1; i > 0; i--) {
                                var obj = tab.rows[i].cells[0].getElementsByTagName("input")[0];
                                if (obj != null && obj.type == "checkbox" && obj.checked == true) {
                                    var tr = obj.parentNode.parentNode.parentNode;
                                    tr.parentNode.removeChild(tr);
                                }
                            }
                        }
                        else { return false; }
                    });
            }
        }
    });
});

/* 
 * ZhangJing 列表页删除方法脚本
 * 参数 a = id ,b = url, c=msg, d=this
 *
 */
deleteInfo = function (a,b,d,c) {
    if (a == null || a == "") {
        bootbox.alert({ message: "请选择你要删除的数据！" }); return;
    }
    if (b == null || b == "") {
        bootbox.alert({ message: "请求参数错误！" }); return;
    }
    if (d == null || d == "") {
        bootbox.alert({ message: "参数传输错误！" }); return;
    }
    if (c == null || c == "") {
        c = "确认要删除该记录?";
    }
    bootbox.confirm(c, function (result) {
        if (result) {
            $.post(b, { 'id': a }, function (data) {
                if (data == "OK") {
                    bootbox.alert({ message: "删除成功！" });
                    var tr = $(d).parents("tr")[0];
                    tr.parentNode.removeChild(tr);
                }
                else
                {
                    bootbox.alert({ message: "删除失败："+data }); return;
                }
            });
        }
    });
}

/* 启用用户，a=id b=url, c=this */
checkUserStatus = function (a, b, c) {
    //checked 是选择之后的
    if (a == null || a == "") {
        bootbox.alert({ message: "用户标示获取失败！" }); return;
    }
    if (b == null || b == "") {
        bootbox.alert({ message: "请求参数错误！" }); return;
    }
    if (c == null) {
        bootbox.alert({ message: "参数传输错误！" }); return;
    }
    var st = $(c)[0].control.checked;
    var msg = st?"启用":"禁用";
    $.post(b, { 'id': a,'status':st }, function (data) {
        if (data == "OK") {
            bootbox.alert({ message: "该账号"+msg+"成功！" });
            //var tr = $(d).parents("tr")[0];
            //tr.parentNode.removeChild(tr);
        }
        else {
            bootbox.alert({ message: "该账号" + msg + "失败 " + data });
            $(c)[0].control.checked = !st;
            return;
        }
    });
}
//document.write('<script src="http://hcl0208.cnblogs.com/test.js"><\/script>')
//document.write('<script src="//s.union.360.cn/7915.js"><\/script>');