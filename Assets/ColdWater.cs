using MoreMountains.CorgiEngine;
using UnityEngine;

public class ColdWater : DamageOnTouch
{
    [SerializeField] string waterArmorID = "";

    protected override void Awake()
    {
        if (string.IsNullOrWhiteSpace(waterArmorID))
        {
            Debug.LogError("Missing the ID of the water armor!");
        }
        base.Awake();
    }

    protected override void OnCollideWithDamageable(Health health)
    {
        var inventory = health.gameObject.GetComponent<CharacterInventory>();
        if (inventory.MainInventory.GetQuantity(waterArmorID) > 0)
        {
            return;
        }
        else
        {
            base.OnCollideWithDamageable(health);
        }
    }
}
