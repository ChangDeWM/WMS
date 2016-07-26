/* 
 * Select Change Script
 * Author：ZhangJing 2016-07-26 Code
 * param desc[ a: select value, b: the next select id, c:the next select default value ]
 * 
 */
EnterpriseChange = function (a,b,c) {
    var $html = "";
    if (a.length > 0) {
        $.getJSON("/ashx/Sys_User.ashx?action=GetDptList", { eid: a }, function (result) {
            $html = '<option value="">  </option>'
            for (var i = 0; i < result.length; i++) {
                if (c != null && c == result[i].DptId) {
                    $html += '<option selected="selected" value="';
                }
                else {
                    $html += '<option value="';
                }
                $html += result[i].DptId;
                $html += '">';
                $html += result[i].DptName;
                $html += "</option>";
                if (result[i].DptChild != null) {
                    for (var j = 0; j < result[i].DptChild.length; j++) {
                        if (c != null && c == result[i].DptChild[j].DptId) {
                            $html += '<option selected="selected" value="';
                        }
                        else {
                            $html += '<option value="';
                        }
                        $html += result[i].DptChild[j].DptId;
                        $html += '">';
                        $html += "  |-- " + result[i].DptChild[j].DptName;
                        $html += "</option>";
                    }
                }
            }
            $("#" + b + "").html($html);
        });
    }
    //$("#" + b + "").html($html);
}