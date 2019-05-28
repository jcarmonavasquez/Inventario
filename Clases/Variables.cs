using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoInventario.Clases
{
    class Variables
    {
        //string de conexion a la base de datos
        public static string conexion= "Data Source=;Initial Catalog = Inventario; User ID = Inventario; Password=qwerty123";
        //Variable de busqueda del grid
        public static string ConsultaBuscar;
        //Articulos
        public static string IdArticulo;
        public static string ArticuloDescripcion;
        public static string ArticuloFamilia;
        public static string ArticuloTipo;
        //Departamentos
        public static string IdDeptos;
        public static string DescripcionDeptos;
        //Empleados
        public static string IdEmpleados;
        public static string EmpleadosBaja;
        public static string EmpleadosNombre;
        public static string EmpleadosDepto;
        //Familias
        public static string IDFamilia;
        public static string DescripcionFamilia;
        //marcas
        public static string IDMarcas;
        public static string DescripcionMarcas;
        //proveedores
        public static string IdProveedores;
        public static string ProveedoresNombre;
        public static string ProveedoresDireccion;
        public static string ProveedoresFax;
        public static string ProveedoresCiudad;
        public static string ProveedoresRFC;
        public static string ProveedoresCURP;
        //Bienes
        public static string IdBienes;
        public static string BienesEtiqueta;
        public static string BienesSerie;
        public static string BienesOrdenCompra;
        public static string BienesFactura;
        public static string BienesTotal;
        public static string BienesProveedor;
        public static string BienesFamilia;
        public static string BienesDescripcionArticulo;
        public static string BienesEmpleado;
        public static string BienesDepartamento;
        public static string BienesObservacion;
        //Bienes Dados de Baja
        public static string IdBienesB;
        public static string BienesBMotivoBaja;
        public static string BienesBObservacion;
        public static string MotivoBaja;
        //Insercion
        public static bool ErrorB;
        public static string Total;

    }
}
