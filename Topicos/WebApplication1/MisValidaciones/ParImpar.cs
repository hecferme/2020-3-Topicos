using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.MisValidaciones
{
    public class ParImparAttribute : ValidationAttribute
    {
        private bool _EsPar = false;

        public ParImparAttribute()
        {
            _EsPar = true;
        }
        public ParImparAttribute(bool EsPar)
        {
            _EsPar = EsPar;
        }

        public string GetErrorMessage(int codigoMensaje)
        {
            var mensaje = string.Empty;
            switch (codigoMensaje)
            {
                case -1:
                    mensaje = $"El número es par y sólo se permiten números impares.";
                    break;
                        
                case -2:
                    mensaje = $"El número es impar y sólo se permiten números pares.";
                    break;
            }
            return mensaje;
        }



        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int elNumero;
            if( ! int.TryParse(value.ToString(), out elNumero))
            {
                return ValidationResult.Success;
            }

            bool elNumeroEsPar = (elNumero % 2 == 0);

            if (elNumeroEsPar && !_EsPar)
            {
                return new ValidationResult(GetErrorMessage(-1));
            }
            if (!elNumeroEsPar && _EsPar)
            {
                return new ValidationResult(GetErrorMessage(-2));
            }
            return ValidationResult.Success;
        }
    }
}
