using System;
using System.IO;

namespace Backpropagation
{
	public class NeuralNet
	{
        private const double LEARNING_RATE_INPUT = 0.2;
        private const double LEARNING_RATE_OUTPUT = 0.15;

        private INeuron [] inputNeurons;		//approximatelty 3072
		private HNeuron [] hiddenNeurons;		// approx 64
		private ONeuron [] outputNeurons;		//approx 10

		private double [] errorComponents;		// approx 10;
		private double [] errorDerivatives;
		private double [] desiredOutputs;

		public NeuralNet()
		{
			inputNeurons = new INeuron[3072];
			hiddenNeurons = new HNeuron[64];
			outputNeurons = new ONeuron[10];

			desiredOutputs = new double[10];
			errorComponents = new double[10];
			errorDerivatives = new double[10];

			createNeurons(inputNeurons.Length, hiddenNeurons.Length, outputNeurons.Length);
		}

		public NeuralNet(int input,int hidden,int output)
		{
			inputNeurons = new INeuron[input];
			hiddenNeurons = new HNeuron[hidden];
			outputNeurons = new ONeuron[output];

			errorComponents = new double[output];
			errorDerivatives = new double[output];
			desiredOutputs = new double[output];

			createNeurons(inputNeurons.Length, hiddenNeurons.Length, outputNeurons.Length);
		}
		public void createNeurons(int input, int hidden, int output)
		{
			// Sets input neurons
			for (int x = 0; x < input; x++)
			{
				inputNeurons[x] = new INeuron(x, hidden);
			}

			// Sets output neurons
			for (int x = 0; x < hidden; x++)
			{
				hiddenNeurons[x] = new HNeuron(x, output);
			}

			// Sets input neurons
			for (int x=0; x < output; x++)
			{
				outputNeurons[x] = new ONeuron(x);
			}

		}

		public double getOuputData(int pos)
		{
			return outputNeurons[pos].getOutputActivation();
		}

		public void setInputs(int pos, double data)
		{
			inputNeurons[pos].setInput(data);
		}

		public void setDesiredOutput(int pos, double data)
		{
			desiredOutputs[pos] = data;
		}

		public double sigmoid(double data)
		{
			if (data >= 20.00)
			{
				data = 32;
			}

			return (double)(1.0 / (1.0 + Math.Exp(-data)));
		}

		public void calculateHiddenActivation()
		{
			// calculate the diferent activations on the 2 neurons
			for (int x = 0; x < hiddenNeurons.Length; x++)
			{
				double summation = 0.0;
				for (int y = 0; y < inputNeurons.Length; y++)
				{
					summation += inputNeurons[y].getInput() * inputNeurons[y].getWeight(x);
				}
				hiddenNeurons[x].setHiddenActivation(sigmoid(summation + hiddenNeurons[x].getBias()));
                //hiddenNeurons[x].setHiddenActivation(sigmoid(summation));
            }
        }

