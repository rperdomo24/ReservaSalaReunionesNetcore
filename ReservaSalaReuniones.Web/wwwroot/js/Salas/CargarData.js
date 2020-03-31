function CargarSalas() {
    var table = $('#table').DataTable({
        "ajax": {
            method: 'get',
            url: '/SalaReuniones/ObtenerSalas',
            async: true
        },
        "columns": [
            { "data": "nombreSala", "name": " Nombre de sala" },
            { "data": "descripcion", "name": "Descripción" },
            {
                "mData": null,
                "mRender": function (data, type, row, meta) {
                    //console.log(data);
                    var url = "/SalaReuniones";
                    var EditaData = "<a href='" + url + "/Edit/" + data.idSala + "' class='btn btn-warning fas fa-edit'></a>";
                    var Deletedata = "<a href='" + url + "/Delete/" + data.idSala + "' class='btn btn-danger fas fa-trash-alt'></a>";
                    var result = "<div class='btn-group mr-2' role='group' aria-label='First group'>";
                    result += EditaData;
                    result += Deletedata;
                    result += "</div>";
                    return result;
                }
            }
        ],
        "paging": true,
        "searching": true,
        "autoWidth": true,
        "responsive": true
    });
}