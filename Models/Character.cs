using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Battler.Models;

public class Character
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [DisplayName("Health")]
    [Range(1,100,ErrorMessage = "Must be between 1 and 100.")]
    public int HP { get; set; }
    [Required]
    [Range(1,100,ErrorMessage = "Must be between 1 and 100.")]
    public int Strength { get; set; }

    public Character()
    {
        
    }
}