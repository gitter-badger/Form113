$('input.single-checkbox').click(Verif);
function Verif() {
    var limit = 6;
    if ($('.single-checkbox:checked').length > limit) {
        this.checked = false;
        alert("Vous ne pouvez comparer que " + limit + " voiture en même temps !");
    }
}