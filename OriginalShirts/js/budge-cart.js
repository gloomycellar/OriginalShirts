var BudgeCart = {
    reload: function () {
        var url = "/Cart/GetCartCount";
        $.get(url).success(function (res) {
            if (res) {
                $("#cart-budge").text(res);
                $("#cart-budge").show();
            } else {
                $("#cart-budge").hide();
            }
        }).fail(function () {
            $("#cart-budge").hide();
        })
    }
}

$(document).ready(function () {
    BudgeCart.reload();
})