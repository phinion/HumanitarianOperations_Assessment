using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public int slots = 4;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<GameObject> items = new List<GameObject>();
    public int currentItem = 0;

    void Awake()
    {

        if (instance != null)
        {
            Debug.Log("More than one instance of inventory found!");
            return;
        }

        instance = this;
    }

    void UpdateUI()
    {
        Debug.Log("UPDATING INVENTORY UI");
    }

    // adds item to inventory
    public void PickupItem(GameObject item)
    {
        if (items.Count < slots)
        {

            items.Add(item);

            if (items.Count == 1)
            {
                currentItem = 1;
            }

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }

    }

    // removes item from inventory
    public void Remove(GameObject item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

        if (items.Count == 0)
        {
            currentItem = 0;
        }

    }

    // places item
    public void PlaceItem()
    {
        //
        if (currentItem != 0)
        {
            GameObject mainCamera = GameObject.Find("MainCamera");
            Debug.Log("Dropping Item " + items[currentItem - 1].GetComponent<Item>().name);
            Quaternion rotation = new Quaternion(0, 0, 0, 1);
            Vector3 position = mainCamera.transform.position + mainCamera.transform.forward * items[currentItem - 1].GetComponent<Interactable>().carryDistance;

            GameObject obj = Instantiate(ItemList.instance.itemGameObjectsList[items[currentItem - 1].GetComponent<Item>().itemID], position, rotation);

            Remove(items[currentItem - 1]);
        }
    }
}
