/*
Template Name: HUD ASP - Responsive Bootstrap 5 Admin Template
Version: 1.8.0
Author: Sean Ngu
Website: http://www.seantheme.com/hud-asp/
*/

var handleInitHighlightJs = function() {
	$('.hljs-container pre code').each(function(i, block) {
		hljs.highlightElement(block);
	});
};


/* Controller
------------------------------------------------ */
$(document).ready(function() {
	handleInitHighlightJs();
});