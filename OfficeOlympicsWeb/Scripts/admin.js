$(function () {
    // extensions

    // event handlers
    $(".event-item").on("click", function () {
        beginEditEvent(this);
    });

    // functions
    var beginEditEvent = function (eventItem) {
        cancelEditEvent($(".event-item-editable"));

        var $eventItem = $(eventItem);

        //$eventItem.off("click");
        $eventItem.hide();

        $.ajax({
            type: "GET",
            url: "/Admin/EditEvent",
            data: { olympicEventId: $(".hidden-event-id", $eventItem).val() },
            success: function (data) {
                var $eventItemEdit = $("<tr>").addClass("event-item-editable");//.append(data)

                $eventItemEdit.append($("<td>").attr("colspan", 2).append(data));

                $eventItem.after($eventItemEdit);

                $("#cancelButton").on("click", function () {
                    cancelEditEvent($eventItemEdit);
                });
            },
            error: function () {
                alert("Something happened");
            }
        });
    };
    var cancelEditEvent = function ($eventItemEdit) {
        //var $eventItem = $(eventItem);

        //$eventItem.next().remove();
        //$eventItem.show();

        var $eventItem = $eventItemEdit.prev();

        $eventItemEdit.remove();
        $eventItem.show();
    }
});