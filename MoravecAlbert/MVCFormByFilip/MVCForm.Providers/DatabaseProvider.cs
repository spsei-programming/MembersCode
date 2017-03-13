using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCForm.Providers
{
    public class DatabaseProvider
    {
	    public void CreateAllergen(string name, byte number)
	    {
		    var connectionString  = ConfigurationManager.ConnectionStrings["MealsDB"].ConnectionString;

		    using (SqlConnection connection = new SqlConnection(connectionString))
		    {
			    SqlCommand cmd = new SqlCommand();

			    cmd.CommandText = $"INSERT INTO Allergen (AllergenName, Number) VALUES ('{name}', '{number}')";
				cmd.CommandType = CommandType.Text;
		    }
	    }
    }
}
