/* -------- [ Producto ] -------- */
let gridApi;

$(document).ready(function () {
    GET_DATA_PRODUCT();
})

function sizeToFit() {
    gridApi.sizeColumnsToFit();
}

$("#btnRefresh").click(function () {
    $("#inpNumPro").val("");
    $("#inpNombre").val("");
    GET_DATA_PRODUCT();
});

function GET_DATA_PRODUCT() {
    $.ajax({
        method: "GET",
        url: "/Producto/GET_DATA_PRODUCT",
        success: function (response) {
            if (response.result = "OK") {
                SET_DATA_GRID(response.data)
            }
            else {
                Swal.fire({
                    title: "Error",
                    text: "Seleccione un producto",
                    icon: "error"
                });
            }
        }
    });
}

function SET_DATA_GRID(data) {
    gridProduct();
    gridApi.setGridOption("rowData", data);
}

function gridProduct() {
    const grid = document.getElementById("gridProd");
    grid.innerHTML = '';
    const gridOptions = {
        columnDefs: [
            {
                width: 15,
                headerCheckboxSelection: true,
                headerCheckboxSelectionFilteredOnly: true,
                checkboxSelection: true,
            },
            { field: "IdProducto" },
            { field: "CodigoBarra" },
            {
                field: "Descripcion",
                editable: true
            },
            {
                field: "Precio",
                editable: true
            },
            {
                field: "Cantidad",
                editable: true
            }
        ],
        rowSelection: "multiple",
    };

    gridApi = agGrid.createGrid(document.querySelector("#gridProd"), gridOptions);

    sizeToFit();
}

/* -------- [ BUSCAR - Producto ] -------- */

$("#btnBuscar").click(function () {
    SEARCH_DATA_PRODUCT();
});

function SEARCH_DATA_PRODUCT() {

    var inpNumPro = $("#inpNumPro").val();
    var inpNombre = $("#inpNombre").val();
    if (inpNumPro != "" && inpNombre != "") {
        $.ajax({
            method: "GET",
            url: "/Producto/SEARCH_DATA_PRODUCT",
            data: {
                inpNumPro,
                inpNombre
            },
            success: function (response) {
                if (response.result = "OK") {
                    SET_DATA_GRID(response.data)
                }
            }
        });
    }
    else {
        Swal.fire({
            title: "Advertencia",
            text: "Ingrese los datos",
            icon: "warning"
        });
    }
}

/* -------- [ EDITAR - Producto ] -------- */

//var rows = gridApi.getSelectedRows();

$("#btnActualizar").click(function () {
    UPDATE_DATA_PRODUCT();
});

function UPDATE_DATA_PRODUCT() {
    var rows = gridApi.getSelectedRows();

    var items = { rows };

    if (rows.length > 0) {
        $.ajax({
            method: "POST",
            url: "/Producto/UPDATE_DATA_PRODUCT",
            dataType: "json",
            data: items,
            success: function (result) {
                Swal.fire({
                    title: "Success",
                    text: "Se actualizo con existo",
                    icon: "success"
                });
                GET_DATA_PRODUCT();
            }
        });
    }
    else {
        Swal.fire({
            title: "Advertencia",
            text: "Seleccione un producto",
            icon: "warning"
        });
    }
}

/* -------- [ ELIMINAR - Producto ] -------- */
$("#btnEliminar").click(function () {
    DELETE_PRODUCT();
});

function DELETE_PRODUCT() {
    var rows = gridApi.getSelectedRows();

    var items = { rows };

    if (rows.length > 0) {
        $.ajax({
            method: "POST",
            url: "/Producto/DELETE_PRODUCT",
            data: items,
            success: function (result) {
                Swal.fire({
                    title: "Success",
                    text: "Se elimino con existo",
                    icon: "success"
                });
                GET_DATA_PRODUCT();
            }
        });
    }
    else {
        Swal.fire({
            title: "Advertencia",
            text: "Seleccione un producto",
            icon: "warning"
        });
    }
}


/* -------- [ AGREGAR - Producto ] -------- */
$("#btnAgregarMod").click(function () {
    ADD_DATA_PRODUCT();
});

function ADD_DATA_PRODUCT() {

    var inpCodMod      = $("#inpCodMod").val();
    var inpDescMod     = $("#inpDescMod").val();
    var inpPrecioMod   = $("#inpPrecioMod").val();
    var inpCantidadMod = $("#inpCantidadMod").val();

    if (inpCodMod != "" && inpDescMod != "" && inpPrecioMod != "" && inpCantidadMod != "") {
        $.ajax({
            method: "POST",
            url: "/Producto/ADD_DATA_PRODUCT",
            data: {
                inpCodMod,
                inpDescMod,
                inpPrecioMod,
                inpCantidadMod
            },
            success: function (result) {
                $("#inpCodMod").val("");
                $("#inpDescMod").val("");
                $("#inpPrecioMod").val("");
                $("#inpCantidadMod").val("");
                Swal.fire({
                    title: "Success",
                    text: "Se agrego con existo",
                    icon: "success"
                });
                GET_DATA_PRODUCT();
            }
        });
    }
    else {
        Swal.fire({
            title: "Advertencia",
            text: "Ingrese todos los datos",
            icon: "warning"
        });
    }
}

