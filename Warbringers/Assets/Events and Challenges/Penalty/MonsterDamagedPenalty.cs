using UnityEngine;

[CreateAssetMenu(fileName = "MonsterDamagedPenalty", menuName = "Challenges/Penalties/MonsterDamagedPenalty", order = 2)]
public class MonsterDamagedPenalty : Penalty
{
    public int damage;
    private string monsterDamagedName = "";
    public override void ApplyPenalty(IEntity entity)
    {
        Monster monster = (entity as Monster);
        monster.GetDamage(this.damage);
    }

    public override string DescriptionGetter()
    {
        return string.Format(GlobalVars.MonsterDamagedPenalty, this.monsterDamagedName,this.damage);
    }
}
