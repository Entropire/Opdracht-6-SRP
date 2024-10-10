using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShipAbility : MonoBehaviour
{
    public static event Action<float> OnMovementSpeedAbility;
    public static event Action<float> OnRotationSpeedAbility;
    public static event Action<float> OnCooldownTimeAbility;

    [SerializeField] private Menu menu;
    [SerializeField] private Image itemImageHolder;
    
    private List<Color> items = new List<Color>();
    private int activeItemIndex = -1;
    
    void Update()
    {
        CycleItems();
        UseItem();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item")) {
            PickUpItem(other.gameObject);
        }
    }
    void PickUpItem(GameObject item) {

        Color color = item.gameObject.GetComponent<Renderer>().material.color;

        Destroy(item);

        items.Add(color);

        activeItemIndex = items.Count - 1;

        itemImageHolder.color = items[activeItemIndex];
        itemImageHolder.enabled = true;
    }
    
    void CycleItems() {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (items.Count > 0)
            {
                if (activeItemIndex < items.Count - 1)
                {
                    activeItemIndex++;
                }
                else
                {
                    activeItemIndex = 0;
                }
                itemImageHolder.color = items[activeItemIndex];
            }
            else
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
        }        
    }
    void UseItem()
    {
        if (Input.GetKeyDown(KeyCode.E) && items.Count > 0 && activeItemIndex != -1) {

            if (items[activeItemIndex] == Color.blue) {
                StartCoroutine(menu.ShowMessage(" +  Move Speed"));
                OnMovementSpeedAbility?.Invoke(5);
            }
            else if (items[activeItemIndex] == Color.red){
                StartCoroutine(menu.ShowMessage(" + Fire Rate"));
                OnCooldownTimeAbility(-0.1f);
            }
            else if(items[activeItemIndex] == Color.green){
                StartCoroutine(menu.ShowMessage(" + Rotation Speed"));
                OnRotationSpeedAbility?.Invoke(10f);
            }      
            items.RemoveAt(activeItemIndex);            
            if (activeItemIndex > 0)
            {
                activeItemIndex--;
                itemImageHolder.color = items[activeItemIndex];
            }
            else if(items.Count == 0)
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
            
        }
    }
}
