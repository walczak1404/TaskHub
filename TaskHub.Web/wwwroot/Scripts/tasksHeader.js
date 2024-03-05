const logo = document.querySelector(".tasks-header__logo > img");
const logoutText = document.querySelector(".tasks-header__logout__text");

window.addEventListener("load", ImgSwitch);
window.addEventListener("load", LogoutTextTrigger);
window.addEventListener("resize", ImgSwitch);
window.addEventListener("resize", LogoutTextTrigger);

function ImgSwitch() {
    if (document.documentElement.clientWidth > 900) {
        logo.src = "/Assets/logo/logo-transparent.png";
    } else {
        logo.src = "/Assets/logo/favicon-color.png";
    }
}

function LogoutTextTrigger() {
    if (document.documentElement.clientWidth > 900) {
        logoutText.textContent = "Sign Out"
    } else {
        logoutText.textContent = "";
    }
}