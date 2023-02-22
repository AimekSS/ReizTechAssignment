using ReizTechAssignment.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReizTechAssignment
{
    internal class Task3
    {
        public static Branch task3Branch = JsonHelper.GetTreeObject();

        public static int ReturnBranchTreeDepth(Branch myBranch)
        {
            if (myBranch.branches == null)
            {
                return 0;
            }
            int maxDepth = 0;
            foreach(Branch branch in myBranch.branches)
            {
                int depth = ReturnBranchTreeDepth(branch);
                maxDepth = Math.Max(maxDepth, depth);
            }
            
            return maxDepth + 1;
        }
    }
}
