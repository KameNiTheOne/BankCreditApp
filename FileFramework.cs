using System.Globalization;
using System.Text;

namespace TestNumbers
{
    public static class FileFramework
    {
        static string savefilename;
        public static void Save()
        {
            File.Delete(savefilename);
            using (var stream = File.Open(savefilename, FileMode.Create))
            {
                using (var Writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach(User user in Repository.Users)
                    {
                        sb.Append($"{user.Name}\t{user.Age}\t{user.CreditedMoney}\t{user.CreditPercentage}\t{user.HasToReturn}\t");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    Writer.WriteLine(sb.ToString());
                }
            }
        }
        public static void Restore()
        {
            CreateFolder();
            if (File.Exists(savefilename))
            {
                using (var stream = File.Open(savefilename, FileMode.Open))
                {
                    using (var reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        string[] tempstr = reader.ReadLine().Split(new char[] { '\t' });
                        for (int i = 0; i < tempstr.Length; i++)
                        {
                            string Name = tempstr[i];
                            int Age = Convert.ToInt32(tempstr[++i]);
                            int CredMoney = Convert.ToInt32(tempstr[++i]);
                            double CredPercentage = Convert.ToDouble(tempstr[++i]);
                            double HasToReturn = Convert.ToDouble(tempstr[++i]);
                            Repository.Users.Add(new User(Name, Age, CredMoney, CredPercentage, HasToReturn));
                        }
                    }
                }
            }
        }
        static void CreateFolder()
        {
            string baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderPath = Path.Combine(baseFolder, @"BankApp(C#)\");
            Directory.CreateDirectory(folderPath);
            savefilename = folderPath + "SaveData.dat";
        }
    }
}
