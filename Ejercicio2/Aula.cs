using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Aula
    {
        private int[,] tablaNotas = new int[4, 12];

        public int this[int i, int j] 
        {
            set
            {
                tablaNotas[i, j] = value;
            }
            get 
            {
                return tablaNotas[i, j];
            }
        }


        private string[] alumnos = { "Hugo", "Iris", "Fer", "Raul", "Marta", "Sara", "Iago", "Curro", "Javi", "Mila", "Juan", "Patricia"};
        private enum asignaturas
        {
            Programacion,
            Bases,
            Sistemas,
            Redes
        }


        // Creo una función para rellenar la tabla de notas random
        public void rellenarTabla()
        {
            Random generador = new Random();

            for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
            {
                for (int j = 0; j < this.tablaNotas.GetLength(1); j++)
                {
                    this.tablaNotas[i, j] = calcularNota(generador);
                }
            }
        }


        // Creo una función para calcular la nota correspondiente según su probabilidad
        static int calcularNota(Random generador)
        {
            int probabilidad = generador.Next(1, 101);

            switch (probabilidad)
            {
                case int n when n <= 5:
                    return 0;

                case int n when n <= 10:
                    return 1;

                case int n when n <= 15:
                    return 2;

                case int n when n <= 25:
                    return 3;

                case int n when n <= 40:
                    return 4;

                case int n when n <= 55:
                    return 5;

                case int n when n <= 70:
                    return 6;

                case int n when n <= 80:
                    return 7;

                case int n when n <= 90:
                    return 8;

                case int n when n <= 95:
                    return 9;

                case int n when n <= 100:
                    return 10;

                default:
                    return 0;
            }
        }


        // Función que calcula la media de todas las notas
        public void calcularMediaTotal()
        {
            double suma = 0;

            for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
            {
                for (int j = 0; j < this.tablaNotas.GetLength(1); j++)
                {
                    suma += this.tablaNotas[i, j];
                }
            }

            double media = suma / (this.tablaNotas.GetLength(0) * this.tablaNotas.GetLength(1));
            Console.WriteLine("La media de todas las notas es : {0}", media);
            Console.WriteLine("Pulsa Enter para continuar");
            Console.ReadLine();
        }


        // Función que devuelve el número del alumno dado su nombre
        public int buscarNumAlumno(string alumno)
        {
            int numAlumno = 77;
            for (int i = 0; i < alumnos.Length; i++)
            {
                if (alumno == alumnos[i])
                {
                    numAlumno = i;
                }
            }

            return numAlumno;
        }


        // Función que devuelve el número de la materia dado su nombre
        public int buscarNumMateria(string materia)
        {
            int numMateria = 77;
            asignaturas asig;
            for (int i = 0; i < 4; i++)
            {
                asig = (asignaturas)i;

                if (asig.ToString() == materia)
                {
                    numMateria = Convert.ToInt32((asignaturas)i);
                }
            }

            return numMateria;
        }


        // Función que calcula la media de todas las notas de un alumno
        public void calcularMediaAlumno(string alumno)
        {
            try
            {
                int numAlumno = buscarNumAlumno(alumno);
                double suma = 0;

                for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
                {
                    suma += this.tablaNotas[i, numAlumno];
                }

                double media = suma / this.tablaNotas.GetLength(0);
                Console.WriteLine("La media de las notas de {0} es : {1}", alumno, media);
                Console.WriteLine("Pulsa Enter para continuar");
            }
            catch (Exception e)
            {
                Console.WriteLine("Excepcion generada : {0}", e.Message);
                Console.WriteLine("No existe ese alumno");
                Console.WriteLine("Pulsa Enter para continuar");
            }
            Console.ReadLine();
        }


        // Función que calcula la media de todas las notas de una asignatura
        public void calcularMediaAsignatura(string asignatura)
        {
            try
            {
                int numMateria = buscarNumMateria(asignatura);
                double suma = 0;

                for (int i = 0; i < this.tablaNotas.GetLength(1); i++)
                {
                    suma += this.tablaNotas[numMateria, i];
                }

                double media = suma / this.tablaNotas.GetLength(1);
                Console.WriteLine("La media de las notas de {0} es : {1}", asignatura, media);
                Console.WriteLine("Pulsa Enter para continuar");
            }
            catch (Exception e)
            {
                Console.WriteLine("Excepcion generada : {0}", e.Message);
                Console.WriteLine("No existe esa asignatura");
                Console.WriteLine("Pulsa Enter para continuar");
            }
            Console.ReadLine();
        }


        // Función para ver todas las notas de un alumno
        public void verNotasAlumno(string alumno)
        {
            try
            {
                int numAlumno = buscarNumAlumno(alumno);

                Console.WriteLine("Las notas de {0} son : ", alumno);
                for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
                {
                    Console.Write("{0}\t", this.tablaNotas[i, numAlumno]);
                }
                Console.Write("\n");
                Console.WriteLine("Pulsa enter para continuar");
            }
            catch (Exception e)
            {
                Console.WriteLine("Excepcion generada : {0}", e.Message);
                Console.WriteLine("No existe esa asignatura");
                Console.WriteLine("Pulsa Enter para continuar");
            }
            Console.ReadLine();
        }


        // Función para visualizar las notas de una asignatura
        public void verNotasAsignatura(string asignatura)
        {
            int numMateria = buscarNumMateria(asignatura);

            Console.WriteLine("Las notas de {0} son : ", asignatura);
            for (int i = 0; i < this.tablaNotas.GetLength(1); i++)
            {
                Console.Write("{0}\t", this.tablaNotas[numMateria, i]);
            }
            Console.Write("\n");
            Console.WriteLine("Pulsa enter para continuar");
            Console.ReadLine();
        }


        // Función que muestra la nota mínima y la nota máxima de un alumno
        public void notaMaxMinAlumno(string alumno)
        {
            int numAlumno = buscarNumAlumno(alumno);
            int[] notasAlumno = new int[4];

            for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
            {
                notasAlumno[i] = this.tablaNotas[i, numAlumno];
            }

            int menor = 10;
            int mayor = 0;

            for (int i = 0; i < notasAlumno.Length; i++)
            {
                if (notasAlumno[i] < menor)
                {
                    menor = notasAlumno[i];
                }

                if (notasAlumno[i] > mayor)
                {
                    mayor = notasAlumno[i];
                }
            }

            Console.WriteLine("La nota más baja de {0} es : {1}", alumno, menor);
            Console.WriteLine("La nota más alta de {0} es : {1}", alumno, mayor);
            Console.WriteLine("Pulsa Enter para continuar");
            Console.ReadLine();
        }


        // Función para visualizar la tabla de los alumnos aprobados
        public void tablaAprobados()
        {
            List<int> aprobados = new List<int>();

            for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
            {
                for (int j = 0; j < this.tablaNotas.GetLength(1); j++)
                {
                    if (this.tablaNotas[i, j] >= 5)
                    {
                        aprobados.Add(this.tablaNotas[i, j]);
                    }
                }
            }

            Console.WriteLine("Notas aprobadas : ");
            for (int i = 0; i < aprobados.Count; i++)
            {
                Console.Write("{0}\t", aprobados[i]);
            }
            Console.Write("\n");
            Console.WriteLine("Pulsa Enter para continuar");
            Console.ReadLine();
        }


        // Función que muestra toda la tabla de notas por consola
        public void verTabla()
        {
            for (int a = 0; a < 12; a++)
            {
                if (a == 0)
                {
                    Console.Write("\t\t");
                }

                Console.Write(alumnos[a] + "\t");
            }
            Console.WriteLine();

            asignaturas asig;

            for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
            {
                asig = (asignaturas)i;
                if (i == 1 || i == 3)
                {
                    Console.Write("{0}\t\t", asig);
                }
                else
                {
                    Console.Write("{0}\t", asig);
                }

                for (int j = 0; j < this.tablaNotas.GetLength(1); j++)
                {
                    Console.Write("{0}\t", tablaNotas[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
}
