using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = other.gameObject.GetComponent<Consumable>().item;
            if (hitObject != null)
            {
                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN:
                        break;
                    case Item.ItemType.HEALTH:
                        AdjustHitPoints(hitObject.quantity);
                        break;
                    default:
                        break;
                }
                other.gameObject.SetActive(false);
            }
        }
    }

    public void AdjustHitPoints(int amount)
    {
        hitPoints += amount;
        print("Adjust hit points by: " + amount + ". New value: " + hitPoints);
    }
}
