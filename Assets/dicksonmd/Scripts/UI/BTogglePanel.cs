using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTogglePanel : MonoBehaviour
{
    public Canvas panel;
    public bool startClosed = true;
    // Start is called before the first frame update
    void Start()
    {
        if (panel == null)
        {
            panel = GetComponent<Canvas>();
        }
        panel.enabled = !startClosed;
    }

    public void OpenPanel()
    {
        SetPanel(true);
    }
    public void ClosePanel()
    {
        SetPanel(false);

    }
    public void TogglePanel()
    {
        panel.enabled = !panel.enabled;
    }
    public void SetPanel(bool val)
    {
        panel.enabled = val;
    }
}
