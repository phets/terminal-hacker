using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    public enum Screen { 
        MainMenu,
        Password,
        Win
    }


    public int level;
    public Screen currentScreen = Screen.MainMenu;
    public string password;

    void ShowMainMenu() {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("-------------------------");
        Terminal.WriteLine("---- TERMINAL HACKER ----");
        Terminal.WriteLine("-------------------------");
        Terminal.WriteLine("");
        Terminal.WriteLine("What would you like to hack?");
        Terminal.WriteLine("");
        Terminal.WriteLine("1. The local library.");
        Terminal.WriteLine("2. The town hall.");
        Terminal.WriteLine("3. The internet provider.");
    }

    void ShowWin() {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Well done. Try a harder level.");
    }

    // Start is called before the first frame update
    void Start() {
        ShowMainMenu();
    }

    // Update is called once per frame
    void Update() {
        
    }
    // OnUserInput is called when the ENTER key is pressed.
    void OnUserInput(string input) {

        print(input);
        input = input.Trim().ToLower();

        if (input == "menu") {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password) { 
            CheckPassword(input);
        }
    }

    void CheckPassword(string input) {
        if (input.Trim().ToLower() == password) { ShowWin(); }
        else {
            Terminal.WriteLine("Wrong password.");
        }
    }

    void RunMainMenu(string input) {

        if (input == "1") {
            level = 1;
            password = "friend";
            StartGame();
        }
        else if (input == "2") {
            level = 2;
            password = "spirit";
            StartGame();
        }
        else if (input == "3") {
            level = 3;
            password = "volante";
            StartGame();
        }
        else {
            Terminal.WriteLine("Please choose a valid level.");
        }
    }

    void StartGame() {

        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine($"You have chosen level {level}.");

        if (level == 1) {
            Terminal.WriteLine("Sometimes I feel like I don't have a partner.");
            Terminal.WriteLine("Sometimes I feel like my only ...");
        }
        else if (level == 2) {
            Terminal.WriteLine("If I die tomorrow I'll be alright because I believe");
            Terminal.WriteLine("that after we're gone the ... carries on.");
        }
        else if (level == 3) {
            Terminal.WriteLine("El Pube è un pilota piazzista ...");
        }
        Terminal.WriteLine("Please enter your password:");
    }
}
