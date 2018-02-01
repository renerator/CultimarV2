﻿function EditaFijacion(
    _IdSeguimientoFijacion,
    _FechaRegistro,
    _LarvasCalibre,
    _LarvasCantidad,
    _CosechaCalibre,
    _CosechaCantidad,
    _NumeroEstanque,
    _DensidadSiembra,
    _IdMortalidad,
    _CantidadMortalidad,
    _FactoresMedicion 
) {

    //alert(_IdSeguimientoFijacion);

    $("#IdSeguimientoFijacion").val(_IdSeguimientoFijacion),
    $("#IdCalibreLarvas").val(_LarvasCalibre),
    $("#idCantidadLarvas").val(_LarvasCantidad),
    $("#IdCosechaCalibre").val(_CosechaCalibre),
    $("#IdCosechaCantidad").val(_CosechaCantidad),
    $("#IdNumeroEstanque").val(_NumeroEstanque),
    $("#IdDensidadSiembra").val(_DensidadSiembra),
    $("#selectTipoM").val(_IdMortalidad),
    $("#IdCantidadMortalidad").val(_CantidadMortalidad),
    $("#FactorM").val(_FactoresMedicion),
    $("#single_cal1").val(_FechaRegistro)
}


$(document).ready(function () {



    $("#tblSeguimientosFijacion").DataTable({
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
            url: "GrabaSeguimientoFijacion",
            type: "POST",
            data: {
                _IdSeguimientoFijacion: $("#IdSeguimientoFijacion").val(),
                _LarvasCalibre: $("#IdCalibreLarvas").val(),
                _LarvasCantidad: $("#IdCosechaCantidad").val(),
                _CosechaCalibre: $("#IdCosechaCalibre").val(),
                _CosechaCantidad: $("#IdCosechaCantidad").val(),
                _NumeroEstanque: $("#IdNumeroEstanque").val(),
                _DensidadSiembra: $("#IdDensidadSiembra").val(),
                _IdMortalidad: $("#selectTipoM").val(),
                _CantidadMortalidad: $("#IdCantidadMortalidad").val(),
                _FactoresMedicion: $("#FactorM").val(),
                _FechaRegistro: $("#single_cal1").val()
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