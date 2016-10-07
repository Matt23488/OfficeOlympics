$(function () {
    // SignalR

    // Event Handlers
    $(".event-panel").click(function () {
        var olympicEventId = $(this).children(":hidden").val();

        window.location.href = "/Home/NewRecord/" + olympicEventId;
    });

    // Context Menu
    $.createContextMenu(".event-panel", function (menuBuilder) {
        menuBuilder.addMenuOption("Enter New Record", function () {
            var olympicEventId = $(this).children(":hidden").val();

            window.location.href = "/Home/NewRecord/" + olympicEventId;
        });

        menuBuilder.addMenuOption("View Event Details", function () {
            toastMessage.showMessage("Coming soon!", "info");
        });

        menuBuilder.addMenuOption("View All Records", function () {
            toastMessage.showMessage("Coming soon!", "info");
        });
    });
});