using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Vineyard : MonoBehaviour
{
    public float seeds;
    public float rate;
    public float initRate = 1f;

    public TextMeshProUGUI seedsTxt;
    // Start is called before the first frame update
    void Start()
    {
        rate = initRate;
    }

    // Update is called once per frame
    void Update()
    {
        seeds += rate * Time.deltaTime;
        seedsTxt.text = "" + (int) seeds;
    }
}
