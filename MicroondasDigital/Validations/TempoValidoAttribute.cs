using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicroondasDigital.Validations
{
    public class TempoValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int tempo = 0;

            try
            {
                tempo = int.Parse(value.ToString());
                if (tempo < 1 || tempo > 120)
                    return new ValidationResult("O tempo de cozinhamento deve ser superior a 1 segundo e inferior a 2 minutos");
            }
            catch(Exception e)
            {
                return new ValidationResult("Informe o tempo de cozinhamento");
            }

            return ValidationResult.Success;
        }
    }
}