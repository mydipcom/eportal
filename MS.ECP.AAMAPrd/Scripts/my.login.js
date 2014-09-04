(function ($) {
    $.getUrlParam = function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) {
            return unescape(r[2]);
        }
        return null;
    }
})(jQuery);

//login
function fLogin(webPath) {
    checkLoginValue();
    var email = $.trim($("#txtMainAdd").val());
    var pass = $.trim($("#txtPass").val());
    AjaxLogin(email, pass, $("#chkReme").attr("checked"), webPath);
    return false;
}

function AjaxLogin(email, pass, remeber, webPath) {

    $.ajax({
        type: "POST",
        contentType: "application/x-www-form-urlencoded;charset=utf-8",
        url: webPath + "?time=" + new Date().getMilliseconds(),
        data: { Email: email, Pass: pass },
        dataType: "json",
        success: function (data) {
            //  var region = data.webregion;
            if (data.result == "1") {
                if (remeber) {
                    $.cookie("UserName", email, { expires: 7, path: "/" });
                }
                var url = $.getUrlParam("returnUrl");
                if (typeof url == "undefined" || url == null) {
                    window.location.href = data.find;
                    //window.location.href = region + "/home/index";
                } else {
                    window.location.href = url;
                }
            } else {
                ShowBox(alertJson[0][data.errMsg]);
            }
            return false;
        }
    });
}


//login
function getAjaxLogin(webPath) {
    var email = $.trim($("#txtUserName").val());
    var pass = $.trim($("#txtPassword").val());
    if (email == "") {
        ShowBox(alertJson[0].msg_InputUserName);
        return false;
    }
    if (pass == "") {
        ShowBox(alertJson[0].msg_InputPassword);
        return false;
    }
    AjaxLogin(email, pass, false, webPath);
    return false;
}

 


//top
 

// show box
function ShowBox(msg, no, yes) {
    var oktext = "OK";
    if (alertJson != null && typeof alertJson[0].msg_Global_LanguageType != "undefined") {
        switch (alertJson[0].msg_Global_LanguageType) {
            case "DE":
                oktext = "";
                break;
            case "FR":
                oktext = "";
                break;
            case "JP":
                oktext = "";
                break;
            default:
                oktext = "OK";
        }
    }
    var box = "<div id=\"inline2\" class=\"word_contend\">"
                    + "<p>" + msg + "</p>"
                    + "<p class=\"ok_button\" onmouseover=\"ButtonOver(this)\" onmouseout=\"ButtonOut(this)\" onclick=\"ClickYes()\">OK</p>"
                    + "<p style=\"clear: both\"></p>"
                    + "</div>";

    $.fancybox(box, {
        'padding': 5,
        'model': true,
        'autoDimensions': true,
        'transitionIn': 'fade',
        'transitionOut': 'fade',
        'centerOnScroll': true,
        'hideOnOverlayClick': false,
        'showCloseButton': true
    });
    return false;
}


function ShowBox2(msg, no, yes) {
    var box = "<div id=\"inline2\" style=\" width: 330px;text-align: left;background: #e8e8e8; margin: 0 auto; padding: 20px 0 5px 0px; border: 1px solid #B0AFAF; font-size: 10pt;font-family:Verdana;color: 333;padding-right: 10px; padding-left: 10px;\">"
                    + "<p>" + msg + "</p>"
                    + "<p class=\"ok_button\" onmouseover=\"ButtonOver(this)\" onmouseout=\"ButtonOut(this)\" onclick=\"ClickYes()\">OK</p>"
                    + "<p style=\"clear: both\"></p>"
                    + "</div>";

    $.fancybox(box, {
        'padding': 5,
        'model': true,
        'autoDimensions': true,
        'transitionIn': 'fade',
        'transitionOut': 'fade',
        'centerOnScroll': true,
        'hideOnOverlayClick': false,
        'showCloseButton': true
    });
    return false;
}


function ShowConfirm(msg, webPath) {
    var box = "<div id=\"inline2\" class=\"word_contend\">"
                    + "<p>" + msg + "</p>"
                    + "<p class=\"no_button\" onmouseover=\"ButtonOver(this)\" onmouseout=\"ButtonOut(this)\" onclick=\"ClickNo()\">" + alertJson[0].msg_ButtonCancel + "</p>"
                    + "<p class=\"ok_button\" onmouseover=\"ButtonOver(this)\" onmouseout=\"ButtonOut(this)\" onclick=\"ConfirmYes('" + webPath + "')\">" + alertJson[0].msg_ButtonOK + "</p>"
                    + "<p style=\"clear: both\"></p>"
                    + "</div>";

    $.fancybox(box, {
        'padding': 5,
        'model': true,
        'autoDimensions': true,
        'transitionIn': 'fade',
        'transitionOut': 'fade',
        'centerOnScroll': true,
        'hideOnOverlayClick': false,
        'showCloseButton': true
    });
    return false;
}

