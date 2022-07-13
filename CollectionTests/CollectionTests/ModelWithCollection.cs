using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTests
{
     public class TreeMapper
    {
        private static  int usefullCounter = 0;
        
        public NewTree MapTreeObject(OldTree qc)
        {
            var model = MapInternal(qc, new HashSet<string>());
            return model;
        }

        private NewTree MapInternal(OldTree iqc, HashSet<string> visitedVertices)
        {
            var index = TakeCounter();

            Console.WriteLine($"(Call no.{index}) Call for vertice {iqc.Id}, Collection of visited vertices is: [{string.Join(',', visitedVertices)}]");
            if (visitedVertices.Contains(iqc.Id))
            {
                Console.WriteLine($"(Call no.{index}) Not mapping the {iqc.Id}, beacuse it was already visited");
                return null;
            }
                

            visitedVertices.Add(iqc.Id);
            Console.WriteLine($"(Call no.{index}) Mapping the {iqc.Id}");

            
            return new NewTree()
            {
                Id = iqc.Id,
                Parents = iqc.Parents?.Select(x => MapInternal(x, visitedVertices))
            };
        }

        private int TakeCounter()
        {
            return usefullCounter++;
        }
    }


    public class OldTree
    {
        public string Id { get; set; }
        public List<OldTree> Parents { get; set; }
    }
}
