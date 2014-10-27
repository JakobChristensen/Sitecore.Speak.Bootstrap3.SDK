class Bootstrap3Nav {
  // #region Public Properties
  public IsVisible: boolean;
  public Tooltip: string;
  // #endregion

  initialize(initial: ComponentOptions, app: Application, el: Element, sitecore: SitecoreSpeak) {
    $(el).find("*[data-toggle]").dropdown();
  }
}

Sitecore.Speak.component(["jquery", "bootstrap"], Bootstrap3Nav, "Bootstrap3-Nav");
