$(function () {
    // SignalR
    var recordHub = $.connection.recordHub;
    $.connection.hub.start();


    recordHub.client.displayMessage = function (message, messageType) {
        window.toastMessage.showMessage(message, messageType);

        var recentRecordListContainer = $("#recentRecordListContainer");

        if (recentRecordListContainer[0]) {
            $.ajax({
                type: "GET",
                cache: false,
                url: "/Home/RecentRecords",
                success: function (data, status, xhr) {
                    recentRecordListContainer.html(data);
                },
                error: function (xhr, status, error) {
                    window.toastMessage.showMessage(error, "danger");
                }
            })
        }
    };
});