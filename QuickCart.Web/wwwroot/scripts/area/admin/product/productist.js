// start initialize Data Table
function initializeDataTable() {
    $('#productDataTable').DataTable({
        "processing": true,
        "serverSide": true,

        "ajax": function (data, callback, settings) {
            GetAllProduct(data, callback, settings);
        },

        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "orderable": false,
                "targets": [1, 2, 3, 4]
            }
        ],
        "columns": [
            { "data": "id" },
            { "data": "name" },
            { "data": "description" },
            { "data": "createdAt" },
            {
                "data": null,
                "orderable": false,
                "render": function (data, type, row) {
                    return `
                        <div class="btn-group" role="group" aria-label="Products Actions">
                            <a href="Products/Edit/${row.id}" class="btn btn-success m-2">Edit</a>
                            <a href="Products/Delete/${row.id}" class="btn btn-danger m-2">Delete</a>
                        </div>
                    `;
                }
            }
        ]
    });
}

function GetAllProduct(data, callback, settings) {
    $.ajax({
        "url": "/api/Products/GetAll",
        "type": 'POST',
        "contentType": 'application/json',
        "dataType": 'json',
        "data": JSON.stringify(data),
        "success": function (response) {
            callback(response);
        },
        "error": function (xhr, status, error) {
            // Handle error here
            console.error('Error fetching data:', error);
        }
    });
}
$(document).ready(function () {
    initializeDataTable();
});
