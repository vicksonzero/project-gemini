using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BFixedTimeLabel : MonoBehaviour
{
    Text label;
    // Start is called before the first frame update
    void Start()
    {
        label = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        label.text = $"{Time.fixedTime}";
    }
}
