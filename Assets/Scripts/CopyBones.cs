using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CopyBones : MonoBehaviour {
    
    public GameObject sourceObject;


	// Use this for initialization
	void Start () {
        Copy();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void Copy()
    {
        if(sourceObject == null)
        {
            return;
        }

        var sourceRenderer = sourceObject.GetComponent<SkinnedMeshRenderer>();
        var targetRenderer = GetComponent<SkinnedMeshRenderer>();

        if (sourceRenderer == null || targetRenderer == null)
        {
            return;
        }
        Debug.Log("Copying bones....");
        targetRenderer.bones = sourceRenderer.bones.Where(b => targetRenderer.bones.Any(t => t.name == b.name)).ToArray();


    }
}
