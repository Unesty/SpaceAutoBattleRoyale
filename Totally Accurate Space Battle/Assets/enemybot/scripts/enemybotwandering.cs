using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybotwandering : MonoBehaviour
{
    public Rigidbody rb;
    public radartofind rtf;
    public int[] chances;
    public bool thinkingcheck = false;
    public bool findingcheck = false;
    public bool startnewbahviour = true;
    public int thinkingrow;
   
    public float movetox;
    public float movetoy;
    public float movetoz;
    public GameObject moveposindicater;
    Vector3 movepos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rtf.focus == null)
        {

            if (startnewbahviour)
            {

                StopCoroutine(thinking());
                int comparefinding = Random.Range(0, chances[0]);
                int comaparethinking = Random.Range(0, chances[1]);

                if (comparefinding < comaparethinking)
                {
                    thinkingrow = Random.Range(1, 5);
                    thinkingcheck = true;

                     movetox = transform.position.x + Random.Range(10f, 100f);
                     movetoy = transform.position.y + Random.Range(10f, 100f);
                     movetoz = transform.position.z + Random.Range(10f, 100f);
                    startnewbahviour = false;
                }
                else if (comaparethinking < comparefinding)
                {
                   
                    findingcheck = true;
                    startnewbahviour = false;
                }
                else if (comparefinding == comaparethinking)
                {
                    thinkingrow = Random.Range(1, 5);
                    thinkingcheck = true;
                    startnewbahviour = false;

                     movetox = transform.position.x + Random.Range(-100f, 100f);
                     movetoy = transform.position.y + Random.Range(-100f, 100f);
                     movetoz = transform.position.z + Random.Range(-100f, 100f);
                }
            }

            if (thinkingcheck)
            {
                StartCoroutine(thinking());
            }
            else if (findingcheck)
            {
                finding();
            }
           
        }
    }

     IEnumerator thinking()
    {
        if (thinkingrow > 0){ 
            


             movepos = new Vector3(movetox, movetoy, movetoz);
            float movingspeed = 3f;
            float lookspeed = 30f;
            Quaternion lookat = Quaternion.LookRotation(movepos - transform.position);
            transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, lookat, lookspeed * Time.deltaTime);

            transform.position = Vector3.MoveTowards(gameObject.transform.position, movepos, movingspeed * Time.deltaTime);
            moveposindicater.transform.position = movepos;
            
        }

        else if (thinkingrow <= 0)
        {
            startnewbahviour = true;
            
        }

        if (transform.position == movepos)
        {
            movetox = transform.position.x + Random.Range(10f, 1000f);
            movetoy = transform.position.y + Random.Range(10f, 1000f);
            movetoz = transform.position.z + Random.Range(10f, 1000f);
        }


        yield return new WaitForSeconds(0.000001f);
        

    }
    public void finding()
    {


    }
    public void towardresources()
    {

    }

   
}
