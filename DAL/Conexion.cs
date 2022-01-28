using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Librerias
using System.Data.SqlClient;

//importacion de la capa logica de negocio 
using BLL;
using System.Data;

namespace DAL
{
    public class Conexion
    {
        string cedulaOrden;
        //Para administrar la referencia de la conexion
        private SqlConnection connection;

       //Para administrar la refrencia de un comando SQL
       private SqlCommand command;

        //variable para realizar lectura de datos en SQL
        private SqlDataReader lector;

        //variable para almacenar todos los datos la conexion
        private string stringConexion;

        //variable para manejar una referencia de una dataSet
        private DataSet datos;

        //variable para adaptar los resultados de na busqueda a un dataset
        private SqlDataAdapter adaptador;

        //Constructor con parametros
        public Conexion(string str)
        {
            this.stringConexion = str;
        }

        //*****************************MATERIALES**************************//
        public void registrarMaterial(Materiales materiales)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se abre la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "[Sp_Ins_Materiales]";

                // se asigna los valores a cada parametro del procedimiento
                this.command.Parameters.AddWithValue("@nombre", materiales.nombre);
                this.command.Parameters.AddWithValue("@tipo", materiales.tipo);
                this.command.Parameters.AddWithValue("@cantidad", materiales.cantidad);
                this.command.Parameters.AddWithValue("@precio", materiales.precio);
                this.command.Parameters.AddWithValue("@proveedor", materiales.proveedor);

                //se ejecuta el comando
                this.command.ExecuteNonQuery();

                //es importante cerra conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarMateriales(Materiales materiales, int pid)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se instancia abrir la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "[Sp_Upd_Materiales]";

                // se asigna los valores a cada parametro del procedimiento
                this.command.Parameters.AddWithValue("@idMaterial", pid);
                this.command.Parameters.AddWithValue("@nombre", materiales.nombre);
                this.command.Parameters.AddWithValue("@tipo", materiales.tipo);
                this.command.Parameters.AddWithValue("@cantidad", materiales.cantidad);
                this.command.Parameters.AddWithValue("@precio", materiales.precio);
                this.command.Parameters.AddWithValue("@proveedor", materiales.proveedor);

                //se ejecuta el comando
                this.command.ExecuteNonQuery();

