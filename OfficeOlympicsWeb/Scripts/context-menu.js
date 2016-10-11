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

                if (menu.menuOptions[i] === "divider") {
                    $menuItem = $("#contextMenu #dividerTemplate").clone()
                                .removeClass("template")
                                .removeAttr("id");
                }
                else {
                    $menuItem = $("#contextMenu #linkTemplate").clone()
                                .removeClass("template")
                                .removeAttr("id");

                    var linkText = menu.menuOptions[i].text;

                    if (detailFactory) {
                        detailFactory.call(target, detailBuilder);

                        var keys = Object.keys(replacementDictionary);
                        for (var j = 0; j < keys.length; j++) {
                            linkText = linkText.replace("{" + keys[j] + "}", replacementDictionary[keys[j]]);
                        }
                    }

                    $("a", $menuItem)
                    .text(linkText)
                    .data("callback", menu.menuOptions[i].callback)
                    .click(function (e) {
                        $("#contextMenu").hide();
                        $(this).data("callback").call(target);
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
        }
    });

    // Make sure menu closes on any click
    $(document).click(function () {
        $(".context-menu-active").removeClass("context-menu-active");
        $("#contextMenu").hide();
    });
});