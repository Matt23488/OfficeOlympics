$(function () {
    $.createContextMenu(".event-panel",
    function (menuBuilder) {
        menuBuilder.addModalTriggerOption("Enter New '{eventName}' Record", "newRecordModal", function (modal) {
            $(".modal-title", modal).text("New Record - " + $(this).children(".event-panel-name").text().trim());
            
            $("#newRecordForm #Event_EventId").val($("#Event_EventId", this).val());
            $("#newRecordForm #Event_EventTypeId").val($("#Event_EventTypeId", this).val());
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