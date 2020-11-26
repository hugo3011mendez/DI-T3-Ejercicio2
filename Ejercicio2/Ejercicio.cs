﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Ejercicio
    {
        static void Main(string[] args)
        {
            Aula aula = new Aula();
            aula.rellenarTabla();

            bool repetir = true;
            while (repetir)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1 - Calcular la media de notas de toda la tabla");
                Console.WriteLine("2 - Media de un alumno");
                Console.WriteLine("3 - Media de una asignatura");
                Console.WriteLine("4 - Visualizar notas de un alumno");
                Console.WriteLine("5 - Visualizar notas de una asignatura");
                Console.WriteLine("6 - Nota máxima y mínima de un alumno");
                Console.WriteLine("7 - Tabla solo de aprobados");
                Console.WriteLine("8 - Visualizar tabla completa");
                Console.WriteLine("9 - Salir");
                Console.WriteLine();
                Console.WriteLine("Qué quieres hacer?");
                try
                {
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    int alumno, materia;

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("La media de todas las notas es : {0:N2}", aula.calcularMediaTotal());
                            Console.WriteLine();
                            Console.WriteLine("Pulsa Enter para continuar");
                            Console.ReadLine();
                            break;

                        case 2:
                            Console.WriteLine("Introduce el índice del alumno sobre el que quieres ver la media : ");
                            alumno = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("La media de las notas de {0} es : {1:N2}", aula[alumno-1], aula.calcularMediaAlumno(alumno));
                            Console.WriteLine();
                            Console.WriteLine("Pulsa Enter para continuar");
                            Console.ReadLine();
                            break;

                        case 3:
                            Console.WriteLine("Introduce el índice de la materia sobre la que quieres ver la media : ");
                            materia = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("La media de las notas es : {0:N2}", aula.calcularMediaAsignatura(materia));
                            Console.WriteLine();
                            Console.WriteLine("Pulsa Enter para continuar");
                            Console.ReadLine();
                            break;

                        case 4:
                            Console.WriteLine("Introduce el índice del alumno sobre el que quieres sus notas : ");
                            alumno = Convert.ToInt32(Console.ReadLine());
                            int[] notasAlumno = aula.verNotasAlumno(alumno);

                            Console.WriteLine("Las notas de {0} son : ", aula[alumno - 1]);
                            for (int i = 0; i < notasAlumno.Length; i++)
                            {
                                Console.Write("{0}\t", notasAlumno[i]);
                            }
                            Console.Write("\n");
                            Console.WriteLine();
                            Console.WriteLine("Pulsa enter para continuar");
                            Console.ReadLine();
                            break;

                        case 5:
                            Console.WriteLine("Introduce el índice de la materia sobre la que quieres ver sus notas : ");
                            materia = Convert.ToInt32(Console.ReadLine());
                            int[] notasMateria = aula.verNotasAsignatura(materia);

                            Console.WriteLine("Las notas son : ");
                            for (int i = 0; i < notasMateria.Length; i++)
                            {
                                Console.Write("{0} :\t", aula[i]);
                                Console.Write("{0}\n", notasMateria[i]);
                            }
                            Console.WriteLine();
                            Console.WriteLine("Pulsa enter para continuar");
                            Console.ReadLine();
                            break;

                        case 6:
                            Console.WriteLine("Introduce el índice del alumno sobre el que quieres ver la nota más baja y la más alta : ");
                            alumno = Convert.ToInt32(Console.ReadLine());
                            int[] notaMinMax = aula.notaMaxMinAlumno(alumno);
                            Console.WriteLine("La nota más baja de {0} es : {1}", aula[alumno - 1], notaMinMax[0]);
                            Console.WriteLine("La nota más alta de {0} es : {1}", aula[alumno - 1], notaMinMax[1]);
                            Console.WriteLine();
                            Console.WriteLine("Pulsa Enter para continuar");
                            Console.ReadLine();
                            break;

                        case 7:
                            List<int> aprobados = aula.tablaAprobados();
                            // Muestro todas las notas de los alumnos que han aprobado al menos una
                            Console.WriteLine("Notas aprobadas : ");
                            for (int k = 0; k < aprobados.Count; k++)
                            {
                                notasAlumno = aula.verNotasAlumno(aprobados[k]+1);

                                Console.WriteLine("Las notas de {0} son : ", aula[aprobados[k]]);
                                for (int i = 0; i < notasAlumno.Length; i++)
                                {
                                    Console.Write("{0}\t", notasAlumno[i]);
                                }
                                Console.Write("\n");
                            }
                            Console.WriteLine();
                            Console.WriteLine("Pulsa Enter para continuar");
                            Console.ReadLine();
                            break;

                        case 8:

                            for (int a = 0; a < 12; a++)
                            {
                                if (a == 0)
                                {
                                    Console.Write("\t\t");
                                }

                                Console.Write(aula[a] + "\t");
                            }
                            Console.WriteLine();

                            Aula.asignaturas asig;
                            for (int i = 0; i < aula.longitudDimensiónTabla(0); i++)
                            {
                                asig = (Aula.asignaturas)i;
                                if (i == 1 || i == 3)
                                {
                                    Console.Write("{0}\t\t", asig);
                                }
                                else
                                {
                                    Console.Write("{0}\t", asig);
                                }

                                for (int j = 0; j < aula.longitudDimensiónTabla(1); j++)
                                {
                                    Console.Write("{0}\t", aula[i, j]);
                                }
                                Console.Write("\n");
                            }

                            break;

                        case 9:
                            repetir = false;
                            Console.WriteLine("Hasta luego!");
                            break;

                        default:
                            Console.WriteLine("No existe esa opción, repite");
                            break;
                    }
                }
                catch (Exception e)
                {
                    if (e is OverflowException || e is FormatException || e is NullReferenceException || e is IndexOutOfRangeException)
                    {
                        Console.WriteLine("Ha ocurrido un error en escribir el dato, asegúrate de que lo escribes bien");
                    }
                }
            }

        }
    }
}
