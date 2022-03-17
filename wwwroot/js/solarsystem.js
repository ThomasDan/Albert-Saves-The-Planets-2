// Messed with the e, ee, and eee below
// (They were all named "e" before..so not sure if this break stuff : DDDD )
//  - Thomas 
$(document).ready(function (e) {
    $('img[usemap]').rwdImageMaps();

    $('area').on('focus', function (ee) {
        ee.preventDefault();
        $('.selection p').html($(this).attr('class'));
    });

    $(document).on('click', function (eee) {
        eee.preventDefault();
        if ($(eee.target).closest('area').length === 0) {
            $('.selection p').html('click a brick');
        }
    });
});