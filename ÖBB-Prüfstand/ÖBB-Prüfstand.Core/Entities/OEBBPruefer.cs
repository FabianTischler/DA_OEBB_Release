using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Core.Entities
{
    public class OEBBPruefer :EntityObject, IValidatableObject
    {
        [Required]
        [MinLength(2, ErrorMessage = "Vorname muss mindestens 2 Zeichen beinhalten.")]
        [MaxLength(50, ErrorMessage ="Vorname kann nicht länger als 50 Zeichen sein")]
        [DisplayName("Vorname")]
        public string V_Name { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Nachnahme muss mindestens 2 Zeichen beinhalten.")]
        [MaxLength(50, ErrorMessage ="Nachnahme kann nicht länger als 50 Zeichen sein")]
        [DisplayName("Nachnahme")]
        public string N_Name { get; set; }

        public string Name => $"{V_Name} {N_Name}";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(V_Name == N_Name)
            {
                yield return new ValidationResult("Vorname dar nicht gleich dem Nachname sein", new String[] { V_Name, N_Name });
            }
            yield return ValidationResult.Success;
        }
    }
}
