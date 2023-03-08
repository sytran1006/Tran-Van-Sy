function hideForm() {
    document.querySelector(".container").style.display = "none";
}
function openCV() {
    document.querySelector('.container').style.display="block";
}
function download(content, fileName, contentType) {
    var a = document.createElement("a");
    var file = new Blob([content], { type: contentType });
    a.href = URL.createObjectURL(file);
    a.download = fileName;
    a.click();
}