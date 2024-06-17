using SimulationFramework;
using SimulationFramework.Desktop;
using Application = TestSimulationFramework.Scripts.Core.Application;

namespace TestSimulationFramework.Scripts
{
    static class Program
    {
        static void Main()
        {
            Simulation.Start<Application>(new DesktopPlatform());
        }
    }
}
