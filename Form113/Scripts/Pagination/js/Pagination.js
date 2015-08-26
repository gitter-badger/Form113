$(function () {
    $("#FirstPage").click(function () {
        $("#idCurrentPage").val(1);
        $("#idFormPagination").submit();
        return false;
    });

    $("#CurrentPage1").click(function () {
        var valeur = parseInt($("#idCurrentPage").val()) - 1;
        if ($("#idCurrentPage").val() != 1) {
            $("#idCurrentPage").val(valeur);
            $("#idFormPagination").submit();
        }
        return false;
    });

    $("#CurrentPage2").click(function () {
        var valeur = parseInt($("#idCurrentPage").val()) + 1;
        if ($("#idCurrentPage").val() != $("#idLastPage").val()) {
            $("#idCurrentPage").val(valeur);
            $("#idFormPagination").submit();
        }
        return false;
    });

    $("#LastPage").click(function () {
        $("#idCurrentPage").val($("#idLastPage").val());
        $("#idFormPagination").submit();
        return false;
    });

    $("a.pageLink").click(function () {
        $("#idCurrentPage").val($(this).html());
        $("#idFormPagination").submit();
        return false;
    });
});
