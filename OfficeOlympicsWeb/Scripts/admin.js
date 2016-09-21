$(function () {
    // extensions

    // event handlers
    $(".event-item").on("click", function () {
        var eventId = $(".hidden-event-id", this).val();
        window.location.href = "/Admin/EditEvent/" + eventId;
    });

    // functions
    
});