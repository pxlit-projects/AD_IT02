using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace finah_desktop
{
    class DBconnect
    {
        private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    //Constructor
    public DBconnect()
    {
        Initialize();
    }

    //Initialize values
    private void Initialize()
    {
        server = "adit02.cloudapp.net";
        database = "finah";
        uid = "root";
        password = "Potlood123";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
		database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        connection = new MySqlConnection(connectionString);
    }

    //open connection to database
        public bool OpenConnection()
    {
         try
    {
        connection.Open();
        return true;
    }
    catch (MySqlException ex)
    {
        //When handling errors, you can your application's response based 
        //on the error number.
        //The two most common error numbers when connecting are as follows:
        //0: Cannot connect to server.
        //1045: Invalid user name and/or password.
        switch (ex.Number)
        {
            case 0:
                MessageBox.Show("Cannot connect to server.  Contact administrator");
                break;

            case 1045:
                MessageBox.Show("Invalid username/password, please try again");
                break;
        }
        return false;
    }
    }

    //Close connection
    private bool CloseConnection()
    {
         try
    {
        connection.Close();
        return true;
    }
    catch (MySqlException ex)
    {
        MessageBox.Show(ex.Message);
        return false;
    }
    }

    //Insert statement
    public void Insert()
    {
    }

    //Update statement
    public void Update()
    {
    }

    //Delete statement
    public void Delete()
    {
    }

    //Select statement
    public List <string> [] Select(String usr,String ww)
    {
         string query = "SELECT * FROM gebruikers where gb_naam="+usr+"AND w_woord="+ww;

    //Create a list to store the result
    List< string >[] list = new List< string >[3];
    list[0] = new List< string >();
    list[1] = new List< string >();
    list[2] = new List< string >();

    //Open connection
    if (this.OpenConnection() == true)
    {
        //Create Command
        MySqlCommand cmd = new MySqlCommand(query, connection);
        //Create a data reader and Execute the command
        MySqlDataReader dataReader = cmd.ExecuteReader();
        
        //Read the data and store them in the list
        while (dataReader.Read())
        {
            list[0].Add(dataReader["id"] + "");
            list[1].Add(dataReader["name"] + "");
            list[2].Add(dataReader["ww"] + "");
        }

        //close Data Reader
        dataReader.Close();

        //close Connection
        this.CloseConnection();

        //return list to be displayed
        return list;
    }
    else
    {
        return list;
    }
    }

   
  
    }
}
