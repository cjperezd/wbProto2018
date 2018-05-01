using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void MonsterRolChanged(Monster monster);

[CreateAssetMenu(fileName = "Team", menuName = "Entities/Team", order = 1)]
public class Team : ScriptableObject, IEntity
{
    public List<Monster> allTeamMonsters;
    public List<Monster> teamMembers;
    public List<Monster> teamReserves;
    public int gems;
    public int plasma;

    public event MonsterRolChanged OnMonsterRolChanged;

    #region Team Changes

    public void BuyMonster(Monster monsterToAdd)
    {
        this.allTeamMonsters.Add(monsterToAdd);
        this.gems -= monsterToAdd.marketValue;
    }

    public void ChangeTeamLeader(Monster newLeader)
    {
        Monster leader = this.allTeamMonsters.Find(x => x.rol == MonsterRol.Leader);
        if (leader != null)
        {
            leader.rol = MonsterRol.Reserve;
            this.teamMembers.Remove(leader);
            this.teamReserves.Add(leader);
            this.OnMonsterRolChanged(leader);
        }

        if (this.IsNotInTeam(newLeader))
        {
            newLeader.rol = MonsterRol.Leader;
            this.teamReserves.Remove(newLeader);
            this.teamMembers.Add(newLeader);
        }
    }

    public void ChangeTeamAttacker(Monster newAttacker)
    {
        Monster attacker = this.allTeamMonsters.Find(x => x.rol == MonsterRol.Attacker);
        if (attacker != null)
        {
            attacker.rol = MonsterRol.Reserve;
            this.teamMembers.Remove(attacker);
            this.teamReserves.Add(attacker);
            this.OnMonsterRolChanged(attacker);
        }

        if (this.IsNotInTeam(newAttacker))
        {
            newAttacker.rol = MonsterRol.Attacker;
            this.teamReserves.Remove(newAttacker);
            this.teamMembers.Add(newAttacker);
        }
    }

    public void ChangeTeamDefender(Monster newDefender)
    {
        Monster defender = this.allTeamMonsters.Find(x => x.rol == MonsterRol.Defender);
        if (defender != null)
        {
            defender.rol = MonsterRol.Reserve;
            this.teamMembers.Remove(defender);
            this.teamReserves.Add(defender);
            this.OnMonsterRolChanged(defender);
        }

        if (this.IsNotInTeam(newDefender))
        {
            newDefender.rol = MonsterRol.Defender;
            this.teamReserves.Remove(newDefender);
            this.teamMembers.Add(newDefender);
        }
    }

    #endregion


    public void ResolveMonstersTraining()
    {
        // We check them in reverse order because a monster can die during training and the collection would be modified.
        for (int i = this.allTeamMonsters.Count - 1; i >= 0; i--)
        {
            this.allTeamMonsters[i].ResolveTraining();
            this.allTeamMonsters[i].ResolveHealing(false);
        }
    }

    private void OnEnable()
    {
        foreach (Monster monster in this.allTeamMonsters)
        {
            monster.OnMonsterDied += OnMonsterDied;
            if (this.IsActualTeamMember(monster))
            {
                if (this.IsNotInTeam(monster))
                {
                    this.teamMembers.Add(monster);
                }
            }
            else
            {
                if (this.IsNotInReserves(monster))
                {
                    this.teamReserves.Add(monster);
                }
            }
        }
    }

    private bool IsNotInReserves(Monster monster)
    {
        return this.teamReserves.Find(x => x.name == monster.name) == null;
    }

    private bool IsNotInTeam(Monster monster)
    {
        return this.teamMembers.Find(x => x.name == monster.name) == null;
    }

    private void OnMonsterDied(Monster monster)
    {
        // TODO: ver si hay que sacarlo de la UI cuando este implementado la parte deinamica o no.
        if (!monster.alive)
        {
            this.plasma += monster.plasmaForSacrifice;
            this.RemoveMonsterFromCollections(monster);
        }
    }

    private void OnMonsterBought(Monster monster)
    {
        this.allTeamMonsters.Add(monster);
        this.teamReserves.Add(monster);
    }

    private void OnMonsterSold(Monster monster)
    {
        // TODO: ver si hay que sacarlo de la UI cuando este implementado la parte deinamica o no.
        this.RemoveMonsterFromCollections(monster);
    }

    private void RemoveMonsterFromCollections(Monster monster)
    {
        this.allTeamMonsters.Remove(monster);
        if (this.IsActualTeamMember(monster))
        {
            this.teamMembers.Remove(monster);
        }
        else
        {
            this.teamReserves.Remove(monster);
        }
        monster.rol = MonsterRol.Reserve;
    }

    private bool IsActualTeamMember(Monster monster)
    {
        return monster.rol == MonsterRol.Attacker ||
               monster.rol == MonsterRol.Defender ||
               monster.rol == MonsterRol.Leader;
    }
}
