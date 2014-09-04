
function CreateUrl(url) {
    if (alertJson[0].msg_GlobalRegion == "en-us") {
        return "/" + url;
    }
    else {
        return "/" + alertJson[0].msg_GlobalRegion + "/" + url;
    }
}

function CreateAjaxUrl(url) {
    if (alertJson[0].msg_GlobalRegion == "en-us") {
        return "/" + url + "?t=" + new Date().getTime();
    }
    else {
        return "/" + alertJson[0].msg_GlobalRegion + "/" + url + "?t=" + new Date().getTime();
    }
}
 
 

var fill = true, css = "border-color", color = "#0E8C7D #0E8C7D #0E8C7D #0E8C7D";
 

function IsNum(e) {
    var obj = e.srcElement || e.target;
    var dot = obj.value.indexOf(".");
    var key = e.keyCode || e.which;
    if (key == 8 || key == 9 || key == 46 || (key >= 37 && key <= 40))
        return true;
    if (key <= 57 && key >= 48) {
        if (dot == -1)
            return true;
        else if (obj.value.length <= dot + 1)
            return true;
    } else if ((key == 46) && dot == -1) {
        return true;
    }
    return false;
}


function autoValue(data) {
    try {
        var v1 = $("#" + data.data.pa1).val();
        var v2 = (100 - parseInt(v1));

        if (parseFloat(v2) < 0) {
            $("#" + data.data.pa1).val("0");
            $("#" + data.data.pa2).val("0");
        }
        else {
            $("#" + data.data.pa2).val(v2);
        }

    }
    catch (e) {
    }
}
 

 
 
 

 
 
 
 


 
 