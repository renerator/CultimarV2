function EditaSemilla(IdSeguimientoSemilla,
    selectOrigen, 
    single_cal1,
    selectFactorM,
    IdCantidadOrigen,
    IdCalibreOrigen,
    selectDestino,
    IdCantidadCosechado,
    IdCantidadCalibre, IdTipoContenedorOrigen) {  
 
    $("#IdSemilla").val(IdSeguimientoSemilla);
    $("#selectOrigen").val(selectOrigen);
    //$(single_cal1).val(single_cal1);
    //$("#selectFactorM").val(selectFactorM);
    //$("#IdCantidadOrigen").val(IdCantidadOrigen);
    //$("#IdCalibreOrigen").val(IdCalibreOrigen);
    //$("#selectDestino").val(selectDestino);
    //$("#IdCantidadCosechado").val(IdCantidadCosechado);
    //$("#IdCantidadCalibre").val(IdCantidadCalibre);
}


$(document).ready(function () {

    $("#datepicker").change(function () {
        changedDate = $(this).val(); //in yyyy-mm-dd format obtained from datepicker
        var date = new Date(changedDate);
        dd_mm_yyyy = twoDigitDate(date) + "-" + twoDigitMonth(date) + "-" + date.getFullYear(); // in dd-mm-yyyy format
        $('#single_cal1').val(dd_mm_yyyy);
    });



    $("#datepicker").change(function () {
        changedDate = $(this).val(); //in yyyy-mm-dd format obtained from datepicker
        var date = new Date(changedDate);
        dd_mm_yyyy = twoDigitDate(date.getDay) + "-" + twoDigitMonth(date.getMonth) + "-" + date.getFullYear(); // in dd-mm-yyyy format
        $('#single_cal1').val(dd_mm_yyyy);
    });





    $("#tblSeguimientosSemilla").DataTable({
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




    $("#divAlert").hide();
    $("#btnGrabarDatos").click(function () {
        $.ajax({
            url: "GrabaDatos",
            type: "POST",
            data: {
                _IdSemilla: $("#IdSemilla").val(),
                _IdTipoContenedorOrigen: $("#selectOrigen").val(),
                _FechaRegistro: $(single_cal1).val(),
                _IdFactoresMedicion: $("#selectFactorM").val(),
                _CantidadOrigen: $("#IdCantidadOrigen").val(),
                _CalibreOrigen: $("#IdCalibreOrigen").val(),
                _IdTipoContenedorDestino: $("#selectDestino").val(),
                _CantidadCosechado: $("#IdCantidadCosechado").val(),
                _CantidadCalibre: $("#IdCantidadCalibre").val()
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