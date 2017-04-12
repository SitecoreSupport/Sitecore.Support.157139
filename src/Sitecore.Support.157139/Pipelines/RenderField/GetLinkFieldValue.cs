using Sitecore.Data.Items;
using Sitecore.Support.Xml.Xsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.Pipelines.RenderField
{
  public class GetLinkFieldValue:Sitecore.Pipelines.RenderField.GetLinkFieldValue
  {
    protected override Sitecore.Xml.Xsl.LinkRenderer CreateRenderer(Item item)
    {
      return new LinkRenderer(item);
    }
  }
}