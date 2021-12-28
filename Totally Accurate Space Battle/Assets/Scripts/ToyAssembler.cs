using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyAssembler : MonoBehaviour
{
    // Maybe just don't use assembler and save raw bytes somewhere
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ParseNames()
    {
        for (int c = 0; c < transform.childCount; ++c)
        {
            Transform child = transform.GetChild(c);
            if(child.name.Contains("NOP")) {
//                 CPU.Memory[i] = 0;
            }
        }
    }
}
