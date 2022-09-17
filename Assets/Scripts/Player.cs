using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private List<Spell> _spells;

    private Rigidbody _rigidbody;
    private Spell _selectedSpell;
    private Enemy _target;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        foreach (Spell spell in _spells)
        {
            spell.gameObject.SetActive(false);
        }

        _selectedSpell = _spells[0];
        _selectedSpell.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent(out Enemy enemy))
                {
                    _selectedSpell.SetTarget(enemy);
                    _selectedSpell.StartUse();
                }
            }
        }

        Move();
    }

    private void Move()
    {
        const string Horizontal = "Horizontal";
        const string Vertical = "Vertical";

        float _rotationX = Input.GetAxis(Horizontal);
        float vertical = Input.GetAxis(Vertical);

        _rigidbody.velocity = transform.forward * vertical * _speed;
        transform.Rotate(_rotationX * new Vector3(0, 1, 0));
    }
}
