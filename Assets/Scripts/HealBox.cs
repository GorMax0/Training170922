using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBox : Spell
{
    [SerializeField] private float _liveTime;

    private List<Enemy> _enemys;

    public override IEnumerator Use()
    {
        throw new System.NotImplementedException();
    }

    public override void SetTarget(Enemy enemy)
    {
        _enemys.Add(enemy);
    }
}
