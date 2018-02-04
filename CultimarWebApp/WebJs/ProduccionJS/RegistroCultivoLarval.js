
function EditaSeguimintoLarval(idCultivoLarval,IdMortalidad,CantidadLarvas, CosechaLarvas, DensidadCultivo, FactoresMedicion, NumeroEstanque)
{  
    $("#selectTipoM").val(IdMortalidad);
    $("#IdCultivoLarval").val(idCultivoLarval);
    $("#CantidadLarvas").val(CantidadLarvas);
    $("#CosechaLarvas").val(CosechaLarvas);
    $("#NumeroEstanque").val(NumeroEstanque);
    $("#DensidadCultivo").val(DensidadCultivo);
    $("#FactorM").val(FactoresMedicion); 
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
 