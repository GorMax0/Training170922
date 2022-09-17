using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Spell> _spells;

    private Spell _selectedSpell;
    private Enemy _target;

    void Start()
    {
        foreach (Spell spell in _spells)
        {
            spell.gameObject.SetActive(false);
        }

        _selectedSpell = _spells[0];
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            _selectedSpell.gameObject.SetActive(true);
            _selectedSpell.Use();
        }
    }
}
