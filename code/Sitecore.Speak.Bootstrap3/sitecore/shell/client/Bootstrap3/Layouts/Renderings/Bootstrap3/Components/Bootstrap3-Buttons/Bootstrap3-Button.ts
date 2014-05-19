import Speak = require("sitecore/shell/client/Speak/Assets/lib/core/1.2/SitecoreSpeak");

class Bootstrap3Button extends Speak.ControlBase {

  // #region Public Properties
  public IsBlock: boolean;
  public IsEnabled: boolean;
  public IsVisible: boolean;
  public Size: string;
  public Text: string;
  public Tooltip: string;
  public Type: string;
  // #endregion

  initialized() {
  }

  click() {
    var click = $(this.el).data("sc-click");
    if (click) {
      Sitecore.Events.handleEvent(click, this);
    }
  }              
}

Sitecore.component(Bootstrap3Button, "Bootstrap3-Button");
