using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumGenSetSearcher
{
    class SummandList
    {
        uint Value, Max, length;
        SummandList next;

        //empty constructor
        public SummandList()
        {
            this.Value = 0;
            this.Max = 0;
            this.length = 0;
            this.next = null;
        }

        // constructor with a first value
        public SummandList(uint FirstSummand)
        {
            this.Value = FirstSummand;
            this.Max = FirstSummand;
            this.length = 1;
            this.next = null;
        }

        // add new summands, but only if they are not already contained
        public void AddSummand(uint NewSummand)
        {
            if (this.isEmpty())
            {
                this.Value = NewSummand;
                this.Max = NewSummand;
                this.length = 1;
                this.next = null;
            }
            else if (NewSummand == this.Max)
            {
                // is already in the list, no action needed
            }
            else
            {
                SummandList current = this;
                bool success = false;
                while ((!success) && (current.next != null))
                {
                    if (current.Value == NewSummand)
                    {
                        // no action needed
                        success = true;
                    }
                    else if (current.next.Value > NewSummand)
                    {
                        //correct place found to add it to the list. No modification of Max needed because there is a larger item
                        SummandList NewItem = new SummandList(NewSummand);
                        NewItem.next = current.next;
                        current.next = NewItem;
                        this.length++;
                    }
                    current = current.next;
                }
                if ((!success) && (current.next == null))
                {
                    // right place not found yet, append it at the end
                    current.next = new SummandList(NewSummand);
                    this.length++;
                    this.Max = NewSummand;
                }
            }
        }

        public bool isEmpty()
        {
            return (this.length == 0);
        }

        public uint GetLength()
        {
            return this.length;
        }

        public uint GetMax()
        {
            return this.Max;
        }

        //create actual copy of all items to avoid interference of pointers to identical elements
        public SummandList Copy()
        {
            SummandList copy = new SummandList();
            if (this.isEmpty())
            {
                return copy;
            }
            else
            {
                SummandList current = this;
                while (current != null)
                {
                    copy.AddSummand(current.Value);
                    current = current.next;
                }
                return copy;
            }
        }

        public ReachedSumsResult GetReachableSumsFull(uint MaxNumSummands)
        {
            // provide a list of all ways sums can be reached with the summands in this list
            // currently only at most two summands are considered, so MaxNumSummands is ignored.
            ReachedSumsResult result = new ReachedSumsResult();
            result.AddResult(0, 0, 0);
            if (!this.isEmpty())
            {
                SummandList SummA = this;
                while (SummA != null)
                {
                    result.AddResult(SummA.Value, SummA.Value, 0); // add result for just one summand being used.
                    SummandList SummB = this;
                    while (SummB != null)
                    {
                        result.AddResult(SummA.Value + SummB.Value, SummA.Value, SummB.Value);
                        SummB = SummB.next;
                    }
                    SummA = SummA.next;
                }
            }
            return result;
        }

        public ReachedSumsResult GetReachableSumsShort(uint MaxNumSummands)
        {
            // provide a list of at least one result for each sum that can be reached with the summands in this list
            // currently only at most two summands are considered, so MaxNumSummands is ignored.
            ReachedSumsResult result = new ReachedSumsResult();
            result.AddResult(0, 0, 0);
            if (!this.isEmpty())
            {
                SummandList SummA = this;
                while (SummA != null)
                {
                    if (!result.SumAlreadyIn(SummA.Value))
                    {
                        result.AddResult(SummA.Value, SummA.Value, 0); // add result for just one summand being used.
                    }
                    SummandList SummB = this;
                    while (SummB != null)
                    {
                        if (!result.SumAlreadyIn(SummA.Value + SummB.Value))
                        {
                            result.AddResult(SummA.Value + SummB.Value, SummA.Value, SummB.Value);
                        }
                        SummB = SummB.next;
                    }
                    SummA = SummA.next;
                }
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            if (this.isEmpty())
            {
                return "Empty List";
            }
            else
            {
                SummandList current = this;
                while (current != null)
                {
                    if (result.Length>0)
                    {
                        result = result + " " + current.Value.ToString();
                    }
                    else
                    {
                        result = current.Value.ToString();
                    }
                    current = current.next;
                }
                return result;
            }
        }
    }
}
