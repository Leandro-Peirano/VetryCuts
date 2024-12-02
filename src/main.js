

const slider = document.getElementById("slider");
const maxSlides = slider.children.length;

var currentSlide = 1;

setInterval(() => {
    currentSlide++;
    if(currentSlide > maxSlides)
        currentSlide = 1;
    slider.style.transform = `translateX(${100 * (1 - currentSlide)}%)`;
}, 2000);
