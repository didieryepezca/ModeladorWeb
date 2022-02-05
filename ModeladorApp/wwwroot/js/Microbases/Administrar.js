window.onload = loadEquipos();

async function loadEquipos() {
    
    var equipos = await funGetAllEquipos(); // la que contendra la data de la función asyncrona.   

    $(function () {
        $("#dataGrid").dxDataGrid({
            dataSource: equipos,
            keyExpr: "iD_EQUIPO",
            allowColumnResizing: true,
            columnAutoWidth: true,
            columnFixing: {
                enabled: true
            },
            allowColumnReordering: true,
            //columnChooser: { enabled: true },
            columns: [{
                caption: 'NOMBRE DE QUIPO',
                dataField: "nombrE_EQUIPO",
                validationRules: [{
                    type: "required"
                }],
                fixed: true
            }, {
                caption: 'NCR',
                dataField: "ncR_EQUIPO",
                validationRules: [{
                    type: "required"
                }]
                }, {
                caption: 'FECHA REGISTRO',
                dataField: "fechA_REGISTRO",
                dataType: "date",
                format: "dd/MM/yyyy HH:mm",
                width: 180,
                validationRules: [{
                    type: "required"
                }]
            },  {
                dataField: "usuario",               
                groupIndex: 0,
                sortOrder: "asc",
                validationRules: [{
                    type: "required"
                }]
                }],        
            
            filterRow: { visible: true },
            searchPanel: { visible: true },
            groupPanel: { visible: true },
            selection: { mode: "single" },
            onSelectionChanged: function (e) {
                e.component.byKey(e.currentSelectedRowKeys[0]).done(employee => {
                    if (employee) {
                        $("#selected-employee").text(`Selected employee: ${employee.FullName}`);
                    }
                });
            },
            summary: {
                groupItems: [{
                    summaryType: "count"
                }]
            },           
            editing: {
                mode: "popup",
                allowUpdating: true,
                allowDeleting: true,
                allowAdding: true,
                popup: {
                    title: 'Información del Equipo',
                    showTitle: true,
                    width: 700,
                    height: 525,
                }
            },
            onRowUpdated: function (e) {
                var data = JSON.stringify(e.data);
                //console.log(selectedRow)
                var actualizar = funUpdateEquipo(data);
                actualizar.then(function (response) {
                    if (response > 0) { console.log("Actualizo Correctamente") }
                    else { console.log("No se Actualizo Correctamente")}
                });

            },
            onInitNewRow(e) { //Cuando cargamos el formulario para añadir un nuevo elemento seteamos el usuario              
                e.data.usuario = currentUser;
            },
            onRowInserted: function (e) {
                delete e.data.iD_EQUIPO; //eliminamos el id que lo autogenerara el insert con entityFramework.
                var data = JSON.stringify(e.data);               
                var insertar = funInsertEquipo(data);
                insertar.then(function (response) {
                    if (response > 0) { console.log("Inserto Correctamente") }
                    else { console.log("No se Inserto Correctamente") }
                });
            },            
            onRowRemoved: function (e) {
                var eliminare = funDeleteEquipoAndCaracteristica(e.data.iD_EQUIPO);
                eliminare.then(function (response) {
                    if (response > 0) { console.log("Eliminados Correctamente") }
                    else { console.log("No se eliminaron los equipos y caracteristicas Correctamente") }
                });
            },
            masterDetail: {
                enabled: true,
                template: function (container, info) {
                    //console.log(info.data)
                    //console.log(info.data.iD_EQUIPO)
                    var eqspecs = funGetCaracteristicas(info.data.iD_EQUIPO); // la que contendra la data de las características
                    eqspecs.then(function (specs) {
                        //console.log(specs);

                        $('<div>')
                            .addClass('master-detail-caption')
                            .text(`Mostrando caracteristicas con ID de Equipo: ${info.data.iD_EQUIPO} `)
                            .css("background-color", "orange")                            
                            .appendTo(container);

                        $('<div>').dxDataGrid({
                                dataSource: specs,
                                keyExpr: "iD_EQUIPO_C",
                                columnAutoWidth: true,
                                showBorders: true,
                            columns: [{
                                caption: 'Caracteristica',
                                dataField: "nombrE_CARACTERISTICA",
                                validationRules: [{
                                    type: "required"
                                }],
                                fixed: true
                                }, {
                                    caption: 'NCR',
                                    dataField: "ncR_CARACTERISTICA",
                                    validationRules: [{
                                        type: "required"
                                    }]
                                }, {
                                    caption: 'FECHA REGISTRO',
                                    dataField: "fechA_REGISTRO",
                                    dataType: "date",
                                    format: "dd/MM/yyyy HH:mm",
                                    width: 180,
                                    validationRules: [{
                                        type: "required"
                                    }]
                                }],
                            editing: {
                                mode: "popup",
                                allowUpdating: true,
                                allowDeleting: true,
                                allowAdding: true,
                                popup: {
                                    title: 'Información de la Característica',
                                    showTitle: true,
                                    width: 700,
                                    height: 525,
                                }
                            },
                            onRowUpdated: function (e) {
                                var data = JSON.stringify(e.data);
                                //console.log(data)
                                var actualizar = funUpdateEquipoCar(data);
                                actualizar.then(function (response) {
                                    if (response > 0) { console.log("Actualizo Correctamente") }
                                    else { console.log("No se Actualizo Correctamente") }
                                });
                            },
                            onRowInserted: function (e) {                              
                                delete e.data.iD_EQUIPO_C; //eliminamos el id que lo autogenerara el insert con entityFramework.
                                e.data.iD_EQUIPO = info.data.iD_EQUIPO; // añadimos id del equipo padre.
                                var data = JSON.stringify(e.data);
                                var insertarC = funInsertEquipoCaracteristica(data);
                                insertarC.then(function (response) {
                                    if (response > 0) { console.log("Inserto Correctamente") }
                                    else { console.log("No se Inserto Correctamente") }
                                });
                            },
                            onRowRemoved: function (e) {                                
                                var eliminarc = funDeleteCaracteristica(e.data.iD_EQUIPO_C);
                                eliminarc.then(function (response) {
                                    if (response > 0) { console.log("Eliminada Correctamente") }
                                    else { console.log("No se elimino Correctamente") }
                                });
                            },
                            filterRow: { visible: true },
                            }).appendTo(container);
                    });                
                }               
            },
            //export: { enabled: true },
            onExporting: function (e) {
                const workbook = new ExcelJS.Workbook();
                const worksheet = workbook.addWorksheet("Main sheet");
                DevExpress.excelExporter.exportDataGrid({
                    worksheet: worksheet,
                    component: e.component,
                }).then(function () {
                    workbook.xlsx.writeBuffer().then(function (buffer) {
                        saveAs(new Blob([buffer], { type: "application/octet-stream" }), "DataGrid.xlsx");
                    });
                });
                e.cancel = true;
            }
        });
    });   
    //console.log(equipos);
}

