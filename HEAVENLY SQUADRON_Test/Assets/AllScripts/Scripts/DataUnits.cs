using System.Collections.Generic;

public class DataUnits 
{
    private const string ENEMY_ID = "Enemy_";
    private static int idEnemy = 1;

    private static Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>();

    public static void RegisterEnemy(Enemy enemy)
    {
        string enemyId = $"{ENEMY_ID}_{idEnemy}";
        idEnemy++;
        enemies.Add(enemyId, enemy);
        enemy.transform.name = enemyId;
    }
    public static void UnRegisterEnemy(string enemyID)
    {
        enemies.Remove(enemyID);
    }
    public static Enemy GetEnemy(string enemyID)
    {
        return enemies[enemyID];
    }
}
