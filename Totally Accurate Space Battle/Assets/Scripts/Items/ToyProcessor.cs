using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyProcessor : MonoBehaviour
{
    // Processor is used to control connected parts.
    /// Memory
    public byte[] Memory = new byte[256];
    [SerializeField] byte ExeStart = 0;
    [SerializeField] byte ExeEnd = 255;
//     enum Instructions {
//         NOP,
//         MOV,
//         // bool gates
//         OR,
//         NOT,
//         AND,
//         // byte integer math
//         ADD,
//         SUB,
//         MUL,
//         DIV,
//         //
//     }
    // These are output devices.
    // It can be possible to implement output by writing to memory region
    // and connected parts will scan those values.

    // Or by changing values inside connected parts
    // by calling an instruction for that.
//     public List<MonoBehaviour> Connections;


    // Start is called before the first frame update
    void Start()
    {
        if(ExeEnd > Memory.Length)
            ExeEnd = (byte)Memory.Length;
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
        // Tasks examples are:
        //  1)Response to other ships positions and decide to avoid or attack them by setting target
        //  2)Move to a target by rotating rockets using motors and setting power of rockets
        //  3)Avoid obstacles using radar, camera, or mechanical parts
        //  4)Predict target position
        //  5)Rotate guns to aim predicted target position
        //  6)Compensate damage
        //
        // If... There is no "if" because of no branching. But it can be emulated.
        //
        // Floating point values are needed for vector math.
        // In low-level languages conversion from byte to float
        // and back, takes nothing. IDK, can c# do this or not.
        // If it can't, we should add memory of floats.
        for(byte i = ExeStart; i < ExeEnd; ++i) {
            switch(Memory[i]) {
                case 0: // NOP
                    break;
                case 1: // MOV
                    Memory[Memory[i+1]] = Memory[Memory[i+2]];
                    i+=2;
                    break;
                case 2: // OR
                    Memory[Memory[i+1]] = (Memory[Memory[i+1]] != 0 || Memory[Memory[i+2]] != 0) ? (byte)1 : (byte)0;
                    i+=2;
                    break;
                case 3: // NOT
                    Memory[Memory[i+1]] = (Memory[Memory[i+1]] == 0) ? (byte)1 : (byte)0;
                    i++;
                    break;
                case 4: // AND
                    Memory[Memory[i+1]] = (Memory[Memory[i+1]] != 0 && Memory[Memory[i+2]] != 0) ? (byte)1 : (byte)0;
                    i+=2;
                    break;
                case 5: // ADD
                    Memory[Memory[i+1]] += Memory[Memory[i+2]];
                    i+=2;
                    break;
                case 6: // SUB
                    Memory[Memory[i+1]] -= Memory[Memory[i+2]];
                    i+=2;
                    break;
                case 7: // MUL
                    Memory[Memory[i+1]] *= Memory[Memory[i+2]];
                    i+=2;
                    break;
                case 8: // DIV
                    Memory[Memory[i+1]] /= Memory[Memory[i+2]];
                    i+=2;
                    break;

            }
        }
    }

//     void Imov(
}
