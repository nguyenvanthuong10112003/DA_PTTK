function toUrlAjax(type = "POST", data, url, success, error) {
    $.ajax(
        {
            type: type,
            data: data,
            url: url,
            dataType: "json",
            success: success,
            error: error
        }
    )
}