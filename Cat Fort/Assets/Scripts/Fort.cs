using UnityEngine;
using System.Collections;

public class Fort : MonoBehaviour{

    [SerializeField]
    Transform _wallObject, _fortObject;

    float _fortIntegrity = 0;
    float _wallIntegrity = 0;

    float wallMaxIntegrity = 100;
    float fortMaxIntegrity = 100;
    float wallMaxHeight = 5;
    float fortMaxHeight = 5;

    public delegate void OnWinLose(Fort fort, bool win);
    public OnWinLose myWinLose;

    /// <summary>
    /// Used to change integrity value.
    /// Changes height as well
    /// </summary>
    private float fortIntegrity
    {
        set { _fortIntegrity = Mathf.Clamp(value, 0, fortMaxIntegrity);
        if (_fortObject != null)
            _fortObject.localPosition = new Vector3(_fortObject.localPosition.x, Mathf.Clamp(_fortIntegrity * (fortMaxHeight / fortMaxIntegrity), 0, fortMaxHeight), _fortObject.localPosition.z);
        if (_fortIntegrity == 100)
            myWinLose(this, true);
        else if (_fortIntegrity == 0)
            myWinLose(this, false);
        }
        get { return _fortIntegrity; }
    }
    /// <summary>
    /// Used to change integrity value.
    /// Changes height as well
    /// </summary>
    private float wallIntegrity
    {
        set { _wallIntegrity = Mathf.Clamp(value, 0, wallMaxIntegrity);
        if (_wallObject != null) 
            _wallObject.localPosition = new Vector3(_wallObject.localPosition.x, Mathf.Clamp(_wallIntegrity * (wallMaxHeight / wallMaxIntegrity), 0, wallMaxHeight), _wallObject.localPosition.z);
        }
        get { return _wallIntegrity; }
    }

    void Start()
    {
        if (_fortObject == null || _wallObject == null)
        {
            _fortObject = transform.FindChild("Fort");
            _wallObject = transform.FindChild("Wall");
        }


        fortIntegrity = 30;
        wallIntegrity = 10;
	}

    public void Damage(int amount)
    {
        //Calculate possible damage to fort
        float rest = amount - wallIntegrity;

        //Damage wall
        wallIntegrity -= amount;

        if (rest > 0)
        {
            fortIntegrity -= fortIntegrity;
        }
    }

    public void AffectWall(int amount)
    {
        wallIntegrity += amount;
    }
    public void AffectFort(int amount)
    {
        fortIntegrity += amount;
    }

    void OnGUI()
    {
        //Debugging gui
        float xStart = ((this.transform.position.x + 2) / 4) * (Screen.width / 2);

        if (GUI.Button(new Rect(xStart, 50, 75, 25), "+ " + this.name + " fort"))
        {
            AffectFort(5);
        }
        if (GUI.Button(new Rect(xStart, 75, 75, 25), "- " + this.name + " fort"))
        {
            AffectFort(-5);
        }
        if (GUI.Button(new Rect(xStart + 75, 50, 75, 25), "+ " + this.name + " wall"))
        {
            AffectWall(5);
        }
        if (GUI.Button(new Rect(xStart + 75, 75, 75, 25), "- " + this.name + " wall"))
        {
            AffectWall(-5);
        }
    }
}
