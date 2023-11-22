using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TrucoActionButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool mouseEntered = false;
    public GameObject button;
    public Color hoverColor;
    public Color nonHoverColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseEntered = true;
        Debug.Log("Mouse enter");
        button.GetComponent<Image>().color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseEntered = false;
        Debug.Log("Mouse exit");
        
        button.GetComponent<Image>().color = nonHoverColor;
    }

    public void OnClick() {
        Debug.Log("OnClick");
    }
}
