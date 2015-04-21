using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MvcMongoDB01.Properties;
using MongoDB.Driver.Linq;

namespace MvcMongoDB01.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public MongoDatabase mongoDatabase;
        public MongoCollection EmployeesCollection;
        public bool ServerIsDown = false;

        // Constructor
        public EmployeeRepository()
        {
            // Get the Mongo Client
           // var mongoClient = new MongoClient(Settings.Default.EmployeesConnectionString);

            // Get the Mongo Server from the Cliet Instance
            //var server = mongoClient.GetServer();

            // Assign the database to mongoDatabase
           // MongoDatabase = server.GetDatabase(Settings.Default.DB);

            // get the Employees collection (table) and assign to EmployeesCollection
            // "Employees"- db name is same as collection (table) name.
           // EmployeesCollection = MongoDatabase.GetCollection("Employees");



            /*mongodb://gactmongo:gact@ds041150.mongolab.com:41150*/
            string host = "ds041150.mongolab.com";
            int port = 41150;
            string dbName = "gactdemo";
            string user = "gactmongo";
            string password = "gact";
            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress(host, port);
            MongoCredential cred = MongoCredential.CreateMongoCRCredential(dbName, user, password);
            settings.Credentials = new List<MongoCredential>() { cred };
            MongoClient mongoClient = new MongoClient(settings);
            MongoServer server = mongoClient.GetServer();
            mongoDatabase = server.GetDatabase(dbName);
            bool check = mongoDatabase.CollectionExists("Employees");
            EmployeesCollection = mongoDatabase.GetCollection("Employees");




            //test if server is up and running
            try
            {
               // MongoDatabase.Server.Ping();
                // Ping() method throws exception if not able to connect

            }
            catch (Exception ex)
            {
                ServerIsDown = true;
            }
        }


        private List<Employee> _employeesList = new List<Employee>();

        public IEnumerable<Employee> GetAllEmployees()
        {
            var result =
                (from e in EmployeesCollection.AsQueryable<Employee>()
                 select e);
            return result;
            
            /*//throw new NotImplementedException();
            if (ServerIsDown) return null;

            if (Convert.ToInt32(EmployeesCollection.Count()) > 0)
            {
                _employeesList.Clear();
                //var employees = EmployeesCollection.FindAs(typeof(Employee), Query.NE("FirstName", "null"));
                var employees = EmployeesCollection.FindAllAs(typeof(Employee));
                if (employees.Count() > 0)
                {
                    foreach (Employee employee in employees)
                    {
                        _employeesList.Add(employee);
                    }
                }
            }
            else
            {
                //#region add test data if DB is empty

                //EmployeesCollection.RemoveAll();
                //foreach (var employee in _testEmployeeData)
                //{
                //    _employeesList.Add(employee);

                //    Add(employee); // add data to mongo db also
                //}

                //#endregion
            }

            var result = _employeesList.AsQueryable();
            return result;*/
        }

        public Employee GetEmployeeById(string id)
        {
            //throw new NotImplementedException();
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id", "Employee Id is empty!");
            }
            var employee = (Employee)EmployeesCollection.FindOneAs(typeof(Employee), Query.EQ("_id", id));
            return employee;
        }

    /*    public Employee Add(Employee employee)
        {
            //throw new NotImplementedException();
            if (string.IsNullOrEmpty(employee.Id))
            {
                employee.Id = Guid.NewGuid().ToString();
            }
            EmployeesCollection.Save(employee);
            return employee;
        }*/

       /* public bool Update(string objectId, Employee employee)
        {
            //throw new NotImplementedException();
            UpdateBuilder updateBuilder = MongoDB.Driver.Builders.Update
                .Set("FirstName", employee.FirstName)
                .Set("LastName", employee.LastName)
                .Set("Address", employee.Address)
                .Set("ContactNo", employee.ContactNo);
            EmployeesCollection.Update(Query.EQ("_id", objectId), updateBuilder);

            return true;
        }

        public bool Delete(string objectId)
        {
            //throw new NotImplementedException();
            EmployeesCollection.Remove(Query.EQ("_id", objectId));
            return true;
        }*/
    }
}