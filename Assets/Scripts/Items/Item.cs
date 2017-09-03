using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject {

    //Overwrite definition of name for every object
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

	public virtual void Use(){

		//Use item

		Debug.Log ("Using item..." + name);

	}

}
