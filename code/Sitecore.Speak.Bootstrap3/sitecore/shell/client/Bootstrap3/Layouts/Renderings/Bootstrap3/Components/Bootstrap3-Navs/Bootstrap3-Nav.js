var Bootstrap3Nav = (function () {
    function Bootstrap3Nav() {
    }
    // #endregion
    Bootstrap3Nav.prototype.initialize = function (initial, app, el, sitecore) {
        $(el).find("*[data-toggle]").dropdown();
    };
    return Bootstrap3Nav;
})();

Sitecore.Speak.component(["jquery", "bootstrap"], Bootstrap3Nav, "Bootstrap3-Nav");
