using System;
using System.Collections;
using System.Collections.Generic;

namespace Metaheuristics
{
	public class DiscreteUMDABL2OptBest42SP : DiscreteUMDA
	{
		public TwoSPInstance Instance { get; protected set; }
		
		public DiscreteUMDABL2OptBest42SP(TwoSPInstance instance, int popSize, 
		                                  double truncFactor, int[] lowerBounds, 
		                                  int[] upperBounds)
			: base(popSize, truncFactor, lowerBounds, upperBounds)
		{
			Instance = instance;
			RepairEnabled = true;
			LocalSearchEnabled = true;
		}
		
		protected override void Repair(int[] individual)
		{
			TwoSPUtils.Repair(Instance, individual);
		}
		
		protected override void LocalSearch(int[] individual)
		{		
			TwoSPUtils.BLLocalSearch2OptBest(Instance, individual);
		}
		
		protected override double Fitness(int[] individual)
		{
			return TwoSPUtils.Fitness(Instance, TwoSPUtils.BLCoordinates(Instance, individual));
		}
	}
}
