using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.Components
{
    public class EnumSelectInput : InputBase<string>
    {
        [Parameter] public Expression<Func<string>> ValidationFor { get; set; }

        protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
        {
            try
            {
                result = (T)Enum.Parse(typeof(T), value);
                validationErrorMessage = null;
                return true;
            }
            catch (ArgumentException)
            {
                result = default;
                validationErrorMessage = $"The {FieldIdentifier.FieldName} field is not valid.";

                return false;
            }
        }
    }
}
