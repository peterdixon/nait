﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Work out the first ten digits of the following sum of one hundred 50 digit numbers.
namespace Euler13
{
    class Program
    {
        static void Main(string[] args)
        {

            //The plan is
            //check the number is correct by taking the index of the last item in that list.

            //Console.WriteLine("the number of digits in number is {0}", number.Length); // Expected answer: 5000.

            //We want to implement an array of 5000 integers.
            //the first 50 digits have index 0-49, the second 50 digits have 50-99, so forth.
            //we will have a 100x50 array whose elements are the ordered pairs(a,b)
            //a: 0-99
            //b: 0-49
            //To map onto a:
            //
            // a = characterIndex / 50 ex) 49/50 -> 0, 1000/50 -> 20.
            // b = characterIndex % 50 ex) 49%50 = 49, 1000%50 = 0.


            string number = Number();
            int[,] numberArray = GetNumberArray(number);

            //Now we want to figure out the sums involved.
            //We can figure out the maximum number of digits our answer will have
            //If each of them were 999..99 (50 9's), then their sum would be 100*999..99 = 999..9900.
            //Hence their sum is at most 52 digits.

            int[] sumList = new int[52];
            sumList = PopulateSumList(sumList);
            /*
             * sumList[49] = getColumnSum(49, numberArray, sumList);
             * Console.WriteLine(sumList[49]);
            */

            //We calculate each digit as follows.
            //Let a_ij be the entry corresponding to the ith 50 digit number's jth digit.
            // 0 <= i <= 99, 0<= j <= 49.
            //Suppose we are calculating the n'th digit of sum
            //nth digit = hundreds place of n-2th sum + tens place of n-1th sum + ones place of nth sum.
            int n;
            for (int index = 0; index<50; index++)
            {
                n = 49 - index;
                sumList[n] = getColumnSum(n, numberArray, sumList);
                Console.WriteLine("the {0}th column has sum {1}.", n, sumList[n]);
            }

            getAnswer(sumList);
            Console.ReadKey();

        }

        static string Number()
        {
            string number = "37107287533902102798797998220837590246510135740250" +
  "46376937677490009712648124896970078050417018260538" +
  "74324986199524741059474233309513058123726617309629" +
  "91942213363574161572522430563301811072406154908250" +
  "23067588207539346171171980310421047513778063246676" +
  "89261670696623633820136378418383684178734361726757" +
  "28112879812849979408065481931592621691275889832738" +
  "44274228917432520321923589422876796487670272189318" +
  "47451445736001306439091167216856844588711603153276" +
  "70386486105843025439939619828917593665686757934951" +
  "62176457141856560629502157223196586755079324193331" +
  "64906352462741904929101432445813822663347944758178" +
  "92575867718337217661963751590579239728245598838407" +
  "58203565325359399008402633568948830189458628227828" +
  "80181199384826282014278194139940567587151170094390" +
  "35398664372827112653829987240784473053190104293586" +
  "86515506006295864861532075273371959191420517255829" +
  "71693888707715466499115593487603532921714970056938" +
  "54370070576826684624621495650076471787294438377604" +
  "53282654108756828443191190634694037855217779295145" +
  "36123272525000296071075082563815656710885258350721" +
  "45876576172410976447339110607218265236877223636045" +
  "17423706905851860660448207621209813287860733969412" +
  "81142660418086830619328460811191061556940512689692" +
  "51934325451728388641918047049293215058642563049483" +
  "62467221648435076201727918039944693004732956340691" +
  "15732444386908125794514089057706229429197107928209" +
  "55037687525678773091862540744969844508330393682126" +
  "18336384825330154686196124348767681297534375946515" +
  "80386287592878490201521685554828717201219257766954" +
  "78182833757993103614740356856449095527097864797581" +
  "16726320100436897842553539920931837441497806860984" +
  "48403098129077791799088218795327364475675590848030" +
  "87086987551392711854517078544161852424320693150332" +
  "59959406895756536782107074926966537676326235447210" +
  "69793950679652694742597709739166693763042633987085" +
  "41052684708299085211399427365734116182760315001271" +
  "65378607361501080857009149939512557028198746004375" +
  "35829035317434717326932123578154982629742552737307" +
  "94953759765105305946966067683156574377167401875275" +
  "88902802571733229619176668713819931811048770190271" +
  "25267680276078003013678680992525463401061632866526" +
  "36270218540497705585629946580636237993140746255962" +
  "24074486908231174977792365466257246923322810917141" +
  "91430288197103288597806669760892938638285025333403" +
  "34413065578016127815921815005561868836468420090470" +
  "23053081172816430487623791969842487255036638784583" +
  "11487696932154902810424020138335124462181441773470" +
  "63783299490636259666498587618221225225512486764533" +
  "67720186971698544312419572409913959008952310058822" +
  "95548255300263520781532296796249481641953868218774" +
  "76085327132285723110424803456124867697064507995236" +
  "37774242535411291684276865538926205024910326572967" +
  "23701913275725675285653248258265463092207058596522" +
  "29798860272258331913126375147341994889534765745501" +
  "18495701454879288984856827726077713721403798879715" +
  "38298203783031473527721580348144513491373226651381" +
  "34829543829199918180278916522431027392251122869539" +
  "40957953066405232632538044100059654939159879593635" +
  "29746152185502371307642255121183693803580388584903" +
  "41698116222072977186158236678424689157993532961922" +
  "62467957194401269043877107275048102390895523597457" +
  "23189706772547915061505504953922979530901129967519" +
  "86188088225875314529584099251203829009407770775672" +
  "11306739708304724483816533873502340845647058077308" +
  "82959174767140363198008187129011875491310547126581" +
  "97623331044818386269515456334926366572897563400500" +
  "42846280183517070527831839425882145521227251250327" +
  "55121603546981200581762165212827652751691296897789" +
  "32238195734329339946437501907836945765883352399886" +
  "75506164965184775180738168837861091527357929701337" +
  "62177842752192623401942399639168044983993173312731" +
  "32924185707147349566916674687634660915035914677504" +
  "99518671430235219628894890102423325116913619626622" +
  "73267460800591547471830798392868535206946944540724" +
  "76841822524674417161514036427982273348055556214818" +
  "97142617910342598647204516893989422179826088076852" +
  "87783646182799346313767754307809363333018982642090" +
  "10848802521674670883215120185883543223812876952786" +
  "71329612474782464538636993009049310363619763878039" +
  "62184073572399794223406235393808339651327408011116" +
  "66627891981488087797941876876144230030984490851411" +
  "60661826293682836764744779239180335110989069790714" +
  "85786944089552990653640447425576083659976645795096" +
  "66024396409905389607120198219976047599490197230297" +
  "64913982680032973156037120041377903785566085089252" +
  "16730939319872750275468906903707539413042652315011" +
  "94809377245048795150954100921645863754710598436791" +
  "78639167021187492431995700641917969777599028300699" +
  "15368713711936614952811305876380278410754449733078" +
  "40789923115535562561142322423255033685442488917353" +
  "44889911501440648020369068063960672322193204149535" +
  "41503128880339536053299340368006977710650566631954" +
  "81234880673210146739058568557934581403627822703280" +
  "82616570773948327592232845941706525094512325230608" +
  "22918802058777319719839450180888072429661980811197" +
  "77158542502016545090413245809786882778948721859617" +
  "72107838435069186155435662884062257473692284509516" +
  "20849603980134001723930671666823555245252804609722" +
  "53503534226472524250874054075591789781264330331690";
            return number;
        }

