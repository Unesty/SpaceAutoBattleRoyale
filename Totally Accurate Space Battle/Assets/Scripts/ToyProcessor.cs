using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyProcessor : MonoBehaviour
{
    // Processor is used to control connected parts.
    /// Memory
    public byte[] Memory = new byte[128];
    // These are output devices.
    // It can be possible to implement output by writing to memory region
    // and connected parts will scan those values.
    // Or by changing values inside connected parts
    // by calling an instruction for that.
    public List<MonoBehaviour> Connections;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // There are several types of processors.
        // Zero instruction processors may or not write to input memory.
        // When they can't, they only combinate the inputs.
        //
        // If there is a few instructions, then programmer
        // would have to create internal functions to emulate needed instructions.
        // So we must create an instruction for each specific task.
        //
        // Floating point values are needed for vector math.
        // In low-level languages conversion from byte to float
        // and back, takes nothing. IDK, can c# do this or not.
        // If it can't, we should add memory of floats.
        for(int i = 0; i < Memory.Length; ++i) {
            switch(Memory[i]) {
                case 0:
                    break;
                case 1:

                    i++;
                    break;
                case 2:
                    if(Memory[Memory[i+1]] == 0)
                        Memory[Memory[i+1]] = 1;
                    else
                        Memory[Memory[i+1]] = 0;
                    i++;
                    break;
            }
        }
    }

//     void Imov(
}
