function EditDespacho(
    _IdPreparoDespacho,
    _FechaEnvio,
    _FechaPreparado,
    _IdOrigen,
    _IdDestino,
    _PesoNeto,
    _PesoBruto,
    _Cantidad,
    _Calibre,
    _cliente

) {
        $("#idDespacho").val(_IdPreparoDespacho),
        $("#single_cal1").val(_FechaEnvio),
        $("#single_cal3").val(_FechaPreparado),
        $("#selectOrigen").val(_IdOrigen),
        $("#selectDestino").val(_IdDestino),
        $("#idPesoNeto").val(_PesoNeto),
        $("#idPesoBruto").val(_PesoBruto),
        $("#idCantidadCalibres").val(_Cantidad),
        $("#idCalibre").val(_Calibre),
        $("#idCliente").val(_cliente)

}


$(document).ready(function () {

     
    $("#tblPreparacionDespacho").DataTable({
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
            url: "GrabaPdespacho",
            type: "POST",
            data: {

                _IdPreparoDespacho: $("#idDespacho").val(),
                _FechaEnvio: $("#single_cal1").val(),
                _FechaPreparado: $("#single_cal3").val(),
                _IdOrigen: $("#selectOrigen").val(),
                _IdDestino: $("#selectDestino").val(),
                _PesoNeto: $("#idPesoNeto").val(),
                _PesoBruto: $("#idPesoBruto").val(),
                _Cantidad: $("#idCantidadCalibres").val(),
                _Calibre: $("#idCalibre").val(),
                _cliente: $("#idCliente").val()
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
