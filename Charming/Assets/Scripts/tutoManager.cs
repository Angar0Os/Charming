using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoManager : MonoBehaviour
{
    [Header("first dialogue")]
    public List<string> Name1;
    public List<string> Dialogue1;
    public List<Texture> Character1;
    public List<AudioClip> Son1;

    [Header("seonde dialogue")]
    public List<string> Name2;
    public List<string> Dialogue2;
    public List<Texture> Character2;
    public List<AudioClip> Son2;

    [Header("End tutorail")]
    public List<string> Name3;
    public List<string> Dialogue3;
    public List<Texture> Character3;
    public List<AudioClip> Son3;

    [Header("other")]
    public GameObject Garde;
    public GameObject SwordPickUp;

    public List<Transform> Wp;
    public Items Sword;

    public bool TutoFact;

    private GameObject player;

    private bool dialogue1 = true;
    private bool dialogue2 = false;

    private bool GoMove = false;
    private bool endMove = false;

    private bool CanPickUpSword = false;

    private int index;

    public static tutoManager instance;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Update()
    {
        // if i am close to garde
        if (Vector2.Distance(player.transform.position, Garde.transform.position) < 5f)
        {
            // if i press the E
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartTuto();
            }
        }

        // if he can move
        if (GoMove)
        {
            // move the garde in the waipoint
            Garde.transform.position = Vector2.MoveTowards(Garde.transform.position, Wp[index].transform.position, 7f * Time.deltaTime);

            // if he is close to waipoint
            if (Vector2.Distance(Garde.transform.position, Wp[index].transform.position) < 0.01f)
            {
                // if he is to first waipoint
                if (index == 0)
                {
                    // increment index waipoint
                    index++;
                }
                else
                {
                    // stop movement
                    GoMove = false;
                    endMove = true;
                    dialogue2 = true;
                }
            }
        }

        // if the garde don't move
        if (endMove)
        {
            // if i am close to the garde
            if (Vector2.Distance(player.transform.position, Garde.transform.position) < 3.5f)
            {
                // if i press to E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    startDialogue2();
                }
            }
        }

        // if i can pick up sword
        if (CanPickUpSword)
        {
            // if i am close to Sword
            if (Vector2.Distance(player.transform.position, SwordPickUp.transform.position) < 3.5f)
            {
                // see the inforamtion for press E
                KeyPressInfo.instance.SeeInfo("Appuie sur E");

                // if i press the E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // add this sword in my inventory
                    Inventory.instance.Add(Sword);
                    CanPickUpSword = false;
                }
            }
        }

        // if i equip this sword
        if (EquipementManager.instance.Equipements[1] != null)
        {
            // if i am close to Garde
            if (Vector2.Distance(player.transform.position, Garde.transform.position) < 3.5f)
            {
                // if i press E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Dialogue.instance.NewDialogue(Dialogue3, Name3, Character3, Son3);
                }
            }
        }
    }

    public void StartTuto()
    {
        // if the tuto is not facct
        if (!TutoFact)
        {
            // if the first dialogue is not fact
            if (dialogue1)
            {
                // launch the first dialogue
                Dialogue.instance.DialogueEnd = MoveGarde;
                player.GetComponent<AudioSource>().volume = 0;
                Dialogue.instance.NewDialogue(Dialogue1, Name1, Character1, Son1);
                dialogue1 = false;
            }
        }
    }

    public void startDialogue2()
    {
        // if the second dialogue is not fact
        if (dialogue2)
        {
            // launch the second dialogue
            Dialogue.instance.DialogueEnd = CanPickUp;
            player.GetComponent<AudioSource>().volume = 0;
            Dialogue.instance.NewDialogue(Dialogue2, Name2, Character2, Son2);
            dialogue2 = false;
        }
    }

    public void MoveGarde()
    {
        player.GetComponent<AudioSource>().volume = 1;
        GoMove = true;
    }

    public void CanPickUp()
    {
        player.GetComponent<AudioSource>().volume = 1;
        CanPickUpSword = true;
    }
}
