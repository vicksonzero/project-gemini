using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPlayer : MonoBehaviour
{
    public Transform gemAnchor;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnGemAdded()
    {
        var weapons = GetComponentsInChildren<BGunWeapon>(true);
        foreach (var weapon in weapons)
        {
            weapon.TryDowngrade();
        }
    }
    public void OnGemRemoved()
    {
        var weapons = GetComponentsInChildren<BGunWeapon>(true);
        foreach (var weapon in weapons)
        {
            weapon.TryUpgrade();
        }
    }
}
