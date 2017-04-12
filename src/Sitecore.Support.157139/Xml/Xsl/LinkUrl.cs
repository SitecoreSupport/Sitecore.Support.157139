using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.Data.Items;
using Sitecore.Text;
using Sitecore.Links;
using Sitecore.Xml.Xsl;

namespace Sitecore.Support.Xml.Xsl
{
  public class LinkUrl : Sitecore.Xml.Xsl.LinkUrl
  {
    protected override string GetInternalUrl(Database database, string url, string itemID, string anchor, string queryString)
    {
      #region native code
      Assert.ArgumentNotNull(database, "database");
      Assert.ArgumentNotNull(url, "url");
      Assert.ArgumentNotNull(itemID, "itemID");
      Assert.ArgumentNotNull(anchor, "anchor");
      Assert.ArgumentNotNull(queryString, "queryString");
      Item item = database.Items[url] ?? database.Items[itemID];
      if (item == null)
      {
        return string.Empty;
      }
      if (item.Paths.IsMediaItem)
      {
        return this.GetMediaUrl(database, itemID);
      }
      #endregion
      #region fix for 157139
      var urlOptions = LinkManager.GetDefaultUrlOptions();
      urlOptions.SiteResolving = Sitecore.Configuration.Settings.Rendering.SiteResolving;

      var str = LinkManager.GetItemUrl(item, urlOptions)+this.GetQueryString(queryString)+anchor;
      #endregion
      return str;
    }








  }
}