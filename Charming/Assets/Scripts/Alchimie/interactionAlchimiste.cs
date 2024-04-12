using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionAlchimiste : MonoBehaviour
{
    public List<Healer> Healers;

    public List<string> Message;
    public List<string> Name;
    public List<Texture> Character;
    public List<AudioClip> Son;
    public List<float> SonPower;

    private void Update()
    {
        // if you are close to the PNJ
        if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 3.5f)
        {
            // if i press E or BTA
            if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("BTA"))
            {
                launchDialogue();
            }
        }
    }

    private void launchDialogue()
    {
        if (Dialogue.instance.EndDialogue)
        {
            // when the dialogue is finish then start the function
            Dialogue.instance.DialogueEnd = startAlchimiste;
            // launch the dialogue
            Dialogue.instance.NewDialogue(Message, Name, Character, Son);
        }
    }

    private void startAlchimiste()
    {
        if (!Alchimy.instance.InAlchimy)
        {
            // open alchimie windos
            Alchimy.instance.OpenAlchimy(Healers);
        }
    }
}
