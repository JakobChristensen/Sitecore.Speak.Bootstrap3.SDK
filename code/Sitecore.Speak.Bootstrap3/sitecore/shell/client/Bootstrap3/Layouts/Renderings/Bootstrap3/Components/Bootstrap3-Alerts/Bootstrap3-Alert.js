var Bootstrap3Alert = (function () {
    function Bootstrap3Alert() {
    }
    // #endregion
    Bootstrap3Alert.prototype.initialize = function (initial, app, el, sitecore) {
        $(el).alert();
    };
    return Bootstrap3Alert;
})();

Sitecore.Speak.component(["jquery", "bootstrap"], Bootstrap3Alert, "Bootstrap3-Alert");
