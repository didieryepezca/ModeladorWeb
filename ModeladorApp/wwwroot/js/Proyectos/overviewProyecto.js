var ArrayCamposPermiso = [];

function AddPermiso() {

    ArrayCamposPermiso = [];
    //var tipos = $("input[type='radio']");
    //var tipoSeleccionado = tipos.filter(":checked");

    var pyId = $('#txtPyId').val();
    var usuario = $('#selectUsuario').val();
    var permiso = $('form input[type=radio]:checked').val();

    var ArrayCamposPermiso = [];

    if (pyId != "" && pyId != null) {
        ArrayCamposPermiso.push(pyId);
    }

    if (usuario != "" && usuario != null) {
        ArrayCamposPermiso.push(usuario);
    }

    if (permiso != "" && permiso != null) {
        ArrayCamposPermiso.push(permiso);
    }

    var nroCamposLlenos = ArrayCamposPermiso.length;

    //console.log(pyId);
    //console.log(usuario);
    //console.log(permiso);

    if (nroCamposLlenos == 3) {

        url = "/Proyectos/FunAgregarPermiso";
        $.get(url, { proyectoId: pyId, userConcedido: usuario, per: permiso }, function (data) {

            //console.log(data);
            if (data == "AGREGADO") {
                Swal.fire('Agregado !', 'El permiso se agregó con éxito.', 'success').then((result) => {
                    location.reload(); //refrescar pantalla para que aparezca el proyecto creado.
                })
            }
            else if (data == "PERMISO EXISTENTE") {
                Swal.fire('ADVERTENCIA', 'El Permiso que intentas agregar ya existe.', 'warning')
            } else {
                Swal.fire('ERROR', 'Hubo un problema no controlado por la aplicación.', 'error')
            }
        });

        $("#selectUsuario").val("");
        $('#modal-permiso').modal('toggle');

    } else {

        Swal.fire('ADVERTENCIA', 'Por favor completa todos los campos.', 'warning')

    }
}

var camposProyecto = [];

function UpdateProyecto() {

    var camposProyecto = [];

    var idpy = $('#txtPyId').val();
    var nombre = $('#txtPyNombre').val();
    var descripcion = $('#txtPyDescripcion').val();


    if (idpy != "" && idpy != null) {
        camposProyecto.push(idpy);
    }

    if (nombre != "" && nombre != null) {
        camposProyecto.push(nombre);
    }

    if (descripcion != "" && descripcion != null) {
        camposProyecto.push(descripcion);
    }

    var nroCamposProyecto = camposProyecto.length;

    if (nroCamposProyecto == 3) {

        url = "/Proyectos/FunUpdateProyecto";
        $.get(url, { vIdPy: idpy, vNombre: nombre, vDescripcion: descripcion }, function (data) {

            if (data >= 1) {

                Swal.fire('Actualizado !', '', 'success')
            }
            else {
                Swal.fire('ADVERTENCIA', 'Hubo un Problema', 'info')
            }
        });

    } else {

        Swal.fire('ERROR', 'Hubo un error no controlado', 'error')

    }
}