
//transperent nav
// Sticky header style change on sroll
$(window).scroll(function() {
    if ($(this).scrollTop() > 100) {
        $("header").addClass("stuck");
    } else {
        $("header").removeClass("stuck");
    }
});

/*=========================*/
/*========on hover dropdown navigation====*/
/*==========================*/
$(document).ready(function() {

    $(".js-activated").dropdownHover({
        instantlyCloseOthers: false,
        delay: 0
    }).dropdown();

});

/* ==============================================
 main flex slider
 =============================================== */
$(window).load(function() {
    $(".main-flex-slider").flexslider({
        slideshowSpeed: 4000,
        directionNav: false,
        animation: "fade",
        controlNav: false,
        direction: "horizontal"
    });
});

/*=========================*/
/*========Animation on scroll with wow.js====*/
/*==========================*/

wow = new WOW(
        {
            animateClass: "animated",
            offset: 100,
            mobile: true
        }
);
wow.init();


/*=========================*/
/*========portfolio mix====*/
/*==========================*/
$("#grid").mixitup();

//
//
//
///* ==============================================
// Auto Close Responsive Navbar on Click
// =============================================== */
//
//function close_toggle() {
//    if ($(window).width() <= 768) {
//        $('.navbar-collapse a').on('click', function() {
//            $('.navbar-collapse').collapse('hide');
//        });
//    }
//    else {
//        $('.navbar .navbar-default a').off('click');
//    }
//}
//close_toggle();
//
//$(window).resize(close_toggle);


//popups//
$(document).ready(function() {
  $(".popup-img").magnificPopup({type:"image"});
});
/* ==============================================
 Smooth Scroll To Anchor
 =============================================== */

$(function() {
  $(".scrollto a[href*=#]:not([href=#])").click(function() {
    if (location.pathname.replace(/^\//,"") == this.pathname.replace(/^\//,"") && location.hostname == this.hostname) {
      var target = $(this.hash);
      target = target.length ? target : $("[name=" + this.hash.slice(1) +"]");
      if (target.length) {
        $("html,body").animate({
          scrollTop: target.offset().top
        }, 1000);
        return false;
      }
    }
  });
});


/************parallax*********************/
//$(function() {
//    $.stellar({
//        horizontalScrolling: false
//    });
//});

//owl carousel for testimonials
$(document).ready(function() {

    //$("#testi-carousel").owlCarousel({
    //    // Most important owl features
    //    items: 1,
    //    itemsCustom: false,
    //    itemsDesktop: [1199, 1],
    //    itemsDesktopSmall: [980, 1],
    //    itemsTablet: [768, 1],
    //    itemsTabletSmall: false,
    //    itemsMobile: [479, 1],
    //    singleItem: false,
    //    startDragging: true,
    //    autoPlay: 4000
    //});

});
$(window).load(function() {
    $(".slide-post").flexslider({
      slideshowSpeed: 4000

    });
});


/* ==============================================
 Counter Up
 =============================================== */
//jQuery(document).ready(function($) {
//    $(".counter").counterUp({
//        delay: 100,
//        time: 800
//    });
//});
  
  //video background
//  jQuery(function() {
//    jQuery(".player").mb_YTPlayer();
//});
                
                /*=========================*/
/*========tooltip and popovers====*/
/*==========================*/
//$("[data-toggle=popover]").popover();

//$("[data-toggle=tooltip]").tooltip();





