$(function () {
    var olympicsHub = $.connection.olympicsHub;

    // event handlers
    $(".event-item").on("click", function () {
        var eventId = $(".hidden-event-id", this).val();
        window.location.href = "/Admin/EditEvent/" + eventId;
    });
    $("#AddEventForm").on("submit", function (e) {
        var form = this;

        var olympicEvent = {
            EventId: 0,
            EventName: $("#Event_EventName").val()
        };

        $.ajax({
            type: "GET",
            cache: false,
            url: "/Ajax/UniqueEventName",
            data: olympicEvent,
            success: function (data, status, xhr) {
                if (data === true) {
                    olympicsHub.server.newEvent(olympicEvent.EventName);

                    form.submit();
                }
                else {
                    toastMessage.showMessage("An event with that name already exists. Please enter a different name.", "danger");
                }
            }
        });

        e.preventDefault();
    });
    $("#EditEventForm").on("submit", function (e) {
        var form = this;

        var submitButton = $("input[type=submit][clicked=true]", this).val();
        var olympicEvent = {
            EventId: $("#Event_EventId").val(),
            EventName: $("#Event_EventName").val()
        };

        $.ajax({
            type: "GET",
            cache: false,
            url: "/Ajax/UniqueEventName",
            data: olympicEvent,
            success: function (data, status, xhr) {
                if (data === true) {
                    if (submitButton === "Save") {
                        olympicsHub.server.editEvent(olympicEvent);
                    }
                    else if (submitButton === "Delete") {
                        olympicsHub.server.deleteEvent(olympicEvent.EventName);
                    }

                    $("[name='submitButton']", form).val(submitButton);
                    form.submit();
                }
                else {
                    toastMessage.showMessage("An event with that name already exists. Please enter a different name.", "danger");
                }
            }
        });

        e.preventDefault();
    });
    $("#AddCompetitorForm").on("submit", function () {
        var name = $("#FirstName").val() + " " + $("#LastName").val();

        olympicsHub.server.newCompetitor(name);

        return true;
    });
    $("#EditCompetitorForm").on("submit", function () {
        var formData = $(this).formData();
        var name = formData.FirstName + " " + formData.LastName;
        var submitButton = $("input[type=submit][clicked=true]", this).val();

        if (submitButton === "Save") {
            olympicsHub.server.editCompetitor(name);
        }
        else if (submitButton === "Delete") {
            olympicsHub.server.deleteCompetitor(name);
        }

        return true;
    });
});