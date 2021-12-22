using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radartofind : MonoBehaviour
{

    public Transform targetplayer;
    public Transform focus;
    public bool playerd;
    public float rotationspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (focus == null && playerd)
        {
            focus = targetplayer;
        }
        else if (!playerd)
        {
            if (targetplayer == focus)
            {
                targetplayer = null;
                focus = null;
            }
            else if (targetplayer != null)
            {
                focus = null;
                playerd = true;
            }
           
        }


        if (focus != null)
        {
            Quaternion rotateto = Quaternion.LookRotation(focus.position - this.gameObject.transform.position);
            this.transform.parent.parent.rotation = Quaternion.RotateTowards(this.gameObject.transform.rotation, rotateto, rotationspeed * Time.deltaTime);
        }
      
       
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerd = true;
            targetplayer = other.gameObject.GetComponent<isplayer>().gameObject.transform.parent;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerd = false;
            
            

        }
    }
}
