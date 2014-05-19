import Speak = require("sitecore/shell/client/Speak/Assets/lib/core/1.2/SitecoreSpeak");

class Bootstrap3SplitButton extends Speak.ControlBase {
  // #region Public Properties
  public IsEnabled: boolean;
  public IsVisible: boolean;
  public Tooltip: string;
  // #endregion

  initialize(initial: ComponentOptions, app: Application, el: Element, sitecore: SitecoreSpeak) {
    $(el).find("*[data-toggle]").dropdown();
  }

  click() {
    var click = $(this.el).data("sc-click");
    if (click) {
      Sitecore.Events.handleEvent(click, this);
    }
  }              
}

Sitecore.component(Bootstrap3SplitButton, "Bootstrap3-SplitButton");
