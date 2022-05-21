using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class SchoolExploreScript : MonoBehaviour
{
    // Token: 0x0600002B RID: 43 RVA: 0x00002A10 File Offset: 0x00000E10
	private void Start()
	{
        this.text = base.GetComponent<TMP_Text>();
    }

	// Token: 0x0600002C RID: 44 RVA: 0x00002A20 File Offset: 0x00000E20
	private void Update()
	{
		if(this.exploreTimer > 0f)
        {
            this.exploreTimer -= 1f * Time.deltaTime;
            this.text.text = "Explore the school! \n" + Mathf.CeilToInt(this.exploreTimer) + " seconds left.";
        }
        else
        {
            this.text.text = string.Empty;
            if(this.gc.classTime == true)
            {
                this.gc.ActivateClassTime();
            }
        }

	}

	// Token: 0x0400002B RID: 43
	public GameControllerScript gc;

    public float exploreTimer;

	// Token: 0x0400002C RID: 44
	private TMP_Text text;
}
