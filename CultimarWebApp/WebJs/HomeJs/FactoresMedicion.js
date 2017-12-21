$(document).ready(function () {
    $("#tblFactoresMedicion").DataTable({
        paging: true,
        retrieve: true,
        dom: 'Bfrtip',
        buttons: [{
            text: 'Excel',
            extend: 'excel'
        },
        {
            text: 'PDF',
            extend: 'pdf'
        }
        ],
        searching: true,
        "language": {
            "lengthMenu": "Mostrar _MENU_ filas por Página",
            "zeroRecords": "Sin Resultados",
            "info": "Mostrando página _PAGE_ de _PAGES_",
            "infoEmpty": "No se han encontrado registros",
            "infoFiltered": "(Filtrando de un total de  _MAX_ registros)"
        }
    });


    $("#btnGrabarDatos").click(function () {
        alert("Funcionalidad en Desarrollo");
        ////$.ajax({
        ////    url: "GrabaDatos",
        ////    type: "POST",
        ////    data: { rut: $("#inputSuccess4").val(), pass: $("#inputSuccess5").val(), nombreUsuario: $("#inputSuccess2").val(), apellidoUsuario: $("#inputSuccess3").val(), idPerfil: $("#selectPerfil").val() },
        ////    async: true,
        ////    success: function (data) {
        ////        if (data == 1) {
        ////            $("#btnCerrarModal").click();
        ////            alert("El Ingreso se ha realizado sin problemas.");
        ////        }
        ////        if (data == 2) {
        ////            alert("El usuario que intenta agregar, ya existe en la BD.");
        ////        }
        ////        if (data == 3) {
        ////            alert("El usuario que intenta agregar, ya existe en la BD.");
        ////        }
        ////        if (data == 4) {
        ////        }
        ////        if (data == 0) {
        ////            alert("El Rut ingresado no corresponde a un rut correcto, intentalo nuevamente.");
        ////        }
        ////    }
        ////});
    });


});