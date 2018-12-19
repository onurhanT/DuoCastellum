public class EnemyMinionFactory {
    public EnemyMinion MakeEnemyMinion(string name)
    {
        if (string.Equals(name, "Warrior"))
        {
            return new EnemyWarrior();
        }
        else if (string.Equals(name, "Boss"))
        {
            return new EnemyBoss();
        }
        else if (string.Equals(name, "Archer"))
        {
            return new EnemyArcher();
        }
        else
        {
            return null;
        }
    }
}