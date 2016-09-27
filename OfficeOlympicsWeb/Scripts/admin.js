$(function () {
    // extensions

    // event handlers
    $(".event-item").on("click", function () {
        var eventId = $(".hidden-event-id", this).val();
        window.location.href = "/Admin/EditEvent/" + eventId;
    });
    $(".competitor-item").on("click", function () {
        var competitorId = $(".hidden-competitor-id", this).val();
        window.location.href = "/Admin/EditCompetitor/" + competitorId;
    });

    // functions
    
});