jQuery(document).ready(function($) {
	"use strict";

	//init slider
	if ($("#rev_slider").length > 0) {
		RevolutionInit();
	}
	if ($("#rev_slider_left_menu").length > 0) {
		PageLeftMenuRevolutionInit();
	}

	//banner isotope
	if ($('.noo-banner-wrap').length > 0) {
		noo_banner_masonry();
	}

	//owl carousel
	OwlCarousel();

	//button search click
	$('.noo-search').on('click', function() {
		$('.search-header').fadeIn(1).addClass('search-header-eff');
		$('.search-header').find('input[type="search"]').val('').attr('placeholder', '').select();
		return false;
	});
	$('.remove-form').on('click', function() {
		$('.search-header').fadeOut(1).removeClass('search-header-eff');
	});

	//ajax popup
	if ($(".noo-quick-view").length > 0) {
		$('.noo-quick-view a').magnificPopup({
			type: 'ajax',
			// Delay in milliseconds before popup is removed
			removalDelay: 300,

			// Class that is added to popup wrapper and background
			// make it unique to apply your CSS animations just to this exact popup
			mainClass: 'mfp-fade'
		});
	}

	//Countdown Timer
	if ($(".clock-inner").length > 0) {
		$(".clock-inner").each(function() {
			var time = $(this).attr("data-time");
			$(this).countdown(time, function(event) {
				var $this = $(this).html(event.strftime('' + '<div class="countdown-section"><div class="countdown-amount">%D</div><div class="countdown-period">Days</div></div>' + '<div class="countdown-section"><div class="countdown-amount">%H</div><div class="countdown-period">Hours</div></div>' + '<div class="countdown-section"><div class="countdown-amount">%M</div><div class="countdown-period">Minutes</div></div>' + '<div class="countdown-section"><div class="countdown-amount">%S</div><div class="countdown-period">Seconds</div></div>'));
			});
		});
	}

	//blog background image
	$('.noo-blog .noo-blog-item').each(function() {
		var post_thumb = $(this).find(".noo-blog-thumbnail");
		post_thumb.css('background-image', 'url("Content/' + post_thumb.attr("data-image") + '")');
	});

	//simple product banner background
	$('.noo-simple-product').each(function() {
		var banner_thumb = $(this).find(".simple-banner-left");
		banner_thumb.css('background-image', 'url("Content/' + banner_thumb.attr("data-image") + '")');
	});

	//header 2 set default height
	if ($(".header-2").length > 0) {
		var h = $(".header-2").outerHeight();
		$("#main").css('margin-top', h);
	}
	if ($(".header-3").length > 0) {
		var h = $(".header-3").outerHeight();
		$("#main").css('margin-top', h);
	}

	$(window).scroll(function() {
		if ($(this).scrollTop() > 100) {
			$(".header-transparent").addClass("on");
		} else {
			$(".header-transparent,.header-3").removeClass("on");
		}
		if ($(this).scrollTop() > 300) {
			$(".header-2,.header-3").addClass("on");
		} else {
			$(".header-2").removeClass("on");
		}
		if ($(this).scrollTop() > 500) {
			$(".go-to-top").addClass("on");
			$(".header-transparent,.header-2,.header-3").addClass("on-fixed");
		} else {
			$(".go-to-top").removeClass("on");
			$(".header-transparent,.header-2,.header-3").removeClass("on-fixed");
		}
	});

	$('body').on('click', '.go-to-top', function() {
		$("html, body").animate({
			scrollTop: 0
		}, 800);
		return false;
	});

	//Toggle Accordion
	var iconOpen = 'fa fa-minus',
		iconClose = 'fa fa-plus';

	$(document).on('show.bs.collapse hide.bs.collapse', '.accordion', function(e) {
		var $target = $(e.target)
		$target.siblings('.accordion-heading')
			.find('.toggle-icon').toggleClass(iconOpen + ' ' + iconClose);
		if (e.type == 'show')
			$target.prev('.accordion-heading').find('.accordion-toggle').addClass('active');
		if (e.type == 'hide')
			$(this).find('.accordion-toggle').not($target).removeClass('active');
	});

	//disable Google Map on scroll
	$('.maps').on('click', function() {
		$('.maps iframe').css("pointer-events", "auto");
	});
	$('.maps').on('mouseleave', function() {
		$('.maps iframe').css("pointer-events", "none");
	});

	//toggle filter
	$('.shop-meta-icon').on('click', function() {
		if ($('.shop-filter').hasClass('eff')) {
			$('.shop-filter').removeClass('eff');
		} else {
			$('.shop-filter').addClass('eff');
		}
	});

	$(window).load(function() {
		$(".noo-spinner").fadeOut('slow').remove();
	});
});

