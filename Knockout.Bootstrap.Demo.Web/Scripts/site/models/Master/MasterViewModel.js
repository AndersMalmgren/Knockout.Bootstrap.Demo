Demo.MasterViewModel = Demo.define({
    init: function () {
        this.view = ko.observable();
        this.bootstrap = ko.bootstrap.init(this.appStart.bind(this));
    },
    prototype: {
        appStart: function () {
            ko.bindingConventions.init({ roots: [Demo] });
            ko.applyBindings(this);
            
            Sammy(function (sammmy) {
                sammmy.get("#:model", function (route) {
                    this.loadView(route.params.model);
                }.bind(this));

                sammmy.get("", function () {
                    this.loadView("Home");
                }.bind(this));
            }.bind(this)).run();
        },
        loadView: function (route) {
            var model = Demo[route + "ViewModel"];
            if (model === undefined)
                throw "Navigation is not known";

            var onload = function (model) {
                this.bootstrap.loadView(model, this.view);
            }.bind(this);

            Demo.modelLoader(model, onload);
        }
    }
});

$(document).ready(function () { Demo.modelLoader(Demo.MasterViewModel); });