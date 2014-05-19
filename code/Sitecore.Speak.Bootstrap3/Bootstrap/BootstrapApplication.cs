// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BootstrapApplication.cs" company="Sitecore A/S">
//   Copyright (C) Sitecore A/S
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Sitecore.Bootstrap
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Web;
  using System.Web.Mvc;

  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Diagnostics;
  using Sitecore.Mvc.Helpers;
  using Sitecore.Mvc.Presentation;

  /// <summary>The bootstrap application.</summary>
  public class BootstrapApplication
  {
    #region Static Fields

    /// <summary>
    /// The application
    /// </summary>
    public static readonly ID Application = new ID("{3C554A04-6BBE-4A3B-8AEA-AFF59FBD20CF}");

    /// <summary>
    /// The button
    /// </summary>
    public static readonly ID Button = new ID("{FCC30FBD-D6B6-47CE-B2D6-B6548D1A173F}");

    /// <summary>
    /// The drop down menu
    /// </summary>
    public static readonly ID DropDownMenu = new ID("{FDD6888F-32EF-4649-BF2E-F902B5175D84}");

    /// <summary>
    /// The menu header
    /// </summary>
    public static readonly ID Header = new ID("{A2345209-6DAC-4416-8908-8B8D9932AEFC}");

    /// <summary>
    /// The link
    /// </summary>
    public static readonly ID Link = new ID("{C7C86218-8F3C-4FB4-8276-D157FF3D24B4}");

    /// <summary>
    /// The menu separator
    /// </summary>
    public static readonly ID Separator = new ID("{EA7F33C8-7C78-4144-85D5-1FDF46438DB6}");

    /// <summary>
    /// The text
    /// </summary>
    public static readonly ID Text = new ID("{0B9FE7B4-016E-48E4-86FB-C7C020EE8745}");

    #endregion

    #region Public Methods and Operators

    /// <summary>Gets the application item.</summary>
    /// <param name="pageItem">The page item.</param>
    /// <returns>Returns the application item.</returns>
    [CanBeNull]
    public static Item GetApplicationItem([NotNull] Item pageItem)
    {
      Assert.ArgumentNotNull(pageItem, "pageItem");

      while (pageItem != null)
      {
        if (pageItem.Is(Application))
        {
          return pageItem;
        }

        if (!string.IsNullOrEmpty(pageItem["AppModelTemplate"]))
        {
          return pageItem;
        }

        pageItem = pageItem.Parent;
      }

      return null;
    }

    /// <summary>
    /// Gets the menu items.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="itemsDataSource">The items data source.</param>
    /// <param name="defaultMenuName">Default name of the menu.</param>
    /// <returns>Returns the menu items.</returns>
    [NotNull]
    public static IEnumerable<Item> GetMenuItems([NotNull] SpeakRenderingModel model, [NotNull] string itemsDataSource, [NotNull] string defaultMenuName = "")
    {
      Assert.ArgumentNotNull(model, "model");
      Assert.ArgumentNotNull(itemsDataSource, "itemsDataSource");
      Assert.ArgumentNotNull(defaultMenuName, "defaultMenuName");

      Item item = null;

      var app = GetApplicationItem(model.PageItem);

      if (itemsDataSource == ".")
      {
        itemsDataSource = model.Rendering.Item.ID.ToString();
      }

      if (!string.IsNullOrEmpty(itemsDataSource))
      {
        item = GetMenuItem(model, itemsDataSource, app);
      }
      else
      {
        if (!defaultMenuName.StartsWith("c_", StringComparison.Ordinal))
        {
          item = GetMenuItem(model, defaultMenuName, app);
        }

        if (item == null)
        {
          item = GetMenuItem(model, model.Rendering.RenderingItem.Name, app);
        }
      }

      return item != null ? item.GetChildren() : Enumerable.Empty<Item>();
    }

    /// <summary>
    /// Gets the menu items.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="itemsDataSource">The items data source.</param>
    /// <param name="app">The application.</param>
    /// <returns>Returns the menu item.</returns>
    [CanBeNull]
    private static Item GetMenuItem([NotNull] SpeakRenderingModel model, [NotNull] string itemsDataSource, [CanBeNull] Item app)
    {
      Debug.ArgumentNotNull(model, "model");
      Debug.ArgumentNotNull(itemsDataSource, "itemsDataSource");

      var path = itemsDataSource;
      var item = model.PageItem.Database.GetItem(path);

      if (item == null)
      {
        path = model.PageItem.Paths.Path + "/PageSettings/" + itemsDataSource;
        item = model.PageItem.Database.GetItem(path);
      }

      if (item == null && app != null)
      {
        path = app.Paths.Path + "/PageSettings/" + itemsDataSource;
        item = model.PageItem.Database.GetItem(path);
      }

      return item;
    }

    #endregion
  }
}