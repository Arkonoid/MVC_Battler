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
    [Range(1, 200)]
    [DisplayName("Health")]
    public int HP { get; set; }
    [Required]
    [Range(1, 50)]
    public int Strength { get; set; }
    [Required]
    [Range(1,20)]
    public int Toughness { get; set; }

    public Character()
    {
        
    }
}
public class Player : Character
    {
        public Player()
        {
        
        }
    }

public class Enemy : Character
{
    public Enemy()
    {
        
    }
}

public class Combatant : Character
{
    public Combatant()
    {
        
    }
}