/*******************************
 * Menu Tabs Plug
 * ZhangJing Add 2016-05-14
 *******************************/

var addTabs = function (options) {
    var url = window.location.protocol + '//' + window.location.host;
    //Zj 增加无http则返回-1
    if (options.url.indexOf("http") >= 0) {
        url = "";
    }
    options.url = url + options.url;
    //写入Cookie，目的是刷新加载
    var optionsList = JSON.parse($.cookie("wms_cookie_nav_zj"));
    if (optionsList != null) {
        for (var n = 0; n < optionsList.length; n++) {
            if (optionsList[n].id == options.id)
            { optionsList.splice(n, 1); break; }
        }
        optionsList[optionsList.length] = options
    }
    else { optionsList = new Array(); optionsList[0] = options; }
    var date = new Date();
    date.setTime(date.getTime() + (48 * 3600 * 1000));
    $.cookie('wms_cookie_nav_zj', JSON.stringify(optionsList), { expires: date });
    id = "tab_" + options.id;
    $(".active").removeClass("active");
    //如果TAB不存在，创建一个新的TAB
    if (!$("#" + id)[0]) {
        //固定TAB中IFRAME高度
        mainHeight = $(this).height() - 135;// $(document.body).height() - 90;
        //创建新TAB的title
        title = '<li class="tabs-header" role="presentation" id="tab_' + id + '"><a href="#' + id + '" aria-controls="' + id + '" role="tab" data-toggle="tab">' + options.title;
        //是否允许关闭
        if (options.close) {
            title += ' <i class="glyphicon glyphicon-remove" tabclose="' + id + '"></i>';
        }
        title += '</a></li>';
        //是否指定TAB内容
        if (options.content) {
            content = '<div role="tabpanel" class="tab-pane" id="' + id + '">' + options.content + '</div>';
        } else {//没有内容，使用IFRAME打开链接
            var ifId = "page_" + id;
            content = '<div role="tabpanel" class="tab-pane" id="' + id + '"><iframe id="page_' + id + '" src="' + options.url + '" width="100%" height="' + mainHeight +
                '" frameborder="no" border="0" marginwidth="0" marginheight="0" scrolling="yes" allowtransparency="yes"></iframe></div>';
        }
        //加入TABS
        $(".nav-tabs").append(title);
        $(".tab-content").append(content);
    }
    //激活TAB
    $("#tab_" + id).addClass('active');
    $("#" + id).addClass("active");

    //自适应窗体高度
    var iframe = document.getElementById("page_" + id);
    try {
        if (iframe.attachEvent) {
            iframe.attachEvent("onload", function () {
                iframe.height = iframe.contentWindow.document.documentElement.scrollHeight;
            });
            return;
        } else {
            iframe.onload = function () {
                iframe.height = iframe.contentDocument.body.scrollHeight;
            };
            return;
        }
    } catch (e) {
        iframe.height = 500;
    }
};

//$(window).resize(function () {
//    var tab = $('.tabs-header.active');
//    var tid = tab[0].id.replace(/[^0-9]/ig, "");
//    var iframe = document.getElementById("page_tab_" + id);
//    try {
//        if (iframe.attachEvent) {
//            iframe.attachEvent("onload", function () {
//                iframe.height = iframe.contentWindow.document.documentElement.scrollHeight;
//                iframe.width = iframe.contentWindow.document.documentElement.scrollWidth;
//            });
//            return;
//        } else {
//            iframe.onload = function () {
//                iframe.height = iframe.contentDocument.body.scrollHeight;
//                iframe.width = iframe.contentDocument.body.scrollWidth;
//            };
//            return;
//        }
//    } catch (e) {
//        iframe.height = 500;
//    }
//});

var closeTab = function (id) {
    //关闭前判断cookie是否需要清空
    var optionsList = JSON.parse($.cookie("wms_cookie_nav_zj"));
    if (optionsList != null) {
        var ishas = 0;
        for (var n = 0; n < optionsList.length; n++) {
            if ("tab_" + optionsList[n].id == id)
            { ishas = 1; optionsList.splice(n, 1); break; }
        }
        if (ishas = 1) {
            var date = new Date();
            date.setTime(date.getTime() + (48 * 3600 * 1000));
            $.cookie('wms_cookie_nav_zj', JSON.stringify(optionsList), { expires: date });
        }
    }
    //如果关闭的是当前激活的TAB，激活他的前一个TAB
    if ($("li.active").attr('id') == "tab_" + id) {
        $("#tab_" + id).prev().addClass('active');
        $("#" + id).prev().addClass('active');
    }
    //关闭TAB
    $("#tab_" + id).remove();
    $("#" + id).remove();
};

$(function () {
    mainHeight = $(document.body).height() - 45;
    $('.main-left,.main-right').height(mainHeight);
    $("[addtabs]").click(function () {
        addTabs({ id: $(this).attr("id"), title: $(this).attr('title'), close: true });
    });

    $(".nav-tabs").on("click", "[tabclose]", function (e) {
        id = $(this).attr("tabclose");
        closeTab(id);
    });
});

function closecur() {
    var tab = $('.tabs-header.active');
    var tid = tab[0].id.replace(/[^0-9]/ig, "");
    closeTab("tab_" + tid);
};

function closeall() {
    var tablist = $('.tabs-header');
    for (var i = tablist.length - 1; i >= 0; i--) {
        var tid = tablist[i].id.replace(/[^0-9]/ig, "");
        $("#tab_tab_" + tid).remove();
        $("#tab_" + tid).remove();
    }
    var optionsList = JSON.parse($.cookie("wms_cookie_nav_zj"));
    optionsList.splice(0, optionsList.length);
    $.cookie('wms_cookie_nav_zj', JSON.stringify(optionsList));

    $('#tabIndex').addClass('active');
    $('#Index').addClass('active');
};

function closeleft() {
    var tab = $('.tabs-header.active');
    var idx = tab.index();
    for (var i = 1; i < idx; i++) {
        var tid = $('.tabs-header')[0].id.replace(/[^0-9]/ig, "");
        $("#tab_tab_" + tid).remove();
        $("#tab_" + tid).remove();
    }
};

function closeright() {
    var tab = $('.tabs-header.active');
    var idx = tab.index();
    var tablist = $('.tabs-header');
    for (var i = tablist.length - 1; i >= idx; i--) {
        var tid = tablist[i].id.replace(/[^0-9]/ig, "");
        $("#tab_tab_" + tid).remove();
        $("#tab_" + tid).remove();
    }
};

function refreshTabs() {
    var tab = $('.tabs-header.active');
    var tid = tab[0].id.replace(/[^0-9]/ig, "");
    document.getElementById("page_tab_" + tid).contentWindow.location.reload(true);
}