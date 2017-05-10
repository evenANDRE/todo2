using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using todo2.Models;
using System.Diagnostics;

namespace todo2
{

    //klasse som tar seg av alle spørringer mot DB
    public class MyMySql
    {
        //connection string, juster denne etter behov
        private string connectionString = "server=localhost;port=3306;uid=todouser;pwd=todo;database=todo;";
        private MySqlConnection con;

        public MyMySql()
        {
            con = new MySqlConnection(connectionString);
        }
        
        //setter inn person
        public long InsertPerson(Person p)
        {
            long retur = 0;
            try
            {
                con.Open(); 
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `user`(`id`, `navn`, `epost`, `tlfnr`) VALUES( NULL, @navn, @epost, @tlfnr)");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@navn", p.navn);
                cmd.Parameters.AddWithValue("@epost", p.epost);
                cmd.Parameters.AddWithValue("@tlfnr", p.tlfnr);

                cmd.ExecuteNonQuery();
                retur = cmd.LastInsertedId;
                con.Close();
            }
            catch(MySqlException ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return retur;
        }

        //setter inn todo oppgave
        public void InsertItem(Item i)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `item`(`id`,`userId`,`tittel`,`beskrivelse`,`type`,`produkt`) VALUES(NULL, @userId, @tittel, @beskr, @type, @produkt)");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@userId", i.personId);
                cmd.Parameters.AddWithValue("@tittel", i.Tittel);
                cmd.Parameters.AddWithValue("@beskr", i.Beskrivelse);
                cmd.Parameters.AddWithValue("@type", i.Type);
                cmd.Parameters.AddWithValue("@produkt", i.Produkt);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        //henter alle brukerene
        public List<Person> SelectAllPersons()
        {
            List<Person> persons = new List<Person>();
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT *, (SELECT COUNT(*) FROM item WHERE userId=user.id) as count FROM user", con);
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Person p = new Person();
                    p.id = Convert.ToInt32(rdr["id"]);
                    p.navn = rdr["navn"].ToString();
                    p.epost = rdr["epost"].ToString();
                    p.tlfnr = Convert.ToInt32(rdr["tlfnr"]);
                    p.count = Convert.ToInt32(rdr["count"]);

                    persons.Add(p);
                }
                con.Close();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return persons;
        }        

        //henter alle oppgavene til en bruker
        public List<Item> SelectAllItemsFromPerson(int personId)
        {
            List<Item> items = new List<Item>();

            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM item WHERE userId=@id", con);
                con.Open();
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", personId);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int row = 0;
                while (rdr.Read())
                {

                    Item i = new Item();
                    i.id = Convert.ToInt32(rdr["id"]);
                    i.personId = Convert.ToInt32(rdr["userId"]);
                    i.Number = ++row;
                    i.Tittel = rdr["tittel"].ToString();
                    i.Beskrivelse = rdr["beskrivelse"].ToString();
                    i.Produkt = rdr["produkt"].ToString();
                    i.Type = rdr["type"].ToString();
                    items.Add(i);
                }
                con.Close();
            }
            catch (MySqlException ex) { Debug.WriteLine(ex.Message); }        

            return items;
        }

        //henter info on en person fra id
        public Person SelectPersonFromId(int id)
        {
            Person p = new Person();

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE id=@id", con);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", id);
                
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    p.id = Convert.ToInt32(rdr["id"]);
                    p.navn = rdr["navn"].ToString();
                    p.epost = rdr["epost"].ToString();
                    p.tlfnr = Convert.ToInt32(rdr["tlfnr"]);
                }
                con.Close();

            }
            catch (MySqlException ex) { Debug.WriteLine(ex.Message); }

            return p;
        }    

    }
}