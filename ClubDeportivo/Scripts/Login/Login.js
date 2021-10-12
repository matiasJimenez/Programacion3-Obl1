
var working = false;
var funcionarioData = undefined;

$('.login').on('submit', function (e) {
    e.preventDefault();
    if (working) return;
    working = true;
    var $this = $(this),
        $state = $this.find('button > .state');
    $this.addClass('loading');
    $state.html('Autenticando');
    $('#stateSpinner').prepend('<i id="spinnerLog" class="spinner"></i>');

    logFuncionario($this, $state);
});

function dataForm() {
    funcionarioData = {
        Mail: $("#txtMail").val(),
        Contraseña: $("#txtContraseña").val()
    };
}

function logFuncionario($this, $state) {
    dataForm();
    $.ajax({
        method: 'POST',
        url: '/Login/Authentication',
        cache: false,
        data: funcionarioData,
        dataType: "json",
        success: function (responseDB) {
            if (responseDB.response.Code == 700) {
                toastr.warning(responseDB.response.Message, "Atención");
                $state.html('Log in');
                $this.removeClass('ok loading');
                $('#spinnerLog').remove();
                working = false;
            } else if (responseDB.response.Code != 0) {
                toastr.error(responseDB.response.Message, "Error");
                $state.html('Log in');
                $this.removeClass('ok loading');
                $('#spinnerLog').remove();
                working = false;
            } else {
                logOk($this, $state);                
            }
        },
        error: function (error) {
            toastr.error("Error con el servidor", "Error");
        }
    });
}

function logOk($this, $state) {
    setTimeout(function () {
        $this.addClass('ok');
        $state.html('Bienvenido!');
        setTimeout(function () {
            $state.html('Log in');
            $this.removeClass('ok loading');
            working = false;
            window.location.href = '/Socio/Socios';
        }, 1000);
    }, 3000);    
}