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
    public int HP { get; set; }
    [Required]
    public int Strength { get; set; }

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