        static int[,] GetNumberArray(string bigNumber)
        {

            int[,] integers = new int[100, 50];
            int a;
            int b;

            for (int i = 0; i < bigNumber.Length; i++)
            {
                a = i / 50;
                b = i % 50;
                int.TryParse(bigNumber[i].ToString(), out integers[a, b]);
            }

            return integers;
        }

        static int[] PopulateSumList(int[] listofSums)
        {
            for(int i = 0; i<listofSums.Length; i++)
            {
                listofSums[i] = 0;
            }
            Console.WriteLine("sumList populated with zeroes");
            return listofSums;
            
        }
        //Get the column sum of the nth column in myArray.
        //there are 100 entries in the column.
        //n ranges from 0-49.
        //We want to start at digit 0 of the sum of all the numbers and move on.
        //Digit 0 is in fact n=50
        //Digit 1 is in fact n=49.
        //Digit 2 is in fact n=48
        static int getColumnSum(int n, int[,] bigNumberArray, int[] ListOfSums)
        {
            int columnSum = 0;
            int hundredsRemainder;
            int tensRemainder;
            if (n < 48)
            {
                //Get the hundreds digit of the n-2th sum. There can be a 1000s digit depending on remainders.
                hundredsRemainder = (ListOfSums[n + 2] % 1000) / 100; // ex 50/100  = 0, 250/100 = 2.
                                                                      //Get the tens digit of the n-1th sum. IGNORE THE HUNDREDS DIGIT OF THE n-1th SUM!
                tensRemainder = (ListOfSums[n + 1] % 100) / 10;

            }
            else if (n == 48) // only the tens remainder can exist.
            {
                hundredsRemainder = 0;
                tensRemainder = (ListOfSums[n + 1] % 100) / 10;
            }
            else //occurs at n=49
            {
                hundredsRemainder = 0;
                tensRemainder = 0;
            }

            columnSum += hundredsRemainder + tensRemainder;
            for (int i = 0; i < 100; i++)
            {
              //  Console.WriteLine(bigNumberArray[i, n]);
                columnSum += bigNumberArray[i, n];
            }
//            Console.WriteLine("The {0}th column sum is: {1}", n, columnSum);
            return columnSum;
            }

        static void getAnswer(int[] listOfSums)
        {
            long sum = 0;
            long oldsum; //This goes from 0 to 10.
            string answer;
            /*
            int twelthColHundreds = listOfSums[12] / 100;
            int eleventhColHundreds = listOfSums[11] / 100;
            int eleventhColTens = (listOfSums[11] % 100) / 10;
    */        
    //We want digits 52 to 42.
            //10th column sum + 9th*10 +8th*100 + ...
            for (int i = 12; i>=0; i--)
            {
                oldsum = sum;
                sum += listOfSums[i] * (long) Math.Pow(10, (12 - i));
                Console.WriteLine("{0} + {1} is {2}", oldsum, listOfSums[i] * (long) Math.Pow(10, (10 - i)), sum);
            }

            answer = sum.ToString();
            Console.WriteLine(answer.Substring(0, 10));
            
        }
    }
}