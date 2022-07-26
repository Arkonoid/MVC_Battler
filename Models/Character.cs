using System.ComponentModel.DataAnnotations;

namespace MVC_Battler.Models;

public class Character
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int HP { get; set; }
    [Required]
    public int Strength { get; set; }

    public Character()
    {
        
    }
}