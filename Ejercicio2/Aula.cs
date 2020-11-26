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

        // Función para que me devuelva la longitud de la dimesión especificada de tablaNotas
        public int longitudDimensiónTabla(int i)
        {
            if (i == 0 || i == 1)
            {
                return tablaNotas.GetLength(i);
            }
            else
            {
                return -1;
            }
        }

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


        public string[] alumnos = { "Hugo", "Iris", "Fer", "Raul", "Marta", "Sara", "Iago", "Curro", "Javi", "Mila", "Juan", "Patricia"};
        public string this[int i]
        {
            set
            {
                alumnos[i] = value;
            }
            get
            {
                return alumnos[i];
            }
        }


        public enum asignaturas
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
        public double calcularMediaTotal()
        {
            double suma = 0;

            for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
            {
                for (int j = 0; j < this.tablaNotas.GetLength(1); j++)
                {
                    suma += this.tablaNotas[i, j];
                }
            }

            double media = suma / (this.tablaNotas.Length);
            return media;
        }


        // Función que devuelve el número del alumno dado su nombre
        // Actualmente no tiene ningún uso aunque la guardo aquí por si la necesito
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
        // Actualmente no tiene ningún uso aunque la guardo aquí por si la necesito
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
        public double calcularMediaAlumno(int numAlumno)
        {
            double suma = 0;

            for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
            {
                suma += this.tablaNotas[i, numAlumno-1];
            }

            double media = suma / this.tablaNotas.GetLength(0);
            return media;
        }


        // Función que calcula la media de todas las notas de una asignatura
        public double calcularMediaAsignatura(int numMateria)
        {
            double suma = 0;

            for (int i = 0; i < this.tablaNotas.GetLength(1); i++)
            {
            suma += this.tablaNotas[numMateria-1, i];
            }

            double media = suma / this.tablaNotas.GetLength(1);
            return media;
        }


        // Función para ver todas las notas de un alumno
        public int[] verNotasAlumno(int numAlumno)
        {
            int[] notasAlumno = new int[this.tablaNotas.GetLength(0)];
            for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
            {
                notasAlumno[i] = this.tablaNotas[i, numAlumno - 1];
            }

            return notasAlumno;
        }


        // Función para visualizar las notas de una asignatura
        public int[] verNotasAsignatura(int numMateria)
        {
            int[] notasMateria = new int[this.tablaNotas.GetLength(1)];
            for (int i = 0; i < this.tablaNotas.GetLength(1); i++)
            {
                notasMateria[i] = this.tablaNotas[numMateria - 1, i];
            }

            return notasMateria;
        }


        // Función para mostrar la nota mínima y la nota máxima de un alumno
        public int[] notaMaxMinAlumno(int numAlumno)
        {
            int[] notasAlumno = new int[4];

            for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
            {
                notasAlumno[i] = this.tablaNotas[i, numAlumno-1];
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

            int[] notas = {menor, mayor};
            return notas;
        }


        // Función para visualizar la tabla de los alumnos aprobados
        public List<int> tablaAprobados()
        {
            // Creo una colección con los nº de los alumnos que han aprobado
            List<int> aprobados = new List<int>();

            // Obtengo la info de los alumnos que han aprobado al menos una nota
            for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
            {
                for (int j = 0; j < this.tablaNotas.GetLength(1); j++)
                {
                    if (this.tablaNotas[i, j] >= 5)
                    {
                        // Si la lista de aprobados ya tiene el mismo nº de alumno, no se guardará otra vez
                        if (!aprobados.Contains(j))
                        {
                            aprobados.Add(j);
                        }
                    }
                }
            }

            return aprobados;
        }
    }
}
