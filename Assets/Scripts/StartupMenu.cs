using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject AuthorsMenu;
    private GameObject[] Menus;

    private void Start()
    {
        Menus = new GameObject[] { MainMenu, OptionsMenu, AuthorsMenu };
        GoToMenu(MainMenu);
    }
    public void OnStartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GoToMenu(GameObject menuObject)
    {
        foreach (var menu in Menus)
        {
            menu.gameObject.SetActive(false);
        }
        menuObject.SetActive(true);
    }
    public void Quit()
    {
        Debug.Log("Quit!!!");
        Application.Quit();

    }
}
