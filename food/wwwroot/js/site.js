// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function onPressAdd() {
    let v = parseInt(document.getElementById("quantity").value) + 1;
    document.getElementById("quantity").value = v;
}
function onPressSub() {
    let v = 0;
    if (parseInt(document.getElementById("quantity").value) > 0) {
        v = parseInt(document.getElementById("quantity").value) - 1;
    }
    document.getElementById("quantity").value = v;
}
