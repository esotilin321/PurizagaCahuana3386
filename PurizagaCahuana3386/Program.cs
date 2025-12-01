using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_3386;
using PurizagaCahuana3386;

namespace PurizagaCahuana3386
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("¿Cuántos lugares desea visitar?: ");
            int n = int.Parse(Console.ReadLine());
            PC_Grafo g = new PC_Grafo(n);

            g.InsertarVertice(Console.ReadLine());
            g.LlenarMatrizManual();
            g.CrearGrafoDeLaMatriz();
            g.MostrarMatrizCompleta();
            
            Console.Write("\nIngrese el origen: ", n - 1);
            string origenNombre = Console.ReadLine();

            Console.Write("Ingrese el destino: ", n - 1);
            string destinoNombre = Console.ReadLine();
            g.Dijkstra(origenNombre, destinoNombre);
            Console.ReadKey();
        }
    }
}
