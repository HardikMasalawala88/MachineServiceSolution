// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var minDate, maxDate;
$(document).ready(function () {
    minDate = new DateTime($('#min'), {
        format: 'MMMM Do YYYY'
    });
    maxDate = new DateTime($('#max'), {
        format: 'MMMM Do YYYY'
    });

    datatable = $('.makeDatatable').dataTable();

    // Refilter the table
    $('#min, #max').on('change', function () {
        //datatable.draw();
        datatable.fnDraw()
    });
});
// Custom filtering function which will search data in column 2 between two values
$.fn.dataTable.ext.search.push(
    function (settings, data, dataIndex) {
            var min = minDate === undefined ? null: minDate.val();
            var max = maxDate === undefined ? null : maxDate.val();
            var date = new Date(data[1]);
            if (
                (min === null && max === null) ||
                (min === null && date <= max) ||
                (min <= date && max === null) ||
                (min <= date && date <= max)
            ) {
                return true;
            }
        
        return false;
    }
);