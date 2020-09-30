using UnityEngine;

public class Item : Interactable {

    new public string name;
    public int itemID;
    public Sprite icon = null;

    // Interact function that comes with Interactable type
    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    // Pickup item
    void Pickup()
	{
		Debug.Log("Pickup up item");
		Inventory.instance.PickupItem(ItemList.instance.itemGameObjectsList[itemID]);
		Destroy(gameObject);
	}
}
