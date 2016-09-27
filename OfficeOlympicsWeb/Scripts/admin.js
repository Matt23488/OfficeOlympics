$(function () {
    var olympicsHub = $.connection.olympicsHub;

    // event handlers
    $(".event-item").on("click", function () {
        var eventId = $(".hidden-event-id", this).val();
        window.location.href = "/Admin/EditEvent/" + eventId;
    });
    $(".competitor-item").on("click", function () {
        var competitorId = $(".hidden-competitor-id", this).val();
        window.location.href = "/Admin/EditCompetitor/" + competitorId;
    });
    $("#AddEventForm").on("submit", function () {
        olympicsHub.server.newEvent($("#Event_EventName").val());

        return true;
    });
    $("#AddCompetitorForm").on("submit", function () {
        var name = $("#FirstName").val() + " " + $("#LastName").val();

        olympicsHub.server.newCompetitor(name);

        return true;
    });
});