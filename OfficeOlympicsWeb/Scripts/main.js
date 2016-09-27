$(function () {
    // jQuery
    jQuery.fn.extend({
        exists: function () {
            if (this[0]) return true;
            else return false;
        }
    });

    //jQuery.validator.setDefaults({
    //    validClass: "has-success",
    //    errorClass: "has-error",
    //    highlight: function (element, errorClass, validClass) {
    //        $(element).closest(".form-group")
    //            .removeClass(validClass)
    //            .addClass("has-error");
    //    },
    //    unhighlight: function (element, errorClass, validClass) {
    //        $(element).closest(".form-group")
    //            .removeClass("has-error")
    //            .addClass(validClass);
    //    }
    //});
    //jQuery.validator.unobtrusive.options = {
    //    errorClass: "has-error",
    //    validClass: "has-success"
    //};

    // SignalR
    var olympicsHub = $.connection.olympicsHub;
    $.connection.hub.start();

    olympicsHub.client.displayMessage = function (message, messageType) {
        window.toastMessage.showMessage(message, messageType);
    };

    // Form Validation
    $(".input-validation-error").parents(".form-group").addClass("has-error");
    $(".field-validation-error").addClass("text-danger");
    $("form").each(function (index, form) {
        var $form = $(form);
        var formData = $.data(form);
        var settings = formData.validator.settings;
        var oldErrorPlacement = settings.errorPlacement;
        var oldSuccess = settings.success;

        settings.errorPlacement = function (label, element) {
            // Call old handler so it can update the HTML
            oldErrorPlacement(label, element);

            // Add Bootstrap classes to newly added elements
            label.parents(".form-group").addClass("has-error");
            label.addClass("text-danger");
        };

        settings.success = function (label) {
            // Remove error class from <div class="form-group">, but don't worry about
            // validation error messages as the plugin is going to remove it anyway
            label.parents(".form-group").removeClass("has-error");

            // Call old handler to do rest of the work
            oldSuccess(label);
        };
    });
});