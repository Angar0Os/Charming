using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackScreen : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    private bool fadeOut = false;
    private bool isActive = false;

    private float transparence;
    public float Step;

    public delegate void IsBlack();
    public IsBlack IsBlacks;

    public GameObject Screen;

    public static BlackScreen instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Start()
    {
        canvasGroup = Screen.GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        // if the black screen is launch
        if (isActive)
        {
            // if is fade out
            if (fadeOut)
            {
                // time that the alpha is not equal 1
                if (transparence >= 1f)
                {
                    fadeOut = false;
                    if (IsBlacks != null)
                    {
                        IsBlacks.Invoke();
                        IsBlacks = null;
                    }
                }
                else
                {
                    // Fade Out
                    transparence += Step * Time.deltaTime;
                }
            }
            else
            {
                if (transparence <= 0f)
                {
                    isActive = false;
                    Screen.SetActive(false);
                }
                else
                {
                    // fade out
                    transparence -= Step * Time.deltaTime;
                }
            }
        }


        canvasGroup.alpha = transparence;
    }

    public void BlackScreens()
    {
        // setactive black screen
        Screen.SetActive(true);
        fadeOut = true;
        isActive = true;
    }
}
