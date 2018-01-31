
function EditaSeguimintoLarval(IdMortalidad, idCultivoLarval, CantidadLarvas, CosechaLarvas, NumeroEstanque, DensidadCultivo, IdFactor)
{ 
    $("#selectTipoM").val(IdMortalidad);
    $("#IdCultivoLarval").val(idCultivoLarval);
    $("#CantidadLarvas").val(CantidadLarvas);
    $("#CosechaLarvas").val(CosechaLarvas);
    $("#NumeroEstanque").val(NumeroEstanque);
    $("#DensidadCultivo").val(DensidadCultivo);
    $("#FactorM").val(IdFactor); 
}
 
$(document).ready(function () {
     
    $("#tblLarvas").DataTable({
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
            url: "GrabaDatosLarval",
            type: "POST",
            data: {
                _idCultivoLarval: $("#IdCultivoLarval").val(),
                _CantidadLarvas: $("#CantidadLarvas").val(),
                _CosechaLarvas: $("#CosechaLarvas").val(),
                _NumeroEstanque: $("#NumeroEstanque").val(),
                _DensidadCultivo: $("#DensidadCultivo").val(), 
                _IdFactoresM: $("#FactorM").val(),
                _selectTipoM: $("#selectTipoM").val() 
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
 