function ShowStatus(msg) {
    var box = "<div id=\"inline2\" class=\"word_contend\">"
                    + "<p>" + msg + "</p>"

                    + "<p style=\"clear: both\"></p>"
                    + "</div>";

    $.fancybox(box, {
        'padding': 5,
        'model': true,
        'autoDimensions': true,
        'transitionIn': 'fade',
        'transitionOut': 'fade',
        'centerOnScroll': true,
        'hideOnOverlayClick': false,
        'showCloseButton': true
    });
    return false;
}


function ShowConfirm2(msg, webPath) {
    var box = "<div id=\"inline2\" class=\"word_contend\">"
                    + "<p>" + msg + "</p>"
                    + "<p class=\"no_button\" onmouseover=\"ButtonOver(this)\" onmouseout=\"ButtonOut(this)\" onclick=\"ClickNo()\">Cancel</p>"
                    + "<p class=\"ok_button\" onmouseover=\"ButtonOver(this)\" onmouseout=\"ButtonOut(this)\" onclick=\"ConfirmYes('" + webPath + "')\">OK</p>"
                    + "<p style=\"clear: both\"></p>"
                    + "</div>";

    $.fancybox(box, {
        'padding': 5,
        'model': true,
        'autoDimensions': true,
        'transitionIn': 'fade',
        'transitionOut': 'fade',
        'centerOnScroll': true,
        'hideOnOverlayClick': false,
        'showCloseButton': true
    });
    return false;
}
function ShowAlertAdmin(msg) {
    var box = "<div id=\"inline2\" class=\"word_contend\">"
                    + "<p>" + msg + "</p>"
                    + "<p class=\"ok_button\" onmouseover=\"ButtonOver(this)\" onmouseout=\"ButtonOut(this)\" onclick=\"ClickYes()\">OK</p>"
                    + "<p style=\"clear: both\"></p>"
                    + "</div>";

    $.fancybox(box, {
        'padding': 5,
        'model': true,
        'autoDimensions': true,
        'transitionIn': 'fade',
        'transitionOut': 'fade',
        'centerOnScroll': true,
        'hideOnOverlayClick': false,
        'showCloseButton': true
    });
    return false;
}


function ShowAlert(msg, url) {
    var box = "<div id=\"inline2\" class=\"word_contend\">"
                    + "<p>" + msg + "</p>"
                    + "<p class=\"ok_button\" onmouseover=\"ButtonOver(this)\" onmouseout=\"ButtonOut(this)\" onclick=\"ClickYes()\">" + alertJson[0].msg_ButtonOK + "</p>"
                    + "<p style=\"clear: both\"></p>"
                    + "</div>";

    $.fancybox(box, {
        'padding': 5,
        'model': true,
        'autoDimensions': true,
        'transitionIn': 'fade',
        'transitionOut': 'fade',
        'centerOnScroll': true,
        'hideOnOverlayClick': false,
        'showCloseButton': true,
        'onClosed': function () {
            window.location.href = url;
        }
    });
    return false;
}


function ButtonOver(e) {
    //$(e).css("background", "#717366").css("color", "#FFF");
    $(e).css("background", "#0E8C7D").css("color", "#FFF");
}

function ButtonOut(e) {
    $(e).css("background", "").css("color", "");
}

function ClickNo() {
    $.fancybox.close();
    return false;
}

function ClickYes() {
    $.fancybox.close();
    return true;
}

function ConfirmYes(webPath) {
    window.location.href = webPath;
    $.fancybox.close();
    return true;
}

function ShowLanguage(imageUrl) {

    $.ajax({
        type: "POST",
        data: $("#frmUnsub").serialize(),
        url: CreateAjaxUrl("ajax/language"),
        dataType: "json",
        success: function (data) {
            if (data.result == "1") {
                var j = 0;
                var objs = eval(data.languages);
                var box = "<div id=\"inline2\" style=\"text-align:left;  margin:0 auto;  font-size:12pt;font-family:Verdana;color:#8C9696; background:#F7FBFB; font-family:Arial; font-weight:normal;\">"

                box = box + "<div style=\" width:719px; height:12px; margin:0 auto;\"></div>";

                box = box + "<div style=\" width:719px; height:auto; margin:0 auto;\">";

                box = box + "<table style=\" width:677px; margin:0 25px 0 auto;  height:auto; font-size:11pt; color:#444; padding:6px 0;\" cellpadding=\"0\" cellspacing=\"0\"><tr>";

                for (var i = 0; i < objs.length; i++) {

                    box = box + "<td style=\"width:100px; text-align:center;\"><input type='checkbox' checked='true' id='chk" + objs[i].Code + "' name='language' value='" + objs[i].Code + "' onclick='insertLanguage(this,\"" + imageUrl + "\");' ";

                    box = box + "/><br /><label id='lbl" + objs[i].Code + "' for='chk" + objs[i].Code + "'> " + objs[i].Text + "</label></td>";

                }

                box = box + "</tr></table>";


                box = box + "<div id='divLanguages'  style=\"margin:0 auto; width:719px;font-family:Arial;\"></div>";
                box = box + "<p class=\"no_button\" onmouseover=\"ButtonOver(this)\" onmouseout=\"ButtonOut(this)\" onclick=\"ClickNo()\">" + alertJson[0].msg_ButtonCancel + "</p>"
                box = box + "<p class=\"ok_button\" onmouseover=\"ButtonOver(this)\" onmouseout=\"ButtonOut(this)\" onclick=\"ClickSave()\">" + alertJson[0].msg_ButtonSave + "</p>";
                box = box + "<p style=\"clear: both\"></p>";



                box = box + "</div>";
                box = box + "<div style=\"background:url(" + imageUrl + "translate_bottom.jpg) no-repeat; width:719px; height:24px; margin:0 auto;\"></div>";

                box = box + "</div>";

                $.fancybox(box, {
                    'padding': 5,
                    'model': true,
                    'autoDimensions': true,
                    'transitionIn': 'fade',
                    'transitionOut': 'fade',
                    'centerOnScroll': true,
                    'hideOnOverlayClick': false,
                    'showCloseButton': true
                })

                if (document.readyState === "complete") {

                    for (var i = 0; i < objs.length; i++) {
                        insertLanguage($("#chk" + objs[i].Code), imageUrl);
                    }
                }

                ;
            }
        }
    });
    return false;
}

