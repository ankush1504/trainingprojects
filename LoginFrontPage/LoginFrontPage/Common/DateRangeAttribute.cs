using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace LoginFrontPage.Common
{
    public class DateRangeAttribute:RangeAttribute
    {
       public DateRangeAttribute(string minimumvalue,string maxvalue) :
       base(typeof(DateTime), minimumvalue, maxvalue)
        {

        }
    }
}