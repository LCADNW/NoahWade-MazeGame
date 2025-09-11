using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Action<ItemSO> EquipItem;
    public Action StopUsingItem;

    [SerializeField] public ItemSO PickedUpItem;

    [Serializable]
    public class EventInRange
    {
        public bool inRange;
        public Action CallbackToLocation;
        public virtual void NotInRange()
        {
            inRange = false;
            CallbackToLocation = null;
        }

        public virtual void InRange(Action _CallbackToLocation)
        {
            inRange = true;
            CallbackToLocation = _CallbackToLocation;
        }
    }

    [Serializable]
    public class EventInRangePickup : EventInRange
    {
        public ItemSO item;
        public override void NotInRange()
        {
            base.NotInRange();
            item = null;
        }

        public virtual void InRange(ItemSO _item, Action _CallbackToLocation)
        {
            base.InRange(_CallbackToLocation);
            item = _item;
            print($"In Range, item {item}");
        }
    }

    [Serializable]
    public class EventInRangeEquipItem : EventInRange
    {
        public bool hasCorrectItem;
        public override void NotInRange()
        {
            base.NotInRange();
            hasCorrectItem = false;
        }

        public virtual void InRange(Action _CallbackToLocation, bool _hasCorrectItem)
        {
            base.InRange(_CallbackToLocation);
            hasCorrectItem = _hasCorrectItem;
        }
    }

    [SerializeField] public EventInRangePickup PickupEvent;
    [SerializeField] public EventInRange UseEvent;



    public void AttemptPickup()
    {

        print($"Attempting Pickup [{PickupEvent.item}]");
        //Guard Clauses
        if (!PickupEvent.inRange) return;

        //This would be so much easier with OnCollisionEnter because i could use the collider other to get my stuff
        PickedUpItem = PickupEvent.item;
        PickupEvent.CallbackToLocation?.Invoke();
        EquipItem?.Invoke(PickedUpItem);
        PickupEvent.NotInRange();

    }

    public void AttemptUse()
    {
        print("Attempting Use");
        if (!UseEvent.inRange) return;

        UseEvent.CallbackToLocation?.Invoke();

        if (PickedUpItem != null)
            if (PickedUpItem.singleUse)
                RemoveItem();

    }

    void DropItem()
    {
        if (PickedUpItem == null) return;

        GameObject droppedPickup
            = Instantiate(
                PickedUpItem.pickupPrefab,
                gameObject.transform.position,
                gameObject.transform.rotation,
                null
            );

        RemoveItem();
    }

    void RemoveItem()
    {
        PickedUpItem = null;
        StopUsingItem?.Invoke();
    }
}
