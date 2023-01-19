using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CanBePickedUp"))
        {
            other.gameObject.SetActive(false);
        }


    }
}