                //es importante cerrar conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Materiales consultarMateriales(int id)
        {
            try
            {
                Materiales temp = null;
                //se instancia la conexion
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();

                //se instancia el comando
                this.command = new SqlCommand(this.stringConexion);
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "Sp_Cns_MaterialXId";
                this.command.Parameters.AddWithValue("@idMaterial", id);

                this.lector = this.command.ExecuteReader();
                //se valida si existen datos para lerr
                if (this.lector.Read())
                {
                    //se instancia un objeto 
                    temp = new Materiales();

                    //se rellena los datos del objeto con la informacion del lector
                    temp.nombre = this.lector.GetValue(1).ToString();
                    temp.tipo = this.lector.GetValue(2).ToString();
                    temp.cantidad = Convert.ToInt32( this.lector.GetValue(3).ToString());
                    temp.precio = Convert.ToInt32( this.lector.GetValue(4).ToString());
                    temp.proveedor = this.lector.GetValue(5).ToString();
                }

                //importante cerrar la conexion
                this.connection.Close();

                //liberamos los recursos
                this.connection.Dispose();
                this.command.Dispose();
                this.lector = null;

                return temp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarMateriales(int id)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se instancia abrir la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "Sp_Del_Materiales";

                //se asigna el valor correspondiente al parametro del procedimiento almacenado
                this.command.Parameters.AddWithValue("@idMaterial", id);

                //se ejecuta el procedimiento almacenado
                this.command.ExecuteNonQuery();

                //es importante cerra conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet buscarProveedores(String nombre)
        {
            try
            {
                //se crea una instancia de la conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se intenta abrir la conexion
                this.connection.Open();

                //se crea la instancia una comando para realizar la transaccion
                this.command = new SqlCommand();

                //se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                //se indica el nombre del procedimiento almacenado
                this.command.CommandText = "[Sp_Cns_ProveedoresXNombre]";

                //se asigna el valor al parámetro del procedimiento
                this.command.Parameters.AddWithValue("@nombre", nombre);

                //se crea instancia del adaptador
                this.adaptador = new SqlDataAdapter();

                //se asigna el comando de búsqueda al adaptador
                this.adaptador.SelectCommand = this.command;

                //se crea una instancia del dataset
                this.datos = new DataSet();

                //se utiliza método fill para llenar el DataSet con los resultados de búsqueda
                this.adaptador.Fill(this.datos);

                //importante  cerrar la conexion
                this.connection.Close();

                //liberacion de recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
                this.adaptador.Dispose();

                //retornamos el dataset lleno de datos
                return this.datos;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //*****************************CLIENTES**************************//
        public void registrarCliente(Clientes clientes)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se abre la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "Sp_Ins_Clientes";

                // se asigna los valores a cada parametro del procedimiento
                this.command.Parameters.AddWithValue("@cedula", clientes.cedula);
                this.command.Parameters.AddWithValue("@nombre", clientes.nombre);
                this.command.Parameters.AddWithValue("@email", clientes.email);
                this.command.Parameters.AddWithValue("@telefono", clientes.telefono);

                //se ejecuta el comando
                this.command.ExecuteNonQuery();

                //es importante cerra conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarCliente(Clientes clientes, string pcedula)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se instancia abrir la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "Sp_Upd_Clientes";

                // se asigna los valores a cada parametro del procedimiento
                this.command.Parameters.AddWithValue("@cedula", pcedula);
                this.command.Parameters.AddWithValue("@nombre", clientes.nombre);
                this.command.Parameters.AddWithValue("@email", clientes.email);
                this.command.Parameters.AddWithValue("@telefono", clientes.telefono);

                //se ejecuta el comando
                this.command.ExecuteNonQuery();

                //es importante cerrar conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Clientes consultarCliente(string pcedula)
        {
            try
            {
                Clientes temp = null;
                //se instancia la conexion
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();

                //se instancia el comando
                this.command = new SqlCommand(this.stringConexion);
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "Sp_Cns_ClientesXCedula";
                this.command.Parameters.AddWithValue("@cedula", pcedula);

                this.lector = this.command.ExecuteReader();
                //se valida si existen datos para lerr
                if (this.lector.Read())
                {
                    //se instancia un objeto 
                    temp = new Clientes();

                    //se rellena los datos del objeto con la informacion del lector
                    temp.cedula = this.lector.GetValue(0).ToString();
                    temp.nombre = this.lector.GetValue(1).ToString();
                    temp.email = this.lector.GetValue(2).ToString();
                    temp.telefono = this.lector.GetValue(3).ToString();
                }

                //importante cerrar la conexion
                this.connection.Close();

                //liberamos los recursos
                this.connection.Dispose();
                this.command.Dispose();
                this.lector = null;

                return temp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarCliente(string pcedula)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se instancia abrir la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "Sp_Del_Clientes";

                //se asigna el valor correspondiente al parametro del procedimiento almacenado
                this.command.Parameters.AddWithValue("@cedula", pcedula);

                //se ejecuta el procedimiento almacenado
                this.command.ExecuteNonQuery();

                //es importante cerra conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //*****************************Crear ORDEN**************************//
        public void registrarCrearOrden(CrearOrden crearOrden)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se abre la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "Sp_Ins_Orden";

                // se asigna los valores a cada parametro del procedimiento
                this.command.Parameters.AddWithValue("@cedula", crearOrden.cedula);
                this.command.Parameters.AddWithValue("@fechaRegistro", crearOrden.fechaRegistro);
                this.command.Parameters.AddWithValue("@fechaEntrega", crearOrden.fechaEntrega);
                this.command.Parameters.AddWithValue("@obsProducto", crearOrden.obsProducto);

                //se ejecuta el comando
                this.command.ExecuteNonQuery();

                //es importante cerra conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarCrearOrden(CrearOrden crearOrden, string pidOrden)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se instancia abrir la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "Sp_Upd_Orden";

                // se asigna los valores a cada parametro del procedimiento
                this.command.Parameters.AddWithValue("@idOrden", pidOrden);
                this.command.Parameters.AddWithValue("@fechaEntrega", crearOrden.fechaEntrega);
                this.command.Parameters.AddWithValue("@obsProducto", crearOrden.obsProducto);

                //se ejecuta el comando
                this.command.ExecuteNonQuery();

                //es importante cerrar conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CrearOrden consultarCrearOrden(string pidOrden)
        {
            try
            {
                CrearOrden temp = null;
                //se instancia la conexion
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();

                //se instancia el comando
                this.command = new SqlCommand(this.stringConexion);
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "Sp_Cns_OrdenesXId";
                this.command.Parameters.AddWithValue("@idOrden", pidOrden);

                this.lector = this.command.ExecuteReader();
                //se valida si existen datos para lerr
                if (this.lector.Read())
                {
                    //se instancia un objeto 
                    temp = new CrearOrden();

                    //se rellena los datos del objeto con la informacion del lector
                    temp.cedula = this.lector.GetValue(1).ToString();
                    temp.fechaRegistro = Convert.ToDateTime(this.lector.GetValue(2).ToString()); 
                    temp.fechaEntrega = Convert.ToDateTime(this.lector.GetValue(3).ToString());
                    temp.obsProducto = this.lector.GetValue(4).ToString();
                }

                //importante cerrar la conexion
                this.connection.Close();

                //liberamos los recursos
                this.connection.Dispose();
                this.command.Dispose();
                this.lector = null;
                return temp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarCrearOrden(string pidOrden)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se instancia abrir la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "Sp_Del_Orden";

                //se asigna el valor correspondiente al parametro del procedimiento almacenado
                this.command.Parameters.AddWithValue("@idOrden", pidOrden);

                //se ejecuta el procedimiento almacenado
                this.command.ExecuteNonQuery();

                //es importante cerra conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet buscarCliente(String pCedula)
        {
            try
            {
                //se crea una instancia de la conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se intenta abrir la conexion
                this.connection.Open();

                //se crea la instancia una comando para realizar la transaccion
                this.command = new SqlCommand();

                //se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                //se indica el nombre del procedimiento almacenado
                this.command.CommandText = "Sp_Cns_ClientesOrdenXId";

                //se asigna el valor al parámetro del procedimiento
                this.command.Parameters.AddWithValue("@cedula", pCedula);

                //se crea instancia del adaptador
                this.adaptador = new SqlDataAdapter();

                //se asigna el comando de búsqueda al adaptador
                this.adaptador.SelectCommand = this.command;

                //se crea una instancia del dataset
                this.datos = new DataSet();

                //se utiliza método fill para llenar el DataSet con los resultados de búsqueda
                this.adaptador.Fill(this.datos);

                //importante  cerrar la conexion
                this.connection.Close();

                //liberacion de recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
                this.adaptador.Dispose();

                //retornamos el dataset lleno de datos
                return this.datos;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //*****************************Materiales ORDEN**************************//
        public DataSet buscarMaterialOrden(String id)
        {
            try
            {
                //se crea una instancia de la conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se intenta abrir la conexion
                this.connection.Open();

                //se crea la instancia una comando para realizar la transaccion
                this.command = new SqlCommand();

                //se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                //se indica el nombre del procedimiento almacenado
                this.command.CommandText = "[Sp_Cns_MaterialesXId]";

                //se asigna el valor al parámetro del procedimiento
                this.command.Parameters.AddWithValue("@idMateriales", id);

                //se crea instancia del adaptador
                this.adaptador = new SqlDataAdapter();

                //se asigna el comando de búsqueda al adaptador
                this.adaptador.SelectCommand = this.command;

                //se crea una instancia del dataset
                this.datos = new DataSet();

                //se utiliza método fill para llenar el DataSet con los resultados de búsqueda
                this.adaptador.Fill(this.datos);

                //importante  cerrar la conexion
                this.connection.Close();

                //liberacion de recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
                this.adaptador.Dispose();

                //retornamos el dataset lleno de datos
                return this.datos;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet buscarOrdenDeMateriales(String id)
        {
            try
            {
                //se crea una instancia de la conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se intenta abrir la conexion
                this.connection.Open();

                //se crea la instancia una comando para realizar la transaccion
                this.command = new SqlCommand();

                //se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                //se indica el nombre del procedimiento almacenado
                this.command.CommandText = "Sp_Cns_MaterialOrdenXId";

                //se asigna el valor al parámetro del procedimiento
                this.command.Parameters.AddWithValue("@idOrden", id);

                //se crea instancia del adaptador
                this.adaptador = new SqlDataAdapter();

                //se asigna el comando de búsqueda al adaptador
                this.adaptador.SelectCommand = this.command;

                //se crea una instancia del dataset
                this.datos = new DataSet();

                //se utiliza método fill para llenar el DataSet con los resultados de búsqueda
                this.adaptador.Fill(this.datos);

                //importante  cerrar la conexion
                this.connection.Close();

                //liberacion de recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
                this.adaptador.Dispose();

                //retornamos el dataset lleno de datos
                return this.datos;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void registrarMaterialesOrden(MaterialesOrden materialesOrden)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se abre la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "Sp_Ins_MaterialesOrden";

                // se asigna los valores a cada parametro del procedimiento
                this.command.Parameters.AddWithValue("@idOrden", materialesOrden.idOrden);
                this.command.Parameters.AddWithValue("@idMaterial", materialesOrden.idMaterial);
                this.command.Parameters.AddWithValue("@cantidad", materialesOrden.cantidad);

                //se ejecuta el comando
                this.command.ExecuteNonQuery();

                //es importante cerra conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet buscarIdOrden(String idOrden)
        {
            try
            {
                //se crea una instancia de la conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se intenta abrir la conexion
                this.connection.Open();

                //se crea la instancia una comando para realizar la transaccion
                this.command = new SqlCommand();

                //se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                //se indica el nombre del procedimiento almacenado
                this.command.CommandText = "Sp_Cns_IdOrdenXId";

                //se asigna el valor al parámetro del procedimiento
                this.command.Parameters.AddWithValue("@idOrden", idOrden);

                //se crea instancia del adaptador
                this.adaptador = new SqlDataAdapter();

                //se asigna el comando de búsqueda al adaptador
                this.adaptador.SelectCommand = this.command;

                //se crea una instancia del dataset
                this.datos = new DataSet();

                //se utiliza método fill para llenar el DataSet con los resultados de búsqueda
                this.adaptador.Fill(this.datos);

                //importante  cerrar la conexion
                this.connection.Close();

                //liberacion de recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
                this.adaptador.Dispose();

                //retornamos el dataset lleno de datos
                return this.datos;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet buscarEmpleado(String id)
        {
            try
            {
                //se crea una instancia de la conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se intenta abrir la conexion
                this.connection.Open();

                //se crea la instancia una comando para realizar la transaccion
                this.command = new SqlCommand();

                //se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                //se indica el nombre del procedimiento almacenado
                this.command.CommandText = "Sp_Cns_IdEmpleadoXId";

                //se asigna el valor al parámetro del procedimiento
                this.command.Parameters.AddWithValue("@id", id);

                //se crea instancia del adaptador
                this.adaptador = new SqlDataAdapter();

                //se asigna el comando de búsqueda al adaptador
                this.adaptador.SelectCommand = this.command;

                //se crea una instancia del dataset
                this.datos = new DataSet();

                //se utiliza método fill para llenar el DataSet con los resultados de búsqueda
                this.adaptador.Fill(this.datos);

                //importante  cerrar la conexion
                this.connection.Close();

                //liberacion de recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
                this.adaptador.Dispose();

                //retornamos el dataset lleno de datos
                return this.datos;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //*****************************Costos Indirectos**************************//
        public void registrarCostosIndirectos(CostosIndirectos costosIndirectos)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se abre la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "Sp_Ins_GastoIndirecto";

                // se asigna los valores a cada parametro del procedimiento
                this.command.Parameters.AddWithValue("@idOrden", costosIndirectos.idOrden);
                this.command.Parameters.AddWithValue("@motivo", costosIndirectos.motivo);
                this.command.Parameters.AddWithValue("@cantidad", costosIndirectos.cantidad);
                this.command.Parameters.AddWithValue("@fecha", costosIndirectos.fecha);
                this.command.Parameters.AddWithValue("@total", costosIndirectos.total);

                //se ejecuta el comando
                this.command.ExecuteNonQuery();

                //es importante cerra conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarCostosIndirectos(CostosIndirectos costosIndirectos, string pid)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se instancia abrir la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "Sp_Upd_GastoIndireto";

                // se asigna los valores a cada parametro del procedimiento
                this.command.Parameters.AddWithValue("@idOrden", costosIndirectos.idOrden);
                this.command.Parameters.AddWithValue("@idGastoIndirecto", pid);
                this.command.Parameters.AddWithValue("@motivo", costosIndirectos.motivo);
                this.command.Parameters.AddWithValue("@cantidad", costosIndirectos.cantidad);
                this.command.Parameters.AddWithValue("@fecha", costosIndirectos.fecha);
                this.command.Parameters.AddWithValue("@total", costosIndirectos.total);

                //se ejecuta el comando
                this.command.ExecuteNonQuery();

                //es importante cerrar conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CostosIndirectos consultarCostosIndirectos(string pid)
        {
            try
            {
                CostosIndirectos temp = null;
                //se instancia la conexion
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();

                //se instancia el comando
                this.command = new SqlCommand(this.stringConexion);
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "Sp_Cns_GastosIndirectosXId";
                this.command.Parameters.AddWithValue("@idGastoIndirecto", pid);

                this.lector = this.command.ExecuteReader();
                //se valida si existen datos para lerr
                if (this.lector.Read())
                {
                    //se instancia un objeto 
                    temp = new CostosIndirectos();

                    //se rellena los datos del objeto con la informacion del lector
                    temp.idOrden = Convert.ToInt32(this.lector.GetValue(1).ToString());
                    temp.idGastoIndirecto = Convert.ToInt32(this.lector.GetValue(0).ToString());
                    temp.motivo = this.lector.GetValue(2).ToString();
                    temp.cantidad = Convert.ToInt32(this.lector.GetValue(3).ToString());
                    temp.fecha = Convert.ToDateTime(this.lector.GetValue(4).ToString());
                    temp.total = Convert.ToDecimal(this.lector.GetValue(5).ToString());
                }

                //importante cerrar la conexion
                this.connection.Close();

                //liberamos los recursos
                this.connection.Dispose();
                this.command.Dispose();
                this.lector = null;
                return temp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarCostosIndirectos(string pid)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se instancia abrir la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "Sp_Del_GastoIndirecto";

                //se asigna el valor correspondiente al parametro del procedimiento almacenado
                this.command.Parameters.AddWithValue("@idGastoIndirecto", pid);

                //se ejecuta el procedimiento almacenado
                this.command.ExecuteNonQuery();

                //es importante cerra conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet buscarCostosDeOrden(String id)
        {
            try
            {
                //se crea una instancia de la conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se intenta abrir la conexion
                this.connection.Open();

                //se crea la instancia una comando para realizar la transaccion
                this.command = new SqlCommand();

                //se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                //se indica el nombre del procedimiento almacenado
                this.command.CommandText = "Sp_Cns_CostoOrdenXId";

                //se asigna el valor al parámetro del procedimiento
                this.command.Parameters.AddWithValue("@idOrden", id);

                //se crea instancia del adaptador
                this.adaptador = new SqlDataAdapter();

                //se asigna el comando de búsqueda al adaptador
                this.adaptador.SelectCommand = this.command;

                //se crea una instancia del dataset
                this.datos = new DataSet();

                //se utiliza método fill para llenar el DataSet con los resultados de búsqueda
                this.adaptador.Fill(this.datos);

                //importante  cerrar la conexion
                this.connection.Close();

                //liberacion de recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
                this.adaptador.Dispose();

                //retornamos el dataset lleno de datos
                return this.datos;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet buscarCostosIndirectos(String id)
        {
            try
            {
                //se crea una instancia de la conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se intenta abrir la conexion
                this.connection.Open();

                //se crea la instancia una comando para realizar la transaccion
                this.command = new SqlCommand();

                //se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                //se indica el nombre del procedimiento almacenado
                this.command.CommandText = "Sp_Cns_CostosXId";

                //se asigna el valor al parámetro del procedimiento
                this.command.Parameters.AddWithValue("@idGastoIndirecto", id);

                //se crea instancia del adaptador
                this.adaptador = new SqlDataAdapter();

                //se asigna el comando de búsqueda al adaptador
                this.adaptador.SelectCommand = this.command;

                //se crea una instancia del dataset
                this.datos = new DataSet();

                //se utiliza método fill para llenar el DataSet con los resultados de búsqueda
                this.adaptador.Fill(this.datos);

                //importante  cerrar la conexion
                this.connection.Close();

                //liberacion de recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
                this.adaptador.Dispose();

                //retornamos el dataset lleno de datos
                return this.datos;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //*****************************MANO DE OBRA ORDEN**************************//
        public void registrarManoObraOrden(ManoDeObraOrden manoDeObraOrden)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se abre la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "Sp_Ins_ManoObraOrden";

                // se asigna los valores a cada parametro del procedimiento
                this.command.Parameters.AddWithValue("@idOrden", manoDeObraOrden.idOrden);
                this.command.Parameters.AddWithValue("@idManoObra", manoDeObraOrden.idManoObra);
                this.command.Parameters.AddWithValue("@horas", manoDeObraOrden.horas);

                //se ejecuta el comando
                this.command.ExecuteNonQuery();

                //es importante cerra conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet buscarManoDeOrden(String id)
        {
            try
            {
                //se crea una instancia de la conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se intenta abrir la conexion
                this.connection.Open();

                //se crea la instancia una comando para realizar la transaccion
                this.command = new SqlCommand();

                //se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                //se indica el nombre del procedimiento almacenado
                this.command.CommandText = "Sp_Cns_ManoDeObraOrdenXId";

                //se asigna el valor al parámetro del procedimiento
                this.command.Parameters.AddWithValue("@idOrden", id);

                //se crea instancia del adaptador
                this.adaptador = new SqlDataAdapter();

                //se asigna el comando de búsqueda al adaptador
                this.adaptador.SelectCommand = this.command;

                //se crea una instancia del dataset
                this.datos = new DataSet();

                //se utiliza método fill para llenar el DataSet con los resultados de búsqueda
                this.adaptador.Fill(this.datos);

                //importante  cerrar la conexion
                this.connection.Close();

                //liberacion de recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
                this.adaptador.Dispose();

                //retornamos el dataset lleno de datos
                return this.datos;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //*****************************MANO DE OBRA**************************//
        public void registrarManoDeObra(ManoDeObra manoDeObra)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se abre la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "Sp_Ins_ManodeObra";

                // se asigna los valores a cada parametro del procedimiento
                this.command.Parameters.AddWithValue("@cedula", manoDeObra.cedula);
                this.command.Parameters.AddWithValue("@nombre", manoDeObra.nombre);
                this.command.Parameters.AddWithValue("@email", manoDeObra.email);
                this.command.Parameters.AddWithValue("@jornada", manoDeObra.jornada);
                this.command.Parameters.AddWithValue("@estado", manoDeObra.estado);

                //se ejecuta el comando
                this.command.ExecuteNonQuery();

                //es importante cerra conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void modificarManoDeObra(ManoDeObra manoDeObra, string id)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se instancia abrir la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "Sp_Upd_ManodeObra";

                // se asigna los valores a cada parametro del procedimiento
                this.command.Parameters.AddWithValue("@id", id);
                this.command.Parameters.AddWithValue("@cedula", manoDeObra.cedula);
                this.command.Parameters.AddWithValue("@nombre", manoDeObra.nombre);
                this.command.Parameters.AddWithValue("@email", manoDeObra.email);
                this.command.Parameters.AddWithValue("@jornada", manoDeObra.jornada);
                this.command.Parameters.AddWithValue("@estado", manoDeObra.estado);

                //se ejecuta el comando
                this.command.ExecuteNonQuery();

                //es importante cerrar conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ManoDeObra consultarManoDeObra(string idManoDeObra)
        {
            try
            {
                ManoDeObra temp = null;
                //se instancia la conexion
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();

                //se instancia el comando
                this.command = new SqlCommand(this.stringConexion);
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "Sp_Cns_ManodeObraXId";
                this.command.Parameters.AddWithValue("@id", idManoDeObra);

                this.lector = this.command.ExecuteReader();
                //se valida si existen datos para lerr
                if (this.lector.Read())
                {
                    //se instancia un objeto 
                    temp = new ManoDeObra();

                    //se rellena los datos del objeto con la informacion del lector
                    temp.id = Convert.ToInt32(this.lector.GetValue(0).ToString());
                    temp.cedula = this.lector.GetValue(1).ToString();
                    temp.nombre = this.lector.GetValue(2).ToString();
                    temp.email = this.lector.GetValue(3).ToString();
                    temp.jornada = this.lector.GetValue(4).ToString();
                    temp.estado = this.lector.GetValue(5).ToString();
                }

                //importante cerrar la conexion
                this.connection.Close();

                //liberamos los recursos
                this.connection.Dispose();
                this.command.Dispose();
                this.lector = null;
                return temp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void eliminarManoDeObra(string idManoDeObra)
        {
            try
            {
                // se instancia una conexion
                this.connection = new SqlConnection(this.stringConexion);

                //se instancia abrir la conexion
                this.connection.Open();

                //se instnacia un comando
                this.command = new SqlCommand();

                // se asigna la conexion al comando
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;

                // se indica el nombre del procedimiento a utilizar el comando
                this.command.CommandText = "Sp_Del_ManodeObra";

                //se asigna el valor correspondiente al parametro del procedimiento almacenado
                this.command.Parameters.AddWithValue("@id", idManoDeObra);

                //se ejecuta el procedimiento almacenado
                this.command.ExecuteNonQuery();

                //es importante cerra conexion
                this.connection.Close();

                // liberamos los recursos de memoria
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //*****************************HOJA DE COSTOS**************************//
        public List<Materiales> consultarTotalDeMateriales(string idOrden)
        {
            try
            {
                List<Materiales> lista = new List<Materiales>();
                Materiales temp = null;
                //se instancia la conexion
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();

                //se instancia el comando
                this.command = new SqlCommand(this.stringConexion);
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "Sp_Cns_MaterialesDeOrden";
                this.command.Parameters.AddWithValue("@idOrden", idOrden);

                this.lector = this.command.ExecuteReader();
                //se valida si existen datos para lerr
                while (this.lector.Read())
                {
                    //se instancia un objeto 
                    temp = new Materiales();

                    //se rellena los datos del objeto con la informacion del lector
                    temp.precio = Convert.ToDecimal(this.lector.GetValue(0).ToString());/*se utiliza el objeto asi para evitar sobre cargar con objetos nuevos y reutilizar los ya hechos*/
                    temp.cantidad = Convert.ToInt32(this.lector.GetValue(1).ToString());
                    temp.idMaterial = 0;
                    temp.nombre = "";
                    temp.tipo = "";
                    temp.proveedor = "";
                    lista.Add(temp);
                }

                //importante cerrar la conexion
                this.connection.Close();

                //liberamos los recursos
                this.connection.Dispose();
                this.command.Dispose();
                this.lector = null;
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ManoDeObra> consultarTotalDeManoDeObra(string idOrden)
        {
            try
            {
                List<ManoDeObra> lista = new List<ManoDeObra>();
                ManoDeObra temp = null;
                //se instancia la conexion
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();

                //se instancia el comando
                this.command = new SqlCommand(this.stringConexion);
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "Sp_Cns_ManoDeObra";
                this.command.Parameters.AddWithValue("@idOrden", idOrden);

                this.lector = this.command.ExecuteReader();
                //se valida si existen datos para lerr
                while (this.lector.Read())
                {
                    //se instancia un objeto 
                    temp = new ManoDeObra();

                    //se rellena los datos del objeto con la informacion del lector
                    temp.jornada = this.lector.GetValue(0).ToString();
                    temp.id = Convert.ToInt32(this.lector.GetValue(1).ToString()); /*se utiliza el objeto asi para evitar sobre cargar con objetos nuevos y reutilizar los ya hechos*/
                    temp.cedula = "";
                    temp.nombre = "";
                    temp.email = "";
                    temp.estado = "";
                    lista.Add(temp);
                }

                //importante cerrar la conexion
                this.connection.Close();

                //liberamos los recursos
                this.connection.Dispose();
                this.command.Dispose();
                this.lector = null;
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<CostosIndirectos> consultarTotalDeCostosIndirectos(string idOrden)
        {
            try
            {
                List<CostosIndirectos> lista = new List<CostosIndirectos>();
                CostosIndirectos temp = null;
                //se instancia la conexion
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();

                //se instancia el comando
                this.command = new SqlCommand(this.stringConexion);
                this.command.Connection = this.connection;

                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "Sp_Cns_CostosIndirectos";
                this.command.Parameters.AddWithValue("@idOrden", idOrden);

                this.lector = this.command.ExecuteReader();
                //se valida si existen datos para lerr
                while (this.lector.Read())
                {
                    //se instancia un objeto 
                    temp = new CostosIndirectos();

                    //se rellena los datos del objeto con la informacion del lector
                    temp.cantidad = Convert.ToInt32(this.lector.GetValue(0).ToString());
                    temp.total = Convert.ToDecimal(this.lector.GetValue(1).ToString()); /*se utiliza el objeto asi para evitar sobre cargar con objetos nuevos y reutilizar los ya hechos*/
                    temp.idOrden = 0;
                    temp.idGastoIndirecto = 0;
                    temp.motivo = "";
                    lista.Add(temp);
                }

                //importante cerrar la conexion
                this.connection.Close();

                //liberamos los recursos
                this.connection.Dispose();
                this.command.Dispose();
                this.lector = null;
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }//Cierre
}// Fin
