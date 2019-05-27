using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GlobalClasses;
using DataAccessLayer;

namespace BusinessLayer
{
    //Caspar
    //Klasse med alle metoderne til fordeling af åbent hus. Implementeret med både hob, og en tilfældig fordeling.
    public class OpenHouseMethods
    {
        //List som skal fungere som HOB.
        private static List<Property> maxHob = new List<Property>();

        //Metoden som kalses gennem knappen til fordeling i Open_House_Distribution UI.
        public static DataTable DistributeHouses(DataTable agentDataTable, DataTable propertyDataTable, int sortMethod)
        {
            //Laver to arrays af hver objekt.
            Agent[] agentsArray = new Agent[agentDataTable.Rows.Count];
            Property[] propertiesArray = new Property[propertyDataTable.Rows.Count];

            //Fylder objekter ind i hver sit array, hentet fra databasen.
            for (int i = 0; i <= agentDataTable.Rows.Count - 1; i++)
            {
                agentsArray[i] = DataAccessLayerFacade.GetAgentById((int)agentDataTable.Rows[i][0]);
            }
            //-||-
            for (int i = 0; i <= propertyDataTable.Rows.Count - 1; i++)
            {
                propertiesArray[i] = DataAccessLayerFacade.GetPropertyById((int)propertyDataTable.Rows[i][0]);
            }

            //Datatable som indeholder fordelingen.
            DataTable distribution = new DataTable();

            //Tilføjer kolonner til datatablet distrubution.
            distribution.Columns.Add("Mægler Id", typeof (int));
            distribution.Columns.Add("Sagsnummer", typeof (int));
            distribution.Columns.Add("Kontant pris", typeof (int));

            //Switch case til hvilken metode der skal bruges til fordelingen.
            switch (sortMethod)
            {
                //Fordel efter Maks-Hob princippet.
                case 0:
                    //Loop som inserter alle boliger i hoben.
                    foreach (Property property in propertiesArray)
                    {
                        Insert(property);
                    }
                    //Så længe hoben har boliger.
                    while (maxHob.Count != 0)
                    {
                        //For hver agent.  
                        for (int j = 0; j <= agentsArray.Length - 1; j++)
                        {
                            //Har hoben stadig boliger?
                            if (maxHob.Count != 0)
                            {
                                //Slet den root-boligen, og returner den som et objekt.
                                Property property = DeleteFirstNode();
                                //Tilføj en row med AId, CaseNr, og CashPrice til fordelings datatablet.
                                distribution.Rows.Add(agentsArray[j].AId, property.CaseNr, property.CashPrice);
                            }
                        }
                    }
                    break;
                //Fordel tilfældigt.
                case 1:
                    //Nyt random objekt.
                    Random random = new Random();
                    //Liste med alle boliger, som nemt kan hentes og slettes fra.
                    List<Property> propertiesList = new List<Property>(propertiesArray);
                    //Så længer der er boliger i listen.
                    while (propertiesList.Count != 0)
                    {
                        //For hver agent.
                        for (int j = 0; j <= agentsArray.Length - 1; j++)
                        {
                            //Har listen stadig boliger?
                            if (propertiesList.Count != 0)
                            {
                                //Find et random index.
                                int randomInt = random.Next(0, propertiesList.Count);
                                //Lav et objekt af indexet.
                                Property property = propertiesList[randomInt];
                                //Tilføj en row med AId, CaseNr, og CashPrice til fordelings datatablet.
                                distribution.Rows.Add(agentsArray[j].AId, property.CaseNr, property.CashPrice);
                                //Fjern boligen på det brugte index.
                                propertiesList.RemoveAt(randomInt);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            //Returner fordelingen som et datatable.
            return distribution;
        }

        private static void Insert(Property property)
        {
            maxHob.Add(property);//Tilføjer værdien til listen.

            MaxHobSort(maxHob.Count - 1);//Kalder metoden for sortering af hoben.
        } //Indsætter en værdi i list-hoben og sorterer det.

        private static void MaxHobSort(int child)
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

        private static Property DeleteFirstNode()
        {
            Property rootValue = FirstNodeValue();

            maxHob[0] = LastLeafValue();//Root værdien i hoben overskrives med den sidste værdi i hoben.

            maxHob.RemoveAt(maxHob.Count - 1);//Fjerner den sidste værdi i hoben.

            MaxHobSortDeletion(0);//Kalder metoden med ansvaret for at sortere oppe fra og ned.

            return rootValue;//returnerer den største værdi i hoben.
        } //Fjerner den første node i hoben, og returnerer dens værdi.

        private static void MaxHobSortDeletion(int parent)
        {
            if (LeftChild(parent) < maxHob.Count - 1 || RightChild(parent) < maxHob.Count - 1)//Kontrollerer at child index er mindre end længden på arrayet.
            {
                int leftChildInt = maxHob[LeftChild(parent)].CashPrice;//Finder værdien på det venstre child.
                int rightChildInt = maxHob[RightChild(parent)].CashPrice;//Finder værdien på det højre child.
                int parentInt = maxHob[parent].CashPrice;

                bool leftChildBigger = parentInt < leftChildInt && leftChildInt >= rightChildInt; //Kontrollerer om venstre child er større end parent, og at den er større end, eller = med højre child.
                                                                                               //Dette gøres fordi hvis begge childs er større end parenten, men de begge er lige store, er det den venstre der rykkes op.
                bool rightChildBigger = parentInt < rightChildInt && leftChildInt < rightChildInt;//Kontrollerer om højre child er større end parent og venstre child. 

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
            MaxHobSort(maxHob.Count - 1);
        } //Sorterer træet oppe fra og ned.

        private static Property FirstNodeValue() => maxHob[0]; //Finder den første værdi i hoben.
        private static Property LastLeafValue() => maxHob[maxHob.Count - 1]; //Finder den sidste værdi i hoben.
        private static int Parent(int node)
        {
            return (node - 1) / 2;
        } //Finder parent indexet.
        private static int LeftChild(int node) => 2 * node + 1; //Finder det venstre childs index.
        private static int RightChild(int node) => 2 * node + 2; //Finder det højre childs index.
    }
}
