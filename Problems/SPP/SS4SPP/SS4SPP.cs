using System;

namespace Metaheuristics
{
	public class SS4SPP : IMetaheuristic, ITunableMetaheuristic
	{
		protected int timePenalty = 50;
		public int poolSize = 200;
		public int refSetSize = 10;
		public double explorationFactor = 0.25;
		
		public void Start(string inputFile, string outputFile, int timeLimit)
		{
			SPPInstance instance = new SPPInstance(inputFile);
			DiscreteSS ss = new DiscreteSS4SPP(instance, poolSize, refSetSize, explorationFactor);
			ss.Run(timeLimit - timePenalty);
			SPPSolution solution = new SPPSolution(instance, ss.BestSolution);
			solution.Write(outputFile);
		}

		public string Name {
			get {
				return "SS for SPP";
			}
		}
		
		public MetaheuristicType Type {
			get {
				return MetaheuristicType.SS;
			}
		}
		
		public ProblemType Problem {
			get {
				return ProblemType.SPP;
			}
		}
		
		public string[] Team {
			get {
				return About.Team;
			}
		}
		
		public void UpdateParameters(double[] parameters)
		{
			timePenalty = (int) parameters[0];
			poolSize = (int) parameters[1];
			refSetSize = (int) parameters[2];
			explorationFactor = parameters[3];
		}
	}
}
