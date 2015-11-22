using UnityEngine;
using System.Collections;

public class spawnOnClick : MonoBehaviour {
    private Camera cam;
    public GameObject gobj;
	// Use this for initialization
	void Start () {
        cam = Camera.current;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 camPos = cam.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(gobj, camPos, Quaternion.identity);
        }
    }
}
