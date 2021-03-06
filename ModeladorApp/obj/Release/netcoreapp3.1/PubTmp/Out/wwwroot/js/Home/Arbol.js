window.onload = loadTree(firstPyID, permiso);

var CLIPBOARD = null;
var tempPyId; // servirá para deshacernos de la vista del proyecto.

var pySelected; //servira para identificar los valores de las cajitas por el id del tree elegido.

async function loadTree(firstPyID, vPermiso) {
    
    var treeReach; //la que rendizará los datos en la tabla.
    var data; // la que contendra la data de la función asyncrona.

    //console.log(vPermiso);            
    if (firstPyID != 0) {

        data = await funGetPyFromUsuario(firstPyID)
        treeReach = "tree_" + firstPyID;
        tempPyId = firstPyID;

        pySelected = firstPyID;

    } else {

        data = await funGetMasterData()
        treeReach = "tree_0";

        pySelected = 0;
    }

    if (data.length >= 1) {

        //---------------------------- Bloqueamos los tabs
        var disabledTabs = document.querySelectorAll('.nav-link.disabled');
        //console.log(disabledTabs);  
        for (t = 0; t <= disabledTabs.length - 1; t++) {
            disabledTabs[t].classList.remove("disabled"); //desbloqueamos los tabs          
        }
        $("#loader").hide(); //Ocultamos el Loader
        //--------------------------------------->>

        $('.nav-link.disabled').removeAttr('disabled')

        if (firstPyID != 0) {

            $("#proyecto_0").removeClass('active');
            $('#proyecto_' + firstPyID).attr('class', "tab-pane active");

        } else {

            $("#proyecto_" + tempPyId).removeClass('active');
            $('#proyecto_0').attr('class', "tab-pane active");
        }

        $(function () {

            $("#" + treeReach).fancytree({

                //-->> Para colocar los checkboxes en la prima columna (columna indice 0) y además agregar el modo de selección en cascada.
                checkbox: true,
                selectMode: 3,
                //---->>

                titlesTabbable: true, // Add all node titles to TAB chain
                quicksearch: true, // Jump to nodes when pressing first character
                source: data,
                // Llamada cada vez que se expande un nodo LAZY.
                lazyLoad: function (event, data) {

                    var node = data.node;     //obtenemos el nodo
                    /*console.log(node.data.id);*/ // obtenemos el id para mandarlo como parent
                    //console.log(node.data.parentId)

                    data.result = {
                        url: "/Home/funGetSubLvls",
                        data: { parent: node.data.id },
                        cache: false
                    };
                },

                ////Evento Expand para capturar algo cuando se expande el arbol
                //expand: function (data) {
                //    console.log("expandiendo");
                //    console.log(data);
                //    $(".OrgDataTreeNotChecked").children(".fancytree-title").css({ 'color': 'red' });
                //},

                extensions: ["edit", "dnd5", "table", "gridnav"],

                dnd5: {
                    preventVoidMoves: true,
                    preventRecursion: true,
                    autoExpandMS: 400,
                    dragStart: function (node, data) {


                        //function saveData(node.data.id);
                        //console.log(node.data.id); //id del elemento a actualizar
                        //console.log(data); //id del nuevo parent

                        return true;
                    },
                    dragEnter: function (node, data) {
                        // return ["before", "after"];
                        return true;
                    },
                    dragDrop: function (node, data) {
                        data.otherNode.moveTo(node, data.hitMode);
                    },
                },
                edit: {
                    triggerStart: ["f2", "shift+click", "mac+enter"],
                    close: function (event, data) {

                        //console.log(data)
                        if (data.save && data.isNew) {
                            // Quick-enter: add new nodes until we hit [enter] on an empty title

                            $("#tree").trigger("nodeCommand", {
                                cmd: "addSibling",
                            });

                            //console.log("Se presionó ENTER");
                            //console.log("------------------->>");
                            //console.log(data.node.title); //enviar como title
                            //console.log(data.node.parent.data.id) //enviar como parent id
                            //console.log(data.node.parent.data.proyectoId) //enviar como proyectoId
                            //console.log(data.node);
                            //------------------------>>AJAX GRABAR NVO NODO
                            //console.log(data.node.parent.data);
                            if (typeof (data.node.parent.data.parentId) === 'undefined') {

                                Swal.fire('ADVERTENCIA', 'Intentas agregar un nodo hermano a la raiz del Árbol, aparecerá en la vista temporal, mas no se guardarán los cambios.', 'warning')

                            } else if (vPermiso == "EDITOR") {
                                $.ajax({
                                    type: "POST",
                                    dataType: "json",
                                    url: "/Home/funInsertLvl",
                                    data: {
                                        "titulo": data.node.title,
                                        "descripcion": data.datadescripcion,
                                        "parent": data.node.parent.data.id,
                                        "projectId": data.node.parent.data.proyectoId
                                    },
                                    success: function (response) {
                                        //console.log(response);
                                    },
                                });
                                //------------------------>>AJAX GRABAR NVO NODO
                                data.node.parent.resetLazy() //Recarga de nodo padre para obtener los ids de la data creada.
                            } else {

                                Swal.fire('ADVERTENCIA', 'Puedes editar el proyecto en su respectiva pestaña EDITOR, si tienes el permiso correspondiente.', 'warning')
                            }
                        } else if (data.isNew == false && data.datatitulo != "") {
                            //console.log(data.node.data.id)
                            if (vPermiso == "EDITOR") {
                                //console.log(data)
                                //------------------------>>AJAX Actualizar Nombre de Nodos
                                $.ajax({
                                    type: "POST",
                                    dataType: "json",
                                    url: "/Home/funUpdateLvlNameDescription",
                                    data: {
                                        "Id": data.node.data.id,
                                        "title": data.node.title,
                                        "description": data.datadescripcion,
                                    },
                                    success: function (response) {
                                        //console.log(response);
                                        if (data.node.data.parentId != 0) {
                                            data.node.parent.resetLazy()
                                        } else {
                                            var datosReload = funGetPyFromUsuario(firstPyID);
                                            datosReload.then(function (dataReload) {
                                                $.ui.fancytree.getTree().reload(dataReload);
                                            });
                                        }
                                    },
                                });
                                //------------------------>>AJAX Actualizar Nombre de Nodos
                            }
                        }
                    },
                },
                table: {
                    indentation: 20,
                    nodeColumnIdx: 1,
                    checkboxColumnIdx: 0, //para poner checkboxes en la prima columna (columna indice 0)
                },
                gridnav: {
                    autofocusInput: false,
                    handleCursorKeys: true,
                },
                createNode: function (event, data) {
                    var node = data.node,
                        $tdList = $(node.tr).find(">td");

                    //console.log("Desglose de nodo...");

                    // Span the remaining columns if it's a folder.
                    // We can do this in createNode instead of renderColumns, because
                    // the `isFolder` status is unlikely to change later
                    if (node.isFolder()) {
                        $tdList
                            .eq(2)
                            .prop("colspan", 6)
                            .nextAll()
                            .remove();
                    }
                },
                renderColumns: function (event, data) {
                    var node = data.node,
                        $tdList = $(node.tr).find(">td");

                    //console.log(node.tr.rowIndex);
                    //-->codigo para colocar el indexador en la primera columna (columna indice 0)
                    //if (node.tr.rowIndex >= 2) { 
                    //    $tdList.eq(0).text(node.getIndexHier());
                    //}

                    //$tdList.eq(2).text(node.data.fechaCreacion);
                    //console.log(node.data.fechaCreacion);
                    //console.log(node.data.id); // id único de cada elemento del arbol.
                    var estilos = getStyles(node.data.id);//-------> estilos del árbol
                    estilos.then(function (estilosresponse) {

                        if (estilosresponse.length != 0) {

                            for (s = 0; s <= estilosresponse.length - 1; s++) {

                                if (estilosresponse[s].style == 'bold' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.fontWeight = estilosresponse[s].style; //titulo                                         
                                } else if (estilosresponse[s].style == 'bold' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.fontWeight = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == 'italic' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.fontStyle = estilosresponse[s].style; //LETRA CURSIVA.
                                } else if (estilosresponse[s].style == 'italic' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.fontStyle = estilosresponse[s].style; //LETRA CURSIVA.
                                }

                                else if (estilosresponse[s].style == 'Lime') {
                                    node.span.style.backgroundColor = estilosresponse[s].style;  //SUBRAYADO VERDE.
                                } else if (estilosresponse[s].style == 'SkyBlue') {
                                    node.span.style.backgroundColor = estilosresponse[s].style;  //SUBRAYADO AZUL.
                                } else if (estilosresponse[s].style == 'Yellow') {
                                    node.span.style.backgroundColor = estilosresponse[s].style;  //SUBRAYADO AMARILLO.
                                } else if (estilosresponse[s].style == 'Fuchsia') {
                                    node.span.style.backgroundColor = estilosresponse[s].style;  //SUBRAYADO FUSCIA.
                                } else if (estilosresponse[s].style == 'Red') {
                                    node.span.style.backgroundColor = estilosresponse[s].style;  //ELEMENTO CARPETA.
                                } else if (estilosresponse[s].style == 'true') {
                                    node.folder = true;  //ICONO DEL FOLDER.
                                }

                                else if (estilosresponse[s].style == 'silver' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.color = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == 'lightslategray' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.color = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == 'grey' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.color = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == 'dimgrey' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.color = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == 'dark' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.color = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == '#206bc4' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.color = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == '#4299e1' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.color = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == '#4263eb' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.color = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == '#ae3ec9' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.color = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == '#d6336c' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.color = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == '#d63939' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.color = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == '#f76707' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.color = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == '#f59f00' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.color = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == '#74b816' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.color = estilosresponse[s].style;; //titulo
                                }


                                else if (estilosresponse[s].style == 'silver' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.color = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == 'lightslategray' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.color = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == 'grey' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.color = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == 'dimgrey' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.color = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == 'dark' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.color = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == '#206bc4' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.color = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == '#4299e1' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.color = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == '#4263eb' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.color = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == '#ae3ec9' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.color = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == '#d6336c' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.color = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == '#d63939' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.color = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == '#f76707' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.color = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == '#f59f00' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.color = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == '#74b816' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.color = estilosresponse[s].style;; //descripcion
                                }


                                else if (estilosresponse[s].style == '8px' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.fontSize = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == '10px' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.fontSize = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == '12px' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.fontSize = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == '14px' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.fontSize = estilosresponse[s].style;; //titulo
                                } else if (estilosresponse[s].style == '16px' && estilosresponse[s].campo == "titulo") {
                                    node.span.children[2].children[0].style.fontSize = estilosresponse[s].style;; //titulo
                                }

                                else if (estilosresponse[s].style == '8px' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.fontSize = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == '10px' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.fontSize = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == '12px' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.fontSize = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == '14px' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.fontSize = estilosresponse[s].style;; //descripcion
                                } else if (estilosresponse[s].style == '16px' && estilosresponse[s].campo == "descripcion") {
                                    node.span.children[2].children[1].style.fontSize = estilosresponse[s].style;; //descripcion
                                }

                            }
                        }
                    });

                    // (Index #0 is rendered by fancytree by adding the checkbox)
                    // Set column #1 info from node data:
                    //$tdList.eq(0).text(node.getIndexHier());
                    // (Index #2 is rendered by fancytree)

                    //---------------------------------------------------------->>>
                    //console.log(pySelected)
                    var titles = funGetTitulos(pySelected)
                    titles.then(function (result) {
                        //console.log(result);
                        var colName = "";

                        if (result.length != 0) {
                            // 50 cajas para nombres de  columnas.
                            //for (h = 0; h <= result.length - 1; h++) { //capturar los 50 titulos
                            for (h = 1; h <= 11 - 1; h++) {
                                $('#' + treeReach + '_colth_' + result[h].tituloID).remove(); //removemos para que no se vuelvan a crear cada vez que inicializamos el arbol
                                colName = colName + '<th id="' + treeReach + '_colth_' + result[h].tituloID + '"><input id="' + treeReach + '_colname_' + result[h].tituloID + '" onchange="InsertUpdateTitulo(`' + treeReach + '_colname`,' + h + ',' + result[h].tituloID + ',' + pySelected + ',`' + vPermiso + '` )" type="text" value="' + result[h].titulo + '" style="width: 100%;"></th>';
                            }
                            $('#head_' + treeReach).append(colName).fadeIn(300000);
                        } else {

                            //for (i = 1; i <= 11 - 1; i++) {
                            //    $('#' + treeReach + '_colth_' + i).remove(); //removemos para que no se vuelvan a crear cada vez que inicializamos el arbol
                            //    colName = colName + '<th id="' + treeReach + '_colth_' + i + '"><input id="' + treeReach + '_colname_' + i + '" onchange="InsertUpdateTitulo(`' + treeReach + '_colname`,' + i + ',' + 0 + ',' + pySelected + ',`' + vPermiso + '` )" type="text" placeholder="Ingrese algo" style="width: 100%;"></th>';
                            //}
                            //$('#head_' + treeReach).append(colName).fadeIn(300000);
                        }
                    });

                    //console.log($tdList);
                    //console.log(node.data.id);
                    //---------> obtener los datos de la tabla TB_NIVEL_INFO segun el id.
                    var info = funGetInfo(node.data.id)
                    info.then(function (result) {

                        // Si la longitud del resultado es distinta de 0 hay datos.
                        if (result.length != 0) {

                            var m = 2;

                            for (n = 0; n <= result.length - 1; n++) {

                                for (i = 2; i <= 12; i++) {

                                    $tdList.eq(m).html('<input type="text" id="' + treeReach + '_colvalue' + result[n].infoID + '" value="' + result[n].informacion + '" onchange="insertOrUpdateInfoGrilla(`tree_' + pySelected + '`,`' + result[n].infoID + '`,`' + 0 + '`,`' + 0 + '`,`' + vPermiso + '`)" style="width: 100%;">');
                                }
                                m = m + 1;
                                for (j = m; j <= 12; j++) {

                                    $tdList.eq(j).html('<input id="' + treeReach + '_colvalue_' + j + '_' + node.data.id + '" onchange="insertOrUpdateInfoGrilla(`tree_' + pySelected + '`,`' + 0 + '`,`' + j + '`,`' + node.data.id + '`,`' + vPermiso + '`)" type="text" style="width: 100%;"/>');

                                }
                            }
                        } else { // Sino no hay ningun dato en las cajas de un arbol. crear las cajas desde 0

                            //console.log("Construir desde 0");
                            for (k = 2; k <= 12; k++) {
                                $tdList.eq(k).html('<input id="' + treeReach + '_colvalue_' + k + '_' + node.data.id + '" onchange="insertOrUpdateInfoGrilla(`tree_' + pySelected + '`,`' + 0 + '`,`' + k + '`,`' + node.data.id + '`,`' + vPermiso + '`)" type="text" style="width: 100%;"/>');
                            }

                        }
                    });                  
                },
                renderNode: function (event, data) {
                    var node = data.node;
                    //console.log(node)
                    if (node.title != "root") {
                        var hiddens = getStyles(node.data.id);//-------> estilos del árbol
                        hiddens.then(function (nodohidden) {
                            //console.log(nodohidden)
                            if (nodohidden.length != 0) {
                                for (h = 0; h <= nodohidden.length - 1; h++) {
                                    if (nodohidden[h].style == 'true' && nodohidden[h].campo == "ocultar nodo") {
                                        node.tr.hidden = nodohidden[h].style; //ocultar nodo

                                        //busco el id del campo que ya esta oculto si no lo encuentro entonces push en el array.
                                        const idPushed = checkedHideCampos.find(x => x.id == node.data.id);
                                        if (typeof (idPushed) === 'undefined') {
                                            checkedHideCampos.push(new campohidden(node.data.id)); //lleno el array de los elementos ya ocultos, para ocultarlos tambien en la funcion de conformar segundo campo.
                                        }

                                    } else if (nodohidden[h].style == 'false' && nodohidden[h].campo == "ocultar nodo") {
                                        node.tr.hidden = nodohidden[h].style; //mostrar nodo
                                    }
                                }
                            }
                        });
                    }                                      
                },
                modifyChild: function (event, data) {
                    data.tree.info(event.type, data);
                    //console.log("----> OPERATION DRAG & DROP")
                    //console.log(data);
                    //console.log(data.childNode.data.id);
                    //console.log(data.childNode.title); //nombre a actualizar                 
                    //console.log(data.node)             
                    if (data.operation == "add") {
                        if (typeof (data.childNode.data.id) != 'undefined') {
                            //console.log(data.operation)
                            //console.log(data.childNode.data.id) // id actualizar
                            //console.log(data.node.data.id) // id del nuevo parent
                            $.ajax({
                                type: "POST",
                                dataType: "json",
                                url: "/Home/funUpdateLvlParent",
                                data: {
                                    "id": data.childNode.data.id,
                                    "newparentId": data.node.data.id,
                                },
                                success: function (response) {
                                    //console.log(response);
                                },
                            });
                        }
                    }
                    //console.log("----> OPERATION DRAG & DROP")
                },
            })
                .on("nodeCommand", function (event, data) {
                    // Custom event handler that is triggered by keydown-handler and
                    // context menu:
                    var refNode,
                        moveMode,
                        tree = $.ui.fancytree.getTree(this),
                        node = tree.getActiveNode();
                    //console.log("--------------------->>Add")
                    //console.log(node.data.id) //enviar como parent id
                    //console.log(node.childNode) //enviar como parent id
                    //console.log("--------------------->>Add")
                    switch (data.cmd) {
                        case "addChild":
                            tree.applyCommand(data.cmd, node);
                            break;
                        case "addSibling":
                            tree.applyCommand(data.cmd, node);
                            break;
                        //console.log("------------>>")
                        //console.log(data.cmd)
                        case "indent":
                        case "moveDown":
                        case "moveUp":
                        case "outdent":
                        case "remove":
                            var selectedNodes = $.ui.fancytree.getTree("#" + treeReach).getSelectedNodes();
                            if (selectedNodes.length > 0) {

                                if (data.cmd == "remove" && vPermiso == "EDITOR") {
                                    Swal.fire({
                                        title: '¿Estás seguro que deseas Eliminar todos?',
                                        showDenyButton: true,
                                        showCancelButton: true,
                                        confirmButtonText: `Si`,
                                        denyButtonText: `Don't save`,
                                    }).then((result) => {
                                        /* Read more about isConfirmed, isDenied below */
                                        if (result.isConfirmed) {
                                            //console.log(node.data.id); // id a eliminar padre e hijos.
                                            //------------------------>>AJAX Eliminar Nivel Padre e Hijos
                                            selectedNodes.forEach(function element(node) {
                                                $.ajax({
                                                    type: "POST",
                                                    dataType: "json",
                                                    url: "/Home/funDeleteLvlAndSublvls",
                                                    data: {
                                                        "Id": node.data.id,
                                                    },
                                                    success: function (response) {
                                                        //console.log(response);
                                                        if (response >= 1) {
                                                        }
                                                    },
                                                });
                                            });
                                            tree.applyCommand(data.cmd, node); //aplicamos cambios para visualizarlos en el arbol.
                                            //------------------------>>AJAX Eliminar Nivel Padre e Hijos                                                                    
                                        } else if (result.isDenied) {
                                            Swal.fire('No', '', 'info')
                                        }
                                    })
                                };
                            } else {
                                if (data.cmd == "remove" && vPermiso == "EDITOR") {
                                    Swal.fire({
                                        title: '¿Estás seguro que deseas Eliminarlo?',
                                        showDenyButton: true,
                                        showCancelButton: true,
                                        confirmButtonText: `Si`,
                                        denyButtonText: `Don't save`,
                                    }).then((result) => {
                                        /* Read more about isConfirmed, isDenied below */
                                        if (result.isConfirmed) {
                                            //console.log(node.data.id); // id a eliminar padre e hijos.
                                            //------------------------>>AJAX Eliminar Nivel Padre e Hijos
                                            $.ajax({
                                                type: "POST",
                                                dataType: "json",
                                                url: "/Home/funDeleteLvlAndSublvls",
                                                data: {
                                                    "Id": node.data.id,
                                                },
                                                success: function (response) {
                                                    //console.log(response);
                                                    if (response >= 1) {
                                                        tree.applyCommand(data.cmd, node);
                                                    }
                                                },
                                            });
                                            //------------------------>>AJAX Eliminar Nivel Padre e Hijos                                                                    
                                        } else if (result.isDenied) {
                                            Swal.fire('No', '', 'info')
                                        }
                                    });
                                };
                            }

                            break;
                        case "rename":
                            tree.applyCommand(data.cmd, node);

                            break;
                        case "cut":
                            CLIPBOARD = { mode: data.cmd, data: node };
                            break;
                        case "copy":
                            CLIPBOARD = {
                                mode: data.cmd,
                                data: node.toDict(true, function (dict, node) {
                                    delete dict.key;
                                }),
                            };
                            break;
                        case "clear":
                            CLIPBOARD = null;
                            break;
                        case "paste":
                            if (CLIPBOARD.mode === "cut") {
                                // refNode = node.getPrevSibling();
                                CLIPBOARD.data.moveTo(node, "child");
                                CLIPBOARD.data.setActive();
                            } else if (CLIPBOARD.mode === "copy") {
                                node.addChildren(
                                    CLIPBOARD.data
                                ).setActive();
                            }
                            break;
                        case "applyboldtitle":

                            var selectedNodes = $.ui.fancytree.getTree("#" + treeReach).getSelectedNodes();
                            //console.log(selectedNodes)
                            if (selectedNodes.length > 0) {
                                //console.log("aplicando negra a muchos elementos");                                                                                
                                selectedNodes.forEach(function element(node) {
                                    //console.log(node.data.id);
                                    var rpt = applyOrRemoveStyle(node.data.id, "bold", "STYLE_APPLY", "titulo")
                                    rpt.then(function (styleresponse) {
                                        //console.log(styleresponse);
                                        if (styleresponse > 0) {
                                            //node.span.style.fontWeight = "bold"
                                            node.span.children[2].children[0].style.fontWeight = "bold"; //titulo
                                        } else {
                                            Swal.fire('ERROR', 'Hubo un problema, probablemente el estilo ya existe.', 'warning')
                                        }
                                    });
                                });

                            } else {
                                //tree.applyCommand(data.cmd, node);
                                //console.log("Aplicar Negrita");
                                //console.log(node.data.id); // id del nodo.
                                var rpt = applyOrRemoveStyle(node.data.id, "bold", "STYLE_APPLY", "titulo")
                                rpt.then(function (styleresponse) {

                                    //console.log(styleresponse);
                                    if (styleresponse > 0) {
                                        //node.span.style.fontWeight = "bold"
                                        node.span.children[2].children[0].style.fontWeight = "bold"; //titulo
                                    } else {
                                        Swal.fire('ERROR', 'Hubo un problema, probablemente el estilo ya existe.', 'warning')
                                    }
                                });
                            }

                            //addColumn(treeReach, node.data.id);
                            break;
                        case "removeboldtitle":

                            var selectedNodes = $.ui.fancytree.getTree("#" + treeReach).getSelectedNodes();

                            if (selectedNodes.length > 0) {

                                selectedNodes.forEach(function element(node) {

                                    var rpt = applyOrRemoveStyle(node.data.id, "bold", "STYLE_REMOVE", "titulo")
                                    rpt.then(function (styleresponse) {
                                        //console.log(styleresponse);
                                        if (styleresponse > 0) {
                                            node.span.children[2].children[0].style.fontWeight = ""; //titulo
                                        } else {
                                            Swal.fire('ERROR', 'Hubo un problema, probablemente el estilo ya existe.', 'warning')
                                        }
                                    });

                                });

                            } else {

                                //tree.applyCommand(data.cmd, node);
                                //console.log("Aplicar Negrita");
                                //console.log(node.data.id); // id del nodo.
                                var rpt = applyOrRemoveStyle(node.data.id, "bold", "STYLE_REMOVE", "titulo")
                                rpt.then(function (styleresponse) {
                                    //console.log(styleresponse);
                                    if (styleresponse > 0) {
                                        node.span.children[2].children[0].style.fontWeight = ""; //titulo
                                    } else {
                                        Swal.fire('ERROR', 'Hubo un problema, probablemente el estilo ya existe.', 'warning')
                                    }
                                });
                            }

                            //addColumn(treeReach, node.data.id);
                            break;

                        case "applybolddescription":

                            var selectedNodes = $.ui.fancytree.getTree("#" + treeReach).getSelectedNodes();

                            if (selectedNodes.length > 0) {

                                selectedNodes.forEach(function element(node) {

                                    //tree.applyCommand(data.cmd, node);
                                    //console.log("Aplicar Negrita");
                                    //console.log(node.data.id); // id del nodo.
                                    var rpt = applyOrRemoveStyle(node.data.id, "bold", "STYLE_APPLY", "descripcion")
                                    rpt.then(function (styleresponse) {

                                        //console.log(styleresponse);
                                        if (styleresponse > 0) {
                                            //node.span.style.fontWeight = "bold"
                                            node.span.children[2].children[1].style.fontWeight = "bold"; //descripcion
                                        } else {
                                            Swal.fire('ERROR', 'Hubo un problema, probablemente el estilo ya existe.', 'warning')
                                        }
                                    });

                                });


                            } else {
                                //tree.applyCommand(data.cmd, node);
                                //console.log("Aplicar Negrita");
                                //console.log(node.data.id); // id del nodo.
                                var rpt = applyOrRemoveStyle(node.data.id, "bold", "STYLE_APPLY", "descripcion")
                                rpt.then(function (styleresponse) {

                                    //console.log(styleresponse);
                                    if (styleresponse > 0) {
                                        //node.span.style.fontWeight = "bold"
                                        node.span.children[2].children[1].style.fontWeight = "bold"; //descripcion
                                    } else {
                                        Swal.fire('ERROR', 'Hubo un problema, probablemente el estilo ya existe.', 'warning')
                                    }
                                });
                            }

                            //addColumn(treeReach, node.data.id);
                            break;
                        case "removebolddescription":

                            var selectedNodes = $.ui.fancytree.getTree("#" + treeReach).getSelectedNodes();

                            if (selectedNodes.length > 0) {

                                selectedNodes.forEach(function element(node) {

                                    //tree.applyCommand(data.cmd, node);
                                    //console.log("Quitar negrita");
                                    var rpt = applyOrRemoveStyle(node.data.id, "bold", "STYLE_REMOVE", "descripcion")
                                    rpt.then(function (styleresponse) {
                                        //console.log(styleresponse);
                                        if (styleresponse > 0) {
                                            node.span.children[2].children[1].style.fontWeight = ""; //descripcion
                                        } else {
                                            Swal.fire('ERROR', 'Hubo un problema quitando el estilo', 'warning')
                                        }
                                    });

                                });

                            } else {

                                //tree.applyCommand(data.cmd, node);
                                //console.log("Quitar negrita");
                                var rpt = applyOrRemoveStyle(node.data.id, "bold", "STYLE_REMOVE", "descripcion")
                                rpt.then(function (styleresponse) {
                                    //console.log(styleresponse);
                                    if (styleresponse > 0) {
                                        node.span.children[2].children[1].style.fontWeight = ""; //descripcion
                                    } else {
                                        Swal.fire('ERROR', 'Hubo un problema quitando el estilo', 'warning')
                                    }
                                });
                            }
                            //addColumn(treeReach, node.data.id);
                            break;
                        case "applyitalictitle":

                            var selectedNodes = $.ui.fancytree.getTree("#" + treeReach).getSelectedNodes();

                            if (selectedNodes.length > 0) {

                                selectedNodes.forEach(function element(node) {

                                    var rpt = applyOrRemoveStyle(node.data.id, "italic", "STYLE_APPLY", "titulo")
                                    rpt.then(function (styleresponse) {

                                        //console.log(styleresponse);
                                        if (styleresponse > 0) {
                                            node.span.children[2].children[0].style.fontStyle = "italic"; //titulo
                                        } else {
                                            Swal.fire('ERROR', 'Hubo un problema, probablemente el estilo ya existe.', 'warning')
                                        }
                                    });

                                });

                            } else {

                                //tree.applyCommand(data.cmd, node);
                                //console.log("Aplicar Cursiva");
                                var rpt = applyOrRemoveStyle(node.data.id, "italic", "STYLE_APPLY", "titulo")
                                rpt.then(function (styleresponse) {

                                    //console.log(styleresponse);
                                    if (styleresponse > 0) {
                                        node.span.children[2].children[0].style.fontStyle = "italic"; //titulo
                                    } else {
                                        Swal.fire('ERROR', 'Hubo un problema, probablemente el estilo ya existe.', 'warning')
                                    }
                                });
                            }
                            //console.log(node.data.id); // id del nodo.
                            //addColumn(treeReach, node.data.id);
                            break;
                        case "removeitalictitle":

                            var selectedNodes = $.ui.fancytree.getTree("#" + treeReach).getSelectedNodes();

                            if (selectedNodes.length > 0) {

                                selectedNodes.forEach(function element(node) {

                                    var rpt = applyOrRemoveStyle(node.data.id, "italic", "STYLE_REMOVE", "titulo")
                                    rpt.then(function (styleresponse) {
                                        //console.log(styleresponse);
                                        if (styleresponse > 0) {
                                            node.span.children[2].children[0].style.fontStyle = ""; //titulo
                                        } else {
                                            Swal.fire('ERROR', 'Hubo un problema quitando el estilo', 'warning')
                                        }
                                    });

                                });

                            } else {

                                //tree.applyCommand(data.cmd, node);
                                //console.log("Quitar negrita");
                                var rpt = applyOrRemoveStyle(node.data.id, "italic", "STYLE_REMOVE", "titulo")
                                rpt.then(function (styleresponse) {
                                    //console.log(styleresponse);
                                    if (styleresponse > 0) {
                                        node.span.children[2].children[0].style.fontStyle = ""; //titulo
                                    } else {
                                        Swal.fire('ERROR', 'Hubo un problema quitando el estilo', 'warning')
                                    }
                                });
                            }

                            //console.log(node.data.id); // id del nodo.
                            //addColumn(treeReach, node.data.id);
                            break;
                        case "applyitalicdescription":

                            var selectedNodes = $.ui.fancytree.getTree("#" + treeReach).getSelectedNodes();

                            if (selectedNodes.length > 0) {

                                selectedNodes.forEach(function element(node) {

                                    var rpt = applyOrRemoveStyle(node.data.id, "italic", "STYLE_APPLY", "descripcion")
                                    rpt.then(function (styleresponse) {

                                        //console.log(styleresponse);
                                        if (styleresponse > 0) {
                                            node.span.children[2].children[1].style.fontStyle = "italic"; //descripcion
                                        } else {
                                            Swal.fire('ERROR', 'Hubo un problema, probablemente el estilo ya existe.', 'warning')
                                        }
                                    });
                                });

                            } else {

                                //tree.applyCommand(data.cmd, node);
                                //console.log("Aplicar Cursiva");
                                var rpt = applyOrRemoveStyle(node.data.id, "italic", "STYLE_APPLY", "descripcion")
                                rpt.then(function (styleresponse) {

                                    //console.log(styleresponse);
                                    if (styleresponse > 0) {
                                        node.span.children[2].children[1].style.fontStyle = "italic"; //descripcion
                                    } else {
                                        Swal.fire('ERROR', 'Hubo un problema, probablemente el estilo ya existe.', 'warning')
                                    }
                                });
                            }
                            //console.log(node.data.id); // id del nodo.
                            //addColumn(treeReach, node.data.id);
                            break;
                        case "removeitalicdescription":

                            var selectedNodes = $.ui.fancytree.getTree("#" + treeReach).getSelectedNodes();

                            if (selectedNodes.length > 0) {

                                selectedNodes.forEach(function element(node) {

                                    var rpt = applyOrRemoveStyle(node.data.id, "italic", "STYLE_REMOVE", "descripcion")
                                    rpt.then(function (styleresponse) {
                                        //console.log(styleresponse);
                                        if (styleresponse > 0) {
                                            node.span.children[2].children[1].style.fontStyle = ""; //descripcion
                                        } else {
                                            Swal.fire('ERROR', 'Hubo un problema quitando el estilo', 'warning')
                                        }
                                    });

                                });

                            } else {

                                //tree.applyCommand(data.cmd, node);
                                //console.log("Quitar negrita");
                                var rpt = applyOrRemoveStyle(node.data.id, "italic", "STYLE_REMOVE", "descripcion")
                                rpt.then(function (styleresponse) {
                                    //console.log(styleresponse);
                                    if (styleresponse > 0) {
                                        node.span.children[2].children[1].style.fontStyle = ""; //descripcion
                                    } else {
                                        Swal.fire('ERROR', 'Hubo un problema quitando el estilo', 'warning')
                                    }
                                });
                            }

                            break;

                        case "changecolorsfontsize":
                            //tree.applyCommand(data.cmd, node);                  
                            //console.log(node.span.children[2].children[0].style);                                   
                            $('#txtNodoId').val(node.data.id);
                            $('#txtGetTree').val(treeReach);
                            $('#modal-color-admin').modal('show');
                            //addColumn(treeReach, node.data.id);
                            break;
                        case "greensubrayado":
                            //tree.applyCommand(data.cmd, node);
                            var selectedNodes = $.ui.fancytree.getTree("#" + treeReach).getSelectedNodes();
                            if (selectedNodes.length > 0) {

                                selectedNodes.forEach(function element(node) {

                                    var rpt = applyOrRemoveStyle(node.data.id, "Lime", "STYLE_APPLY", "subrayado verde")
                                    rpt.then(function (styleresponse) {
                                        //console.log(styleresponse);
                                        if (styleresponse > 0) {
                                            node.span.style.backgroundColor = "Lime";
                                        } else {
                                            Swal.fire('ERROR', 'Hubo un problema, si ya cuenta con un subrayado quítelo antes de agregar otro.', 'warning')
                                        }
                                    });

                                });

                            } else {

                                var rpt = applyOrRemoveStyle(node.data.id, "Lime", "STYLE_APPLY", "subrayado verde")
                                rpt.then(function (styleresponse) {
                                    //console.log(styleresponse);
                                    if (styleresponse > 0) {
                                        node.span.style.backgroundColor = "Lime";
                                    } else {
                                        Swal.fire('ERROR', 'Hubo un problema, si ya cuenta con un subrayado quítelo antes de agregar otro.', 'warning')
                                    }
                                });
                            }

                            break;
                        case "bluesubrayado":

                            var selectedNodes = $.ui.fancytree.getTree("#" + treeReach).getSelectedNodes();

                            if (selectedNodes.length > 0) {

                                selectedNodes.forEach(function element(node) {

                                    var rpt = applyOrRemoveStyle(node.data.id, "SkyBlue", "STYLE_APPLY", "subrayado azul")
                                    rpt.then(function (styleresponse) {
                                        //console.log(styleresponse);
                                        if (styleresponse > 0) {
                                            node.span.style.backgroundColor = "SkyBlue";
                                        } else {
                                            Swal.fire('ERROR', 'Hubo un problema, si ya cuenta con un subrayado quítelo antes de agregar otro.', 'warning')
                                        }
                                    });
                                });

                            } else {

                                var rpt = applyOrRemoveStyle(node.data.id, "SkyBlue", "STYLE_APPLY", "subrayado azul")
                                rpt.then(function (styleresponse) {
                                    //console.log(styleresponse);
                                    if (styleresponse > 0) {
                                        node.span.style.backgroundColor = "SkyBlue";
                                    } else {
                                        Swal.fire('ERROR', 'Hubo un problema, si ya cuenta con un subrayado quítelo antes de agregar otro.', 'warning')
                                    }
                                });
                            };


                            break;
                        case "yellowsubrayado":

                            var selectedNodes = $.ui.fancytree.getTree("#" + treeReach).getSelectedNodes();

                            if (selectedNodes.length > 0) {

                                selectedNodes.forEach(function element(node) {

                                    var rpt = applyOrRemoveStyle(node.data.id, "Yellow", "STYLE_APPLY", "subrayado amarillo")
                                    rpt.then(function (styleresponse) {
                                        //console.log(styleresponse);
                                        if (styleresponse > 0) {
                                            node.span.style.backgroundColor = "Yellow";
                                        } else {
                                            Swal.fire('ERROR', 'Hubo un problema, si ya cuenta con un subrayado quítelo antes de agregar otro.', 'warning')
                                        }
                                    });
                                });

                            } else {

                                var rpt = applyOrRemoveStyle(node.data.id, "Yellow", "STYLE_APPLY", "subrayado amarillo")
                                rpt.then(function (styleresponse) {
                                    //console.log(styleresponse);
                                    if (styleresponse > 0) {
                                        node.span.style.backgroundColor = "Yellow";
                                    } else {
                                        Swal.fire('ERROR', 'Hubo un problema, si ya cuenta con un subrayado quítelo antes de agregar otro.', 'warning')
                                    }
                                });
                            }

                            break;
                        case "fuchsiasubrayado":

                            var selectedNodes = $.ui.fancytree.getTree("#" + treeReach).getSelectedNodes();

                            if (selectedNodes.length > 0) {

                                selectedNodes.forEach(function element(node) {

                                    var rpt = applyOrRemoveStyle(node.data.id, "Fuchsia", "STYLE_APPLY", "subrayado fucsia")
                                    rpt.then(function (styleresponse) {
                                        //console.log(styleresponse);
                                        if (styleresponse > 0) {
                                            node.span.style.backgroundColor = "Fuchsia";
                                        } else {
                                            Swal.fire('ERROR', 'Hubo un problema, si ya cuenta con un subrayado quítelo antes de agregar otro.', 'warning')
                                        }
                                    });

                                });

                            } else {

                                var rpt = applyOrRemoveStyle(node.data.id, "Fuchsia", "STYLE_APPLY", "subrayado fucsia")
                                rpt.then(function (styleresponse) {
                                    //console.log(styleresponse);
                                    if (styleresponse > 0) {
                                        node.span.style.backgroundColor = "Fuchsia";
                                    } else {
                                        Swal.fire('ERROR', 'Hubo un problema, si ya cuenta con un subrayado quítelo antes de agregar otro.', 'warning')
                                    }
                                });
                            }

                            break;
                        case "redsubrayado":

                            var selectedNodes = $.ui.fancytree.getTree("#" + treeReach).getSelectedNodes();

                            if (selectedNodes.length > 0) {

                                selectedNodes.forEach(function element(node) {

                                    var rpt = applyOrRemoveStyle(node.data.id, "Red", "STYLE_APPLY", "subrayado rojo")
                                    rpt.then(function (styleresponse) {
                                        //console.log(styleresponse);
                                        if (styleresponse > 0) {
                                            node.span.style.backgroundColor = "Red";
                                        } else {
                                            Swal.fire('ERROR', 'Hubo un problema, si ya cuenta con un subrayado quítelo antes de agregar otro.', 'warning')
                                        }
                                    });

                                });

                            } else {

                                var rpt = applyOrRemoveStyle(node.data.id, "Red", "STYLE_APPLY", "subrayado rojo")
                                rpt.then(function (styleresponse) {
                                    //console.log(styleresponse);
                                    if (styleresponse > 0) {
                                        node.span.style.backgroundColor = "Red";
                                    } else {
                                        Swal.fire('ERROR', 'Hubo un problema, si ya cuenta con un subrayado quítelo antes de agregar otro.', 'warning')
                                    }
                                });
                            }

                            break;
                        case "removesubrayado":

                            var selectedNodes = $.ui.fancytree.getTree("#" + treeReach).getSelectedNodes();

                            if (selectedNodes.length > 0) {

                                selectedNodes.forEach(function element(node) {

                                    var rpt1 = applyOrRemoveStyle(node.data.id, "Lime", "STYLE_REMOVE", "subrayado verde")
                                    rpt1.then(function (resp1) {
                                        var rpt2 = applyOrRemoveStyle(node.data.id, "Aqua", "STYLE_REMOVE", "subrayado azul")
                                        rpt2.then(function (resp2) {
                                            var rpt3 = applyOrRemoveStyle(node.data.id, "Yellow", "STYLE_REMOVE", "subrayado amarillo")
                                            rpt3.then(function (resp3) {
                                                var rpt4 = applyOrRemoveStyle(node.data.id, "Fuchsia", "STYLE_REMOVE", "subrayado fucsia")
                                                rpt4.then(function (resp4) {
                                                    var rpt5 = applyOrRemoveStyle(node.data.id, "Red", "STYLE_REMOVE", "subrayado rojo")
                                                    rpt5.then(function (resp5) {
                                                        node.span.style.backgroundColor = "";
                                                    });
                                                });
                                            });
                                        });
                                    });
                                });

                            } else {

                                var rpt1 = applyOrRemoveStyle(node.data.id, "Lime", "STYLE_REMOVE", "subrayado verde")
                                rpt1.then(function (resp1) {
                                    var rpt2 = applyOrRemoveStyle(node.data.id, "Aqua", "STYLE_REMOVE", "subrayado azul")
                                    rpt2.then(function (resp2) {
                                        var rpt3 = applyOrRemoveStyle(node.data.id, "Yellow", "STYLE_REMOVE", "subrayado amarillo")
                                        rpt3.then(function (resp3) {
                                            var rpt4 = applyOrRemoveStyle(node.data.id, "Fuchsia", "STYLE_REMOVE", "subrayado fucsia")
                                            rpt4.then(function (resp4) {
                                                var rpt5 = applyOrRemoveStyle(node.data.id, "Red", "STYLE_REMOVE", "subrayado rojo")
                                                rpt5.then(function (resp5) {
                                                    node.span.style.backgroundColor = "";
                                                });
                                            });
                                        });
                                    });
                                });
                            }

                            break;

                        case "setfoldericon":
                            //tree.applyCommand(data.cmd, node);
                            console.log("Añadir icono de folder");
                            var rpt = applyOrRemoveStyle(node.data.id, "true", "STYLE_APPLY", "")
                            rpt.then(function (styleresponse) {
                                //console.log(styleresponse);
                                if (styleresponse > 0) {
                                    node.folder = true;
                                } else {
                                    Swal.fire('ERROR', 'Hubo un problema, Puede que el nivel ya cuente con ícono de carpeta', 'warning')
                                }
                            });
                            //console.log(node.data.id); // id del nodo.
                            //addColumn(treeReach, node.data.id);
                            break;

                        case "removefoldericon":
                            //tree.applyCommand(data.cmd, node);
                            //console.log("Quitar icono de folder");
                            var rpt = applyOrRemoveStyle(node.data.id, "true", "STYLE_REMOVE", "")
                            rpt.then(function (styleresponse) {
                                //console.log(styleresponse);
                                if (styleresponse > 0) {
                                    node.folder = "";
                                } else {
                                    Swal.fire('ERROR', 'Hubo un problema quitando el estilo', 'warning')
                                }
                            });
                            //console.log(node.data.id); // id del nodo.
                            //addColumn(treeReach, node.data.id);
                            break;
                        case "addnchilds":
                            //tree.applyCommand(data.cmd, node);
                            //console.log("Añadir n hijos");
                            //console.log(node.data.id);
                            $('#modal-utilities').modal('show');

                            $('#txtIdParent').val(node.data.id);
                            $('#txtPyID').val(pySelected);
                            $('#txtTree').val(treeReach);
                            //console.log(nodo.parent);

                            break;
                        case "duplicatelevel":
                            //tree.applyCommand(data.cmd, node);
                            //console.log("Añadir n hijos");
                            //console.log(node.data.id);
                            //console.log(nodo.parent);

                            Swal.fire({
                                title: 'Cantidad de veces a duplicar',
                                input: 'number',
                                inputAttributes: {
                                    autocapitalize: 'off',
                                    min: 1,
                                },
                                inputValue: 1,
                                showCancelButton: true,
                                confirmButtonText: 'Duplicar',
                                showLoaderOnConfirm: true,
                            }).then((result) => {
                                if (result.isConfirmed) {
                                    Swal.fire({ title: 'Duplicando ' + result.value + ' veces', allowOutsideClick: false, showConfirmButton: false })
                                    //--------------------------------->>
                                    //console.log(result.value) cantidad de veces
                                    var rpt = duplicateLevels(node.data.id, node.data.parentId, pySelected, result.value)
                                    rpt.then(function (response) {
                                        //console.log(response);
                                        var tree = $("#" + treeReach).fancytree("getTree"); // para obtener el arbol renderizado.
                                        var nodo = tree.getActiveNode(); // para obtener el nodo activo.

                                        if (response.msg == "Se duplicaron correctamente los niveles") {
                                            Swal.fire('Duplicados Correctamente !', 'Se duplicaron: ' + response.registros + ' Registros, de un total de: ' + response.total + ' ', 'success');
                                            nodo.parent.resetLazy(); //recargamos el nodo parent para cargar los id de los n elementos ingresados.
                                        } else if (response.msg == "Falto duplicar algunos niveles") {
                                            Swal.fire("Atencion", 'Se duplicaron: ' + response.registros + ' Registros, de un total de: ' + response.total + ' ', "warning");
                                            nodo.parent.resetLazy(); //recargamos el nodo parent para cargar los id de los n elementos ingresados.
                                        } else if (response.msg == "Excepcion no controlada") {
                                            Swal.fire("Atencion", 'Hubo una excepción, se duplicaron: ' + response.registros + ' Registros, de un total de: ' + response.total + ' ', "warning");
                                            nodo.parent.resetLazy(); //recargamos el nodo parent para cargar los id de los n elementos ingresados.
                                        } else {
                                            Swal.fire("Hubo un Problema", 'Error:' + response.msg, "error");
                                        } 
                                        
                                    }).catch(error => {
                                        Swal.fire('ERROR', 'Hubo un problema, no se pudo duplicar correctamente.', 'warning')
                                    });
                                }
                            });

                            break;
                        case "setsecondinput":

                            var selectedNodes = $.ui.fancytree.getTree("#" + treeReach).getSelectedNodes();
                            if (selectedNodes.length > 0) {

                                $('#footer_options').remove();
                                var footerBtns = "";
                                $('#tbodyAdminCampos').remove();
                                var tableChildNodes = "";

                                var parentIds = [];

                                tableChildNodes = tableChildNodes + '<tbody id="tbodyAdminCampos">';
                                selectedNodes.forEach(function element(node) {

                                    if (node.children != null) {

                                        parentIds.push(node.children[0].data.parentId);
                                        //console.log(parentId);

                                        tableChildNodes = tableChildNodes + '<tr class="header naranja" style="cursor:pointer;">';
                                        tableChildNodes = tableChildNodes + '<td><input onclick="fnCheckFieldChanges(' + node.children[0].data.parentId + ')" value="' + node.data.descripcion + '" type="checkbox" disabled></td>';
                                        tableChildNodes = tableChildNodes + '<td><span class="text-muted">' + node.title + '</span></td>';
                                        tableChildNodes = tableChildNodes + '<td><span class="text-muted">' + node.data.descripcion + '</span></td>';
                                        tableChildNodes = tableChildNodes + '</tr>';

                                        node.children.forEach(function element(child) {

                                            //console.log(child);
                                            tableChildNodes = tableChildNodes + '<tr class="header" style="cursor:pointer;">';
                                            tableChildNodes = tableChildNodes + '<td><input onclick="fnCheckFieldChanges(' + node.children[0].data.parentId + ')" value="' + [child.data.descripcion, node.children[0].data.parentId] + '" type="checkbox" class="checkbox_check_campo" name="checkbox_check_campo[]"></td>';
                                            tableChildNodes = tableChildNodes + '<td><span class="text-muted">' + child.title + '</span></td>';
                                            tableChildNodes = tableChildNodes + '<td><span class="text-muted">' + child.data.descripcion + '</span></td>';
                                            tableChildNodes = tableChildNodes + '</tr>';
                                        });
                                    }
                                });

                                tableChildNodes = tableChildNodes + '</tbody>';

                                $('#tblAdminSecondInput').append(tableChildNodes).fadeIn(300000);

                                //------------------------------------------> Modal Cancel - Apply Options
                                footerBtns = footerBtns + '<div class="modal-footer" id="footer_options">';
                                footerBtns = footerBtns + '<button type="button" class="btn me-auto" data-bs-dismiss="modal">Cancelar</button>';
                                footerBtns = footerBtns + '<button id="btnApplySecondField" onclick="fnSetSecondFieldValueMultiple(`' + treeReach + '`, `' + parentIds + '`);" style="display:none" type="button" class="btn btn-primary" data-bs-dismiss="modal">Aplicar</button>';
                                footerBtns = footerBtns + '</div>';

                                $('#modalContentFields').append(footerBtns).fadeIn(300000);
                                $('#modal-second-input').modal('show');

                                //console.log(parentIds);
                            } else {
                                if (node.expanded === true) { //preguntar si el nodo esta expandido                                     
                                    var childNodes = node.children;

                                    buildSecondInput(childNodes, treeReach, node.data.descripcion); //envio los datos de los hijos y el nodo para resetear el nodo padre.
                                    $('#modal-second-input').modal('show');
                                } else {
                                    Swal.fire('ELEMENTO CONTRAIDO', 'Por favor desglose todos los elementos hijos y subhijos que desee incluir', 'warning')
                                }
                            }
                            //addColumn(treeReach, node.data.id);
                            break;
                        case "showhidenodes":
                            /*console.log("Mostrar y/o ocultar nodos.");*/
                            if (node.expanded === true) { //preguntar si el nodo esta expandido                                                    
                                var childNodes = node.children;
                                fnShowHideElements(childNodes, treeReach); //envio los datos de los hijos y el nodo para resetear el nodo padre.
                                $('#modal-showhide-nodes').modal('show');
                            } else {
                                Swal.fire('ELEMENTO CONTRAIDO', 'Por favor desglose para obtener los elementos hijos', 'warning')
                            }

                            break;
                        case "insertmicrodb":
                            console.log("Ingresando microbase de excel...");
                            $('#modal-insert-microdb').modal('show');
                            var parentId = node.data.id;
                            modalInsertMicroDB(parentId, treeReach, pySelected);

                            break;
                        //case "hidegrid":
                        //    //tree.applyCommand(data.cmd, node);
                        //    console.log("ocultar columnas");
                        //    console.log(node)
                        //    //console.log(node.data.id); // id del nodo.
                        //    //addColumn(treeReach, node.data.id);
                        //    break;
                        //case "newcolumn":
                        //    //tree.applyCommand(data.cmd, node);
                        //    console.log("Nueva columna");
                        //    console.log(node)
                        //    //console.log(node.data.id); // id del nodo.
                        //    //addColumn(treeReach, node.data.id);
                        //    break;
                        default:
                            alert("Unhandled command: " + data.cmd);
                            return;
                    }
                })
                .on("keydown", function (e) {
                    var cmd = null;
                    //------------------------------- EVENTOS DESENCADENADOS POR TECLAS.
                    // console.log(e.type, $.ui.fancytree.eventToString(e));
                    switch ($.ui.fancytree.eventToString(e)) {
                        case "ctrl+shift+n":
                        case "meta+shift+n": // mac: cmd+shift+n
                            cmd = "addChild";
                            break;
                        case "ctrl+c":
                        case "meta+c": // mac
                            cmd = "copy";
                            break;
                        case "ctrl+v":
                        case "meta+v": // mac
                            cmd = "paste";
                            break;
                        case "ctrl+x":
                        case "meta+x": // mac
                            cmd = "cut";
                            break;
                        case "ctrl+n":
                        case "meta+n": // mac
                            cmd = "addSibling";
                            break;
                        /*case "del":*/ //Tecla DEL para eliminar un nodo
                        case "meta+backspace": // mac
                            cmd = "remove";
                            break;
                        // case "f2":  // already triggered by ext-edit pluging
                        //   cmd = "rename";
                        //   break;
                        case "ctrl+up":
                        case "ctrl+shift+up": // mac
                            cmd = "moveUp";
                            break;
                        case "ctrl+down":
                        case "ctrl+shift+down": // mac
                            cmd = "moveDown";
                            break;
                        case "ctrl+right":
                        case "ctrl+shift+right": // mac
                            cmd = "indent";
                            break;
                        case "ctrl+left":
                        case "ctrl+shift+left": // mac
                            cmd = "outdent";
                    }
                    if (cmd) {
                        $(this).trigger("nodeCommand", { cmd: cmd });
                        return false;
                    }
                });

            /*
             * Tooltips
             */
            // $("#tree").tooltip({
            //   content: function () {
            //     return $(this).attr("title");
            //   }
            // });

            /*
             * Context menu (https://github.com/mar10/jquery-ui-contextmenu)
             */
            $("#" + treeReach).contextmenu({
                delegate: "span.fancytree-node",
                menu: [
                    {
                        title: "Editar <kbd>[F2]</kbd>",
                        cmd: "rename",
                        uiIcon: "ui-icon-pencil",
                    },
                    {
                        title: "Eliminar <strong>(M)</strong> <kbd>[Del]</kbd>",
                        cmd: "remove",
                        uiIcon: "ui-icon-trash",
                    },
                    { title: "----" },
                    {
                        title: "Nuevo Hermano <kbd>[Ctrl+N]</kbd>",
                        cmd: "addSibling",
                        uiIcon: "ui-icon-plus",
                    },
                    {
                        title: "Nuevo Hijo <kbd>[Ctrl+Shift+N]</kbd>",
                        cmd: "addChild",
                        uiIcon: "ui-icon-arrowreturn-1-e",
                    }, { title: "----" },
                    {
                        title: "Añadir N hijos",
                        cmd: "addnchilds",
                    },
                    {
                        title: "Duplicar elemento",
                        cmd: "duplicatelevel",
                    },
                    {
                        title: "Formar Segundo Campo <strong>(M)</strong>",
                        cmd: "setsecondinput",
                    },
                    {
                        title: "Mostrar / Ocultar Elementos",
                        cmd: "showhidenodes",
                    },{
                        title: "<strong>Ingresar Microbase</strong>",
                        cmd: "insertmicrodb",
                    },
                    { title: "----" },
                    {
                        title: "Aplicar Negrita al Titulo <strong>(M)</strong>",
                        cmd: "applyboldtitle",
                    }, {
                        title: "Quitar Negrita del Titulo <strong>(M)</strong>",
                        cmd: "removeboldtitle",
                    },
                    {
                        title: "Aplicar Negrita a Descripcion <strong>(M)</strong>",
                        cmd: "applybolddescription",
                    }, {
                        title: "Quitar Negrita de Descripcion <strong>(M)</strong>",
                        cmd: "removebolddescription",
                    }
                    , {
                        title: "Aplicar Cursiva al Titulo <strong>(M)</strong>",
                        cmd: "applyitalictitle",
                    }, {
                        title: "Quitar Cursiva de Titulo <strong>(M)</strong>",
                        cmd: "removeitalictitle",
                    }, {
                        title: "Aplicar Cursiva a Descripcion <strong>(M)</strong>",
                        cmd: "applyitalicdescription",
                    }, {
                        title: "Quitar Cursiva de Descripcion <strong>(M)</strong>",
                        cmd: "removeitalicdescription",
                    }, { title: "----" },
                    {
                        title: "Colores y Tamaños de Fuente <strong>(M)</strong>",
                        cmd: "changecolorsfontsize",
                    }
                    , { title: "----" },
                    {
                        title: "Subrayar verde <strong>(M)</strong>",
                        cmd: "greensubrayado",
                    }, {
                        title: "Subrayar azul <strong>(M)</strong>",
                        cmd: "bluesubrayado",
                    }, {
                        title: "Subrayar amarillo <strong>(M)</strong>",
                        cmd: "yellowsubrayado",
                    }, {
                        title: "Subrayar fuchsia <strong>(M)</strong>",
                        cmd: "fuchsiasubrayado",
                    }, {
                        title: "Subrayar rojo <strong>(M)</strong>",
                        cmd: "redsubrayado",
                    }, {
                        title: "Quitar Subrayado <strong>(M)</strong>",
                        cmd: "removesubrayado",
                    }, { title: "----" },
                    {
                        title: "Setear icono de folder",
                        cmd: "setfoldericon",
                    },
                    {
                        title: "Quitar icono de folder",
                        cmd: "removefoldericon",
                    }
                    //, {
                    //    title: "Mostrar Grilla",
                    //    cmd: "showgrid",
                    //},
                    //{
                    //    title: "Ocultar Grilla",
                    //    cmd: "hidegrid",
                    //},
                    //{
                    //    title: "Nueva Columna",
                    //    cmd: "newcolumn",
                    //    uiIcon: "ui-icon-plus",
                    //},
                    //{ title: "----" },
                    //{
                    //    title: "Cortar <kbd>Ctrl+X</kbd>",
                    //    cmd: "cut",
                    //    uiIcon: "ui-icon-scissors",
                    //},
                    //{
                    //    title: "Copiar <kbd>Ctrl-C</kbd>",
                    //    cmd: "copy",
                    //    uiIcon: "ui-icon-copy",
                    //},
                    //{
                    //    title: "Pegar as child<kbd>Ctrl+V</kbd>",
                    //    cmd: "paste",
                    //    uiIcon: "ui-icon-clipboard",
                    //    disabled: true,
                    //},
                ],
                beforeOpen: function (event, ui) {
                    var node = $.ui.fancytree.getNode(ui.target);
                    $("#" + treeReach).contextmenu(
                        "enableEntry",
                        "paste",
                        !!CLIPBOARD
                    );
                    node.setActive();
                },
                select: function (event, ui) {
                    var that = this;
                    // delay the event, so the menu can close and the click event does
                    // not interfere with the edit control
                    setTimeout(function () {
                        $(that).trigger("nodeCommand", { cmd: ui.cmd });
                    }, 100);

                },
            });

        }); //---------> End Fancytree..

    } else {

        //console.log("proyecto de usuario");

    } //--------> End If
}

