function EditaSemilla(
    idOrigen,
    IdDestino,
    idFactorMedicion,
    IdSeguimientoSemilla,
    single_cal1,
    IdCantidadOrigen,
    IdCalibreOrigen,
    IdCantidadCosechado,
    IdCantidadCalibre
) {


    $("#IdSemilla").val(IdSeguimientoSemilla);
    $("#selectOrigen").val(idOrigen);
    $(single_cal1).val(single_cal1);
    $("#FactorM").val(idFactorMedicion);
    $("#IdCantidadOrigen").val(IdCantidadOrigen);
    $("#IdCalibreOrigen").val(IdCalibreOrigen);
    $("#selectDestino").val(IdDestino);
    $("#IdCantidadCosechado").val(IdCantidadCosechado);
    $("#IdCantidadCalibre").val(IdCantidadCalibre);
}


$(document).ready(function () {

     

    $("#tblSeguimientosSemilla").DataTable({
        paging: true,
        retrieve: true,
        searching: true,
        responsive: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.11/i18n/Spanish.json"
        }
    });




    $("#divAlert").hide();
    $("#btnGrabarDatos").click(function () {
       
        $.ajax({
            url: "GrabaDatos",
            type: "POST",
            data: {
                _IdSemilla: $("#IdSemilla").val(),
                _IdTipoContenedorOrigen: $("#selectOrigen").val(),
                _FechaRegistro: $(single_cal1).val(),
                _IdFactoresMedicion: $("#FactorM").val(),
                _CantidadOrigen: $("#IdCantidadOrigen").val(),
                _CalibreOrigen: $("#IdCalibreOrigen").val(),
                _IdTipoContenedorDestino: $("#selectDestino").val(),
                _CantidadCosechado: $("#IdCantidadCosechado").val(),
                _CantidadCalibre: $("#IdCantidadCalibre").val()
            },

            async: true,
            success: function (data) {
                //if (data == 0) {
                //    $("#btnCerrarModal").click();
                //    alert("El Ingreso se ha realizado sin problemas.");
                //}
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

function EditaUsuarios(item) {
    $.ajax({
        url: "AutorizaUsuario",
        type: "POST",
        data: { idUsuario: item },
        async: true,
        success: function (data) {
            if (data == 0) {
                alert("No se ha podido realizar la autorización");
            }
            if (data == 1) {
                alert("Autorización realizada con exito...!!!");
                location.reload();
            }
        }
    });

}

function QuitapermisoUsuarios(item) {
    $.ajax({
        url: "QuitapermisoUsuarios",
        type: "POST",
        data: { idUsuario: item },
        async: true,
        success: function (data) {
            if (data == 0) {
                alert("Error al realizar la solicitud en la BD.");
            }
            if (data == 1) {
                alert("Acción realizada con exito...!!!");
                location.reload();
            }
        }
    });
}