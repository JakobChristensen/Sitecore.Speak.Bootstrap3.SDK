var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
define(["require", "exports", "sitecore/shell/client/Speak/Assets/lib/core/1.2/SitecoreSpeak"], function(require, exports, Speak) {
    var Bootstrap3SplitButton = (function (_super) {
        __extends(Bootstrap3SplitButton, _super);
        function Bootstrap3SplitButton() {
            _super.apply(this, arguments);
        }
        // #endregion
        Bootstrap3SplitButton.prototype.initialize = function (initial, app, el, sitecore) {
            $(el).find("*[data-toggle]").dropdown();
        };

        Bootstrap3SplitButton.prototype.click = function () {
            var click = $(this.el).data("sc-click");
            if (click) {
                Sitecore.Events.handleEvent(click, this);
            }
        };
        return Bootstrap3SplitButton;
    })(Speak.ControlBase);

    Sitecore.component(Bootstrap3SplitButton, "Bootstrap3-SplitButton");
});
