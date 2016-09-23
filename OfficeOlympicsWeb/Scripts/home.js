$(function () {
    var recordHub = $.connection.recordHub;

    recordHub.client.updateRecords = function (recordView) {
        $("#recordListContainer").html(recordView);
    };
});