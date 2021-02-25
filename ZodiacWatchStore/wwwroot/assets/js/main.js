$(document).ready(function () {
    $(document).on('click', '.fa-eye', function () {
        let productId = $(this).parent().prev().val();
        $.ajax({
            url: '/Home/QuickView?id=' + productId,
            type: 'Get',
            success: function (res) {
                $('#quick-view .modal-content').append(res);
                $('.close').click(function () {
                    $('#quick-view .modal-content').children('.modal-body').remove();
                })
            }
        })
    })

    $(document).on('click', "#addToBasket", function () {
        let productId = $(this).next().val();
        $('.cart-modal .modal-body>div').children('.row').html("");
        $.ajax({
            url: '/Product/AddToBasket?Id=' + productId,
            type: 'Get',
            success: function (res) {
                $('.cart-modal .modal-body>div').children('.row').append(res);
                swal("Səbətə Əlavə Olundu!", {
                    buttons: false,
                    timer: 1000,
                    icon: "success",
                });
            }
        })
    })

    $(document).on('submit', '.deleteProduct', function (e) {
        e.preventDefault();
        let productId = $(this).children('input').val();
        console.log(productId);
        $.ajax({
            url: '/Product/DeleteFromBasket/?id=' + productId,
            type: 'Get',
            success: function (res) {
                $('.cart-modal .modal-body>div').children('.row').append(res);
            }
        })
    })
    $('.btn-wishlist').click(function () {
        $(this).children(".fa-heart").toggleClass("fas");
    })

    //$('.btn-cart').click(function () {
    //    swal("This modal will disappear soon!", {
    //        buttons: false,
    //        timer: 1000,
    //        icon : "success",
    //    });
    //})
    $('.big-carousel').owlCarousel({
        loop: true,
        margin: 10,
        nav: false,
        dots: true,
        autoplay: false,
        autoplayTimeout: 2000,
        autoplayHoverPause: true,

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
                items: 5
            }
        }
    });
    $('.mini-carousel').owlCarousel({
        loop: true,
        margin: 10,
        nav: false,
        dots: true,
        autoplay: true,
        autoplayTimeout: 2000,
        autoplayHoverPause: true,

        responsive: {
            0: {
                items: 0
            },
            400: {
                items: 0
            },
            600: {
                items: 0
            },
            1000: {
                items: 1
            }
        }
    });

        $('.brands').click(function () {
            $('#brands').toggleClass('d-block');
        })
        $('.buy').click(function () {
            $('.bottom').addClass("clicked");
        });

        $('.remove').click(function () {
            $('.bottom').removeClass("clicked");
        });

        $('.user a').click(function (e) {
            e.preventDefault();
            $('.user ul').toggleClass('d-block');
        })
        $('.shop').click(function () {
            if ($('.cart-modal').hasClass('fade')) {
                $('.modal-backdrop').addClass('show');
                $('.modal-backdrop').addClass('d-block');
                $('.cart-modal').removeClass('fade');

                $('.cart-modal').css('display', 'block');
            }
        })
        $('.close').click(function () {
            if (!($('.cart-modal').hasClass('fade'))) {
                $('.modal-backdrop').removeClass('d-block');
                $('.cart-modal').addClass('fade');
                $('.modal-backdrop').removeClass('show');
                $('.cart-modal').css('display', 'none');
            }
        })
        $('.btn-quick').click(function () {
            console.log("jkdhkajs");
            $(".view-modal").removeClass('show');
        })

    $(document).on('submit', '.deleteProduct', function (e) {
        e.preventDefault();
        $(this).parent().parent().parent().remove();
    });
       



        $(".product-item").hover(function () {
            $(this).children('.caption').children('.inner').children('.button-group').css('opacity', '1');
        }, function () {
            $(this).children('.caption').children('.inner').children('.button-group').css('opacity', '0');
        });

    })

    let stickyHeader = document.querySelector("header");
    let sticky = header.offsetTop + 170;
    function makeStickyNav() {
        if (window.pageYOffset > sticky) {
            stickyHeader.classList.add("fixed-top");

        } else {
            stickyHeader.classList.remove("fixed-top");
        }
    }
    $(window).scroll(function () {
        makeStickyNav();
    });


    var email = document.getElementById('email'),
        button = document.getElementById('button');

    function validateEmail(email) {
        var ex = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
        return ex.test(email);
    }

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

    $('.sim-thumb').on('click', function () {
        $('#main-product-image').attr('src', $(this).data('image'));
    })


jQuery(document).ready(function () {
    // This button will increment the value
    $('[data-quantity="plus"]').click(function (e) {
        // Stop acting like a button
        e.preventDefault();
        // Get the field name
        fieldName = $(this).attr('data-field');
        // Get its current value
        var currentVal = parseInt($('input[name=' + fieldName + ']').val());
        // If is not undefined
        if (!isNaN(currentVal)) {
            // Increment
            $('input[name=' + fieldName + ']').val(currentVal + 1);
        } else {
            // Otherwise put a 0 there
            $('input[name=' + fieldName + ']').val(0);
        }
    });
    // This button will decrement the value till 0
    $('[data-quantity="minus"]').click(function (e) {
        // Stop acting like a button
        e.preventDefault();
        // Get the field name
        fieldName = $(this).attr('data-field');
        // Get its current value
        var currentVal = parseInt($('input[name=' + fieldName + ']').val());
        // If it isn't undefined or its greater than 0
        if (!isNaN(currentVal) && currentVal > 0) {
            // Decrement one
            $('input[name=' + fieldName + ']').val(currentVal - 1);
        } else {
            // Otherwise put a 0 there
            $('input[name=' + fieldName + ']').val(0);
        }
    });

});