//---------------- carga de proyecto MASTER
function funGetMasterData() {
    var url = "/Home/funGetLvlMaster";
    return $.get(url, {}, function (data) {
        //console.log(data);
    });
};

//---------------- carga de proyecto de Usuario...
function funGetPyFromUsuario(vIdProject) {
    var url = "/Home/funGetLvlFromPyUsuario";
    return $.get(url, { idProyecto: vIdProject }, function (data) {
        //console.log(data);
    });
};
//-------------------------------- para obtener los titulos de las columnas...
async function funGetTitulos(pyId) {
    return titles = await funGetTitlesFromDB(pyId);
    //var info = await funGetInfoFromDB(lvlID);
    //console.log(info)
};

function funGetTitlesFromDB(pyId) {
    var url = "/Home/funGetColumnTitles";
    return $.get(url, { idProyecto: pyId }, function (data) {
        //console.log(data);
    });
}

function InsertUpdateTitulo(tree, i, id, idpy, permiso) {

    //console.log(permiso);

    if (typeof (permiso) === 'undefined' || permiso == "VIEWER") {

        Swal.fire('ADVERTENCIA', 'Puedes editar el proyecto en su respectiva pestaña EDITOR, si tienes el permiso correspondiente.', 'warning')

    } else {

        var urlToGo = "";
        var dataToGo;
        //console.log(tree, i)
        if (id > 0) {

            var tituloUpdate = $('#' + tree + "_" + id).val();

            //console.log(tree);
            //console.log(tituloUpdate);

            urlToGo = "/Home/funUpdateTitulo";
            dataToGo = { "id": id, "title": tituloUpdate }

            $.ajax({
                type: "POST",
                dataType: "json",
                url: urlToGo,
                data: dataToGo,
                success: function (response) {

                    if (response > 0) {

                        Swal.fire({
                            toast: true,
                            background: 'orange',
                            icon: 'success',
                            title: 'Titulo actualizado',
                            animation: false,
                            position: 'bottom',
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true,
                            didOpen: (toast) => {
                                toast.addEventListener('mouseenter', Swal.stopTimer)
                                toast.addEventListener('mouseleave', Swal.resumeTimer)
                            }
                        })

                    } else {

                        Swal.fire({
                            toast: true,
                            background: 'orange',
                            icon: 'error',
                            title: 'Hubo un problema',
                            animation: false,
                            position: 'bottom',
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true,
                            didOpen: (toast) => {
                                toast.addEventListener('mouseenter', Swal.stopTimer)
                                toast.addEventListener('mouseleave', Swal.resumeTimer)
                            }
                        })
                    }
                },
            });


        } else {

            var tituloInsert = $('#' + tree + i).val();
            //console.log(tituloInsert)
            urlToGo = "/Home/funInsertTitulo";
            dataToGo = { "proyectoId": idpy, "title": tituloInsert }

            $.ajax({
                type: "POST",
                dataType: "json",
                url: urlToGo,
                data: dataToGo,
                success: function (response) {

                    if (response > 0) {

                        //removemos la funcion onchange y la volvemos a agregar solo con los parametros necesarios para la actualizacion.
                        $('#' + tree + i).removeAttr("onchange");
                        $('#' + tree + i).attr('onchange', "InsertUpdateTitulo('" + tree + "','" + i + "','" + response + "','" + idpy + "','" + permiso + "')");
                        //cambiamos el id tambien por el nuevo con solo los parametros requeridos para la actualizacion.
                        $('#' + tree + i).attr('id', tree + '_' + response);

                        Swal.fire({
                            toast: true,
                            background: 'orange',
                            icon: 'success',
                            title: 'Titulo guardado',
                            animation: false,
                            position: 'bottom',
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true,
                            didOpen: (toast) => {
                                toast.addEventListener('mouseenter', Swal.stopTimer)
                                toast.addEventListener('mouseleave', Swal.resumeTimer)
                            }
                        })

                    } else {
                        Swal.fire({
                            toast: true,
                            background: 'orange',
                            icon: 'error',
                            title: 'Hubo un problema',
                            animation: false,
                            position: 'bottom',
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true,
                            didOpen: (toast) => {
                                toast.addEventListener('mouseenter', Swal.stopTimer)
                                toast.addEventListener('mouseleave', Swal.resumeTimer)
                            }
                        })
                    }
                },
            });
        }
    }
}

