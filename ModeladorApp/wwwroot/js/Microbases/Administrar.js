function cargarArchivo() {
    var fileUpload = $("#txtSubirA").get(0);
    
    var files = fileUpload.files;
    var file_bytes = new FormData();
    for (var i = 0; i < files.length; i++) {
        file_bytes.append(files[i].name, files[i]);
    }
    var observaciones = $('#txtObs').val();

    if (observaciones != "" && observaciones != null) {

        var upload_response = funUploadExcel(observaciones, file_bytes)
        upload_response.then(function (response) {
            console.log(response);
            if (response.msg == "Archivo subido con exito.") {
                Swal.fire('Cargado !', 'Se subieron: ' + response.registros + ' Registros, puedes consultar la pestaña historial de cargas', 'success')
            } else if (response == "El campo descripcion/comentario debe ser llenado.") {
                swal("Atencion", "Por favor escribe una observacion o comentario para cargar tu archivo", "warning");
            } else if (response == "El formato de una o varias columnas no es el establecido, por favor revisar el Excel.") {
                swal("Error", response, "warning");
            } else if (response == "El archivo selecionado no es un documento Excel.Verifique que la extención del documento sea .XLS o .XLSX") {
                swal("Error", response, "warning");
            }
        });
    } else {

        Swal.fire('ATENCION', 'Por favor agregar un comentario', 'warning')
    }
    return false;    
}
async function funUploadExcel(obs, file_bytes) {
    return carga = await funUploadExcelToDB(obs, file_bytes);    
};
function funUploadExcelToDB(obs, file_bytes) {
    return $.ajax({
        type: "POST",
        dataType: "json",
        url: "/Microbases/subirArchivo?observaciones=" + obs,
        contentType: false,
        processData: false,
        data: file_bytes,
        success: function (obs) {
            //console.log(response);
        },
    });
}