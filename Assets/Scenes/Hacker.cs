using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    string[] level1passwords = {"book","shelf","write","publish","autor","borrow"};    
    string[] level2passwords = {"gun","bullet","rifle","sniper","violence","pistol","prison","arrest","handcuff"};
    string[] level3passwords = {"earth","solarsystem","jupiter","mars","comet","bigbang","planet","pluto","moon","venus","neptune"};

    int level;
    enum Screen {MainMenu, Password, Win};
    Screen currentScreen;
    string password;

    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu ()
    {
        Screen currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("You Can Type (menu) To back To Menu AnyTime");
        Terminal.WriteLine("");
        Terminal.WriteLine("");
        Terminal.WriteLine("Where To Hack ?");
        Terminal.WriteLine("1 : Library");
        Terminal.WriteLine("2 : Police Station");
        Terminal.WriteLine("3 : NASA");
        Terminal.WriteLine("Select :");
    }

    void OnUserInput(string input)
    {
        if(input == "menu"){
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }
    void RunMainMenu (string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
            
        else 
        {
            Terminal.WriteLine("Not Valid");
        }
    }

    void AskForPassword(){
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = level1passwords[Random.Range(0, level1passwords.Length)];
                break;
            case 2:
                password = level2passwords[Random.Range(0, level2passwords.Length)];
                break;
            case 3:
                password = level3passwords[Random.Range(0, level3passwords.Length)];
                break;
            default:
                Debug.LogError("Not Valid");
                break;
        }
        Terminal.WriteLine("Password:  ,   $ Hint: " + password.Anagram());
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Book...!");
                Terminal.WriteLine(@"
     _.--._  _.--._
,-=.-':;:;:;\':;:;:;'-._
\\\:;:;:;:;:;\:;:;:;:;:;\
 \\\:;:;:;:;:;\:;:;:;:;:;\
  \\\:;:;:;:;:;\:;:;:;:;:;\
   \\\:;:;:;:;:;\:;::;:;:;:\
    \\\;:;::;:;:;\:;:;:;::;:\
     \\\;;:;:_:--:\:_:--:_;:;\
      \\\_.-''      :      '-.\
       \`_..--''--.;.--''--.._\\");
                break;
            case 2:
                Terminal.WriteLine("Prison Key...!");
                Terminal.WriteLine(@"
               .--.
              /.-. '----------.
              \'-' .--'--''-'-'
               '--'");
                break;
            case 3:
                Terminal.WriteLine("WellCome To NASA!");
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___/\__,_|");
                break;
            default:
                Debug.LogError("Not Valid");
                break;
        }
    }
}
