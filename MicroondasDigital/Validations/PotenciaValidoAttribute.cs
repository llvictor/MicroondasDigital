using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicroondasDigital.Validations
{
    public class PotenciaValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int potencia = 0;

            try
            {
                potencia = int.Parse(value.ToString());
                if (potencia < 1 || potencia > 10)
                    return new ValidationResult("A potência deve ser superior a 1 e inferior a 10");

            }
            catch (Exception e)
            {
                return new ValidationResult("Informe a potência");
            }

            return ValidationResult.Success;
        }
    }
}