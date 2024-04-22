// Disables buttons with class 'disable-button-on-click' when clicked
// Requires jQuery
$(document).ready(function () {
    $('.disable-button-on-click').click(function () {
        $(this).prop('disabled', true);
        $(this).addClass('disabled');
    });
});