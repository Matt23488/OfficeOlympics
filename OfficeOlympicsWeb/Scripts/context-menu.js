$(function () {

    var contextHelper = {
        menuState: {
            menuArray: [],
            addMenu: function (selector, detailFactory) {
                this.menuArray = this.menuArray.filter(function (item) {
                    return item.selector !== selector;
                });
                this.menuArray.push({
                    selector: selector,
                    menuOptions: [],
                    detailFactory: detailFactory
                });
            },
            addMenuOption: function (selector, menuItem) {
                var item = this.menuArray.filter(function (item) {
                    return item.selector === selector;
                })[0];

                if (!item) return;

                item.menuOptions.push(menuItem);
            },
            addDivider: function (selector) {
                var item = this.menuArray.filter(function (item) {
                    return item.selector === selector;
                })[0];

                if (!item) return;

                item.menuOptions.push("divider");
            },
            getDetailFactory: function (selector) {
                var item = this.menuArray.filter(function (item) {
                    return item.selector === selector;
                })[0];

                if (!item) return null;

                return item.detailFactory;
            },
            getMenu: function (selector) {
                var item = this.menuArray.filter(function (item) {
                    return item.selector === selector;
                })[0];

                return item;
            }
        },
        buildMenuHtml: function (selector, target, detailFactory) {
            // Remove old menu items
            $("#contextMenu li").not(".template").remove();

            var menu = this.menuState.menuArray.filter(function (item) {
                return item.selector === selector;
            })[0];

            var replacementDictionary = {};
            var detailBuilder = {
                setData: function (name, value) {
                    replacementDictionary[name] = value;
                }
            };

            for (var i = 0; i < menu.menuOptions.length; i++) {
                var $menuItem = null;
                var currentMenuOptions = menu.menuOptions[i];

                if (currentMenuOptions === "divider") {
                    $menuItem = $("#contextMenu #dividerTemplate").clone()
                                .removeClass("template")
                                .removeAttr("id");
                }
                else {
                    $menuItem = $("#contextMenu #linkTemplate").clone()
                                .removeClass("template")
                                .removeAttr("id");

                    var linkText = currentMenuOptions.text;

                    if (detailFactory) {
                        detailFactory.call(target, detailBuilder);

                        var keys = Object.keys(replacementDictionary);
                        for (var j = 0; j < keys.length; j++) {
                            linkText = linkText.replace("{" + keys[j] + "}", replacementDictionary[keys[j]]);
                        }
                    }

                    var $a = $("a", $menuItem);

                    $a.text(linkText)
                    .data("callback", currentMenuOptions.callback)
                    .data("modalId", currentMenuOptions.modalId)
                    .click(function (e) {
                        $("#contextMenu").hide();

                        var modalId = $(this).data("modalId");
                        var callback = $(this).data("callback");

                        if (callback) {
                            if (modalId) {
                                callback.call(target, $("#" + modalId)[0]);
                            }
                            else {
                                callback.call(target);
                            }
                        }

                        if (modalId) {
                            $("#" + modalId).modal();
                        }

                        e.preventDefault(); // Prevents scroll to top caused by href="#"
                    });
                }

                $("#contextMenu").append($menuItem);
            }
        },
        getMenuPosition: function (mouse, direction, scrollDir) {
            var win = $(window)[direction]();
            var scroll = $(window)[scrollDir]();
            var menu = $("#contextMenu")[direction]();
            var position = mouse + scroll;

            // Opening the menu would pass the edge of the page
            if (mouse + menu > win && menu < mouse) {
                position -= menu;
            }

            return position;
        }
    };

    jQuery.extend({
        createContextMenu: function (selector, factory, detailFactory) {
            /// <summary>Creates a custom context menu for elements that match the provided selector.</summary>
            /// <param name="selector" type="String">CSS/jQuery selector that represents elements to apply the context menu to.</param>
            /// <param name="factory" type="Function">A function that builds the menu items.</param>
            /// <param name="detailFactory" type="Function">A function that further customizes option text based on which DOM element invoked the menu.</param>
            /// <returns type="jQuery">The selected DOM elements wrapped in a jQuery object.</returns>

            if (typeof selector !== "string") return;

            contextHelper.menuState.addMenu(selector, detailFactory);
            var menuBuilder = {
                addMenuOption: function (text, callback) {
                    contextHelper.menuState.addMenuOption(selector, { text: text, callback: callback });
                },
                addDivider: function () {
                    contextHelper.menuState.addDivider(selector);
                },
                addModalTriggerOption: function (text, modalId, callback) {
                    contextHelper.menuState.addMenuOption(selector, { text: text, modalId: modalId, callback: callback });
                }
            };

            factory(menuBuilder);

            return $(selector).each(function () {

                // Open the menu
                $(this).on("contextmenu", function (e) {
                    // Return native menu if pressing control
                    if (e.ctrlKey) return;

                    $(selector).removeClass("context-menu-active");
                    $(this).addClass("context-menu-active");

                    // Build the HTML
                    contextHelper.buildMenuHtml(selector, this, detailFactory);

                    $("#contextMenu")
                    .show()
                    .css({
                        position: "absolute",
                        left: contextHelper.getMenuPosition(e.clientX, "width", "scrollLeft"),
                        top: contextHelper.getMenuPosition(e.clientY, "height", "scrollTop")
                    });

                    e.preventDefault();
                });
            });
        },
        reapplyContextMenu: function (selector) {
            /// <summary>Reapplies an existing context menu for elements that match the provided selector. Useful if the page content changes dynamically and the event handlers are lost.</summary>
            /// <param name="selector" type="String">CSS/jQuery selector that represents elements to apply the context menu to.</param>
            /// <returns type="jQuery">The selected DOM elements wrapped in a jQuery object.</returns>

            if (typeof selector !== "string") return;

            $(selector).off("contextmenu");

            return $(selector).each(function () {

                // Open the menu
                $(this).on("contextmenu", function (e) {
                    // Return native menu if pressing control
                    if (e.ctrlKey) return;

                    $(selector).removeClass("context-menu-active");
                    $(this).addClass("context-menu-active");

                    // Build the HTML
                    contextHelper.buildMenuHtml(selector, this, contextHelper.menuState.getDetailFactory(selector));

                    $("#contextMenu")
                    .show()
                    .css({
                        position: "absolute",
                        left: contextHelper.getMenuPosition(e.clientX, "width", "scrollLeft"),
                        top: contextHelper.getMenuPosition(e.clientY, "height", "scrollTop")
                    });

                    e.preventDefault();
                });
            });
        },
        invokeMenuOption: function (selector, target, optionIndex) {
            /// <summary>Invokes a menu option programatically.</summary>
            /// <param name="selector" type="String">CSS/jQuery selector that represents the elements the context menu is applied to.</param>
            /// <param name="target" type="DOM">The actual element to invoke the menu option on.</param>
            /// <param name="optionIndex" type="Number">The index of the menu option to invoke.</param>

            if (typeof selector !== "string") return;

            var menuOption = contextHelper.menuState.getMenu(selector).menuOptions[optionIndex];

            if (menuOption.callback) {
                if (menuOption.modalId) {
                    menuOption.callback.call(target, $("#" + menuOption.modalId)[0]);
                }
                else {
                    menuOption.callback.call(target);
                }
            }

            if (menuOption.modalId) {
                $("#" + menuOption.modalId).modal();
            }
        }
    });

    // Make sure menu closes on any click
    $(document).click(function () {
        $(".context-menu-active").removeClass("context-menu-active");
        $("#contextMenu").hide();
    });
});