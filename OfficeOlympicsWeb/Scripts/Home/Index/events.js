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

    $("#newRecordForm #Record_Competitor_CompetitorId").on("change", function () {
        var $competitor = $(this);
        var $witness1 = $("#newRecordForm #Record_Witness1_CompetitorId");
        var $witness2 = $("#newRecordForm #Record_Witness2_CompetitorId");

        var competitorId = $(":selected", $competitor).val().trim();
        var witness1Id = $(":selected", $witness1).val().trim();
        var witness2Id = $(":selected", $witness2).val().trim();

        // If default option is selected, do nothing
        if (competitorId.length === 0) return;

        // If conflicting options are selected, revert the others back to the default option
        if (witness1Id === competitorId) {
            $("option:eq(0)", $witness1).prop("selected", true);
        }
        if (witness2Id === competitorId) {
            $("option:eq(0)", $witness2).prop("selected", true);
        }
    });

    $("#newRecordForm #Record_Witness1_CompetitorId").on("change", function () {
        var $competitor = $("#newRecordForm #Record_Competitor_CompetitorId");
        var $witness1 = $(this);
        var $witness2 = $("#newRecordForm #Record_Witness2_CompetitorId");

        var competitorId = $(":selected", $competitor).val().trim();
        var witness1Id = $(":selected", $witness1).val().trim();
        var witness2Id = $(":selected", $witness2).val().trim();

        // If default option is selected, do nothing
        if (witness1Id.length === 0) return;

        // If conflicting options are selected, revert the others back to the default option
        if (competitorId === witness1Id) {
            $("option:eq(0)", $competitor).prop("selected", true);
        }
        if (witness2Id === witness1Id) {
            $("option:eq(0)", $witness2).prop("selected", true);
        }
    });

    $("#newRecordForm #Record_Witness2_CompetitorId").on("change", function () {
        var $competitor = $("#newRecordForm #Record_Competitor_CompetitorId");
        var $witness1 = $("#newRecordForm #Record_Witness1_CompetitorId");
        var $witness2 = $(this);

        var competitorId = $(":selected", $competitor).val().trim();
        var witness1Id = $(":selected", $witness1).val().trim();
        var witness2Id = $(":selected", $witness2).val().trim();

        // If default option is selected, do nothing
        if (witness2Id.length === 0) return;

        // If conflicting options are selected, revert the others back to the default option
        if (competitorId === witness2Id) {
            $("option:eq(0)", $competitor).prop("selected", true);
        }
        if (witness1Id === witness2Id) {
            $("option:eq(0)", $witness1).prop("selected", true);
        }
    });
});