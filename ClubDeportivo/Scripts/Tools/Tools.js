
var Tools = Tools || {

    datatables: function () {
        $.extend(true, $.fn.dataTable.defaults, {
            processing: "Processing...",
            lengthChange: false,
            language: {
                zeroRecords: "No results found",
                emptyTable: "No data available",
                info: "Total records: _TOTAL_",
                infoEmpty: "",
                infoFiltered: "",
                infoPostFix: "",
                url: "",
                thousands: ", ",
                loadingRecords: "Loading...",
                search: "Search: ",
                paginate: {
                    first: "First",
                    last: "Last",
                    next: "Next",
                    previous: "Previous"
                },
                aria: {
                    sortAscending: ": Activar para ordenar la columna de manera ascendente",
                    sortDescending: ": Activar para ordenar la columna de manera descendente"
                }
            }
        }
        ); 
    },
};