$(document).ready(function() {
    $("ul#menu li").hover(
        function() { // mouse in
            $(this).find("ul.submenu").slideDown('fast');
        },
        function() { // mouse out
            $(this).find("ul.submenu").slideUp('slow');
        }
    )
});