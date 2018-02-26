function EditaSeguimientoMar(
_IdSeguimiento,
_IdRegistroInicial,
_IdMortalidad,
_FechaDesdoble,
_CantidadOrigen,
_IdCalibreOrigen,
_IdUbicacionOrigen,
    _IdUbicacionDestino,
_IdTipoSistema,
_CantidadSistemaOrigen,
_IdSistemaOrigen,
_CantidadDestino,
_IdCalibreDestino,
_CantidadSistemaDestino,
_IdSistemaDestino,
_Observaciones
) {
    $("#IdRegistroSeguimiento").val(_IdSeguimiento);
    $("#NombreCultivo").val(_IdRegistroInicial);
    $("#selectTipoMortalidad").val(_IdMortalidad);
    $("#single_cal1").val(_FechaDesdoble);
    $("#CantidadOrigen").val(_CantidadOrigen);
    $("#CalibreOrigen").val(_IdCalibreOrigen);
    $("#selectTipoSistemaOrigen").val(_IdSistemaOrigen);
    $("#CantidadSistemaOrigen").val(_CantidadSistemaOrigen);
    $("#CantidadDestino").val(_CantidadDestino);
    $("#CalibreDestino").val(_IdCalibreDestino);
    $("#selectTipoSistemaDestino").val(_IdSistemaDestino);
    $("#CantidadSistemaDestino").val(_CantidadSistemaDestino);
    $("#txtObservaciones").val(_Observaciones);
    $("#selectUbicacionDestino").val(_IdUbicacionDestino);
    $("#selectUbicacionOrigen").val(_IdUbicacionOrigen);

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




$(document).ready(function () {
    $("#tblRegistroSeguimientoMar").DataTable({
        paging: true,
        retrieve: true,
        searching: true,
        responsive: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.11/i18n/Spanish.json"
        }
    });
    $("#btnPopUpRegistroSeguimientoMar").click(function () {
        $("#IdRegistroSeguimiento").val("");
        $("#NombreCultivo").val("");
        $("#selectTipoMortalidad").val("");
        $("#CantidadOrigen").val("");
        $("#CalibreOrigen").val("");
        $("#selectTipoSistemaOrigen").val("");
        $("#CantidadSistemaOrigen").val("");
        $("#CantidadDestino").val("");
        $("#CalibreDestino").val("");
        $("#selectTipoSistemaDestino").val("");
        $("#CantidadSistemaDestino").val("");
        $("#txtObservaciones").val("");
        $("#selectUbicacionDestino").val("");
        $("#selectUbicacionOrigen").val("");

    });

    $("#btnGrabarDatos").click(function () {
        var ID = $("#IdRegistroSeguimiento").val();
        var IdRegistroInicial = $("#NombreCultivo").val();
        var IdMortalidad = $("#selectTipoMortalidad").val();
        var FechaDesdoble = formateaFecha($("#single_cal1").val());
        var CantidadOrigen = $("#CantidadOrigen").val();
        var IdCalibreOrigen = $("#CalibreOrigen").val();
        var IdUbicacionOrigen = $("#selectUbicacionOrigen").val();
        var CantidadSistemaOrigen = $("#CantidadSistemaOrigen").val();
        var IdSistemaOrigen = $("#selectTipoSistemaOrigen").val();
        var CantidadDestino = $("#CantidadDestino").val();
        var IdCalibreDestino = $("#CalibreDestino").val();
        var IdUbicacionDestino = $("#selectUbicacionDestino").val();
        var CantidadSistemaDestino = $("#CantidadSistemaDestino").val();
        var IdSistemaDestino = $("#selectTipoSistemaDestino").val();
        var Observaciones = $("#txtObservaciones").val();
        
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }

        $.ajax({
            url: "GrabaSeguimientoMar",
            type: "POST",
            data: {
                _IdSeguimiento: ID,
                _IdRegistroInicial: IdRegistroInicial,
                _IdMortalidad: IdMortalidad,
                _FechaDesdoble: FechaDesdoble,
                _CantidadOrigen: CantidadOrigen,
                _IdCalibreOrigen: IdCalibreOrigen,
                _IdUbicacionOrigen: IdUbicacionOrigen,
                _CantidadSistemaOrigen: CantidadSistemaOrigen,
                _IdSistemaOrigen: IdSistemaOrigen,
                _CantidadDestino: CantidadDestino,
                _IdCalibreDestino: IdCalibreDestino,
                _IdUbicacionDestino: IdUbicacionDestino,
                _CantidadSistemaDestino: CantidadSistemaDestino,
                _IdSistemaDestino: IdSistemaDestino,
                _Observaciones: Observaciones
            },

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

});