function funGetAllEquipos() {
    var url = "/Microbases/funGetAllEquipos";
    return $.get(url, {  }, function (data) {
        //console.log(data);
    });
};

//------------------------------------- Get Caracteristicas
async function funGetCaracteristicas(idEq) {
    return caracteristicas = await funGetEquipoCaracteristicasFromDB(idEq);
};
function funGetEquipoCaracteristicasFromDB(idEq) {
    var url = "/Microbases/funGetEquipoCaracteristicas";
    return $.get(url, { "idEquipo": idEq}, function (data) {
        //console.log(data);
    });
};
//-------------------------------------------------------------------------
//------------------------------------- Insert Equipo
async function funInsertEquipo(data) {
    //console.log(datos);
    return equipo = await InsertEquipoToDB(data);
};

function InsertEquipoToDB(data) {
    //console.log("hola");
    //console.log(data);
    return $.ajax({
        type: "POST",
        dataType: "json",
        url: "/Microbases/funInsertEquipo",
        data: { "datos": data },
        success: function (response) {
            //console.log(response);
        },
    });
}
//-------------------------------------------------------------------------
//------------------------------------- Update Equipo
async function funUpdateEquipo(data) {
    //console.log(datos);
    return equipo = await UpdateEquipoToDB(data);
};

function UpdateEquipoToDB(data) {
    //console.log("hola");
    //console.log(data);
    return $.ajax({
        type: "POST",
        dataType: "json",
        url: "/Microbases/funUpdateEquipo",
        data: { "datos": data },
        success: function (response) {
            //console.log(response);
        },
    });
}
//------------------------------------- Delete Equipo y Caracteristica
async function funDeleteEquipoAndCaracteristica(idEquipo) {
    //console.log(datos);
    return dele = await deleteEquipoAndCaracteristicaFromDB(idEquipo);
};

function deleteEquipoAndCaracteristicaFromDB(idEquipo) {
    //console.log("hola");
    //console.log(data);
    return $.ajax({
        type: "POST",
        dataType: "json",
        url: "/Microbases/funDeleteEquipoAndCaracteristicas",
        data: { "idEquipo": idEquipo },
        success: function (response) {
            //console.log(response);
        },
    });
}
//-------------------------------------------------------------------------




//-------------------------------------------------------------------------
//------------------------------------- Insert Equipo Caracteristicas
async function funInsertEquipoCaracteristica(data) {
    //console.log(datos);
    return caracteristicas = await InsertEquipoCaracteristicaToDB(data);
};

function InsertEquipoCaracteristicaToDB(data) {
    //console.log("hola");
    //console.log(data);
    return $.ajax({
        type: "POST",
        dataType: "json",
        url: "/Microbases/funInsertEquipoCaracteristica",
        data: { "datos": data },
        success: function (response) {
            //console.log(response);
        },
    });
}
//-------------------------------------------------------------------------
//------------------------------------- Update Equipo Caracteristicas
async function funUpdateEquipoCar(data) {
    //console.log(datos);
    return equipo = await UpdateEquipoCarToDB(data);
};

function UpdateEquipoCarToDB(data) {
    //console.log("hola");
    //console.log(data);
    return $.ajax({
        type: "POST",
        dataType: "json",
        url: "/Microbases/funUpdateEquipoCaracteristica",
        data: { "datos": data },
        success: function (response) {
            //console.log(response);
        },
    });
}
//-------------------------------------------------------------------------
//------------------------------------- Delete Caracteristica
async function funDeleteCaracteristica(idc) {
    //console.log(datos);
    return delc = await deleteCaracteristicaFromDB(idc);
};

function deleteCaracteristicaFromDB(idc) {
    //console.log("hola");
    //console.log(data);
    return $.ajax({
        type: "POST",
        dataType: "json",
        url: "/Microbases/funDeleteCaracteristica",
        data: { "idc": idc },
        success: function (response) {
            //console.log(response);
        },
    });
}
//-------------------------------------------------------------------------

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