var frmid, layer;

layui.use('layer', function () {
    layer = layer;
});

/**
 *  前后台数据交互
 * @param {any} options
 */
var ajax_request = function (options) {
    var option = {
        type: 'post',
        async: false,//false为阻塞请求
        datatype: 'application/json',
        //callback: function (rst) { },
    }

    //把option 对象存放在 options 对象中
    options = $.extend(options, option);
    $.ajax({
        type: options.type,
        url: options.url == undefined ? '' : options.url,
        data: options.data,
        //发送请求之前
        beforeSend: function () {
            frmid = showLoading();
        },
        //成功
        success: function (data, textStatus) {         
            options.callback(data);
        },
        //错误
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            error(XMLHttpRequest, textStatus, errorThrown);
        }, 
        //请求完成
        complete: function (response, status, xhr) {
            setTimeout(function () { hideLoading(frmid); }, 10);
        }
    })
}

var showLoading = function () {
 //   return top.layer.open({ title: '', icon: 1, type: 1, closeBtn: 0, area: ['200px', '40px'], btn: [], content: '请稍候，数据载入中……' });
}

var hideLoading = function (id) {
    top.layer.close(id);
}

var dialog = function (content) {
    top.layer.open({ type: 1, content: content });
}

var error = function (event, xhr, settrings) {
    alert('error');
}


var menuList;

var initMenu = function (urls) {
    ajax_request({
        url: urls,
        callback: function (rst) {
            menuList = eval(rst);
            buildMenu(0);
        }
    });
}

/**
 * 生成导航
 * @param {any} pid
 */

var flag = true;

var buildMenu = function (pid) {
    if (pid == 0) //如果pid为0，则表示第一层级菜单，为页头菜单，if单独组成
    {
        $.each(menuList, function (j, item) {
            
            $.each(item.children, function (i, data) {
                //console.log(data);
                $('#topnavs').append('<li class="list"><a href="javascript:;" onclick="buildMenu(' + data.id + ')"><img src="' + data.iocCss + '" /> <br>' + data.name + '</a></li>');
            });
        });        
    }
    else //生成侧边栏
    {
       
        $.each(menuList, function (j, item) {
            
            $.each(item.children, function (i, item1) {//一级

                if (item1.children) {
                    $.each(item1.children, function (j, item2) {//二级

                        if (item2.parentId == pid) {                        
                            add_accordion(item2.name, item2.id);                         
                            $(".panel-tool").html("");
                            if (item2.children) {
                                $.each(item2.children, function (k, item3) { // 三级                               
                                    if ($(".trees").eq(j).attr("name") == item3.parentId) {
                                        $(".trees").eq(j).html("<li><div id='sub" + item3.id+"' onclick='Content_click(" + item3.id + ")'><img src=" + item3.iocCss + "><a href='javascript:;'' class>" + item3.name + "</a></div></li>");
                                    }
                                });
                            }
                        }
                    });
                }
            });             
        });             
    }
}

/**
 * 加载内容页
 */



/**
 * 添加手风琴
 * @param {any} title 标题 
 * @param {any} htm 内容
 */

var add_accordion = function (title, id) {

    /*??  防止连续添加*/    
    $("#aa").accordion("add", { //添加
        title: title,        
        selected: true,
        border: false,       
        content: function () {
            //var html = "<a href='javascript:void(0);' onclick='Click_leftNav(" + rst[i].id + ")' >" + rst[i].name + "</a>";
            //var html = "<ul name=" + rst[i].id + "  class='easyui-tree trees'></ul>"
            var html = "<ul name=" + id + "  class='easyui-tree trees'></ul>"
            return html;
        }
    });
    
   
}


/**
 * 验证用户输入是否合法
 * @param {any} options
 */
var verfication_input = function (options) {

    if (options.LogName == "" || options.PassWord == "") {
        return "请输入用户名或密码";
    } else {
        if (options.inputCode != options.code) {
            return "请输入4位数验证码";
        }
        return "true";
    }
}




/** 
 *  记录当前时间
 * */
var Timer = function () {
    var date = new Date();
    setTimeout(function () {
        //  return String(date.getFullYear()) + "年" + String(date.getMonth()) + "月" + String(date.getDay());
        return date.toLocaleTimeString();
    }, 1000);
}