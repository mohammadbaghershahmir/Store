function AddToCart(productId) {
    let count = 1;
    let model = { productId, count }
    ajaxFunc("/Cart/AddToCart", model, "POST",
        function (result) {
            if (result.isSuccess) {
                Toastify({
                    text: result.message,
                    className: "successs",
                    style: {
                        background: "linear-gradient(to right, #00b09b, #96c93d)",
                    }
                }).showToast();
                GetListCart();
                GetBacket()
            } else {
                console.log(result.message);
            }
        },
        function (error) {
            $('.tp-login-btn').text("Login");
            $("#error-login").text(result.message)
            console.log(error);
        }
    );
}
function Add(cartItemId) {
    let count = 1;
    let model = { cartItemId, count }
    ajaxFunc("/Cart/Add", model, "POST",
        function (result) {
            if (result.isSuccess) {
                Toastify({
                    text: result.message,
                    className: "successs",
                    style: {
                        background: "linear-gradient(to right, #00b09b, #96c93d)",
                    }
                }).showToast();
                GetListCart();
                GetBacket()
            } else {
                console.log(result.message);
            }
        },
        function (error) {
            console.log(error);
        }
    );
}
function LowOff(cartItemId) {
    let count = 1;
    let model = { cartItemId, count }
    ajaxFunc("/Cart/LowOff", model, "POST",
        function (result) {
            if (result.isSuccess) {
                Toastify({
                    text: result.message,
                    className: "successs",
                    style: {
                        background: "linear-gradient(to right, #00b09b, #96c93d)",
                    }
                }).showToast();
                GetListCart();
                GetBacket()
            } else {
                console.log(result.message);
            }
        },
        function (error) {
            console.log(error);
        }
    );
}
function RemoveFromCard(productId) {
    let model = {productId}
    ajaxFunc("/Cart/RemoveFromCard", model, "POST",
        function (result) {
            if (result.isSuccess) {
                Toastify({
                    text: result.message,
                    className: "successs",
                    style: {
                        background: "linear-gradient(to right, #00b09b, #96c93d)",
                    }
                }).showToast();
                GetListCart();
                GetBacket()
            } else {
            }
        },
        function (error) {
        }
    );
}
function GetListCart() {
    var base_url = window.location.origin;
    console.log(base_url)
    $.ajax(base_url +'/Cart/CartViewComponent',
        {
            dataType: 'html', // type of response data
            timeout: 500,     // timeout milliseconds

            success: function (html, status, xhr) {   // success callback function     
                $("#viewcomponent-cart").html(html);

            },
            error: function (jqXhr, textStatus, errorMessage) { // error callback
            }
        });
}
function GetBacket() {
    var base_url = window.location.origin;
    console.log(base_url)
    $.ajax(base_url + '/Cart/BacketViewComponent',
        {
            dataType: 'html', // type of response data
            timeout: 500,     // timeout milliseconds

            success: function (html, status, xhr) {   // success callback function     
                $("#viewcomponent-backet").html(html);

            },
            error: function (jqXhr, textStatus, errorMessage) { // error callback
            }
        });
}
