$(function () {
    // jQuery
    jQuery.fn.extend({
        exists: function () {
            if (this[0]) return true;
            else return false;
        },
        formData: function () {
            var values = {};
            $(":input", this).each(function () {
                values[this.name] = $(this).val();
            });

            return values;
        },
        unique: function () {
            var uniqueItems = [];

            for (var i = 0; i < this.length; i++) {
                if (!uniqueItems.contains(this[i])) {
                    uniqueItems.push(this[i]);
                }
            }

            return $(uniqueItems);
        },
        clearForm: function () {
            $(":input", this).val("");
            
            $(".form-group.has-error", this).each(function () {
                $(".form-control.input-validation-error", this)
                .removeClass("input-validation-error");

                $(".field-validation-error", this)
                .removeClass("field-validation-error")
                .addClass("field-validation-valid")
                .html("");

                $(this).removeClass("has-error");
            });
        }
    });

    $.ajaxSetup({
        error: function (xhr, status, error) {
            window.toastMessage.showMessage(error, "danger");
        }
    });

    // Extensions
    Array.prototype.contains = function (item) {
        for (var i = 0; i < this.length; i++) {
            if (this[i] === item) return true;
        }

        return false;
    };

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

    // Other initialization
    $("form input[type=submit]").click(function () {
        $("input[type=submit]", $(this).parents("form")).removeAttr("clicked");
        $(this).attr("clicked", "true");
    });
    $(document).on("change", ":file", function () {
        var input = $(this);
        var numFiles = input.get(0).files ? input.get(0).files.length : 1;
        var label = input.val().replace(/\\/g, "/").replace(/.*\//, "");

        input.trigger("fileselect", [numFiles, label]);
    });
    $(":file").on("fileselect", function (event, numFiles, label) {
        $(this).parents(".file-upload").children(".file-name").text(label);
    });
});