$(function () {
    var fadeHandle = 0;
    var $toast = $("#toastMessage");

    window.toastMessage = {
        showMessage: function (message, messageType) {
            resetState();

            $toast.attr("class", "toast");
            $toast.addClass("toast-" + messageType)

            $("#messageText", $toast).text(message);
            $toast.show();

            createFadeTimeout(5000);

            $toast.on("mouseover", function () {
                window.clearTimeout(fadeHandle);
                $toast.stop(true, false);
                $toast.css("opacity", 1);
            });

            $toast.on("mouseout", function () {
                createFadeTimeout(1000);
            });
        }
    };

    $("#toastMessage .close-icon").on("click", function () {
        resetState();
        $toast.fadeOut(500);
    });

    function createFadeTimeout(timeout) {
        fadeHandle = window.setTimeout(function () {
            $toast.fadeOut(2000, function () {
                resetState();
            });
        }, timeout);
    }

    function resetState() {
        window.clearTimeout(fadeHandle);
        $toast.stop(true, false);
        $toast.css("opacity", 1);
        $toast.off("mouseover");
        $toast.off("mouseout");
    }
});