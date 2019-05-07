using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;
using System.Data;

namespace GlobalClasses
{
    public class OpenHouseMethods
    {
        public static Property[] maxHob = new Property[0];

        public static DataTable DistributeHouses(Agent[] agentsArray, Property[] propertiesArray, int sortMethod)
        {
            DataTable distribution = new DataTable();

            distribution.Columns.Add("AId", typeof (int));
            distribution.Columns.Add("CaseNr", typeof (int));
            distribution.Columns.Add("CashPrice", typeof (int));

            switch (sortMethod)
            {
                case 0:
                    foreach (Property property in propertiesArray)
                    {
                        Insert(property);
                    }

                    while (maxHob.Length != 0)
                    {
                            for (int j = 0; j <= agentsArray.Length - 1; j++)
                            {
                                if (maxHob.Length != 0)
                                {
                                    Property property = DeleteFirstNode();
                                    distribution.Rows.Add(agentsArray[j].AId, property.CaseNr, property.CashPrice);
                                }
                        }
                    }
                    break;
                case 1:
                    Random random = new Random();

                    List<Property> propertiesList = new List<Property>(propertiesArray);

                    while (propertiesList.Count != 0)
                    {
                        for (int j = 0; j <= agentsArray.Length - 1; j++)
                        {
                            if (propertiesList.Count != 0)
                            {
                                int randomInt = random.Next(0, propertiesList.Count - 1);
                                Property property = propertiesList[randomInt];
                                distribution.Rows.Add(agentsArray[j].AId, property.CaseNr, property.CashPrice);
                                propertiesList.RemoveAt(randomInt);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            return distribution;
        }

        public static void Insert(Property property)
        {
            List<Property> tempList = new List<Property>(maxHob);//Midlertidig liste til obevaring af maxHob arrayet.

            tempList.Add(property);//Tilføjer værdien til listen.

            maxHob = new Property[tempList.Count];//Erstatter maxHob med et nyt array, nu 1 større.

            for (int i = 0; i < tempList.Count; i++)//Kopierer dataen tilbage til arrayet fra listen.
            {
                maxHob[i] = tempList[i];
            }

            MaxHobSort(maxHob.Length - 1);//Kalder metoden for sortering af hoben.
        } //Indsætter en værdi i arrayet og sorterer det.

        public static void MaxHobSort(int child)
        {
            if (child > 0)
            {
                if (maxHob[child].CashPrice > maxHob[Parent(child)].CashPrice)//Kontrollerer om child er større end parent til child.
                {
                    Property temp = maxHob[child];//Opretter midlertidig int.

                    maxHob[child] = maxHob[Parent(child)];//Child bliver = parent.

                    maxHob[Parent(child)] = temp;//Parent bliver = midlertidig child værdi.

                    MaxHobSort(Parent(child));//Kalder sorterings algoritmen igen, nu med parent pladsen til det child vi startede med.
                }
            }

        } //Sorterer arrayet.

        public static Property DeleteFirstNode()
        {
            List<Property> tempList = new List<Property>(maxHob);//Midlertidig liste til hob-arrayet.

            Property rootValue = FirstNodeValue();

            tempList[0] = LastLeafValue();//Root værdien i hoben overskrives med den sidste værdi i hoben.

            tempList.RemoveAt(maxHob.Length - 1);//Fjerner den sidste værdi i hoben.

            maxHob = new Property[tempList.Count];//Laver et ny array ud fra listen vi arbejder med.

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
                int leftChildInt = maxHob[LeftChild(parent)].CashPrice;//Finder værdien på det venstre child.
                int rightChildInt = maxHob[RightChild(parent)].CashPrice;//Finder værdien på det højre child.

                bool leftChildBigger = parent < leftChildInt && leftChildInt >= rightChildInt; //Kontrollerer om venstre child er større end parent, og at den er større end, eller = med højre child.
                                                                                               //Dette gøres fordi hvis begge childs er større end parenten, men de begge er lige store, er det den venstre der rykkes op.
                bool rightChildBigger = parent < rightChildInt && leftChildInt < rightChildInt;//Kontrollerer om højre child er større end parent og venstre child. 

                if (leftChildBigger)
                {
                    Property temp = maxHob[parent];//Laver en temp værdi for parent.

                    maxHob[parent] = maxHob[LeftChild(parent)];//Sætter parent værdi = venstre childs værdi.

                    maxHob[LeftChild(parent)] = temp;//Sætter venstre childs værdi = parent værdi.

                    MaxHobSortDeletion(LeftChild(parent));//Kalder metoden igen, nu med det venstre barn som parent.
                }
                else if (rightChildBigger)
                {
                    Property temp = maxHob[parent];//Samme som for oven.

                    maxHob[parent] = maxHob[RightChild(parent)];

                    maxHob[RightChild(parent)] = temp;

                    MaxHobSortDeletion(RightChild(parent));
                }
            }
            MaxHobSort(maxHob.Length - 1);
        } //Sorterer træet oppe fra og ned.

        public static Property FirstNodeValue() => maxHob[0]; //Bruges ikke. Finder den første værdi i hoben.
        public static Property LastLeafValue() => maxHob[maxHob.Length - 1]; //Finder den sidste værdi i hoben.
        public static int Parent(int node)
        {
            return (node - 1) / 2;
        } //Finder parent indexet.
        public static int LeftChild(int node) => 2 * node + 1; //Finder det venstre childs index.
        public static int RightChild(int node) => 2 * node + 2; //Finder det højre childs index.
    }
}
