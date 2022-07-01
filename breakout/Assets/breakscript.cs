using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakscript : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        maxblood = 3;
        Blood = 3;
        mygift = new gift();
        mygift.getrandomgift();
    }
    public gift mygift;
    float blood;
    public float maxblood;


    //prefabs
    public GameObject threeballs;

    [System.Obsolete]
    public float Blood
    {
        get { return blood; }
        set { blood = value;if (blood <= 0) { mydestroy(); } setcolor(); }
    }
    void mydestroy()
    {
        mygift.create_gift(gameObject, this);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    void setcolor()
    {
        Material m = new Material(Shader.Find("Standard"));
      //  m.CopyPropertiesFromMaterial(gameObject.GetComponent<Material>());
        var ratio = blood / maxblood;
        ratio = 1 - ratio;
        ratio *= ratio;
        ratio = 1 - ratio;
        m.color = new Color(ratio, 1 - ratio, 1 - ratio);
        gameObject.GetComponent<MeshRenderer>().material = m;
    }
    public enum gifttype {none,threballs };
    public class gift:Object
    {
        string giftname;
        gifttype gif;
        public gift(gifttype gif2=gifttype.none)
        {
            gif = gif2;
            switch (gif)
            {
                case gifttype.threballs:
                    giftname = "Three balls";
                    break;
                default:
                    giftname = "no gift";
                    break;
            }
        }
        public override string ToString()
        {
            return giftname;
        }
        public  void getrandomgift()
        {
            var f = Mathf.Round(Random.Range(0, 2));
            switch (f)
            {
                case 0:
                    gif = gifttype.threballs;
                    break;
                default:
                    gif = gifttype.none;
                    break;
            }
        }
        public void create_gift(GameObject gh,breakscript br)
        {
            switch (gif)
            {
                case gifttype.threballs:
                    GameObject g1 = Instantiate(br.threeballs, gh.transform.position, Quaternion.identity);
                    g1.GetComponent<giftscript>().g = new gift(gif);
                    break;
            }
        }
        public void aply(GameObject g)
        {
            switch (gif)
            {
                case gifttype.threballs:
                    var gs = GameObject.FindGameObjectsWithTag("ball");
                    foreach (var gh in gs)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            GameObject gk = Instantiate(gh, gh.GetComponent<Rigidbody>().position, Quaternion.identity);
                            gk.GetComponent<Rigidbody>().velocity = gh.GetComponent<Rigidbody>().velocity;
                        }
                    }
                    break;
            }
        }
    }
}
