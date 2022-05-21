using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPickupScript : MonoBehaviour
{
    private void Start()
	{
	}

	// Token: 0x060009CA RID: 2506 RVA: 0x00025604 File Offset: 0x00023A04
	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f && this.gc.pet == 0 || Input.GetKeyDown(KeyCode.E) && Time.timeScale != 0f && this.gc.pet == 0)
		{
			Ray ray = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit))
			{
				if (raycastHit.transform.name == "Pickup_PetRock" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					this.gc.CollectPet(1);
				}
				else if (raycastHit.transform.name == "Pickup_PetGrass" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					this.gc.CollectPet(2);
				}
				else if (raycastHit.transform.name == "Pickup_PetHairball" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					this.gc.CollectPet(3);
				}
			}
		}
	}

	// Token: 0x040006DB RID: 1755
	public GameControllerScript gc;

	// Token: 0x040006DC RID: 1756
	public Transform player;
}
