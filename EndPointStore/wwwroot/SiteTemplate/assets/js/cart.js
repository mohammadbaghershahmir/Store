function AddToCart(productId) {
    let count = 1;
    let model = { productId, count }
    ajaxFunc("/Cart/AddToCart", model, "POST",
        function (result) {
            console.log(result);
            if (result.isSuccess) {
                Toastify({
                    text: result.message,
                    className: "successs",
                    style: {
                        background: "linear-gradient(to right, #00b09b, #96c93d)",
                    }
                }).showToast();
            } else {
                $('.tp-login-btn').text("Login");
                $("#error-login").text(result.message);
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
            console.log(result);
            if (result.isSuccess) {
                Toastify({
                    text: result.message,
                    className: "successs",
                    style: {
                        background: "linear-gradient(to right, #00b09b, #96c93d)",
                    }
                }).showToast();
            } else {
                $('.tp-login-btn').text("Login");
                $("#error-login").text(result.message);
                console.log(result.message);
            }
        },
        function (error) {
            $("#error-login").text(result.message)
            console.log(error);
        }
    );
}
function LowOff(cartItemId) {
    let count = 1;
    let model = { cartItemId, count }
    ajaxFunc("/Cart/LowOff", model, "POST",
        function (result) {
            console.log(result);
            if (result.isSuccess) {
                Toastify({
                    text: result.message,
                    className: "successs",
                    style: {
                        background: "linear-gradient(to right, #00b09b, #96c93d)",
                    }
                }).showToast();
            } else {
                $('.tp-login-btn').text("Login");
                $("#error-login").text(result.message);
                console.log(result.message);
            }
        },
        function (error) {
            $("#error-login").text(result.message)
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
            } else {
                $('.tp-login-btn').text("Login");
                $("#error-login").text(result.message);
            }
        },
        function (error) {
            $("#error-login").text(result.message)
        }
    );
}