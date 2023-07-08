function changeprovince() {

    var selectedprovince = $("#input-province").val();

    var provinceId = {
        provinceId: selectedprovince
    };
    var base_url = window.location.origin;
    $.ajax(base_url + '/Cart/CityViewComponent',
        {
            data: provinceId,
            dataType: 'html', // type of response data
            timeout: 500,     // timeout milliseconds
            success: function (html, status, xhr) {   // success callback function
                $(".city-component-container").html(html);
            //    ReloadBills();
            },
            error: function (jqXhr, textStatus, errorMessage) { // error callback

            }
        });
}
function changeProvinceEdit(IdEditAddress) {

    let provinceId = $(".input-province-edit").val();
    let addressId = IdEditAddress;
    var data = {
        provinceId, addressId
    };
    console.log(data);
    var base_url = window.location.origin;
    $.ajax(base_url + '/Cart/EditCityViewComponent',
        {
            data: data,
            dataType: 'html', // type of response data
            timeout: 500,     // timeout milliseconds
            success: function (html, status, xhr) {   // success callback function
                $("#edit-city-component-container").html(html);
                //    ReloadBills();
            },
            error: function (jqXhr, textStatus, errorMessage) { // error callback

            }
        });
}
