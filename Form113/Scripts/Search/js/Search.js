$(function () {
    Slider();

});
function Slider() {

    $("#SliderRange").slider({
        range: true,
        min: 0,
        step: 1000,
        values: [$("#Prixmin").val(), $("#Prixmax").val()],
        slide: function (event, ui) {
            $("#amount").val(ui.values[0] + " € - " + ui.values[1] + " €");
            $("#Prixmin").val(ui.values[0]);
            $("#Prixmax").val(ui.values[1]);
        }
    });

    $("#SliderRange").slider("option", "max", $("#PrixMaxSlider").val());

    if ($("#Prixmin").val != null || $("#Prixmax").val != null) {
        $("#amount").val($("#Prixmin").val() + " € - " + $("#Prixmax").val() + " €");
    }
    else {
        $("#amount").val($("#SliderRange").slider("values", 0) + " € - " + $("#SliderRange").slider("values", 1) + " €");
        $("#Prixmin").val($("#SliderRange").slider("values", 0));
        $("#Prixmax").val($("#SliderRange").slider("values", 1));
    }
}