using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacultyAudioScript : MonoBehaviour
{
    // Token: 0x06000943 RID: 2371 RVA: 0x00021436 File Offset: 0x0001F836
	private void OnTriggerEnter(Collider other)
	{
		if (this.gc.notebooks >= 2 & other.tag == "Player" && this.gc.didWarning == false && this.gc.spoopMode == false)
		{
            this.gc.didWarning = true;
            this.gc.schoolMusic.volume = 0.5f;
			this.audioDevice.PlayOneShot(this.baldiDoor, 1f);
		}
	}

	// Token: 0x040005D6 RID: 1494
	public GameControllerScript gc;

	// Token: 0x040005D7 RID: 1495
	public AudioSource audioDevice;

	// Token: 0x040005D8 RID: 1496
	public AudioClip baldiDoor;
}