		public void calculateOutputActivation()
		{
			// calculate the differnent activations for the output layers
			for(int x = 0; x < outputNeurons.Length; x++)
			{
				double summation = 0.0;
				for (int y = 0; y < hiddenNeurons.Length; y++)
				{
					summation += hiddenNeurons[y].getHiddenActivation() * hiddenNeurons[y].getWeight(x);
				}
				outputNeurons[x].setOutputActivation(sigmoid(summation + outputNeurons[x].getBias()));
                //outputNeurons[x].setOutputActivation(sigmoid(summation));
            }
        }
		public void calculateErrorComponents()
		{
			// calculate the different EC on the the output layer
			for (int x = 0; x < outputNeurons.Length; x++)
			{
				errorComponents[x] = (desiredOutputs[x]) - (outputNeurons[x].getOutputActivation());
			}
		}
		public void calculateDerivatives()
		{
			// calclulate the different derivatives on the output layer
			for (int x = 0; x < outputNeurons.Length; x++)
			{
				errorDerivatives[x] = outputNeurons[x].getOutputActivation() * (1 - (outputNeurons[x].getOutputActivation())) * errorComponents[x];
			}
		}
		public void learn()
		{
			// trainning session
			run();
			calculateErrorComponents();
			calculateDerivatives();

            // calculates the errors of every neuron in the 2 layer
            for (int x = 0; x < hiddenNeurons.Length; x++)
			{
                hiddenNeurons[x].calculateError(errorDerivatives);
            }

            // change in the weights in the 2 to ouput
            for (int x = 0; x < hiddenNeurons.Length; x++)
			{
                hiddenNeurons[x].setWeights(LEARNING_RATE_INPUT, errorDerivatives);
            }

            // change the weights in the input to 2
            for (int x = 0; x < inputNeurons.Length; x++)
			{
				for (int y = 0; y < hiddenNeurons.Length; y++)
				{
					inputNeurons[x].setWeights(y, hiddenNeurons[y].getError(), LEARNING_RATE_OUTPUT);
				
				}
			}

            // change in output neuron bias
            for (int x = 0; x < outputNeurons.Length; x++)
			{
                outputNeurons[x].changeBias(LEARNING_RATE_INPUT, errorDerivatives);
            }

            // change in 2 neuron bias
            for (int x = 0; x < hiddenNeurons.Length; x++)
			{
                hiddenNeurons[x].changeBias(LEARNING_RATE_OUTPUT);
            }

		}
		public void run()
		{
			calculateHiddenActivation();
			calculateOutputActivation();
			// application phase
		}
		public bool countGood()
		{
			// session terminator
			bool result=true;
			for(int x = 0; x < outputNeurons.Length; x++)
			{
				if((errorComponents[x] - errorDerivatives[x]) != 0)
					result = false;
			}
			return result;
		}
		public void saveWeights(String path)
        {
			// Stores all data
			string dataFile = "data.csv";

			// Stores separated data
			string weightsInputFile = "weights_inputlayer.csv";
			string weightsHiddenFile = "weights_hiddenlayer.csv";
			string biasHiddenFile = "bias_hiddenlayer.csv";
			string biasOutputFile = "bias_outputlayer.csv";

            using (StreamWriter streamWriter = new StreamWriter(path + dataFile)) 
			{
                // saving the weights of the input layer
                for (int x = 0; x < inputNeurons.Length; x++)
				{
					for(int y = 0; y < hiddenNeurons.Length; y++)
					{
                        streamWriter.WriteLine(inputNeurons[x].getWeight(y));
                    }
				}

                //saving the weights of the hidden layer
                for (int x = 0; x < hiddenNeurons.Length; x++)
				{
					for (int y = 0; y < outputNeurons.Length; y++)
					{
						streamWriter.WriteLine(hiddenNeurons[x].getWeight(y));
					}
				}

                // saving hidden layer bias
                for (int x = 0; x < hiddenNeurons.Length; x++)
				{
					streamWriter.WriteLine(hiddenNeurons[x].getBias());
				}

                // saving output layer bias
                for (int x = 0; x < outputNeurons.Length; x++)
				{
					streamWriter.WriteLine(outputNeurons[x].getBias());
				}
			}// end of streamwriter

            #region Separates dataFile into four smaller datas
            {
                using (StreamWriter streamWriter = new StreamWriter(path + weightsInputFile))
                {
                    // saving the weights of the input layer
                    for (int x = 0; x < inputNeurons.Length; x++)
                    {
                        for (int y = 0; y < hiddenNeurons.Length; y++)
                        {
                            streamWriter.WriteLine(inputNeurons[x].getWeight(y));
                        }
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter(path + weightsHiddenFile))
                {
                    //saving the wieghts of the hidden layer
                    for (int x = 0; x < hiddenNeurons.Length; x++)
                    {
                        for (int y = 0; y < outputNeurons.Length; y++)
                        {
                            streamWriter.WriteLine(hiddenNeurons[x].getWeight(y));
                        }
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter(path + biasHiddenFile))
                {
                    // saving hidden layer bias
                    for (int x = 0; x < hiddenNeurons.Length; x++)
                    {
                        streamWriter.WriteLine(hiddenNeurons[x].getBias());
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter(path + biasOutputFile))
                {
                    // saving output layer bias
                    for (int x = 0; x < outputNeurons.Length; x++)
                    {
                        streamWriter.WriteLine(outputNeurons[x].getBias());
                    }
                }
            }
            #endregion
        }

        public void loadWeights(String path)
		{
			using (StreamReader sr = new StreamReader(path)) 
			{
                //loading the weights of the input layer
                for (int x = 0; x < inputNeurons.Length; x++)
				{
					for(int y = 0; y < hiddenNeurons.Length; y++)
					{
						inputNeurons[x].setWeight(y, Convert.ToDouble(sr.ReadLine()));
					}
				}

                //loading the wieghts of the hidden layer
                for (int x = 0; x < hiddenNeurons.Length; x++)
				{
					for (int y = 0; y < outputNeurons.Length; y++)
					{
						hiddenNeurons[x].setWeight(y, Convert.ToDouble(sr.ReadLine()));
					}
				}

                // loading hidden layer bias
                for (int x = 0; x < hiddenNeurons.Length; x++)
				{
					hiddenNeurons[x].setBias(Convert.ToDouble(sr.ReadLine()));
				}

                // loading output layer bias
                for (int x = 0; x < outputNeurons.Length; x++)
				{
					outputNeurons[x].setBias(Convert.ToDouble(sr.ReadLine()));
				}
			}//end of streamreader
		}
	}//end of neural net
}
