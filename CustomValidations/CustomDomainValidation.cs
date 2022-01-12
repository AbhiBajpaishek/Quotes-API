using System.ComponentModel.DataAnnotations;

namespace Quotes_API.CustomValidations
{
    public class CustomDomainValidation : ValidationAttribute
    {
        private readonly string _customDomain;
        public CustomDomainValidation(string customDomain)
        {
            _customDomain = customDomain;
        }
        public override bool IsValid(object value)
        {
            string enteredDomain =  value.ToString().Split('@')[1];
            return (enteredDomain.ToLower() == _customDomain.ToLower());
        }


    }
}