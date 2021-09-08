using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shoping_Cart.Models
{
    public class ok
    {
        public static List<cartitem> c = new List<cartitem>();//list object
    }
    public class cartitem
    {
        public int iid;
        public int iqty;
    }
}