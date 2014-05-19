var Bootstrap3ButtonGroup = (function () {
    function Bootstrap3ButtonGroup() {
    }
    // #endregion
    Bootstrap3ButtonGroup.prototype.initialize = function (initial, app, el, sitecore) {
        $(el).find("*[data-toggle]").dropdown();
    };
    return Bootstrap3ButtonGroup;
})();

Sitecore.component(["jquery", "bootstrap"], Bootstrap3ButtonGroup, "Bootstrap3-ButtonGroup");
