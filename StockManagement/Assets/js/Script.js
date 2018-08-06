
$(document).ready(function() {
    $.fn.datepicker.defaults.format = "yyyy-mm-dd";
    $('.datepicker').datepicker({
        startDate: '-3000d'
    });
});


