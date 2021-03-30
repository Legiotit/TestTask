using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData
{
    public static string name;
    public static string mail;
    public static int score;


    public static void LoadUserData()
    {
        name = PlayerPrefs.GetString("Name");
        mail = PlayerPrefs.GetString("Mail");
        score = PlayerPrefs.GetInt("Player Score");
    }

    public static bool CheckLoadUserData()
    {
        return UserData.name != null && UserData.name != "";
    }

    public static bool CheckSaveUserData()
    {
        return PlayerPrefs.GetString("Name") != null;
    }

    public static void SaveUserDataScore()
    {
        PlayerPrefs.SetInt("Player Score", UserData.score);
    }

    public static bool SaveUserData(string name, string mail)
    {

        if (name != null && name != "" && mail != null && mail != "")
        {
            UserData.name = name;
            UserData.mail = mail;
            PlayerPrefs.SetString("Name", UserData.name);
            PlayerPrefs.SetString("Mail", UserData.mail);
            PlayerPrefs.SetInt("Player Score", 0);
            return true;
        }
        else return false;
    }

    public static void DeleteUserData()
    {
        PlayerPrefs.DeleteAll();
        name = null;
        mail = null;
        score = 0;
    }
}
