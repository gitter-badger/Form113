$(function () {
    ChosenFinish();
    ListeDesRegions();
    $("#idContinent").change(ListeDesRegions);
    $("#idRegions").change(ListeDesPays);
});
function ListeDesRegions() {
    var idcont = $("#idContinent").val();
    var idPreSelectR = $("#idR").val().split("/");
    var option = "";
    $.getJSON('/Localisation/GetJSONREG/' + idcont, function (data) {
        $.each(data, function (index, reg) {
            option += '<option value="' + reg.nr + '">' + reg.reg + '</option>';
        });
        $("#idRegions").html(option);
        $("#idPays").val();
        ListeDesPays();
    });
}
function ListeDesPays() {
    var idreg = $("#idRegions").val();
    var idPreSelectP = $("#idP").val().split("/"); 
    array = array.concat(idPreSelectP);
    var selected = "";
    var option = "";
    $.getJSON('/Localisation/GetJSONPAYS/' + idreg, function (data) {
        $.each(data, function (index, pay) {
            option += '<option value="' + pay.np + '">' + pay.pay + '</option>';
        });
        $("#idPays").html(option);
        UpdateChosen();
    });
}

function UpdateChosen() {
    $(".chosen-select").trigger("chosen:updated");
}
function ChosenFinish() {
    $(".chosen-select").chosen();
}
