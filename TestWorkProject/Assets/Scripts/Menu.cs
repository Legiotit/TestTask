using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject inputName;
    [SerializeField]
    GameObject inputMail;

    [SerializeField]
    GameObject canvasMainMenu;
    [SerializeField]
    GameObject canvasCreateUserMenu;

    [SerializeField]
    LoadLevel LoadLevel;

    [SerializeField]
    Text scoreText;
    [SerializeField]
    MaskableGraphic ErrorImage;

    void Awake()
    {
        if (UserData.CheckLoadUserData())
        {
            EnterMenu();
        } 
        else if (UserData.CheckSaveUserData())
        {
            UserData.LoadUserData();
            EnterMenu();
        }
        else
        {
            OpenCreateUser();
        }
    }

    private void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = UserData.score.ToString();
        }
    }

    public void DeleteUserData()
    {
        UserData.DeleteUserData();
        OpenCreateUser();
    }

    public void SaveNewUser()
    {
        if (SaveNewUserData())
        {
            EnterMenu();
        }
        else
        {
            StartCoroutine(Error());
        }
    }

    private IEnumerator Error()
    {
        ErrorImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        ErrorImage.gameObject.SetActive(false);
    }

    public bool SaveNewUserData()
    {
        if (inputName != null && inputName.GetComponent<InputField>() && inputMail != null && inputMail.GetComponent<InputField>())
        {
            return UserData.SaveUserData(inputName.GetComponent<InputField>().text, inputMail.GetComponent<InputField>().text);
        }
        else return false;
    }

    public void EnterMenu()
    {
        CloseAllMenu();
        canvasMainMenu.SetActive(true);
    }

    public void OpenCreateUser()
    {
        CloseAllMenu();
        canvasCreateUserMenu.SetActive(true);
    }

    public void StartLevel()
    {
        if (LoadLevel != null)
        {
            LoadLevel.LoadScene(1);
        }
    }

    private void CloseAllMenu()
    {
        if (canvasMainMenu != null)
        {
            canvasMainMenu.SetActive(false);
        }
        if (canvasCreateUserMenu != null)
        {
            canvasCreateUserMenu.SetActive(false);
        }
    }

}
