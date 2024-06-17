using SimulationFramework;
using SimulationFramework.Desktop;
using Application = TestSimulationFramework.Core.Application;

namespace TestSimulationFramework
{
    static class Program
    {
        static void Main()
        {
            Simulation.Start<Application>(new DesktopPlatform());
        }
    }
}
