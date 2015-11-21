$(function () {
    
    var pingResultHub = $.connection.pingResultHub;

    pingResultHub.client.addPingResultToPage = function (pingResult) {
        updatePingResult(pingResult)
    }

    $.connection.hub.start().done(function () {
        console.log("Hub component initiated...");
        pingResultHub.server.SendNotification
    });





    function updatePingResult(pingResult) {
        var tbl = $('#pingResultTable');
    }

})