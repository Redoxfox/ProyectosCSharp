using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBB
{
    class CnodoBB
    {
        private int casilla;
        private int col;
        private int row;
        private string valueCasilla;

        private CnodoBB izq;
        private CnodoBB der;

        public int Casilla
        {
            get => casilla;
            set => casilla = value;
        }

        public int Col
        {
            get => col;
            set => col = value;
        }

        public int Row
        {
            get => row;
            set => row = value;
        }

        public string Vcasilla
        {
            get => valueCasilla;
            set => valueCasilla = value;
        }

        internal CnodoBB Izq
        {
            get => izq;
            set => izq = value;
        }

        internal CnodoBB Der
        {
            get => der;
            set => der = value;
        }

        public CnodoBB()
        {
            casilla = 0;
            col = 0;
            row = 0;
            izq = null;
            der = null;
        }
    }
}
