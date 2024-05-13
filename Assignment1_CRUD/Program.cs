
namespace Assignment1_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<object> task = new List<object>();
            Boolean exit = false;
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

                Console.WriteLine("Choose Your Option");
                int opt = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= 5; i++)
                {
                    if (i == opt)
                    {

                        switch (i)
                        {
                            case 1:
                                Console.WriteLine("Add Task");
                                Console.WriteLine("--------");
                                Console.WriteLine("        ");
                                object tasks = Console.ReadLine();
                                task.Add(tasks);
                                Console.WriteLine("Task Added");
                                break;
                            case 2:
                                Console.WriteLine("View Tasks");
                                Console.WriteLine("----------");
                                Console.WriteLine("          ");

                                for (int j = 0; j < task.Count; j++)
                                    Console.WriteLine(task[j]);
                                break;
                            case 3:
                                Console.WriteLine("Update Task");
                                Console.WriteLine("-----------");
                                Console.WriteLine("Enter The Index to Update(index starts from 0):");
                                int Uindex = Convert.ToInt32(Console.ReadLine());
                                if (Uindex >= 0 && Uindex < task.Count)
                                {
                                    Console.WriteLine("Enter Task To Update");
                                    object updatedTask = Console.ReadLine();
                                    task[Uindex] = updatedTask;
                                    Console.WriteLine("Task Updated");
                                }
                                else
                                    Console.WriteLine("Enter Correct index");
                                break;
                            case 4:
                                Console.WriteLine("Delete Task");
                                Console.WriteLine("------------");
                                Console.WriteLine("Enter Index to Delete ");
                                int Dindex =Convert.ToInt32(Console.ReadLine());
                                if (Dindex >= 0 && Dindex < task.Count)
                                {
                                    task.RemoveAt(Dindex);
                                    Console.WriteLine("Task Removed");
                                }
                                break;
                            case 5:
                                exit = true;
                                break;
                            default:
                                Console.WriteLine("Enter The Correct Option");
                                break;
                        }
                        break;
                    }
                }
            }
        }
    }
}
