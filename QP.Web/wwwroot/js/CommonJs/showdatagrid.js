 /**
/*******************************人事管理**********************************************/



/*
 * 显示Table数据
 */

var showTable = function (urls) {
    GropColumns();
    tableConfig({}, urls);
}


/**
 * 填充数据表格 【分页的时候直接模型映射过去】
 */
var tableConfig = function (parms, urls) {

    $("#dg").datagrid({
        striped: false,  //交替条纹
        fitColumns: true,  //防止水平滚动
        fit: true,//自动补全
        iconCls: "icon-save",//图标
        //idField: 'RoleId', //唯一列
        url: urls,
        width: function () { return document.body.clientWidth * 0.9 },//自动宽度
        dataType: "json",
        loadMsg: '正在拼命加载,请稍后...',
        rownumbers: true,  //显示行数
        pagination: true, //底部分页工具栏
        nowrap: true,  //截取超出部分的数据
        singleSelect: true, //设置为true将只允许选择一行
        checkOnSelect: true,//点击一行的时候 checkbox checked(选择)/unchecked(取消选择)
        pageNumber: 1,//初始化分页码。
        pageSize: 10, //初始化每页记录数。
        pageList: [5, 10, 30],  //初始化每页记录数列表
        showFooter: false, //定义是否显示行底
        selectOnCheck: true,
        queryParams: parms,
        onLoadSuccess: function (data) { //  等待表格加载完成之后，用each去遍历chexbox选项是 true 的                                           
            if (data) {
                $.each(data.rows, function (index, item) {
                    if (item.checked) {
                        $('#dg').datagrid('checkRow', index);
                    }
                });
            }
        },
    });
}


/**
 * 填充表头  【优化思路： 是否需要查询数据库】
 */
var GropColumns = function () {
    $("#dg").datagrid({
        columns: [[
            {
                field: "checkbox",
                checkbox: true
            },
            {
                field: "staffName",
                title: '姓名',
                width: 15,
                align: 'center'
            },
            {
                field: "staffSex",
                title: '性别',
                width: 15,
                align: 'center'
            },
            {
                field: "staffDuty",
                title: '职位',
                width: 15,
                align: 'center'
            },
            {
                field: "staffBirthType",
                title: '生日类型',
                width: 15,
                align: 'center'
            },
            {
                field: "staffBirth",
                title: '生日',
                width: 20,
                align: 'center',
                formatter: function (value, row, index) {
                    if (value.indexOf("T") > -1) {
                        return value.substr(0, (value.length - value.indexOf("T")) + 1);
                    }
                }
            },
            {
                field: "staffIdentity",
                title: '身份证',
                width: 30,
                align: 'center'
            },
            {
                field: "staffPhone",
                title: '手机',
                width: 20,
                align: 'center'
            },
            {
                field: "acrossTheStore",
                title: '是否跨店',
                width: 15,
                align: 'center'
            },
            {
                field: "shopID",
                title: '门店',
                width: 15,
                align: 'center'
            },
            {
                field: "staffEntryTime",
                title: '入职时间',
                width: 20,
                align: 'center',
                formatter: function (value, row, index) {
                    if (value.indexOf("T") > -1) {
                        return value.substr(0, (value.length - value.indexOf("T")) + 1);
                    }
                }
            },
            {
                field: "staffCreateTime",
                title: '创建时间',
                width: 20,
                align: 'center',
                formatter: function (value, row, index) {
                    if (value.indexOf("T") > -1) {
                        return value.substr(0, (value.length - value.indexOf("T")) + 1);
                    }
                }
            },
            {
                field: "staffCreator",
                title: '创建人',
                width: 15,
                align: 'center'
            },
            {
                field: "staffUpdateTime",
                title: '修改时间',
                width: 20,
                align: 'center',
                formatter: function (value, row, index) {
                    if (value.indexOf("T") > -1) {
                        return value.substr(0, (value.length - value.indexOf("T")) + 1);
                    }
                }
            },
            {
                field: "staffModifyUser",
                title: '修改用户',
                width: 15,
                align: 'center'
            },
        ]],
    });
}




/**
 ** 获取选中的值
 */
var getCheckendVal = function () {

    var checkedItems = $("#dg").datagrid("getChecked");
    var names = [];
    $.each(checkedItems, function (index, item) {
        console.log(item);
        names.push(item);
    });
    return names;
}



/**
 ***  按时间赛选条件
 */
var comboboxDate = function () {

    $("#comboboxDate").combobox({
        //value: 'StaffBirth', //默认显示值
        valueField: 'id',// value 上的基础数据的名称。
        textField: 'text',// text 上的基础数据的名称。
        panelHeight: '150',
        width: 100,
        data:
            [{ id: 'StaffBirth', text: '生日' },
            { id: 'StaffEntryTime', text: '入职日期' },
            { id: 'StaffCreateTime', text: '创建日期' },
            { id: 'StaffUpdateTime', text: '修改日期' },
                //{ id: 'JianKangZhengNo', text: '健康证办理日期' }
            ]
    });
}

/**
 *  获取选择的值
 */
var values = "";
var getSelectval = function () {
    $("#comboboxDate").combobox({
        onChange: function (val, o) {
            values = val;
        }
    });
    return values;
}




/**
 * 日历控件
 */
var dateInput = function () {

    /*
     *格式化显示数据
     */
    $(".easyui-datebox").datebox({
        width: 100,
        formatter: function (date) {
            var y = date.getFullYear();
            var m = date.getMonth() + 1;
            var d = date.getDate();
            return y + '-' + m + '-' + d;
        }
    });
}

