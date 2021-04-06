using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SumGenSetSearcher
{
    class SummandListSearcher
    {
        public static SummandListCatalogue BFS_SummandLists2Range(uint SumA, uint SumB, uint MaxNumSummands)
        {
            // currently the max number of summands is limited to 2, so MaxNumSummands will be ignored
            SummandListCatalogue BFSIntermediateResults = new SummandListCatalogue();
            SummandListCatalogue Results = new SummandListCatalogue();
            bool ResultFound = false;
            bool TooLongResults = false;
            uint MaxSummandListLength = UInt32.MaxValue; // will only make sense after first result is found
            uint SumMin = Math.Min(SumA, SumB);
            uint SumMax = Math.Max(SumA, SumB);
            SummandList current = new SummandList();

            BFSIntermediateResults.AppendSummandList(current); //initialization with at least one result list

            //loop
            while ((!BFSIntermediateResults.isEmpty()) && (!TooLongResults))
            {
                // extract summand result list in the catalogue and check if it is already a solution
                current = BFSIntermediateResults.RemoveFirstSummandList();
                //MessageBox.Show("currently extracted: " + current.ToString());
                ReachedSumsResult Reachables = current.GetReachableSumsShort(MaxNumSummands);
                //MessageBox.Show("Reachable Sums: " + Reachables.ToString());
                if (Reachables.ReachedSumsBetween(SumMin, SumMax))
                {
                    //MessageBox.Show("Solution: " + current.ToString());
                    // current summand list is a valid solution, add it to the final results list, but only if it is not too long
                    if (current.GetLength() <= MaxSummandListLength)
                    {
                        Results.AppendSummandList(current);
                    }
                    else
                    {
                        TooLongResults = true; // from now on, all found solutions will be longer than the current ones, we can abort
                    }
                    // additionally, if it is the first result found, then fix the max length of valid results
                    // in order to record only the most efficient ones
                    if (!ResultFound)
                    {
                        ResultFound = true;
                        MaxSummandListLength = current.GetLength();
                    }
                }
                else
                {
                    // create new longer tentative solutions and append them to the intermediate results for further evaluation 
                    //(at the end so that the shortest solutions are found first)
                    uint StartVal = current.GetMax()+1;
                    for (uint i = StartVal; i <= SumMax; i++)
                    {
                        SummandList NewSummandList = current.Copy(); //create full copy of currently evaluated list
                        NewSummandList.AddSummand(i);
                        //MessageBox.Show("new tentative: " + NewSummandList.ToString());
                        BFSIntermediateResults.AppendSummandList(NewSummandList);
                    }
                }
            }
            return Results;
        }
    }
}
