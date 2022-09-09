const parallax = document.getElementById("parallax");

window.addEventListener("scroll", function() {
    let offset = this.window.pageYOffset;
    parallax.style.backgroundPositionY = offset * 0.7 + "px";
})