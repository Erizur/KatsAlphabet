using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x020000C2 RID: 194
public class MathGameScript : MonoBehaviour
{

    private String Number2String(int number, bool isCaps)
    {
        Char c = (Char)((isCaps ? 65 : 97) + (number - 1));
        return c.ToString();
    }

    // Token: 0x06000982 RID: 2434 RVA: 0x000231E0 File Offset: 0x000215E0
    private void Start()
    {
        this.gc.ActivateLearningGame();
        if (this.gc.notebooks == 1)
        {
            this.QueueAudio(this.bal_intro);
        }
        this.NewProblem();
        if (this.gc.spoopMode)
        {
            this.baldiFeedTransform.position = new Vector3(-1000f, -1000f, 0f);
        }
    }

    // Token: 0x06000983 RID: 2435 RVA: 0x00023270 File Offset: 0x00021670
    private void Update()
    {
        if (!this.baldiAudio.isPlaying)
        {
            if (this.audioInQueue > 0 & !this.gc.spoopMode)
            {
                this.PlayQueue();
            }
            this.baldiFeed.SetBool("talking", false);
        }
        else
        {
            this.baldiFeed.SetBool("talking", true);
        }
        if ((Input.GetKeyDown("return") || Input.GetKeyDown("enter")) & this.questionInProgress)
        {
            this.questionInProgress = false;
            this.CheckAnswer();
        }
        if (this.problem > 4)
        {
            this.endDelay -= 1f * Time.unscaledDeltaTime;
            if (this.endDelay <= 0f)
            {
                if(this.gc.notebooks < 2)
                {
                    GC.Collect();
                    if(this.problemsWrong >= 3 && this.gc.notebooks == 2){
                        this.gc.RestartLearningGame(base.gameObject);
                    }
                    else{
                        this.gc.CollectNotebook();
                        this.gc.RestartLearningGame(base.gameObject);
                    }

                }
                else
                {
                    GC.Collect();
                    if(this.problemsWrong >= 3){
                        this.gc.RestartLearningGame(base.gameObject);
                    }
                    else{
                        this.ExitGame();
                    }
                }
            }
        }
    }

