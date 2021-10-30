$(document).ready(function(){

    $('#adv-slider').owlCarousel({
        margin: 10,
        nav: true,
        loop:true,
        rtl:true,
        autoplay: true,
        dots:false,
        autoplayHoverPause: true,
        responsive: {
            0:{
                items: 1
            },
            500:{
                items: 2
            },
            600:{
                items: 2
            },
            700:{
                items: 2
            },
            800:{
                items: 3
            },
            900:{
                items: 4
            },
            1200:{
                items: 5
            },
            1400:{
                items: 6
            }
        }
    });
});