$(function () {
    InitialiseHidden();
});

function InitialiseHidden() {
    console.log("TOTO");
    var str = "";
    if (localStorage.length != 0) {
        for (var i = 0; i < localStorage.length; i++) {
            var key = localStorage.key(i);
            var valeur = localStorage.getItem(key);
            if (i != 0) {
                str += "/";
            }
            str += key + "," + valeur;
        }
    }
    $("#ListeProduitCommande").val(str);
}