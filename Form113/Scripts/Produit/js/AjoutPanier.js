$(function () {
    $("input.ButtonAjoutPanier").click(AjoutPanier);
    $("a.Reply").click(Repondre);
    $("#ZoneCommenter").hide();
});

function AjoutPanier()
{
    var valeur = $(this).parent().parent().find("input.Quantiter");
    //console.log(valeur.val());
    //console.log(valeur.attr("id"));
    localStorage.setItem(valeur.attr("id"), valeur.val());
    //console.log(sessionStorage);
}

function Repondre()
{    

    $("#ZoneCommenter").show();
}