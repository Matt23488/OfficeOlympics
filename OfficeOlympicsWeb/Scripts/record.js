$(function () {
    var recordHub = $.connection.recordHub;
    $.connection.hub.start();

    $("#newRecordForm").on("submit", function () {
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

        recordHub.server.recordBroken(record);

        return true;
    });
});