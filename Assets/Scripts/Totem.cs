using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : Spell
{
    [SerializeField] private float _liveTime;

    private List<Enemy> _enemys;
    private Coroutine _work;

    public override void Use()
    {

    }

    public override void SetTarget(Enemy enemy)
    {
        _enemys.Add(enemy);
    }

    private IEnumerator Work()
    {
        while (_liveTime > 0)
        {
            SetTarget(null);
            yield return null;
        }
    }
}
