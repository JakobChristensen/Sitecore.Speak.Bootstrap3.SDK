class Bootstrap3Alert {

  // #region Public Properties
  public IsVisible: boolean;
  public Subtext: string;
  public Text: string;
  public Tooltip: string;
  public Type: string;
  // #endregion

  initialize(initial: ComponentOptions, app: Application, el: Element, sitecore: SitecoreSpeak) {
    $(el).alert();
  }
}

Sitecore.Speak.component(["jquery", "bootstrap"], Bootstrap3Alert, "Bootstrap3-Alert");
