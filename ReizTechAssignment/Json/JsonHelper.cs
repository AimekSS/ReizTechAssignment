using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReizTechAssignment.Json
{
    internal class JsonHelper
    {
        public static string fileName = "jsonBranchStringFile.json";
        public static string folderName = "Json";
        public static string filePath = Path.Combine($"..\\..\\..\\{folderName}", fileName);
        public static string testDataFilePath = Path.Combine($"..\\..\\..\\{folderName}", "testData.json");


        public static Branch GetTreeObject()
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Branch>(jsonString);
        }

        public static void SerializeTreeObjectToJson(Branch branch)
        {
            string jsonString = JsonConvert.SerializeObject(branch);
            File.WriteAllText(filePath, jsonString);
        }


        public static Branch GetTreeObjectTestData()
        {
            string jsonString = File.ReadAllText(testDataFilePath);
            return JsonConvert.DeserializeObject<Branch>(jsonString);
        }
    }
}
