$(function () {
    AfficheProduit();
    $("input.ButtonViderPanier").click(ViderPanier);
    VerifButton();
});

function AfficheProduit() {
    $("#JQ").html("");
    if (localStorage.length != 0) {

        for (var i = 0; i < localStorage.length; i++) {
            var key = localStorage.key(i);
            UnProduit(key,i);
        }
    }
    else {
        $("#JQ").html('<p>Votre Panier est Vide !</p>');
    }
}

function UnProduit(id,tour) {

    $.getJSON('/Panier/GetJSONPROD/' + id, function (produit) {
        var valeur = localStorage.getItem(id);

        if (tour % 2 == 0)
        {
            var str = '<div class="row panel panel-info">';

        }
        else
        {    
            var str = '<div class="row panel panel-success">';
        }
        str += '<div class="panel-heading">'+produit.prod+'</div>';
        str += '<div class="panel-body">';

        str += '<label for="' + id + '" class="col-sm-2">Quantité : </label>';
        str += '<input class="form-control col-sm-6 Quantiter" data-val="true" data-val-number="Le champ Quantité doit être un nombre." data-val-required="Le champ Quantité est requis." id="' + id + '" name="IdProduit" value="' + valeur + '" type="text">';
        str += '<label for="' + id + '" class="col-sm-2">' + produit.prix * valeur + ' €</label>';
        str += '<input type="button" class="ButtonMaj" value="Modifier Quantité" />';

        str += '</div></div>';

        $("#JQ").html($("#JQ").html() + str);

        $("input.ButtonMaj").click(MajQty);
    })
}

function MajQty() {
    var valeur = $(this).parent().find("input.Quantiter");
    localStorage.setItem(valeur.attr("id"), valeur.val());
    AfficheProduit();
}

function ViderPanier() {
    if (confirm("Voulez vous vraiment vider votre panier ?")) {
        localStorage.clear();
    }
    AfficheProduit();
    VerifButton();
}

function VerifButton() {
    if (localStorage.length == 0) {
        $("#button").hide();
    }
}