function insertLanguage(e, imgUrl) {
    if ($(e).attr("checked")) {
        var lang = $(e).attr("value");
        var htmlcode = "<fieldset id='fdset" + $(e).attr("value") + "'>";
        htmlcode = htmlcode + "<div style=\" width:663px; height:47px; margin:0 auto; padding-right:13px;\"><h1 style=\"font-size:13pt; font-family:Arial; padding:18px 0 0 20px;\">" + $("#lbl" + lang).text() + "</h1></div>";
        htmlcode = htmlcode + "<div style=\" width:663px; height:auto; margin:0 auto; padding-right:13px;\">";

        htmlcode = htmlcode + "<div>";
        htmlcode = htmlcode + "<legend></legend>";
        htmlcode = htmlcode + "<table style=\"margin-left:50px;\">";
        htmlcode = htmlcode + "<tr><th style=\"text-align:right; padding-right:10px; padding-top:11px;\">" + $("#lblTitle").text() + "</th><td class='tdfill'><p>" + "<input id='" + lang + "Title' maxlength='600' value='" + alertJson[0].msg_Translating + "' type='text' name='listTitle' />" + "</p></td></tr>";
        htmlcode = htmlcode + "<tr><th style=\"text-align:right\">" + $("#lblDescription").text() + "</th><td class='tdList_Description'><textarea id='" + lang + "Des'  name='ListDescription'maxlength='1000' rows='5' class='within'>" + alertJson[0].msg_Translating + "</textarea></td></tr>";
        htmlcode = htmlcode + "</table>";
        htmlcode = htmlcode + "<div style=\"background:url(" + imgUrl + "translate_dash.jpg) repeat-x; width:675px; height:2px; margin:20px 0 0 7px;\"></div>";
        mlcode = htmlcode + "</div>";

        translateText(lang, $("#listTitle").val(), "#" + lang + "Title");
        translateText(lang, $("#listDes").val(), "#" + lang + "Des");

        htmlcode = htmlcode + "</div>";
        htmlcode = htmlcode + "<div style=\"background:url(" + imgUrl + "translate_title_bottom.png) no-repeat; width:683px; height:17px;  margin:0 auto; padding-right:13px;\"></div>	";
        htmlcode = htmlcode + "</fieldset> ";

        $("#divLanguages").append(htmlcode);
        if ($("#pCompleted").css("display") == "none") {
            $("#pCompleted").css("display", "");
        }
    }
    else {
        $("#fdset" + $(e).attr("value")).remove();
        if ($("fieldset").length == 0) {
            $("#pCompleted").css("display", "none");
        }
    }
}

function translateText(lang, text, id) {
    $.ajax({
        type: "POST",
        data: { "source": text, "lang": lang },
        url: CreateAjaxUrl("ajax/translate"),
        dataType: "json",
        success: function (data) {
            if (data.result == "1") {
                $(id).val(data.text);
            }
        }
    });
}

function ClickSave() {
    var lang, langs = "", titles = "", descriptions = "";
    $("#divLanguages fieldset").each(function () {
        if ($(this).attr("id") != undefined) {
            lang = $(this).attr("id").replace("fdset", "");
            if ($.trim($("#" + lang + "Title").val()) != alertJson[0].msg_Translating && $.trim($("#" + lang + "Des").val()) != alertJson[0].msg_Translating) {
                langs = langs + lang + "#";
                titles = titles + $.trim($("#" + lang + "Title").val()).replace("#", "%23") + "#";
                descriptions = descriptions + $.trim($("#" + lang + "Des").val()).replace("#", "%23") + "#";
            }
        }
    });
    $("#hidLang").val(langs);
    $("#hidTitle").val(titles);
    $("#hidDescription").val(descriptions);
    $.fancybox.close();
    return true;
}