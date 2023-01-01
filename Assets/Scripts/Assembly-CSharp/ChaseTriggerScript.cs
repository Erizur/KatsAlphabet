using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTriggerScript : MonoBehaviour
{
    public GameControllerScript gc;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && this.gc.mode == "roomchase" && this.gc.roomToShow == this.gameObject)
        {
            this.gc.RoomTriggerEvent();
            this.gameObject.SetActive(false);
        }
    }
}
