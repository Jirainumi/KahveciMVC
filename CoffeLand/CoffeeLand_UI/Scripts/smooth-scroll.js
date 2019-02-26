/*jshint jquery:true */
/*global $:true */

var $ = jQuery.noConflict();

$(document).ready(function($) {
	"use strict";

	/*-------------------------------------------------*/
	/* =   Smooth scroll
	/*-------------------------------------------------*/

	$('#container').imagesLoaded(function(){
		//Get Sections top position
		function getTargetTop(elem){
			
			//gets the id of the section header
			//from the navigation's href e.g. ("#html")
			var id = elem.attr("href");

			//Height of the navigation
			var offset = 60;

			//Gets the distance from the top and 
			//subtracts the height of the nav.
			return $(id).offset().top - offset;
		}

		//Smooth scroll when user click link that starts with #

		var elemHref = $('a.go-down[href^="#"]');

		elemHref.click(function(event) {
			
			//gets the distance from the top of the 
			//section refenced in the href.
			var target = getTargetTop($(this));

			//scrolls to that section.
			$('html, body').animate({scrollTop:target}, 500);

			//prevent the browser from jumping down to section.
			event.preventDefault();
		});

		//Pulling sections from main nav.
		var sections = $('a.go-down[href^="#"]');

		// Go through each section to see if it's at the top.
		// if it is add an active class
		function checkSectionSelected(scrolledTo){
			
			//How close the top has to be to the section.
			var threshold = 100;

			var i;

			for (i = 0; i < sections.length; i++) {
				
				//get next nav item
				var section = $(sections[i]);

				//get the distance from top
				var target = getTargetTop(section);
				
				//Check if section is at the top of the page.
				if (scrolledTo > target - threshold && scrolledTo < target + threshold) {

					//remove all selected elements
					sections.removeClass("active");

					//add current selected element.
					section.addClass("active");
				}

			}
		}

		//Check if page is already scrolled to a section.
		checkSectionSelected($(window).scrollTop());

		$(window).scroll(function(){
			checkSectionSelected($(window).scrollTop());
		});

	});

	/*-------------------------------------------------*/
	/* =  Menu - active
	/*-------------------------------------------------*/
	// Whithout Resize
	$(function() {

		// Do our DOM lookups beforehand
		var nav_container = $("header");
		var nav = $(".navbar");
		
		var top_spacing = 0;
		var waypoint_offset = 0;

		nav_container.waypoint({
			handler: function(direction) {
				if (direction == 'down') {
	
					nav.stop().addClass("active").css("top",-nav.outerHeight()).animate({"top":top_spacing});
					//nav_container.stop().addClass("active").css("top",-nav.outerHeight()).animate({"top":top_spacing});
					
				} else {
					
					nav.stop().removeClass("active").css("top",nav.outerHeight()+waypoint_offset).animate({"top":""});
					//nav_container.stop().removeClass("active").css("top",nav.outerHeight()+waypoint_offset).animate({"top":""});
					
				}
				
			},
			offset: function() {
				return -nav.outerHeight()-waypoint_offset;
			}
		});

	});
});

