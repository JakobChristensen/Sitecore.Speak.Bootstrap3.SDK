var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
define(["require", "exports", "sitecore/shell/client/Speak/Assets/lib/core/1.2/SitecoreSpeak"], function(require, exports, Speak) {
    var Bootstrap3Select = (function (_super) {
        __extends(Bootstrap3Select, _super);
        function Bootstrap3Select() {
            _super.apply(this, arguments);
        }
        // #endregion
        Bootstrap3Select.prototype.initialize = function (initial, app, el, sitecore) {
            var _this = this;
            var children = $(el).children();
            if (children.length > 0) {
                _.each($(el).children(), function (e) {
                    _this.Items.push({ DisplayName: $(e).text().trim(), Value: $(e).attr("value").trim() });
                });
            }

            this.on("change:SelectedItem", function (newValue) {
                return _this.setSelectedItem(newValue);
            });

            // this is a hack to prevent Items bindings from overwriting the the SelectedItem binding
            setTimeout(function () {
                if (_this.initialValue != null) {
                    _this.SelectedItem = _this.initialValue;
                }
            }, 1);
        };

        Bootstrap3Select.prototype.initialized = function () {
        };

        Bootstrap3Select.prototype.setSelectedItem = function (newValue) {
            if (this.initialValue == null) {
                this.initialValue = newValue;
            }
        };
        return Bootstrap3Select;
    })(Speak.ControlBase);

    Sitecore.Speak.component(["jquery", "underscore"], Bootstrap3Select, "Bootstrap3-Select");
});
