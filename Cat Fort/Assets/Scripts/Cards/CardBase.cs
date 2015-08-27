using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class CardBase {
    Sprite _image;

    ResourceType _costType;
    float _cost;

    string _name;
    string _description;

    public abstract void Affect(Player affecter, Player affectee);

    public void DrawCardImage(Transform transform)
    {
        transform.FindChild("Name").GetComponent<Text>().text = _name;
        transform.FindChild("Description").GetComponent<Text>().text = _description;
        transform.FindChild("Cost").GetComponent<Text>().text = _cost.ToString();
        transform.FindChild("Icon").GetComponent<Image>().sprite = null;
        transform.FindChild("Image").GetComponent<Image>().sprite = _image;
    }
}
