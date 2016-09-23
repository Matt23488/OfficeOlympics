$(function () {
    window.toastMessage = {
        showMessage: function (message, messageType) {
            var toast = $("#toastMessage");
            toast.attr("class", "toast");

            switch (messageType) {
                case "success":
                    toast.addClass("toast-success");
                    break;
                case "info":
                    toast.addClass("toast-info");
                    break;
                case "warning":
                    toast.addClass("toast-warning");
                    break;
                case "danger":
                    toast.addClass("toast-danger");
                    break;
            }

            $("#messageText", toast).text(message);
            toast.show();

            window.setTimeout(function () {
                toast.fadeOut(2000);
            }, 5000);
        },
        hide: function (timeout) {
            if (!timeout) timout = 0;

            $("#toastMessage").fadeOut(timeout);
        }
    };

    $("#toastMessage .close-icon").on("click", function () {
        window.toastMessage.hide(500);
    });
});