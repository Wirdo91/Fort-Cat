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
    }

    /// <summary>
    /// Call for players turn
    /// </summary>
    /// <returns>true if turn ended, false if turn still going</returns>
    public bool TurnUpdate()
    {
        return false;
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
