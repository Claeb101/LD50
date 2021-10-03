using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class CardPlacer : MonoBehaviour
{
    private Camera _mainCam;
    private CardSelector _selector;
    private Collider2D _validArea;

    private Vineyard _vineyard;
    // Start is called before the first frame update
    void Start()
    {
        _selector = FindObjectOfType<CardSelector>();
        _validArea = GetComponentInChildren<Collider2D>();
        _mainCam = FindObjectOfType<Camera>();
        _vineyard = GetComponent<Vineyard>();
    }

    // Update is called once per frame
    void Update()
    {
        var mouse = Mouse.current;
        if (_selector.selectedCard != null)
        {
            if (mouse.leftButton.wasReleasedThisFrame)
            {
                Vector2 mousePos = _mainCam.ScreenToWorldPoint(mouse.position.ReadValue());
                if(_validArea.bounds.Contains(mousePos))
                {
                    if (_vineyard.seeds >= _selector.selectedCard.cost)
                    {
                        _vineyard.seeds -= _selector.selectedCard.cost;
                        Instantiate(_selector.selectedCard.troop, mousePos, Quaternion.identity, transform);
                        _selector.UnSelect();
                    }
                    else
                    {
                        Debug.Log("Can't buy");
                    }
                }
            }
        }
    }
}
