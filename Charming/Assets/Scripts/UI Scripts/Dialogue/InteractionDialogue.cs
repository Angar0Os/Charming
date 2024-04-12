using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDialogue : MonoBehaviour
{
    public List<Texture> Character;
    public List<string>  CharacterName;
    public List<string>  CharacterDialogue;
    public List<AudioClip> AudioClips;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Time.timeScale == 1f)
        {
            // if I'm close enough
            if (Vector2.Distance(transform.position, player.transform.position) < 3.5f)
            {
                // if i press E or BTA and i am not in dialogue
                if ((Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("BTA")) && Dialogue.instance.EndDialogue)
                {
                    // start a function for launch the dialogue
                    LaunchDialogue();
                    //Dialogue.instance.DialogueEnd = ResetVolume;

                }
            }
        } 
    }

    public void LaunchDialogue()
    {
        // start a new dialogue
        player.GetComponent<AudioSource>().volume = 0;
        Dialogue.instance.NewDialogue(CharacterDialogue, CharacterName, Character, AudioClips);

    }

    public void ResetVolume()
    {
        player.GetComponent<AudioSource>().volume = 1;
    }
}
