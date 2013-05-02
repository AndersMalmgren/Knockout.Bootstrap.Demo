ko.bindingHandlers.rainbow = {
    init: function() {
        Rainbow.color();
    }
};
ko.virtualElements.allowedBindings.rainbow = true;