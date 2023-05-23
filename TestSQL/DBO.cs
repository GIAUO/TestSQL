using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TestSQL
{
    internal class DBO
    {
        private string m_URL;
        private string m_dbName;
        private string m_ID;
        private string m_mdp;
        private MySqlConnection m_connection;

       
        public string dbName { get { return m_dbName; } set { m_dbName = value; } }

        public DBO(string URL, string ID, string mdp, string databaseName)
        {
            m_URL = URL;
            m_ID = ID;
            m_mdp = mdp;
            m_dbName = databaseName;
            connect();
        }

        public void connect()
        {
            string connStr = "server=" + m_URL + ";user=" + m_ID + ";database=" + m_dbName + ";password=" + m_mdp + ";";
            m_connection = new MySqlConnection(connStr);
            m_connection.Open();
        }
        public void reconnect()
        {
            close();
            connect();
        }
        public void close()
        {
            m_connection.Close();
        }

        public MySqlDataReader query(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, m_connection);
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                return rdr;
            }
        }
    }
}
