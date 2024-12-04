using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    private float width;
    private float height;
    private void Start()
    {
        width = Screen.width;
        height = Screen.height;
    }
    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(Input.mousePosition.x/width, Input.mousePosition.y/height, 0);

        StartCoroutine(CameraShake());
        //FUNCTION WHATEVER
    }

    IEnumerator CameraShake()
    {
        int seconds = 0;
        while (seconds < 10)
        {
            print("coroutine");
            seconds++;
            yield return null;
        }

    }
}