function noo_banner_masonry() {
	$('.noo-banner-wrap').each(function() {
		var $this = $(this);
		$this.imagesLoaded(function() {
			$this.isotope({
				itemSelector: '.banner-item',
				transitionDuration: '0.8s',
				masonry: {
					'gutter': 0
				}
			});
		});
	})
}

function OwlCarousel() {
	if ($(".noo-product-slider").length > 0) {
		$(".noo-product-slider").each(function() {
			$(this).owlCarousel({
				navigation: false,
				slideSpeed: 600,
				pagination: true,
				paginationSpeed: 400,
				autoHeight: true,
				addClassActive: true,
				autoPlay: false,
				singleItem: true
			});
		});
	}
	if ($(".noo-on-sale").length > 0) {
		$(".noo-on-sale").each(function() {
			$(this).owlCarousel({
				items: 4,
				itemsDesktop: [1199, 4],
				itemsDesktopSmall: [979, 3],
				itemsTablet: [768, 3],
				itemsMobile: [479, 2],
				slideSpeed: 500,
				paginationSpeed: 1000,
				rewindSpeed: 1000,
				autoHeight: false,
				ClassActive: true,
				autoPlay: true,
				loop: true,
				pagination: false
			});
		});
	}
	if ($(".noo-partner").length > 0) {
		var items = $(this).attr('data-item');
		$('.noo-partner').each(function() {
			$(this).owlCarousel({
				items: items,
				itemsDesktop: [1199, 4],
				itemsDesktopSmall: [979, 3],
				itemsTablet: [767, 2],
				itemsMobile: [479, 1],
				slideSpeed: 500,
				paginationSpeed: 1000,
				rewindSpeed: 1000,
				autoHeight: false,
				addClassActive: true,
				autoPlay: true,
				loop: true,
				pagination: false
			});
		});
	}
	if ($(".noo-simple-product-slider").length > 0) {
		$('.noo-simple-product-slider').each(function() {
			$(this).owlCarousel({
				items: 5,
				itemsDesktop: [1199, 4],
				itemsDesktopSmall: [979, 3],
				itemsTablet: [768, 2],
				slideSpeed: 500,
				paginationSpeed: 800,
				rewindSpeed: 1000,
				autoHeight: true,
				addClassActive: true,
				autoPlay: false,
				loop: true,
				pagination: false
			});
		});
	}
	if ($(".noo-testimonial").length > 0) {
		$('.noo-testimonial').each(function() {
			$(this).owlCarousel({
				autoPlay: true,
				navigation: true,
				slideSpeed: 400,
				pagination: false,
				paginationSpeed: 400,
				addClassActive: true,
				singleItem: true
			});
		});
	}
	if ($(".noo-testimonial-2").length > 0) {
		$('.noo-testimonial-2').each(function() {
			var sync1 = $(".noo-sync1");
			var sync2 = $(".noo-sync2");

			sync1.owlCarousel({
				singleItem: true,
				slideSpeed: 400,
				navigation: false,
				pagination: false,
				autoHeight: true,
				afterAction: syncPosition,
				responsiveRefreshRate: 200
			});

			sync2.owlCarousel({
				items: 3,
				itemsDesktop: [1199, 3],
				itemsDesktopSmall: [979, 3],
				itemsTablet: [768, 3],
				itemsMobile: [479, 1],
				pagination: false,
				responsiveRefreshRate: 100,
				afterInit: function(el) {
					el.find(".owl-item").eq(0).addClass("synced");
				}
			});

			function syncPosition(el) {
				var current = this.currentItem;
				$(".noo-sync2")
					.find(".owl-item")
					.removeClass("synced")
					.eq(current)
					.addClass("synced")
				if ($(".noo-sync2").data("owlCarousel") !== undefined) {
					center(current)
				}

			}

			$(".noo-sync2").on("click", ".owl-item", function(e) {
				e.preventDefault();
				var number = $(this).data("owlItem");

				sync1.trigger("owl.goTo", number);
			});

			function center(number) {
				var sync2visible = sync2.data("owlCarousel").owl.visibleItems;

				var num = number;
				var found = false;
				for (var i in sync2visible) {
					if (num === sync2visible[i]) {
						var found = true;
					}
				}

				if (found === false) {
					if (num > sync2visible[sync2visible.length - 1]) {
						sync2.trigger("owl.goTo", num - sync2visible.length + 2)
					} else {
						if (num - 1 === -1) {
							num = 0;
						}
						sync2.trigger("owl.goTo", num);
					}
				} else if (num === sync2visible[sync2visible.length - 1]) {
					sync2.trigger("owl.goTo", sync2visible[1])
				} else if (num === sync2visible[0]) {
					sync2.trigger("owl.goTo", num - 1)
				}
			}
		});
	}
	if ($('#product-detail-slider').length > 0) {
		$("#product-detail-slider").owlCarousel({
			items: 1,
			navigation: true,
			slideSpeed: 600,
			pagination: false,
			paginationSpeed: 400,
			addClassActive: true,
			singleItem: true

		});
		$('.item-img:first-child').addClass('t-active');

		$(".images").on("click", ".item-img", function(e) {
			e.preventDefault();
			$('.item-img').removeClass('t-active');
			$(this).addClass('t-active');
			var number = $('.item-img').index(this);
			$('#product-detail-slider').trigger("owl.goTo", number);
		});

		$('.owl-next').on("click", function() {
			$('.item-img').removeClass('t-active');
			var $index = $(".owl-item").index($(".active"));
			$('.item-img').eq($index).addClass('t-active');
		});

		$('.owl-prev').on("click", function() {
			$('.item-img').removeClass('t-active');
			var $index = $(".owl-item").index($(".active"));
			$('.item-img').eq($index).addClass('t-active');
		});
	}
}

