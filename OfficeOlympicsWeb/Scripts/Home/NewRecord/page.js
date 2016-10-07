$(function () {
    var olympicsHub = $.connection.olympicsHub;

    $("#NewRecordForm").on("submit", function () {
        var record = {
            Event: {
                EventId: $("#Event_EventId").val(),
                EventName: $("#Event_EventName").val()
            },
            Record: {
                Competitor: {
                    CompetitorId: $("#Record_Competitor_CompetitorId :selected").val(),
                    FirstName: $("#Record_Competitor_CompetitorId :selected").text().split(" ")[0],
                    LastName: $("#Record_Competitor_CompetitorId :selected").text().split(" ")[1]
                },
                Score: {
                    EventType: $("#Event_EventTypeId").val(),
                    Score: $("#Record_Score_Score").val()
                },
                Witness1: {
                    CompetitorId: $("#Record_Witness1_CompetitorId :selected").val(),
                    FirstName: $("#Record_Witness1_CompetitorId :selected").text().split(" ")[0],
                    LastName: $("#Record_Witness1_CompetitorId :selected").text().split(" ")[1]
                },
                Witness2: {
                    CompetitorId: $("#Record_Witness2_CompetitorId :selected").val(),
                    FirstName: $("#Record_Witness2_CompetitorId :selected").text().split(" ")[0],
                    LastName: $("#Record_Witness2_CompetitorId :selected").text().split(" ")[1]
                }
            }
        };

        olympicsHub.server.recordBroken(record);

        return true;
    });
    $("#Record_Competitor_CompetitorId").on("change", function () {
        var $competitor = $(this);
        var $witness1 = $("#Record_Witness1_CompetitorId");
        var $witness2 = $("#Record_Witness2_CompetitorId");

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
    $("#Record_Witness1_CompetitorId").on("change", function () {
        var $competitor = $("#Record_Competitor_CompetitorId");
        var $witness1 = $(this);
        var $witness2 = $("#Record_Witness2_CompetitorId");

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
    $("#Record_Witness2_CompetitorId").on("change", function () {
        var $competitor = $("#Record_Competitor_CompetitorId");
        var $witness1 = $("#Record_Witness1_CompetitorId");
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