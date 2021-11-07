$(document).ready(() => {
    // Hide login modal
    $('#loginModal')
        .addClass('d-none')
        .css({
            right: -$('#loginModal').outerWidth(),
        });

    setTimeout(() => {
        $('.alert').remove();
    }, 3000);
});

$('#btnLogin').click(async (e) => {
    e.preventDefault();
    await $.ajax({
        url: "http://localhost:56633/Home/LogIn",
        type: 'GET',
        success: function (res) {
            let modalLogin = $('#loginModal');
            if (modalLogin.children().length === 0) {
                $('#loginModal').append(res);
            }

        }
    });
    if ($('#loginModal').css('right') === '0px') {
        $('#loginModal').animate(
            {
                right: -$('#loginModal').outerWidth(),
            },
            1000,
            () => {
                $('#loginModal').addClass('d-none');
            }
        );
    } else {
        $('#loginModal').removeClass('d-none').animate(
            {
                right: 0,
            },
            1000
        );
    }
});

// Header Search
$('#headerSearch').change(() => {
    $('#filteredSearchArea').removeClass('d-none');

    if ($('#headerSearch').val() == '') {
        $('#filteredSearchArea').addClass('d-none');
    }
});

$(window).scroll(function () {

    if ($(window).scrollTop() > 80) {
        $('nav').addClass('sticky');
    }

    if ($(window).scrollTop() < 81) {
        $('nav').removeClass('sticky');
    }
});

// Slide

var slideIndex = 0;
showSlides();
function showSlides() {
    var i;
    var slides = document.getElementsByClassName('mySlides');
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = 'none';
    }
    slideIndex++;
    if (slideIndex > slides.length) {
        slideIndex = 1;
    }
    slides[slideIndex - 1].style.display = 'block';

    setTimeout(showSlides, 4000);
}


