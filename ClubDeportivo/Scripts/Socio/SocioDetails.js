var SocioDetails = function ($) {
    var data = {};
    var idSocio = "";
    var socioData = undefined;

    function bindEvent() {

        $("#goBack").on("click", function () {
            window.location.href = '/Socio/Socios';
        });

        $('#divBirthDate').datepicker({
            format: 'dd/mm/yyyy',
            language: 'es'
        });

        loadData()

        $("#btnSaveSocio").on("click", function () {
            saveUpdateSocio();
        });

    }

    function loadData() {
        $.ajax({
            method: 'GET',
            url: "/Socio/GetSocio" + "?idSocio=" + idSocio,
            dataType: "json",
            cache: false
        }).done(function (responseDB) {
            data.socio = responseDB.response.DataModel;
            if (data.socio.IdSocio != null) {
                initData(data);
            }
        });
    }

    function initData(data) {
        $("#txtNombreCompleto").val(data.socio.NombreCompleto);
        $("#txtCedula").val(data.socio.Cedula);
        $("#txtCedula").prop("disabled", true);
        if (data.socio.FechaNacimiento !== null && data.socio.FechaNacimiento != "0001-01-01T00:00:00") {
            var datebirth = moment(data.socio.FechaNacimiento).format("DD/MM/YYYY");
            $('#divBirthDate').datepicker("setDate", datebirth);
        }
        $("#ckbActivo").prop('checked', data.socio.Activo);//val(data.socio.Activo);
    }

    function disableForm() {
        $("#txtNombreCompleto").prop("disabled", true);
        $("#txtCedula").prop("disabled", true);
        $("#inputBirth").prop("disabled", true);
        $("#ckbActivo").prop("disabled", true);
        $("#goBack").prop("disabled", true);
        $("#btnSaveSocio").prop("disabled", true);
    }

    function dataForm() {
        socioData = {
            IdSocio: idSocio,
            NombreCompleto: $("#txtNombreCompleto").val(),
            Cedula: $("#txtCedula").val(),
            FechaNacimiento: $("#inputBirth").val(),
            Activo: $('#ckbActivo').is(":checked")
        };
    }

    function saveUpdateSocio() {
        dataForm()
        $.ajax({
            method: 'POST',
            url: '/Socio/CreateOrUpdateSocio',
            cache: false,
            data: socioData,
            dataType: "json",
            success: function (responseDB) {
                if (responseDB.response.Code == 700) {
                    toastr.warning(responseDB.response.Message, "Atención");
                } else if (responseDB.response.Code != 0) {
                    toastr.error(responseDB.response.Message, "Error");
                } else {
                    toastr.success("Guardado Exitoso", "");
                    disableForm();
                    setInterval(function wait() {
                        localStorage.removeItem("IdSocio");
                        data = {};
                        window.location.href = '/Socio/Socios';
                    }, 4000);                    
                }
            },
            error: function (error) {
                toastr.error("Error con el servidor", "Error");
            }
        });
    }

    return {
        init: function () {
            idSocio = localStorage.getItem("IdSocio");
            bindEvent();
        },
    };
}(jQuery);