using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionShop : MonoBehaviour
{
    public List<string> Name;
    public List<string> Dialogues;
    public List<Texture> Character;
    public List<AudioClip> AudioClips;
    public List<float> SonPower;

    public List<Items> Items;

    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Time.timeScale == 1f)
        {
            // if you are not in shop
            if (!Shop.instance.InShop)
            {
                // if i press this key
                if (Input.GetKeyDown(KeyCode.E) || Input.GetButton("BTA"))
                {
                    // if you are close to the Pnj shop
                    if (Vector2.Distance(transform.position, Player.transform.position) < 3.5f)
                    {
                        // lunch the dialogue
                        lunchDialogueBeforeShop();
                    }
                }
            }
        }
    }

    void lunchDialogueBeforeShop()
    {
        if (Dialogue.instance.EndDialogue)
        {
            // when the dialogue is finish then lunch the shop
            Dialogue.instance.DialogueEnd = startShop;
            Dialogue.instance.NewDialogue(Dialogues, Name, Character, AudioClips);
        }
    }

    void startShop()
    {
        // display the shop with item
        Shop.instance.NewShop(Items);
    }
}
