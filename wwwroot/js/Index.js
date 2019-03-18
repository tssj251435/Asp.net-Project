

var popularLinks = document.querySelectorAll(".popular-pagination");
generateHref(popularLinks, "popPage", "#popularPresents")

var regularLinks = document.querySelectorAll(".regular-pagination");
generateHref(regularLinks, "page")

function generateHref (elements, key, ext = "")
{
    for (var i = 0; i < elements.length; i++) {
        var obj = elements[i]
        var data = obj.dataset.page
        var current = window.location.search.substring(1).split('&')
        var hasPage = current[current.length - 1].search(key)
        if (hasPage >= 0) {
            current.pop()
        }
        var newQuery = current.join('&')
        obj.href = '?' + (newQuery.length === 0 ? '' : newQuery + '&') + key + '=' + data + ext
    }
}

// Her bliver søgebarens position opdateret, når brugeren scroller ned eller op ad siden
document.addEventListener('scroll', function (e) {
    if (window.pageXOffset <= 40) {
        var form = document.getElementById('search-form');
        form.classList.remove('fixed');
        var fc = document.getElementById('first-container');
        fc.style.marginTop = '10px';
    }
    if (window.pageYOffset >= 80) {
        var form = document.getElementById('search-form');
        form.classList.add('fixed');
        var fc = document.getElementById('first-container');
        fc.style.marginTop = '165px';
    }
})

var button = document.querySelectorAll(".read-more");
var presentDescription = document.querySelectorAll(".presentText");


//
for (var i = 0; i < button.length; i++) {
    button[i].addEventListener("click", function (event) {
        var text = event.target.previousElementSibling;
        text.classList.toggle("expanded");
        if (this.textContent === "Læs mere")
            this.textContent = "Skjul";
        else
            this.textContent = "Læs mere";              
    });
}
// Fjerner knappen "læs mere" såfremt gavebeskrivelsens indhold er tom
for (var x = 0; i < presentDescription.length; i++) {
    if (presentDescription[i].textContent === "") {
        button[i].style.visibility = "hidden";
        console.log("test");
    }
    else {
        button[i].style.visibility = "visible";
        console.log("test2");
    }
}


$(document).ready(function () {
    $("#slider-range").slider({
        range: true,
        min: 0,
        max: 2500,
        values: [0, 500],
        slide: function (event, ui) {
            $("#ammount").val(ui.values[0] + " - " + ui.values[1]);
        }
    });
    $("#ammount").val($("#slider-range").slider("values", 0) + " - " + $("#slider-range").slider("values", 1));
});


document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('select[name="who"]').onchange = changeEventHandler;
}, false);



var presentLinks = document.querySelectorAll('.present-image');
for (var i = 0; i < presentLinks.length; i++) {
    presentLinks[i].addEventListener('click', onPresentImageClickEventHandler);
}

//Denne funktion sørger for at man ikke kan forøge en gaves rating ved kun at indtaste en URL-addresse
function onPresentImageClickEventHandler (event) {
    $.ajax({
        method: "PUT",
        headers: {'X-Requested-With': 'XMLHttpRequest'},
        url: "presents/" + event.target.dataset.id + "/rating"
    }).done(function (msg) {
        console.log(msg)
    })
}
































































//var slider = document.getElementById("slider").
//var sliderPrice = document.getElementById("sliderPrice");

//slider.addEventListener("Change", function (e) {
    

//});


//var imageTextSubstring = document.querySelectorAll("p");
//var imageTextFull = document.querySelectorAll("p");


//function Expand() {
//    for (var i = 0; i < imageTextFull.length; i++) {
//        if (imageTextFull[i].textContent.length >= 60) {
//            imageTextSubstring[i].textContent = imageTextFull[i].textContent.substr(0, 90);
//            span[i].textContent = "Læs mere her";
//            span[i].classList.add("textDec");
//        }
//    }
//}

//Expand();

