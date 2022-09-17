using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public abstract class Spell : MonoBehaviour
{
    [SerializeField] private int _power;
    [SerializeField] private int _distance;
    [SerializeField] private int _targetAccelerationForce;
    [SerializeField] private float _cooldown;

    private Enemy _enemy;
    private LineRenderer _rayRender;
    private Coroutine _coroutine;

    protected bool IsUse;

    protected int Power => _power;
    protected int Distance => _distance;
    protected int TargetAccelerationForce => _targetAccelerationForce;
    protected Enemy Enemy => _enemy;
    protected LineRenderer RayRender => _rayRender;

    private void Awake()
    {
        _rayRender = GetComponent<LineRenderer>();
    }

    public abstract IEnumerator Use();

    public void StartUse()
    {
        IsUse = true;

        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Use());
    }

    public void EndUse()
    {

    }

    public virtual void SetTarget(Enemy enemy)
    {
        if(enemy == null)
            throw new ArgumentNullException($"{nameof(enemy)} don't detected.");

        _enemy = enemy;
    }
}
