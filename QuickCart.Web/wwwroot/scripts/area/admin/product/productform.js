

// start function

function handleCategoryChange() {
    $("#categoryList").on("change", function () {
        GetSubCategories();

    });
}


// start handle new  image

function handleFileSelect(event) {
    var files = event.target.files;
    $('#selectedImagesContainer').html('');
    for (var i = 0; i < files.length; i++) {
        var file = files[i];
        previewImage(file);
    }
}


function previewImage(file) {
    var reader = new FileReader();

    reader.onload = function (event) {
        var imgElement = createImageElement(event.target.result);
        $('#selectedImagesContainer').append(imgElement);
    }

    reader.readAsDataURL(file);
}


function createImageElement(src) {
    var imgElement = '<div class="mb-2 col-3 mb-2">';
    imgElement += '<img class="img-thumbnail" src="' + src + '" style="max-width: 150px; max-height: 150px;" />';
    imgElement += '<button type="button" class="btn btn-sm btn-danger delete-image">Remove</button>';
    imgElement += '</div>';
    return imgElement;
}

function onChangeImages() {
    $('#imagesInput').on('change', handleFileSelect);

    $('#selectedImagesContainer').on('click', '.delete-image', function () {
        $(this).closest('div').remove();
        $('#imagesInput').val('');
    });
}
// end handle new  image

// start handle current image

function removeCurrentImage() {
    $(document).on('click', '.delete-current-image', function () {
        var fileUrl = $(this).closest('.current-image-container').data('fileurl');

        $(this).closest('.current-image-container').remove();

        var removedImagesInput = $('#filesNameToRemove');
        console.log('Removed Images Input:', removedImagesInput);

        var removedImages = removedImagesInput.val();
        if (removedImages) {
            removedImages += "," + fileUrl;
        } else {
            removedImages = fileUrl;
        }

        removedImagesInput.val(removedImages);
    });
}




// end handle current image 

// end function
// Start service
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

function GetSubCategories() {
    var selectedCategory = document.getElementById("categoryList").value;
    if (!selectedCategory) {
        selectedCategory = $("#selectedCategoryId").val();
    }
    console.log(selectedCategory);
    $.ajax({
        url: '/api/SubCategories/GetSubCategories/' + selectedCategory,
        type: 'GET',
        contentType: 'application/json',
        success: function (response) {

            $list = $('#subCategoryList');
            if (response && response.success && response.data) {

          
                var items = '';
                var selectedSubCategoryId = $("#selectedSubCategoryId").val();
                response.data.forEach(function (subCategory) {

                    var isSelected = subCategory.value === selectedSubCategoryId;
                    items += '<option value="' + subCategory.value + '"' + (isSelected ? ' selected' : '') + '>' + subCategory.text + '</option>';
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
// End service

// Start call services and functions

    $(document).ready(function () {
        GetCategories();
        GetSubCategories();
        handleCategoryChange();
        onChangeImages();
        removeCurrentImage();
    });

// End call services and functions