//-------------------------------- para obtener la info de cada nivel...
async function funGetInfo(lvlID) {
    return info = await funGetInfoFromDB(lvlID);
    //var info = await funGetInfoFromDB(lvlID);
    //console.log(info)
};

function funGetInfoFromDB(lvlID) {
    var url = "/Home/funGetInfoFromDB";
    return $.get(url, { lvlId: lvlID }, function (data) {
        //console.log(data);
    });
}

function insertOrUpdateInfoGrilla(tree, id, i, nodeId, permiso) {

    //console.log(permiso);
    if (typeof (permiso) === 'undefined' || permiso == "VIEWER") {

        Swal.fire('ADVERTENCIA', 'Puedes editar el proyecto en su respectiva pestaña EDITOR, si tienes el permiso correspondiente.', 'warning')

    } else {

        //tree: referencia al arbol
        //id: el id para actualizar en caso haya un registro guardado.
        //i: el contador de la caja empezando en 2 de izquierda a derecha hasta el 51
        //nodeId: el valor del nivel del nodo en el que estamos.

        var urlToGo = "";
        var dataToGo;

        if (id > 0) {
            //console.log("ACTUALIZAR ! ")
            var valorCajaUpdate = $('#' + tree + '_colvalue' + id).val();

            urlToGo = "/Home/funUpdateInfo";
            dataToGo = { "id": id, "informacion": valorCajaUpdate }

            $.ajax({
                type: "POST",
                dataType: "json",
                url: urlToGo,
                data: dataToGo,
                success: function (response) {

                    if (response > 0) {

                        Swal.fire({
                            toast: true,
                            background: 'orange',
                            icon: 'success',
                            title: 'Información actualizada',
                            animation: false,
                            position: 'bottom',
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true,
                            didOpen: (toast) => {
                                toast.addEventListener('mouseenter', Swal.stopTimer)
                                toast.addEventListener('mouseleave', Swal.resumeTimer)
                            }
                        })

                    } else {

                        Swal.fire({
                            toast: true,
                            background: 'orange',
                            icon: 'error',
                            title: 'Hubo un problema',
                            animation: false,
                            position: 'bottom',
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true,
                            didOpen: (toast) => {
                                toast.addEventListener('mouseenter', Swal.stopTimer)
                                toast.addEventListener('mouseleave', Swal.resumeTimer)
                            }
                        })
                    }
                },
            });


        } else {
            //console.log("INSERTAR ! ")

            var valorCajaInsert = $('#' + tree + '_colvalue_' + i + "_" + nodeId).val();

            urlToGo = "/Home/funInsertInfo";
            dataToGo = { "idLvl": nodeId, "info": valorCajaInsert }

            $.ajax({
                type: "POST",
                dataType: "json",
                url: urlToGo,
                data: dataToGo,
                success: function (response) {

                    if (response > 0) {

                        //removemos la funcion onchange y la volvemos a agregar solo con los parametros necesarios para la actualizacion.
                        $('#' + tree + '_colvalue_' + i + "_" + nodeId).removeAttr("onchange");
                        $('#' + tree + '_colvalue_' + i + "_" + nodeId).attr('onchange', "insertOrUpdateInfoGrilla('" + tree + "','" + response + "','" + 0 + "','" + 0 + "','" + permiso + "')");
                        //cambiamos el id tambien por el nuevo con solo los parametros requeridos para la actualizacion.
                        $('#' + tree + '_colvalue_' + i + "_" + nodeId).attr('id', tree + '_colvalue' + response);

                        Swal.fire({
                            toast: true,
                            background: 'orange',
                            icon: 'success',
                            title: 'Información guardada',
                            animation: false,
                            position: 'bottom',
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true,
                            didOpen: (toast) => {
                                toast.addEventListener('mouseenter', Swal.stopTimer)
                                toast.addEventListener('mouseleave', Swal.resumeTimer)
                            }
                        })

                    } else {
                        Swal.fire({
                            toast: true,
                            background: 'orange',
                            icon: 'error',
                            title: 'Hubo un problema',
                            animation: false,
                            position: 'bottom',
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true,
                            didOpen: (toast) => {
                                toast.addEventListener('mouseenter', Swal.stopTimer)
                                toast.addEventListener('mouseleave', Swal.resumeTimer)
                            }
                        })
                    }
                },
            });
        }
    }
}

