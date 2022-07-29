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
    
    public class Enemy
    {
        public string EnemyName { get; set; }
        public int EnemyHP { get; set; }
        public int EnemyStrength { get; set; }

        public Enemy()
        {
            
        }
    }
    
    //GET
    public IActionResult BattlePreview(int? id)
    {

        Enemy enemy = new Enemy();
        Random rd = new Random();
        enemy.EnemyHP = rd.Next(10, 31);
        enemy.EnemyStrength = rd.Next(10, 31);

        Enemy charEnemy = new Enemy();
        var charEnemyList = _db.Characters.ToList();

        if (charEnemyList.Count > 0)
        {
            var chosenEnemy = charEnemyList[rd.Next(0, charEnemyList.Count)];
            charEnemy.EnemyName = chosenEnemy.Name;
            charEnemy.EnemyHP = chosenEnemy.HP;
            charEnemy.EnemyStrength = chosenEnemy.Strength;
        }

        var coinToss = rd.Next(0, 2);
        if (coinToss == 0)
        {
            ViewBag.Enemy = enemy;
        }
        else
        {
            ViewBag.Enemy = charEnemy;
        }
        

        var selection = _db.Characters.Find(id);
        return View(selection);
    }

    // GET
    public IActionResult BattleUpdate(string playerName, string enemyName, int playerHP, int enemyHP, int playerStrength, int enemyStrength)
    {
        enemyHP -= playerStrength;

        if (enemyHP <= 0)
        {
            return RedirectToAction("Victory");
        }

        playerHP -= enemyStrength;

        if (playerHP <= 0)
        {
            return RedirectToAction("Defeat");
        }

        ViewBag.PlayerName = playerName;
        ViewBag.EnemyName = enemyName;
        ViewBag.PlayerHP = playerHP;
        ViewBag.EnemyHP = enemyHP;
        ViewBag.PlayerStrength = playerStrength;
        ViewBag.EnemyStrength = enemyStrength;
        
        return View();
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