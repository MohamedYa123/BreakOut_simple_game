using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rx = GameObject.Find("right").transform.position.x;
        lx = GameObject.Find("left").transform.position.x;
        xdiff = gameObject.GetComponent<Rigidbody>().position.x - Input.mousePosition.x;
        //Cursor.visible = false;
    }
    float rx;
    float lx;
    float xdiff;
   public  float speed=0.2f;
    bool j = false;
    // Update is called once per frame
    void Update()
    {
        var posi = new Vector3((Input.mousePosition.x + xdiff) * speed, gameObject.GetComponent<Rigidbody>().position.y, gameObject.GetComponent<Rigidbody>().position.z);
        if (posi.x<=lx + gameObject.transform.localScale.x / 2 || posi.x>=rx-gameObject.transform.localScale.x/2)
        {
            //  xdiff = -Input.mousePosition.x + gameObject.GetComponent<Rigidbody>().position.x / speed;
            xdiff = -Input.mousePosition.x + gameObject.GetComponent<Rigidbody>().position.x / speed;
            return;
        }
        gameObject.GetComponent<Rigidbody>().position = posi;
        xdiff = -Input.mousePosition.x + gameObject.GetComponent<Rigidbody>().position.x / speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //j = true;
       // xdiff =- Input.mousePosition.x + gameObject.GetComponent<Rigidbody>().position.x/speed;
    }
    private void OnCollisionExit(Collision collision)
    {
        //j = false;
    }
}
