$(function () {
    
    var pingResultHub = $.connection.pingResultHub;

    pingResultHub.client.addPingResultToPage = function () {
        updatePingResult()

    };


    $.connection.hub.start().done(function () {
        //pingResultHub.server.SendNotification
        alert("connection started")
        updatePingResult();
    }).fail(function (e) {
        alert(e);
    });


    function updatePingResult(pingResult) {
        var tbl = $('#pingResultTable');
        $.ajax({
            url: '/home/Status',
            contentType: 'application/html ; charset:utf-8',
            type: 'GET',
            dataType: 'html'
        }).success(function (result) {
            tbl.empty().append(result);
        }).error(function () {

        });
    }

})