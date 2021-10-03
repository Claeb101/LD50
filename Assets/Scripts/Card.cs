using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public GameObject troop;

    public float cost;

    public TextMeshProUGUI costTxt;
    public Image cardImg;
    public Color unselectedColor;

    private CardSelector _selector;
    
    public bool _selected;
    
    // Start is called before the first frame update
    void Start()
    {
        _selector = GetComponentInParent<CardSelector>();
        _selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        cardImg.color = _selected ? Color.white : unselectedColor;
        costTxt.text = "" + cost;
    }

    public void OnToggle()
    { 
        Debug.Log($"Toggle Card with Troop: {troop.name} | _selected: {_selected}");
        if (!_selected)
        {
            _selector.Select(this);
        }
        else
        {
            _selector.UnSelect();
        }
    }
}
