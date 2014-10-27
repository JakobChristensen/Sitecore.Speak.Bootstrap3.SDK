var Bootstrap3ButtonDropdown = (function () {
    function Bootstrap3ButtonDropdown() {
    }
    // #endregion
    Bootstrap3ButtonDropdown.prototype.initialize = function (initial, app, el, sitecore) {
        $(el).find("*[data-toggle]").dropdown();
    };
    return Bootstrap3ButtonDropdown;
})();

Sitecore.Speak.component(["jquery", "bootstrap"], Bootstrap3ButtonDropdown, "Bootstrap3-ButtonDropdown");
