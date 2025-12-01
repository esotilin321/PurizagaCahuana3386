using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_3386
{
    public class PC_Grafo
    {
        public PC_Vertice lista_primero = null;
        public int[,] ma;
        public int CantidadVertices;
        public PC_Vertice[] Vertices;
        private const int infinito = 99999999;
        public PC_Grafo(int Camino)
        {
            CantidadVertices = Camino;
            ma = new int[Camino, Camino];
            Vertices = new PC_Vertice[Camino];
            for (int i = 0; i < Camino; i++)
            {
                Console.Write("Ingrese ubicación ");
                string Lugar = Console.ReadLine();
                InsertarVertice(Lugar);
            }
            PC_Vertice temp = lista_primero;
            for (int i = 0; i < Camino; i++)
            {
                Vertices[i] = temp;
                temp = temp.sig;
            }
        }
        public void CrearGrafoDeLaMatriz()
        {
            for (int i = 0; i < CantidadVertices; i++)
            {
                for (int j = 0; j < CantidadVertices; j++)
                {
                    if (ma[i, j] > 0)
                    {
                        Vertices[i].InsertarArista(Vertices[j], ma[i, j]);
                    }
                }
            }
        }
        public void InsertarVertice(string v)
        {
            PC_Vertice nuevo = new PC_Vertice();
            nuevo.dato = v;
            if (lista_primero == null)
            {
                lista_primero = nuevo;
            }
            else
            {
                PC_Vertice temp = lista_primero;
                while (temp.sig != null)
                {
                    temp = temp.sig;
                }
                temp.sig = nuevo;
            }
        }
        public void LlenarMatrizManual()
        {
            PC_Vertice fila = lista_primero;
            for (int i = 0; i < CantidadVertices; i++)
            {
                PC_Vertice columna = lista_primero;
                for (int j = 0; j < CantidadVertices; j++)
                {
                    if (i == j)
                    {
                        ma[i, j] = 0;
                    }
                    else if (j > i)
                    {
                        Console.Write($"Costo entre {fila.dato} y {columna.dato} (si no hay camino escriba 0): ");
                        int valor = int.Parse(Console.ReadLine());
                        if (valor == 0)
                        {
                            valor = infinito;
                        }
                        ma[i, j] = valor;
                        ma[j, i] = valor;
                    }
                    columna = columna.sig;
                }

                fila = fila.sig;
            }
        }

        public void MostrarMatrizCompleta()
        {
            if (lista_primero == null)
            {
                Console.WriteLine("La lista de vértices está vacía.");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\t"); 
            PC_Vertice encabezado = lista_primero;
            while (encabezado != null)
            {
                Console.Write(encabezado.dato + "\t");
                encabezado = encabezado.sig;
            }
            Console.WriteLine();
            PC_Vertice fila = lista_primero;
            for (int i = 0; i < ma.GetLength(0); i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(fila.dato + "\t");
                Console.ForegroundColor = ConsoleColor.Cyan;
                for (int j = 0; j < ma.GetLength(1); j++)
                {
                    Console.Write(ma[i, j] + "\t");
                }
                Console.WriteLine();

                fila = fila.sig;
            }
        }
        public void Recorrer(PC_Vertice v)
        {
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Vertice actual: " + v.dato);
            Console.WriteLine("Rutas: ");
            v.MostrarAristas();
            int op;
            Console.WriteLine("0-> salir");
            Console.Write("Ingrese un opcion: ");
            op = int.Parse(Console.ReadLine());

            if (op != 0)
            {
                PC_Arista temp = v.lista_de_arista;
                for (int i = 0; i < (op - 1); i++)
                {
                    temp = temp.next;
                }
                Recorrer(temp.destino);
            }

            if (op == 0) Console.WriteLine("Saliendo....");
        }
        public void Dijkstra(string origen, string destino)
        {
            int inicio = ObtenerIndice(origen);
            int fin = ObtenerIndice(destino);
            if (inicio == -1 || fin == -1)
            {
                Console.WriteLine("Alguno de los vértices no existe.");
                return;
            }
            int[] dist = new int[CantidadVertices];
            bool[] visitado = new bool[CantidadVertices];
            int[] previo = new int[CantidadVertices];
            for (int i = 0; i < CantidadVertices; i++)
            {
                dist[i] = infinito;
                visitado[i] = false;
                previo[i] = -1;
            }
            dist[inicio] = 0;
            for (int i = 0; i < CantidadVertices - 1; i++)
            {
                int u = DistanciaBarata(dist, visitado);
                visitado[u] = true;
                for (int v = 0; v < CantidadVertices; v++)
                {
                    if (!visitado[v] &&
                        ma[u, v] > 0 &&
                        dist[u] + ma[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + ma[u, v];
                        previo[v] = u;
                    }
                }
            }
            MostrarCaminos(previo, inicio, fin, dist[fin]);
        }
        public int ObtenerIndice(string nombre)
        {
            for (int i = 0; i < CantidadVertices; i++)
            {
                if (Vertices[i].dato == nombre)
                {
                    return i;
                }
            }
            return 0;
        }
        private int DistanciaBarata(int[] dist, bool[] visitado)
        {
            int min = int.MaxValue;
            int idx = -1;

            for (int i = 0; i < CantidadVertices; i++)
            {
                if (!visitado[i] && dist[i] < min)
                {
                    min = dist[i];
                    idx = i;
                }
            }
            return idx;
        }

        private void MostrarCaminos(int[] previo, int inicio, int fin, int Precio)
        {
            if (Precio >= infinito)
            {
                Console.WriteLine("No existe camino entre esos vértices.");
                return;
            }
            List<int> camino = new List<int>();
            int actual = fin;
            while (actual != -1)
            {
                camino.Add(actual);
                actual = previo[actual];
            }
            camino.Reverse();
            Console.WriteLine("\nCamino más corto:");
            for (int i = 0; i < camino.Count; i++)
            {
                Console.Write(Vertices[camino[i]].dato);
                if (i < camino.Count - 1)
                    Console.Write(" -> ");
            }
            Console.WriteLine($"\nCosto total: {Precio}");
        }
    }
}

