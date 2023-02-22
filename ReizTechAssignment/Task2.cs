using Newtonsoft.Json;
using ReizTechAssignment.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReizTechAssignment
{
    internal class Task2
    {
        public static void BranchTreeSetUpService()
        {
            Branch mainBranch = new Branch();

            mainBranch = JsonHelper.GetTreeObject();

            for (; ; )
            {
                Console.Clear();
                Console.WriteLine("Would you like to add a branch? \n1. Yes\n2. No");
                string userInput = Console.ReadLine();


                if (userInput == "1")
                {
                    BranchMovementService(mainBranch);
                    Console.WriteLine("We are back to the main branch");
                    Thread.Sleep(400);
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("Ok, see you later  /( O_O)/");
                    Thread.Sleep(300);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again...");
                    Thread.Sleep(500);
                }
            }

            JsonHelper.SerializeTreeObjectToJson(mainBranch);
        }

        private static void BranchMovementService(Branch branch)
        {
            for (; ; )
            {
                if (branch.branches.Count != 0)
                {
                    for (; ; )
                    {
                        Console.Clear();

                        for (int i = 0; i < branch.branches.Count; i++)
                        {
                            Console.WriteLine($"Inside this branch there are branch number: {i}");
                        }

                        Console.WriteLine("Would you like to add another branch to current branch or branch inside the branch from current branch \n(a bit confusing maybe, sorry)\n1. First option\n2. Second option\n3. Go back");
                        string userAddingBranchPick = Console.ReadLine();

                        if (userAddingBranchPick == "1")
                        {
                            BranchAddService(branch);
                        }
                        else if (userAddingBranchPick == "2")
                        {
                            int userBranchPickInt = -1;
                            string userBranchPick = "";
                            for (; ; )
                            {
                                bool exceptionThrown = false;
                                Console.WriteLine("\nIn which branch would you like to add a branch?\nTo exit type 'exit'");
                                try
                                {
                                    userBranchPick = Console.ReadLine();
                                    userBranchPickInt = Convert.ToInt32(userBranchPick);
                                }
                                catch (Exception)
                                {
                                    exceptionThrown = true;
                                }

                                if (userBranchPick == "exit") { break; }

                                if (!exceptionThrown && userBranchPickInt >= 0 && userBranchPickInt < branch.branches.Count && userBranchPickInt != null) { break; }
                                else if (exceptionThrown)
                                {
                                    Console.WriteLine("Sorry, but the data you have typed might not be the correct data type");
                                }
                                else if (userBranchPickInt < 0 || userBranchPickInt >= branch.branches.Count || userBranchPickInt == null)
                                {
                                    Console.WriteLine("The number you have typed is not in the range of possible branches");
                                }
                            }

                            if (userBranchPick == "exit")
                            {
                                Console.WriteLine("Going back...");
                                Thread.Sleep(500);
                            }
                            else
                            {
                                Console.WriteLine("Ok lets add branches to branch {0}", userBranchPickInt);
                                Thread.Sleep(500);
                                BranchMovementService(branch.branches[userBranchPickInt]);
                            }
                        }
                        else if (userAddingBranchPick == "3")
                        {
                            goto exit;
                        }
                        else
                        {
                            Console.WriteLine("Wrong input, please try again...");
                            Thread.Sleep(500);
                        }
                    }
                }
                else
                {
                    for (; ; )
                    {
                        Console.WriteLine("There are no branches yet in this branch, would you like to add one?\n1. Yes\n2. Go back");
                        string userInput2 = Console.ReadLine();

                        if (userInput2 == "1")
                        {
                            BranchAddService(branch);
                            break;
                        }
                        else if (userInput2 == "2")
                        {
                            goto exit;
                        }
                        else
                        {
                            Console.WriteLine("Wrong input, please try again...");
                            Thread.Sleep(500);
                        }
                    }
                }
            }

        exit:
            Console.WriteLine("Exiting the branch");
            Thread.Sleep(1500);
        }

        private static void BranchAddService(Branch myBranch)
        {
            Branch newBranch = new Branch();
            myBranch.branches.Add(newBranch);
            Console.WriteLine("Branch added");
            Thread.Sleep(500);
        }
    }
}
