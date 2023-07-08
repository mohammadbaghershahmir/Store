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
                GetBacket();
                GetListCartTable();
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
                GetBacket();
                GetListCartTable();
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
                GetBacket();
                GetListCartTable();

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
                GetBacket();
                GetListCartTable();
            } else {
            }
        },
        function (error) {
        }
    );
}
function GetListCart() {
    var base_url = window.location.origin;
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
function GetListCartTable() {
    var base_url = window.location.origin;
    $.ajax(base_url + '/Cart/CartTableViewComponent',
        {
            dataType: 'html', // type of response data
            timeout: 500,     // timeout milliseconds

            success: function (html, status, xhr) {   // success callback function     
                $("#CartTableContainer").html(html);

            },
            error: function (jqXhr, textStatus, errorMessage) { // error callback
            }
        });
}
function GetListAddress() {
    var base_url = window.location.origin;
    $.ajax(base_url + '/Cart/AddressUserViewComponent',
        {
            dataType: 'html', // type of response data
            timeout: 500,     // timeout milliseconds

            success: function (html, status, xhr) {   // success callback function     
                $("#AddressUserContainer").html(html);

            },
            error: function (jqXhr, textStatus, errorMessage) { // error callback
            }
        });
}
function GetEditAddressUserProvince(id) {

    var addressId = {
        addressId: id
    };
    var base_url = window.location.origin;
    $.ajax(base_url + '/Cart/EditProvinceViewComponent',
        {
            data: addressId,
            dataType: 'html', // type of response data
            timeout: 500,     // timeout milliseconds

            success: function (html, status, xhr) {   // success callback function
                $("#edit-province").html(html);
            },
            error: function (jqXhr, textStatus, errorMessage) { // error callback

            }
        });
    GetEditAddressUserCity(id);
    GetDetailEditAddressUser(id);
    $("#address-edit").modal('show');
}
function GetEditAddressUserCity(id) {
    let provinceId = $(".input-province-edit").val();
    let addressId = id;
    var data ={
        provinceId,addressId
    };
    console.log(provinceId)
    var base_url = window.location.origin;
    $.ajax(base_url + '/Cart/EditCityViewComponent',
        {
            data: data,
            dataType: 'html', // type of response data
            timeout: 500,     // timeout milliseconds

            success: function (html, status, xhr) {   // success callback function
                $("#edit-city-component-container").html(html);
            },
            error: function (jqXhr, textStatus, errorMessage) { // error callback

            }
        });
}
function GetDetailEditAddressUser(id) {
     let provinceId = $(".input-province-edit").val();
    let addressId = id;
    var data ={
        provinceId,addressId
    };
    var base_url = window.location.origin;
    $.ajax(base_url + '/Cart/DetailEditAddressUserViewComponent',
        {
            data: data,
            dataType: 'html', // type of response data
            timeout: 500,     // timeout milliseconds

            success: function (html, status, xhr) {   // success callback function
                $("#edit-detail-component-container").html(html);
            },
            error: function (jqXhr, textStatus, errorMessage) { // error callback

            }
        });
}
