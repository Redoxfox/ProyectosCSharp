using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBB
{
    class ArbolBB
    {
        private CnodoBB raiz;
        private CnodoBB trabajo;

        private int i = 0;

        public ArbolBB()
        {
            raiz = null;
        }

        internal CnodoBB Raiz
        {
            get => raiz;
            set => raiz = value;
        }


        public CnodoBB insert(int pcasilla, int pcol, int prow, string valueCasilla, CnodoBB pNodo)
        {
            CnodoBB temp = null;
            if (pNodo == null)
            {
                temp = new CnodoBB();
                temp.Casilla = pcasilla;
                temp.Col = pcol;
                temp.Row = prow;
                temp.Vcasilla = valueCasilla;

                return temp;
            }

            if (pcasilla < pNodo.Casilla)
            {
                pNodo.Izq = insert(pcasilla, pcol, prow, valueCasilla, pNodo.Izq);
            }

            if (pcasilla > pNodo.Casilla)
            {
                pNodo.Der = insert(pcasilla, pcol, prow, valueCasilla, pNodo.Der);
            }

            return pNodo;

        }

        public void tranversa(CnodoBB pNodo)
        {
            if (pNodo == null)
            {
                return;
            }

            for (int n = 0; n < 1; n++)
            {
                Console.Write(" ");
            }

            Console.WriteLine(pNodo.Casilla);

            if (pNodo.Izq != null)
            {
                i++;
                Console.Write("I ");
                tranversa(pNodo.Izq);
                i--;
            }

            if (pNodo.Der != null)
            {
                i++;
                Console.Write("D ");
                tranversa(pNodo.Der);
                i--;
            }
        }
    }
}
