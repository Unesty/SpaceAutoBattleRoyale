using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyProcessor : MonoBehaviour
{
    public byte[] memory = new byte[128];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for(int i = 0; i < memory.Length; ++i) {
            switch(memory[i]) {
                case 0:
                    break;
                case 1:

                    break;
            }
        }
    }

//     void Imov(
}
