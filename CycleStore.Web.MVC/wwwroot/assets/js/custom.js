(function ($) {
	"use strict";
	var cycling = {
		initialised: false,
		version: 1.0,
		init: function () {

			if(!this.initialised) {
				this.initialised = true;
			} else {
				return;
			}

			// Functions Calling

			this.loader();
			this.products_slider();
			this.testimonial();
			this.popup();
			this.toggle_menu();
			this.product_count();

		},

        // loader start
        loader: function () { 
            $(window).on('load', function() {
                var load;
                setTimeout(function() {
                    $('body').addClass('load');
                }, 500);
            });
        },
        // loader end
        // products slider start
        products_slider: function () { 
            if($('.cl-products-slider').length > 0){
                var swiper = new Swiper('.cl-products-slider .swiper-container', {
                    slidesPerView: 4,
                    spaceBetween: 24, 
                    loop:true,
                    autoplay:true,
                    speed:1500,
                    breakpoints: {
                        480: {
                            slidesPerView: 1,
                            spaceBetween: 24
                        },
                        767: {
                            slidesPerView: 1,
                            spaceBetween: 24
                        },
                        991: {
                            slidesPerView: 2,
                            spaceBetween: 24
                        },
                        1199: {
                            slidesPerView: 3,
                            spaceBetween: 24
                        },
                    },
                    pagination: {
                        el: '.swiper-pagination',
                        clickable: true
                    },
                    navigation: {
                        nextEl: '.swiper-button-next',
                        prevEl: '.swiper-button-prev',
                    },
                });
            }
        },
        // products slider end
        // testimonial slider start
        testimonial: function () { 
            if($('.cl-testimonial').length > 0){
                var swiper = new Swiper('.cl-testimonial .swiper-container', {
                    slidesPerView: 1,
                    spaceBetween: 24, 
                    loop:true,
                    autoplay:true,
                    speed:1500,
                    navigation: {
                        nextEl: '.swiper-button-next',
                        prevEl: '.swiper-button-prev',
                    },
                });
            }
        },
        // testimonial slider end
        // popup start
        popup: function () {
            if($('.cl-play-icon').length > 0){
                $('.cl-popup-youtube').magnificPopup({
                disableOn: 700,
                type: 'iframe',
                mainClass: 'mfp-fade',
                removalDelay: 160,
                preloader: false,
                fixedContentPos: false
                });
            };
        },
		// popup end
        // mobile menu start
        toggle_menu: function () {
            if($('.cl-header').length > 0){
                var w = window.innerWidth;
                if (w <= 1199) {
                    $(".cl-menu-toggle").on('click',function(e){
                        event.stopPropagation();
                        $("body").toggleClass("cl-open-menu");
                    });
                    $("body").on('click',function(){
                        $("body").removeClass("cl-open-menu");
                    });
                    $(".cl-navbar").on('click',function(){
                        event.stopPropagation();
                    });
                    $(".cl-navbar > ul > li").on('click', function (e) {
                        $(".cl-mega-menu-ul").slideToggle();
                    });
                    $(".cl-navbar>ul li").on('click',function(){
                        $(this).children(".cl-sub-menu,ul.cl-mega-menu").slideToggle();
                    });
                }
            };
        },
		// mobile menu end
        // quantity start
        product_count: function () {
            $('.cl-add-count').on('click',function(){
                if ($(this).prev().val() < 50000) {
                    $(this).prev().val(+$(this).prev().val() + 1);
                }
            });
            $('.cl-sub-count').on('click',function(){
                if ($(this).next().val() > 1) {
                    if ($(this).next().val() > 1) $(this).next().val(+$(this).next().val() - 1);
                }
            });
        },
        // quantity end
    };	
    cycling.init();
})(jQuery);	
new WOW().init();
// Contact Form Submission
function checkRequire(formId , targetResp){
    targetResp.html('');
    var email = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/;
    var url = /(http|ftp|https):\/\/[\w-]+(\.[\w-]+)+([\w.,@?^=%&amp;:\/~+#-]*[\w@?^=%&amp;\/~+#-])?/;
    var image = /\.(jpe?g|gif|png|PNG|JPE?G)$/;
    var mobile = /^[\s()+-]*([0-9][\s()+-]*){6,20}$/;
    var facebook = /^(https?:\/\/)?(www\.)?facebook.com\/[a-zA-Z0-9(\.\?)?]/;
    var twitter = /^(https?:\/\/)?(www\.)?twitter.com\/[a-zA-Z0-9(\.\?)?]/;
    var google_plus = /^(https?:\/\/)?(www\.)?plus.google.com\/[a-zA-Z0-9(\.\?)?]/;
    var check = 0;
    $('#er_msg').remove();
    var target = (typeof formId == 'object')? $(formId):$('#'+formId);
    target.find('input , textarea , select').each(function(){
        if($(this).hasClass('require')){
            if($(this).val().trim() == ''){
                check = 1;
                $(this).focus();
                $(this).parent('div').addClass('form_error');
                targetResp.html('You missed out some fields.');
                $(this).addClass('error');
                return false;
            }else{
                $(this).removeClass('error');
                $(this).parent('div').removeClass('form_error');
            }
        }
        if($(this).val().trim() != ''){
            var valid = $(this).attr('data-valid');
            if(typeof valid != 'undefined'){
                if(!eval(valid).test($(this).val().trim())){
                    $(this).addClass('error');
                    $(this).focus();
                    check = 1;
                    targetResp.html($(this).attr('data-error'));
                    return false;
                }else{
                    $(this).removeClass('error');
                }
            }
        }
    });
    return check;
}
$(".submitForm").on('click', function() {
    var _this = $(this);
    var targetForm = _this.closest('form');
    var errroTarget = targetForm.find('.response');
    var check = checkRequire(targetForm , errroTarget);
    
    if(check == 0){
       var formDetail = new FormData(targetForm[0]);
        formDetail.append('form_type' , _this.attr('form-type'));
        $.ajax({
            method : 'post',
            url : 'ajaxmail.php',
            data:formDetail,
            cache:false,
            contentType: false,
            processData: false
        }).done(function(resp){
            console.log(resp);
            if(resp == 1){
                targetForm.find('input').val('');
                targetForm.find('textarea').val('');
                errroTarget.html('<p style="color:green;">Mail has been sent successfully.</p>');
            }else{
                errroTarget.html('<p style="color:red;">Something went wrong please try again latter.</p>');
            }
        });
    }
});