//-------------------------------- para obtener la info de cada nivel...
function fnExpandNodes(vIdProyecto) {
    $("#tree_" + vIdProyecto).fancytree("getRootNode").visit(function (node) {
        if (node.isExpanded() == false) {
            node.setExpanded(true);
        }
    });
}
//Mensajito para la informacion que se puede editar proyecto
function EdicionInfo() {
    Swal.fire('EDITOR', 'Puedes editar éste proyecto en su respectiva pestaña EDITOR, ya sea porque es tuyo o porque te concedieron dicho permiso.', 'info')
}

function fnShowHideColumns(loadedTree) {
    //var select = document.getElementById('selecterColumns');
    var select = $("#selecterColumns option:selected").text();
    //console.log(select);
    if (select == "HIDEALL") {
        //for para obtener las columnas por indice.
        for (c = 3; c <= 53; c++) {
            $('#' + loadedTree + ' td:nth-child(' + c + '),th:nth-child(' + c + ')').hide();
        }
    } else if (select == "SHOWALL") {
        //for para obtener las columnas por indice.
        for (c = 3; c <= 53; c++) {
            $('#' + loadedTree + ' td:nth-child(' + c + '),th:nth-child(' + c + ')').show();
        }
    }
}
//------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------
//----------------------------------------------------------> CARGA DE COLUMNAS PARA CONFIGURACION
var checkedColumns = [];

