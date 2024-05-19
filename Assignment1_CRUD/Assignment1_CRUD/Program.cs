namespace Assignment1_CRUD
{
    internal class Program
    {
        class Task
        {
            public string Title;
            public string Description;
            public Task(string title, string description)
            {
                this.Title = title;
                this.Description = description;
            }
        }
        static void Main(string[] args)
        {
            List<Task> task = new List<Task>();
            bool exit = false;
            while (exit != true)
            {
                Console.WriteLine("       ");
                Console.WriteLine("OPTIONS");
                Console.WriteLine("-------");
                Console.WriteLine("1.ADD");
                Console.WriteLine("2.VIEW");
                Console.WriteLine("3.UPDATE");
                Console.WriteLine("4.DELETE");
                Console.WriteLine("5.EXIT");
                Console.WriteLine("       ");

                Console.WriteLine("Enter Your Option (1-5)");
                int opt =Convert.ToInt32(Console.ReadLine());

                if (opt > 5)
                {
                    Console.WriteLine("Enter Option between 1-5");
                    continue;
                }
                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Add Task");
                        Console.WriteLine("--------");
                        Console.WriteLine("Title:");
                        string title=Console.ReadLine();
                        Console.WriteLine("Description:");
                        string description=Console.ReadLine();
                        task.Add(new Task(title, description));
                        Console.WriteLine("Tasked Added");
                        break;
                    case 2:
                        Console.WriteLine("View");
                        Console.WriteLine("----");
                        if (task.Count == 0)
                        {
                            Console.WriteLine("No Task Found");
                        }
                        else
                        {
                            for (int i = 0; i < task.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}.Title:{task[i].Title}\n  Description:{task[i].Description}");
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Update");
                        Console.WriteLine("------");
                        Console.WriteLine("Enter Id to Update :");
                        int Updateindex = Convert.ToInt32(Console.ReadLine());
                        Updateindex = Updateindex - 1;
                        if (Updateindex >= 0 && Updateindex < task.Count)
                        {
                            /*Console.WriteLine($"Enter New Title to Update:{task[Updateindex].Title}");
                            string UpdateTitle=Console.ReadLine();
                            task[Updateindex].Title = UpdateTitle;
                            Console.WriteLine($"Enter New Description to Update:{task[Updateindex].Description}");
                            string UpdateDescription=Console.ReadLine();
                            task[Updateindex].Description = UpdateDescription;
                            Console.WriteLine("Updated");*/

                            Console.WriteLine("Choose for Updation");
                            Console.WriteLine("1.Title");
                            Console.WriteLine("2.Description");
                            Console.WriteLine("Choose your Option");
                            int opt2 = Convert.ToInt32(Console.ReadLine());
                            if (opt > 2)
                                Console.WriteLine("Enter Correct Option");
                            switch (opt2)
                            {
                                case 1:
                                    Console.WriteLine("Title");
                                    Console.WriteLine("-----");
                                    Console.WriteLine($"Enter New Title to Update:{task[Updateindex].Title}");
                                    string UpdateTitle = Console.ReadLine();
                                    task[Updateindex].Title = UpdateTitle;
                                    Console.WriteLine("Title Updated");
                                    break;
                                case 2:
                                    Console.WriteLine("Description");
                                    Console.WriteLine("-----------");
                                    Console.WriteLine($"Enter New Title to Update:{task[Updateindex].Description}");
                                    string UpdateDescription = Console.ReadLine();
                                    task[Updateindex].Description = UpdateDescription;
                                    Console.WriteLine("Description Updated");
                                    break;
                            }
                        }
                        else
                            Console.WriteLine("Index not found");
                        break;
                    case 4:
                        Console.WriteLine("Delete");
                        Console.WriteLine("------");
                        Console.WriteLine("Enter Index to Delete ");
                        int Deleteindex = Convert.ToInt32(Console.ReadLine());
                        Deleteindex = Deleteindex - 1;
                        if (Deleteindex >= 0 && Deleteindex < task.Count)
                        {
                            task.RemoveAt(Deleteindex);
                            Console.WriteLine("Task Removed");
                        }
                        else
                            Console.WriteLine("Nothing to delete");
                        break;
                    case 5:
                        exit=true;
                        break;
                }
            }
        }
    }
}
