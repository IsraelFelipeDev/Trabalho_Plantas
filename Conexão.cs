using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Plantas
{
    internal class Conexão
    {
        private const string servidor = "localhost";
        private const string banco = "db_plantas";
        private const string usuario = "root";
       //private const string senha = "13042501@If";

        static public string ServidorBanco = $"Server = {servidor}; Database = {banco}; user id = {usuario}"; //Password = {senha}";
    }
}
