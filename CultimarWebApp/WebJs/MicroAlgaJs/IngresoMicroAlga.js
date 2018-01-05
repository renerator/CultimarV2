﻿

$(document).ready(function () {
    $("#tblMicroAlgas").DataTable({
            paging: true,
            retrieve: true,
            searching: true,
            responsive: true,
            "language": {
                "url": "//cdn.datatables.net/plug-ins/1.10.11/i18n/Spanish.json",
                "lengthMenu": "Mostrar _MENU_ filas por Página",
                "zeroRecords": "No existen Registros en el sistema",
                "info": "Mostrando página _PAGE_ de _PAGES_",
                "infoEmpty": "No se han encontrado registros",
                "infoFiltered": "(Filtrando de un total de  _MAX_ registros)"
            }
    });

    $("#btnGrabarDatos").click(function () {
        var fechaConFormato = formateaFecha($("#single_cal1").val());
        var ID = $("#IdMicroAlga").val();
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }

        if ($("#selectEspecies").val() != "")
        {
                $.ajax({
                    url: "GrabaDatosMicroAlga",
                    type: "POST",
                    data: { idMicroAlga: ID, idEspecie: $("#selectEspecies").val(), cantidadVolumen: $("#cantidadVolumen").val(), numeroBolsa: $("#numeroBolsa").val(), fecha: fechaConFormato },
                    async: true,
                    success: function (data) {
                        if (data == 1) {
                            $("#btnCerrarModal").click();
                            alert("El Ingreso se ha realizado sin problemas.");
                        }
                        if (data == 2) {
                            alert("Debe ingresar todos los datos, no podra grabar en la BD.");
                        }
                        if (data == 3) {
                            alert("Ha ocurrido un error al grabar los datos, intentalo nuevamente.");
                        }
                        if (data == 4) {
                            alert("No tienes permiso para modificar, debes solicitar permiso al administrador para que puedas modificar datos en el sistema.");
                        }
                        if (data == 5) {
                            alert("Tu perfil de usuario no te permite realizar ninguna acción, solo puedes leer la información ingresada al sistema.");
                        }
                        if (data == 0) {
                            alert("No se ha realizado la acción, intentalo nuevamente.");
                        }
                    }
                });
        }
        else
        { alert("Debe definir la Especie a ingresar"); }
        
    });

    $("#btnPopUpMicroAlga").click(function () {
        $("#selectEspecies").val("");
        $("#IdMicroAlga").val("");
        $("#cantidadVolumen").val("");
        $("#numeroBolsa").val("");
    });
});

function EditaMicroAlga(idMicroAlga, nombreEspecie, cantidadVolumen, numeroBolsa, fecha, idEspecie) {
    $("#selectEspecies").val(idEspecie);
    $("#IdMicroAlga").val(idMicroAlga);
    $("#cantidadVolumen").val(cantidadVolumen);
    $("#numeroBolsa").val(numeroBolsa);
    $("#single_cal1").val(fecha);
}


function formateaFecha(fechaInput) {
    var fecha = fechaInput;
    var formattedDate = new Date(fecha);
    var d = formattedDate.getDate();
    if (d < 10)
    {
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