using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Xml.Xsl;

namespace Sitecore.Support.Xml.Xsl
{
  public class LinkRenderer :Sitecore.Xml.Xsl.LinkRenderer
  {
    #region fix for 157139
    public LinkRenderer(Item item):base(item)
    {
      
    }
    protected override string GetUrl(XmlField field)
    {
      if (field != null)
      {
        return new Sitecore.Support.Xml.Xsl.LinkUrl().GetUrl(field, this.Item.Database);
      }
      var urlOptions = LinkManager.GetDefaultUrlOptions();
      urlOptions.SiteResolving = Sitecore.Configuration.Settings.Rendering.SiteResolving;

      return LinkManager.GetItemUrl(this.Item, urlOptions);
    }
    #endregion
  }



}
