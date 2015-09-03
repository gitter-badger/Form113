$(function () {
    ListeDesVilles();
    $("#ListeDepartements").change(ListeDesVilles);
    ChosenFinish();
});

function ListeDesVilles() {
    var iddep = $("#ListeDepartements").val();
    console.log(iddep);
    var option = "";
    $.getJSON('/Localisation/GetJSONVILLE/' + iddep, function (data) {
        $.each(data, function (index, ville) {
            option += '<option value="' + ville.idv + '">' + ville.nom + '</option>';
        });
        $("#idville").html(option);
        UpdateChosen();
    });
}
function UpdateChosen() {
    $(".chosen-select").trigger("chosen:updated");
}
function ChosenFinish() {
    $(".chosen-select").chosen();
}
