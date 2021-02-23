$(document).ready(function(){
    $('.brands').click(function(){
        $('#brands').toggleClass('d-block');
    })
    $('.buy').click(function(){
        $('.bottom').addClass("clicked");
      });
      
      $('.remove').click(function(){
        $('.bottom').removeClass("clicked");
      });

      $('.user a').click(function(e){
        e.preventDefault();
        $('.user ul').toggleClass('d-block');
      })
$('.shop').click(function(){
  if($('.cart-modal').hasClass('fade')){
    $('.cart-modal').removeClass('fade');
    $('.cart-modal').css('display','block');
  }
})
 $('.close').click(function(){
  if(!($('.cart-modal').hasClass('fade'))){
    $('.cart-modal').addClass('fade');
    $('.cart-modal').css('display','none');
  }
 })



        $(".product-item").hover(function(){
          $(this).children('.caption').children('.inner').children('.button-group').css('opacity','1');
          }, function(){
            $(this).children('.caption').children('.inner').children('.button-group').css('opacity','0');
        });
      
})

let stickyHeader = document.querySelector("header");
    let sticky = header.offsetTop;
    console.log(header.offsetTop);
    console.log(window.pageYOffset);
    function makeStickyNav() {
        if (window.pageYOffset > sticky) {
            stickyHeader.classList.add("sticky-top");

        } else {
            stickyHeader.classList.remove("sticky-top");
        }
    }
    $(window).scroll(function () {
        makeStickyNav();
    });
    

    function openNav() {
        document.getElementById("mySidepanel").style.width = "350px";
      }
      
      /* Set the width of the sidebar to 0 (hide it) */
      function closeNav() {
        document.getElementById("mySidepanel").style.width = "0";
      }
    // document.querySelector(".shop").addEventListener('click',function(){
    //   $('cart-modal').toggleClass('show');
    // });
      
    var email = document.getElementById('email'),
    button = document.getElementById('button');

function validateEmail(email) {
    var ex = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
    return ex.test(email);
}
$('.owl-carousel').owlCarousel({
  loop: true,
  margin: 10,
  nav: false,
  dots: true,
  responsive: {
      0: {
          items: 1
      },
      400: {
          items: 2
      },
      600: {
          items: 3
      },
      1000: {
          items: 6
      }
  }
});

// email.addEventListener('keydown', function() {
//   var email = this.value;
  
//   if(validateEmail(email)) {
//     button.classList.add('is-active');
//   }
// });

// button.addEventListener('click', function(e){
//   e.preventDefault();
//   this.classList.add('is-done','is-active');
  
//   setTimeout(function(){ 
//     button.innerHTML = "Təşəkkürlər! Siz abunə oldunuz."
//   }, 500);
// });

$('.sim-thumb').on('click', function() {
  $('#main-product-image').attr('src', $(this).data('image'));
})


jQuery(document).ready(function(){
  // This button will increment the value
  $('[data-quantity="plus"]').click(function(e){
      // Stop acting like a button
      e.preventDefault();
      // Get the field name
      fieldName = $(this).attr('data-field');
      // Get its current value
      var currentVal = parseInt($('input[name='+fieldName+']').val());
      // If is not undefined
      if (!isNaN(currentVal)) {
          // Increment
          $('input[name='+fieldName+']').val(currentVal + 1);
      } else {
          // Otherwise put a 0 there
          $('input[name='+fieldName+']').val(0);
      }
  });
  // This button will decrement the value till 0
  $('[data-quantity="minus"]').click(function(e) {
      // Stop acting like a button
      e.preventDefault();
      // Get the field name
      fieldName = $(this).attr('data-field');
      // Get its current value
      var currentVal = parseInt($('input[name='+fieldName+']').val());
      // If it isn't undefined or its greater than 0
      if (!isNaN(currentVal) && currentVal > 0) {
          // Decrement one
          $('input[name='+fieldName+']').val(currentVal - 1);
      } else {
          // Otherwise put a 0 there
          $('input[name='+fieldName+']').val(0);
      }
  });
});




