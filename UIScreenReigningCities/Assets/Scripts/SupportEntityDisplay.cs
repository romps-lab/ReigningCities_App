using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SupportEntityDisplay : MonoBehaviour
{
    private GameObject SupportEntityView;
    [SerializeField]
    public GameObject supportEntityContent;
    [SerializeField]
    public GameObject supportButtonPrefab;

    private GameObject supportOptions;
    private Button supportButton;
    private SpriteAtlas atlas;


    // Start is called before the first frame update
    void Start()
    {
        atlas = Resources.Load<SpriteAtlas>("storeAtlas");
        SupportEntityView = GameObject.Find("SupportEntityView");
        supportOptions = GameObject.Find("SupportButtonOptions");
        supportButton = supportOptions.GetComponent<Button>();
        supportButton.onClick.AddListener(delegate () { showSupportEntitiesView(); });
        populateSupportView();
        SupportEntityView.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void showSupportEntitiesView()
    {
        if (SupportEntityView.activeSelf)
        {
            SupportEntityView.SetActive(false);
            supportButton.GetComponent<Image>().sprite = atlas.GetSprite("build");
        }
        else
        {
            SupportEntityView.SetActive(true);
            supportButton.GetComponent<Image>().sprite = atlas.GetSprite("red-WhiteText");
        }
    }

    private void populateSupportView()
    {
        SupportEntityView.SetActive(true);
        List<string> items = RCStore.Instance.getSupportEntitiesItems();
        List<string> displayNames = RCStore.Instance.getSupportEntitiesItemsDisplayName();
        int itr = 0;
        foreach (string item in items)
        {
            GameObject btnObj = Instantiate(supportButtonPrefab, supportEntityContent.transform);
            btnObj.GetComponent<Image>().sprite = atlas.GetSprite(item);
            btnObj.name = item;
            Button btn = btnObj.GetComponent<Button>();
            btn.onClick.AddListener(delegate () { currentEntitySelected(EventSystem.current.currentSelectedGameObject.name); });
            Text txt = btnObj.GetComponentInChildren<Text>();
            txt.text = displayNames[itr];
            ++itr;
            ARScreenHelper.Instance.currentSupportEntity = item;
        }
    }

    public void currentEntitySelected(string name)
    {
        ARScreenHelper.Instance.currentSupportEntity = name;
    }
}
