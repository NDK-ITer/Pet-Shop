function ShowImagePreview(imgUpLoader, previewImage) {
    if (imgUpLoader.files && imgUpLoader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imgUpLoader.filer[0]);
    }
}