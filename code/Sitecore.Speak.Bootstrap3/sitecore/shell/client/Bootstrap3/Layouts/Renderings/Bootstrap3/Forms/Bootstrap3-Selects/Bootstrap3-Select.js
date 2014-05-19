var Bootstrap3Select = (function () {
    function Bootstrap3Select() {
    }
    // #endregion
    Bootstrap3Select.prototype.initialize = function (initial, app, el, sitecore) {
        var _this = this;
        _.each($(el).children(), function (e) {
            _this.Items.push({ DisplayName: $(e).text().trim(), Value: $(e).attr("value").trim() });
        });
    };
    return Bootstrap3Select;
})();

Sitecore.component(["jquery", "underscore"], Bootstrap3Select, "Bootstrap3-Select");
