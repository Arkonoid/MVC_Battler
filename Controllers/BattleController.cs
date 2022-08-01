using Microsoft.AspNetCore.Mvc;
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
        var random = new Random();

        var tempPlayer = new Combatant
        {
            Name = _db.Players.Find(id).Name,
            HP = _db.Players.Find(id).HP,
            Strength = _db.Players.Find(id).Strength,
            Toughness = _db.Players.Find(id).Toughness
        };

        var charEnemyList = _db.Players.ToList();
        var chosenEnemy = charEnemyList[random.Next(0, charEnemyList.Count)];

        var tempEnemy = new Combatant
        {
            Name = chosenEnemy.Name,
            HP = chosenEnemy.HP,
            Strength = chosenEnemy.Strength,
            Toughness = chosenEnemy.Toughness
        };

        _db.Combatants.Add(tempPlayer);
        _db.Combatants.Add(tempEnemy);
        _db.SaveChanges();

        var combatants = new List<Character> {tempPlayer, tempEnemy};

        return View("BattleUpdate",combatants);
    }

    // GET
    public IActionResult BattleUpdate(int playerId, int enemyId, string playerTurn, string enemyTurn)
    {
        //Convert combatant ids into their respective objects
        var tempPlayer = _db.Combatants.Find(playerId);
        var tempEnemy = _db.Combatants.Find(enemyId);

        ////////////////////////////////////////////////////////////
        //                                                        //
        //                    PLAYER'S TURN                       //
        //                                                        //
        ////////////////////////////////////////////////////////////
        
        //Fight Option
        if (playerTurn == "Fight")
        {
            //Deal damage
            tempEnemy.HP -= Math.Max(tempPlayer.Strength - tempEnemy.Toughness / 2, 0);

            //Check to see if enemy is dead
            if (tempEnemy.HP <= 0) return RedirectToAction("Victory");
        }
        
        //Defend Option
        if (playerTurn == "Defend")
        {
            //Increase Toughness
            tempPlayer.Toughness *= 2;
        }

        ////////////////////////////////////////////////////////////
        //                                                        //
        //                    ENEMY'S TURN                        //
        //                                                        //
        ////////////////////////////////////////////////////////////
        
        //Fight Option
        if (enemyTurn == "Fight")
        {
            //Deal damage
            tempPlayer.HP -= Math.Max(tempEnemy.Strength - tempPlayer.Toughness / 2, 0);

            //Check to see if player is dead
            if (tempPlayer.HP <= 0) return RedirectToAction("Defeat");
        }
        
        ////////////////////////////////////////////////////////////
        //                                                        //
        //                 CONTINUE BATTLE LOOP                   //
        //                                                        //
        ////////////////////////////////////////////////////////////
        
        //Save changes to the database
        _db.SaveChanges();
        
        //Put the combatants into the @model list
        var combatants = new List<Character> {tempPlayer, tempEnemy};

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