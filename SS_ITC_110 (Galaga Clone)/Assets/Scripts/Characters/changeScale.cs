using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScale : MonoBehaviour
{
    public const float
        SCALEDEGREE = 1.1f,
        SCALERATE = 1.001f;
    private const string
        OBJECTNAME = "pacman";


    public GameObject
        target;

    [SerializeField]
    private Vector3
        initialScale,
        dynamicScale;
    [SerializeField]
    private bool
        up = true;
    [SerializeField]
    private float
        looptime;
        

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find(OBJECTNAME);
        initialScale = target.transform.localScale;
        dynamicScale = target.transform.localScale;
        looptime = Mathf.Log(SCALEDEGREE / initialScale.x, SCALERATE); // determines how many times the scaling loop will need to run given the target scale value and the scaling rate
       
       StartCoroutine(scaling());
    }

    // Update is called once per frame
    void Update()
    { 
    }

    IEnumerator scaling()
    {
        while (up)
        {
            for (int i = 0; i<looptime; dynamicScale *= SCALERATE, i++)
            {
                target.transform.localScale = dynamicScale;
                yield return null;
            }
            for (int i = 0; i < looptime; dynamicScale /= SCALERATE, i++)
            {
                target.transform.localScale = dynamicScale;
                yield return null;
            }
        }
    }
}
