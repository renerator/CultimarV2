function EditaOrigen(idOrigen, nombreOrigen) {
    $("#Idorigen").val(idOrigen);
    $("#nombreOrigen").val(nombreOrigen);
}

$(document).ready(function () {
    $("#tblParametrosTipoSistema").DataTable({
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
    $("#tblParametrosTipoMortalidad").DataTable({
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

    $("#tblParametrosTipoIdentificacion").DataTable({
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


    $("#tblParametrosTipoContenedor").DataTable({
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

    $("#tblParametrosOrigen").DataTable({
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
    $("#tblParametrosEspecies").DataTable({
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
    $("#tblParametrosDestino").DataTable({
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


    $("#btnGrabarParametrosOrigen").click(function () {
        var ID = $("#Idorigen").val();
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }
        $.ajax({
            url: "GrabaParametroOrigen",
            type: "POST",
            data: { idOrigen: ID, nombreOrigen: $("#nombreOrigen").val() },
            async: true,
            success: function (data) {
                if (data == 1) {
                    $("#btnCerrarModalOrigen").click();
                    alert("El Ingreso se ha realizado sin problemas.");
                }
                if (data == 2) {
                    alert("No se puede grabar el dato en la BD, intentalo nuevamente.");
                }
                if (data == 3) {
                    alert("El nombre del parametro no puede estar vacio, no se ha realizado la operación.");
                }
                if (data == -1) {
                    top.location.href = 'ErrorPage?error=101';
                }
                if (data == 0) {
                    alert("Hay un problema con el metodo de grabación, reinicia la sesión e intentalo nuevamente.");
                }
            }
        });
    });
    $("#btnGrabarParametrosDestino").click(function () {
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