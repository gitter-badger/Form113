$(function () {
    ChosenFinish();
    ListeDesRegions();
    $("#idContinent").change(ListeDesRegions);
    $("#idRegions").change(ListeDesPays);
});
function ListeDesRegions() {
    var idcont = $("#idContinent").val();
    var idPreSelectR = $("#idR").val().split('/');
    var option = "";
    $.getJSON('/Localisation/GetJSONREG/' + idcont, function (data) {
        $.each(data, function (index, reg) {
            if ($.inArray(""+reg.nr, idPreSelectR) >= 0) {
                option += '<option selected value="' + reg.nr + '">' + reg.reg + '</option>';
            }
            else {
                option += '<option value="' + reg.nr + '">' + reg.reg + '</option>';
            }
        });
        $("#idRegions").html(option);
        $("#idPays").val();
        ListeDesPays();
    });
}
function ListeDesPays() {
    var idreg = $("#idRegions").val();
    var idPreSelectP = $("#idP").val().split('/');
    var option = "";
    $.getJSON('/Localisation/GetJSONPAYS/' + idreg, function (data) {
        $.each(data, function (index, pay) {
            if ($.inArray(pay.np, idPreSelectP) >= 0) {
                option += '<option selected value="' + pay.np + '">' + pay.pay + '</option>';
            }
            else {
                option += '<option value="' + pay.np + '">' + pay.pay + '</option>';
            }
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
