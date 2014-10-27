var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
define(["require", "exports", "sitecore/shell/client/Speak/Assets/lib/core/1.2/SitecoreSpeak"], function(require, exports, Speak) {
    var Bootstrap3Tab = (function (_super) {
        __extends(Bootstrap3Tab, _super);
        function Bootstrap3Tab() {
            _super.apply(this, arguments);
        }
        // #endregion
        Bootstrap3Tab.prototype.initialized = function () {
            var $el = $(this.el);
            $el.tab();
        };
        return Bootstrap3Tab;
    })(Speak.ControlBase);

    Sitecore.Speak.component(Bootstrap3Tab);
});
