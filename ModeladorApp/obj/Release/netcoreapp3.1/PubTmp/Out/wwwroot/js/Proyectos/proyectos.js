var ArrayCamposProyecto = [];

function crearProyecto() {

    ArrayCamposProyecto = [];

    var nombre = $('#txtPyNombre').val();
    var desc = $('#txtPyDescripcion').val();

    if (nombre != "" && nombre != null) {
        ArrayCamposProyecto.push(nombre);
    }

    if (desc != "" && desc != null) {
        ArrayCamposProyecto.push(desc);
    }

    var nroCamposLlenos = ArrayCamposProyecto.length;

    if (nroCamposLlenos == 2) {

        Swal.fire({ title: 'Creando Proyecto ' + nombre + '...', allowOutsideClick: false, showConfirmButton: false })

        var rpt = createProjectAsync(nombre, desc)
        rpt.then(function (response) {

            console.log(response);
            if (response >= 1) {

                $('#txtPyNombre').val("");
                $('#txtPyDescripcion').val("");
                $('#modal-new-project').modal('toggle');

                Swal.fire('Proyecto Creado !', '', 'success').then((result) => {
                    location.reload(); //refrescar pantalla para ver los cambios.                  
                })

            } else {
                Swal.fire('ERROR', 'Hubo un problema', 'error')
            }
        })
    }
    else {
        Swal.fire('ATENCION', 'Por favor llena ambos campos', 'warning')
    }
}

async function createProjectAsync(nombre, desc) {
    return created = await createProjectInDB(nombre, desc);
};

function createProjectInDB(nombre, desc) {
    return $.ajax({
        type: "POST",
        url: "/Proyectos/funCreateProject",
        data: {
            "nombre": nombre,
            "descripcion": desc,
        },
        success: function (response) {
        },
    });
}

function deteleProject(id, nombre) {

    Swal.fire({
        title: '¿Estás seguro que deseas Eliminar:  ' + nombre + ' ?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: `Si`,
        denyButtonText: `Don't save`,
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {

            Swal.fire({ title: 'Eliminando ' + nombre + '...', allowOutsideClick: false, showConfirmButton: false })

            var rpt = confirmDeleteProject(id)
            rpt.then(function (response) {

                console.log(response);
                if (response >= 1) {

                    Swal.fire('Proyecto Eliminado !', '', 'success').then((result) => {
                        location.reload(); //refrescar pantalla para ver los cambios.                  
                    })

                } else {
                    Swal.fire('ERROR', 'Hubo un problema', 'error')
                }
            })

        } else if (result.isDenied) {
            Swal.fire('No', '', 'info')
        }
    })
}

async function confirmDeleteProject(vId) {
    return deleted = await DeleteProjectInDB(vId);
};

function DeleteProjectInDB(vId) {
    //console.log(vId);
    return $.ajax({
        type: "POST",
        url: "/Proyectos/funDeleteProject",
        data: {
            "proyectoId": vId,
        },
        success: function (response) {
        },
    });
}

function cloneProject(idPy, namePy, desc) {

    Swal.fire({
        title: '¿Estás seguro que deseas Clonar:  ' + namePy + ' ?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: `Si`,
        denyButtonText: `Don't save`,
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {

            Swal.fire({ title: 'Clonando ' + namePy + '...', allowOutsideClick: false, showConfirmButton: false })

            var rpt = confirmCloneProject(idPy, namePy, desc)
            rpt.then(function (response) {
                //console.log(response);
                if (response.msg == "Se duplicaron correctamente los niveles") {
                    Swal.fire('Clonado Correctamente !', 'Se duplicaron: ' + response.registros + ' Registros, de un total de: ' + response.total + ' ', 'success').then((result) => {
                        location.reload(); //refrescar pantalla para ver los cambios.
                    });                         
                } else if (response.msg == "Falto duplicar algunos niveles") {
                    Swal.fire('Atencion', 'Se duplicaron: ' + response.registros + ' Registros, de un total de: ' + response.total + ' ', "warning").then((result) => {
                        location.reload(); //refrescar pantalla para ver los cambios.
                    });
                } else if (response.msg == "Excepcion no controlada") {
                    Swal.fire("Atencion", 'Hubo una excepción, se duplicaron: ' + response.registros + ' Registros, de un total de: ' + response.total + ' ', "warning").then((result) => {
                        location.reload(); //refrescar pantalla para ver los cambios.
                    });                    
                } else {
                    Swal.fire("Hubo un Problema", 'Error:' + response.msg, "error").then((result) => {
                        location.reload(); //refrescar pantalla para ver los cambios.
                    });
                }                
            })

        } else if (result.isDenied) {
            Swal.fire('No', '', 'info')
        }
    })
}

async function confirmCloneProject(idPy, namePy, desc) {
    return clone = await CloneProjectInDB(idPy, namePy, desc);
};
function CloneProjectInDB(idproyecto, nombre, descripcion) {
    return $.ajax({
        type: "POST",
        url: "/Proyectos/funCloneProject",
        data: {
            "proyectoId": idproyecto,
            "nombre": nombre,
            "descripcion": descripcion,
        },
        success: function (response) { },
    });
}