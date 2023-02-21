using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    public enum Poweruptype
    {
        Powerup = 0,
        Life = 1,
        Score = 2,
    }

    public Poweruptype currentPickup;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController temp = collision.gameObject.GetComponent<PlayerController>();

            switch (currentPickup)
            {
                case Poweruptype.Powerup:

                    break;
                case Poweruptype.Life:
                    temp.lives++;

                    break;
                case Poweruptype.Score:

                    break;
            }
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
