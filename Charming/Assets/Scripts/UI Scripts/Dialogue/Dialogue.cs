using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    private List<string> texte;
    private List<string> name;
    private List<Texture> character;
    private List<AudioClip> audioClips;

    private int index = 0;

    public bool EndDialogue = true;
    public bool EndPrintMessage = true;

    private AudioSource AudioSource;

    public Text TextDialogue;
    public Text Name;

    public GameObject CharacterPicture;
    public GameObject DialogueBox;

    public delegate void EndDialogues();
    public EndDialogues DialogueEnd;

    public static Dialogue instance;
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
        AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // if it is not in dialogue
        if (EndDialogue == false)
        {
            // put the name and image of the person speaking
            Name.text = name[index];
            CharacterPicture.GetComponent<RawImage>().texture = character[index];

            if (Input.GetKeyDown(KeyCode.Space) && !EndPrintMessage)
            {
                EndPrintMessage = true;
            }
            // if the space key is pressed and the dialog has finished being written
            else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("BTA") || Input.GetMouseButtonDown(0)) && EndPrintMessage)
            {
                // if the dialogue is over
                if (index >= texte.Count - 1)
                {
                    // stop the dialog box
                    EndDialogue = true;
                    DialogueBox.SetActive(false);
                    index = 0;
                    if (DialogueEnd != null)
                    {
                        DialogueEnd.Invoke();
                        DialogueEnd = null;
                    }
                    return;
                }

                // writing dialogue
                index++;
                EndPrintMessage = false;

                // start write effect
                StartCoroutine(Type());
            }
        }
    }

    // launch a new dialogue without son power
    public void NewDialogue(List<string> _texte, List<string> _name, List<Texture> _character, List<AudioClip> _audioClips)
    {
        // creation of a new dialogue
        EndPrintMessage = false;
        DialogueBox.SetActive(true);
        EndDialogue = false;
        texte = _texte;
        name = _name;
        character = _character;
        audioClips = _audioClips;

        // play the sound
        playSound();
        // Start write effect
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        // reset the text
        TextDialogue.text = "";

        // play the sound
        playSound();

        // dialogue writing effect
        foreach (var lettre in texte[index].ToCharArray())
        {
            // if endPrintMessage is true
            if (EndPrintMessage)
            {
                // write all dialogue
                TextDialogue.text = texte[index];
            }
            // if endPrintMessage is false
            else
            {
                // add a next letter
                TextDialogue.text += lettre;
                // wait 0.02 seconds
                yield return new WaitForSeconds(0.02f);
            }    
        }
        EndPrintMessage = true;
    }

    private void playSound()
    {
        // if there is a AudioClip in this index 
        if (audioClips[index] != null)
        {
            AudioSource.PlayOneShot(audioClips[index]);
        }
    }
}