Demo.TestViewModel = Demo.define({
    meta: {
        url: "api/test"
    },
    init: function (data) {
        ko.mapping.fromJS(data, {}, this);
    }
});