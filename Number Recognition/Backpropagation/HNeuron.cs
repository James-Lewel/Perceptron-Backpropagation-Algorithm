using System;

namespace Backpropagation
{
	public class HNeuron
    {
        private static Random rand;

        private int id;
        private double [] weights;	//there will be 10 for the input neurons
		private int weightSize;
		private double hiddenActivation;
		private double bias;
		private double error;

		public HNeuron()
		{
			id = 0;
			weightSize = 10;
			weights = new double[10];
			setRandomWeights(10);

            hiddenActivation = 0.0;
            bias = this.randomWeight();
            error = 0.0;
        }

		public HNeuron(int id, int size)
		{
			this.id = id;
			weightSize = size;
			weights = new double[weightSize];
			setRandomWeights(weightSize);

            hiddenActivation = 0.0;
            bias = 0.01;//this.randomweight();
            error = 0.0;
        }

		public void calculateError(double [] derivatives)
		{
			// calculate the error on the input layer
			double result = 0.0;
			for(int x = 0; x < derivatives.Length; x++)
			{
				result += (derivatives[x] * weights[x]);
			}
			//result*=hactivation;
			//result*=(1-hactivation);
			error = (result * hiddenActivation * (1 - hiddenActivation));
		}

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public double getError()
        {
            return error;
        }

        public void setError(double error)
		{
			this.error = error;
		}

		public void setHiddenActivation(double data)
		{
			hiddenActivation = data;
		}

		public double getHiddenActivation()
		{
			return hiddenActivation;
		}

        public double getBias()
        {
            return bias;
        }

        public void setBias(double bias)
		{
			this.bias= bias;
		}

		public void changeBias(double learningRateInput)
		{
			//change the bias of this neuron
			bias += error * learningRateInput;
		}

        public double getWeight(int outputId)
        {
            return weights[outputId];
        }

        public void setWeight(int pos, double data)
        {
            weights[pos] = data;
        }

        public void setWeights(double learningRateOutput, double[] derivatives)
        {
            // change the weights of connected between input and 2 layer
            double temp = 0.0;
            temp = hiddenActivation * learningRateOutput;

            for (int x = 0; x < derivatives.Length; x++)
            {
                weights[x] += (temp * derivatives[x]);
            }
        }

        public void setRandomWeights(int size)
		{
			for(int x = 0; x < size; x++)
			{
				weights[x] = randomWeight();
			}
		}

		private double randomWeight()
		{
			/*int num;
			DateTime x=DateTime.Now;
			Random rnd=new Random((int)x.Millisecond);
			num=(int)(rnd.Next()%100.00);
			return 2*((float)(num/100.00));
			
			Random y=new Random();
			double x=(double)y.Next(-10,10);
			Console.WriteLine("at hidden {0} = {1}", this.idno,x);
			return x;*/
			if(rand == null)
			{
				rand = new Random();
			}
                
			int MaxLimit = + 1000; 
                
			int MinLimit = - 1000; 

			double number = (double) (rand.Next(MinLimit, MaxLimit)) / 2000;
                
			return number; 
		}
	}//end of class HNeuron
}
