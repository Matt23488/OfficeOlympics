$(function () {
    var recordHub = $.connection.recordHub;
    $.connection.hub.start();

    $("#newRecordForm").on("submit", function () {
        //var record = {};

        //record.Event = {};
        //record.Event.EventId = $("#Event_EventId").val();
        //record.Event.EventName = $("#Event_EventName").val();

        //record.Record = {};
        //record.Record.RecordHolder = $("#Record_RecordHolder").val();
        //record.Record.Witnesses = [];
        //record.Record.Witnesses.push($("#Record_Witnesses_0_").val());
        //record.Record.Witnesses.push($("#Record_Witnesses_1_").val());
        //record.Record.Score = {};
        //record.Record.Score.EventType = $("#Record_Score_EventType").val();
        //record.Record.Score.Score = $("#Record_Score_Score").val();

        //var record = {
        //    RecordHolder: $("#Record_RecordHolder").val(),
        //    Event: $("#Event_EventName").val(),
        //    Score: {
        //        EventType: $("#Record_Score_EventType :selected").val(),
        //        Score: $("#Record_Score_Score").val()
        //    },
        //    Witnesses: [ $("#Record_Witnesses_0_").val(), $("#Record_Witnesses_1_").val() ]
        //};

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