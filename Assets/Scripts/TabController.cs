using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    public Image[] tabImages; // Array of tab images
    public GameObject[] pages; // Array of tab page GameObjects

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivateTab(0); // Activate the first tab by default
    }

    public void ActivateTab(int tabIndex)
    {
        // Loop through all tabs and pages
        for (int i = 0; i < tabImages.Length; i++)
        {
            // Activate the selected tab and page, deactivate others
            bool isActive = (i == tabIndex);
            tabImages[i].color = isActive ? Color.white : Color.gray; // Change color based on active state
            pages[i].SetActive(isActive);
        }
    }
}
