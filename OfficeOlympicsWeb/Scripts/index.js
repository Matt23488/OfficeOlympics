$(function () {
    // SignalR

    // Event Handlers
    $(".event-panel").click(function () {
        var olympicEventId = $(this).children(":hidden").val();

        window.location.href = "/Home/NewRecord/" + olympicEventId;
    });
});