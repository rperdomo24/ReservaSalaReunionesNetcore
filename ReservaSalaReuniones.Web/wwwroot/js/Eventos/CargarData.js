function InicializarModalEvento(modal, Titulo, ini, fin, texts, idreserva) {
    var botones = '';
    document.getElementById("modal-footer").innerHTML = "";

    $(' #FechaInicio').val(momentFormat(ini));
    $('#FechaFin').val(momentFormat(fin));
    $('#TituloModal').text(Titulo);
    botones += '<button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>';
    if (texts) {
        $('#Descripcion').val(texts);
        console.log(idreserva);
        $('#IdReserva').val(idreserva);
        botones += '<input type="submit" value="Cancelar reserva" class="btn btn-danger" />';
        $('#create').attr('action', "/Reserva/delete");
    } else {
        $('#create').attr('action', "/Reserva/Create");
        botones += '<input type="submit" value="Reservar" class="btn btn-primary" />';
    }
    $("#modal-footer").append(botones);
    $("#myModal").modal();
}

function InicializaCalendario(IdSala) {
    if (calendar) {
        calendar.destroy();
    }

    calendar = new FullCalendar.Calendar(calendarEl, {
        plugins: ['bootstrap', 'interaction', 'dayGrid', 'timeGrid'],
        selectable: true,
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        select: function (info) {
            if (calendar.view.type == 'dayGridMonth') {
                calendar.changeView('timeGridDay', info.startStr);
            } else {
                InicializarModalEvento('myModal', 'Datos para reservar sala', info.start, info.end);
            }
        },
        eventClick: function (info) {
            InicializarModalEvento('myModal1', 'Datos de reserva', info.event.start, info.event.end, info.event.title, info.event.id);
            console.log(info);
        },
        timeZone: 'local',
        locale: 'es',

        eventSources: [
            {
                url: '/Reserva/ObtenerReservas?Id=' + IdSala,
                method: 'get',
                success: function (e) {
                    return e.data;
                },
                failure: function (s) {
                    console.log(s);
                }
            }
        ],
        editable: true,
        droppable: true
    });
    calendar.render();
}

function ObtenerdataSelect() {

    $.ajax({
        type: "GET",
        url: '/SalaReuniones/ObtenerSalas',
        dataType: "json",
        success: function (data) {
            CargarSelect("#Sala", data.data, "nombreSala", "idSala");
        },
        error: function (data) {
            alert('error');
        }
    });

}

function InicializaCalendarioLimpio() {
    calendar = new FullCalendar.Calendar(calendarEl, {
        plugins: ['bootstrap', 'interaction', 'dayGrid', 'timeGrid'],
        selectable: true,
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        timeZone: 'local',
        locale: 'es',
        select: function (info) {
            alert("Antes de reservar debe seleccionar la sala");

        },
    });
    calendar.render();
}