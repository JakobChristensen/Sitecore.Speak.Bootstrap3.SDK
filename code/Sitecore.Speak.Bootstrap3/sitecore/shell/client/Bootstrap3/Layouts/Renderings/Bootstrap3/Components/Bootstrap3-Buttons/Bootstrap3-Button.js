var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
define(["require", "exports", "sitecore/shell/client/Speak/Assets/lib/core/1.2/SitecoreSpeak"], function(require, exports, Speak) {
    var Bootstrap3Button = (function (_super) {
        __extends(Bootstrap3Button, _super);
        function Bootstrap3Button() {
            _super.apply(this, arguments);
        }
        // #endregion
        Bootstrap3Button.prototype.initialized = function () {
        };

        Bootstrap3Button.prototype.click = function () {
            var click = $(this.el).data("sc-click");
            if (click) {
                Sitecore.Speak.Events.handleEvent(click, this);
            }
        };
        return Bootstrap3Button;
    })(Speak.ControlBase);

    Sitecore.Speak.component(Bootstrap3Button, "Bootstrap3-Button");
});
