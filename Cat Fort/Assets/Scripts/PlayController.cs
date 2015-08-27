using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayController : MonoBehaviour {

    Player _player1;
    Player _player2;

    Player _activePlayer;

    [SerializeField]
    Button[] _cardButtons;

    [SerializeField]
    Fort fort1, fort2;

    bool gameOver = false;

	// Use this for initialization
	void Start () 
    {
        if (fort1 == null || fort2 == null)
        {
            fort1 = GetComponentsInChildren<Fort>()[0];
            fort2 = GetComponentsInChildren<Fort>()[1];
        }

        _player1 = new Player(fort1);
        _player2 = new Player(fort2);

        _activePlayer = _player1;

        _player1.Fort.myWinLose += OnWinLoseCondition;
        _player2.Fort.myWinLose += OnWinLoseCondition;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (gameOver)
            return;

        //If true, turn has changed
        if (_activePlayer.TurnUpdate())
        {
            if (_activePlayer == _player1)
            {
                _activePlayer = _player2;
            }
            else
            {
                _activePlayer = _player1;
            }
        }

        _activePlayer.TurnUpdate();
        _activePlayer.TurnGUI();
	}

    /// <summary>
    /// To be called when a player believes the game is over
    /// </summary>
    /// <param name="fort">The player/Fort which throws the message</param>
    /// <param name="win">Whether ther player won or lost</param>
    private void OnWinLoseCondition(Fort fort, bool win)
    {
        if (_player1.CompareFort(fort))
        {
            if (win)
            {
                Debug.Log("Player 1 Won");
            }
            else
            {
                Debug.Log("Player 1 Lost");
            }
        }
        else
        {
            if (win)
            {
                Debug.Log("Player 2 Won");
            }
            else
            {
                Debug.Log("Player 2 Lost");
            }
        }
    }

    public void OnClicked(Button button)
    {
        if (gameOver)
            return;

        Debug.Log(button.name);
    }
}
