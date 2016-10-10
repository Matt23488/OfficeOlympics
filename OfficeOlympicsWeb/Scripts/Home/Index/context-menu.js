$(function () {
    $.createContextMenu(".event-panel",
    function (menuBuilder) {
        menuBuilder.addMenuOption("Enter New '{eventName}' Record", function () {
            var olympicEventId = $(this).children(":hidden").val();

            window.location.href = "/Home/NewRecord/" + olympicEventId;
        });

        menuBuilder.addMenuOption("View '{eventName}' Details", function () {
            toastMessage.showMessage("Coming soon!", "info");
        });

        menuBuilder.addMenuOption("View All Records for '{eventName}'", function () {
            toastMessage.showMessage("Coming soon!", "info");
        });
    },
    function (detailBuilder) {
        detailBuilder.setData("eventName", $(this).children(".event-panel-name").text().trim());
    });
});