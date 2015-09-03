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
            str += key + "," + valeur;
        }
    }
    $("input.ListeProduitCommande").val(str);
}