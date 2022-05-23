using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerConsole : MonoBehaviour
{
    private void Start()
	{
		this.hitBox = base.GetComponent<BoxCollider>();
	}

	// Token: 0x060009B6 RID: 2486 RVA: 0x00024DAE File Offset: 0x000231AE
	private void Update()
	{
	}

	// Token: 0x060009B7 RID: 2487 RVA: 0x00024DB0 File Offset: 0x000231B0
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			SceneManager.LoadScene("DeveloperConsole");
		}
	}

	// Token: 0x040006AF RID: 1711
	public PlayerScript ps;

	// Token: 0x040006B0 RID: 1712
	private BoxCollider hitBox;
}
