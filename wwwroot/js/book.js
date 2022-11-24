$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "api/bookctl",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "title", "width": "20%" },
            { "data": "author", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            { "data": "price", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="text-center">
                        <a href="/BookList/Upsert?id=${data}" class="btn btn-info"> Edit</a>
                        <a class = "btn btn-danger" onclick=Delete("api/bookctl?id=${data}")> Delete </a>
                        </div>
                           `;
                }
            }
        ]
    })
}
function Delete(url) {
  //  alert(url);
    swal({
        title: "Want to Delete Data??",
        text: "Delete Record !!",
        buttons: true,
        icon: "warning",
        dangerModel:true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: url,
                type: "DELETE",
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
    })
}