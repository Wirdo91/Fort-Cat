using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    List<CardBase> _possibleCards;

    [SerializeField]
    bool _animating = false;
    bool _halfway = false;

    void Start()
    {
        _uiCards = new Transform[this.transform.childCount];
        for (int i = 0; i < this.transform.childCount; i++)
        {
            _uiCards[i] = this.transform.GetChild(i);
        }
    }

    void Update()
    {
        if (_animating)
        {
            Rotate2Back();
            if (_halfway)
            {
                Rotate2Front(_currentCards);
            }
        }
    }

    public CardBase GetNewCard()
    {
        return _possibleCards[Random.Range(0, _possibleCards.Count - 1)];
    }

    public void SwitchPlayer(Player player)
    {
        _currentCards = player.Hand;
        _animating = true;
    }

    private void Rotate2Back()
    {
        for (int i = 0; i < _uiCards.Length; i++)
        {
            if (!_halfway && _uiCards[i].eulerAngles.y < 90)
            {
                _uiCards[i].Rotate(0, _rotateSpeed * Time.deltaTime, 0);
                if (_uiCards[i].localEulerAngles.y >= 90)
                {
                    _uiCards[i].localEulerAngles = new Vector3(0, 90, 0);
                }
            }
            else if (!_halfway && (int)_uiCards[i].localEulerAngles.y == 90)
            {
                _uiCards[i].FindChild("ForSide").gameObject.SetActive(false);
                _uiCards[i].FindChild("BackSide").gameObject.SetActive(true);
                _uiCards[i].localEulerAngles = new Vector3(0, 270, 0);
                if (i == _uiCards.Length - 1)
                {
                    _halfway = true;
                }
            }
            else if (_halfway && _uiCards[i].localEulerAngles.y < 360)
            {
                _uiCards[i].Rotate(0, _rotateSpeed * Time.deltaTime, 0);
                if (_uiCards[i].localEulerAngles.y >= 360 || (_uiCards[i].localEulerAngles.y >= 0 && _uiCards[i].localEulerAngles.y < 270))
                {
                    _uiCards[i].localEulerAngles = Vector3.zero;
                }
            }
        }
    }

    private void Rotate2Front(CardBase[] currentCards)
    {
        _halfway = false;
        for (int i = 0; i < _uiCards.Length; i++)
        {
            if (!_halfway && _uiCards[i].eulerAngles.y < 90)
            {
                _uiCards[i].Rotate(0, _rotateSpeed * Time.deltaTime, 0);
                if (_uiCards[i].localEulerAngles.y >= 90)
                {
                    _uiCards[i].localEulerAngles = new Vector3(0, 90, 0);
                }
            }
            else if (!_halfway && (int)_uiCards[i].localEulerAngles.y == 90)
            {
                _uiCards[i].FindChild("ForSide").gameObject.SetActive(true);
                _uiCards[i].FindChild("BackSide").gameObject.SetActive(false);
                _uiCards[i].localEulerAngles = new Vector3(0, 270, 0);
                if (i == _uiCards.Length - 1)
                {
                    for (int n = 0; n < _uiCards.Length; n++)
                    {
                        currentCards[n].DrawCardImage(_uiCards[n]);
                    }
                    _halfway = true;
                }
            }
            else if (_halfway && _uiCards[i].localEulerAngles.y < 360)
            {
                _uiCards[i].Rotate(0, _rotateSpeed * Time.deltaTime, 0);
                if (_uiCards[i].localEulerAngles.y >= 360 || (_uiCards[i].localEulerAngles.y >= 0 && _uiCards[i].localEulerAngles.y < 270))
                {
                    _uiCards[i].localEulerAngles = Vector3.zero;
                }
            }
        }
        _halfway = false;
        _animating = false;
    }
}
