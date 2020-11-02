function ShowInfo() {
    const accordionItemHeaders = document.querySelectorAll(".accordion-item-header");

    accordionItemHeaders.forEach(accordionItemHeader => {
        accordionItemHeader.addEventListener("click", event => {
            accordionItemHeader.classList.toggle("active");
            const accordionItemBody = accordionItemHeader.nextElementSibling;
            if (accordionItemHeader.classList.contains("active")) {
                accordionItemBody.style.maxHeight = accordionItemBody.scrollHeight + "px";
            }
            else {
                accordionItemBody.style.maxHeight = 0;
            }
        });
    });
}

function ReadMore(ev) {
    const btn = ev.target;
    const dots = btn.parentElement.closest('.movie-plot').querySelector('.dots');
    const moreText = btn.parentElement.closest('.movie-plot').querySelector('.more');
    const btnText = btn.parentElement.closest('.movie-plot').querySelector('.myBtn');

    if (dots.style.display === "none") {
        dots.style.display = "inline";
        btnText.innerHTML = "Read more";
        moreText.style.display = "none";
    } else {
        dots.style.display = "none";
        btnText.innerHTML = "Read less";
        moreText.style.display = "inline";
    }
}

function changeLikeImage() {
    var likeImage = document.getElementById('like-logo');
    var dislikeImage = document.getElementById('dislike-logo');
    if (likeImage.src.match("/Images/likeBW.jpg")) {
        likeImage.src = "/Images/likeColor.jpg"
        dislikeImage.src = "/Images/dislikeGray.jpg"
    }
    else {
        image.src = "/Images/likeBW.jpg"
    }
};

function changeDislikeImage() {
    var likeImage = document.getElementById('like-logo');
    var dislikeImage = document.getElementById('dislike-logo');
    if (dislikeImage.src.match("/Images/dislikeBW.jpg")) {
        likeImage.src = "/Images/likeGray.jpg"
        dislikeImage.src = "/Images/dislikeColor.jpg"
    }
    else {
        image.src = "/Images/dislikeBW.jpg"
    }
};