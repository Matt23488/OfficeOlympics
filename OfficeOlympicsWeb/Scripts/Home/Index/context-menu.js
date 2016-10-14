$(function () {
    $.createContextMenu(".event-panel",
    function (menuBuilder) {
        menuBuilder.addMenuOption("Enter New '{eventName}' Record", function () {
            var $modal = $("#newRecordModal");
            var eventName = $(this).children(".event-panel-name").text().trim();

            $(".event-name", $modal).text(eventName);

            $("#newRecordForm #Event_EventId").val($("#EventId", this).val());
            $("#newRecordForm #Event_EventName").val(eventName);
            $("#newRecordForm #Event_EventTypeId").val($("#EventTypeId", this).val());

            $modal.modal();
        });

        menuBuilder.addMenuOption("View '{eventName}' Details", function () {
            var $modal = $("#eventDetailsModal");

            $(".event-name", $modal).text($(this).children(".event-panel-name").text().trim());

            $("#Description", $modal).text($("#Description", this).val());
            $("#Specification", $modal).text($("#Specification", this).val());

            $modal.modal();
        });

        menuBuilder.addMenuOption("View All Records for '{eventName}'", function () {
            toastMessage.showMessage("Coming soon!", "info");
        });
    },
    function (detailBuilder) {
        detailBuilder.setData("eventName", $(this).children(".event-panel-name").text().trim());
    });
});