﻿/*
 * Created by SharpDevelop.
 * User: Daniel
 * Date: 22.09.2017
 * Time: 21:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
	/// <summary>
	/// Description of WorkingNeuron.
	/// </summary>
	
	public class WorkingNeuron : Neuron
	{
		
		//TODO bei bene steht hier noch ein float value drin, bei Brotcrunsher nicht??!?? --> hier und bei Bc als lok. variable in getValue() gelöst
		//private float value;
		
		private IActivationFunction activationFunction =new Sigmoid();
		private List<Connection> connections = new List<Connection>();  //Liste der vom WorkingNeuron nach LINKS gehenden Connections
																		//WorkingNeuron ist ZIEL der Verbindung
		
		public IActivationFunction ActFct
		{
			get{return activationFunction;}
		}
																		
		public override float getValue() //hier halte ich mich eher an Brotcrunsher als an Bene, siehe das fehlende float value attribut
		{								 	
			float sum = 0;
			
			foreach(Connection c in connections)
			{
				sum += c.getValue();
			}
			
			//Console.WriteLine("[WORKING NEURON] In die Akt'Fkt eingegeben wird:\n"+sum); //fuer debugging!
			//Console.WriteLine("von ihr ausgegeben wird:\n"+activationFunction.Activation(sum));
			
			return activationFunction.Activation(sum);
		}
		
		public void addConnection(Connection c) //fügt eine übergebene Connection der Liste connections eines WNeurons hinzu.											
		{
			connections.Add(c);
		}
		
		public WorkingNeuron(IActivationFunction ActFct = null) //Standardmäßig wird mit Sigmoid initialsiert
		{
			ActFct = new Sigmoid();
			if (ActFct != null) {
				this.activationFunction = ActFct;
			}			
		}
		
		public float[] getWeightsAsArray()
		{
			float[] res = new float[connections.Count];
			int i = 0;			
			foreach (Connection conn in connections) {
				res[i] = conn.getWeight();
				i++;
			}
			return res;
		}
		
		public float getWeightFromNeuronNumber(int n)
		{
			return this.connections[n].getWeight();
		}
		
	}
}
