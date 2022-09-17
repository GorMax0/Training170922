using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : Spell
{
    [SerializeField] private float _liveTime;

    private List<Enemy> _enemys;

    public override IEnumerator Use()
    {
        yield return null;
    }

    public override void SetTarget(Enemy enemy)
    {
        _enemys.Add(enemy);
    }
}
