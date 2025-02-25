using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemButton : MonoBehaviour
{
    public Text buttonText;

    public void OnButtonClick()
    {
        // Get the text of the button when clicked
        string buttonTextValue = buttonText.text;

        // Use a switch statement based on the button text
        switch (buttonTextValue)
        {
            case "Armor": case "Food": case "Gear": case "Tack": case "Tool": case "Trade": case "Weapon":
                PlayerPrefs.SetString("ItemType", buttonText.text);
                SceneManager.LoadScene("itemSearch");

                break;

            case "Mount":
                PlayerPrefs.SetString("ItemType", buttonText.text);
                SceneManager.LoadScene("Mounts");
                break;

            case "Lifestyle": case "Pack": case "Service":
                PlayerPrefs.SetString("ItemType", buttonText.text);
                SceneManager.LoadScene("7Items");
                break;
            case "Trinket":
                PlayerPrefs.SetString("ItemType", buttonText.text);
                SceneManager.LoadScene("Trinkets");
                break;
            case "Waterborne":
                PlayerPrefs.SetString("ItemType", buttonText.text);
                SceneManager.LoadScene("Waterbornes");
                break;
            default:
                Debug.Log("Unknown button clicked!");
                break;
        }
    }
}
