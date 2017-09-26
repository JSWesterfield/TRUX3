if (typeof trux.services === "undefined") {
    trux.services = {
        trucks: {}
    };
}
else {
    trux.services.trucks = {};
}

trux.services.trucks = trux.services.trucks || {};

trux.services.trucks.selectAll = function (onSuccess, onError) {
    var url = '/api/truck';
    var settings = {
        cache: false,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "GET"
    };
    $.ajax(url, settings);
};

trux.services.trucks.save = function (data, onSuccess, onError) {
    var url = '/api/truck';
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        type: "POST",
        data: data,
        success: onSuccess,
        error: onError
    };
    $.ajax(url, settings);
};

trux.services.trucks.update = function (data, onSuccess, onError) {
    var url = '/api/trucks';
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        type: "PUT",
        data: data,
        success: onSuccess,
        error: onError
    };
    $.ajax(url, settings);
};

trux.services.trucks.delete = function (data, onSuccess, onError) {
    var url = '/api/truck?id=' + data;
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        type: "DELETE",
        success: onSuccess,
        error: onError
    };
    $.ajax(url, settings);
};

trux.services.trucks.getById = function (userId, ajaxGetByIdSucces, ajaxError) {
    
    var url = '/api/trux/' + userId;

    var settings = {

        cache: false
            , dataType: "json"
            , success: ajaxGetByIdSucces
            , error: ajaxError
            , type: "GET"
    };

    $ajax(url, settings);
}