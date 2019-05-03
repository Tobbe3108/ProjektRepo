using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Classes;

namespace BusinessLayer
{
    class OpenHouseMethods
    {
        public static int[] maxHob = new int[0];

        public static int[,] DistributeHouses(Agent[] agentsArray, Property[] propertiesArray)
        {
            int[,] distribution = new int[agentsArray.Length-1, propertiesArray.Length-1];

            foreach (Property price in propertiesArray)
            {

            }
        }

        public static void Insert(int value)
        {
            List<int> tempList = new List<int>(maxHob);//Midlertidig liste til obevaring af maxHob arrayet.

            tempList.Add(value);//Tilføjer værdien til listen.

            maxHob = new int[tempList.Count];//Erstatter maxHob med et nyt array, nu 1 større.

            for (int i = 0; i < tempList.Count; i++)//Kopierer dataen tilbage til arrayet fra listen.
            {
                maxHob[i] = tempList[i];
            }

            MaxHobSort(maxHob.Length - 1);//Kalder metoden for sortering af hoben.
        } //Indsætter en værdi i arrayet og sorterer det.

        public static void MaxHobSort(int child)
        {
            if (maxHob[child] > maxHob[Parent(child)])//Kontrollerer om child er større parent til child.
            {
                int temp = maxHob[child];//Opretter midlertidig int.

                maxHob[child] = maxHob[Parent(child)];//Child bliver = parent.

                maxHob[Parent(child)] = temp;//Parent bliver = midlertidig child værdi.

                MaxHobSort(Parent(child));//Kalder sorterings algoritmen igen, nu med parent pladsen til det child vi startede med.
            }
        } //Sorterer arrayet.

        public static int DeleteFirstNode()
        {
            List<int> tempList = new List<int>(maxHob);//Midlertidig liste til hob-arrayet.

            int rootValue = tempList[0];

            tempList[0] = LastLeafValue();//Root værdien i hoben overskrives med den sidste værdi i hoben.

            tempList.RemoveAt(maxHob.Length - 1);//Fjerner den sidste værdi i hoben.

            maxHob = new int[tempList.Count];//Laver et ny array ud fra listen vi arbejder med.

            for (int i = 0; i < tempList.Count; i++)//Kopierer dataen fra listen til arrayet.
            {
                maxHob[i] = tempList[i];
            }

            MaxHobSortDeletion(0);//Kalder metoden med ansvaret for at sortere oppe fra og ned.

            return rootValue;//returnerer den største værdi i hoben.
        } //Fjerner den første node i træet, og returnerer dens værdi.

        public static void MaxHobSortDeletion(int parent)
        {
            if (LeftChild(parent) < maxHob.Length - 1 || RightChild(parent) < maxHob.Length - 1)//Kontrollerer at child index er mindre end længden på arrayet.
            {
                int leftChildInt = maxHob[LeftChild(parent)];//Finder værdien på det venstre child.
                int rightChildInt = maxHob[RightChild(parent)];//Finder værdien på det højre child.

                bool leftChildBigger = parent < leftChildInt && leftChildInt >= rightChildInt; //Kontrollerer om venstre child er større end parent, og at den er større end, eller = med højre child.
                                                                                               //Dette gøres fordi hvis begge childs er større end parenten, men de begge er lige store, er det den venstre der rykkes op.
                bool rightChildBigger = parent < rightChildInt && leftChildInt < rightChildInt;//Kontrollerer om højre child er større end parent og venstre child. 

                if (leftChildBigger)
                {
                    int temp = maxHob[parent];//Laver en temp værdi for parent.

                    maxHob[parent] = leftChildInt;//Sætter parent værdi = venstre childs værdi.

                    maxHob[LeftChild(parent)] = temp;//Sætter venstre childs værdi = parent værdi.

                    MaxHobSortDeletion(LeftChild(parent));//Kalder metoden igen, nu med det venstre barn som parent.
                }
                else if (rightChildBigger)
                {
                    int temp = maxHob[parent];//Samme som for oven.

                    maxHob[parent] = rightChildInt;

                    maxHob[RightChild(parent)] = temp;

                    MaxHobSortDeletion(RightChild(parent));
                }
            }
            MaxHobSort(maxHob.Length - 1);
        } //Sorterer træet oppe fra og ned.
         
        public static int FirstNodeValue() => maxHob[0]; //Bruges ikke. Finder den første værdi i hoben.
        public static int LastLeafValue() => maxHob[maxHob.Length - 1]; //Finder den sidste værdi i hoben.
        public static int Parent(int node)
        {
            return (node - 1) / 2;
        } //Finder parent indexet.
        public static int LeftChild(int node) => 2 * node + 1; //Finder det venstre childs index.
        public static int RightChild(int node) => 2 * node + 2; //Finder det højre childs index.
    }
}
