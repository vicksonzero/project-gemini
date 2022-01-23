using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BClosePanel : MonoBehaviour
{
    public Button closeButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
