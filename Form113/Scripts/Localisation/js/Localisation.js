$(function () {
    ChosenFinish();
    $("#idContinent").change(ListeDesRegions);
    $("#idRegions").change(ListeDesPays);
});
function ListeDesRegions() {
    $(".chosen-select").trigger("chosen:updated");
    var idcont = $("#idContinent").val();
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
    $(".chosen-select").trigger("chosen:updated");
    var idreg = $("#idRegions").val();
    var option = "";
    $.getJSON('/Localisation/GetJSONPAYS/' + idreg, function (data) {
        $.each(data, function (index, pay) {
            option += '<option value="' + pay.np + '">' + pay.pay + '</option>';
        });
        $("#idPays").html(option);
    });
}
function ChosenFinish() {
    $(".chosen-select").chosen();
}
