using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public Text Monedas;

    public void GetInventory()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetInventory,error => Debug.LogError(error.GenerateErrorReport()));
    }

    public void OnGetInventory(GetUserInventoryResult result)
    {
        Debug.Log("Received the following items: ");
        foreach (var eachItem in result.Inventory)
            Debug.Log("Items (" + eachItem.DisplayName + "): " + eachItem.ItemInstanceId);
    } 

    public void GetCurrency()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetCurrency,error => Debug.LogError(error.GenerateErrorReport()));
    }

    public void OnGetCurrency(GetUserInventoryResult result)
    {
        string DineroPanel = "Dineros:\n";
        foreach (KeyValuePair<string, int> currency in result.VirtualCurrency)
        {
            DineroPanel += " " + currency.Key + ", Cantidad: " + currency.Value + "\n";
            Debug.Log("total: " + result.VirtualCurrency.Count);
        }
        Monedas.text = DineroPanel;
    }
 
}