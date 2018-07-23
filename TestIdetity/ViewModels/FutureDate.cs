using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TestIdetity.ViewModels
{
    public class FutureDate :ValidationAttribute
    {
       
        public override bool IsValid(object value)
        {
            DateTime dateTime;

           var isvalid= DateTime.TryParseExact(Convert.ToString(value), "d MMM yyyy", CultureInfo.CurrentCulture,DateTimeStyles.None,out dateTime);
            return (isvalid && dateTime > DateTime.Now);
        }

    }
}