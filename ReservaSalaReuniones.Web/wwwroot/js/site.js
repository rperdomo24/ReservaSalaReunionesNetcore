
function regresarPagina() {
    window.history.back();
}

function VerAlertas(Titulo, Texto, type) {
    Swal.fire(
        {
            type: type,
            title: Titulo,
            html: Texto,
            showConfirmButton: false,
            timer: 4000
        }
    );
}

function Cancelar(NameForms) {
    $('#' + NameForms).trigger("reset");
}

function momentFormat(id) {
    return moment(id).format('DD-MM-YYYY hh:mm A');
}

function PaqueteDatePicker(IdInput) {
    $('input[id="' + IdInput + '"]').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        minYear: 2000,
        autoUpdateInput: true,
        timePicker: true,
        locale: {
            format: 'DD-MM-YYYY hh:mm'
        }
        //}, function (chosen_date) {
        //    $('input[id="' + IdInput + '"]').val(chosen_date.format('DD-MM-YYYY hh:mm'));
        //});
    });

}


function PaqueteDatePickerLimpio(IdInput) {
    $('input[id="' + IdInput + '"]').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        minYear: 2000,
        autoUpdateInput: false,
        timePicker: true,
        locale: {
            format: 'DD-MM-YYYY hh:mm A'
        }
    }, function (chosen_date) {
        $('input[id="' + IdInput + '"]').val(chosen_date.format('DD-MM-YYYY hh:mm A'));
    });

}

function InicializarSelect(Class) {
    $(Class).select2({
        theme: 'bootstrap4'
    });
}




function CargarSelect(select, data, argText, argKey) {
    $(select).append(new Option('Seleccione una sala', "0"));
    $.each(data, function (key, value) {
        $(select).append(new Option(value[argText], value[argKey]));
    });
}




