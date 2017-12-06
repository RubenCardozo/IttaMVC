
//MyJS validator

$.validator.addMethod("antichuck", function (value, element, params) {
    return value.toUpperCase() != "CHUCK";
}
);

$.validator.unobtrusive.adapters.add("antichuck", [],
    function (options) {
        options.rules["antichuck"] = options.params;
        options.messages["antichuck"] = option.message;
    }
);