$(function () {
    $("input.ButtonAjoutPanier").click(AjoutPanier);
    $("a.Comment").click(Comment);
    $("a.Reply").click(Repondre);
    $("#ZoneCommenter").hide();
});

function AjoutPanier() {
    var valeur = $(this).parent().parent().find("input.Quantiter");
    //console.log(valeur.val());
    //console.log(valeur.attr("id"));
    localStorage.setItem(valeur.attr("id"), valeur.val());
    //console.log(sessionStorage);
}

function Comment() {
    var valeur = $("#IdProduit").val();
    $("#ComProduit").val(valeur);
    $("#ComCom").val(null);

    $("#ZoneCommenter").show();
}
function Repondre() {
    var valeurP = $("#IdProduit").val();
    $("#ComProduit").val(valeurP);

    var valeurC = $(this).parent().parent().children(".IdCom").val();
    $("#ComCom").val(valeurC);
    $("#ZoneCommenter").show();

}