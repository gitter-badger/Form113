$(function () {
    InitialiseHidden();
});

function InitialiseHidden() {
    var str = "";
    if (localStorage.length != 0) {
        for (var i = 0; i < localStorage.length; i++) {
            var key = localStorage.key(i);
            var valeur = localStorage.getItem(key);
            if (i != 0) {
                str += "/";
            }

            UnProduit(key, i);

            str += key + "," + valeur;
        }
    }
    $("input.ListeProduitCommande").val(str);
}

function UnProduit(id, tour) {

    $.ajax({
        url: '/Panier/GetJSONPROD/' + id,
        dataType: 'json',
        async: false,

    }).done(function (produit) {
        var valeur = localStorage.getItem(id);

        console.log(id);
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
    })
}