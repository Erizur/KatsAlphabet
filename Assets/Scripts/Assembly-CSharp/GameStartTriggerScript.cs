using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
	{
		if (this.gc.notebooks >= 2 & other.tag == "Player" && hasPlayed == false)
		{
            hasPlayed = true;
			this.gc.ActivateSpoopMode();
            this.gc.baldiScrpt.GetAngry(1f);
		}
	}

    public GameControllerScript gc;
    private bool hasPlayed = false;
}
