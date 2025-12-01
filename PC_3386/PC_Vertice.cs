using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_3386
{
    public class PC_Vertice
    {
        public string dato;
        public PC_Vertice sig = null;
        public PC_Arista lista_de_arista = null;
        public void InsertarArista(PC_Vertice destino, int precio)
        {
            PC_Arista nuevo = new PC_Arista();
            nuevo.destino = destino;
            nuevo.precio = precio;
            if (lista_de_arista == null)
            {
                lista_de_arista = nuevo;
            }
            else
            {
                PC_Arista temp = lista_de_arista;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = nuevo;
            }
        }
        public void MostrarAristas()
        {
            PC_Arista temp = lista_de_arista;
            int i = 1;
            while (temp != null)
            {
                Console.WriteLine("->" + i + "  " + temp.destino.dato);
                temp = temp.next;
                i++;
            }
        }
    }
}
