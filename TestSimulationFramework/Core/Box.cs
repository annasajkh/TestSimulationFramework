using SimulationFramework;
using SimulationFramework.Drawing;
using System.Numerics;

namespace TestSimulationFramework.Core;

public class Box
{
    public Vector2 position;
    public Color color;
    public Vector2 velocity;
    public Vector2 size = new Vector2(25, 25);


    public Box()
    {
        color = new Color(Application.random.NextSingle(), Application.random.NextSingle(), Application.random.NextSingle(), 1);
        position = new Vector2(Application.random.NextSingle() * Window.Width, Application.random.NextSingle() * Window.Height);
        velocity = new Vector2(Application.random.NextSingle() * 2 - 1, Application.random.NextSingle() * 2 - 1).Normalized() * (100 +  Application.random.NextSingle() * 200);
    }

    public void Update()
    {
        position += velocity * Time.DeltaTime;

        if (position.X > Window.Width - size.X)
        {
            position.X = Window.Width - size.X;
            velocity.X = -velocity.X;
        }
        else if (position.X < 0)
        {
            position.X = 0;
            velocity.X = -velocity.X;
        }

        if (position.Y > Window.Height - size.Y)
        {
            position.Y = Window.Height - size.Y;
            velocity.Y = -velocity.Y;
        }
        else if (position.Y < 0)
        {
            position.Y = 0;
            velocity.Y = -velocity.Y;
        }
    }

    public void Draw(ICanvas canvas)
    {
        canvas.PushState();
        canvas.Fill(color);
        canvas.DrawRect(position, size);
        canvas.PopState();
    }
}
