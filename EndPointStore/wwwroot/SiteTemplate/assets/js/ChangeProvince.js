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
