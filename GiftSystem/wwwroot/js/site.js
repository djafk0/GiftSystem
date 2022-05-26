$(document).ready(function () {
    $('#myTable').removeClass('d-none');
    $('#sendGiftButton').removeClass('d-none'); 

    $('#myTable').DataTable({
        "scrollY": "450px",
        "scrollCollapse": true,
        "paging": true
    });
});