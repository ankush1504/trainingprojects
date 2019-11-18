using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dropdown2ndpage.Models
{
    public class UserFavlist
    {
        public IEnumerable<usertable> user1 { get; set; }

        public IEnumerable<favlist> fav1 { get; set; }
    }
}