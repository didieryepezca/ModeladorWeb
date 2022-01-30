window.onload = loadMaster();


//----------------------------------------------------------- PESTAÑA PROYECTO MASTER -----------------------
async function loadMaster() {

    //removemos el pane del proyecto master para volverlo a construir
    $("#masterPane").remove();

    //muestra el loader cuando volvemos a hacer click aqui
    $("#emptyPy").show();

    var data = await funGetMasterData()

    //cuando termina de ejecutarse la función asyncrona oculta el loader...
    $("#emptyPy").hide();

    //------------------------------------------------------------->>>Treeview Master
    var treeview = "";

    treeview = treeview + '<div id="masterPane" style="border:1px solid black; padding:0px; background-color:#FAFAFA">';
    treeview = treeview + '<div class="treeview">';
    treeview = treeview + '<ul>';

    treeview = treeview + '<li>';
    treeview = treeview + '<span class="colapsado avatar avatar-xs rounded me-2" style="background-image: url(https://image.pngaaa.com/73/4388073-middle.png)" id="node_' + data[0].nivelID + '" onclick="getSubMenus(' + data[0].nivelID + ')" data-loaded="false" pid="">&nbsp;</span>';
    treeview = treeview + '<a style="cursor:pointer">' + data[0].identificador + '</a> - ';
    treeview = treeview + '<a style="cursor:pointer">' + data[0].nombre + '</a>';
    treeview = treeview + '</li>';

    treeview = treeview + '</ul>';
    treeview = treeview + '</div>';
    treeview = treeview + '</div>';

    $('#master').append(treeview).fadeIn(300000);
    //------------------------------------------------------------->>>Treeview Master
}

//trae la información del Master.
function funGetMasterData() {
    var url = "/Home/funGetMaster";
    return $.get(url, {}, function (data) {
        //console.log(data);
    });
};

//----------------------------------------------------------- PESTAÑA PROYECTO MASTER -----------------------

function getSubMenus(pId) {

    //console.log(pId)
    //Comprobar si la data se ha cargado
    if ($('#node_' + pId).attr('data-loaded') === 'false') {

        $('#node_' + pId).attr('style', "background-image: url(https://raw.githubusercontent.com/Codelessly/FlutterLoadingGIFs/master/packages/cupertino_activity_indicator_selective.gif)");// Loader
        $('#node_' + pId).removeClass("colapsado");

        //console.log("colapsado");
        // Cargamos la data con un Ajax Call...
        $.ajax({
            url: "/Home/funGetSubNiveles",
            type: "GET",
            data: { parentId: pId },
            dataType: "json",
            success: function (d) {

                //console.log(d);

                $('#node_' + pId).attr('style', "background-image: url(https://iconsplace.com/wp-content/uploads/_icons/ffa500/256/png/minus-2-icon-11-256.png)"); //-

                if (d.length > 0) {

                    if (d[0].parentNivelID == pId) { $('#ul' + pId).remove(); } //prevenir info duplicada                        

                    var $ul = $('<ul id="ul' + pId + '"></ul>');
                    $.each(d, function (i, element) {

                        //console.log(element.nivelID);

                        var info = funGetInfo(element.nivelID)

                        var cajitas = "";

                        info.then(function (result) {
                            // accedemos al result de la promise info...                                

                            //for para agregar la información dinámica a las cajitas de texto...
                            for (j = 0; j <= result.length - 1; j++) {
                                //cajitas = cajitas + '<input type="text" value="' + result[j].informacion + '" style="width: fit-content">';
                                cajitas = cajitas + '<span class="input" role="textbox" contenteditable>' + result[1].informacion + '</span>';
                            }

                            $ul.append(
                                $("<li></li>").append(
                                    '<span class="avatar avatar-xs rounded me-2 colapsado" style="background-image: url(https://image.pngaaa.com/73/4388073-middle.png)" id="node_' + element.nivelID + '" onclick="getSubMenus(' + element.nivelID + ')" data-loaded="false" pid="' + element.nivelID + '">&nbsp;</span>' +
                                    '<a style="cursor:pointer">' + element.identificador + '</a>' + ' - ' +
                                    '<a style="cursor:pointer">' + element.nombre + '</a>' + ' - ' +
                                    cajitas
                                    //'<a style="cursor:pointer"><svg xmlns="http://www.w3.org/2000/svg" class="icon" width="24" height="24" viewBox="0 0 24 24" stroke-width="2" stroke="currentColor" fill="none" stroke-linecap="round" stroke-linejoin="round"><path stroke="none" d="M0 0h24v24H0z" fill="none"></path><circle cx="6" cy="10" r="2"></circle><line x1="6" y1="4" x2="6" y2="8"></line><line x1="6" y1="12" x2="6" y2="20"></line><circle cx="12" cy="16" r="2"></circle><line x1="12" y1="4" x2="12" y2="14"></line><line x1="12" y1="18" x2="12" y2="20"></line><circle cx="18" cy="7" r="2"></circle><line x1="18" y1="4" x2="18" y2="5"></line><line x1="18" y1="9" x2="18" y2="20"></line></svg></a>'                                                                                                                                   
                                )
                            )

                        });


                    });


                    $('#node_' + pId).parent().append($ul);
                    //$('#node_' + pId).addClass('colapsado');
                    $('#node_' + pId).attr('style', "background-image: url(https://iconsplace.com/wp-content/uploads/_icons/ffa500/256/png/minus-2-icon-11-256.png)"); //-
                    $('#node_' + pId).toggleClass('colapsado expandido');
                    $('#node_' + pId).closest('li').children('ul').slideDown();
                }
                else {
                    // no sub menu
                    $('#node_' + pId).css({ 'display': 'inline-block', 'width': '15px' });
                }

                $('#node_' + pId).attr('data-loaded', true);
            },
            error: function () {
                alert("Hubo un problema al cargar la data!");
            }
        });
    }
    else {
        // if already data loaded            
        //console.log("expandido")

        $('#node_' + pId).attr('data-loaded', false);
        $('#node_' + pId).toggleClass("colapsado expandido");
        $('#node_' + pId).attr('style', "background-image: url(https://image.pngaaa.com/73/4388073-middle.png)"); // +

        $('#node_' + pId).closest('li').children('ul').slideToggle();
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
//-------------------------------- para obtener la info de cada nivel...


function editNombre(vId) {

    console.log(vId)

}

function editIdentificador(vId) {

    console.log(vId)

}