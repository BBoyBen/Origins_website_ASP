var IDInterval;


function userAction() {
    window.clearInterval(IDInterval);
    IDInterval = setInterval(autoSlide, 5000);
}

function autoSlide() {
    var nextButton = document.getElementById('nextButton');
    nextButton.click();
}

function StartAnim() {
    IDInterval = setInterval(autoSlide, 5000);
}