function columnId(idElement) {
    this.idElement = idElement;
};

function loadColumnas(loadedTree, vIdProyecto) {

    $('#footer_columns_options').remove();
    var option_btns = "";

    //---------------------------------------------------------->
    //console.log(loadedTree, vIdProyecto)
    $('#tbodyAdminColumnas').remove();
    var cuerpo_columnas = "";

    var titulos = funGetTitulos(vIdProyecto)
    titulos.then(function (result) {

        //console.log(result);

        cuerpo_columnas = cuerpo_columnas + '<tbody id="tbodyAdminColumnas">';

        result.forEach(function (element) {

            cuerpo_columnas = cuerpo_columnas + '<tr>';

            const idPushed = checkedColumns.find(x => x.idElement == element.tituloID);

            if (typeof (idPushed) === 'undefined') {
                //console.log("NO ESTA PUSHEADO:" + idPushed)
                cuerpo_columnas = cuerpo_columnas + '<td><input onclick="fnCheckColumnChanges(' + element.tituloID + ')" value=' + element.tituloID + ' type="checkbox" class="checkbox_check" name="checkbox_check[]"></td>';

            } else {
                //console.log("YA ESTA PUSHEADO:" + idPushed)
                cuerpo_columnas = cuerpo_columnas + '<td><input onclick="fnCheckColumnChanges(' + element.tituloID + ')" value=' + element.tituloID + ' type="checkbox" class="checkbox_check" name="checkbox_check[]" checked></td>';
            }
            cuerpo_columnas = cuerpo_columnas + '<td><span class="text-muted">' + element.titulo + '</span></td>';

            cuerpo_columnas = cuerpo_columnas + '</tr>';

        });
        cuerpo_columnas = cuerpo_columnas + '</tbody>';

        $('#tblAdminColumnas').append(cuerpo_columnas).fadeIn(300000);

        //------------------------------------------> Modal Cancel - Apply Options

        option_btns = option_btns + '<div class="modal-footer" id="footer_columns_options">';
        option_btns = option_btns + '<button type="button" class="btn me-auto" data-bs-dismiss="modal">Cancelar</button>';
        option_btns = option_btns + '<button onclick="fnApplyColumnChanges(`' + loadedTree + '`);" type="button" class="btn btn-primary" data-bs-dismiss="modal">Mostrar</button>';
        option_btns = option_btns + '</div>';

        $('#modalContent').append(option_btns).fadeIn(300000);
    });
}

