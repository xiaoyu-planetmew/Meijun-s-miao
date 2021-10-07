using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltips : MonoBehaviour
{
    public GameObject detailText;

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowTooltip()
    {
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public void UpdateTooltip(string _detailText)
    {
        detailText.GetComponent<TMP_Text>().text = _detailText;
    }

    //ONCE MOUS HOVER, We can know the ITEM detail information
    public void SetPosition(Vector2 _pos)
    {
        transform.localPosition = new Vector2(0.0f, -69.2f);//MARKER 
    }

}
