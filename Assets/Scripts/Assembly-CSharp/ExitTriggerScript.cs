using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000BF RID: 191
public class ExitTriggerScript : MonoBehaviour
{
	// Token: 0x06000962 RID: 2402 RVA: 0x000219A0 File Offset: 0x0001FDA0
	private void OnTriggerEnter(Collider other)
	{
		if (this.gc.notebooks >= 8 & other.tag == "Player")
		{
			if(this.gc.pet != 0){
				switch (this.gc.pet)
				{
					case 1:
						PlayerPrefs.SetInt("PetRock", 1);
						break;
					case 2:
						PlayerPrefs.SetInt("PetGrass", 1);
						break;
					case 3:
						PlayerPrefs.SetInt("PetHairball", 1);
						break;
					default:
						break;
				}
			}
			SceneManager.LoadScene("Results");
			//you will always get the win screen
		}
	}

	// Token: 0x040005F6 RID: 1526
	public GameControllerScript gc;
}
