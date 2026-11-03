using System;
using System.ComponentModel;
using System.Numerics;

namespace TwoVTwoTris.Input;

public static class InputSettings
{
    public static int keyCodeRight = 65;
    public static int keyCodeLeft = 67;
    public static int keyCodeCW = 68;
    public static int keyCodeCCW = 1;
    public static int keyCode180 = 1;
    public static int keyCodeSD = 1;
    public static int keyCodeHD = 1;
    public static int keyCodeHold = 1;

    public static float arr;
    public static float das;
    public static float dcd;
    public static float sdf;
    private static int j;
    private static string[] set;
    public static float[] settings = new float[12];
    public static int hardDrop;
    public static void getInputs()
    {
        using (StreamReader reader = new StreamReader("data.txt")) {
            string line;
            j = 0;
            while ((line = reader.ReadLine()) != null) {
                set = line.Split(' '); 
                if (float.TryParse(set[1], out float result))
                {
                    Console.WriteLine($"Success! Parsed value: {result}");
                    settings[j] = result;
                } 
                j++;
            }
            try{
                setSettings(settings);
            }
            catch (Exception)
            {
                System.Console.WriteLine("COOKED");
            }
        }
    }
        

    public static void writeInputs(float[] set){
        using (StreamWriter writer = File.CreateText("data.txt")) {
            writer.WriteLine($"Arr: {set[0]}");
            writer.WriteLine($"Das: {set[1]}");
            writer.WriteLine($"Dcd: {set[2]}");
            writer.WriteLine($"Sdf: {set[3]}");
            writer.WriteLine($"Right: {set[4]}");
            writer.WriteLine($"Left: {set[5]}");
            writer.WriteLine($"CW: {set[6]}");
            writer.WriteLine($"CCW: {set[7]}");
            writer.WriteLine($"180: {set[8]}");
            writer.WriteLine($"SD: {set[9]}");
            writer.WriteLine($"HD: {set[10]}");
            writer.WriteLine($"Hold: {set[11]}");
        }
    }
    public static void setSettings(float[] inputs){
        arr = inputs[0];
        das = inputs[1];
        dcd = inputs[2];
        sdf = inputs[3];
        keyCodeRight = (int) inputs[4];
        keyCodeLeft = (int) inputs[5];
        keyCodeCW = (int) inputs[6];
        keyCodeCCW = (int)inputs[7];
        keyCode180 = (int) inputs[8];
        keyCodeSD = (int)inputs[9];
        keyCodeHD = (int)inputs[10];
        keyCodeHold = (int)inputs[11];
    }

}
