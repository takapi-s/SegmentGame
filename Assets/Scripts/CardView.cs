using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] Image iconImage;

    public void Show(CardModel cardModel) // cardModel�̃f�[�^�擾�Ɣ��f
    {
        iconImage.sprite = cardModel.icon;
    }
}