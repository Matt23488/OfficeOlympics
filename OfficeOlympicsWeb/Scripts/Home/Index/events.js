$(function () {
    var olympicsHub = $.connection.olympicsHub;

    $(".event-panel").click(function () {
        $.invokeMenuOption(".event-panel", this, 0);
    });

    $("#newRecordForm #cancelButton").click(function () {
        $("#newRecordModal").modal("hide");
    });

    $("#newRecordForm").submit(function (e) {
        e.preventDefault();
        if (!$(this).valid()) return false;

        var newRecord = {
            Event: {
                EventId: $("#Event_EventId", this).val(),
                EventName: $("#Event_EventName", this).val(),
                EventTypeId: $("#Event_EventTypeId", this).val()
            },
            Record: {
                Competitor: {
                    CompetitorId: $("#Record_Competitor_CompetitorId :selected", this).val(),
                    FirstName: $("#Record_Competitor_CompetitorId :selected", this).text().split(" ")[0],
                    LastName: $("#Record_Competitor_CompetitorId :selected", this).text().split(" ")[1]
                },
                Score: {
                    EventType: $("#Event_EventTypeId", this).val(),
                    Score: $("#Record_Score_Score", this).val()
                },
                Witness1: {
                    CompetitorId: $("#Record_Witness1_CompetitorId :selected", this).val(),
                    FirstName: $("#Record_Witness1_CompetitorId :selected", this).text().split(" ")[0],
                    LastName: $("#Record_Witness1_CompetitorId :selected", this).text().split(" ")[1]
                },
                Witness2: {
                    CompetitorId: $("#Record_Witness2_CompetitorId :selected", this).val(),
                    FirstName: $("#Record_Witness2_CompetitorId :selected", this).text().split(" ")[0],
                    LastName: $("#Record_Witness2_CompetitorId :selected", this).text().split(" ")[1]
                },
            }
        };

        $.ajax({
            type: "POST",
            url: "/Ajax/NewRecord",
            data: newRecord,
            success: function (data, status, xhr) {
                if (data === true) {
                    toastMessage.showMessage("Record entered successfully!", "success");
                    olympicsHub.server.recordBroken(newRecord);
                }
                else {
                    toastMessage.showMessage("Record did not save.", "danger");
                }
            }
        })

        $("#newRecordModal").modal("hide");
    });

    $("#newRecordModal").on("hidden.bs.modal", function () {
        $("#newRecordForm").clearForm();
    });
});