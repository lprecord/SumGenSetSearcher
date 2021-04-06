using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SumGenSetSearcher
{
    class SummandListCatalogue
    {
        SummandList Summands;
        SummandListCatalogue next,last;
        uint length;

        //class creator w/o initial list
        public SummandListCatalogue()
        {
            this.Summands = null;
            this.length = 0;
            this.next = null;
            this.last = null;
        }

        //class creator with initial array
        // don't want to need to check for null pointers, so this is private
        private SummandListCatalogue(SummandList InitSummandList)
        {
            this.length = 0;
            this.last = null;
            SummandList copy = InitSummandList;
            if (null != copy)
            {
                this.Summands = copy;
                this.length = 1;
                this.last = this;
            }
            this.next = null;
        }

        public bool isEmpty()
        {
            return (this.length == 0);
        }

        public uint GetLength()
        {
            return this.length;
        }

        //method for adding a new list at the end of the list
        public void AppendSummandList(SummandList NewSummandList)
        {
            SummandList copy = NewSummandList;
            if (null != copy)
            {
                if (this.isEmpty())
                {
                    this.Summands = copy;
                    this.length = 1;
                    this.last = this;
                    this.next = null;
                    //MessageBox.Show("empty to: " + this.Summands.ToString());
                }
                else
                {
                    this.last.next = new SummandListCatalogue(copy);
                    this.length++;
                    this.last = this.last.next;
                }
            }
        }

        public SummandList GetNthSummandList(uint n) //get the nth summand list in the collection
        {
            if (this.isEmpty() || (n>this.length))
            {
                return null;
            }
            else
            {
                SummandListCatalogue current = this;
                for (int i = 1; i <n; i++)
                {
                    current = current.next;
                }
                return current.Summands;
            }
        }

        public SummandList RemoveFirstSummandList()//get the first summand list in the collection and remove it from the collection
        {
            if (this.isEmpty())
            {
                //nothing to remove
                return null;
            }
            else if (this.next == null)
            {
                // special simple case: just one element
                SummandList copy = this.Summands;
                this.Summands = null;
                this.length = 0;
                this.last = null;
                return copy;
            }
            else
            {
                // "this" cannot be deleted, so the next element is deleted, but it's value is taken over into the current element
                SummandList copy = this.Summands;
                this.Summands = next.Summands;
                this.length--;
                if (this.last == this.next)
                {
                    this.last = this; // handle special case where there is just one additional element
                }
                this.next = this.next.next;
                return copy;
            }
        }
    }
}
