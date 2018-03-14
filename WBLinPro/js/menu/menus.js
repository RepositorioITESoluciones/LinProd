$(function () {
    getMenus();  
});


function getMenus() {
    var html="";
    $.ajax({
        async: false,
        type: 'POST',
        url: 'WSLinPro.asmx/muestraMenus',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (dataList) {
            $.each(dataList, function (index, list) {
                html += '<ul>';
                $.each(list.listaMenus, function (index, item) {
                html += '<li class="">';
                html += '<a href="#" title="' + item.nombreMenu + '"><i class="fa fa-lg fa-fw ' + item.icono + '"></i> <span class="menu-item-parent">' + item.nombreMenu + '</span></a>';
                html += getSubMenus(item.idMenu)
                

                html += '</li>';


                //    html += '<li class="top-menu-invisible" id="li'+item.idMenu+'">' +
                //                    '<a href="' + item.liga + '" onclick="getSubMenus(' + item.idMenu + '); showSubmenu(' + item.idMenu + ')">' +
                //                    '<i class="'+item.icono+'"></i> <span class="menu-item-parent">' + item.nombreMenu + '</span>';
                //    if(item.idMenu != 1 && item.hijos === 1){
                //        html += '<b class="collapse-sign"><em class="fa fa-plus-square-o emP"></em></b>';
                //    }
                //    html += '</a>' +
                //                    '<div id="list' + item.idMenu + '"></div>' +
                //             '</li>';
                });
                html += '</ul>';
                $("nav").html(html);
            });
        }
    });
}

function getSubMenus(idMenu) {
    var hijos = '';
    
    if (parseInt(idMenu) != 0) {
        $.ajax({
            async: false,
            type: 'POST',
            url: 'WSLinPro.asmx/muestraSubMenus',
            data: JSON.stringify({ idPadre: idMenu }),
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (dataList) {
                $.each(dataList, function (index, menuHijos) {
                    if (!jQuery.isEmptyObject(menuHijos.listaMenusHijos)) {

                        hijos += '<ul>';
                        $.each(menuHijos.listaMenusHijos, function (index, item) {
                            hijos += '<li class="">';
                            hijos += '<a href="' + item.liga + '" title="Bandeja" id="' + item.nombreMenu + '"><i class="fa fa-lg fa-fw fa-gear"></i> <span class="menu-item-parent">' + item.nombreMenu + '</span></a>';
                            hijos += pintMenuHijos(item.idMenu)
                            hijos += '</li>';
                        });

                        hijos += '</ul>';

                    }
                });
            }
        });
    }

    return hijos
}

function pintMenuHijos(idMenu) {
    var subhijos = '';

    if (parseInt(idMenu) != 0) {
        $.ajax({
            async: false,
            type: 'POST',
            url: 'WSLinPro.asmx/muestraSubMenus',
            data: JSON.stringify({ idPadre: idMenu }),
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (dataList) {
                $.each(dataList, function (index, menuHijos) {
                    if (!jQuery.isEmptyObject(menuHijos.listaMenusHijos)) {

                        subhijos += '<ul>';
                        $.each(menuHijos.listaMenusHijos, function (index, item) {
                            subhijos += '<li class="">';
                            subhijos += '<a href="' + item.liga + '" title="Bandeja" id="' + item.nombreMenu + '"><span class="menu-item-parent">' + item.nombreMenu + '</span></a>';
                            //hijos += pintMenuHijos(item.idMenu)
                            subhijos += '</li>';
                        });

                        subhijos += '</ul>';

                    }
                });
            }
        });
    }

    return subhijos
}

function showSubmenu(idPadre) {
        if ($("#list" + idPadre + " > * ").length > 0 && $("#li" + idPadre + "  > a > b  > em:first-child").hasClass("fa fa-plus-square-o")) {
            $("#list" + idPadre).show();
            $("#li" + idPadre).addClass('active');
            $("#li" + idPadre + " > a > b > em:first-child").removeClass('fa fa-plus-square-o');
            $("#li" + idPadre + " > a > b > em:first-child").addClass('fa fa-minus-square-o');
        } else {
            $("#list" + idPadre).hide();
            $("#li" + idPadre).removeClass('active');
            $("#li" + idPadre + " em:first-child").removeClass('fa fa-minus-square-o');
            $("#li" + idPadre + " em:first-child").addClass('fa fa-plus-square-o');
        }   
}
