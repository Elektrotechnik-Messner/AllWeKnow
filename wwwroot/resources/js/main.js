function delay(time) {
    return new Promise((resolve) =>
        setTimeout(resolve, time)
    ); /* delay(500).then(() => (do the code here)); */
}

document.addEventListener("scroll", (event) => {
    var top = window.scrollY || document.documentElement.scrollTop;
    var body = document.body;
    var nav = document.querySelector("nav.navbar");

    if (top > 384) {
        document.body.classList.add("scrolled");
        nav.classList.add("shadow");
    } else {
        document.body.classList.remove("scrolled");
        nav.classList.remove("shadow");
    }
});

