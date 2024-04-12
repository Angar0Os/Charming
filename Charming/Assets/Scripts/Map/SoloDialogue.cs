using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloDialogue : MonoBehaviour
{

    [Header("First dialogue")]
    public List<string> Name1;
    public List<string> Dialogue1;
    public List<Texture> Character1;
    public List<AudioClip> Son1;

    public GameObject Player;
    public GameObject Quest1;

    public bool DoOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Quest1.GetComponent<Quest1>().enabled)
        {
            if (DoOnce && Player.GetComponent<AnimPlayer>().armor == 0)
            {
                Player.GetComponent<AudioSource>().volume = 0;
                Dialogue.instance.NewDialogue(Dialogue1, Name1, Character1, Son1);
                Dialogue.instance.DialogueEnd = ResetSound;
                this.enabled = false;
            }
        }
        else
        {
            return;
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DoOnce = true;
    }   

    public void ResetSound()
    {
        Player.GetComponent<AudioSource>().volume = 1;
    }
}
