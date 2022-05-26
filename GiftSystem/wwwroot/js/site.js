$(document).ready(function () {
    $('#myTable').DataTable({
        "scrollY": "470px",
        "scrollCollapse": true,
        "paging": true
    });

    $('#myTable').removeClass('d-none');
    $('#sendGiftButton').removeClass('d-none'); 
});