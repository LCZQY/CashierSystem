/**
/*******************************Easyui控件公用配置 **********************************************/




/**
 * * windows基本配置  
 */

var configeWindow = function () {    
   // $('#window').window("resize", { top: $(document).scrollTop() + ($(window).height() - 300) * 0.5 });//居中显示
    $("#window").window({
        width: document.body.clientWidth / 3,
        height: document.body.clientHeight *0.8, 
        collapsible: false,
        border: false,
        minimizable: false,
        maximizable: false,
        draggable: true,
        resizable: false,        
    });


}

