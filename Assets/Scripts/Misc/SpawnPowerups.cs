using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerups : MonoBehaviour
{

    //varible to store objects
    public GameObject[] powerups;

    // Start is called before the first frame update
    void Start()
    {
        //spawn random object
        Instantiate(powerups[Random.Range(0, powerups.Length)], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
