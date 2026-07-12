using System;

class Program
{
    static void Main(string[] args)
    {
        Simulation jahSimulation = new Simulation(20, 10);

        SimulationObject jahSimulationObject = new Character(10, 10, 10, 10, 10, 10, "wander", 0, 2);
        jahSimulationObject.SetAvatar("X");

        jahSimulation.AddSimulationObject(jahSimulationObject);

        jahSimulation.Resume();
    }
}