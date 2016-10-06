$(function () {
    var olympicsHub = $.connection.olympicsHub;

    olympicsHub.client.refreshRecords = function () {
        var recentRecordListContainer = $("#recentRecordListContainer");

        if (recentRecordListContainer.exists()) {
            $.ajax({
                type: "GET",
                cache: false,
                url: "/Home/RecentRecords",
                success: function (data, status, xhr) {
                    recentRecordListContainer.html(data);
                }
            })
        }
    };
    olympicsHub.client.refreshEvents = function () {
        var recentEventListContainer = $("#recentEventListContainer");
        
        if (recentEventListContainer.exists()) {
            $.ajax({
                type: "GET",
                cache: false,
                url: "/Home/RecentEvents",
                success: function (data, status, xhr) {
                    recentEventListContainer.html(data);
                }
            })
        }
    };
    olympicsHub.client.refreshCompetitors = function () {
        var recentCompetitorListContainer = $("#recentCompetitorListContainer");

        if (recentCompetitorListContainer.exists()) {
            $.ajax({
                type: "GET",
                cache: false,
                url: "/Home/RecentCompetitors",
                success: function (data, status, xhr) {
                    recentCompetitorListContainer.html(data);
                }
            });
        }
    };
});