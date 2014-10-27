import Speak = require("sitecore/shell/client/Speak/Assets/lib/core/1.2/SitecoreSpeak");

class Bootstrap3Modal extends Speak.ControlBase {
  // #region Public Properties
  public Header: string;
  public IsVisible: boolean;
  public Keyboard: boolean;
  public Text: string;
  public Tooltip: string;
  // #endregion

  public IsOpen: boolean;

  initialized() {
    this.defineProperty("IsOpen", false);

    var $el = $(this.el);
    $el.modal({ show: false, keyboard: true });

    this.on("change:IsOpen", this.setIsOpen, this);

    var controlId = $el.data("sc-id");
    this.app.on("open:" + controlId, this.open, this);
    this.app.on("close:" + controlId, this.close, this);

    $el.on("hide", $.proxy(this.close, this));
    $el.on("show", $.proxy(this.open, this));
  }

  open() {
    this.IsOpen = true;
  }

  close() {
    this.IsOpen = false;
  }

  setIsOpen() {
    $(this.el).modal(this.IsOpen ? "show" : "hide");
  }

  click(data) {
    var controlId = $(this.el).data("sc-id");
    var button = $(data[1].target).data("sc-button");

    this.app.trigger("click:" + controlId + "_" + button);

    this.close();
  }
}

Sitecore.Speak.component(["bootstrap"], Bootstrap3Modal, "Bootstrap3-Modal");
