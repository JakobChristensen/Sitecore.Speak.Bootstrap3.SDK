// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlHelperExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the HtmlHelperExtensions class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Sitecore.Bootstrap
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Web;
  using System.Web.Mvc;

  using Sitecore;
  using Sitecore.Configuration;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Diagnostics;
  using Sitecore.Extensions.StringExtensions;
  using Sitecore.Links;
  using Sitecore.Mvc.Helpers;
  using Sitecore.Names;
  using Sitecore.Resources;
  using Sitecore.Speak.Extensions;
  using Sitecore.Web.Pipelines.GetClick;
  using Sitecore.Web.UI;

  /// <summary>
  /// Defines the HtmlHelperExtensions class.
  /// </summary>
  public static class SitecoreHelperExtensions
  {
    #region Public Methods and Operators

    /// <summary>Gets the click.</summary>
    /// <param name="htmlHelper">The HTML helper.</param>
    /// <param name="item">The item.</param>
    /// <param name="clickFieldName">Name of the click field.</param>
    /// <returns>Returns the click.</returns>
    [CanBeNull]
    public static HtmlString ClickFieldAttribute([NotNull] this SitecoreHelper htmlHelper, [NotNull] Item item, [NotNull] string clickFieldName)
    {
      Assert.ArgumentNotNull(htmlHelper, "htmlHelper");
      Assert.ArgumentNotNull(item, "item");
      Assert.ArgumentNotNull(clickFieldName, "clickFieldName");

      if (string.IsNullOrEmpty(clickFieldName))
      {
        clickFieldName = "$itemid";
      }

      var click = item.GetField(clickFieldName);
      if (string.IsNullOrEmpty(click))
      {
        return MvcHtmlString.Empty;
      }

      if (click.StartsWith("trigger:", StringComparison.InvariantCultureIgnoreCase) || click.StartsWith("action:", StringComparison.InvariantCultureIgnoreCase))
      {
        var args = new GetClickArgs(click);
        ClientHost.Pipelines.Run(PipelineNames.GetClick, args);

        if (string.IsNullOrEmpty(args.Click))
        {
          return MvcHtmlString.Empty;
        }

        var name = item.Name.GetSafeIdentifier() + "Click";

        return new HtmlString(string.Format("data-sc-id=\"{0}\" data-sc-presenter=\"{1}\" data-sc-component=\"Bootstrap3-Click\" data-sc-require=\"/sitecore/shell/-/speak/v1/client/Bootstrap3-Click.js\" data-bind=\"click: click, enable: isEnabled, visible: isVisible\" data-sc-properties=\"{{ &quot;isEnabled&quot;:&quot;true&quot;, &quot;isVisible&quot;:&quot;true&quot; }}\" data-sc-click=\"{2}\"", name, SpeakSettings.Components.KnockoutPresenter, HttpUtility.HtmlAttributeEncode(args.Click)));
      }

      if (click.StartsWith("javascript:", StringComparison.InvariantCultureIgnoreCase))
      {
        var args = new GetClickArgs(click);
        ClientHost.Pipelines.Run(PipelineNames.GetClick, args);
        if (string.IsNullOrEmpty(args.Click))
        {
          return MvcHtmlString.Empty;
        }

        return new HtmlString(string.Format("onclick=\"{0}\"", HttpUtility.HtmlAttributeEncode(args.Click)));
      }

      return new HtmlString("data-sc-click=\"" + HttpUtility.HtmlAttributeEncode(click) + "\"");
    }

    /// <summary>Displays the name.</summary>
    /// <param name="htmlHelper">The HTML helper.</param>
    /// <param name="item">The item.</param>
    /// <param name="displayFieldName">Display name of the field.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>Returns the HTML string.</returns>
    [NotNull]
    public static HtmlString DisplayName([NotNull] this SitecoreHelper htmlHelper, [NotNull] Item item, [NotNull] string displayFieldName, [NotNull] string defaultValue = "")
    {
      Assert.ArgumentNotNull(htmlHelper, "htmlHelper");
      Assert.ArgumentNotNull(item, "item");
      Assert.ArgumentNotNull(displayFieldName, "displayFieldName");
      Assert.ArgumentNotNull(defaultValue, "defaultValue");

      return new HtmlString(item.GetField(displayFieldName, defaultValue));
    }

    /// <summary>Gets the click.</summary>
    /// <param name="htmlHelper">The HTML helper.</param>
    /// <param name="item">The item.</param>
    /// <param name="clickFieldName">Name of the click field.</param>
    /// <returns>Returns the click.</returns>
    [CanBeNull]
    public static HtmlString HrefAttribute([NotNull] this SitecoreHelper htmlHelper, [NotNull] Item item, [NotNull] string clickFieldName)
    {
      Assert.ArgumentNotNull(htmlHelper, "htmlHelper");
      Assert.ArgumentNotNull(item, "item");
      Assert.ArgumentNotNull(clickFieldName, "clickFieldName");

      if (string.IsNullOrEmpty(clickFieldName))
      {
        clickFieldName = "$itemid";
      }

      if (clickFieldName.StartsWith("#") && clickFieldName.Length > 1)
      {
        var link = "#" + item.GetField(clickFieldName.Mid(1));
        return new HtmlString("href=\"" + HttpUtility.HtmlAttributeEncode(link) + "\"");
      }

      var click = item.GetField(clickFieldName);
      if (string.IsNullOrEmpty(click))
      {
        return MvcHtmlString.Empty;
      }

      if (click.StartsWith("trigger:", StringComparison.InvariantCultureIgnoreCase) || click.StartsWith("action:", StringComparison.InvariantCultureIgnoreCase))
      {
        var args = new GetClickArgs(click);
        ClientHost.Pipelines.Run(PipelineNames.GetClick, args);

        click = args.Click;
        if (string.IsNullOrEmpty(click))
        {
          return MvcHtmlString.Empty;
        }

        var name = item.Name.GetSafeIdentifier() + "Click";

        return new HtmlString(string.Format("href=\"#\" data-sc-id=\"{0}\" data-sc-presenter=\"{1}\" data-sc-component=\"Bootstrap3-Click\" data-sc-require=\"/sitecore/shell/-/speak/v1/client/Bootstrap3-Click.js\" data-bind=\"click: click, enable: isEnabled, visible: isVisible\" data-sc-properties=\"{{ &quot;isEnabled&quot;:&quot;true&quot;, &quot;isVisible&quot;:&quot;true&quot; }}\" data-sc-click=\"{2}\"", name, SpeakSettings.Components.KnockoutPresenter, HttpUtility.HtmlAttributeEncode(click)));
      }

      if (ID.IsID(click))
      {
        var target = item.Database.GetItem(click);
        if (target != null)
        {
          var options = new UrlOptions
          {
            AddAspxExtension = false
          };

          var itemUrl = LinkManager.GetItemUrl(target, options);
          return new HtmlString("href=\"" + HttpUtility.HtmlAttributeEncode(itemUrl) + "\"");
        }
      }

      return new HtmlString("href=\"" + HttpUtility.HtmlAttributeEncode(click) + "\"");
    }

    /// <summary>
    /// Icons the specified HTML helper.
    /// </summary>
    /// <param name="htmlHelper">The HTML helper.</param>
    /// <param name="item">The item.</param>
    /// <param name="iconFieldName">Name of the icon field.</param>
    /// <param name="additionalClassName">Name of the additional class.</param>
    /// <returns>Returns the HTML string.</returns>
    [NotNull]
    public static HtmlString Icon([NotNull] this SitecoreHelper htmlHelper, [NotNull] Item item, [NotNull] string iconFieldName, [NotNull] string additionalClassName = "")
    {
      Assert.ArgumentNotNull(htmlHelper, "htmlHelper");
      Assert.ArgumentNotNull(item, "item");
      Assert.ArgumentNotNull(iconFieldName, "iconFieldName");
      Assert.ArgumentNotNull(additionalClassName, "additionalClassName");

      return new HtmlString(GetIconTag(item, iconFieldName, additionalClassName));
    }

    /// <summary>Attributes the specified HTML helper.</summary>
    /// <param name="htmlHelper">The HTML helper.</param>
    /// <param name="children">The children.</param>
    /// <param name="displayFieldName">Display name of the field.</param>
    /// <param name="iconFieldName">Name of the icon field.</param>
    /// <param name="clickFieldName">Name of the click field.</param>
    /// <returns>Returns the HTML string.</returns>
    [NotNull]
    public static HtmlString Menu([NotNull] this SitecoreHelper htmlHelper, [NotNull] IEnumerable<Item> children, [NotNull] string displayFieldName, [NotNull] string iconFieldName, [NotNull] string clickFieldName)
    {
      Assert.ArgumentNotNull(htmlHelper, "htmlHelper");
      Assert.ArgumentNotNull(children, "children");
      Assert.ArgumentNotNull(displayFieldName, "displayFieldName");
      Assert.ArgumentNotNull(iconFieldName, "iconFieldName");
      Assert.ArgumentNotNull(clickFieldName, "clickFieldName");

      if (string.IsNullOrEmpty(clickFieldName))
      {
        clickFieldName = "Click";
      }

      var result = new StringWriter();

      foreach (var item in children)
      {
        if (string.Compare(item.Name, "PageSettings", StringComparison.InvariantCultureIgnoreCase) == 0)
        {
          continue;
        }

        if (item.Is(BootstrapApplication.Separator))
        {
          result.WriteLine("<li role=\"presentation\" class=\"divider\"></li>");
          continue;
        }

        if (item.Is(BootstrapApplication.Header))
        {
          result.WriteLine("<li role=\"presentation\" class=\"dropdown-header\">" + item["Text"] + "</li>");
          continue;
        }

        var displayName = item.GetField(displayFieldName, item.DisplayName);
        var icon = GetIconTag(item, iconFieldName, string.Empty);
        var href = HrefAttribute(htmlHelper, item, clickFieldName);

        /*
        if (item.HasChildren)
        {
          result.WriteLine("<li class=\"dropdown-submenu\" role=\"presentation\">");
          result.WriteLine("  <a tabindex=\"-1\" class=\"btn btn-default dropdown-toggle\"  data-toggle=\"dropdown\" {0}>{1} {2}</a>", href, icon, displayName);
          result.WriteLine("  <ul class=\"dropdown-menu\">");

          htmlHelper.Menu(item.Children, displayFieldName, iconFieldName, clickFieldName);

          result.WriteLine("  </ul>");
          result.WriteLine("</li>");
        }
        else
        {
          result.WriteLine("<li role=\"presentation\">");
          result.WriteLine("  <a tabindex=\"-1\" {0}>{1} {2}</a>", href, icon, displayName);
          result.WriteLine("</li>");
        }
        */
        result.WriteLine("<li role=\"presentation\">");
        result.WriteLine("  <a tabindex=\"-1\" {0}>{1} {2}</a>", href, icon, displayName);
        result.WriteLine("</li>");
      }

      return MvcHtmlString.Create(result.ToString());
    }

    #endregion

    #region Methods

    /// <summary>Gets the icon.</summary>
    /// <param name="item">The item.</param>
    /// <param name="fieldName">Name of the field.</param>
    /// <param name="additionalClassName"></param>
    /// <returns>Returns the string.</returns>
    [NotNull]
    private static string GetIconTag([NotNull] Item item, [NotNull] string fieldName, string additionalClassName)
    {
      Debug.ArgumentNotNull(item, "item");
      Debug.ArgumentNotNull(fieldName, "fieldName");

      if (string.IsNullOrEmpty(fieldName))
      {
        return string.Empty;
      }

      var size = 0;
      string result;
      switch (fieldName)
      {
        case "$icon":
          result = item.Appearance.Icon;
          break;

        case "$icon16x16":
          result = Images.GetThemedImageSource(item.Appearance.Icon, ImageDimension.id16x16);
          size = 16;
          break;

        case "$icon24x24":
          result = Images.GetThemedImageSource(item.Appearance.Icon, ImageDimension.id24x24);
          size = 24;
          break;

        case "$icon32x32":
          result = Images.GetThemedImageSource(item.Appearance.Icon, ImageDimension.id32x32);
          size = 32;
          break;

        case "$icon48x48":
          result = Images.GetThemedImageSource(item.Appearance.Icon, ImageDimension.id48x48);
          size = 48;
          break;

        default:
          result = item[fieldName];
          break;
      }

      if (string.IsNullOrEmpty(result))
      {
        return string.Empty;
      }

      if (result.IndexOf('/') >= 0)
      {
        var iconTag = "<img src=\"" + result + "\"";

        if (size > 0)
        {
          iconTag += string.Format(" height=\"{0}\" width=\"{0}\"", size);
        }

        if (!string.IsNullOrEmpty(additionalClassName))
        {
          iconTag += " class=\"" + additionalClassName + "\"";
        }

        iconTag += " alt =\"\" />";

        return iconTag;
      }

      if (!result.StartsWith("glyphicon-", StringComparison.InvariantCultureIgnoreCase))
      {
        result = "glyphicon-" + result;
      }

      if (!string.IsNullOrEmpty(additionalClassName))
      {
        result += " " + additionalClassName;
      }

      return string.Format("<i class=\"glyphicon {0}\"></i>", result);
    }

    #endregion
  }
}