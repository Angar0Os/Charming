using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeforeMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // start a black screen effect
        StartCoroutine(Delai());
    }

    private void StartBlackScreen()
    {
        // start the black screen
        BlackScreen.instance.BlackScreens();

        // when the there is a black screen then launch this function
        BlackScreen.instance.IsBlacks = LaunchMenu;
    }

    private void LaunchMenu()
    {
        // load the MainMenu
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator Delai()
    {
        // wati 2.5 seconds
        yield return new WaitForSeconds(2.5f);
        // start the function for start the black screen
        StartBlackScreen();
    }
}
