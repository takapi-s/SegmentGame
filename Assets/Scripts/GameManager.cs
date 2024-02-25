using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] GameObject cardPrefab;
    [SerializeField] Transform playerHand;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cardPrefab, playerHand);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
