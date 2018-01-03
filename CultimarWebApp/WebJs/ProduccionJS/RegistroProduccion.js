$(document).ready(function () {

    $("#datepicker").change(function () {
        changedDate = $(this).val(); //in yyyy-mm-dd format obtained from datepicker
        var date = new Date(changedDate);
        dd_mm_yyyy = twoDigitDate(date) + "-" + twoDigitMonth(date) + "-" + date.getFullYear(); // in dd-mm-yyyy format
        $('#single_cal1').val(dd_mm_yyyy);
    });


 

    $("#tblRegistroProduccion").DataTable({
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
            url: "GrabaDatosRegistroProduccion",
            type: "POST",
            data: {
                _CantidadProductoresMachos: $("#CantidadPMachos").val(),
                _CantidadProductoresHembras: $("#CantidadPHembras").val(),
                _FechaInicioCultivo: $(single_cal1).val(),
                _CantidadFecundada: $("#CantidadFecundada").val(),
                _NumeroDesoveTemporada: $("#NroDesoveTemporada").val(),
                _CantidadSembrada: $("#CantidadSembrada").val(),
                _FactoresMedicion: $("#FactoresMedicion").val(),
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