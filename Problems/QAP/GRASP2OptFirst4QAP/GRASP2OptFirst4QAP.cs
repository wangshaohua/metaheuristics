using System;
using System.Collections;
using System.Collections.Generic;

namespace Metaheuristics
{
	public class GRASP2OptFirst4QAP : IMetaheuristic, ITunableMetaheuristic
	{
		protected double timePenalty = 50;
		protected double rclThreshold = 0.9;
			
		public void Start(string fileInput, string fileOutput, int timeLimit)
		{
			QAPInstance instance = new QAPInstance(fileInput);
			
			// Setting the parameters of the GRASP for this instance of the problem.
			DiscreteGRASP grasp = new DiscreteGRASP2OptFirst4QAP(instance, rclThreshold);
			
			// Solving the problem and writing the best solution found.
			grasp.Run(timeLimit - (int)timePenalty, RunType.TimeLimit);
			QAPSolution solution = new QAPSolution(instance, grasp.BestSolution);
			solution.Write(fileOutput);
		}
		
		public string Name {
			get {
				return "GRASP with 2-opt (first improvement) local search for QAP";
			}
		}
		
		public MetaheuristicType Type {
			get {
				return MetaheuristicType.GRASP;
			}
		}
		
		public ProblemType Problem {
			get {
				return ProblemType.QAP;
			}
		}
		
		public string[] Team {
			get {
				return About.Team;
			}
		}
		
		public void UpdateParameters (double[] parameters) {
			timePenalty = parameters[0];
			rclThreshold = parameters[1];
		}
	}
}
