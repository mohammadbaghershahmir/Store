function ajaxFunc(url, data, type, callback, error) {
     $.ajax({
        type: type,
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: callback,
        error: error
    });
}
var successToastify = Toastify({
    node: $("#success-notification-content").clone().removeClass("hidden")[0],
    duration: 3000,
    newWindow: true,
    close: true,
    gravity: "top",
    position: "right",
    stopOnFocus: true
});

var dangerToastify = Toastify({
    node: $("#failed-notification-content").clone().removeClass("hidden")[0],
    duration: 3000,
    newWindow: true,
    close: true,
    gravity: "top",
    position: "right",
    stopOnFocus: true
});
