using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giftscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        switch (gameObject.name)
        {
            case "three":
                mytype = breakscript.gifttype.threballs;
                g = new breakscript.gift(gif2:mytype);
                break;
        }
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -20);
    }
    public breakscript.gifttype mytype;
    public breakscript.gift g;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "me")
        {
            g.aply(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