//------------------------------>>> Chekar todos los checkboxes de los campos de las columnas
$(document).on('change', 'input[id="checkAll"]', function () {
    checkedColumns = [];
    $('.checkbox_check').prop("checked", this.checked);

    $("input[name='checkbox_check[]']:checked").each(function () {
        //alert("Id: " + $(this).attr("id") + " Value: " + $(this).val());
        checkedColumns.push(new columnId($(this).val()));
    });
    //console.log(checkedColumns);
});
//----------------------------------------------------------> Manejo individual de los checkboxes de la función anterior.
function fnCheckColumnChanges() {

    if ($('input.checkbox_check').is(':checked') == true) {
        checkedColumns = [];
        var m = jQuery('input:checkbox[class=checkbox_check]:checked').length;
        if (m > 0) {
            jQuery('input:checkbox[class=checkbox_check]:checked').each(function () {

                checkedColumns.push(new columnId($(this).val()));
            });
        }
        //console.log(checkedColumns);
    } else {
        checkedColumns = [];
        Swal.fire('ADVERTENCIA', 'No seleccionaste ninguna columna', 'warning')
    }
}

function fnApplyColumnChanges(loadedTree) {

    //mostrar columnas de los checkboxes checkeados.
    checkedColumns.forEach(function (checked_element) {

        var columnIndex = $('#' + loadedTree + '_colname_' + checked_element.idElement).parent().index() + 1;
        $('#' + loadedTree + ' td:nth-child(' + columnIndex + '),th:nth-child(' + columnIndex + ')').show();

    });

    //ocultar columnas de los checkboxes no checkeados.
    var unCheckedColumns = $("input:checkbox:not(:checked)").length;
    if (unCheckedColumns > 0) {
        jQuery("input:checkbox:not(:checked)").each(function () {

            var columnIndex = $('#' + loadedTree + '_colname_' + $(this).val()).parent().index() + 1;
            $('#' + loadedTree + ' td:nth-child(' + columnIndex + '),th:nth-child(' + columnIndex + ')').hide();

        });
    }
}
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//------------------------------------------------------>> Setear segundo campo.
var checkedCampos = [];
function campo(valor, id) {
    this.valor = valor;
    this.id = id;
};
//-----> Para identificar cuales campos ya se encuentran formando el segundo campo.
var alreadyCheckedCampos = [];
function Field(val) {
    this.val = val;
};

function buildSecondInput(childNodes, loadedTree, settedFields) {
    //console.log("Nodos hijos:")
    //console.log(childNodes)
    //console.log(checkedHideCampos)
    //-----> Para identificar cuales campos ya se encuentran formando el segundo campo.
    const settedCampos = settedFields.split(" - ");
    settedCampos.forEach(function (f) {
        alreadyCheckedCampos.push(new Field(f))
    });
    alreadyCheckedCampos.splice(-1)

    //------------>> id del nodo padre en donde se formará el segundo campo.
    var id = childNodes[0].parent.data.id;

    $('#footer_options').remove();
    var footerBtns = "";

    $('#tbodyAdminCampos').remove();
    var tableChildNodes = "";

    tableChildNodes = tableChildNodes + '<tbody id="tbodyAdminCampos">';

    childNodes.forEach(function element(treeNode, index, array) {


        const ocultos = checkedHideCampos.find(x => x.id == treeNode.data.id);
        //console.log(ocultos)

        const pField0 = alreadyCheckedCampos.find(x => x.val == treeNode.data.descripcion);

        if (typeof (ocultos) === 'undefined') {

            if (treeNode.children != null) {

                if (typeof (pField0) === 'undefined') {

                    tableChildNodes = tableChildNodes + '<tr class="header naranja" style="cursor:pointer;">';
                    tableChildNodes = tableChildNodes + '<td><input onclick="fnCheckFieldChanges(' + 0 + ')" value="' + treeNode.data.descripcion + '" type="checkbox" class="checkbox_check_campo" name="checkbox_check_campo[]"></td>';
                    tableChildNodes = tableChildNodes + '<td><span class="text-muted">' + treeNode.title + '</span></td>';
                    tableChildNodes = tableChildNodes + '<td><span class="text-muted">' + treeNode.data.descripcion + '</span></td>';
                    tableChildNodes = tableChildNodes + '</tr>';

                } else {

                    tableChildNodes = tableChildNodes + '<tr class="header naranja" style="cursor:pointer;">';
                    tableChildNodes = tableChildNodes + '<td><input onclick="fnCheckFieldChanges(' + 0 + ')" value="' + treeNode.data.descripcion + '" type="checkbox" class="checkbox_check_campo" name="checkbox_check_campo[]" checked></td>';
                    tableChildNodes = tableChildNodes + '<td><span class="text-muted">' + treeNode.title + '</span></td>';
                    tableChildNodes = tableChildNodes + '<td><span class="text-muted">' + treeNode.data.descripcion + '</span></td>';
                    tableChildNodes = tableChildNodes + '</tr>';

                }



                treeNode.children.forEach(function element(treeSonNode1, index, array) {

                    const pField1 = alreadyCheckedCampos.find(x => x.val == treeSonNode1.data.descripcion);
                    //console.log(pField1)

                    if (treeSonNode1.children != null) {

                        if (typeof (pField1) === 'undefined') {
                            tableChildNodes = tableChildNodes + '<tr class="" style="cursor:pointer;">';
                            tableChildNodes = tableChildNodes + '<td><input onclick="fnCheckFieldChanges(' + 0 + ')" value="' + treeSonNode1.data.descripcion + '" type="checkbox" class="checkbox_check_campo" name="checkbox_check_campo[]"></td>';
                            tableChildNodes = tableChildNodes + '<td><span class="text-muted"> -->' + treeSonNode1.title + '</span></td>';
                            tableChildNodes = tableChildNodes + '<td><span class="text-muted"> ' + treeSonNode1.data.descripcion + '</span></td>';
                            tableChildNodes = tableChildNodes + '</tr>';

                        } else { //---------->> checkboxes chekados de los campos que se han encontrado ya formando el 2 campo.
                            tableChildNodes = tableChildNodes + '<tr class="" style="cursor:pointer;">';
                            tableChildNodes = tableChildNodes + '<td><input onclick="fnCheckFieldChanges(' + 0 + ')" value="' + treeSonNode1.data.descripcion + '" type="checkbox" class="checkbox_check_campo" name="checkbox_check_campo[]" checked></td>';
                            tableChildNodes = tableChildNodes + '<td><span class="text-muted"> -->' + treeSonNode1.title + '</span></td>';
                            tableChildNodes = tableChildNodes + '<td><span class="text-muted"> ' + treeSonNode1.data.descripcion + '</span></td>';
                            tableChildNodes = tableChildNodes + '</tr>';
                        }


                        treeSonNode1.children.forEach(function element(treeSonNode2, index, array) {

                            const pField2 = alreadyCheckedCampos.find(x => x.val == treeSonNode2.data.descripcion);
                            //console.log(pField2)

                            if (typeof (pField2) === 'undefined') {

                                tableChildNodes = tableChildNodes + '<tr class="" style="cursor:pointer;">';
                                tableChildNodes = tableChildNodes + '<td><input onclick="fnCheckFieldChanges(' + 0 + ')" value="' + treeSonNode2.data.descripcion + '" type="checkbox" class="checkbox_check_campo" name="checkbox_check_campo[]"></td>';
                                tableChildNodes = tableChildNodes + '<td><span class="text-muted"> ---->' + treeSonNode2.title + '</span></td>';
                                tableChildNodes = tableChildNodes + '<td><span class="text-muted"> ' + treeSonNode2.data.descripcion + '</span></td>';
                                tableChildNodes = tableChildNodes + '</tr>';

                            } else {//---------->> checkboxes chekados de los campos que se han encontrado ya formando el 2 campo.

                                tableChildNodes = tableChildNodes + '<tr class="" style="cursor:pointer;">';
                                tableChildNodes = tableChildNodes + '<td><input onclick="fnCheckFieldChanges(' + 0 + ')" value="' + treeSonNode2.data.descripcion + '" type="checkbox" class="checkbox_check_campo" name="checkbox_check_campo[]" checked></td>';
                                tableChildNodes = tableChildNodes + '<td><span class="text-muted"> ---->' + treeSonNode2.title + '</span></td>';
                                tableChildNodes = tableChildNodes + '<td><span class="text-muted"> ' + treeSonNode2.data.descripcion + '</span></td>';
                                tableChildNodes = tableChildNodes + '</tr>';

                            }

                        });

                    } else {

                        tableChildNodes = tableChildNodes + '<tr>';
                        tableChildNodes = tableChildNodes + '<td><input onclick="fnCheckFieldChanges(' + 0 + ')" value="' + treeSonNode1.data.descripcion + '" type="checkbox" class="checkbox_check_campo" name="checkbox_check_campo[]"></td>';
                        tableChildNodes = tableChildNodes + '<td><span class="text-muted"> -->' + treeSonNode1.title + '</span></td>';
                        tableChildNodes = tableChildNodes + '<td><span class="text-muted"> ' + treeSonNode1.data.descripcion + '</span></td>';
                        tableChildNodes = tableChildNodes + '</tr>';

                    }
                });

            }

            else {

                const pField = alreadyCheckedCampos.find(x => x.val == treeNode.data.descripcion);
                /* console.log(pField)*/

                tableChildNodes = tableChildNodes + '<tr class="header">';

                if (typeof (pField) === 'undefined') {

                    tableChildNodes = tableChildNodes + '<td><input onclick="fnCheckFieldChanges(' + 0 + ')" value="' + treeNode.data.descripcion + '" type="checkbox" class="checkbox_check_campo" name="checkbox_check_campo[]"></td>';
                    tableChildNodes = tableChildNodes + '<td><span class="text-muted">' + treeNode.title + '</span></td>';
                    tableChildNodes = tableChildNodes + '<td><span class="text-muted">' + treeNode.data.descripcion + '</span></td>';

                } else { //---------->> checkboxes chekados de los campos que se han encontrado ya formando el 2 campo.

                    tableChildNodes = tableChildNodes + '<td><input onclick="fnCheckFieldChanges(' + 0 + ')" value="' + treeNode.data.descripcion + '" type="checkbox" class="checkbox_check_campo" name="checkbox_check_campo[]" checked></td>';
                    tableChildNodes = tableChildNodes + '<td><span class="text-muted">' + treeNode.title + '</span></td>';
                    tableChildNodes = tableChildNodes + '<td><span class="text-muted">' + treeNode.data.descripcion + '</span></td>';
                }

                tableChildNodes = tableChildNodes + '</tr>';
            }

        } // end if ocultos.


    });
    tableChildNodes = tableChildNodes + '</tbody>';

    $('#tblAdminSecondInput').append(tableChildNodes).fadeIn(300000);
    //------------------------------------------> Modal Cancel - Apply Options
    footerBtns = footerBtns + '<div class="modal-footer" id="footer_options">';
    footerBtns = footerBtns + '<button type="button" class="btn me-auto" data-bs-dismiss="modal">Cancelar</button>';
    footerBtns = footerBtns + '<button id="btnApplySecondField" onclick="fnSetSecondFieldValue(`' + loadedTree + '`, ' + id + ');" style="display:none" type="button" class="btn btn-primary" data-bs-dismiss="modal">Aplicar</button>';
    footerBtns = footerBtns + '</div>';

    $('#modalContentFields').append(footerBtns).fadeIn(300000);

    //desglose de columnas para seleccionar los hijos de los hijos
    //$('#tblAdminSecondInput tr:not(.header)').hide();
    //$('#tblAdminSecondInput .header').click(function () {
    //    $(this).nextUntil('tr.header').slideToggle(300);
    //});
}


