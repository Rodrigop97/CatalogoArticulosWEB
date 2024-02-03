function noImage(img) {
    img.src = "img/utilities/noImage.jpg";
}
function change() {
    var imgLocal = document.getElementById("imgLocal");
    var imgInternet = document.getElementById("imgInternet");
    if (imgLocal.classList.contains("d-none"))
        imgLocal.classList.remove("d-none")
    else
        imgLocal.classList.add("d-none")
    if (imgInternet.classList.contains("d-none"))
        imgInternet.classList.remove("d-none")
    else
        imgInternet.classList.add("d-none")
}
function cargarImgLocal(input) {
    var img = document.getElementsByClassName("object-fit-contain")[0];
    var file = input.files[0];
    console.log(img);
    console.log(file);
    if (file) {
        const reader = new FileReader();
        reader.onload = function (e) {
            img.src = e.target.result;
        }
        reader.readAsDataURL(file);
    }
}
function cargarImgWeb(input) {
    if (input.value)
        document.getElementsByClassName("object-fit-contain")[0].src = input.value;
}