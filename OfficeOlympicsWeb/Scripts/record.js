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
                RecordHolder: $("#Record_RecordHolder").val(),
                Witnesses: [$("#Record_Witnesses_0_").val(), $("#Record_Witnesses_1_").val()],
                Score: {
                    EventType: $("#Event_EventTypeId").val(),
                    Score: $("#Record_Score_Score").val()
                }
            }
        };

        recordHub.server.recordBroken(record);

        return true;
    });
});