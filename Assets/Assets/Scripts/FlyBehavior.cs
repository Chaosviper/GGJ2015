using UnityEngine;
using System.Collections;

public class FlyBehavior : MonoBehaviour
{
    Transform myTransform;
    //Più è grande tremorvalue, più trema
    public float tremorValue = 5;
    //Range indica quanto ci si può spostare dal centro
    public float range = 3;
    private Vector3 initialPos;

    // Use this for initialization
    void Start()
    {
        initialPos = this.transform.position;
        myTransform = this.transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tremorPos = new Vector3(Random.Range(-1, 2) * tremorValue * Time.deltaTime, Random.Range(-1, 2) * tremorValue * Time.deltaTime, 0);
        if ((initialPos.x + range > myTransform.position.x + tremorPos.x && myTransform.position.x + tremorPos.x > initialPos.x - range) && (initialPos.y + range > myTransform.position.y + tremorPos.y && myTransform.position.y + tremorPos.y > initialPos.y - range))
            myTransform.position += tremorPos;
    }
}
