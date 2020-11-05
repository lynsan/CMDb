function getApiLike() {
    var btn = document.getElementById('ListItemLike');
    var imdbId = btn.getAttribute('data-imdbid');
    var url = 'https://cmdbapi.kaffekod.se/api/'
    var fullUrl = url + imdbId + '/like';
    fetch(fullUrl)
        .then((res) => res.json())
        .then((data) => {
            document.getElementById('numberOfLikes').innerHTML = data.numberOfLikes;
        })
        .catch((err) => console.log(err))
}

function getApiDislike() {
    var btn = document.getElementById('ListItemDislike');
    var imdbId = btn.getAttribute('data-imdbid');
    var url = 'https://cmdbapi.kaffekod.se/api/'
    var fullUrl = url + imdbId + '/dislike';
    fetch(fullUrl)
        .then((res) => res.json())
        .then((data) => {
            document.getElementById('numberOfDislikes').innerHTML = data.numberOfDislikes;
        })
        .catch((err) => console.log(err))
}

function likeBtnClick() {
    document.getElementById("likeHoverImg").src = "/Images/likeColor.jpg";
    document.getElementById("dislikeHoverImg").src = "/Images/dislikeGray.jpg";
    disableEverything();
    getApiLike();
}

function dislikeBtnClick() {
    document.getElementById("dislikeHoverImg").src = "/Images/dislikeColor.jpg";
    document.getElementById("likeHoverImg").src = "/Images/likeGray.jpg";
    disableEverything();
    getApiDislike();
}

function disableEverything() {
    document.getElementsByClassName("hover")[0].style.opacity = 1;
    document.getElementsByClassName("hover")[1].style.opacity = 1;
    document.getElementById("ListItemDislike").style.pointerEvents = "none";
    document.getElementById("ListItemLike").style.pointerEvents = "none";
}

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

function search(ev) {
    if (ev.target.value.length > 0) {
        ev.target.parentElement.classList.add('not-empty');
    }
    else {
        ev.target.parentElement.classList.remove('not-empty');
    }
}
