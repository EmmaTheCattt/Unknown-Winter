using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        FlareGun, HealthKit, FlareAmmo
    }

    public ItemType itemtype;
    public int amount;


    public Sprite GetSprite()
    {
        switch (itemtype)
        {
            default:
                case ItemType.FlareGun: return ItemAssets.Instance.flareGunSprite;
                case ItemType.HealthKit: return ItemAssets.Instance.healthKitSprite;
                case ItemType.FlareAmmo: return ItemAssets.Instance.flareAmmoSprite;
        }
    }
}
