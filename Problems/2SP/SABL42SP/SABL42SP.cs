using System;
using System.Collections;
using System.Collections.Generic;

namespace Metaheuristics
{
	public class SABL42SP : IMetaheuristic
	{
		public void Start(string fileInput, string fileOutput, int timeLimit)
		{
			TwoSPInstance instance = new TwoSPInstance(fileInput);
			DiscreteSA sa = new DiscreteSABL42SP(instance);
			sa.Run(timeLimit);
			int[,] coordinates = TwoSPUtils.BLCoordinates(instance, sa.BestSolution);
			TwoSPSolution solution = new TwoSPSolution(instance, coordinates);
			solution.Write(fileOutput);
		}
		
		public string Name {
			get {
				return "SA using the BL heuristic for 2SP";
			}
		}
		
		public MetaheuristicType Type {
			get {
				return MetaheuristicType.SA;
			}
		}
		
		public ProblemType Problem {
			get {
				return ProblemType.TwoSP;
			}
		}
		
		public string[] Team {
			get {
				return About.Team;
			}
		}
	}
}