using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CardSelector : MonoBehaviour
{
    public Card selectedCard;
    // Start is called before the first frame update
    void Start()
    {
        selectedCard = null;
    }
    
    public void Select(Card card)
    {
        if (selectedCard) UnSelect();
        selectedCard = card; card._selected = true;
    }

    public void UnSelect()
    {
        selectedCard._selected = false;
        selectedCard = null;
    }
}
