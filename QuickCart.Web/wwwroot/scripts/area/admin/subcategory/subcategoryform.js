function GetCategories() {

    $.ajax({
        url: '/api/Categories/GetCategories',
        type: 'GET',
        contentType: 'application/json',
        success: function (response) {

            $list = $('#categoryList');
            if (response && response.success && response.data) {

                var initialOption = '<option value="" selected disabled>-- Select Category --</option>';

                var items = initialOption;
                var selectedCategoryId = $("#selectedCategoryId").val();
                response.data.forEach(function (category) {

                    var isSelected = category.value === selectedCategoryId;
                    items += '<option value="' + category.value + '"' + (isSelected ? ' selected' : '') + '>' + category.text + '</option>';
                });
                $list.html(items);
            } else {
                console.error('Error retrieving categories:', data.Message);
            }
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
        }
    });
}


// Start call services and functions

$(document).ready(function () {
    GetCategories();

});

// End call services and functions
