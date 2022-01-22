using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class RebindSaveLoad : MonoBehaviour
{
    public InputActionAsset actions;

    private string GetPrefKey(){
        return $"rebinds/{actions.GetInstanceID()}";
    }
    public void OnEnable()
    {
        var key = GetPrefKey();

        var rebinds = PlayerPrefs.GetString(key);
        Debug.Log($"OnEnable {key}: " + rebinds);
        if (!string.IsNullOrEmpty(rebinds))
        {
            actions.LoadBindingOverridesFromJson(rebinds);
        }
    }

    public void OnDisable()
    {
        var key = GetPrefKey();

        var rebinds = actions.SaveBindingOverridesAsJson();
        Debug.Log($"OnDisable {key}: " + rebinds);
        PlayerPrefs.SetString(key, rebinds);
    }
}
