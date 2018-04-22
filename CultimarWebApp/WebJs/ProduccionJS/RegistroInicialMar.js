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
        var NombreCultivo = $("#NombreCultivo").val();
        var CalibreOrigen = $("#CalibreOrigen").val();
        var CantidadOrigen = $("#CantidadOrigen").val();
        var IdSistema = $("#selectTipoSistema").val();
        var Cantidad = $("#Cantidad").val();
        var IdMortalidad = $("#selectTipoMortalidad").val();
        var observaciones = $("#txtObservaciones").val();
        var _ubicacionOceanica = $("#ubicacionOceanica").val();


        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }
        $.ajax({
            url: "GrabaRegistroInicialMar",
            type: "POST",
            data: {
                idRegistro: ID,
                idCultivo: NombreCultivo,
                fechaIngreso: fechaIngreso,
                fechaFuturo: fechaFuturoDesobe,
                cantidadOrigen: CantidadOrigen,
                calibreOrigen: CalibreOrigen,
                cantidad: Cantidad,
                IdTipoSistema: IdSistema,
                idMortalidad: IdMortalidad,
                observaciones: observaciones,
                ubicacionOceanica: _ubicacionOceanica
            },
            async: true,
            success: function (data) {
                if (data == 1) {
                    $("#btnCerrarModal").click();
                    alert("El Ingreso se ha realizado sin problemas.");
                    window.location.reload(true);
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
        $("#NombreCultivo").val("");
        $("#CalibreOrigen").val("");
        $("#CantidadOrigen").val("");
        $("#selectTipoSistema").val("");
        $("#Cantidad").val("");
        $("#selectTipoMortalidad").val("");
        $("#txtObservaciones").val("");
        $("#ubicacionOceanica").val("");
    });



});

function EditaRegistro(IdRegistro, IdRegistroLarval, FechaIngreso, FechaFuturoDesdoble, IdOrigen, CantidadOrigen, CalibreOrigen, IdTipoSistema, Cantidad, IdTipoMortalidad, Observaciones, ubicacionOceanica) {
    $("#IdRegistroInicialMar").val(IdRegistro);
    $("#NombreCultivo").val(IdRegistroLarval);
    $("#CalibreOrigen").val(IdOrigen);
    $("#single_cal1").val(FechaIngreso);
    $("#single_cal2").val(FechaFuturoDesdoble);
    $("#CantidadOrigen").val(CantidadOrigen);
    $("#selectTipoSistema").val(IdTipoSistema);
    $("#Cantidad").val(Cantidad);
    $("#selectTipoMortalidad").val(IdTipoMortalidad);
    $("#txtObservaciones").val(Observaciones);
    $("#ubicacionOceanica").val(ubicacionOceanica);
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


