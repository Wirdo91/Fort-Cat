using UnityEngine;
using System.Collections;

public enum GroupType
{
    Humans,
    Cats
}
public enum ResourceType
{
    Money,
    Claws
}

public class Player {

    Fort _fort;
    CardController _cardControllerInstance;
    PlayController _playControllerInstance;

    public Fort Fort
    {
        get { return _fort; }
    }

    CardBase[] _hand;

    public CardBase[] Hand
    {
        get { return _hand; }
    }

    public Player(Fort fort)
    {
        _fort = fort;
        _cardControllerInstance = GameObject.FindObjectOfType<CardController>();
        _playControllerInstance = GameObject.FindObjectOfType<PlayController>();
    }

    /// <summary>
    /// Call for players turn
    /// </summary>
    /// <returns>true if turn ended, false if turn still going</returns>
    public bool TurnUpdate()
    {
        return false;
    }

    public void PlayCard(int index)
    {
        //Animate card to deck
        Hand[index].Affect(this, _playControllerInstance.GetOtherPlayer(this));
        _hand[index] = _cardControllerInstance.GetNewCard();
        Debug.Log(index);
        //Animate deck to card
    }

    /// <summary>
    /// Call to show player gui
    /// </summary>
    public void TurnGUI()
    { 
    
    }

    public bool CompareFort(Fort fort)
    {
        return Fort == fort;
    }
}
