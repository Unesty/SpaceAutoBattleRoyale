using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyProcessor : MonoBehaviour
{
    public byte[] memory = new byte[128];
    public FuelEngine rmthis;

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
                    rmthis.on = memory[i+1] == 1;
                    i++;
                    break;
                case 2:
                    if(memory[memory[i+1]] == 0)
                        memory[memory[i+1]] = 1;
                    else
                        memory[memory[i+1]] = 0;
                    i++;
                    break;
            }
        }
    }

//     void Imov(
}
