$(function () {
    var olympicsHub = $.connection.olympicsHub;

    olympicsHub.client.refreshRecords = function (eventId) {
        $.ajax({
            type: "GET",
            cache: false,
            url: "/Home/TopThree",
            data: { eventId: eventId },
            success: function (data, status, xhr) {
                $("#eventPanel" + eventId).html(data);
                $.reapplyContextMenu(".event-panel");
                $(".event-panel").off("click");
                $(".event-panel").click(function () {
                    $.invokeMenuOption(".event-panel", this, 0);
                });
                $(".modal").modal("hide");
            }
        });
    };
    olympicsHub.client.refreshBoard = function () {
        $.ajax({
            type: "GET",
            cache: false,
            url: "/Home/IndexPartial",
            success: function (data, status, xhr) {
                $("#pageContent").html(data);
                $.reapplyContextMenu(".event-panel");
                $(".event-panel").off("click");
                $(".event-panel").click(function () {
                    $.invokeMenuOption(".event-panel", this, 0);
                });
                $(".modal").modal("hide");
            }
        });
    };
});