const dark_css = "css/dark.css";
const light_css = "css/light.css";
var current_css = dark_css;
var isDark = true;

function setCSS(cssLinkIndex) {
    if (document.cookie.length != 0) {
        console.log(document.cookie.length + " saved cookie(s)");
        var array = document.cookie.split("=");
        for (let index = 0; index < array.length; index+=2) {
            console.log(array[index]);
            if(array[index] == "dark") {
                isDark = array[index + 1]
                break;
            }
        }
    } else {
        console.log("no saved cookies");
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
}

let slideIndex_0 = 1;
let slideIndex_1 = 1;
let slideIndex_2 = 1;
showSlides_0(slideIndex_0);
showSlides_1(slideIndex_1);
showSlides_2(slideIndex_2);

function nextSlide() {
  showSlides_0(slideIndex_0 += 1);
  showSlides_1(slideIndex_1 += 1);
  showSlides_2(slideIndex_2 += 1);
}

function showSlides_0(n) {
  let slides = document.getElementsByClassName("slide_0");
  if (n > slides.length) {slideIndex_0 = 1}
  if (n < 1) {slideIndex_0 = slides.length}
  for (let i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  console.log(slides.length);
  slides[slideIndex_0-1].style.display = "block";
}

function showSlides_1(n) {
    let slides = document.getElementsByClassName("slide_1");
    if (n > slides.length) {slideIndex_1 = 1}
    if (n < 1) {slideIndex_1 = slides.length}
    for (let i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";
    }
    slides[slideIndex_1-1].style.display = "block";
}

function showSlides_2(n) {
    let slides = document.getElementsByClassName("slide_2");
    if (n > slides.length) {slideIndex_2 = 1}
    if (n < 1) {slideIndex_2 = slides.length}
    for (let i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";
    }
    slides[slideIndex_2-1].style.display = "block";
}

setInterval(function(){ nextSlide(); }, 5000);