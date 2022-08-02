// Fixed navbar
window.onscroll = function () { myFunction() };

var navbar = document.getElementById("navbar");

var sticky = navbar.offsetTop;

function myFunction() {
    if (window.pageYOffset >= sticky) {
        navbar.firstElementChild.classList.add("sticky")
        navbar.firstElementChild.classList.add("shadow")
        navbar.classList.add("pt-5")
    } else {
        navbar.firstElementChild.classList.remove("sticky");
        navbar.firstElementChild.classList.remove("shadow")
        navbar.classList.remove("pt-5")
    }
}

