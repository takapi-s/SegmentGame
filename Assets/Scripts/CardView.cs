using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] Image iconImage;

    public void Show(CardModel cardModel) // cardModel‚Ìƒf[ƒ^æ“¾‚Æ”½‰f
    {
        iconImage.sprite = cardModel.icon;
    }
}