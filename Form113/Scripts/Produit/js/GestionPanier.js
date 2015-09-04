$(function () {
    AfficheProduit();
    $("input.ButtonViderPanier").click(ViderPanier);
    $("input.Quantiter").change(Verif);
    VerifButton();

});

function AfficheProduit() {
    $("#JQ").html("");
    if (localStorage.length != 0) {

        for (var i = 0; i < localStorage.length; i++) {
            var key = localStorage.key(i);
            UnProduit(key, i);
        }

        var prixtotal = parseFloat($("#PrixTotal").val());
        $("#PrixPanier").html("Prix total de votre commande : " + prixtotal + " €");
    }
    else {
        $("#JQ").html('<p>Votre Panier est Vide !</p>');
    }

}

function UnProduit(id, tour) {
    // $.getJSON('/Panier/GetJSONPROD/' + id, function (produit) {
    // GET JSON SYNCRONE
    $.ajax({
        url: '/Panier/GetJSONPROD/' + id,
        dataType: 'json',
        async: false,

    }).done(function (produit) {
        var valeur = localStorage.getItem(id);

        var str = '<div class="row panel panel-info">';
        str += '<div class="panel-heading">' + produit.prod + '</div>';
        str += '<div class="panel-body">';

        str += '<label for="' + id + '" class="col-sm-2">Quantité : </label>';
        str += '<input class="form-control col-sm-6 Quantiter" data-val="true" data-val-number="Le champ Quantité doit être un nombre." data-val-required="Le champ Quantité est requis." id="' + id + '" name="IdProduit" value="' + valeur + '" type="number" max="' + produit.stock + '" min="1">';
        str += '<label for="' + id + '" class="col-sm-2">' + produit.prix * valeur + ' €</label>';
        str += '<input type="button" class="ButtonMaj" value="Modifier Quantité" />';

        str += '</div></div>';

        var valint = 0;
        if (tour != 0) {
            valint = parseFloat($("#PrixTotal").val());
        }
        var prixtotal = valint + (produit.prix * valeur);

        $("#PrixTotal").val(prixtotal);

        // reecrit a chaque fois pour faire un petit effet de style
        $(".PrixPanier").html("Prix total de votre commande : " + prixtotal + " €");

        var test1 = parseInt($("#NbCommande").val());
        var test2 = parseInt($("#NbCommandeFid").val());
        if (test1 >= test2) {
            $(".PrixPanierRemiser").show();
            var prixremiser = prixtotal - (prixtotal * 10 / 100)
            $(".PrixPanierRemiser").html("Votre prix fidelité : " + prixremiser + " €");
        }
        else {
            $(".PrixPanierRemiser").hide;
        }

        $("#JQ").html($("#JQ").html() + str);

        $("input.ButtonMaj").click(MajQty);
    })
}

function MajQty() {
    var valeur = $(this).parent().find("input.Quantiter");

    var max = valeur.attr("max");
    var test = parseInt(valeur.val());
    if (test >= max) {
        valeur.val(max);
    }

    localStorage.setItem(valeur.attr("id"), valeur.val());
    AfficheProduit();
}

function ViderPanier() {
    if (confirm("Voulez vous vraiment vider votre panier ?")) {
        localStorage.clear();
    }
    AfficheProduit();
    $(".PrixPanier").hide();
    VerifButton();
}

function VerifButton() {
    if (localStorage.length == 0) {
        $("#button").hide();
    }
}