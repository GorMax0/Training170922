using System;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [SerializeField] private int _power;
    [SerializeField] private int _distance;
    [SerializeField] private int _targetAccelerationForce;
    [SerializeField] private float _cooldown;

    private Enemy _enemy;

    protected int Power => _power;

    public abstract void Use();

    public virtual void SetTarget(Enemy enemy)
    {
        if(enemy == null)
            throw new ArgumentNullException($"{nameof(enemy)} don't detected.");

        _enemy = enemy;
    }
}