function RevolutionInit() {
	$("#rev_slider").show().revolution({
		sliderType: "standard",
		sliderLayout: "fullwidth",
		dottedOverlay: "none",
		delay: 9000,
		navigation: {
			keyboardNavigation: "off",
			keyboard_direction: "horizontal",
			mouseScrollNavigation: "off",
			mouseScrollReverse: "default",
			onHoverStop: "off",
			arrows: {
				style: "zeus",
				enable: true,
				hide_onmobile: false,
				hide_onleave: false,
				tmp: '<div class="tp-title-wrap">  	<div class="tp-arr-imgholder"></div> </div>',
				left: {
					h_align: "left",
					v_align: "center",
					h_offset: 20,
					v_offset: 0
				},
				right: {
					h_align: "right",
					v_align: "center",
					h_offset: 20,
					v_offset: 0
				}
			}
		},
		visibilityLevels: [1240, 1024, 778, 480],
		gridwidth: 1380,
		gridheight: 868,
		lazyType: "none",
		shadow: 0,
		spinner: "spinner0",
		stopLoop: "off",
		stopAfterLoops: -1,
		stopAtSlide: -1,
		shuffle: "off",
		autoHeight: "off",
		disableProgressBar: "on",
		hideThumbsOnMobile: "off",
		hideSliderAtLimit: 0,
		hideCaptionAtLimit: 0,
		hideAllCaptionAtLilmit: 0,
		debugMode: false,
		fallbacks: {
			simplifyAll: "off",
			nextSlideOnWindowFocus: "off",
			disableFocusListener: false,
		}
	});
}

function PageLeftMenuRevolutionInit() {
	$("#rev_slider_left_menu").show().revolution({
		sliderType: "standard",
		sliderLayout: "auto",
		dottedOverlay: "none",
		delay: 9000,
		navigation: {
			onHoverStop: "off",
		},
		visibilityLevels: [1240, 1024, 778, 480],
		gridwidth: 1240,
		gridheight: 868,
		lazyType: "none",
		parallax: {
			type: "mouse",
			origo: "enterpoint",
			speed: 400,
			levels: [5, 10, 15, 20, 25, 30, 35, 40, 45, 46, 47, 48, 49, 50, 51, 55],
			type: "mouse",
		},
		shadow: 0,
		spinner: "spinner0",
		stopLoop: "off",
		stopAfterLoops: -1,
		stopAtSlide: -1,
		shuffle: "off",
		autoHeight: "off",
		disableProgressBar: "on",
		hideThumbsOnMobile: "off",
		hideSliderAtLimit: 0,
		hideCaptionAtLimit: 0,
		hideAllCaptionAtLilmit: 0,
		debugMode: false,
		fallbacks: {
			simplifyAll: "off",
			nextSlideOnWindowFocus: "off",
			disableFocusListener: false,
		}
	});
}
