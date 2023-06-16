using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Factory_Enemy : Factory<Unit_Enemy>
{
    IDictionary<string, Unit_Enemy> dict = new Dictionary<string, Unit_Enemy>();
    
    public Factory_Enemy(Unit_Enemy[] objs) : base(objs)
    {
        foreach(Unit_Enemy obj in objs)
        {
            dict.Add(obj.name, obj);
        }
    }

    public override Unit_Enemy CreateNew(string Name)
    {
        foreach (Unit_Enemy obj in dict.Values)
        {
            if(obj.name== Name)
            {
                return pool.Get(Name);
            }
        }

        return null;
    }

    public override Unit_Enemy CreateRandom()
    {
        int rand = Random.Range(0,dict.Count);

        Unit_Enemy obj = pool.Get(dict.ElementAt(rand).Value.name);

        return obj;
    }
}
