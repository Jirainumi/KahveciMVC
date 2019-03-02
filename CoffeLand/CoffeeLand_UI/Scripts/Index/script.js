/*jshint jquery:true */

$(document).ready(function($) {
	"use strict";

	/* global google: false */

	/*-------------------------------------------------*/
	/* =  portfolio isotope
	/*-------------------------------------------------*/

	var winDow = $(window);
		// Needed variables
		var $container=$('.iso-call');
		var $filter=$('.filter');

		try{
			$container.imagesLoaded( function(){
				$container.trigger('resize');
				$container.isotope({
					filter:'*',
					layoutMode:'masonry',
					animationOptions:{
						duration:750,
						easing:'linear'
					}
				});

				$('.triggerAnimation').waypoint(function() {
					var animation = $(this).attr('data-animate');
					$(this).css('opacity', '');
					$(this).addClass("animated " + animation);

				},
					{
						offset: '75%',
						triggerOnce: true
					}
				);
			});
		} catch(err) {
		}

		winDow.on('resize', function(){
			var selector = $filter.find('a.active').attr('data-filter');

			try {
				$container.isotope({
					filter	: selector,
					animationOptions: {
						duration: 750,
						easing	: 'linear',
						queue	: false,
					}
				});
			} catch(err) {
			}
			return false;
		});

		// Isotope Filter
		$filter.find('a').on('click', function(){
			var selector = $(this).attr('data-filter');

			try {
				$container.isotope({
					filter	: selector,
					animationOptions: {
						duration: 750,
						easing	: 'linear',
						queue	: false,
					}
				});
			} catch(err) {

			}
			return false;
		});


	var filterItemA	= $('.filter li a');

		filterItemA.on('click', function(){
			var $this = $(this);
			if ( !$this.hasClass('active')) {
				filterItemA.removeClass('active');
				$this.addClass('active');
			}
		});

	/*-------------------------------------------------*/
	/* =  OWL carousell
	/*-------------------------------------------------*/
	try {
		var owlWrap = $('.owl-wrapper');

		if (owlWrap.length > 0) {

			if (jQuery().owlCarousel) {
				owlWrap.each(function(){

					var carousel= $(this).find('.owl-carousel'),
						dataNum = $(this).find('.owl-carousel').attr('data-num'),
						dataNum2,
						dataNum3;

					if ( dataNum == 1 ) {
						dataNum2 = 1;
						dataNum3 = 1;
					} else if ( dataNum == 2 ) {
						dataNum2 = 2;
						dataNum3 = dataNum - 1;
					} else {
						dataNum2 = dataNum - 1;
						dataNum3 = dataNum - 2;
					}

					carousel.owlCarousel({
						autoPlay: 10000,
						navigation : true,
						itemsScaleUp: true,
						items : dataNum,
						itemsDesktop : [1199,dataNum2],
						itemsDesktopSmall : [979,dataNum3]
					});

				});
			}
		}

	} catch(err) {

	}

	/*-------------------------------------------------*/
	/* =  browser detect
	/*-------------------------------------------------

	var ToogleMenu = $('a.open-menu');

	ToogleMenu.on('click', function(event) {
		event.preventDefault();

		var MainMenu = $('.navbar-nav'),
			$this = $(this);
		if ( !$this.hasClass('opened') ) {
			$this.addClass('opened');
			MainMenu.addClass('active');
		} else {
			$this.removeClass('opened');
			MainMenu.removeClass('active');
		}
	}); */

	/*-------------------------------------------------*/
	/* =  Search animation
	/*-------------------------------------------------*/

	var searchToggle = $('.open-search a, a.open-menu'),
		inputAnime = $("#right-sidebar"),
		closeSidebtn = $("a.close-sidebar");

	searchToggle.on('click', function(event){
		event.preventDefault();
		inputAnime.addClass('active');
	});

	closeSidebtn.on('click', function(event){
		event.preventDefault();
		inputAnime.removeClass('active');
	});

	/*-------------------------------------------------*/
	/* =  flexslider
	/*-------------------------------------------------*/
	try {

		var SliderPost = $('.flexslider');

		SliderPost.flexslider({
			slideshowSpeed: 3000,
			easing: "swing"
		});
	} catch(err) {

	}

	/* ---------------------------------------------------------------------- */
	/*	magnific-popup
	/* ---------------------------------------------------------------------- */

	try {
		// Example with multiple objects
		$('.zoom').magnificPopup({
			type: 'image',
			gallery: {
				enabled: true
			}
		});

	} catch(err) {

	}

	/*-------------------------------------------------*/
	/* =   magnific popup product popup
	/*-------------------------------------------------*/

	try {
		var productpopup = $('.shoping-cart');
		productpopup.magnificPopup({
			closeBtnInside:true,
			gallery: {
				enabled: false
			}
		});
	} catch(err) {

	}

	/* ---------------------------------------------------------------------- */
	/*	Sticky sidebar
	/* ---------------------------------------------------------------------- */

	try {

		$('.sticky-content').theiaStickySidebar({
			additionalMarginTop: 30
		});

	} catch(err) {

	}

	/* ---------------------------------------------------------------------- */
	/*	Bootstrap tabs
	/* ---------------------------------------------------------------------- */

	var tabId = $('.nav-tabs a');
	try{
		tabId.on('click', function (e) {
			e.preventDefault();
			$(this).tab('show');
		});
	} catch(err) {
	}

	/*-------------------------------------------------*/
	/* = slider Testimonial
	/*-------------------------------------------------*/

	var slidertestimonial = $('.bxslider');
	try{
		slidertestimonial.bxSlider({
			mode: 'fade',
			auto: 'true'
		});

		$('.gallery-bxslider').bxSlider({
			mode: 'horizontal',
			auto: true,
			pagerCustom: '#bx-pager'
		});

	} catch(err) {
	}

	/*-------------------------------------------------*/
	/* = horizontal scrollbar
	/*-------------------------------------------------*/

	try{
		$(".scroller-posts-line").mousewheel(function(event, delta) {

			this.scrollLeft -= (delta * 30);

			event.preventDefault();

		});

	} catch(err) {
	}

	/*-------------------------------------------------*/
	/* =  price range code
	/*-------------------------------------------------*/

	try {

		for( var j = 100; j <= 10000; j++ ){
			$('#start-val').append(
				'<option value="' + j + '">' + j + '</option>'
			);
		}
		// Initialise noUiSlider
		$('.noUiSlider').noUiSlider({
			range: [0,400],
			start: [25,225],
			handles: 2,
			connect: true,
			step: 1,
			serialization: {
				to: [ $('#start-val'),
					$('#end-val') ],
				resolution: 1
			}
		});
	} catch(err) {

	}

	/*-------------------------------------------------*/
	/* = skills animate
	/*-------------------------------------------------*/

	try{

		var skillBar = $('.skills-box');
		skillBar.appear(function() {

			var animateElement = $(".meter > p");
			animateElement.each(function() {
				$(this)
					.data("origWidth", $(this).width())
					.width(0)
					.animate({
						width: $(this).data("origWidth")
					}, 1200);
			});

		});
	} catch(err) {
	}

	/*-------------------------------------------------*/
	/* =  count increment
	/*-------------------------------------------------*/
	try {
		$('.statistic-box').appear(function() {
			$('.timer').countTo({
				speed: 4000,
				refreshInterval: 60,
				formatter: function (value, options) {
					return value.toFixed(options.decimals);
				}
			});
		});
	} catch(err) {

	}

	/* ---------------------------------------------------------------------- */
	/*	Shop galery image replacement
	/* ---------------------------------------------------------------------- */

	var elemToShow = $('.other-products a');

	elemToShow.on('click', function(e){
		e.preventDefault();
		elemToShow.removeClass('active');
		$(this).addClass('active');
		var newImg = $(this).attr('data-image');
		var prodHolder = $('.image-holder img');
		prodHolder.attr('src', newImg);
	});

	/*-------------------------------------------------*/
	/* =  product increase
	/*-------------------------------------------------*/

	var fieldNum = $('input[type="text"]'),
		btnIncrease = $('button.increase'),
		btnDecrease = $('button.decrease');

		btnIncrease.on('click', function(event){
			event.preventDefault();
			var fieldVal = $(this).parent('div.quantity-add').find(fieldNum).val();
			var nextVal = parseFloat(fieldVal) + 1;
			$(this).parent('div.quantity-add').find(fieldNum).val(nextVal);
		});

		btnDecrease.on('click', function(event){
			event.preventDefault();
			var fieldVal = $(this).parent('div.quantity-add').find(fieldNum).val();
			var nextVal = parseFloat(fieldVal) - 1;
			if (fieldVal > 0) {
				$(this).parent('div.quantity-add').find(fieldNum).val(nextVal);
			} else {
				$(this).parent('div.quantity-add').find(fieldNum).val(0);
			}
		});

	/* ---------------------------------------------------------------------- */
	/*	Load more posts from container
	/* ---------------------------------------------------------------------- */

	var LoadButton = $('a.load-post-container'),
		PortContainer = ('.iso-call'),
		i = 0,
		s = 0;

	LoadButton.live( 'click', function(event) {
		event.preventDefault();

		var LoadContainer = $(this).attr('data-load'),
			xel = parseInt($(this).attr('data-number'));

		var storage = document.createElement('div');
		$(storage).load("load-container/" + LoadContainer + " .project-post, .blog-post", function(){

			var elemloadedLength = $(storage).find('.project-post, .blog-post').length;

			if ( ((s + 1) <= elemloadedLength) ) {

				s = i + xel;

				var t = i - 1;
				var $elems;

				if ( i === 0 ) {
					/// create new item elements
					$elems = $(storage).find(".project-post:lt(" + s + "), .blog-post:lt(" + s + ")").appendTo(PortContainer);
					// append elements to container
					$container.isotope( 'appended', $elems );

					if ( LoadContainer == "blog-container3.html") {
						$(storage).find(".blog-post:lt(" + s + ")").appendTo('.blog-box.timeline');
					}

				} else {
					/// create new item elements
					$elems = $(storage).find(".project-post:lt(" + s + "):gt("+ t +"), .blog-post:lt(" + s + "):gt("+ t +")").appendTo(PortContainer);
					// append elements to container
					$container.isotope( 'appended', $elems );

					if ( LoadContainer == "blog-container3.html") {
						$(storage).find(".blog-post:lt(" + s + "):gt("+ t +")").appendTo('.blog-box.timeline');
					}
				}

				i = i + xel;
			}

			if ( ( s >= elemloadedLength ) ) {
				$('a.load-post-container').text("No more posts");
			}

		});

	});


	/* ---------------------------------------------------------------------- */
	/*	Contact Map
	/* ---------------------------------------------------------------------- */


	try {
		mapcallFunction();
	} catch(err) {

	}

	/* ---------------------------------------------------------------------- */
	/*	work horizontal scroll bar
	/* ---------------------------------------------------------------------- */

	var outerScroller = $('.inner-scroller'),
		itemscroll = outerScroller.find('.item'),
		snditemscroll = outerScroller.find('.item.snd-width'),
		itemLength = itemscroll.length,
		itemLength2 = snditemscroll.length,
		itemLength1 = itemLength - itemLength2;
		var itemwidth = itemscroll.outerWidth(),
		itemwidth2 = snditemscroll.outerWidth(),
		outerScrollerWidth = itemwidth * itemLength1 + itemwidth2 * itemLength2;
		outerScroller.css('width', outerScrollerWidth);

	var sliderHeight = $(window).outerHeight() - $('.navbar-default').outerHeight() - $('footer').outerHeight(),
		sliderWidth = $(window).outerWidth()/2,
		MapItem = $('.fullscreenbanner #map');

		MapItem.css({'height': sliderHeight, 'width': sliderWidth });


	$(window).on('resize', function(){
		var itemwidth = itemscroll.outerWidth(),
		outerScrollerWidth = itemwidth * itemLength;
		outerScroller.css('width', outerScrollerWidth);

		var sliderHeight = $(window).outerHeight() - $('.navbar-default').outerHeight() - $('footer').outerHeight(),
		sliderWidth = $(window).outerWidth()/2,
		MapItem = $('.fullscreenbanner #map');

		MapItem.css({'height': sliderHeight, 'width': sliderWidth });
		try {
			mapcallFunction();
		} catch(err) {

		}
	});

	/* ---------------------------------------------------------------------- */
	/*	Accordion
	/* ---------------------------------------------------------------------- */
	var clickElem = $('a.accord-link');

	clickElem.on('click', function(e){
		e.preventDefault();

		var $this = $(this),
			parentCheck = $this.parents('.accord-elem'),
			accordItems = $('.accord-elem'),
			accordContent = $('.accord-content');

		if( !parentCheck.hasClass('active')) {

			accordContent.slideUp(400, function(){
				accordItems.removeClass('active');
			});
			parentCheck.find('.accord-content').slideDown(400, function(){
				parentCheck.addClass('active');
			});

		} else {

			accordContent.slideUp(400, function(){
				accordItems.removeClass('active');
			});

		}
	});

	/* ---------------------------------------------------------------------- */
	/*	Contact Form
	/* ---------------------------------------------------------------------- */

	var submitContact = $('#submit_contact'),
		message = $('#msg');

	submitContact.on('click', function(e){
		e.preventDefault();

		var $this = $(this);

		$.ajax({
			type: "POST",
			url: 'contact.php',
			dataType: 'json',
			cache: false,
			data: $('#contact-form').serialize(),
			success: function(data) {

				if(data.info !== 'error'){
					$this.parents('form').find('input[type=text],textarea,select').filter(':visible').val('');
					message.hide().removeClass('success').removeClass('error').addClass('success').html(data.msg).fadeIn('slow').delay(5000).fadeOut('slow');
				} else {
					message.hide().removeClass('success').removeClass('error').addClass('error').html(data.msg).fadeIn('slow').delay(5000).fadeOut('slow');
				}
			}
		});
	});


	/* ---------------------------------------------------------------------- */
	/*	menu responsive
	/* ---------------------------------------------------------------------- */
	var menuClick = $('a.elemadded'),
		navbarVertical = $('.menu');

	menuClick.on('click', function(e){
		e.preventDefault();

		if( navbarVertical.hasClass('active') ){
			navbarVertical.slideUp(300).removeClass('active');
		} else {
			navbarVertical.slideDown(300).addClass('active');
		}
	});

	winDow.on('resize', function(){
		if ( winDow.width() > 991 ) {
			navbarVertical.slideDown(300).removeClass('active');
		} else {
			navbarVertical.slideUp(300).removeClass('active');
		}
	});

	/*-------------------------------------------------*/
	/* =  comming soon & error height fix
	/*-------------------------------------------------*/

	var deficHeight = $('.navbar-default').outerHeight() + $('footer').outerHeight();
	$('.error-section, .comming-soon-section').css('min-height', $(window).height() - deficHeight);

	try {

		$('#clock').countdown("2018/01/29", function(event) {
			var $this = $(this);
			switch(event.type) {
				case "seconds":
				case "minutes":
				case "hours":
				case "days":
				case "daysLeft":
					$this.find('span#'+event.type).html(event.value);
					break;
				case "finished":
					$this.hide();
					break;
			}
		});

	} catch(err) {

	}

	/* ---------------------------------------------------------------------- */
	/*	Header animate after scroll
	/* ---------------------------------------------------------------------- */

	(function() {

		var docElem = document.documentElement,
			didScroll = false,
			changeHeaderOn = 250;
			document.querySelector( 'header' );
		function init() {
			window.addEventListener( 'scroll', function() {
				if( !didScroll ) {
					didScroll = true;
					setTimeout( scrollPage, 100 );
				}
			}, false );
		}

		function scrollPage() {
			var sy = scrollY();
			if ( sy >= changeHeaderOn ) {
				$( 'header' ).addClass('active');
			}
			else {
				$( 'header' ).removeClass('active');
			}
			didScroll = false;
		}

		function scrollY() {
			return window.pageYOffset || docElem.scrollTop;
		}

		init();

	})();

});

function mapcallFunction() {
	var contact = {"lat":"-33.880641", "lon":"151.204298"}; //Change a map coordinate here!

	var mapContainer = $('#map');
	mapContainer.gmap3({
		action: 'addMarker',
		marker:{
			options:{
				icon : new google.maps.MarkerImage('images/marker.png')
			}
		},
		latLng: [contact.lat, contact.lon],
		map:{
			center: [contact.lat, contact.lon],
			zoom: 16
			},
		},
		{action: 'setOptions', args:[{scrollwheel:false}]}
	);
}