    // Token: 0x06000984 RID: 2436 RVA: 0x00023350 File Offset: 0x00021750
    private void NewProblem()
    {
        this.playerAnswer.text = string.Empty;
        this.problem++;
        this.playerAnswer.ActivateInputField();
        if (this.problem <= 4)
        {
            this.QueueAudio(this.bal_problems[this.problem - 1]);
            if ((this.gc.mode == "story" & (this.problem <= 3 || this.gc.notebooks <= 2)) || (this.gc.mode == "endless" & (this.problem <= 3 || this.gc.notebooks != 2)))
            {
                this.num1 = (float)Mathf.RoundToInt(UnityEngine.Random.Range(1f, 26f));
                switch(this.num1){
                    case 1:
                        this.thType = "st";
                        break;
                    case 2:
                        this.thType = "nd";
                        break;
                    case 3:
                        this.thType = "rd";
                        break;
                    default:
                        this.thType = "th";
                        break;
                }
                this.sign = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
                if (this.sign == 0)
                {
                    this.solution = Number2String(Mathf.RoundToInt(this.num1), true);
                    this.questionText.text = string.Concat(new object[]
                    {
                        "What's the ",
                        this.num1 + thType,
                        " letter of the Alphabet?"
                    });
                }
                else if (this.sign == 1)
                {
                    this.solution = Number2String(Mathf.RoundToInt(this.num1), true);
                    this.questionText.text = string.Concat(new object[]
                    {
                        "What's the ",
                        this.num1 + thType,
                        " letter of the Alphabet?"
                    });
                }
            }
            else
            {
                this.impossibleMode = true;
                this.num1 = UnityEngine.Random.Range(1f, 9999f);
                this.num2 = UnityEngine.Random.Range(1f, 9999f);
                this.num3 = UnityEngine.Random.Range(1f, 9999f);
                this.sign = Mathf.RoundToInt((float)UnityEngine.Random.Range(0, 1));
                this.QueueAudio(this.bal_screech);
                if (this.sign == 0)
                {
                    this.questionText.text = string.Concat(new object[]
                    {
                        "EXCEPTION OCCURRED, ERROR CODE: \n",
                        this.num1,
                        this.num2,
                        this.num3
                    });
                }
                else if (this.sign == 1)
                {
                    this.questionText.text = string.Concat(new object[]
                    {
                        "INTERNAL SYSTEM ERROR, ERROR CODE: \n",
                        this.num1,
                        this.num2,
                        this.num3
                    });
                }
                this.num1 = UnityEngine.Random.Range(1f, 9999f);
                this.num2 = UnityEngine.Random.Range(1f, 9999f);
                this.num3 = UnityEngine.Random.Range(1f, 9999f);
                this.sign = Mathf.RoundToInt((float)UnityEngine.Random.Range(0, 1));
                if (this.sign == 0)
                {
                    this.questionText2.text = string.Concat(new object[]
                    {
                        "EXCEPTION OCCURRED, ERROR CODE: \n",
                        this.num1,
                        this.num2,
                        this.num3
                    });
                }
                else if (this.sign == 1)
                {
                    this.questionText2.text = string.Concat(new object[]
                    {
                        "INTERNAL SYSTEM ERROR, ERROR CODE: \n",
                        this.num1,
                        this.num2,
                        this.num3
                    });
                }
                this.num1 = UnityEngine.Random.Range(1f, 9999f);
                this.num2 = UnityEngine.Random.Range(1f, 9999f);
                this.num3 = UnityEngine.Random.Range(1f, 9999f);
                this.sign = Mathf.RoundToInt((float)UnityEngine.Random.Range(0, 1));
                if (this.sign == 0)
                {
                    this.questionText3.text = string.Concat(new object[]
                    {
                        "EXCEPTION OCCURRED, ERROR CODE: \n",
                        this.num1,
                        this.num2,
                        this.num3
                    });
                }
                else if (this.sign == 1)
                {
                    this.questionText3.text = string.Concat(new object[]
                    {
                        "INTERNAL SYSTEM ERROR, ERROR CODE: \n",
                        this.num1,
                        this.num2,
                        this.num3
                    });
                }
            }
            this.questionInProgress = true;
        }
        else
        {
            this.endDelay = 5f;
            if (!this.gc.spoopMode && this.gc.notebooks < 2 && this.problemsWrong <= 1)
            {
                this.questionText.text = "Great Job!";
            }
            else if(!this.gc.spoopMode && this.gc.notebooks < 2 && this.problemsWrong <= 2)
            {
                this.questionText.text = "It's okay, you can do better!";
            }
            else if(!this.gc.spoopMode && this.gc.notebooks >= 2 && this.problemsWrong < 3)
            {
                this.questionText.text = "You finished the game!";
            }
            else if (this.gc.mode == "endless" & this.problemsWrong <= 0)
            {
                int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
                this.questionText.text = this.endlessHintText[num];
            }
            else if (this.gc.mode == "story" & this.problemsWrong >= 4)
            {
                this.questionText.text = "You have answered \neverything incorrectly.";
                this.questionText2.text = string.Empty;
                this.questionText3.text = string.Empty;
                this.questionText4.text = string.Empty;
                if (this.baldiScript.isActiveAndEnabled) this.baldiScript.Hear(this.playerPosition, 7f);
                this.gc.failedNotebooks++;
            }
            else
            {
                int num2 = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
                this.questionText.text = this.hintText[num2];
                this.questionText2.text = string.Empty;
                this.questionText3.text = string.Empty;
                this.questionText4.text = string.Empty;
            }
            if(!this.gc.spoopMode && this.gc.notebooks < 2 && this.problemsWrong <= 2)
            {
                this.questionText.text = this.questionText.text + "\nMore questions coming...";
            }
            else if(!this.gc.spoopMode && this.gc.notebooks == 2 && this.problemsWrong >= 3)
            {
                this.questionText.text = this.questionText.text + "\nRestarting game...";
            }
        }
    }

