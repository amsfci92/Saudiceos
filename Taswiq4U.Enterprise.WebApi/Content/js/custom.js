$(document).ready(function() {
  // setup owl carouser plugin
  var owl = $('.owl-carousel');
  owl.owlCarousel({
    margin: 10,
    loop: true,
    autoplay: true,
    responsive: {
      0: {
        items: 1
      },
      600: {
        items: 2
      },
      1000: {
        items: 4
      }
    }
  })
  $('.productCar').owlCarousel({
    loop:true,
    margin:10,
    nav:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:3
        },
        1000:{
            items:5
        }
    }
})
  // setup owl carouser plugin End

  // input plus and minus
  function incrementValue(e) {
  e.preventDefault();
  var fieldName = $(e.target).data('field');
  var parent = $(e.target).closest('div');
  var currentVal = parseInt(parent.find('input[name=' + fieldName + ']').val(), 10);

  if (!isNaN(currentVal)) {
    parent.find('input[name=' + fieldName + ']').val(currentVal + 1);
  } else {
    parent.find('input[name=' + fieldName + ']').val(0);
  }
}

function decrementValue(e) {
  e.preventDefault();
  var fieldName = $(e.target).data('field');
  var parent = $(e.target).closest('div');
  var currentVal = parseInt(parent.find('input[name=' + fieldName + ']').val(), 10);

  if (!isNaN(currentVal) && currentVal > 0) {
    parent.find('input[name=' + fieldName + ']').val(currentVal - 1);
  } else {
    parent.find('input[name=' + fieldName + ']').val(0);
  }
}

$('.input-group').on('click', '.button-plus', function(e) {
  incrementValue(e);
});

$('.input-group').on('click', '.button-minus', function(e) {
  decrementValue(e);
});

  // input plus and minus End



  // navbar fixed top
   $(window).scroll(function() {
       if ($(document).scrollTop() > 20) {
           $('.navbar').css({
            'background':'#FFF',
            'box-shadow':'1px 1px 10px 1px  #DDD',
            'margin-top' : '0',
            'transation' : '.3s all',
           });
       }
       else {
         $('.navbar').css({
          'background':'transparent',
          'box-shadow':'none',
          'margin-top' : '35px',
          'transation' : '.3s all',
         });
       }
   });

});
