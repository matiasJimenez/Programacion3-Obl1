var FuncionarioDetails = function ($) {
    var funcionarioData = undefined;

    function bindEvent() {
        $("#btnSaveFuncionario").on("click", function () {
            saveFuncionario();
        });
    }

    function dataForm() {
        funcionarioData = {
            IdFuncionario: 0,
            Mail: $("#txtMail").val(),
            Contraseña: $("#txtContraseña").val()
        };
    }

    function disableForm() {
        $("#txtMail").prop("disabled", true);
        $("#txtContraseña").prop("disabled", true);
        $("#btnSaveFuncionario").prop("disabled", true);
    }

    function saveFuncionario() {
        dataForm()
        $.ajax({
            method: 'POST',
            url: '/Login/CreateFuncionario',
            cache: false,
            data: funcionarioData,
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
                        window.location.href = '/Login/Login';
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
            bindEvent();
        },
    };
}(jQuery);