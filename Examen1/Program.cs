using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    class Empleado
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public decimal Salario { get; set; }

    public Empleado(string cedula, string nombre, string direccion, string telefono, decimal salario)
        {
            Cedula = cedula;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Salario = salario;
        }
    }

    class Menu
    {
        private Empleado[] empleados;
        private int contadorEmpleados;

        public Menu(int maxEmpleados)
        {
            empleados = new Empleado[maxEmpleados];
            contadorEmpleados = 0;
        }

        public void MostrarMenu()
        {
            Console.WriteLine("Menú Principal");
            Console.WriteLine("1. Agregar Empleados");
            Console.WriteLine("2. Consultar Empleados");
            Console.WriteLine("3. Modificar Empleados");
            Console.WriteLine("4. Borrar Empleados");
            Console.WriteLine("5. Inicializar Arreglos");
            Console.WriteLine("6. Reportes");
            Console.WriteLine("7. Salir");
        }

        public void AgregarEmpleado(string cedula, string nombre, string direccion, string telefono, decimal salario)
        {
            if (contadorEmpleados < empleados.Length)
            {
                empleados[contadorEmpleados] = new Empleado(cedula, nombre, direccion, telefono, salario);
                contadorEmpleados++;
                Console.WriteLine("Empleado agregado con éxito.");
            }
            else
            {
                Console.WriteLine("No se pueden agregar más empleados. El límite ha sido alcanzado.");
            }
        }

        public void ConsultarEmpleadoPorCedula(string cedula)
        {
            Empleado empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
            if (empleado != null)
            {
                Console.WriteLine($"Cedula: {empleado.Cedula}");
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Dirección: {empleado.Direccion}");
                Console.WriteLine($"Teléfono: {empleado.Telefono}");
                Console.WriteLine($"Salario: {empleado.Salario}");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void ModificarEmpleadoPorCedula(string cedula, string nombre, string direccion, string telefono, decimal salario)
        {
            Empleado empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
            if (empleado != null)
            {
                empleado.Nombre = nombre;
                empleado.Direccion = direccion;
                empleado.Telefono = telefono;
                empleado.Salario = salario;
                Console.WriteLine("Empleado modificado con éxito.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void BorrarEmpleadoPorCedula(string cedula)
        {
            Empleado empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
            if (empleado != null)
            {
                empleados = empleados.Where(e => e.Cedula != cedula).ToArray();
                contadorEmpleados--;
                Console.WriteLine("Empleado eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void InicializarArreglos()
        {
            empleados = new Empleado[empleados.Length];
            contadorEmpleados = 0;
            Console.WriteLine("Arreglos inicializados.");
        }

        public void MostrarReportes()
        {
            Console.WriteLine("Menú de Reportes");
            Console.WriteLine("1. Consultar empleados con número de cédula");
            Console.WriteLine("2. Listar todos los empleados ordenados por nombre");
            Console.WriteLine("3. Calcular y mostrar el promedio de los salarios");
            Console.WriteLine("4. Calcular y mostrar el salario más alto y el más bajo");
            Console.WriteLine("5. Volver al Menú Principal");
        }

        public void ConsultarEmpleadosPorCedula(string cedula)
        {
            Empleado empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
            if (empleado != null)
            {
                Console.WriteLine($"Cedula: {empleado.Cedula}");
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Dirección: {empleado.Direccion}");
                Console.WriteLine($"Teléfono: {empleado.Telefono}");
                Console.WriteLine($"Salario: {empleado.Salario}");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void ListarEmpleadosOrdenadosPorNombre()
        {
            var empleadosOrdenados = empleados.OrderBy(e => e.Nombre);
            foreach (var empleado in empleadosOrdenados)
            {
                Console.WriteLine($"Cedula: {empleado.Cedula}, Nombre: {empleado.Nombre}");
            }
        }

        public void CalcularPromedioSalarios()
        {
            if (contadorEmpleados > 0)
            {
                decimal sumaSalarios = empleados.Sum(e => e.Salario);
                decimal promedioSalarios = sumaSalarios / contadorEmpleados;
                Console.WriteLine($"Promedio de salarios: {promedioSalarios}");
            }
            else
            {
                Console.WriteLine("No hay empleados registrados.");
            }
        }

        public void CalcularSalarioMasAltoYBajo()
        {
            if (contadorEmpleados > 0)
            {
                decimal salarioMasAlto = empleados.Max(e => e.Salario);
                decimal salarioMasBajo = empleados.Min(e => e.Salario);
                Console.WriteLine($"Salario más alto: {salarioMasAlto}");
                Console.WriteLine($"Salario más bajo: {salarioMasBajo}");
            }
            else
            {
                Console.WriteLine("No hay empleados registrados.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu(100);
            int opcion;

            do
            {
                menu.MostrarMenu();
                Console.Write("Ingrese una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Cedula: ");
                        string cedula = Console.ReadLine();
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Dirección: ");
                        string direccion = Console.ReadLine();
                        Console.Write("Teléfono: ");
                        string telefono = Console.ReadLine();
                        Console.Write("Salario: ");
                        decimal salario = decimal.Parse(Console.ReadLine());

                        menu.AgregarEmpleado(cedula, nombre, direccion, telefono, salario);
                        break;

                    case 2:
                        Console.Write("Ingrese la cédula del empleado a consultar: ");
                        string cedulaConsulta = Console.ReadLine();
                        menu.ConsultarEmpleadoPorCedula(cedulaConsulta);
                        break;

                    case 3:
                        Console.Write("Ingrese la cédula del empleado a modificar: ");
                        string cedulaModificacion = Console.ReadLine();
                        Console.Write("Nombre: ");
                        string nombreModificacion = Console.ReadLine();
                        Console.Write("Dirección: ");
                        string direccionModificacion = Console.ReadLine();
                        Console.Write("Teléfono: ");
                        string telefonoModificacion = Console.ReadLine();
                        Console.Write("Salario: ");
                        decimal salarioModificacion = decimal.Parse(Console.ReadLine());

                        menu.ModificarEmpleadoPorCedula(cedulaModificacion, nombreModificacion, direccionModificacion, telefonoModificacion, salarioModificacion);
                        break;

                    case 4:
                        Console.Write("Ingrese la cédula del empleado a eliminar: ");
                        string cedulaBorrado = Console.ReadLine();
                        menu.BorrarEmpleadoPorCedula(cedulaBorrado);
                        break;

                    case 5:
                        menu.InicializarArreglos();
                        break;

                    case 6:
                        int opcionReportes;
                        do
                        {
                            menu.MostrarReportes();
                            Console.Write("Ingrese una opción de reporte: ");
                            opcionReportes = int.Parse(Console.ReadLine());

                            switch (opcionReportes)
                            {
                                case 1:
                                    Console.Write("Ingrese la cédula del empleado a consultar: ");
                                    string cedulaReporte = Console.ReadLine();
                                    menu.ConsultarEmpleadosPorCedula(cedulaReporte);
                                    break;

                                case 2:
                                    menu.ListarEmpleadosOrdenadosPorNombre();
                                    break;

                                case 3:
                                    menu.CalcularPromedioSalarios();
                                    break;

                                case 4:
                                    menu.CalcularSalarioMasAltoYBajo();
                                    break;
                            }
                        } while (opcionReportes != 5);
                        break;

                }
            } while (opcion != 7);
        }
    }
}
