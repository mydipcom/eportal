﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS.ECP.Web.WebPager
{
    public interface IPagedList<T> : IEnumerable<T>, IPagedList, IEnumerable
    {
    }

 

 


}