
$(document).ready(function() {
    $.fn.datepicker.defaults.format = "yyyy-mm-dd";
    $('.datepicker').datepicker({
        startDate: '-3000d'
    });
    $('#body_viewSearchItemGridView').DataTable();

    $(".only-number").keypress(function (e) {
        console.log(e.which);
        //if the letter is not digit then display error and don't type anything
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57 )) {
            return false;
        }
    });
});




