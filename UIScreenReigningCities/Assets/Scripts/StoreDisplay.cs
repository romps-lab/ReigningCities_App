using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class StoreDisplay : MonoBehaviour
{

    private GameObject UICanvas;
    private GameObject LoadingCanvas;
    private GameObject CategoryView;
    [SerializeField]
    public GameObject categoryContent;
    private GameObject ItemsView;
    [SerializeField]
    public GameObject itemsContent;

    [SerializeField]
    public GameObject categoryButtonPrefab;
    [SerializeField]
    public GameObject itemsButtonPrefab;
    [SerializeField]
    public SpriteAtlas atlas;

    private string currentCategory;


    // Start is called before the first frame update
    void Start()
    {
        UICanvas = GameObject.Find("StoreCanvas");
        LoadingCanvas = GameObject.Find("LoadingCanvas");

        CategoryView = GameObject.Find("Cartegory_View");
        ItemsView = GameObject.Find("Items_View");

        UICanvas.SetActive(true);
        LoadingCanvas.SetActive(false);

        ItemsView.SetActive(false);
        CategoryView.SetActive(true);

        populateCategoriesView();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void populateCategoriesView()
    {
        CategoryView.SetActive(true);
        List<string> categories = RCStore.Instance.getMainCategories();
        foreach (string category in categories)
        {
            GameObject btnObj = Instantiate(categoryButtonPrefab, categoryContent.transform);
            btnObj.GetComponent<Image>().sprite = atlas.GetSprite(category);
            btnObj.name = category;
            Button btn = btnObj.GetComponent<Button>();
            btn.onClick.AddListener(delegate () { showItems(EventSystem.current.currentSelectedGameObject.name); });
            Text txt = btnObj.GetComponentInChildren<Text>();
            txt.text = category;
        }
    }

    public void populateItemsView(List<string> items , List<string> displayNames)
    {
        ItemsView.SetActive(true);
        removePreviousItemsFromView();
        int itr = 0;
        foreach (string item in items)
        {
            GameObject btnObj = Instantiate(itemsButtonPrefab, itemsContent.transform);
            btnObj.GetComponent<Image>().sprite = atlas.GetSprite(item);
            btnObj.name = item;
            Button btn = btnObj.GetComponent<Button>();
            btn.onClick.AddListener(delegate () { showInAR(EventSystem.current.currentSelectedGameObject.name); });
            Text txt = btnObj.GetComponentInChildren<Text>();
            txt.text = displayNames[itr];
            ++itr;
        }
    }

    public void removePreviousItemsFromView()
    {
        for (int itr = 0; itr < itemsContent.transform.childCount; itr++)
        {
            Destroy(itemsContent.transform.GetChild(itr).gameObject);
        }
    }

    public void showInAR(string modelName)
    {
        //Check for double tap
        foreach(Touch touch in Input.touches)
        {
            if (touch.tapCount == 2)
            {
                Debug.Log("Double TAP... : " + modelName);
                ARScreenHelper.Instance.reset();
                ARScreenHelper.Instance.generateDuplicateResource(this.currentCategory, modelName);
                SceneManager.LoadScene("DeployScene");
            }
        }
    }

    public void showItems(string categoryName)
    {
        Debug.Log("Button Clicked :" + categoryName);
        this.currentCategory = categoryName;
        List<string> items = RCStore.Instance.getMainItemsName(categoryName);
        List<string> displayNames = RCStore.Instance.getMainItemsDisplayName(categoryName);
        populateItemsView(items , displayNames);
    }
}
