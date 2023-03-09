using System;

namespace Backpropagation
{
	public class INeuron
    {
        private static Random random;

        private int id;
		private double input;
		private double [] weights; // 64 2 neurons to be connected
		private int weightSize;
		private int num;

		public INeuron()
		{
			id = 0;
			input = 0;
			weightSize = 64;
			weights = new double[weightSize];
			setRandomWeights(weightSize);
		}

		public INeuron(int id, int size)
		{
			this.id = id;
			input = 0;
			weightSize = size;
			weights = new double[weightSize];
			setRandomWeights(weightSize);
		}

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public double getInput()
        {
            return input;
        }

        public void setInput(double data)
		{
			input = data;
		}

		public double getWeight(int hiddenId)
		{
			return weights[hiddenId];
		}

		public void setWeight(int pos, double data)
		{
			weights[pos] = data;
		}

        public void setWeights(int hiddenId, double error, double learningRateInput)
        {
            weights[hiddenId] += (error * learningRateInput) * input;
        }

        public void setRandomWeights(int size)
        {
            for (int x = 0; x < size; x++)
            {
                weights[x] = randomWeight();
            }

        }

        private double randomWeight()
        {
            /*DateTime x=DateTime.Now;
			Random rnd=new Random((int)x.Millisecond);
			num+=(int)(rnd.Next()%100.00);
			return 2*((float)(num/100.00));
			
			Random y=new Random();
			double x=(double)y.Next(-10,10);
			Console.WriteLine("at hidden {0} = {1}", this.idno,x);
			return x;*/

            if (random == null)
            {
                random = new Random();
            }

            int MaxLimit = +1000;

            int MinLimit = -1000;

            double number = (double)(random.Next(MinLimit, MaxLimit)) / 2000;

            return number;
        }
    }// end of class INEURON
}
