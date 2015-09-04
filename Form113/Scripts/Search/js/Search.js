$(function () {
    Slider();
    ListeDesSousCategorie();
    $("#idCategories").change(ListeDesSousCategorie);
});

function Slider() {
    $("#SliderRange").slider({
        range: true,
        min: 0,
        step: 10,
        values: [$("#Prixmin").val(), $("#PrixMaxSlider").val()],
        slide: function (event, ui) {
            $("#amount").val(ui.values[0] + " € - " + ui.values[1] + " €");
            $("#Prixmin").val(ui.values[0]);
            $("#Prixmax").val(ui.values[1]);
        }
    });

    $("#SliderRange").slider("option", "max", $("#PrixMaxSlider").val());

    if ($("#Prixmin").val != null || $("#Prixmax").val != null) {
        $("#amount").val($("#Prixmin").val() + " € - " + $("#PrixMaxSlider").val() + " €");
    }
    else {
        $("#amount").val($("#SliderRange").slider("values", 0) + " € - " + $("#SliderRange").slider("values", 1) + " €");
        $("#Prixmin").val($("#SliderRange").slider("values", 0));
        $("#Prixmax").val($("#SliderRange").slider("values", 1));
    }
}

function ListeDesSousCategorie() {
    var idcat = $("#idCategories").val();
    var idPreSelectSC = $("#idSC").val().split('/');
    var option = "";
    $.getJSON('/Search/GetJSONSCAT/' + idcat, function (data) {
        $.each(data, function (index, scat) {
            if ($.inArray("" + scat.nc, idPreSelectSC) >= 0) {
                option += '<option selected value="' + scat.nc + '">' + scat.scat + '</option>';
            }
            else {
                option += '<option value="' + scat.nc + '">' + scat.scat + '</option>';
            }
        });
        $("#idSousCategories").html(option);
        UpdateChosen();
    });
}

function UpdateChosen() {
    $(".chosen-select").trigger("chosen:updated");
}