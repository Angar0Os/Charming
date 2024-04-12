using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delai());
    }


    private void Update()
    {
        if (Input.GetButtonDown("BTX") || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // skip credit
            goMenu();
        }
    }

    IEnumerator Delai()
    {
        // wait 16 seondes
        yield return new WaitForSeconds(16f);
        goMenu();
    }

    private void goMenu()
    {
        // return to menu
        SceneManager.LoadScene("MainMenu");
    }
}
