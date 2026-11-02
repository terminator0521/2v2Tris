using raygui_cs;
using TwoVTwoTris.Input;
    using System;
using System.IO;
using System.ComponentModel;
using System.Xml;
using System.IO.Pipelines;

namespace TwoVTwoTris.Core.Scenes{
    internal class SettingsScene : Scene
    {
        private float arr;
        private float das;
        private float dcd;
        private float sdf;
        private int j;
        private float[] settings= new float[4];
        IInputManager[] i;
        internal SettingsScene() : base()
        {
            using (StreamReader reader = new StreamReader("data.txt")) {
                string line;
                j = 0;
                while ((line = reader.ReadLine()) != null) {
                    if (float.TryParse(line, out float result))
                    {
                        Console.WriteLine($"Success! Parsed value: {result}");
                        settings[j] = result;
                    }
                    j++;
                    System.Console.WriteLine(line);
                }
                setInputs(settings);
            }
        }

        internal void writeInputs(float arr, float das, float dcd, float sdf){
            using (StreamWriter writer = File.CreateText("data.txt")) {
                writer.WriteLine($"Arr: {arr}");
                writer.WriteLine($"Das: {das}");
                writer.WriteLine($"Dcd: {dcd}");
                writer.WriteLine($"Sdf: {sdf}.");
            }
        }
        internal void setInputs(float[] inputs){
            arr = inputs[0];
            das = inputs[1];
            dcd = inputs[2];
            sdf = inputs[3];
        }


        internal override void Render()
        {

        }

        internal override Scene SetNextScene()
        {
            return null;
        }

        internal override void UI()
        {
            arr = Raygui.GuiSlider(
                new Raylib_cs.Rectangle(100, 100, 300, 30)
                , "ARR"
                , arr + ""
                , arr
                , 0.0f
                , 5.0f
                );
            das = Raygui.GuiSlider(
                new Raylib_cs.Rectangle(100, 200, 300, 30)
                , "DAS"
                , das + ""
                , das
                , 0.0f
                , 20.0f
                );
            dcd = Raygui.GuiSlider(
                new Raylib_cs.Rectangle(100, 300, 300, 30)
                , "DCD"
                , dcd + ""
                , dcd
                , 0.0f
                , 20.0f
                );
            sdf = Raygui.GuiSlider(
                new Raylib_cs.Rectangle(100, 400, 300, 30)
                , "SDF"
                , sdf + ""
                , sdf
                , 5.0f
                , 40.0f
                );
        }

        internal override void Update()
        {
            GetInputs(i);
            writeInputs(arr,das,dcd,sdf);
        }

        internal override void GetInputs(IInputManager[] inputManagers)
        {
            base.GetInputs(inputManagers);
        }
    }
}
