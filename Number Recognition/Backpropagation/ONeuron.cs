using System;

namespace Backpropagation
{
	public class ONeuron
    {
        private static Random rand;

        private int id;
        private double bias;
		private double outputActivation;

		public ONeuron()
        {
            id = 0;
            bias = randomBias();
			outputActivation = 0.0;
		}

		public ONeuron(int id)
        {
            this.id = id;
            bias = 0.01; //this.randomBias();
			outputActivation = 0.0;
        }
        public int getId()
        {
            return id;
        }

        public void setId(int id)
		{
			this.id = id;
		}
        public double getOutputActivation()
        {
            return outputActivation;
        }

        public void setOutputActivation(double data)
		{
			outputActivation = data;
		}

		public double getBias()
		{
			return bias;
		}

		public void setBias(double bias)
		{
			this.bias= bias;
		}

		public void changeBias(double learningRateOutput, double [] derivatives)
		{
			bias += learningRateOutput * derivatives[id];
		}
		
		private double randomBias()
		{
		/*	int num;
			
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
	}//end of class ONeuron

}
