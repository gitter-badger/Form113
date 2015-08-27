$(function () {
    $("button.ButtonAjoutPanier").click(AjoutPanier);
});

function AjoutPanier()
{
    var valeur = $("#" + $(this).id.val() + "Qty").val();
    console.log(valeur);
    //localStorage.setItem($(this).id.val(),valeur);
}