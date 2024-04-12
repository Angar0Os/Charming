using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementDetection : MonoBehaviour
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Princess1>().gameObject;
        this.transform.position = Player.transform.position;
    }
}
