﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS.ECP.Web.WebPager
{
  internal class PagerItem
{
    // Methods
    public PagerItem(string text, int pageIndex, bool disabled, PagerItemType type)
    {
        this.Text = text;
        this.PageIndex = pageIndex;
        this.Disabled = disabled;
        this.Type = type;
    }

    // Properties
    internal bool Disabled { get; set; }

    internal int PageIndex { get; set; }

    internal string Text { get; set; }

    internal PagerItemType Type { get; set; }
}



}