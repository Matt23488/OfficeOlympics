$(function () {
    var fadeHandle = 0;
    var $toast = $("#toastMessage");

    window.toastMessage = {
        showMessage: function (message, messageType) {
            /// <signature>
            ///   <summary>Shows an unobtrusive message at the top of the user's screen.</summary>
            ///   <param name="message" type="String">The message to display.</param>
            ///   <param name="messageType" type="String">The type (color) of the message. Valid types are "info", "success", "warning", and "danger".</param>
            /// </signature>

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

    if ($(window).width() < 992) {
        $toast.on("click", function () {
            resetState();
            $toast.fadeOut(500);
        });
    }

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

    $(window).resize(function () {
        var newWidth = $(window).width();

        if (newWidth < 992) {
            $toast.on("click", function () {
                resetState();
                $toast.fadeOut(500);
            });
        }
        else {
            $toast.off("click");
        }
    });

    $.createContextMenu("#toastMessage", function (menuBuilder) {
        menuBuilder.addMenuOption("Close", function () {
            resetState();
            $toast.fadeOut(500);
        });
    });
});