var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
define(["require", "exports", "sitecore/shell/client/Speak/Assets/lib/core/1.2/SitecoreSpeak"], function(require, exports, Speak) {
    var Bootstrap3Carousel = (function (_super) {
        __extends(Bootstrap3Carousel, _super);
        function Bootstrap3Carousel() {
            _super.apply(this, arguments);
        }
        // #endregion
        Bootstrap3Carousel.prototype.initialized = function () {
            $(this.el).carousel({
                interval: this.Interval,
                pause: this.Pause,
                wrap: this.Wrap
            });
        };
        return Bootstrap3Carousel;
    })(Speak.ControlBase);

    Sitecore.component(Bootstrap3Carousel);
});
