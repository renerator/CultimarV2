
function EditaProduccion(IdRegistroProduccion,
    CantidadProductoresMachos,
    CantidadProductoresHembras,  
    CantidadFecundada,
    NumeroDesoveTemporada,
    CantidadSembrada,
    IdFactor,
    NumeroEstanquesUtilizado,
    DensidadSiembra) {
     
     
    $("#IdRegistro").val(IdRegistroProduccion);
    $("#CantidadPMachos").val(CantidadProductoresMachos);
    $("#CantidadPHembras").val(CantidadProductoresHembras); 
    $("#CantidadFecundada").val(CantidadFecundada);
    $("#NroDesoveTemporada").val(NumeroDesoveTemporada);
    $("#CantidadSembrada").val(CantidadSembrada);
    $("#FactorM").val(IdFactor);
    $("#NroEstanque").val(NumeroEstanquesUtilizado);
    $("#DensidadSiembra").val(DensidadSiembra); 
}

$(document).ready(function () {

 
 

    $("#tblRegistroProduccion").DataTable({
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
            url: "GrabaDatosRegistroProduccion",
            type: "POST",
            data: {
                _IdProduccion: $("#IdRegistro").val(),
                _CantidadProductoresMachos: $("#CantidadPMachos").val(),
                _CantidadProductoresHembras: $("#CantidadPHembras").val(), 
                _CantidadFecundada: $("#CantidadFecundada").val(),
                _NumeroDesoveTemporada: $("#NroDesoveTemporada").val(),
                _CantidadSembrada: $("#CantidadSembrada").val(),
                _FactoresMedicion: $("#FactorM").val(),
                _NumeroEstanquesUtilizado: $("#NroEstanque").val(),
                _DensidadSiembra: $("#DensidadSiembra").val()
            },

            async: true,
            success: function (data) {
                if (data == 0) {
                    $("#btnCerrarModal").click();
                    alert("El Ingreso se ha realizado sin problemas.");
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