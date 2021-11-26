/*diumenge novembre 28, 23:55
Esdeveniment del curs
Ejercicio con nota 3 (tema 4)

Crea un programa de C# que pueda almacenar hasta 10000 contactos (amistades, familiares, etc). Para cada contacto, debe permitir al usuario almacenar la siguiente información:

Nombre
Correo electrónico
Año de nacimiento
Aficiones
Estatura (en metros)
Comentarios


Esta versión mostrará un menú con las opciones:



1. Añadir datos de un contacto.

2. Buscar entre los contactos existentes.

3. Ver detalles de un contacto.

4. Modificar los datos de un contacto.

5. Borrar un contacto.

6. Ordenar datos.

7. Ver estadísticas.

8. Corregir errores frecuentes.

S. Salir.



Es decir, debe permitir al usuario realizar las siguientes operaciones:

1 - Añadir un nuevo contacto (al final de los datos existentes). El nombre no debe estar vacío
(si introduce un nombre vacío, se le volverá a pedir tantas veces como sea necesario).
Si se introduce una cadena vacía como respuesta al año de nacimiento, éste se guardará como 0,
y lo mismo ocurrirá con la estatura. No se debe realizar ninguna otra validación.

2 - Buscar contactos que contengan un determinado texto (búsqueda parcial,
en cualquier campo de texto, sin distinción de mayúsculas y minúsculas). 
Debe mostrar el número de registro y el nombre, en la misma línea, 
haciendo una pausa después de cada 22 líneas en pantalla.

3 - Ver todos los datos de un contacto determinado, a partir de su número de registro.
Se debe avisar (pero no volver a pedir) si el número no es válido.

4 - Modificar un registro: pedirá al usuario su número (por ejemplo, 1 para la primera ficha),
mostrará el valor anterior de cada campo (por ejemplo, dirá: "Nombre anterior: Elon Musk")
y permitirá escribir un nuevo valor para ese campo, o bien pulsar Intro para dejarlo sin modificar.
Se debe avisar al usuario (pero no volver a pedir) si introduce un número de registro incorrecto.

5 - Eliminar un registro, en la posición indicada por el usuario. Se le debe avisar (pero no volver a preguntar)
si introduce un número de registro incorrecto. Debe mostrar el registro que se va a eliminar 
y solicitar confirmación antes de la eliminación.

6 - Ordenar los datos alfabéticamente, por nombre.

7 - Ver estadísticas: mostrará la cantidad de contactos, la edad media (para cada edad supondremos que
basta con restar al año actual, 2021, el año de nacimiento) de todos nuestros contactos 
(salvo los que tengan 0 como año de nacimiento) y 
la estatura media de nuestros contactos (salvo los que tengan 0 como estatura).

8 - Corregir errores frecuentes: eliminará espacios finales, espacios iniciales y espacios duplicados en el nombre,
aficiones y comentarios de todos los registros existentes. Si alguna estatura es negativa o superior a tres metros,
se guardará un 0 en su lugar. Si algún año de nacimiento es anterior a 1850 o posterior a 2100, se guardará como 0.

S - Salir de la aplicación (como no guardamos la información en fichero, los datos se perderán).



El menú deberá repetirse hasta que el usuario escoja la opción "S" 
(que será aceptable tanto en mayúsculas como en minúsculas).

La estructura repetitiva del programa debe ser adecuada, y emplear un booleano de control. 
El fuente debe estar correctamente tabulado y resultar fácil de leer.

Debes entregar exclusivamente el fichero ".cs" (no todo el proyecto), sin comprimir, 
que deberá tener un comentario con tu nombre al principio. 
Haz que el nombre del fichero también incluya tu nombre.*/
using System;

