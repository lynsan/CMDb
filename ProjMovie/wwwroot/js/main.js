function search(ev) {
    if (ev.target.value.length > 0) {
        ev.target.parentElement.classList.add('not-empty');
    }
    else {
        ev.target.parentElement.classList.remove('not-empty');
    }
    apiSearch(ev);
}

function apiSearch(ev) {
    var omdbUrl = 'https://www.omdbapi.com/?apikey=aa247f46&s='
    var searchText = ev.target.value

    fetch(omdbUrl + searchText)
        .then((res) => res.json())
        .then((data) => {

            
            if (data.Response === "True") {
                document.getElementById('first').innerHTML = data.Search[0].Title
                document.getElementById('firstLink').href = "/Detail/Index/" + data.Search[0].imdbID

                document.getElementById('second').innerHTML = data.Search[1].Title
                document.getElementById('secondLink').href = "/Detail/Index/" + data.Search[1].imdbID

                document.getElementById('third').innerHTML = data.Search[2].Title
                document.getElementById('thirdLink').href = "/Detail/Index/" + data.Search[2].imdbID

                document.getElementById('fourth').innerHTML = data.Search[3].Title
                document.getElementById('fourthLink').href = "/Detail/Index/" + data.Search[3].imdbID
            }
            else {

                document.getElementById('first').innerHTML = "Search not found!"
                document.getElementById('second').innerHTML = ""
                document.getElementById('third').innerHTML = ""
                document.getElementById('fourth').innerHTML = ""

            }

        })
        .catch((err) => console.log(err))
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




