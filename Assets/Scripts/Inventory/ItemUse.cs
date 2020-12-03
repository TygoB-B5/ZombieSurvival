using UnityEngine;

public class ItemUse : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInventory inventory;

    private void Awake()
    {
        inventory = GetComponent<PlayerInventory>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        GetKeyboardUseInput();
    }

    private void GetKeyboardUseInput()
    {
        if (playerInput.Keyboard1)
            Use(inventory.slots[0]);
        else if (playerInput.Keyboard2)
            Use(inventory.slots[1]);
        else if (playerInput.Keyboard3)
            Use(inventory.slots[2]);
        else if (playerInput.Keyboard4)
            Use(inventory.slots[3]);
        else if (playerInput.Keyboard5)
            Use(inventory.slots[4]);
        else if (playerInput.Keyboard6)
            Use(inventory.slots[5]);
        else if (playerInput.Keyboard7)
            Use(inventory.slots[6]);
        else if (playerInput.Keyboard8)
            Use(inventory.slots[7]);
        else if (playerInput.Keyboard9)
            Use(inventory.slots[8]);
    }

    public void Use(Slot useSlot)
    {
        if (!useSlot.hasItem)
            return;

        if (useSlot.item.count <= 0)
            return;

        useSlot.item.count--;

        UseItem(useSlot);

        CheckIfEmpty(useSlot);

    }

    private void UseItem(Slot slot)
    {
        if (slot.item.name == "Medkit")
        {
            GetComponent<PlayerHealth>().health += 6;
        }
    }

    private void CheckIfEmpty(Slot useSlot)
    {
        if (useSlot.item.count == 0)
        {
            useSlot.hasItem = false;
            useSlot.item.name = "";
        }
    }
}
