$(function () {
    $.createContextMenu(".event-panel",
    function (menuBuilder) {
        menuBuilder.addModalTriggerOption("Enter New '{eventName}' Record", "newRecordModal", function (modal) {
            $(".event-name", modal).text($(this).children(".event-panel-name").text().trim());
            
            $("#newRecordForm #Event_EventId").val($("#Event_EventId", this).val());
            $("#newRecordForm #Event_EventTypeId").val($("#Event_EventTypeId", this).val());
        });

        menuBuilder.addModalTriggerOption("View '{eventName}' Details", "eventDetailsModal", function (modal) {
            $(".event-name", modal).text($(this).children(".event-panel-name").text().trim());

            $("#Description", modal).text($("#Event_Description", this).val());
            $("#Specification", modal).text($("#Event_Specification", this).val());
        });

        menuBuilder.addMenuOption("View All Records for '{eventName}'", function () {
            toastMessage.showMessage("Coming soon!", "info");
        });
    },
    function (detailBuilder) {
        detailBuilder.setData("eventName", $(this).children(".event-panel-name").text().trim());
    });
});