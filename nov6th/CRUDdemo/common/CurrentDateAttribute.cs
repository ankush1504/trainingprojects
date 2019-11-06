using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUDdemo.common
{
    public class CurrentDateAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime datetime = Convert.ToDateTime(value);
            return (datetime < DateTime.Now);
        }

    }
}