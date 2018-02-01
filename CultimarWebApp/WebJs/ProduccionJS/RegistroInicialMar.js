$(document).ready(function () {
    $("#tblRegistroInicialMar").DataTable({
        paging: true,
        retrieve: true,
        searching: true,
        responsive: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.11/i18n/Spanish.json"
        }
    });

    $("#btnGrabarDatos").click(function () {
        var fechaIngreso = formateaFecha($("#single_cal1").val());
        var fechaFuturoDesobe = formateaFecha($("#single_cal2").val());
        var ID = $("#IdRegistroInicialMar").val();
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }
        $.ajax({
            url: "GrabaRegistroInicialMar",
            type: "POST",
            data: { idRegistro: ID, fechaIngreso: fechaIngreso, fechaFuturo: fechaFuturoDesobe, cantidadOrigen: $("#CantidadOrigen").val(), calibreOrigen: $("#CalibreOrigen").val(), idOrigen: $("#selectOrigen").val(), cantidad: $("#Cantidad").val(), IdTipoSistema: $("#selectTipoSistema").val(), idMortalidad: $("#selectTipoMortalidad").val() },
            async: true,
            success: function (data) {
                if (data == 1) {
                    $("#btnCerrarModal").click();
                    alert("El Ingreso se ha realizado sin problemas.");
                }
                if (data == 3) {
                    alert("Ha ocurrido un error al grabar los datos, intentalo nuevamente.");
                }
                if (data == 4) {
                    alert("No tienes permiso para modificar, Hemos enviado un correo al administrador del sistema solicitando autorización para la modificación del registro, cuando te den autorización, te llegara un Email con la información.");
                }
                if (data == 5) {
                    alert("Tu perfil de usuario no te permite realizar ninguna acción, solo puedes leer la información ingresada al sistema.");
                }
                if (data == 0) {
                    alert("No se ha realizado la acción, intentalo nuevamente.");
                }
            }
        });

    });

    $("#btnPopUpRegistroInicialMar").click(function () {
        $("#IdRegistroInicialMar").val("");
        $("#selectOrigen").val("0");
        $("#CantidadOrigen").val("");
        $("#CalibreOrigen").val("");
        $("#selectTipoSistema").val("0");
        $("#Cantidad").val("");
        $("#selectTipoMortalidad").val("0");
    });



});

function EditaRegistro(IdRegistro, FechaIngreso, FechaFuturoDesdoble, IdOrigen, CantidadOrigen, CalibreOrigen, IdTipoSistema, Cantidad, IdTipoMortalidad) {
    $("#IdRegistroInicialMar").val(IdRegistro);
    $("#single_cal1").val(FechaIngreso);
    $("#single_cal2").val(FechaFuturoDesdoble);
    $("#selectOrigen").val(IdOrigen);
    $("#CantidadOrigen").val(CantidadOrigen);
    $("#CalibreOrigen").val(CalibreOrigen);
    $("#selectTipoSistema").val(IdTipoSistema);
    $("#Cantidad").val(Cantidad);
    $("#selectTipoMortalidad").val(IdTipoMortalidad);
}

function formateaFecha(fechaInput) {
    var fecha = fechaInput;
    var formattedDate = new Date(fecha);
    var d = formattedDate.getDate();
    if (d < 10) {
        d = "0" + d;
    }
    var m = formattedDate.getMonth();
    m += 1;  // JavaScript months are 0-11
    if (m < 10) {
        m = "0" + m;
    }
    var y = formattedDate.getFullYear();
    fecha = d + "-" + m + "-" + y;
    return fecha;
}
