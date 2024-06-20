// start initialize Data Table
function initializeDataTable() {
    $('#productDataTable').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/api/Products/GetAll",
            "type": 'GET',
            "dataSrc": function (json) {

                var data = json.data;
                if (Array.isArray(data)) {
                    return data;
                }
                console.error('Unexpected JSON structure:', json);
                return [];
            },
            "error": function (xhr, status, error) {
                console.error(`Error: ${error}`);
                console.error(`Status: ${status}`);
                console.error(`Response: ${xhr.responseText}`);
            }
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

$(document).ready(function () {
    initializeDataTable();
});
