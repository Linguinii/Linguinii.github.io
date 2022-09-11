const dark_css = "css/dark.css";
const light_css = "css/light.css";
var current_css = dark_css;
var isDark = true;

function setCSS(cssLinkIndex) {
    if (document.cookie.length != 0) {
        var array = document.cookie.split("=");
        for (let index = 0; index < array.length; index+=2) {
            if(array[index] == "dark") {
                isDark = array[index + 1]
                break;
            }
        }
    }
    
    if (isDark) {
        current_css = dark_css;
    } else {
        current_css = light_css;
    }

    var oldlink = document.getElementsByTagName("link").item(cssLinkIndex);

    var newlink = document.createElement("link");
    newlink.setAttribute("rel", "stylesheet");
    newlink.setAttribute("type", "text/css");
    newlink.setAttribute("href", current_css);

    document.getElementsByTagName("head").item(cssLinkIndex).replaceChild(newlink, oldlink);

    console.log("old "+ oldlink + " new " + newlink);
}

function changeCSS(cssLinkIndex) {

    if (isDark) {
        current_css = light_css;
    } else {
        current_css = dark_css;
    }

    isDark = !isDark;

    document.cookie = "dark=" + isDark

    var oldlink = document.getElementsByTagName("link").item(cssLinkIndex);

    var newlink = document.createElement("link");
    newlink.setAttribute("rel", "stylesheet");
    newlink.setAttribute("type", "text/css");
    newlink.setAttribute("href", current_css);

    document.getElementsByTagName("head").item(cssLinkIndex).replaceChild(newlink, oldlink);

    console.log("old "+ oldlink + " new " + newlink);
}