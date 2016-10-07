$(function () {
    var menuState = {
        menuArray: [],
        addMenu: function (selector) {
            this.menuArray = this.menuArray.filter(function (item) {
                return item.selector !== selector;
            });
            this.menuArray.push({
                selector: selector,
                menuOptions: []
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
        }
    };
    function getMenuState() { return menuState; }

    function buildMenuHtml(selector, target) {
        // Remove old menu items
        $("#contextMenu li").not(".template").remove();

        var menu = getMenuState().menuArray.filter(function (item) {
            return item.selector === selector;
        })[0];

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

                $("a", $menuItem)
                .text(menu.menuOptions[i].text)
                .data("callback", menu.menuOptions[i].callback)
                .click(function () {
                    $("#contextMenu").hide();
                    $(this).data("callback").call(target);
                });
            }

            $("#contextMenu").append($menuItem);
        }
    }

    function getMenuPosition(mouse, direction, scrollDir) {
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

    $.createContextMenu = function (selector, factory) {
        getMenuState().addMenu(selector);
        var menuBuilder = {
            addMenuOption: function (text, callback) {
                getMenuState().addMenuOption(selector, { text: text, callback: callback });
            },
            addDivider: function () {
                getMenuState().addDivider(selector);
            }
        };

        factory(menuBuilder);

        return $(selector).each(function () {

            // Open the menu
            $(this).on("contextmenu", function (e) {

                // Return native menu if pressing control
                if (e.ctrlKey) return;

                // Build the HTML
                buildMenuHtml(selector, this);

                var $menu = $("#contextMenu")
                            .show()
                            .css({
                                position: "absolute",
                                left: getMenuPosition(e.clientX, "width", "scrollLeft"),
                                top: getMenuPosition(e.clientY, "height", "scrollTop")
                            });

                e.preventDefault();
            });
        });
    };

    // Make sure menu closes on any click
    $(document).click(function () {
        $("#contextMenu").hide();
    });
});