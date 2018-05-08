using UnityEngine.UI;

public class TrainMonster : MonsterDataForPanel
{
    public Dropdown trainningSelector;

    // TODO: Son solo valores para el prototipo
    public const int experiencePointsForLightTranning = 20;
    public const int damageForLightTraining = 20;
    public const int experiencePointsForMediumTranning = 35;
    public const int damageForMediumTraining = 35;
    public const int experiencePointsForHardTranning = 50;
    public const int damageForHardTraining = 50;

    public override void SetMonsterLabels()
    {
        this.levelLabel.text = string.Format(GlobalVars.Level, this.monster.level.ToString());
        this.attackPoints.text = string.Format(GlobalVars.AttackPoints, this.monster.attackPoints.ToString());
        this.defensePoints.text = string.Format(GlobalVars.DefensePoints, this.monster.defensePoints.ToString());
        this.totalLifePoints.text = string.Format(GlobalVars.TotalLifePoints, this.monster.totalLifePoints.ToString());
        this.actualLifePoints.text = string.Format(GlobalVars.ActualLifePoints, this.monster.actualLifePoints.ToString());
        this.mantainCost.text = string.Format(GlobalVars.MaintainceCost, this.monster.mantainCost.ToString());
        this.plasmaForSacrifice.text = string.Format(GlobalVars.PlasmaForSacrifice, this.monster.plasmaForSacrifice.ToString());
        this.experience.text = string.Format(GlobalVars.Experience, this.monster.experience.ToString());
        this.teamRol.text = string.Format(GlobalVars.TeamRol, this.monster.TeamRol);
        this.monsterName.text = this.monster.name;

        // TODO: ver si se puede sacar este switch horrible por algo como lo que esta en Admin MOnster.
        switch (this.monster.actualTrainning)
        {
            case TrainningType.NoTraining:
                this.monster.actualTrainning = 0;
                break;
            case TrainningType.Light:
                this.trainningSelector.value = 1;
                break;
            case TrainningType.Medium:
                this.trainningSelector.value = 2;
                break;
            case TrainningType.Hard:
                this.trainningSelector.value = 3;
                break;
        }

        this.trainningSelector.onValueChanged.AddListener(delegate
        {
            TrainningModeChanged(this.trainningSelector);
        });
    }

    private void TrainningModeChanged(Dropdown change)
    {
        // TODO: ver si se puede sacar este switch horrible por algo como lo que esta en Admin MOnster.
        switch (change.value)
        {
            case 0:
                this.monster.actualTrainning = TrainningType.NoTraining;
                break;
            case 1:
                this.monster.actualTrainning = TrainningType.Light;
                break;
            case 2:
                this.monster.actualTrainning = TrainningType.Medium;
                break;
            case 3:
                this.monster.actualTrainning = TrainningType.Hard;
                break;
        }
    }
}
