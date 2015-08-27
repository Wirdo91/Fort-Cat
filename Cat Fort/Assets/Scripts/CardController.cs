using UnityEngine;
using System.Collections;

public class CardController : MonoBehaviour {

    [SerializeField]
    Sprite _backSide;

    Transform[] _uiCards;

    [SerializeField]
    float _rotateSpeed;

    [SerializeField]
    bool _hideP2;

    CardBase[] _currentCards;

    [SerializeField]
    bool _animating = false;
    bool _halfway = false;

    void Start()
    {
        _uiCards = this.transform.GetComponentsInChildren<Transform>();
    }

    void Update()
    {

    }

    public void SwitchCards(Player player)
    {
        _currentCards = player.Hand;
        _animating = true;
    }
}
