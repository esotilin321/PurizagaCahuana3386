using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_3386
{
//    public class PC_ListaEnlazadaSimple
//    {

//        public PC_Vertice PrimerVertice = null;
//        public int cantidadVisitados = 0;
//        public void AgregarVisitado(PC_Vertice v)
//        {
//            PC_Vertice nuevoVertice = new PC_Vertice();
//            nuevoVertice.dato = v.dato;
//            nuevoVertice.lista_de_arista = v.lista_de_arista;
//            if (PrimerVertice == null)
//            {
//                PrimerVertice = nuevoVertice;
//            }
//            else
//            {
//                PC_Vertice temp = PrimerVertice;
//                while (temp.sig != null)
//                {
//                    temp = temp.sig;
//                }
//                temp.sig = nuevoVertice;
//            }
//            cantidadVisitados++;
//        }
//        public bool buscarVisitados(PC_Vertice v)
//        {
//            PC_Vertice temp = PrimerVertice;
//            while (temp != null)
//            {
//                if (temp.dato == v.dato)
//                {
//                    return true;
//                }
//                temp = temp.sig;
//            }
//            return false;
//        }
//    }
//    public class PC_ListaSimpleDistancias
//    {
//        public class NodoDistancia
//        {
//            public PC_Vertice vertice;
//            public int costo;
//            public PC_Vertice Previo;
//            public NodoDistancia siguiente = null;
//        }

//        public NodoDistancia PrimerNodo = null;
//        public int cantidadnodos = 0;
//        public void AgregarDistancias(PC_Vertice v, int costo, PC_Vertice previo) //insertar Ls
//        {
//            NodoDistancia nuevoNodo = new NodoDistancia();
//            nuevoNodo.vertice = v;
//            nuevoNodo.costo = costo;
//            nuevoNodo.Previo = previo;
//            if (PrimerNodo == null)
//            {
//                PrimerNodo = nuevoNodo;
//            }
//            else
//            {
//                NodoDistancia temp = PrimerNodo;
//                while (temp.siguiente != null)
//                {
//                    temp = temp.siguiente;
//                }
//                temp.siguiente = nuevoNodo;
//            }
//            cantidadnodos++;//faltan determinar sus distancias
//        }
//        public NodoDistancia obtenerNodo(PC_Vertice v) //Encontrar buscar
//        {
//            NodoDistancia temp = PrimerNodo;
//            while (temp != null)
//            {
//                if (temp.vertice == v) //encontre, ya fue visitado!
//                {
//                    return temp;
//                }
//                temp = temp.siguiente;
//            }
//            return null;
//        }
//    }
}
