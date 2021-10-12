var data = {};
var Socio = function ($) {

    function bindEvent() {
        initTableSocio();

        $("#btnAddSocio").click(function () {
            localStorage.removeItem("IdSocio");
            window.location.href = '/Socio/SocioDetails';
        });

        $('#tableSocio').on('click', 'a.link-socio', function () {
            var IdSocio = $(this).data("idsocio");
            localStorage.setItem("IdSocio", IdSocio);
            window.location.href = '/Socio/SocioDetails';
        });

        loadData();
    }

    function initTableSocio() {
        Tools.datatables();
        tableSocios = $("#tableSocio").DataTable({
            "dom": "<'col-md-12'<'pull-left'l><'pull-right'B>>tpi",
            "aaData": data.socios,
            "scrollCollapse": true,
            "paging": true,
            "pageLength": 10,
            "columnDefs": [
                {
                    data: function (row, type, set, meta) {
                        return row.NombreCompleto;
                    },
                    targets: 0,
                    "orderable": true,
                },
                {
                    data: function (row, type, set, meta) {
                        return row.Cedula;
                    },
                    targets: 1
                },
                {
                    data: function (row, type, set, meta) {
                        return row.Activo == 1? "Activo" : "Inactivo";
                    },
                    targets: 2
                },
                {
                    data: function (row, type, set, meta) {
                        var editLink = '<a href="javascript:void(0)" data-idSocio="' + row.IdSocio + '" class="link-socio btn btn-secondary" style="width: 40px;"><i class="fa fa-pen"></i></a>';

                        var actions = ''
                            + '<div class="text-center" >'
                            + '     ' + (editLink)
                            + '</div>';
                        return actions;
                    },
                    targets: 3,
                    "orderable": false,
                },
            ],
        });
    }

    function loadData() {
        $.ajax({
            method: 'POST',
            url: "/Socio/GetSocios",
            dataType: "json",
            cache: false
        }).done(function (responseDB) {
            data.socios = responseDB.response.DataModel;
            tableSocios.clear();
            tableSocios.rows.add(data.socios);
            tableSocios.draw();
        });
    }

    function removeSocio(id) {
        $.ajax({
            method: 'POST',
            url: "/Socio/DeleteSocio",
            cache: false,
            data: { socioId: id },
            dataType: "json"
        }).done(function (response) {
            toastr.success("Success", "");
            loadData();
        }).error(function (error) {
            toastr.error(response.message, "Error");
        });
    }

    return {
        init: function () {
            bindEvent();
        },
        removeSocio: function (id) {
            removeSocio(id);
        },
    };
}(jQuery);