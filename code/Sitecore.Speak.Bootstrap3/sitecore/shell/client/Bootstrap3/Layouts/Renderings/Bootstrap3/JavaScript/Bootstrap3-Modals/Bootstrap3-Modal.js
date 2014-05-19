var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
define(["require", "exports", "sitecore/shell/client/Speak/Assets/lib/core/1.2/SitecoreSpeak"], function(require, exports, Speak) {
    var Bootstrap3Modal = (function (_super) {
        __extends(Bootstrap3Modal, _super);
        function Bootstrap3Modal() {
            _super.apply(this, arguments);
        }
        Bootstrap3Modal.prototype.initialized = function () {
            this.defineProperty("IsOpen", false);

            var $el = $(this.el);
            $el.modal({ show: false, keyboard: true });

            this.on("change:IsOpen", this.setIsOpen, this);

            var controlId = $el.data("sc-id");
            this.app.on("open:" + controlId, this.open, this);
            this.app.on("close:" + controlId, this.close, this);

            $el.on("hide", $.proxy(this.close, this));
            $el.on("show", $.proxy(this.open, this));
        };

        Bootstrap3Modal.prototype.open = function () {
            this.IsOpen = true;
        };

        Bootstrap3Modal.prototype.close = function () {
            this.IsOpen = false;
        };

        Bootstrap3Modal.prototype.setIsOpen = function () {
            $(this.el).modal(this.IsOpen ? "show" : "hide");
        };

        Bootstrap3Modal.prototype.click = function (data) {
            var controlId = $(this.el).data("sc-id");
            var button = $(data[1].target).data("sc-button");

            this.app.trigger("click:" + controlId + "_" + button);

            this.close();
        };
        return Bootstrap3Modal;
    })(Speak.ControlBase);

    Sitecore.component(["bootstrap"], Bootstrap3Modal, "Bootstrap3-Modal");
});
