using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGemBitHolder : MonoBehaviour
{
    public BGemBit gemBit;
    public int value;
    public void ReleaseBits()
    {
        for (int i = 0; i < 1000 && value > 0; i++)
        {
            var bit = Instantiate(gemBit, transform.position, Quaternion.identity);
            bit.RandomlyScatter();
            value -= bit.value;
            if (value < 0) bit.value += value;
        }
    }
}
