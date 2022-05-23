using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DevConsoleScript : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text outputText;

    // All checks start here
    private bool hasMounted = false;
    private bool hasLoadedGame = false;
    private bool hasLoadedScene = false;

    private string BoolToString(bool boolValue)
    {
        if (boolValue)
        {
            return "Yes";
        }
        else
        {
            return "No";
        }
    }

    private void Start()
    {
        outputText.text = "E3G Engine v0.1.7\nDeveloper Console\n";
        this.inputField.ActivateInputField();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (inputField.text.Length > 0)
            {
                string[] args = inputField.text.ToLower().Split(' ');
                int index = 0;
                index = args.Length - 1;
                if (args[0] == "clear")
                {
                    ClearConsole();
                }
                else if (args[0] == "emount")
                {
                    if(index <= 0){PrintConsoleText("Emount: No arguments specified."); Reactivate(); return;}
                    if(args[1] == "basic")
                    {
                        if(hasMounted){PrintConsoleText("Emount: Already mounted."); Reactivate(); return;}
                        hasMounted = true;
                        PrintConsoleText("Emount: Loaded Basic Functionality.");
                    }
                    else if(args[1] == "game")
                    {
                        if(hasMounted == true)
                        {
                            if(hasLoadedGame){PrintConsoleText("Emount: Already mounted game."); Reactivate(); return;}
                            hasLoadedGame = true;
                            PrintConsoleText("Emount: Mounted 'KATALPHABET'.");
                        }
                        else
                        {
                            PrintConsoleText("Emount: You haven't mounted the basic functionality yet!");
                        }
                    }
                    else if(args[1] != "")
                    {
                        PrintConsoleText("Emount: Unknown command.");
                    }
                    else
                    {
                        PrintConsoleText("Emount: No arguments specified.");
                    }
                }
                else if (args[0] == "lscene")
                {
                    if(index <= 0){PrintConsoleText("Lscene: No arguments specified."); Reactivate(); return;}
                    if(hasMounted && hasLoadedGame)
                    {
                        if(args[1] == "certificated")
                        {
                            if(index <= 1){PrintConsoleText("Lscene: 2nd argument not specified."); Reactivate(); return;}
                            if(args[2] == "1")
                            {
                                if(hasLoadedScene){PrintConsoleText("Lscene: Already loaded scene."); Reactivate(); return;}
                                hasLoadedScene = true;
                                PrintConsoleText("Lscene: Scene 'Certificated' loaded.");
                            }
                            else if(args[2] != "1")
                            {
                                PrintConsoleText("Lscene: Mounting mulitple scenes is not supported yet.");
                            }
                        }
                        else if(args[1] != "")
                        {
                            PrintConsoleText("Lscene: Unknown scene '" + args[1] + "'.");
                        }
                    }
                    else
                    {
                        PrintConsoleText("Basic Mount: " + BoolToString(hasMounted) + "\nGame Mount: " + BoolToString(hasLoadedGame));
                        PrintConsoleText("Lscene: Make sure both of these are mounted properly!");
                    }

                }
                else if(args[0] == "rscene")
                {
                    if(index <= 0){PrintConsoleText("Rscene: No arguments specified."); Reactivate(); return;}
                    if(hasMounted && hasLoadedGame && hasLoadedScene)
                    {
                        if(args[1] == "1")
                        {
                            PrintConsoleText("Rscene: Loading scene...");
                            GenerateRandomText();
                            SceneManager.LoadScene("Certificated");
                        }
                        else
                        {
                            PrintConsoleText("Rscene: Can't play unknown scene.");
                        }
                    }
                    else
                    {
                        PrintConsoleText("Basic Mount: " + BoolToString(hasMounted) + "\nGame Mount: " + BoolToString(hasLoadedGame) + "\nScene Load: " + BoolToString(hasLoadedScene));
                        PrintConsoleText("Rscene: Please make sure all of these say 'Yes'.");
                    }
                }
                else if (args[0] == "help")
                {
                    PrintConsoleText("Read the manual for more information.");
                }
                else if (args[0] == "exit")
                {
                    PrintConsoleText("Exiting to main menu");
                    SceneManager.LoadScene("MainMenu");
                }
                else
                {
                    PrintConsoleText("'" + args[0] + "'" + " is not a valid command");
                }
                Reactivate();
            }
        }
    }

    public void PrintConsoleText(string log)
    {
        outputText.text += log + "\n";
    }

    public void Reactivate()
    {
        this.inputField.text = string.Empty;
        this.inputField.ActivateInputField();
    }

    public void ClearConsole()
    {
        outputText.text = "E3G Engine v0.1.7\nDeveloper Console\n";
    }

    public void GenerateRandomText()
    {
        //Fill the screen with random numbers
        for (int i = 0; i < 9999; i++)
        {
            int randomNumber = Random.Range(0, 9999);
            outputText.text += randomNumber.ToString() + randomNumber.ToString() + randomNumber.ToString() + randomNumber.ToString() + "\n";
        }
    }
}
