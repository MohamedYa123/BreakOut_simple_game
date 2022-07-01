using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
        _rb.velocity = new Vector3(0, 0, -30);
        gb = GameObject.Find("me");
    }
    GameObject gb;
    private Rigidbody _rb;
    private Vector3 _velocity;
    Vector3 h;
    // Update is called once per frame
    void Update()
    {
         h = gameObject.GetComponent<Rigidbody>().velocity;
        _velocity = _rb.velocity;
        if (gb.transform.position.z-gb.transform.lossyScale.z > gameObject.transform.position.z)
        {
            Destroy(gameObject);
        }
        //_rb.AddForce(_velocity, ForceMode.VelocityChange);
    }

    [System.Obsolete]
    public void OnCollisionEnter(Collision collision)
    {
        //var h= gameObject.GetComponent<Rigidbody>().velocity;
        
        
        if (collision.gameObject.tag == "breaker" || collision.gameObject.tag == "break" || collision.gameObject.tag == "breakme")
        {
            // print(collision.contacts[0].point);
            if (collision.gameObject.tag == "breaker")
            {
                var p = collision.contacts[0].point;
                var p2 = collision.gameObject.GetComponent<Rigidbody>().position;
                var h = p - p2;
                var center = (p2[0] + collision.gameObject.GetComponent<Transform>().localScale.x / 2f);
                var x = (h[0] -center);
                var xv = 14f * h[0];
                var kk = 20;
                var z = Mathf.Sqrt(Mathf.Pow( 100,2) + kk*kk);
                var zf = Mathf.Sqrt(Mathf.Pow(z, 2) - Mathf.Pow(xv, 2));
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(xv/1.5f, 0,zf/1.5f );
            }
            else
            {
                if (collision.gameObject.tag == "breakme")
                {
                    collision.gameObject.GetComponent<breakscript>().Blood--;
                }
                ReflectProjectile(_rb, collision.contacts[0].normal);
                //    gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-h.x, -h.y, h.z);
            }
        }
    }
   

    private void ReflectProjectile(Rigidbody rb, Vector3 reflectVector)
    {
        _velocity = Vector3.Reflect(_velocity, reflectVector);
        _rb.velocity = _velocity;
    }
}
