using SimulationFramework;
using SimulationFramework.Drawing;
using SimulationFramework.Input;
using System.Numerics;


namespace TestSimulationFramework.Core;

public class Application : Simulation
{
    public static Random random = new();

    public List<Box> boxes = new();

    readonly IFont font = Graphics.LoadFont(Path.Combine("Assets", "Fonts", "Arial.ttf"));

    float rotation = 0;

    public override void OnInitialize()
    {
        Window.Title = "TestSimulationFramework";
        Window.Resize(960, 540);

        for (int i = 0; i < 5000; i++)
        {
            boxes.Add(new Box());
        }
    }

    public override void OnRender(ICanvas canvas)
    {
        for (int i = 0; i < boxes.Count; i++)
        {
            boxes[i].Update();
        }

        canvas.Clear(Color.CornflowerBlue);

        for (int i = 0; i < boxes.Count; i++)
        {
            boxes[i].Draw(canvas);
        }

        canvas.Fill(Color.White);
        canvas.FontSize(64);
        canvas.Font(font);

        canvas.PushState();
        canvas.Translate(Mouse.Position);
        canvas.Rotate(rotation);
        canvas.DrawText("Hello World", Vector2.Zero, Alignment.Center);
        canvas.PopState();

        canvas.FontSize(32);
        canvas.DrawText($"{Performance.Framerate}", Vector2.Zero);


        rotation -= 0.01f;
    }
}