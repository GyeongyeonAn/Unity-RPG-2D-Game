using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public HealthBar healthBarPrefab;
    private HealthBar healthBar;

    private void Start()
    {
        hitPoints.value = startingHitPoints;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = other.gameObject.GetComponent<Consumable>().item;
            if (hitObject != null)
            {
                bool shouldDisappear = false;
                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN:
                        shouldDisappear = true;
                        break;
                    case Item.ItemType.HEALTH:
                        shouldDisappear = AdjustHitPoints(hitObject.quantity);
                        break;
                    default:
                        break;
                }
                if (shouldDisappear)
                {
                    other.gameObject.SetActive(false);
                }
            }
        }
    }

    public bool AdjustHitPoints(int amount)
    {
        if (hitPoints.value < maxHitPoints)
        {
            hitPoints.value += amount;
            print("Adjust hit points by: " + amount + ". New value: " + hitPoints.value);
            return true;
        }
        return false;
    }
}
