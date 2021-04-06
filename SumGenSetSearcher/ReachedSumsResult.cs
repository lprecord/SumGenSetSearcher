using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumGenSetSearcher
{
    class ReachedSumsResult
    {
        uint Sum, SummandA, SummandB, length;
        ReachedSumsResult next;

        //empty constructor
        public ReachedSumsResult()
        {
            this.Sum = 0;
            this.SummandA = 0;
            this.SummandB = 0;
            this.length = 0;
            this.next = null;
        }

        //constructor with one result
        // only used internally, so a check can be done if the result to be added is correct;
        private ReachedSumsResult(uint SumIn, uint SummAIn, uint SummBIn)
        {
            this.Sum = SumIn;
            this.SummandA = Math.Max(SummAIn, SummBIn);
            this.SummandB = Math.Min(SummAIn, SummBIn);
            this.length = 1;
            this.next = null;
        }

        private ReachedSumsResult GetLastInList()
        {
            if (this.next == null)
            {
                return this;
            }
            else
            {
                ReachedSumsResult last = this.next;
                while (last.next!=null)
                {
                    last = last.next;
                }
                return last;
            }
        }

        public bool isEmpty()
        {
            return (this.length == 0);
        }

        public bool AddResult(uint SumIn, uint SummAIn, uint SummBIn)
        {
            // add result in order with preference Sum, maximum of SummA, SummB, minimum of SummA, SummB
            // don't add a result identical to a previous one added
            //don't add wrong results
            if ((SummAIn + SummBIn) != SumIn)
            {
                return false; // no success if result is a false result
            }
            else
            {
                bool success = false; //initial assumption: result will not be added;

                if (this.isEmpty())
                {
                    this.Sum = SumIn;
                    this.SummandA = Math.Max(SummAIn, SummBIn);
                    this.SummandB = Math.Min(SummAIn, SummBIn);
                    this.length = 1;
                    this.next = null;
                    success = true;
                }
                else
                {
                    ReachedSumsResult beforelast = this;
                    ReachedSumsResult last = this;
                    bool identicalfound = false;
                    while ((last != null) && (!success) && (!identicalfound))
                    {
                        if ((SumIn < last.Sum) 
                            ||((last.Sum == SumIn)
                                && (Math.Max(SummAIn, SummBIn) < last.SummandA))
                            ||((last.Sum == SumIn)
                                && (Math.Max(SummAIn, SummBIn) == last.SummandA)
                                && (Math.Min(SummAIn, SummBIn) < last.SummandB)))
                        {
                            //suitable place for putting in the new result found, and the current sum is larger than the input
                            ReachedSumsResult AddIn = new ReachedSumsResult(last.Sum, last.SummandA, last.SummandB);
                            AddIn.next = last.next;
                            last.next = AddIn;
                            last.Sum = SumIn;
                            last.SummandA = Math.Max(SummAIn, SummBIn);
                            last.SummandB = Math.Min(SummAIn, SummBIn);
                            this.length++;
                            success = true;
                        }
                        else if ((last.Sum == SumIn)
                                && (Math.Max(SummAIn, SummBIn) == last.SummandA)
                                && (Math.Min(SummAIn, SummBIn) == last.SummandB))
                        {
                            identicalfound = true;
                        }
                        beforelast = last;
                        last = last.next;
                    }
                    if (!success && !identicalfound)
                    {
                        // no suitable place found yet? Not aborted because an identical result is already in the list?
                        // add the result at the end;
                        beforelast.next = new ReachedSumsResult(SumIn, SummAIn, SummBIn);
                        this.length++;
                        success = true;
                    }
                }

                return success;
            }
        }

        public bool ResAlreadyIn(uint SumIn, uint SummAIn, uint SummBIn) // check if an identical result was already added
        {
            bool result = false;
            ReachedSumsResult current = this;
            while ((current!=null) && (!result))
            {
                if ((current.Sum==SumIn) && 
                    (current.SummandA == Math.Max(SummAIn, SummBIn)) && 
                    (current.SummandB == Math.Min(SummAIn, SummBIn)))
                {
                    result = true;
                }
                current = current.next;
            }
            return result;
        }

        public bool SumAlreadyIn(uint SumIn) // check if a result for this sum was already added
        {
            bool result = false;
            ReachedSumsResult current = this;
            while ((current!= null) && (!result))
            {
                if (current.Sum == SumIn)
                {
                    result = true;
                }
                current = current.next;
            }
            return result;
        }

        public bool ReachedSumsBetween(uint Sum1, uint Sum2) //check if all the sums between two values (including the values) are reached in this results list
        {
            if (this.isEmpty())
            {
                return false;
            }
            else
            {
                bool nonemissed = true;
                bool searchfinished = false;
                uint SumMin = Math.Min(Sum1, Sum2);
                uint SumMax = Math.Max(Sum1, Sum2);
                uint CurrentSum = SumMin;
                ReachedSumsResult current = this;
                while ((current != null) && (!searchfinished))
                {
                    if (current.Sum > CurrentSum)
                    {
                        //sum in current list item is larger than our searched item, so it can't have been
                        // in the list (which is sorted by sum)
                        nonemissed = false;
                        searchfinished = true;
                    }
                    else if (current.Sum == CurrentSum) 
                    {
                        // currently searched element in the range found. Now search the next one (if any is still to be searched)
                        // because the list is ordered, the next one must be located further down the list
                        if (CurrentSum == SumMax)
                        {
                            searchfinished = true;
                        }
                        else
                        {
                            CurrentSum++;
                        }
                    }
                    current = current.next;
                }
                if ((!nonemissed) || (!searchfinished))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public override string ToString() // do the full list of results line by line
        {
            string result = "";
            if (this.isEmpty())
            {
                return "No sums reached.";
            }
            else
            {
                ReachedSumsResult current = this;
                while (current != null)
                {
                    result = result + current.SummandA.ToString() + " + " + current.SummandB.ToString() + " = " + current.Sum.ToString() + "\n";
                    current = current.next;
                }
                return result;
            }
        }

        public string ToString(uint LimA, uint LimB) // do a short summary of all the results outside the range, do the results inside the range line by line
        {
            uint SumMin = Math.Min(LimA, LimB);
            uint SumMax = Math.Max(LimA, LimB);
            bool aboveMin = false;
            string result = "";
            if (this.isEmpty())
            {
                return "No sums reached.";
            }
            else
            {
                ReachedSumsResult current = this;
                while (current != null)
                {
                    if ((current.Sum >= SumMin) && (current.Sum <= SumMax))
                    {
                        if (!aboveMin)
                        {
                            result = result + "\n";
                            aboveMin = true;
                        }
                        result = result + current.SummandA.ToString() + " + " + current.SummandB.ToString() + " = " + current.Sum.ToString() + "\n";
                    }
                    else//(current.Sum > SumMax || current.Sum < SumMin)
                    {
                        result = result + current.SummandA.ToString() + "+" + current.SummandB.ToString() + "=" + current.Sum.ToString() + "/ ";
                    }
                    current = current.next;
                }
                return result;
            }
        }
    }
}
