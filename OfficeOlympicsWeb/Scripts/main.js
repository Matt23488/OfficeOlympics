$(function () {
    // SignalR
    var recordHub = $.connection.recordHub;
    $.connection.hub.start().done(function () {
        Cookies.set("conn-id", $.connection.recordHub.connection.id);
    });

    recordHub.client.recordBroken = function (recordViewModel) {
        alert("The record for " + recordViewModel.Event + " has been broken by " + recordViewModel.RecordHolder + "!");
    };
});