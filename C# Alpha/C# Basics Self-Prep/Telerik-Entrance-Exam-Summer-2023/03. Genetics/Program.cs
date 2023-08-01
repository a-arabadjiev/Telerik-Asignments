namespace _03._Genetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parrent1 = Console.ReadLine();
            string parent2 = Console.ReadLine();

            int flipBit = int.Parse(Console.ReadLine());

            string child1 = parrent1.Substring(0, flipBit) + parent2.Substring(flipBit);
            string child2 = parent2.Substring(0, flipBit) + parrent1.Substring(flipBit);

            int sumChild1 = 0;
            int sumChild2 = 0;

            for (int i = 0; i < child1.Length; i++)
            {
                sumChild1 += int.Parse(child1[i].ToString());
                sumChild2 += int.Parse(child2[i].ToString());
            }

            decimal child1Ratio = sumChild1 * 100 / child1.Length;
            decimal child2Ratio = sumChild2 * 100 / child2.Length;

            string winnerChild;
            decimal winnerChildRatio;

            if (sumChild1 >  sumChild2)
            {
                winnerChild = child1;
                winnerChildRatio = child1Ratio;
            }
            else if (sumChild2 > sumChild1) 
            {
                winnerChild = child2;
                winnerChildRatio = child2Ratio;
            }
            else
            {
                winnerChild = child1;
                winnerChildRatio = child1Ratio;
            }

            if (winnerChildRatio >= 50)
            {
                Console.WriteLine(winnerChild);
            }
            else 
            {
                winnerChild = winnerChild.Replace('0', '2');
                winnerChild = winnerChild.Replace('1', '0');
                winnerChild = winnerChild.Replace('2', '1');

                Console.WriteLine(winnerChild);
            }
        }
    }
}