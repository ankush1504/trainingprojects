using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CRUDdemo.common
{
    public class DateRangeAttribute:RangeAttribute
    {

        public DateRangeAttribute(string minimumvalue) :
           base(typeof(DateTime), minimumvalue, DateTime.Now.ToShortDateString())
        {

        }
    }
}