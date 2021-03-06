﻿import Speak = require("sitecore/shell/client/Speak/Assets/lib/core/1.2/SitecoreSpeak");

class Bootstrap3Carousel extends Speak.ControlBase {
  // #region Public Properties
  // This region was generated by a tool. Changes to this region may cause incorrect behavior and will be lost if the code is regenerated.
  public Interval: number;
  public IsVisible: boolean;
  public Pause: string;
  public Tooltip: string;
  public Wrap: boolean;

// #endregion

  initialized() {
    $(this.el).carousel({
      interval: this.Interval,
      pause: this.Pause,
      wrap: this.Wrap
    });
  }
}

Sitecore.Speak.component(Bootstrap3Carousel);