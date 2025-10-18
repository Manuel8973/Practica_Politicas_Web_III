using Microsoft.AspNetCore.Identity;

namespace NetIdentity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime FechaNacimiento { get; set; }
        public string? NombreCompleto { get; set; }
        public string genero { get; set; } = "O"; //Masculino | Femenino | Otro | GeneroX | GeneroY ; M | F | O | X | Y
        
        public const string MASCULINO = "M";
        public const string FEMENINO = "F";
        public const string OTRO = "O";
        public const string GENERO_X = "X";
        public const string GENERO_Y = "Y";
        
        //public bool isFemenino? (1) =0(masculino) | isMasculino 1|0 
    }
}
