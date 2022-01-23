using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BScrollingBackground : MonoBehaviour
{
    public float vSpeed = 1;
    MeshRenderer meshRenderer;
    public float currentscroll = 0f;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentscroll += vSpeed * Time.deltaTime;
        var currentOffset = meshRenderer.material.GetTextureOffset("_MainTex");
        meshRenderer.material.SetTextureOffset("_MainTex", new Vector2(0, currentscroll));
        meshRenderer.material.mainTextureOffset = new Vector2(0, currentscroll);
    }
}