//------------------------------>>> Chekar todos los checkboxes de los campos hijos
$(document).on('change', 'input[id="checkAllDatosHijos"]', function () {
    checkedCampos = [];
    $('.checkbox_check_campo').prop("checked", this.checked);
    $("input[name='checkbox_check_campo[]']:checked").each(function () {
        //alert("Id: " + $(this).attr("id") + " Value: " + $(this).val());            
        const valor = $(this).val();
        const partido = valor.split(",");
        //console.log(partido);
        checkedCampos.push(new campo(partido[0], partido[1]));
    });
    if (checkedCampos.length > 0) {
        $('#btnApplySecondField').show();
    } else {
        $('#btnApplySecondField').hide();
    }
    //console.log(checkedCampos);
});
//----------------------------------------------------------> Manejo individual de los checkboxes de la función anterior.      
function fnCheckFieldChanges(id) {
    //console.log(valor);
    if ($('input.checkbox_check_campo').is(':checked') == true) {
        checkedCampos = [];
        var m = jQuery('input:checkbox[class=checkbox_check_campo]:checked').length;
        if (m > 0) {
            jQuery('input:checkbox[class=checkbox_check_campo]:checked').each(function () {

                if (id != 0) {
                    const valor = $(this).val();
                    const partido = valor.split(",");
                    //console.log(partido);
                    checkedCampos.push(new campo(partido[0], partido[1]));

                } else {
                    checkedCampos.push(new campo($(this).val(), id));
                }
            });
            //console.log(checkedCampos);
            $('#btnApplySecondField').show();
        }

    } else {
        checkedCampos = [];
        $('#btnApplySecondField').hide();
    }
}

function fnSetSecondFieldValue(loadedTree, id) {
    //console.log(loadedTree);
    var builtField = "";
    //console.log(checkedCampos)
    checkedCampos.forEach(function (campo) {
        builtField = builtField + campo.valor + " - ";
    });

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "/Home/funUpdateLvlDescriptionFromChilds",
        data: {
            "Id": id,
            "descriptionfromchilds": builtField
        },
        success: function (response) {
            if (response > 0) {
                //console.log(response);
                var tree = $('#' + loadedTree).fancytree('getTree');// para obtener el arbol renderizado.
                var nodo = tree.getActiveNode(); // para obtener el nodo activo.            
                nodo.parent.resetLazy(); //resetear nodo para ver cambios reflejados
            } else {
                Swal.fire('ERROR', 'Hubo un problema con la creación del segundo campo.', 'error')
            }
        },
    });
};

function fnSetSecondFieldValueMultiple(loadedTree, id) {

    const idR = id;
    const idF = idR.split(",");

    idF.forEach(function (idF) {

        var builtField = "";
        var eachId = 0;

        checkedCampos.forEach(function (campo) {

            if (campo.id == idF) {
                eachId = campo.id;
                builtField = builtField + campo.valor + " - ";
                //console.log(campo);
            }
        });
        //console.log(eachId);
        //console.log(builtField);

        $.ajax({
            type: "POST",
            dataType: "json",
            url: "/Home/funUpdateLvlDescriptionFromChilds",
            data: {
                "Id": eachId,
                "descriptionfromchilds": builtField
            },
            success: function (response) {
                if (response > 0) {
                    //console.log(response);
                    var tree = $('#' + loadedTree).fancytree('getTree');// para obtener el arbol renderizado.
                    var nodo = tree.getActiveNode(); // para obtener el nodo activo.            
                    nodo.parent.resetLazy(); //resetear nodo para ver cambios reflejados
                } else {
                    Swal.fire('ERROR', 'Hubo un problema con la creación del segundo campo.', 'error')
                }
            },
        });
    });
}
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//----------------------------------------------------->> FIN Seteo de segundo campo.


//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//------------------------------------------------------>> Mostrar/ocultar nodos.

var checkedHideCampos = [];
function campohidden(id) {
    this.id = id;
};

function fnShowHideElements(childNodes, loadedTree) {

    $('#footer_options_showhide').remove();
    var footerBtns = "";

    $('#tbodyAdminShowHide').remove();
    var tableChildNodes = "";

    tableChildNodes = tableChildNodes + '<tbody id="tbodyAdminShowHide">';

    childNodes.forEach(function element(treeNode, index, array) {

        if (treeNode.tr.hidden == true) {

            tableChildNodes = tableChildNodes + '<tr class="header" style="cursor:pointer;">';
            tableChildNodes = tableChildNodes + '<td><input onclick="fnCheckCamposToHide()" value="' + treeNode.data.id + '" type="checkbox" class="checkbox_check_campo_visibles" name="checkbox_check_campo_visibles[]" checked></td>';
            tableChildNodes = tableChildNodes + '<td><span class="text-muted">' + treeNode.title + '</span></td>';
            tableChildNodes = tableChildNodes + '<td><span class="text-muted">' + treeNode.data.descripcion + '</span></td>';
            tableChildNodes = tableChildNodes + '</tr>';
        } else {
            tableChildNodes = tableChildNodes + '<tr class="header" style="cursor:pointer;">';
            tableChildNodes = tableChildNodes + '<td><input onclick="fnCheckCamposToHide()" value="' + treeNode.data.id + '" type="checkbox" class="checkbox_check_campo_visibles" name="checkbox_check_campo_visibles[]"></td>';
            tableChildNodes = tableChildNodes + '<td><span class="text-muted">' + treeNode.title + '</span></td>';
            tableChildNodes = tableChildNodes + '<td><span class="text-muted">' + treeNode.data.descripcion + '</span></td>';
            tableChildNodes = tableChildNodes + '</tr>';
        }

    });
    //console.log(checkedHideCampos)
    tableChildNodes = tableChildNodes + '</tbody>';

    $('#tblAdminShowHide').append(tableChildNodes).fadeIn(300000);

    //------------------------------------------> Modal Cancel - Apply Options
    footerBtns = footerBtns + '<div class="modal-footer" id="footer_options_showhide">';
    footerBtns = footerBtns + '<button type="button" class="btn me-auto" data-bs-dismiss="modal">Cancelar</button>';
    footerBtns = footerBtns + '<button id="btnApplyShowHide" onclick="fnHideNodes(`' + loadedTree + '`);" type="button" class="btn btn-primary" data-bs-dismiss="modal">Ocultar</button>';
    footerBtns = footerBtns + '</div>';

    $('#modalShowHideNodes').append(footerBtns).fadeIn(300000);
}


//----------->> Para crear array con los checkboxes que no se han chequeado.
var unCheckedShowCampos = [];
function camposhow(id) {
    this.id = id;
};
//----------->> Para crear array con los checkboxes que no se han chequeado.


//------------------------------>>> Chekar todos los checkboxes de los campos hijos
$(document).on('change', 'input[id="checkAllDatosHijosHide"]', function () {
    checkedHideCampos = [];
    $('.checkbox_check_campo_visibles').prop("checked", this.checked);
    $("input[name='checkbox_check_campo_visibles[]']:checked").each(function () {
        //alert("Id: " + $(this).attr("id") + " Value: " + $(this).val());       
        checkedHideCampos.push(new campohidden($(this).val()));
    });

    unCheckedShowCampos = [];
    $("input:checkbox[class=checkbox_check_campo_visibles]:not(:checked)").each(function () {
        //alert("Id: " + $(this).attr("id") + " Value: " + $(this).val());       
        unCheckedShowCampos.push(new camposhow($(this).val()));
    });

    //console.log(unCheckedShowCampos);
});

function fnCheckCamposToHide() {
    if ($('input.checkbox_check_campo_visibles').is(':checked') == true) {
        checkedHideCampos = [];
        var m = jQuery('input:checkbox[class=checkbox_check_campo_visibles]:checked').length;
        if (m > 0) {
            jQuery('input:checkbox[class=checkbox_check_campo_visibles]:checked').each(function () {

                checkedHideCampos.push(new campohidden($(this).val()));
            });
            //console.log(checkedHideCampos);               
        }
    } else {
        checkedHideCampos = [];
    }

    var uncheckedNodes = $("input:checkbox[class=checkbox_check_campo_visibles]:not(:checked)").length;
    if (uncheckedNodes > 0) {
        unCheckedShowCampos = [];
        jQuery("input:checkbox[class=checkbox_check_campo_visibles]:not(:checked)").each(function () {
            unCheckedShowCampos.push(new camposhow($(this).val()))
        });
    }
    //console.log(unCheckedShowCampos);           
}

function fnHideNodes(tree) {
    //console.log(tree)
    //console.log(checkedHideCampos);
    var tree = $('#' + tree).fancytree('getTree');// para obtener el arbol renderizado.
    var nodo = tree.getActiveNode(); // para obtener el nodo activo.                    

    checkedHideCampos.forEach(function element(campotohide, index, array) {
        //console.log(campotohide.id)
        var hiderpt = applyOrRemoveStyle(campotohide.id, true, "STYLE_APPLY", "ocultar nodo")
        hiderpt.then(function (styleresponse) {
            if (styleresponse > 0) {
                //nodo.span.hidden = true;       
                nodo.children.forEach(function element(childnode, index, array) {
                    if (campotohide.id == childnode.data.id) {
                        //console.log(childnode.data.id)                               
                        childnode.tr.hidden = true;
                    };
                });
            } else {
                console.log("Hubo un problema al ocultar el campo con id: " + campotohide.id);
            }
        });
    });

    unCheckedShowCampos.forEach(function element(campotohide, index, array) {

        //console.log(campotohide);
        var showrpt = applyOrRemoveStyle(campotohide.id, true, "STYLE_REMOVE", "ocultar nodo")
        showrpt.then(function (styleresponse) {
            //console.log(styleresponse);
            if (styleresponse > 0) {
                nodo.children.forEach(function element(childnode, index, array) {
                    if (campotohide.id == childnode.data.id) {
                        //console.log(childnode.data.id)
                        childnode.tr.hidden = "";
                    };
                });
            } else {
                console.log("Hubo un problema al mostrar el campo con id: " + campotohide.id);
            }
        });
    });
}
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//----------------------------------------------------->> FIN Seteo de Mostrar/ocultar nodos..


//--------------------------------------------------------------------------
//--------------------------------------------------------------------------
//--------------------------------------------------------------------------
//--------------------------------------------------------------------------
//----------------------------------------------------->> Obteniendo estilos
async function getStyles(lvlID) {
    return styles = await getStylesFromDB(lvlID);
};

function getStylesFromDB(lvlID) {

    var urlToGo = "";
    var dataToGo;
    //------------------------>>AJAX Obtener estilos
    return $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Home/funGetLevelStyles",
        data: {
            "nivelID": lvlID
        },
        success: function (response) {
            //console.log(response);
        },
    });
    //------------------------>>AJAX Obtener estilos
}
//----------------------------------------------------->> Obteniendo estilos

//----------------------------------------------------->> Aplicando estilos
async function applyOrRemoveStyle(lvlID, style, action, campo) {
    return styleReponse = await applyOrRemoveStyleToDB(lvlID, style, action, campo);
};

function applyOrRemoveStyleToDB(lvlID, style, action, campo) {

    var urlToGo = "";
    var dataToGo;

    if (action == "STYLE_APPLY") {

        urlToGo = "/Home/funInsertLvlStyle";
        dataToGo = { "nivelID": lvlID, "style": style, "campo": campo }

        //------------------------>>AJAX Aplicar estilo
        return $.ajax({
            type: "POST",
            dataType: "json",
            url: urlToGo,
            data: dataToGo,
            success: function (response) {
                //console.log(response);
            },
        });
        //------------------------>>AJAX Aplicar estilo
    } else if (action == "STYLE_REMOVE") {

        urlToGo = "/Home/funDeleteStyle";
        dataToGo = { "nivelID": lvlID, "style": style, "campo": campo }

        //------------------------>>AJAX Aplicar estilo
        return $.ajax({
            type: "POST",
            dataType: "json",
            url: urlToGo,
            data: dataToGo,
            success: function (response) {
                //console.log(response);
            },
        });
    }
}
//----------------------------------------------------->> Aplicando estilos


//---------------------------->> removiendo estilos: COLORES Y FUENTES:
async function removeColorsAndSizes(lvlID) {
    return removes = await removeColorsAndSizesToDB(lvlID);
};

function removeColorsAndSizesToDB(lvlID) {

    //------------------------>>AJAX quitar estilos colores y fuentes
    return $.ajax({
        type: "POST",
        dataType: "json",
        url: "/Home/funRemoveColorsAndSizes",
        data: { "nivelID": lvlID },
        success: function (response) {
            //console.log(response);
        },
    });
    //------------------------>>AJAX quitar estilos colores y fuentes   
}
//---------------------------->> removiendo estilos: COLORES Y FUENTES

var arrayHijos = [];

