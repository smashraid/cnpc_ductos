var site = function() {
	this.navLi = $('#nav li').children('ul').hide().end();
	this.init();
};

site.prototype = {
 	
 	init : function() {
 		this.setMenu();
 	},
 	
 	// Enables the slidedown menu, and adds support for IE6
 	
 	setMenu : function() {
 	
 	$.each(this.navLi, function() {
 		if ( $(this).children('ul')[0] ) {
 			$(this)
 				.append('<span />')
 				.children('span')
 					.addClass('hasChildren')
 		}
 	});
 	
 		this.navLi.hover(function() {
 			// mouseover
			$(this).find('> ul').stop(true, true).slideDown('slow', 'easeOutBounce');
 		}, function() {
 			// mouseout
 			$(this).find('> ul').stop(true, true).hide(); 		
		});
 		
 	}
 
}


new site();

// Get the modal
var modal = document.getElementById('myModal');

// Get the button that opens the modal
var btn = document.getElementById("myBtn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks on the button, open the modal 
//btn.onclick = function() {
//    modal.style.display = "block";
//}

// When the user clicks on <span> (x), close the modal
//span.onclick = function() {
//    modal.style.display = "none";
//}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}


