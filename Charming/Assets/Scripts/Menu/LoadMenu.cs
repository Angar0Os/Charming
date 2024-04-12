using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{

    void Start()
    {
        // start the black screen effect
        StartCoroutine(Delai());
        // launch this function whe  it's the full black screen
        BlackScreen.instance.IsBlacks = LaunchMenu;
    }

    IEnumerator Delai()
    {
        // wait 3 seconds
        yield return new WaitForSeconds(3f);
        // start the black screen
        BlackScreen.instance.BlackScreens();
    }

    private void LaunchMenu()
    {
        // load the menu
        SceneManager.LoadScene("MainMenu");
    }
}
