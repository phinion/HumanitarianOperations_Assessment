using UnityEngine;

public class Item : Interactable {

    new public string name;
    public int itemID;
    public Sprite icon = null;
    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    void Pickup()
	{
		Debug.Log("Pickup up item");
		Inventory.instance.PickupItem(ItemList.instance.itemGameObjectsList[itemID]);
		Destroy(gameObject);
	}
}
