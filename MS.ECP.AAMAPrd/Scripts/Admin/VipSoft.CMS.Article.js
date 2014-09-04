/// <reference path="jquery-1.7.1.js" />
/// <reference path="jquery.form.js" />

var editor;
jQuery(document).ready(function () {
    editor = UE.getEditor('UEContent');
    submit(); 
});
//Tab控制函数
function submit() {
    //设置点击后的切换样式
    // jQuery(":input[type='submit']").click(function (event) {
    //     jQuery.ajax({
    //         type: "POST",
    //         url: "/Admin/Content/Add/",
    //         dataType: "json",
    //         success: function (data) {
    //             alert(data);
    //             alert("success!");
    //         },
    //         error: function (data) {
    //             alert(data);
    //             alert("This Edit/Update is failed!");
    //         }
    //     });
    // }
    //);

    //jQuery('#btnSave').click(function () {
    //    alert("Thank you for your comment!");
    //});


    // prepare Options Object 
    var options = {
        // other available options:             
        url: '/Admin/Content/Save/?'+new Date().getMilliseconds(),  // override for form's 'action' attribute 
        //target:        '#output2',   // target element(s) to be updated with server response 
        // beforeSubmit: showRequest,  // pre-submit callback 
        type: 'post',    // 'get' or 'post', override for form's 'method' attribute 
        data: { id: jQuery('#PageContent_ID').val() },
        dataType: 'json',        // 'xml', 'script', or 'json' (expected server response type) 
        //clearForm: true        // clear all form fields after successful submit 
        //resetForm: true        // reset the form after successful submit 

        // jQuery.ajax options can be used here too, for example: 
        //timeout:   3000 
        success: function () {
            //art.dialog({
            //    title: '消息提示',
            //    content: '保存成功'
            //});
            //alert("保存成功！");
            location.href = "/Admin/Content/List";
        }
    };
    
    if (jQuery('#contentFrm').length > 0) {
        // bind to the form's submit event 
        jQuery('#contentFrm').submit(function () {
            // inside event callbacks 'this' is the DOM element so we first 
            // wrap it in a jQuery object and then invoke ajaxSubmit 
            editor.sync();
            jQuery(this).ajaxSubmit(options);

            // !!! Important !!! 
            // always return false to prevent standard browser submit and page navigation 
            return false;
        });
    }
}


function search() {

    // prepare Options Object 
    var options = {
        // other available options:             
        url: '/VipSoft/Article/List/' + jQuery('#mid').val() + '/' + jQuery('#cid').val() + '/?' + new Date().getMilliseconds(),  // override for form's 'action' attribute 
        //target:        '#output2',   // target element(s) to be updated with server response 
        // beforeSubmit: showRequest,  // pre-submit callback 
        type: 'post',    // 'get' or 'post', override for form's 'method' attribute 
        //data: { mid: jQuery('#mid').val(), CategoryId: jQuery('#cid').val(), id: jQuery('#id').val() },
        dataType: 'json'//,        // 'xml', 'script', or 'json' (expected server response type) 
        //clearForm: true        // clear all form fields after successful submit 
        //resetForm: true        // reset the form after successful submit 

        // jQuery.ajax options can be used here too, for example: 
        //timeout:   3000 
        //success: function () {
        //    art.dialog({
        //        title: '消息提示',
        //        content: '保存成功'
        //    });
        //}
    };
    alert(1);
    if (jQuery('#frmArticleList').length > 0) {
        alert(3);
        // bind to the form's submit event 
        jQuery('#frmArticleList').submit(function () {
            // inside event callbacks 'this' is the DOM element so we first 
            // wrap it in a jQuery object and then invoke ajaxSubmit 
            editor.sync();
            jQuery(this).ajaxSubmit(options);

            // !!! Important !!! 
            // always return false to prevent standard browser submit and page navigation 
            return false;
        });
    } 
}

function successed() {
    alert("删除成功！");
}


