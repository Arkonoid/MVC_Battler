using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Battler.Data;
using MVC_Battler.Models;

namespace MVC_Battler.Controllers;

public class BattleController : Controller
{
    private readonly ApplicationDbContext _db;

    public BattleController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    //GET
    public IActionResult BattlePreview(int? id)
    {
        Random random = new Random();
        
        Combatant tempPlayer = new Combatant()
        {
            Name = _db.Players.Find(id).Name,
            HP = _db.Players.Find(id).HP,
            Strength = _db.Players.Find(id).Strength
        };

        var charEnemyList = _db.Players.ToList();
        var chosenEnemy = charEnemyList[random.Next(0, charEnemyList.Count)];
        
        Combatant tempEnemy = new Combatant()
        {
            Name = chosenEnemy.Name,
            HP = chosenEnemy.HP,
            Strength = chosenEnemy.Strength
        };

        _db.Combatants.Add(tempPlayer);
        _db.Combatants.Add(tempEnemy);
        _db.SaveChanges();
        
        List<Character> combatants = new List<Character>() {tempPlayer, tempEnemy};

        return View(combatants);
    }

    // GET
    public IActionResult BattleUpdate(int playerId, int enemyId)
    {
        var tempPlayer = _db.Combatants.Find(playerId);
        var tempEnemy = _db.Combatants.Find(enemyId);
        
        //Player's Turn
        tempEnemy.HP -= tempPlayer.Strength;
        
        //Check to See if Enemy is Dead
        if (tempEnemy.HP <= 0)
        {
            return RedirectToAction("Victory");
        }
        
        //Enemy's Turn
        tempPlayer.HP -= tempEnemy.Strength;
        
        //Check to See if Player is Dead
        if (tempPlayer.HP <= 0)
        {
            return RedirectToAction("Defeat");
        }

        _db.SaveChanges();
        
        //Continue Battle
        List<Character> combatants = new List<Character>() {tempPlayer, tempEnemy};
        
        return View(combatants);
    }

    public IActionResult Victory()
    {
        return View();
    }
    
    public IActionResult Defeat()
    {
        return View();
    }
}