namespace Connota3
{
    class Program
    {
         struct ficha
        {
           public string nombre;
           public string email;
           public int anyoNacimiento;
           public string aficiones;
           public float estatura;
           public string comentarios;
        }
        static void Main(string[] args)
        {
            const int ANYOACTUAL = 2021;
            ficha [] fichas = new ficha [1000];
            bool salir = false;
            char menu;
            int contadorFichas = 0,totalEdad=0, registroABuscar,edad, campoModificadoInt,
                contadorDeedadesvalidas=0,contadorDeEstaturasvalidas=0;
            float campoModificadoFloat, totalEstaturas=0;
            string aStringAnyo,aStringEstatura,textoABuscar, textoABuscarMayusculas,campoModificado,ordenDada;
             
            do
            {
                Console.WriteLine("Elige un menu de los siguientes.");
                Console.WriteLine("1. Añadir datos de un contacto.");
                Console.WriteLine("2. Buscar entre los contactos existentes.");
                Console.WriteLine("3. Ver detalles de un contacto.");
                Console.WriteLine("4. Modificar los datos de un contacto.");
                Console.WriteLine("5. Borrar un contacto.");
                Console.WriteLine("6. Ordenar datos.");
                Console.WriteLine("7. Ver estadísticas");
                Console.WriteLine("8. Corregir errores frecuentes.");
                Console.WriteLine("S. Salir.");
                menu = Convert.ToChar(Console.ReadLine());

                switch (menu)
                {
                    /* 1 - Añadir un nuevo contacto(al final de los datos existentes). El nombre no debe estar vacío(si introduce un nombre vacío,
                    * se le volverá a pedir tantas veces como sea necesario). Si se introduce una cadena vacía como respuesta al año de nacimiento,
                    * éste se guardará como 0, y lo mismo ocurrirá con la estatura.No se debe realizar ninguna otra validación.*/
                    case '1':
                        {
                            do
                            {
                                Console.WriteLine("Escribe el nombre.");
                                fichas[contadorFichas].nombre = Console.ReadLine();
                            }
                            while (fichas[contadorFichas].nombre == "");

                            Console.WriteLine("Escribe el mail.");
                            fichas[contadorFichas].email = Console.ReadLine();
                            Console.WriteLine("Escribe el año de nacimiento.");
                            aStringAnyo = Console.ReadLine();
                            if (aStringAnyo!="") 
                            {
                                fichas[contadorFichas].anyoNacimiento= Convert.ToInt32(aStringAnyo);
                            }
                            else
                            {
                                fichas[contadorFichas].anyoNacimiento = 0;
                            }
                            Console.WriteLine("Escribe las aficiones.");
                            fichas[contadorFichas].aficiones = Console.ReadLine();
                            Console.WriteLine("Escribe la estatura en metros");
                            aStringEstatura = Console.ReadLine();
                            if (aStringEstatura!= "")
                            {
                                fichas[contadorFichas].estatura = Convert.ToSingle(aStringEstatura);
                            }
                            else
                            {
                                fichas[contadorFichas].estatura = 0;
                            }
                            Console.WriteLine("Escribe los comentarios:");
                            fichas[contadorFichas].comentarios = Console.ReadLine();
                            contadorFichas++;
                            Console.WriteLine();
                        };break;//fin del menu 1.

                        /*2 - Buscar contactos que contengan un determinado texto(búsqueda parcial, 
                         * en cualquier campo de texto, sin distinción de mayúsculas y minúsculas). 
                         * Debe mostrar el número de registro y el nombre, en la misma línea,
                         * haciendo una pausa después de cada 22 líneas en pantalla.*/
                    case '2':
                        {
                            Console.WriteLine("Escribe el texto a buscar.");
                            textoABuscar= Console.ReadLine();
                            textoABuscarMayusculas = textoABuscar.ToUpper();
                            for (int i = 0; i <contadorFichas; i++)
                            {
                                fichas[i].nombre = fichas[i].nombre.ToUpper();
                                fichas[i].email = fichas[i].email.ToUpper();
                                fichas[i].aficiones = fichas[i].aficiones.ToUpper();
                                fichas[i].comentarios = fichas[i].comentarios.ToUpper();
                                if ((fichas[i].nombre).Contains(textoABuscarMayusculas))
                                {
                                    Console.WriteLine("Numero de registro: {0} Nombre: {1}",
                                        i + 1, fichas[i].nombre);
                                }
                                else if ((fichas[i].email).Contains(textoABuscarMayusculas))
                                {
                                    Console.WriteLine("Numero de registro: {0} Nombre: {1}",
                                        i + 1, fichas[i].nombre);
                                }
                                else if ((fichas[i].aficiones).Contains(textoABuscarMayusculas))
                                {
                                    Console.WriteLine("Numero de registro: {0} Nombre: {1}",
                                        i + 1, fichas[i].nombre);
                                }
                                else if ((fichas[i].comentarios).Contains(textoABuscarMayusculas))
                                {
                                    Console.WriteLine("Numero de registro: {0} Nombre: {1}",
                                        i + 1, fichas[i].nombre);
                                }
                            }
                            Console.WriteLine();
                        }
                        ; break;//fin del menu2.
                    /* 3 - Ver todos los datos de un contacto determinado, a partir de su número de registro.
                    Se debe avisar(pero no volver a pedir) si el número no es válido.*/
                    case '3':
                        {
                            Console.WriteLine("Escribe el numero de registro.");
                            registroABuscar = Convert.ToInt32(Console.ReadLine());
                            if(registroABuscar<=contadorFichas)
                            {
                                Console.WriteLine("Nombre:**{0}**", fichas[registroABuscar - 1].nombre);
                                Console.WriteLine("Email:**{0}** ", fichas[registroABuscar - 1].email);
                                Console.WriteLine("Año de nacimiento:**{0}**", fichas[registroABuscar - 1].anyoNacimiento);
                                Console.WriteLine("Aficiones:**{0}**", fichas[registroABuscar - 1].aficiones);
                                Console.WriteLine("Estatura en metros:**{0}**", fichas[registroABuscar - 1].estatura);
                                Console.WriteLine("Comentarios:**{0}**", fichas[registroABuscar - 1].comentarios);
                            }
                            else
                            {
                                Console.WriteLine("Registro incorrecto");
                            }
                            Console.WriteLine();
                        }; break;
                    /*4 - Modificar un registro: pedirá al usuario su número (por ejemplo, 1 para la primera ficha),
                    mostrará el valor anterior de cada campo (por ejemplo, dirá: "Nombre anterior: Elon Musk")
                    y permitirá escribir un nuevo valor para ese campo, o bien pulsar Intro para dejarlo sin modificar.
                    Se debe avisar al usuario (pero no volver a pedir) si introduce un número de registro incorrecto.*/
                    case '4':
                        {
                            Console.WriteLine("Escribe numero de registro a buscar.");
                            registroABuscar = Convert.ToInt32(Console.ReadLine());
                            if (registroABuscar <=contadorFichas)
                            {
                                Console.WriteLine("Nombre anterior: {0}", fichas[registroABuscar - 1].nombre);
                                Console.WriteLine("Nombre nuevo o pulsa enter");
                                campoModificado = Console.ReadLine();
                                if (campoModificado!="")
                                {
                                    fichas[registroABuscar - 1].nombre = campoModificado;
                                }

                                Console.WriteLine("Email anterior: {0} ", fichas[registroABuscar - 1].email);
                                Console.WriteLine("Email nuevo o pulsa enter");
                                campoModificado = Console.ReadLine();
                                if (campoModificado != "")
                                {
                                    fichas[registroABuscar - 1].email = campoModificado;
                                }
                                Console.WriteLine("Año de nacimiento anterior: {0}", fichas[registroABuscar - 1].anyoNacimiento);
                                Console.WriteLine("Año de nacimiento nuevo o pulsa enter");
                                campoModificado = Console.ReadLine();
                                if (campoModificado != "")
                                {
                                    fichas[registroABuscar-1].anyoNacimiento = Convert.ToInt32(campoModificado);
                                }
                                Console.WriteLine("Aficiones anteriores: {0}", fichas[registroABuscar - 1].aficiones);
                                Console.WriteLine("Aficiones nuevas o pulsa enter");
                                campoModificado = Console.ReadLine();
                                if (campoModificado != "")
                                {
                                    fichas[registroABuscar - 1].aficiones = campoModificado;
                                }
                                Console.WriteLine("Estatura en metros anterior: {0}", fichas[registroABuscar - 1].estatura);
                                Console.WriteLine("Estatura nueva o pulsa enter");
                                campoModificado = Console.ReadLine();
                                if (campoModificado != "")
                                {
                                    fichas[registroABuscar - 1].estatura = Convert.ToSingle(campoModificado);
                                }
                                Console.WriteLine("Comentarios anteriores: {0}", fichas[registroABuscar - 1].comentarios);
                                Console.WriteLine("Comentarios nuevos o pulsa enter");
                                campoModificado = Console.ReadLine();
                                if (campoModificado != "")
                                {
                                    fichas[registroABuscar - 1].comentarios = campoModificado;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Registro incorrecto");
                            }
                            Console.WriteLine();
                        };break;
                    /*5 - Eliminar un registro, en la posición indicada por el usuario. Se le debe avisar (pero no volver a preguntar)
                    si introduce un número de registro incorrecto. Debe mostrar el registro que se va a eliminar 
                    y solicitar confirmación antes de la eliminación.*/
                    case '5':
                        {
                            Console.WriteLine("Escribe numero de registro a eliminar.");
                            registroABuscar = Convert.ToInt32(Console.ReadLine());
                            if (registroABuscar < contadorFichas)
                            {
                                Console.WriteLine("El registro que se eliminara es el: {0}", registroABuscar);
                                Console.WriteLine("Si desea borrar el registro pulse ENTER ");
                                Console.WriteLine("Si desea conservar el registro pulsa N ");
                                ordenDada = Console.ReadLine();
                                if (ordenDada=="")
                                {
                                    for (int i = registroABuscar-1; i <= contadorFichas; i++)
                                    {
                                        fichas[i].nombre = fichas[i+1].nombre;
                                        fichas[i].email = fichas[i+1].email;
                                        fichas[i].anyoNacimiento = fichas[i+1].anyoNacimiento;
                                        fichas[i].aficiones = fichas[i+1].aficiones;
                                        fichas[i].estatura = fichas[i+1].estatura;
                                        fichas[i].comentarios = fichas[i+1].comentarios;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Registro incorrecto");
                            }
                            Console.WriteLine();
                        };break;
                    /*6 - Ordenar los datos alfabéticamente, por nombre.*/
                    case '6':  
                        {
                            for (int i = 0; i <contadorFichas-1; i++)
                            {
                                for (int j = 1; j < contadorFichas; j++)
                                {
                                    if (fichas[i].nombre.CompareTo(fichas[j].nombre)>0)
                                    {
                                        string auxNombre = fichas[i].nombre;
                                        fichas[i].nombre = fichas[j].nombre;
                                        fichas[j].nombre = auxNombre;

                                        string auxEmail = fichas[i].email;
                                        fichas[i].email = fichas[j].email;
                                        fichas[j].email = auxEmail;

                                        int auxAnyo = fichas[i].anyoNacimiento;
                                        fichas[i].anyoNacimiento = fichas[j].anyoNacimiento;
                                        fichas[j].anyoNacimiento = auxAnyo;

                                        string auxAficiones = fichas[i].aficiones;
                                        fichas[i].aficiones = fichas[j].aficiones;
                                        fichas[j].aficiones = auxAficiones;

                                        float auxEstatura = fichas[i].estatura;
                                        fichas[i].estatura = fichas[j].estatura;
                                        fichas[j].estatura = auxEstatura;

                                        string auxComentarios = fichas[i].comentarios;
                                        fichas[i].comentarios = fichas[j].comentarios;
                                        fichas[j].comentarios = auxComentarios;

                                    }
                                }
                            }
                            Console.WriteLine("Registros ordenados alfabeticamente!!");
                            Console.WriteLine();
                        }; break;
                    /*7 - Ver estadísticas: mostrará la cantidad de contactos, la edad media (para cada edad supondremos que
                    basta con restar al año actual, 2021, el año de nacimiento) de todos nuestros contactos 
                    (salvo los que tengan 0 como año de nacimiento) y 
                    la estatura media de nuestros contactos (salvo los que tengan 0 como estatura).
                    */
                    case '7':
                        {
                            Console.WriteLine("La cantidad de contactos totales guardados es: {0}", contadorFichas);
                            //buscar fichas con anyo 0 y crear un total
                            for (int i = 0; i <contadorFichas; i++)
                            {
                                if (fichas[i].anyoNacimiento != 0)
                                {
                                    edad = ANYOACTUAL - fichas[i].anyoNacimiento;
                                    totalEdad += edad;
                                    contadorDeedadesvalidas++;
                                }

                                if (fichas[i].estatura != 0)
                                {
                                    totalEstaturas += fichas[i].estatura;
                                    contadorDeEstaturasvalidas++;
                                }
                            }
                            Console.WriteLine("La edad media de los contactos guardados es: {0}",totalEdad/contadorDeedadesvalidas);
                            Console.WriteLine("La estatura media de los contactos guardados es: {0}",totalEstaturas/contadorDeEstaturasvalidas);
                            Console.WriteLine();
                        }
                        ; break;
                    /*8 - Corregir errores frecuentes: eliminará espacios finales, espacios iniciales y espacios duplicados en el nombre,
                    aficiones y comentarios de todos los registros existentes. Si alguna estatura es negativa o superior a tres metros,
                    se guardará un 0 en su lugar. Si algún año de nacimiento es anterior a 1850 o posterior a 2100, se guardará como 0.*/
                    case '8':
                        {

                            for (int i = 0; i <contadorFichas; i++)
                            {
                                string sin3espacios = fichas[i].nombre.Replace("   ", " ");
                                fichas[i].nombre = sin3espacios;
                                string sin2espacios = fichas[i].nombre.Replace("  ", " ");
                                fichas[i].nombre = sin2espacios;
                                fichas[i].nombre = fichas[i].nombre.TrimStart();
                                fichas[i].nombre = fichas[i].nombre.TrimEnd();

                                if ((fichas[i].estatura < 0) || ( fichas[i].estatura >= 3))
                                {
                                    fichas[i].estatura = 0;
                                }
                                if ((fichas[i].anyoNacimiento <= 1850) || (fichas[i].anyoNacimiento >= 2100))
                                {
                                    fichas[i].anyoNacimiento = 0;
                                }

                            }
                        }
                        ; break;
                    case 's':;break;
                    case 'S':
                        {
                            salir = true;
                        }
                        ; break;
                    default:;break;
                }
            }
            while (salir == false);
        }
       
    }
}
