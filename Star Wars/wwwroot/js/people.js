var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#D_load').DataTable({
        "ajax": {
            "url": "People/Select",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "16%" },
            { "data": "height", "width": "16%" },
            { "data": "mass", "width": "16%" },
            { "data": "skin_color", "width": "16%" },
            { "data": "eye_color", "width": "16%" },
            {
                "data": "url",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/People/Details?id=${data.substr(-2,1)}" target="_blank" class='btn btn-success' style='cursor:pointer;width:70px;'>
                          Details
                        </a>
                        &nbsp;
                        </div>`;
                }, "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });

}


function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Deleting is final,you will not recover",
        icon: "warning",
        buttons: true,
        dangerMode:true
    }).then((willdelete) => {
        if (willdelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }

    });

}