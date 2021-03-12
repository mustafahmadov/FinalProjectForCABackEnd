//import { get } from "jquery";

$(document).ready(function () {
    $(document).on('click', '.fa-eye', function () {
        let productId = $(this).parent().prev().val();
        $.ajax({
            url: '/Home/QuickView?id=' + productId,
            data: {
                id: productId,
            },
            type: 'Get',
            success: function (res) {
                $('#quick-view .modal-content').append(res);
                $('.close').click(function () {
                    $('#quick-view .modal-content').children('.modal-body').remove();
                })
            }
        })
    })
    let WishlistCount = () => {
        $.ajax({
            url: '/Product/WishListCount',
            type: 'Get',
            success: function (res) {
                $('.heart-count').html(res);
            }
        });
    }
    WishlistCount();


    let cardTotal = () => {
        $.ajax({
            url: '/Basket/GetBasketTotal',
            type: 'Get',
            success: function (res) {
                $('#total_cart_amt').html(res);
                $('#product_total_amt').html(res);
            }
        });
    }

    cardTotal();


    let getBasketCount = () => {
        let basketCount = $('.shop span');
        $.ajax({
            url: '/Product/GetBasketCount',
            type: 'GET',
            success: function (res) {
                basketCount.text(res);
            }
        })
    }
    getBasketCount();



    let getBasketTotal = () => {
        let basketTotal = $('.basketTotal');
        $.ajax({
            url: '/Product/GetBasketTotal',
            type: 'GET',
            success: function (res) {
                basketTotal.text('₼' + res);
            }
        })
    }
    getBasketTotal();

    $(document).on('click', "#addToBasket", function () {
        let productId = $(this).next().val();
        let productCount = $('#quickViewInput').val();
        $('.cart-modal .modal-content .modal-body .row').remove();
        $.ajax({
            url: '/Product/AddToBasket',
            data: {
                id: productId,
                count: productCount,
            },
            type: 'Get',
            success: function (res) {
                console.log(res);
                $('.cart-modal .modal-content .modal-body').prepend(res);
                swal("Səbətə Əlavə Olundu!", {
                    buttons: false,
                    timer: 1000,
                    icon: "success",

                });
                getBasketCount();
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
                $('.cart-modal .modal-content .modal-body .row').remove();
                $('.cart-modal .modal-content .modal-body').prepend(res);
                getBasketCount();
                getBasketTotal();
            }

        })
        
    })

    $(document).on('click', '#addToWishlist', function () {
        let productId = $(this).next().val();
        $.ajax({
            url: '/Product/AddToWishList?id=' + productId,
            type: 'Get',
            success: function (res) {
                swal("Arzu siyahısına əlavə olundu!", {
                    buttons: false,
                    timer: 1000,
                    icon: "success",

                });
                console.log(res);
                WishlistCount();
            }
        });
    })

    $(document).on('click', '#removeFromWishlist', function (e) {
        e.preventDefault();
        let productId = $(this).prev().val();
        $(this).parent().parent().parent().remove();
        $.ajax({
            url: '/Product/RemoveFromWishList?id=' + productId,
            type: 'Get',
            success: function (res) {
                $('.table').append(res);
                $.ajax({
                    url: '/Product/WishListCount',
                    type: 'Get',
                    success: function (res) {
                        $('.heart-count').html(res);
                    }
                });
            }
        })
    })

    $(document).on('click', '.plusBtn', function () {
        let inputVal = $(this).parent().prev().children('.page-link');
        let itemTotal = $(this).parent().parent().parent().parent().next().children(".price_money").children('.itemTotal').children('.itemVal');
        let productId = $(this).next().val();
        let anotherInputVal = $(this).parent().prev().prev().children('.minBtn');
        console.log(itemTotal);
        $.ajax({
            url: '/Basket/IncProductCountOne?id=' + productId,
            type: "Get",
            success: function (res) {
                itemTotal.html(res);
                getBasketCount();
                $.ajax({
                    url: '/Basket/GetBasketTotal',
                    type: 'Get',
                    success: function (res) {
                        $('#total_cart_amt').html(res);
                        $('#product_total_amt').html(res);
                        $.ajax({
                            url: '/Basket/GetProductCount?id=' + productId,
                            type: 'GET',
                            success: function (res) {
                                inputVal.val(res);
                            }
                        })
                    }
                });  
            }
        })
    })

    $(document).on('click', '.minBtn', function () {
        let inputVal = $(this).parent().next().children('.page-link');
        let thisVal = $(this);
        let itemTotal = $(this).parent().parent().parent().parent().next().children(".price_money").children('.itemTotal').children('.itemVal');
        let productId = $(this).next().val();
        $('.productCard').children('.row').remove();
        console.log(itemTotal);
        $.ajax({
            url: '/Basket/DecProductCountOne?id=' + productId,
            type: "Get",
            success: function (res) {
                $('.productCard').append(res);
                getBasketCount();
                $.ajax({
                    url: '/Basket/GetBasketTotal',
                    type: 'Get',
                    success: function (res) {
                        $('#total_cart_amt').html(res);
                        $('#product_total_amt').html(res);
                    }
                });
            }
        })
    })

    $(document).on('submit', '#removeFromCard', function () {
        let productId = $(this).next().val();
        let deletedRow = $(this).parent().parent().parent().parent();
        $('.productCard').children('.row').remove();
        $.ajax({
            url: '/Basket/DeleteFromCard?id=' + productId,
            type: 'Get',
            success: function (res) {
                $('.productCard').append(res);
                let basketCount = $('.shop span');
                $.ajax({
                    url: '/Product/GetBasketCount',
                    type: 'GET',
                    success: function (res) {
                        basketCount.text(res);
                    }
                })
            }
        })
    })

    $(document).on('keyup', '#input-search', function () {
        let search = $(this).val().trim();
        $("#searchList li").slice(1).remove();
        if (search.length > 0) {
            $.ajax({
                url: "/Product/Search?search=" + search,
                type: "Get",
                success: function (res) {
                    $("#searchList").append(res);
                }
            })
        }
    })
   
    

    $('.plusBtn').click(function (e) {
        let inputVal = $(this).parent().prev().children('.page-link');
        e.preventDefault();
    })
    $('.minBtn').click(function (e) {
        let inputVal = $(this).parent().next().children('.page-link');
        e.preventDefault();
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
                items: 1
            },
            400: {
                items: 2
            },
            600: {
                items: 2
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

    $('.user>a').click(function (e) {
        e.preventDefault();
            $('.user ul').toggleClass('d-block');
        })
    $('.shop').click(function (e) {
        e.preventDefault();
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
    $('.minus').click(function () {
        var $input = $(this).parent().find('input');
        var count = parseInt($input.val()) - 1;
        count = count < 1 ? 1 : count;
        $input.val(count);
        $input.change();
        return false;
    });
    $('.plus').click(function () {
        var $input = $(this).parent().find('input');
        $input.val(parseInt($input.val()) + 1);
        $input.change();
        return false;
    });

    

});





