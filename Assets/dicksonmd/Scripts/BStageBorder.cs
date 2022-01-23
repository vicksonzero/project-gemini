using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BStageBorder : MonoBehaviour
{
    public void OnTriggerExit2D(Collider2D collider)
    {
        // Debug.Log("OnTriggerExit");
        var behaviour = collider.gameObject.GetComponent<BLeaveStageAtBorder>();
        if (behaviour != null)
        {
            behaviour.Exit();
        }
    }
}
