$(document).ready(function () {

    context.init({ preventDoubleContext: false });

    context.attach('.tabs-header', [
		{ text: '关闭', href: 'javascript:closecur();' },
        { text: '刷新', href: 'javascript:refreshTabs();' },
		{ divider: true },
        { text: '全部关闭', href: 'javascript:closeall();' },
        { text: '关闭左侧', href: 'javascript:closeleft();' },
        { text: '关闭右侧', href: 'javascript:closeright();' }
    ]);

    context.settings({ compress: true });
});