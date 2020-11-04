//// Like a movie and get an updated number of likes
//function like() {
//    document.getElementById('like').disabled = true;
//    document.getElementById('dislike').disabled = true;
//    var btn = document.getElementById('like');
//    var imdbId = btn.getAttribute('data-imdbid');
//    var url = 'https://cmdbapi.kaffekod.se/api/'
//    var fullUrl = url + imdbId + '/like';
//    fetch(fullUrl) //we send in a url in which will give us data
//        .then((res) => res.json()) //we get an object of response which is a data then we convert it to a new object which gives us another data
//        .then((data) => {
//            document.getElementById('totalLikes').innerHTML = data.numberOfLikes; //getting the specific data we want
//        })
//        .catch((err) => console.log(err))
//}

//// Dislike a movie and get an updated number of dislikes
//function dislike() {
//    document.getElementById('like').disabled = true;
//    document.getElementById('dislike').disabled = true;
//    var btn = document.getElementById('dislike');
//    var imdbId = btn.getAttribute('data-imdbid');
//    var url = 'https://cmdbapi.kaffekod.se/api/'
//    var fullUrl = url + imdbId + '/dislike';
//    fetch(fullUrl)
//        .then((res) => res.json())
//        .then((data) => {
//            document.getElementById('totalDislikes').innerHTML = data.numberOfDislikes;
//        })
//        .catch((err) => console.log(err))
//}

function likeBtnClick() {
    document.getElementById("likeHoverImg").src = "/Images/likeColor.jpg";
    document.getElementById("dislikeHoverImg").src = "/Images/dislikeGray.jpg";
    disableEverything();
}

function dislikeBtnClick() {
    document.getElementById("dislikeHoverImg").src = "/Images/dislikeColor.jpg";
    document.getElementById("likeHoverImg").src = "/Images/likeGray.jpg";
    disableEverything();
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


//function changeLikeImage() {
//    var likeImage = document.getElementById('like-logo');
//    var dislikeImage = document.getElementById('dislike-logo');
//    if (likeImage.src.match("/Images/likeBW.jpg")) {
//        likeImage.src = "/Images/likeColor.jpg"
//        dislikeImage.src = "/Images/dislikeGray.jpg"
//    }
//    else {
//        image.src = "/Images/likeBW.jpg"
//    }
//};

//function changeDislikeImage() {
//    var likeImage = document.getElementById('like-logo');
//    var dislikeImage = document.getElementById('dislike-logo');
//    if (dislikeImage.src.match("/Images/dislikeBW.jpg")) {
//        likeImage.src = "/Images/likeGray.jpg"
//        dislikeImage.src = "/Images/dislikeColor.jpg"
//    }
//    else {
//        image.src = "/Images/dislikeBW.jpg"
//    }
//};