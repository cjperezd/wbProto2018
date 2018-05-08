using System.Collections.Generic;
using UnityEngine;

public abstract class Requirement: ScriptableObject
{
    public string description
    {
        get
        {
            return this.DescriptionGetter();
        }
    }

    public abstract bool RequirementFulfilled();
    public abstract string DescriptionGetter();

    //TODO: esto se podria hacer de otra manera, sino en cada lugar que lo estamos consultando, esta controlando / generando de nuevo las colecciones.
    public abstract List<Monster> GetMonstersFullfillingRequirement();

    // TODO: otros requerimientos son: 
    // 1) experimentar con un monstruo... que le hace? que pide?
    // 3) combate clandestino.
}
