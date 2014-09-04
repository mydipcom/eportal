// show box
function ShowBox(msg, no, yes) {
    var oktext = "OK";
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
        'showCloseButton': true
    });
    return false;
}


function ShowConfirm(msg, webPath) {
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



function ShowConfirm2(msg) {
    var box = "<div id=\"inline2\" class=\"word_contend\">"
                    + "<p>" + msg + "</p>"
                    + "<p class=\"no_button\" onmouseover=\"ButtonOver(this)\" onmouseout=\"ButtonOut(this)\" onclick=\"ClickNo()\">" + alertJson[0].msg_ButtonCancel + "</p>"
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
        'showCloseButton': true
    });
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