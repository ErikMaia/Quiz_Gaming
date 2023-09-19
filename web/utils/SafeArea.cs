using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace web.utils;
public class SafeArea: PageModel
{
    protected bool safeAreaTest()
    {
        var cookie = Request.Cookies["user-id"];
        if (cookie != null)
        {
            return true;
        }
        return false;
    }
}
