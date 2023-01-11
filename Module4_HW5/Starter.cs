using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Module4_HW5
{
    public class Starter
    {
        public static void DisplayQueryString(
            string queryName,
            string queryString)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(queryName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(queryString);
        }

        public static void Run()
        {
            var optionsBuilder =
                new DbContextOptionsBuilder<DatabaseContext>();
            var options = optionsBuilder.Options;
            using (DatabaseContext db = new DatabaseContext(options))
            {
                db.SaveChanges();
                Console.WriteLine("DB creation operation has been performed," +
                     "please check your SQL server\n\n");

                // QUERY 1. INCLUDE 3 TABLES AND USE LEFT JOIN
                var query1 = db.Clients.Include(x => x.Projects)
                    .ThenInclude(y => y.EmployeeProject);
                DisplayQueryString(
                    "QUERY 1. INCLUDE 3 TABLES AND USE LEFT JOIN",
                    query1.ToQueryString());
                foreach (var item in query1.ToList())
                {
                    Console.WriteLine(
                        item.ClientName + " " +
                        item.ClientCompany + " " +
                        item.Projects.Count + " " +
                        item.Projects.FirstOrDefault()?.EmployeeProject?.Count);
                }

                // QUERY 2. DIFFERENCE BETWEEN CREATEDDATA/HIREDDATE
                // AND TODAY. SERVER-SIDE FILTRATION
                var query2 = db.Employees
                    .Select(x =>
                    new { DateDifference = DateTime.Now - x.HiredDate });
                DisplayQueryString(
                    "\n\n\nQUERY 2. DIFFERENCE BETWEEN CREATEDDATA" +
                    "/HIREDDATEAND TODAY. SERVER-SIDE FILTRATION",
                    query2.ToQueryString());
                foreach (var item in query2.ToList())
                {
                    Console.WriteLine(item.DateDifference);
                }

                // QUERY 3. UPDATE 2 ENTITIES IN 1 TRANSACTION
                DisplayQueryString(
                    "\n\n\nQUERY 3. UPDATE 2 ENTITIES" +
                    "IN 1 TRANSACTION WAS EXECUTED",
                    string.Empty);
                Console.WriteLine(
                    $"BEFORE[EMPLOYEE/OFFICE] " +
                    $"[{db.Employees.FirstOrDefault().FirstName}," +
                    $"{db.Employees.FirstOrDefault().Office.Title}]");
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Employees.FirstOrDefault().FirstName += "UPDATED";
                        db.Employees.FirstOrDefault().Office.Title += "UPDATED";
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }

                Console.WriteLine(
                    $"AFTER[EMPLOYEE/OFFICE] " +
                    $"[{db.Employees.FirstOrDefault().FirstName}," +
                    $"{db.Employees.FirstOrDefault().Office.Title}]");

                // QUERY 4. ADD "EMPLOYEE" ENTITY WITH "TITLE" AND "PROJECT"
                Models.Employee employee =
                    new Models.Employee()
                    {
                        FirstName = "EMP",
                        LastName = "EMP",
                        DateOfBirth = DateTime.Now,
                        HiredDate = DateTime.Now,
                        Office = new Models.Office
                        {
                            Title = "Office",
                            Location = "Location"
                        },
                        Title = new Models.Title
                        { Name = "Title" }
                    };
                var query4 = db.Employees.Add(employee);
                db.SaveChanges();
                DisplayQueryString(
                    "\n\n\nQUERY 4. ADD 'EMPLOYEE' ENTITY" +
                    "WITH 'TITLE' AND 'PROJECT' (ADD METHOD DOES NOT" +
                    "HAVE SQL QUERY STRING)",
                    query4.ToString());
                Console.WriteLine("EMPLOYEE ADDED");

                // QUERY 5. DELETE EMPLOYEE ENTITY
                var query5 = db.Employees.Remove(employee);
                db.SaveChanges();
                DisplayQueryString(
                    "\n\n\nQUERY 5. DELETE EMPLOYEE ENTITY",
                    query5.ToString());
                Console.WriteLine("Employee was removed");

                // QUERY 6. GROUP EMPLOYEES BY TITLES
                // AND DISPLAY TITLES IF IT DOES NOT CONTAIN 'a'
                var query6 = db.Employees
                .Where(e => !e.Title.Name.Contains("a"))
                .GroupBy(e => e.Title)
                .Select(e => new { Title = e.Key.Name });
                DisplayQueryString(
                    "\n\n\nQUERY 6. GROUP EMPLOYEES BY TITLES AND" +
                    "DISPLAY TITLES IF IT DOES NOT CONTAIN 'a'",
                    query6.ToQueryString());
                Console.WriteLine("Titles that do not contain 'a'");
                foreach (var item in query6)
                {
                    Console.WriteLine(item.Title);
                }
            }
        }
    }
}
