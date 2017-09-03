using UnityEngine;

public class Interactable : MonoBehaviour {

    //How close the player needs to be to interact with object
    public float radius = 3f;
    bool isFocus = false;
    bool hasInteracted = false;
    Transform player;

    //Variable to make interaction only available in specific direction like chest from the front
    public Transform interactionTransform;

    public virtual void Interact()
    {
        //This is overriden for each object
        Debug.Log("Interacting..." + transform.name);
    }

    private void Start()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
    }

    void Update()
    {
        if (isFocus && hasInteracted == false)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocus(Transform playerTransform)
    {
        hasInteracted = false;
        isFocus = true;
        player = playerTransform;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);


    }
}