function addNHijos() {

    arrayHijos = [];

    var vCant = $('#txtCantidad').val();
    var vNombre = $('#txtNombreBase').val();
    var vIDparent = $('#txtIdParent').val();
    var vIDproject = $('#txtPyID').val();
    var treeSelected = $('#txtTree').val();

    if (vCant != "" && vCant != null) {
        arrayHijos.push(vCant);
    } if (vNombre != "" && vNombre != null) {
        arrayHijos.push(vNombre);
    }
    var nroCamposLlenos = arrayHijos.length;
    if (nroCamposLlenos == 2) {

        Swal.fire({ title: 'Añadiendo ' + vCant + ' Niveles...', allowOutsideClick: false, showConfirmButton: false })

        var rpt = addNHijosAsync(vCant, vNombre, vIDparent, vIDproject)
        rpt.then(function (response) {

            //console.log(response);
            if (response >= 1) {

                $('#txtIdParent').val("");
                $('#txtCantidad').val("");
                $('#txtNombreBase').val("");
                $('#txtPyID').val("");

                $('#modal-utilities').modal('toggle');

                Swal.fire('Niveles añadidos !', '', 'success').then((result) => {

                    var tree = $("#" + treeSelected).fancytree("getTree"); // para obtener el arbol renderizado.
                    var nodo = tree.getActiveNode(); // para obtener el nodo activo.

                    nodo.parent.resetLazy(); //recargamos el nodo parent para cargar los id de los n elementos ingresados.
                });

                $('#txtTree').val("");

            } else {
                Swal.fire('ERROR', 'Hubo un problema', 'error')
            }
        })

    } else {
        Swal.fire('ADVERTENCIA', 'Complete ambos campos', 'warning')
    }
}

async function addNHijosAsync(vCant, vNombre, vIDparent, vIDproject) {
    return hijos = await addHijosInDB(vCant, vNombre, vIDparent, vIDproject);
};

function addHijosInDB(vCant, vNombre, vIDparent, vIDproject) {
    return $.ajax({
        type: "POST",
        url: "/Home/funInsertNLvls",
        data: {
            "cantidad": vCant,
            "nombreBase": vNombre,
            "parent": vIDparent,
            "projectID": vIDproject,
        },
        success: function (response) {
        },
    });
}

//-------------------------------- Duplicar Niveles.
async function duplicateLevels(vId, vPid, idPy, qty) {
    return dups = await duplicateLevelsInDB(vId, vPid, idPy, qty);
};

function duplicateLevelsInDB(vId, vPid, idPy, qty) {
    return $.ajax({
        type: "POST",
        url: "/Home/funDuplicateLevels",
        data: {
            "vId": vId,
            "vParentId": vPid,
            "projectId": idPy,
            "cantidad": qty,
        },
        success: function (response) {
            //console.log(response);
        },
    });
}

var colorsandsizes = [];

function estilo(valor, campo, tipo) {
    this.valor = valor;
    this.campo = campo;
    this.tipo = tipo;
};

function fnApplyColors() {

    var arbol = $('#txtGetTree').val();

    colorsandsizes = [];

    const firstColor = $('input[name=color]:checked').val();
    const secondColor = $('input[name=color-rounded]:checked').val();

    const firstSize = $('input[name=first-size]:checked').val();
    const secondSize = $('input[name=second-size]:checked').val();

    if (firstColor != "") {
        colorsandsizes.push(new estilo(firstColor, "titulo", "color"))
    } if (secondColor != "") {
        colorsandsizes.push(new estilo(secondColor, "descripcion", "color"))
    } if (firstSize != "") {
        colorsandsizes.push(new estilo(firstSize, "titulo", "size"))
    } if (secondSize != "") {
        colorsandsizes.push(new estilo(secondSize, "descripcion", "size"))
    }

    if (colorsandsizes.length > 0) {


        var selectedNodes = $.ui.fancytree.getTree("#" + arbol).getSelectedNodes();
        if (selectedNodes.length > 0) {

            selectedNodes.forEach(function element(node) {

                //console.log(node.data.id);

                var rpt1 = removeColorsAndSizes(node.data.id)
                rpt1.then(function (res1) {
                    //console.log("Eliminando>" + res1)

                    colorsandsizes.forEach(function element(elemento, index, array) {

                        //console.log(elemento.valor, elemento.campo)                    

                        var rpt2 = applyOrRemoveStyle(node.data.id, elemento.valor, "STYLE_APPLY", elemento.campo)
                        rpt2.then(function (styleresponse) {

                            //console.log("Aplicando>" + styleresponse);

                            if (elemento.tipo == "color") {
                                if (elemento.campo == "titulo") {
                                    node.span.children[2].children[0].style.color = elemento.valor; //titulo
                                } else if (elemento.campo == "descripcion") {
                                    node.span.children[2].children[1].style.color = elemento.valor; //descripcion
                                }
                            } else {
                                if (elemento.campo == "titulo") {
                                    node.span.children[2].children[0].style.fontSize = elemento.valor; //titulo
                                } else if (elemento.campo == "descripcion") {
                                    node.span.children[2].children[1].style.fontSize = elemento.valor; //descripcion
                                }
                            }
                        });
                    });
                });
            });
            $('#modal-color-admin').modal('toggle');
        }
        else {

            var nodoId = $('#txtNodoId').val();

            var tree = $("#" + arbol).fancytree("getTree"); // para obtener el arbol renderizado.
            var nodo = tree.getActiveNode(); // para obtener el nodo activo.  

            var rpt1 = removeColorsAndSizes(nodoId)
            rpt1.then(function (res1) {
                //console.log("Eliminando>" + res1)

                colorsandsizes.forEach(function element(elemento, index, array) {

                    //console.log(elemento.valor, elemento.campo)                    

                    var rpt2 = applyOrRemoveStyle(nodoId, elemento.valor, "STYLE_APPLY", elemento.campo)
                    rpt2.then(function (styleresponse) {

                        //console.log("Aplicando>" + styleresponse);

                        if (elemento.tipo == "color") {
                            if (elemento.campo == "titulo") {
                                nodo.span.children[2].children[0].style.color = elemento.valor; //titulo
                            } else if (elemento.campo == "descripcion") {
                                nodo.span.children[2].children[1].style.color = elemento.valor; //descripcion
                            }
                        } else {
                            if (elemento.campo == "titulo") {
                                nodo.span.children[2].children[0].style.fontSize = elemento.valor; //titulo
                            } else if (elemento.campo == "descripcion") {
                                nodo.span.children[2].children[1].style.fontSize = elemento.valor; //descripcion
                            }
                        }
                    });

                    $('#modal-color-admin').modal('toggle');
                });
            });
        }
    }
}

var tableToExcel = (function () {
    var uri = 'data:application/vnd.ms-excel;base64,'
        , template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>'
        , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
        , format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }
    return function (table, name) {
        if (!table.nodeType) table = document.getElementById(table)
        var ctx = { worksheet: name || 'Worksheet', table: table.innerHTML }
        window.location.href = uri + base64(format(template, ctx))
    }
})()

        //function addColumn(tree, nodoId) {
        //    console.log(tree,nodoId)
        //    $('#' + tree + ' thead tr').append('<th id=th' + nodoId +'>Col</th>');
        //    $('#' + tree + ' tbody tr').append('<td id=td' + nodoId +'><input type="text" placeholder="Ingrese algo"></td>');
        //}

//------------------------------------------------------->> FASE 2 09/02/2022
//------------------------------------------------------------------------->>

async function modalInsertMicroDB(parentId, treeReach, pySelected) {    
    //pySelected
    $('#footer_options_equipos').remove();
    var footerBtns = "";
    $('#tbodyDataEquipos').remove();
    var tableDataEquipos = "";    
            
    var equipos = await funGetAllEquiposFromDB();   
        
    tableDataEquipos = tableDataEquipos + '<tbody id="tbodyDataEquipos">';
    
    equipos.forEach(function element(ele) {

        tableDataEquipos = tableDataEquipos + '<tr class="header equiponaranja" style="cursor:pointer;">';
        tableDataEquipos = tableDataEquipos + '<td><input type="checkbox" disabled></td>';
        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + ele.nombrE_EQUIPO + '</span></td>';
        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + ele.nrC_EQUIPO + '</span></td>';
        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + ele.canT_EQUIPO + '</span></td>';
        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + ele.unD_EQUIPO + '</span></td>';
        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + ele.desC1_EQUIPO + '</span></td>';
        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + ele.suB_TOTAL1_EQ + '</span></td>';
        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + ele.mrC_EQUIPO + '</span></td>';
        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + ele.desC2_EQUIPO + '</span></td>';
        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + ele.suB_TOTAL2_EQ + '</span></td>';
        tableDataEquipos = tableDataEquipos + '</tr>';

            //---------------------------------------Caracteristicas
            var caracteristica = function () {
                var salidaAjax = null;
                $.ajax({
                    url: '/Microbases/funGetEquipoCaracteristicas',
                    type: "GET",
                    dataType: "JSON",
                    async: false,
                    data: { "idEquipo": ele.iD_EQUIPO },
                    success: function (data) {                       
                        salidaAjax = data;
                    }
                });
                return salidaAjax;
            }();
           
            caracteristica.forEach(function element(elec) {
                        tableDataEquipos = tableDataEquipos + '<tr class="" style="cursor:pointer;">';
                        tableDataEquipos = tableDataEquipos + '<td><input class="checkbox_equipo" onclick="fnSetEquipo()" value="' + [elec.iD_EQUIPO_C, elec.iD_EQUIPO] + '" data-parsley-multiple="checkbox" type="checkbox"></td>';
                        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + elec.nombrE_CARACTERISTICA + '</span></td>';
                        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + elec.nrC_CARACTERISTICA + '</span></td>';
                        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + elec.canT_CARACTERISTICA + '</span></td>';
                        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + elec.unD_CARACTERISTICA + '</span></td>';
                        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + elec.desC1_CARACTERISTICA + '</span></td>';
                        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + elec.suB_TOTAL1 + '</span></td>';
                        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + elec.mrC_CARACTERISTICA + '</span></td>';
                        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + elec.desC2_CARACTERISTICA + '</span></td>';
                        tableDataEquipos = tableDataEquipos + '<td><span class="text-muted">' + elec.suB_TOTAL2 + '</span></td>';
                        tableDataEquipos = tableDataEquipos + '</tr>';
            });
            //---------------------------------------Caracteristicas
    });

    tableDataEquipos = tableDataEquipos + '</tbody>';
    
    $('#tblDataFromMicroDB').append(tableDataEquipos).fadeIn(300000);       

    //------------------------------------------> Modal Cancel - Apply Options
    footerBtns = footerBtns + '<div class="modal-footer" id="footer_options_equipos">';
    footerBtns = footerBtns + '<button type="button" class="btn me-auto" data-bs-dismiss="modal">Cancelar</button>';
    footerBtns = footerBtns + '<button id="btnAddEquipos" onclick="fnAddEquipos(`' + treeReach + '`, `' + parentId + '`, `' + pySelected + '`);" style="display:none" type="button" class="btn btn-primary">Agregar</button>';
    footerBtns = footerBtns + '</div>';

    $('#modalInsertMicroDB').append(footerBtns).fadeIn(300000);

    //-------> desglose de columnas para seleccionar las caracteristicas de los equipos
    $('#tblDataFromMicroDB tr:not(.header)').hide();
    $('#tblDataFromMicroDB .header').click(function () {
        $(this).nextUntil('tr.header').slideToggle(300);
    });
}


var checkedEquipos = [];
function caracteristicaEquipo(idC, idE) {
    this.idC = idC;
    this.idE = idE;
};
function fnSetEquipo() {
    //console.log("ID Caracteristica:", vIdC)
    //console.log("ID Equipo Padre:", vIdE)
    if ($('input.checkbox_equipo').is(':checked') == true) {
        checkedEquipos = [];
        var m = jQuery('input:checkbox[class=checkbox_equipo]:checked').length;
        if (m > 0) {
            jQuery('input:checkbox[class=checkbox_equipo]:checked').each(function () {
                const ids = $(this).val();
                const splitedId = ids.split(",");                
                checkedEquipos.push(new caracteristicaEquipo(splitedId[0], splitedId[1]));
            });
            //console.log(checkedEquipos);
            $('#btnAddEquipos').show();
        }
    } else {
        checkedEquipos = [];
        $('#btnAddEquipos').hide();
    }
}

function fnAddEquipos(treeReach, parentId, pySelected) {
    //console.log(checkedEquipos);
    //console.log(treeReach);
    //console.log(parentId);    

    var equiposToTree = JSON.stringify(checkedEquipos);

    Swal.fire({
        title: '¿Estás seguro que deseas agregarlos?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: `Si`,
        denyButtonText: `Don't save`,
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            $('#modal-insert-microdb').modal('hide');
            //------------------------>>AJAX 
            var insercion = funInsertEquiposToTree(equiposToTree, parentId, pySelected);
            insercion.then(function (response) {
                if (response > 0) {
                    var tree = $("#" + treeReach).fancytree("getTree"); // para obtener el arbol renderizado.
                    var nodo = tree.getActiveNode(); // para obtener el nodo activo.
                    nodo.parent.resetLazy(); //recargamos el nodo parent para cargar los id de los n elementos ingresados.
                    Swal.fire('HECHO', 'Se agregaron los Equipos y características correctamente.', 'success')
                }
                else { Swal.fire('ADVERTENCIA', 'Hubo un problema o los equipos que intentas agregar ya existen', 'warning') }
            });
            //------------------------>>AJAX                                                                 
        } else if (result.isDenied) {
            Swal.fire('No', '', 'info')
        }
    });
}

//------------------------------------- Insert Equipo
async function funInsertEquiposToTree(data, parentId, pySelected) {
    //console.log(datos);
    return equipos = await InsertEquiposToTreeInDB(data, parentId, pySelected);
};

function InsertEquiposToTreeInDB(data, parentId, pySelected) {
    //console.log("hola");
    //console.log(data);
    return $.ajax({
        type: "POST",
        dataType: "json",
        url: "/Home/funInsertEquiposToTreeInDB",
        data: { "datos": data, "idPadre": parentId, "projectId": pySelected},
        success: function (response) {
            //console.log(response);
        },
    });
}

//--------------------------------------> Llamada DB Equipos.
function funGetAllEquiposFromDB() {
    var url = "/Microbases/funGetAllEquipos";
    return $.get(url, {}, function (data) {
        //console.log(data);
    });
};
//--------------------------------------->>