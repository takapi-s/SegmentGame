using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] CardController cardPrefab;
    [SerializeField] Transform playerHand1, playerHand2, playerHand3, playerHand4;

    List<int> deck = new List<int>(55);
    static System.Random rng = new System.Random(); // —”¶¬Ší‚ğ‰Šú‰»


    void Start()
    {
        //deck make
        for (int i = 1; i < 55; i++)
        {
            deck.Add(i);
        }
        foreach (int card in deck)
        {
            Debug.Log(card);
        }

        StartGame();
    }

    void StartGame()
    {

        //
        DeckShuffle();
        foreach (int card in deck)
        {
            Debug.Log(card);
        }

        SetStartHand();
    }

    void DeckShuffle()
    {
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int value = deck[k];
            deck[k] = deck[n];
            deck[n] = value;
        }
    }

    void CreateCard(int cardID, Transform place)
    {
        CardController card = Instantiate(cardPrefab, place);
        card.Init(cardID);
    }

    void DrawCard(Transform hand)
    {
        if(deck.Count == 0)
        {
            //deck reset
            return;
        }
        int cardID = deck[0];
        deck.RemoveAt(0);
        
    }

    void SetStartHand()
    {
        for(int i = 0; i < 3; i++) 
        {
            DrawCard(playerHand1);
            DrawCard(playerHand2);
            DrawCard(playerHand3);
            DrawCard(playerHand4); 

        }
    }



}