$(function () {
    // SignalR
    var recordHub = $.connection.recordHub;
    $.connection.hub.start();


    recordHub.client.displayMessage = function (message, messageType) {
        window.toastMessage.showMessage(message, messageType);
    };
});