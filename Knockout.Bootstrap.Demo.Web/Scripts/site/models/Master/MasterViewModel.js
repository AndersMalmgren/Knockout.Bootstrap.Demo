Demo = {
    define: function (definition) {
        if (definition.prototype) {
            definition.init.prototype = definition.prototype;
            definition.init.prototype.constructor = definition.init;
        }

        if (definition.meta) {
            definition.init.meta = definition.meta;
        }

        return definition.init;
    },
    modelLoader: function (model, callback) {
        var onloaded = function (data) {
            var instance = new model(data);

            if (callback)
                callback(instance);
        };

        if (model.meta && model.meta.url) {
            $.getJSON(model.meta.url, null, onloaded);
        } else {
            onloaded();
        }
    }
};

Demo.MasterViewModel = Demo.define({
    init: function (version) {
        this.view = ko.observable();
        this.version = version;

        this.bootstrap = ko.bootstrap.init(this, this.appStart.bind(this));
    },
    prototype: {
        appStart: function () {
            Sammy(function (sammmy) {
                sammmy.get("#:model", function (route) {
                    this.loadView(route.params.model);
                }.bind(this));

                sammmy.get("", function () {
                    this.loadView("Home");
                }.bind(this));
            }.bind(this)).run();

            ko.bindingConventions.init({ roots: [Demo] });
            ko.applyBindings(this);
        },
        loadView: function (route) {
            var model = Demo[route + "ViewModel"];
            if (model === undefined)
                throw "Navigation is not known";

            var onload = function (model) {
                this.bootstrap.loadView(model, this.view);
            }.bind(this);

            Demo.modelLoader(model, onload);
        },
        loadTemplates: function (root, callback) {
            $.getJSON("api/template", { root: root }, function(data) {

                callback(data);
            });
        }
    }
});

Demo.modelLoader(Demo.MasterViewModel)