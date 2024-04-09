using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    public Text instructions;
    float instructionStartTime = 5;

   



    void Start () { 
        LaunchInstructions();
       
    }

    void LaunchInstructions()
    {
        instructionStartTime = Time.time;
    }

    void Update()

    {
        string[] biomes = new string[] { "TRIVIA1: ", "TRIVIA2: ", "TRIVIA3: ", "TRIVIA4: ", "TRIVIA5: ", "TRIVIA6: ", 
        "TRIVIA7: ", "TRIVIA8: ", "TRIVIA9: ", "TRIVIA10: ", "TRIVIA11: ", "TRIVIA12: ", "TRIVIA13: ", "TRIVIA14: ", "TRIVIA15: ",
        "TRIVIA16: ","TRIVIA17: ","TRIVIA18: ","TRIVIA19: ","TRIVIA20: ","TRIVIA21: ","TRIVIA22: ","TRIVIA23: ","TRIVIA24: ","TRIVIA25: "};
        System.Random random = new System.Random();
        int useBiome = random.Next(biomes.Length);
        string pickBiome = biomes[useBiome]; 

        if (instructionStartTime > 0 && Time.time >= instructionStartTime)
        {
            if (Time.time - instructionStartTime < 5)
                instructions.text = pickBiome;
            else if (Time.time - instructionStartTime < 10)
                instructions.text = pickBiome;
            else
            {
                instructionStartTime = -1;
                instructions.text = pickBiome;
            }
        }
    }
}
