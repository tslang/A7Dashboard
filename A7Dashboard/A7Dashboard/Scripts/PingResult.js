$(function () {
    var notification = $.connection.pingResultHub;

    notification.client.addPingResultToPage = function (statusCode, statusDescription, server, responseUri, responseStatus) {

        var tbl = $('#pingResultTable"');
        $.ajax({
            url: '/api/pingResult',
            type: 'GET',
            dataType: 'json',
            cache: false,
            contentType: 'application/json'
        }).success(function (result) {
            if (result.length > 0) {
                tbl.empty();
                tbl.append('<tr><th>StatusCode</th><th>Status Description</th><th>Server</th><th>Response Uri</th><th>Response Status</th></tr>');
                var rows = [];
                for (var i = 0; i < result.length; i++) {
                    rows.push(' <tr><td>' + result[i].StatusCode + '</td><td>' + result[i].StatusDescription + '</td><td>' + result[i].Server + '</td><td> ' + result[i].ResponseUri + '</td><td>' + result[i].ResponseStatus + '</td></tr>');

                }
                tbl.append(rows.join(''));
            }
        });


        $.connection.hub.start().done(function () {
                notification.server.getAllPingResults();
            })
            .fail(function (e) {
                alert(e);
            });
    }
});















//$(function () {

//    // 
//    var notifications = $.connection.pingHub;

//    // UPDATE PINGRESULT
//    notifications.client.addResultToPage = function (statusCode, statusDescription, server, responseUri, responseStatus) {
//        var tbl = $('pingResultTable');
//        $.ajax({
//            url: 'api/pingResult',
//            type: 'GET',
//            contentType: 'application/json',
//            dataType: 'json'
//        }).success(function (result) {
//            tbl.empty().append(result);
//        }).error(function () {

//        });
//    };

//    // Establish Connection
//    $.connection.hub.start()
//        .done(function () {
//            alert('connection started')
//            getAllResults();
//        })
//        .fail(function (e) {
//            alert(e);
//        });
//});

