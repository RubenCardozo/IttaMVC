using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNovembre2017.Models
{
    public class AntiChuckAttribute : ValidationAttribute, IClientValidatable
    {

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule AntiChuck = new ModelClientValidationRule();
            AntiChuck.ErrorMessage = ErrorMessageString;
            AntiChuck.ValidationType = "antichuck";
            yield return AntiChuck;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value.ToString().ToUpper()=="CHUCK")
            {
                
                return new ValidationResult(ErrorMessage??"Seul Chuck peut passer ce contraint");          
            }
            return null;
        }

        
    }
}