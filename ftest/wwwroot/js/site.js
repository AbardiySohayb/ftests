// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
    const observerOptions = {
        root: null,
        threshold: 0.5,
    };

    const observer = new IntersectionObserver(
        handleIntersection,
        observerOptions
    );

    const animatedElements = document.querySelectorAll(".animated-on-scroll");

    animatedElements.forEach((element) => {
        observer.observe(element);
    });

    function handleIntersection(entries, observer) {
        entries.forEach((entry) => {
            if (entry.isIntersecting) {
                animateElement(entry.target);
                observer.unobserve(entry.target);
            }
        });
    }

    function animateElement(element) {
        anime({
            targets: element,
            opacity: [0, 1],
            translateY: [50, 0],
            duration: 1000,
            easing: "easeInOutQuad",
        });
    }
});
const observer1 = new IntersectionObserver((entries) => {
    entries.forEach((entry) => {
        console.log(entry);
        if (entry.isIntersecting) {
            entry.target.classList.add("show");
        } else {
            entry.target.classList.remove("show");
        }
    });
});
const hiddenElements = document.querySelectorAll(".hidden");
hiddenElements.forEach((el) => observer1.observe(el));
/arrow/
const arrow = document.getElementById("arrow");
const btnAdd = document.getElementById("btnAdd");
arrow.style.top = `${btnAdd.offsetTop + btnAdd.offsetHeight / 2 - arrow.offsetHeight / 2
    }px`;