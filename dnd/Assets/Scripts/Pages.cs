using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pages : MonoBehaviour
{
    public Text[] itemTexts; // Array of UI Text elements to display items
    public Button prevButton; // Button to navigate to the previous page
    public Button nextButton; // Button to navigate to the next page

    private int currentPageIndex = 0;
    private int itemsPerPage = 6;
    private string[] allItems; // Array of all items to be displayed

    void Start()
    {
        // Example data: Replace with your own item names
        allItems = new string[]
        {
            "Armor", "Food", "Gear", "Lifestyle", "Mount", "Pack",
            "Service", "Tack", "Tool", "Trade", "Trinket", "Waterborne", "Weapon"
        };

        UpdateDisplayedItems();
    }

    void UpdateDisplayedItems()
    {
        int startIndex = currentPageIndex * itemsPerPage;
        int endIndex = Mathf.Min(startIndex + itemsPerPage, allItems.Length);

        for (int i = startIndex; i < endIndex; i++)
        {
            int displayIndex = i % itemsPerPage; // Get index within current page
            itemTexts[displayIndex].text = allItems[i];
        }

        prevButton.interactable = currentPageIndex > 0;
        nextButton.interactable = endIndex < allItems.Length;
    }

    public void OnPrevButtonClick()
    {
        currentPageIndex = Mathf.Max(0, currentPageIndex - 1);
        UpdateDisplayedItems();
    }

    public void OnNextButtonClick()
    {
        currentPageIndex = Mathf.Min(currentPageIndex + 1, (allItems.Length - 1) / itemsPerPage);
        UpdateDisplayedItems();
    }
}
