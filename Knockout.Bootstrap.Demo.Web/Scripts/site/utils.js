(function(Demo) {
    Demo.define = function(definition) {
        if (definition.prototype) {
            definition.init.prototype = definition.prototype;
            definition.init.prototype.constructor = definition.init;
        }

        if (definition.meta) {
            definition.init.meta = definition.meta;
        }

        return definition.init;
    };

    Demo.modelLoader = function(model, callback) {
        var onloaded = function(data) {
            var instance = new model(data);

            if (callback)
                callback(instance);
        };

        if (model.meta && model.meta.url) {
            $.getJSON(model.meta.url, null, onloaded);
        } else {
            onloaded();
        }
    };
})(window.Demo = window.Demo = {});