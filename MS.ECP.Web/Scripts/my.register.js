
var ajaxUpload;
var fill = true, css = "border-color", redcolor = "red red red red";

function checkValues(var1, var2) {
    var reExg = /[_a-zA-Z]/;

    var strEmail = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    var reemail = new RegExp(strEmail);
    if ($.trim($("#txtEmail").val()) != "" && !reemail.test($.trim($("#txtEmail").val()))) {
        ShowBox(alertJson[0].msg_EmailError);
        $("#txtEmail").css(css, redcolor);
        $("#txtEmail").focus();
        return false; fill = false;
    }
    else {
        $("#txtEmail").css(css, "");
    }

    if ($.trim($("#txtPassword").val()) != $.trim($("#txtRePassword").val())) {
        ShowBox(alertJson[0].msg_CommonPassWord);
        $("#txtRePassword").css(css, redcolor);
        $("#txtRePassword").focus();
        return false; fill = false;
    }
    if (!passwordRule($.trim($("#txtPassword").val()))) {
        ShowBox(alertJson[0].msg_PasswordRules);
        $("#txtPassword").css(css, redcolor);
        $("#txtRePassword").css(css, redcolor);
        return false; fill = false;
    }

    if (!$("#ckbPolicy").attr("checked")) {
        ShowBox(alertJson[0].msg_Agreement);
        $("#ckbPolicy").focus();
        return false;
        fill = false;
    }
    return fill;
}

function passwordRule(password) {
    var val = password;
    var getstr, oldval;
    if (val.length > 10 || val.length < 7) {
        return false;
    }
    var reg = /\d/;
    if (!reg.exec(val)) {
        return false;
    }
    reg = /[a-zA-Z]/;
    if (!reg.exec(val)) {
        return;
    }
    return true;
}

function AddRegister(filename) {
    if (!RegisterSubmit()) {
        return false;
    }
    $.ajax({
        type: "POST",
        contentType: "application/x-www-form-urlencoded;charset=utf-8",
        url: CreateAjaxUrl("account/register2"),
        data: "fileN=" + filename + "&" + $("#frmRegister").serialize(),
        dataType: "json",
        success: function (data) {
            if (data.result == "1") {

            }
            else {
                alert(data.errMsg);
            }
            return false;
        }
    });
    return false;
}