    // Token: 0x06000985 RID: 2437 RVA: 0x00023BB8 File Offset: 0x00021FB8
    public void OKButton()
    {
        this.CheckAnswer();
    }

    // Token: 0x06000986 RID: 2438 RVA: 0x00023BC0 File Offset: 0x00021FC0
    public void CheckAnswer()
    {
        if (this.playerAnswer.text == "31718")
        {
            base.StartCoroutine(this.CheatText("THIS IS WHERE IT ALL BEGAN"));
            SceneManager.LoadSceneAsync("TestRoom");
        }
        else if (this.playerAnswer.text == "53045009")
        {
            base.StartCoroutine(this.CheatText("USE THESE TO STICK TO THE CEILING!"));
            this.gc.Fliparoo();
        }
        if (this.problem <= 4)
        {
            if (this.playerAnswer.text.ToLower() == this.solution.ToLower() & !this.impossibleMode)
            {
                this.results[this.problem - 1].texture = this.correct;
                this.baldiAudio.Stop();
                this.ClearAudioQueue();
                int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 3f));
                this.QueueAudio(this.bal_praises[num]);
                this.NewProblem();
            }
            else
            {
                this.problemsWrong++;
                this.results[this.problem - 1].texture = this.incorrect;
                this.baldiAudio.Stop();
                this.ClearAudioQueue();
                if (!this.gc.spoopMode)
                {
                    if(this.problemsWrong >= 4 && this.gc.notebooks == 2){
                        this.QueueAudio(this.bal_allwrong);
                    }
                    else{
                        this.QueueAudio(this.bal_wrong);
                    }
                    //this.baldiFeed.SetTrigger("angry");
                    //this.gc.ActivateSpoopMode();
                }
                else{
                    if (this.gc.mode == "story")
                    {
                        if (this.problem == 4)
                        {
                            this.baldiScript.GetAngry(1f);
                        }
                        else
                        {
                            this.baldiScript.GetTempAngry(0.25f);
                        }
                    }
                    else
                    {
                        this.baldiScript.GetAngry(1f);
                    }
                }
                this.NewProblem();
            }
        }
    }

    // Token: 0x06000987 RID: 2439 RVA: 0x00023D9F File Offset: 0x0002219F
    private void QueueAudio(AudioClip sound)
    {
        this.audioQueue[this.audioInQueue] = sound;
        this.audioInQueue++;
    }

    // Token: 0x06000988 RID: 2440 RVA: 0x00023DBD File Offset: 0x000221BD
    private void PlayQueue()
    {
        this.baldiAudio.PlayOneShot(this.audioQueue[0]);
        this.UnqueueAudio();
    }

    // Token: 0x06000989 RID: 2441 RVA: 0x00023DD8 File Offset: 0x000221D8
    private void UnqueueAudio()
    {
        for (int i = 1; i < this.audioInQueue; i++)
        {
            this.audioQueue[i - 1] = this.audioQueue[i];
        }
        this.audioInQueue--;
    }

    // Token: 0x0600098A RID: 2442 RVA: 0x00023E1C File Offset: 0x0002221C
    private void ClearAudioQueue()
    {
        this.audioInQueue = 0;
    }

    // Token: 0x0600098B RID: 2443 RVA: 0x00023E28 File Offset: 0x00022228
    private void ExitGame()
    {
        if (this.problemsWrong <= 0 & this.gc.mode == "endless")
        {
            this.baldiScript.GetAngry(-1f);
        }
        this.gc.DeactivateLearningGame(base.gameObject);
    }

    // Token: 0x0600098C RID: 2444 RVA: 0x00023E80 File Offset: 0x00022280
    public void ButtonPress(int value)
    {
        if (value >= 0 & value <= 9)
        {
            this.playerAnswer.text = this.playerAnswer.text + value;
        }
        else if (value == -1)
        {
            this.playerAnswer.text = this.playerAnswer.text + "-";
        }
        else
        {
            this.playerAnswer.text = string.Empty;
        }
    }

    // Token: 0x0600098D RID: 2445 RVA: 0x00023F04 File Offset: 0x00022304
    private IEnumerator CheatText(string text)
    {
        for (; ; )
        {
            this.questionText.text = text;
            this.questionText2.text = string.Empty;
            this.questionText3.text = string.Empty;
            this.questionText4.text = string.Empty;
            yield return new WaitForEndOfFrame();
        }
        yield break;
    }

    // Token: 0x04000641 RID: 1601
    public GameControllerScript gc;

    // Token: 0x04000642 RID: 1602
    public BaldiScript baldiScript;

    // Token: 0x04000643 RID: 1603
    public Vector3 playerPosition;

    // Token: 0x04000644 RID: 1604
    public GameObject mathGame;

    // Token: 0x04000645 RID: 1605
    public RawImage[] results = new RawImage[4];

    // Token: 0x04000646 RID: 1606
    public Texture correct;

    // Token: 0x04000647 RID: 1607
    public Texture incorrect;

    // Token: 0x04000648 RID: 1608
    public TMP_InputField playerAnswer;

    // Token: 0x04000649 RID: 1609
    public TMP_Text questionText;

    // Token: 0x0400064A RID: 1610
    public TMP_Text questionText2;

    // Token: 0x0400064B RID: 1611
    public TMP_Text questionText3;

    public TMP_Text questionText4;

    // Token: 0x0400064C RID: 1612
    public Animator baldiFeed;

    // Token: 0x0400064D RID: 1613
    public Transform baldiFeedTransform;

    // Token: 0x04000654 RID: 1620
    public AudioClip bal_intro;

    // Token: 0x04000655 RID: 1621
    public AudioClip bal_screech;

    // Token: 0x04000657 RID: 1623
    public AudioClip[] bal_praises = new AudioClip[4];

    // Token: 0x04000658 RID: 1624
    public AudioClip[] bal_problems = new AudioClip[3];

    public AudioClip bal_wrong;

    public AudioClip bal_allwrong;

    // Token: 0x0400065A RID: 1626
    private float endDelay;

    // Token: 0x0400065B RID: 1627
    private int problem;

    // Token: 0x0400065C RID: 1628
    private int audioInQueue;

    // Token: 0x0400065D RID: 1629
    private float num1;

    // Token: 0x0400065E RID: 1630
    private float num2;

    // Token: 0x0400065F RID: 1631
    private float num3;

    private string thType;

    // Token: 0x04000660 RID: 1632
    private int sign;

    // Token: 0x04000661 RID: 1633
    private string solution;

    // Token: 0x04000662 RID: 1634
    private string[] hintText = new string[]
    {
        "You will get it right next time!",
        "Nice try!"
    };

    // Token: 0x04000663 RID: 1635
    private string[] endlessHintText = new string[]
    {
        "That's more like it...",
        "Keep up the good work or see me after class..."
    };

    // Token: 0x04000664 RID: 1636
    private bool questionInProgress;

    // Token: 0x04000665 RID: 1637
    private bool impossibleMode;

    // Token: 0x04000666 RID: 1638
    private bool joystickEnabled;

    // Token: 0x04000667 RID: 1639
    private int problemsWrong;

    // Token: 0x04000668 RID: 1640
    private AudioClip[] audioQueue = new AudioClip[20];

    // Token: 0x04000669 RID: 1641
    public AudioSource baldiAudio;
 }
