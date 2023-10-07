using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankPickup : MonoBehaviour
{
    public GameObject
        playerRef;
    public CharacterBrain
        charBrainRef;
    public bool
        entered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            entered = true;
            Destroy(gameObject);
            charBrainRef.health += 10;
            playerRef.GetComponent<Movement>().movementSpeed = 3;
        }
    }
}