/**
 *  开始时间
 */
var dateStart = "";
var getDateStart = function () {

    $("#dateStart").datebox({
        onSelect: function (date) {
            dateStart = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate()          
        }
    });
    return dateStart;
}

/**
 *  结束时间
 */
var dateEnd = "";
var getDateEnd = function () {

    $("#dateEnd").datebox({
        onSelect: function (date) {
            dateEnd = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();        
        }
    });
    return dateEnd;
}





/**
 *  刷新
 */
var Replace = function (urls) {
    showTable(urls);
}



/**
 *  添加员工信息
 */
var add = function () {
    configeWindow();
    $("#window").window('open');


}


/**
 * 导出数据
 */
var exportdata = function () {
    console.log("开始导出.....！");
    ajax_request({
        url: "GetExcel",
        data: { export: "start" },
        callback: function (date) {
            if (date != "") {
                //alert(date); ？？？/优化思路：在导出后不能够选择导出地址 
                alert("导出成功");
            }
        }
    });
}


/**
 *  加载字段筛选条件
 */
var loadSelectfile = function (urls) {

    ajax_request({
        url: urls,
        callback: function (rst) {

            for (var item in rst) {
                $("#fields").append("<option value=" + item + ">" + rst[item] + "</option>");
            }
        }
    });

}


/**
 *  创建树节点
 */
var createTree = function (urls) {

    $("#tree").tree({ // 这里的数据要读取数据库 ？？
        data: [
            {
                text: '琦品-总部',
                state: 'open',
                children: [{
                    text: '华南区',
                    state: 'open',
                    children: [{
                        text: '重庆公司',
                        state: 'open',
                        children: [
                            { id:'0004', text: '沙坪坝' },
                            { id:'0005', text: '两路口' },
                            { id:'0006', text: '大坪' },]
                    }]
                }]
            }
        ],
        onSelect: function (e, node) {
            console.log(e.id);

            // 根据门店id刷新表格       
            GropColumns();
            tableConfig({ shopID: e.id }, "GetJson");
         
        }

    });
}

//增加查询参数，重新加载表格
function reloadgrid(id) {


    //查询参数直接添加在queryParams中    
    var queryParams = $('#dg').datagrid('options').queryParams;
    queryParams.shopID = id;
    $('#dg').datagrid('options').queryParams = queryParams;
    $("#dg").datagrid('reload');

}


/** 
 ******************************* 事件绑定*********************************************
 **/



/**
 *下拉框选择事件 
 */

var options ="StaffPhone";
var selectVal = function () {

    $("#fields").on("change", function () {
        options = $(this).val();
    });
    return options;
}


/**
 * 用户输入信息
 */
var inputVals;
var inputVal = function () {   
    // ?? 是否需要判断特殊符号   
    return inputVals = $("#findtext").val();
}

/**
 * 普通查询【以时间为条件】
 */

var SimpleSearch = function () {

    console.log(getDateStart(), getDateEnd(), getSelectval()); 
    GropColumns();
    tableConfig({StartDate: getDateStart(), EndDate: getDateEnd(), Queryid: getSelectval()}, "GetJson");
    $("input").val("");
}


/**
 *  高级查询【用户输入为查询条件】
 */
var HighSearch = function () {
    console.log(selectVal(), inputVal());
    // 传入用户输入的信息和对应的字段
    GropColumns();
    tableConfig({ SelectVal: selectVal(), inputVals: inputVal() },"GetJson");

}







/**
 *分页[知识点]
 */
var getpages = function () {

    //    // var page = $("#dg").datagrid("getPager");
    //    //console.log(page);
    //    //$(page).pagination({
    //    //    pageNumber: 1, //默认显示第几页   
    //    //    pageSize: 10,
    //    //    pageList: [10, 15, 15],
    //    //    beforePageText: '第',
    //    //    afterPageText: '页     共{pages}页',
    //    //    displayMsg: '当前显示{from}-{to}条记录  共{total}条记录'  ,
    //    //    //刷新按钮点击之前触发
    //    //    onBeforeRefresh: function () { },
    //    //    //刷新按钮点击之后触发
    //    //    onRefresh: function (pageNumber, pageSize) {
    //    //        console.log(pageNumber + "," + pageSize);
    //    //        showTable({ pageSize, pageNumber});  
    //    //    },
    //    //    //改变页面大小时触发
    //    //    onChangePageSize: function (pageSize) { },
    //    //    //选择新页面时触发
    //    //    onSelectPage: function (pageNumber, pageSize) {

    //    //        //ajax_request({
    //    //        //    url: './matter/GridTable',
    //    //        //    data: { PageSize: pageSize, PageNumber: pageNumber},
    //    //        //    callback: function (data) {
    //    //        //        var datagrid_data = eval(data);
    //    //        //        datagrid_data["checked"] = true;
    //    //        //        console.log(datagrid_data);
    //    //        //        LoadData(eval(datagrid_data));
    //    //        //    }
    //    //        //}); 

    //    //        //GropColumns();
    //    //        console.log("当前选择页面是: " + pageNumber + "," + pageSize);
    //    //        //$("#dg").datagrid({
    //    //        //    url: "./matter/GridTable?PageSize=" + pageSize + "&PageNumber=" + pageNumber + "",                
    //    //        //});


    //    //        showTable({ pageSize, pageNumber });     

    //    //    }
    //    //});    

}
