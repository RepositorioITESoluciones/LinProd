using System;
using System.Collections.Generic;
using System.Web.Services;
using LinPro.Entidades;
using LinPro.Negocio;
using LinPro.Datos;
using System.Data;




/// <summary>
/// Summary description for MyServiceClass
/// </summary>
/// 
[System.Web.Script.Services.ScriptService]

public class WSLinPro : System.Web.Services.WebService
{
    public WSLinPro() { }
    readonly NegocioDatosEmpresariales metodosNegocioDatosEmpresariales = new NegocioDatosEmpresariales();
    readonly NegocioGirosEmpresariales metodosNegocioGE = new NegocioGirosEmpresariales();
    readonly NegocioTipoAlmacen metodosNegocioTipoAlmacen = new NegocioTipoAlmacen();
    readonly NegocioAlmacen metodosNegocioAlmacen = new NegocioAlmacen();
    readonly NegocioPuestos metodosNegocioPuestos = new NegocioPuestos();
    readonly NegocioModeloPlacas metodosModeloPlacas = new NegocioModeloPlacas();
    readonly NegocioPlacas metodosPlacas = new NegocioPlacas();
    readonly DatosMaquinariaDispositivosMedicion metodosMaquinariaDispositivosMedicion = new DatosMaquinariaDispositivosMedicion();
    readonly NegocioCrud metodosNegocio = new NegocioCrud();
    readonly NegocioCalculoProduccion metodosCalculoProduccion = new NegocioCalculoProduccion();

    #region EjemploCrud
    readonly NegocioMaquinariaDispositivoMedicion metodosNegocioMaquinariaDispositivoMedicion = new NegocioMaquinariaDispositivoMedicion();
    
    [WebMethod]
    public EntidadCrud LlenaTabla()
    {
        EntidadCrud listcampos;
        listcampos = metodosNegocio.LlenaTabla();
        return listcampos;

    }

    [WebMethod]
    public bool insertaWs(string nombre, string apellido, int edad, string email,int area,string fecha)
    {


        CamposCrud campos = new CamposCrud();

        campos.nombre = nombre;
        campos.apellidos = apellido;
        campos.edad = edad;
        campos.email = email;
        campos.idArea = area;
        campos.fecha = Convert.ToDateTime(fecha.ToString());



        return metodosNegocio.insertar(campos);

    }
    [WebMethod]
    public bool ActualisarWs(int idUsuario, string nombre, string apellido, int edad, string email)
    {


        CamposCrud campos = new CamposCrud();
        campos.idUsuario = idUsuario;
        campos.nombre = nombre;
        campos.apellidos = apellido;
        campos.edad = edad;
        campos.email = email;



        return metodosNegocio.actualisar(campos);

    }
    [WebMethod]
    public bool eliminarWs(int idUsuario)
    {


        CamposCrud campos = new CamposCrud();
        campos.idUsuario = idUsuario;




        return metodosNegocio.eliminar(campos);

    }

    [WebMethod]
    public Area LlenaComboWS()
    {
        Area listcampos;
        listcampos = metodosNegocio.LlenacomboNeg();
        return listcampos;

    }


    #endregion


    #region Sucursales
    readonly NegocioSucursal metodosSucursal = new NegocioSucursal();
    [WebMethod]
    public Sucursal LlenaTablaSucursales()
    {
        Sucursal listcampos;
        listcampos = metodosSucursal.LlenaTablaSucursales();
        return listcampos;

    }
    [WebMethod]
    public bool ActualizarSucursal(string nombre, int idEmpresa, string RS, int TipoPer, string RFC, string Calle, string NumExt, string NumInt, int ComboEstado, int ComboCP, int idSucursal)
    {

        if (NumInt == null)
        {
            NumInt = "Sin Numero Interior";
        }

        CamposSucursal campos = new CamposSucursal();
        campos.DatosFiscales = new CamposDatosFiscales();
        campos.DatosFiscales.TipoPersona = new CamposTipoPersona();
        campos.DatosFiscales.Estado = new CamposEstado();


        campos.nombre = nombre;
        campos.idEmpresa = idEmpresa;
        campos.DatosFiscales.RazonSocial = RS;
        campos.DatosFiscales.TipoPersona.IdTipoPersona = TipoPer;
        campos.DatosFiscales.RFC = RFC;
        campos.DatosFiscales.Calle = Calle;
        campos.DatosFiscales.NumeroExterior = NumExt;

        campos.DatosFiscales.NumeroInterior = NumInt;
        campos.DatosFiscales.Estado.idEstado = ComboEstado;
        campos.DatosFiscales.C_CP = ComboCP;
        campos.idSucursal = idSucursal;

        return metodosSucursal.actualizarSucursalNegocio(campos);

    }
    [WebMethod]
    public bool EliminarSucursal(int idSucursal)
    {
        CamposSucursal campos = new CamposSucursal();


        campos.idSucursal = idSucursal;

        return metodosSucursal.eliminarSucursalNegocio(campos);

    }
    [WebMethod]
    public bool InsertarSucursal(string nombre, int idEmpresa, string RFC, int ComboTPer, string RS,   string Calle, string NumExt, string NumInt, int ComboEstado, int ComboCP)
    {
        CamposSucursal campos = new CamposSucursal();
        campos.DatosFiscales = new CamposDatosFiscales();
        campos.DatosFiscales.TipoPersona = new CamposTipoPersona();
        campos.DatosFiscales.Estado = new CamposEstado();


        campos.nombre = nombre;
        campos.idEmpresa = idEmpresa;
        campos.DatosFiscales.RazonSocial = RS;
        campos.DatosFiscales.TipoPersona.IdTipoPersona = ComboTPer;
        campos.DatosFiscales.RFC = RFC;
        campos.DatosFiscales.Calle = Calle;
        campos.DatosFiscales.NumeroExterior = NumExt;
        campos.DatosFiscales.NumeroInterior = NumInt;
        campos.DatosFiscales.Estado.idEstado = ComboEstado;
        campos.DatosFiscales.C_CP = ComboCP;



        return metodosSucursal.InsertaSucursalNegocio(campos);

    }
    [WebMethod]
    public CodigoPostal LlenaComboCP(int idEstado)
    {

        CodigoPostal listaCP;
        listaCP = metodosSucursal.LlenaComboCP(idEstado);
        return listaCP;

    }
    [WebMethod]
    public Sucursal LlenaComboEmpresa()
    {
        Sucursal listaEmpresa;
        listaEmpresa = metodosSucursal.LlenaComboEmpresa();
        return listaEmpresa;

    }
    [WebMethod]
    public TipoPersona LlenaComboTipoPersona()
    {
        TipoPersona listaTipoPersona;
        listaTipoPersona = metodosSucursal.LlenaComboTipoPersona();
        return listaTipoPersona;

    }
    [WebMethod]
    public Sucursal LlenaComboDatosFiscales()
    {
        Sucursal listaDatosFiscales;
        listaDatosFiscales = metodosSucursal.LlenaComboDatosFiscales();

        return listaDatosFiscales;
    }
    [WebMethod]
    public Estado LlenaComboEstado()
    {
        Estado ListaRegistrosEstado;
        ListaRegistrosEstado = metodosSucursal.LlenaComboEstados();

        return ListaRegistrosEstado;
    }
    #endregion

    #region CrudAreas
    readonly NegocioArea metodosArea = new NegocioArea();


    [WebMethod]
    public Area LlenaTablaArea()
    {
        Area listcampos;
        listcampos = metodosArea.LlenaTabla();
        return listcampos;

    }

    [WebMethod]
    public bool insertaAreaWs(string area, string descripcion, int[] sucursales)
    {
        CamposArea campos = new CamposArea();
        campos.nombre = area;
        campos.descripcion = descripcion;
        //campos.sucursal.idSucursal = idSucursal;
        Console.WriteLine("sucursales " + sucursales);
        return metodosArea.InsertaAreaNegocio(campos, sucursales);
    }

    [WebMethod]
    public bool actualisarAreaWs(string area, string descripcion, int idArea, int[] idSucursales)
    {
        CamposArea campos = new CamposArea();
        campos.sucursal = new CamposSucursal();
        campos.nombre = area;
        campos.descripcion = descripcion;
        campos.idArea = idArea;

        return metodosArea.actualizarAreaNegocio(campos, idSucursales);
    }


    [WebMethod]
    public bool eliminarAreaWs(int idArea)
    {
        CamposArea campos = new CamposArea();

        campos.idArea = idArea;

        return metodosArea.eliminarAreaNegocio(idArea);
    }

    [WebMethod]
    public Sucursal LlenaComboSucursalWS()
    {
        Sucursal listcampos;
        listcampos = metodosArea.LlenacomboSucursalNegocio();
        return listcampos;
    }

    [WebMethod]
    public Sucursal getidSucursalesByArea(int idArea)
    {
        Sucursal listcampos;
        listcampos = metodosArea.getidSucursalesByArea(idArea);
        return listcampos;
    }
    #endregion

    #region CrudRoles
    readonly NegocioPerfil metodosPerfil = new NegocioPerfil();

    [WebMethod]
    public Perfil LlenaTablaPerfiles()
    {
        Perfil listcampos;
        listcampos = metodosPerfil.LlenaTabla();
        return listcampos;

    }

    [WebMethod]
    public bool insertaPerfilWs(string nombre, string descripcion)
    {
        CamposPerfil campos = new CamposPerfil();
        campos.nombre = nombre;
        campos.descripcion = descripcion;

        return metodosPerfil.InsertaPerfilNegocio(campos);
    }

    [WebMethod]
    public bool actualisarPerfilWs(string nombre, string descripcion, int idPerfil)
    {
        CamposPerfil campos = new CamposPerfil();
        campos.nombre = nombre;
        campos.descripcion = descripcion;
        campos.idPerfil = idPerfil;

        return metodosPerfil.actualizarPerfilNegocio(campos);
    }

    [WebMethod]
    public bool eliminarPerfilWs(int idPerfil)
    {
        CamposPerfil campos = new CamposPerfil();

        campos.idPerfil = idPerfil;

        return metodosPerfil.eliminarPerfilNegocio(idPerfil);
    }
    #endregion

    #region CrudModelosMaquina
    readonly NegocioModeloMaquina metodosModeloMaquinas = new NegocioModeloMaquina();

    [WebMethod]
    public ModeloMaquina LlenaTablaModelosMAquina()
    {
        ModeloMaquina listcampos;
        listcampos = metodosModeloMaquinas.LlenaTabla();
        return listcampos;

    }

    [WebMethod]
    public bool insertaModeloMaquinaWs(string nombre, string descripcion, int anio, int idMarca)
    {
        CamposModeloMaquina campos = new CamposModeloMaquina();
        campos.marca = new CamposMarcaMaquinaria();
        campos.nombre = nombre;
        campos.anio = anio;
        campos.descripcion = descripcion;
        campos.marca.idMarca = idMarca;

        return metodosModeloMaquinas.InsertaModeloMaquinaNegocio(campos);
    }

    [WebMethod]
    public bool actualisarModeloMaquinaWs(string nombre, string descripcion, int anio, int idMarca, int idModeloMaquina)
    {
        CamposModeloMaquina campos = new CamposModeloMaquina();
        campos.marca = new CamposMarcaMaquinaria();
        campos.nombre = nombre;
        campos.descripcion = descripcion;
        campos.anio = anio;
        campos.marca.idMarca = idMarca;
        campos.idModeloMaquina = idModeloMaquina;

        return metodosModeloMaquinas.actualizarModeloMaquinaNegocio(campos);
    }

    [WebMethod]
    public bool eliminarModeloMaquinaWs(int idModeloMaquina)
    {
        CamposModeloMaquina campos = new CamposModeloMaquina();

        campos.idModeloMaquina = idModeloMaquina;

        return metodosModeloMaquinas.eliminarModeloMaquinaNegocio(idModeloMaquina);
    }

    [WebMethod]
    public MarcaMaquinaria LlenaComboMarcaWS()
    {
        MarcaMaquinaria listcampos;
        listcampos = metodosModeloMaquinas.LlenacomboMarcaNegocio();
        return listcampos;
    }
    #endregion

    #region CrudProveedor
    readonly NegocioProveedor metodosProveedor = new NegocioProveedor();

    [WebMethod]
    public Proveedor LlenaTablaProveedor()
    {
        Proveedor listcampos;
        listcampos = metodosProveedor.LlenaTabla();
        return listcampos;

    }

    [WebMethod]
    public bool insertaProveedorWs(string proveedor, int tipo, string rfc, string razon, int ComboEstado, int cp, string calle, string ext, string interior, int tipoPer, DateTime fechaAlta)
    {
        CamposProveedor campos = new CamposProveedor();
        campos.datosFiscales = new CamposDatosFiscales();
        campos.tipoPersona = new CamposTipoPersona();
        campos.tipoProveedor = new CamposTipoProveedor();
        campos.estado = new CamposEstado();
        campos.datosFiscales.RazonSocial = razon;
        campos.datosFiscales.RFC = rfc;
        campos.datosFiscales.C_CP = cp;
        campos.estado.idEstado = ComboEstado;
        campos.datosFiscales.Calle = calle;
        campos.datosFiscales.NumeroExterior = ext;
        campos.datosFiscales.NumeroInterior = interior;
        campos.tipoPersona.IdTipoPersona = tipoPer;
        campos.nombre = proveedor;
        campos.tipoProveedor.idTipoProveedor = tipo;
        campos.fechaAlta = fechaAlta;     

        return metodosProveedor.InsertaProveedorNegocio(campos);
    }

    [WebMethod]
    public bool ActualisarProveedorWs(int idDatos, int idProveedor, string proveedor, int tipo, string rfc, string razon, int cp, int ComboEstado, string calle, string ext, string interior, int tipoPer, string fechaAlta, string fechaBaja)
    {
        CamposProveedor campos = new CamposProveedor();
        campos.datosFiscales = new CamposDatosFiscales();
        campos.tipoPersona = new CamposTipoPersona();
        campos.tipoProveedor = new CamposTipoProveedor();
        campos.estado = new CamposEstado();
        
        campos.datosFiscales.RazonSocial = razon;
        campos.datosFiscales.RFC = rfc;
        campos.datosFiscales.IdDatosFiscales = idDatos;
        campos.datosFiscales.C_CP = cp;
        campos.estado.idEstado = ComboEstado;
        campos.datosFiscales.Calle = calle;
        campos.datosFiscales.NumeroExterior = ext;
        campos.datosFiscales.NumeroInterior = interior;
        campos.tipoPersona.IdTipoPersona = tipoPer;
        campos.idProveedor = idProveedor;
        campos.nombre = proveedor;
        campos.tipoProveedor.idTipoProveedor = tipo;
        campos.fechaAlta = Convert.ToDateTime(fechaAlta);
        campos.fechaBaja = Convert.ToDateTime(fechaBaja);

        return metodosProveedor.actualizarProveedorNegocio(campos);
    }

    [WebMethod]
    public bool eliminarProveedorWs(int idProveedor)
    {
        CamposProveedor campos = new CamposProveedor();

        campos.idProveedor = idProveedor;

        return metodosProveedor.eliminarProveedorNegocio(idProveedor);
    }

    [WebMethod]
    public TipoProveedor LlenaComboTipoProveedor()
    {
        TipoProveedor listcampos;
        listcampos = metodosProveedor.LlenaComboTipoProveedor();
        return listcampos;
    }

    [WebMethod]
    public CodigoPostal LlenaComboCodigoPostal()
    {
        CodigoPostal listcampos;
        listcampos = metodosProveedor.LlenaComboCodigoPostal();
        return listcampos;
    }

    [WebMethod]
    public Estado LlenaEstadoByCP(int cp)
    {
        Estado listcampos;
        listcampos = metodosProveedor.LlenaEstadoByCP(cp);
        return listcampos;
    }

    #endregion


    #region Datos empresariales

    [WebMethod]
    public DatosEmpresariales LlenaTablaDE() {
        DatosEmpresariales listcampos;
        listcampos = metodosNegocioDatosEmpresariales.LlenaTablaDE();
        return listcampos;
    }

    [WebMethod]
    public bool InsertarDatosEmpresariales(string nombre, string fechaRegistro, int idGiro, int ComboTPer, string RazonSocial, string RFC, int ComboEstado, int ComboCP, string Calle, string NumExt, string NumInt) {
        CamposDatosEmpresariales campos = new CamposDatosEmpresariales();
        campos.DatosFiscales = new CamposDatosFiscales();
        campos.DatosFiscales.TipoPersona = new CamposTipoPersona();
        campos.DatosFiscales.Estado = new CamposEstado();


        campos.nombre = nombre;
        campos.fechaRegistro = fechaRegistro;
        campos.idGiro = idGiro;

        campos.DatosFiscales.RazonSocial = RazonSocial;
        campos.DatosFiscales.TipoPersona.IdTipoPersona = ComboTPer;
        campos.DatosFiscales.RFC = RFC;
        campos.DatosFiscales.Calle = Calle;
        campos.DatosFiscales.NumeroExterior = NumExt;
        campos.DatosFiscales.NumeroInterior = NumInt;
        campos.DatosFiscales.Estado.idEstado = ComboEstado;
        campos.DatosFiscales.C_CP = ComboCP;

        return metodosNegocioDatosEmpresariales.InsertaDatosEmpresariales(campos);

    }
    [WebMethod]
    public bool ActualizarDatosEmpresariales(int idEmpresa, string nombre, string fechaRegistro, int idGiro, int ComboTPer, string RazonSocial, string RFC, int ComboEstado, int ComboCP, string Calle, string NumExt, string NumInt) {

        if (NumInt == null) {
            NumInt = "Sin Numero Interior";
        }
        CamposDatosEmpresariales campos = new CamposDatosEmpresariales();
        campos.DatosFiscales = new CamposDatosFiscales();
        campos.DatosFiscales.TipoPersona = new CamposTipoPersona();
        campos.DatosFiscales.Estado = new CamposEstado();
        campos.idEmpresa = idEmpresa;
        campos.nombre = nombre;
        campos.fechaRegistro = fechaRegistro;
        campos.idGiro = idGiro;

        campos.DatosFiscales.RazonSocial = RazonSocial;
        campos.DatosFiscales.TipoPersona.IdTipoPersona = ComboTPer;
        campos.DatosFiscales.RFC = RFC;
        campos.DatosFiscales.Calle = Calle;
        campos.DatosFiscales.NumeroExterior = NumExt;  
        campos.DatosFiscales.NumeroInterior = NumInt;
        campos.DatosFiscales.Estado.idEstado = ComboEstado;
        campos.DatosFiscales.C_CP = ComboCP;


        return metodosNegocioDatosEmpresariales.ActualizarDatosEmpresariales(campos);

    }

    [WebMethod]
    public bool EliminarDatosEmpresariales(int idEmpresa) {
        CamposDatosEmpresariales campos = new CamposDatosEmpresariales();
        campos.idEmpresa = idEmpresa;

        return metodosNegocioDatosEmpresariales.EliminarDatosEmpresariales(campos);

    }



    [WebMethod]
    public bool ExisteRFC(String rfc) {

        CamposDatosEmpresariales campos = new CamposDatosEmpresariales();
        campos.DatosFiscales = new CamposDatosFiscales();
        campos.DatosFiscales.RFC = rfc;

        return metodosNegocioDatosEmpresariales.ExisteRFC(campos);
    }

    #endregion

    #region Giros empresariales

    [WebMethod]
    public Giros LlenaTablaGE() {
        Giros listcampos;
        listcampos = metodosNegocioGE.LlenaTablaGE();
        return listcampos;
    }

    [WebMethod]
    public bool insertaWsGE(string nombre) {
        CamposGirosEmpresariales datosGirosEmpresariales = new CamposGirosEmpresariales();
        datosGirosEmpresariales.nombre = nombre;
        return metodosNegocioGE.insertarGE(datosGirosEmpresariales);
    }

    [WebMethod]
    public bool ActualizarWsGE(int idGiro, string nombre) {
        CamposGirosEmpresariales datosGirosEmpresariales = new CamposGirosEmpresariales();
        datosGirosEmpresariales.idGiro = idGiro;
        datosGirosEmpresariales.nombre = nombre;

        return metodosNegocioGE.actualizarGE(datosGirosEmpresariales);
    }

    [WebMethod]
    public bool EliminarWsGE(int idGiro) {
        CamposGirosEmpresariales datosGirosEmpresariales = new CamposGirosEmpresariales();
        datosGirosEmpresariales.idGiro = idGiro;
        return metodosNegocioGE.eliminarGE(datosGirosEmpresariales);
    }

    #endregion

    #region Almacen

    [WebMethod]
    public Almacen LlenaTablaAlmacen() {
        Almacen listcampos;
        listcampos = metodosNegocioAlmacen.LlenaTablaAlmacen();
        return listcampos;
    }
    [WebMethod]
    public Almacen LlenaComboSucursales() {
        Almacen listcampos;
        listcampos = metodosNegocioAlmacen.LlenaComboSucursales();
        return listcampos;
    }

    [WebMethod]
    public Almacen LlenaComboTipoAlmacen() {
        Almacen listcampos;
        listcampos = metodosNegocioAlmacen.LlenaComboTipoAlmacen();
        return listcampos;
    }

    [WebMethod]
    public bool insertaWsInsertarAlmacen(string descripcion, int idSucursal, int idTipoAlmacen) {
        CamposAlmacen datosAlmacen = new CamposAlmacen();
        datosAlmacen.descripcion = descripcion;
        datosAlmacen.idSucursal = idSucursal;
        datosAlmacen.idTipoAlmacen = idTipoAlmacen;
        return metodosNegocioAlmacen.InsertarAlmacen(datosAlmacen);
    }


    [WebMethod]
    public bool actualizarWsAlmacen(int idAlmacen, string descripcion, int idSucursal, int idTipoAlmacen) {
        CamposAlmacen datosAlmacen = new CamposAlmacen();
        datosAlmacen.idAlmacen = idAlmacen;
        datosAlmacen.descripcion = descripcion;
        datosAlmacen.idSucursal = idSucursal;
        datosAlmacen.idTipoAlmacen = idTipoAlmacen;
        return metodosNegocioAlmacen.ActualizarAlmacen(datosAlmacen);
    }

    [WebMethod]
    public bool EliminarWsAlmacen(int idAlmacen) {
        CamposAlmacen datosAlmacen = new CamposAlmacen();
        datosAlmacen.idAlmacen = idAlmacen;
        return metodosNegocioAlmacen.EliminarAlmacen(datosAlmacen);
    }

    #endregion

    #region Tipo almacen

    [WebMethod]
    public TipoAlmcanen LlenaTablaTipoAlmacen() {
        TipoAlmcanen listcampos;
        listcampos = metodosNegocioTipoAlmacen.LlenaTablaTipoAlmacen();
        return listcampos;
    }

    [WebMethod]
    public bool insertaWsTipoAlmacen(string nombre, string descripcion) {
        CamposTipoAlmacen datosTipoAlmacen = new CamposTipoAlmacen();
        datosTipoAlmacen.nombre = nombre;
        datosTipoAlmacen.descripcion = descripcion;
        return metodosNegocioTipoAlmacen.insertarTipoAlmacen(datosTipoAlmacen);
    }

    [WebMethod]
    public bool ActualizarWsTipoAlmacen(int idTipoAlmacen, string nombre, string descripcion) {
        CamposTipoAlmacen datosTipoAlmacen = new CamposTipoAlmacen();
        datosTipoAlmacen.idTipoAlmacen = idTipoAlmacen;
        datosTipoAlmacen.nombre = nombre;
        datosTipoAlmacen.descripcion = descripcion;
        return metodosNegocioTipoAlmacen.actualizarTipoAlmacen(datosTipoAlmacen);
    }

    [WebMethod]
    public bool EliminarWsTipoAlmacen(int idTipoAlmacen) {
        CamposTipoAlmacen datosTipoAlmacen = new CamposTipoAlmacen();
        datosTipoAlmacen.idTipoAlmacen = idTipoAlmacen;
        return metodosNegocioTipoAlmacen.eliminarTipoAlmacen(datosTipoAlmacen);
    }

    #endregion

    #region Puestos

    [WebMethod]
    public Puestos LlenaTablaPuestos() {
        Puestos listcampos;
        listcampos = metodosNegocioPuestos.LlenaTablaPuestos();
        return listcampos;
    }
    [WebMethod]
    public bool InsertaWsPuestos(string nombre, string descripcion) {
        CamposPuestos datosPuestos = new CamposPuestos();
        datosPuestos.nombrePuesto = nombre;
        datosPuestos.descripcion = descripcion;
        return metodosNegocioPuestos.InsertarPuestos(datosPuestos);
    }

    [WebMethod]
    public bool ActualizarWsPuestos(int idPuesto, string nombre, string descripcion) {
        CamposPuestos datosPuestos = new CamposPuestos();
        datosPuestos.idPuesto = idPuesto;
        datosPuestos.nombrePuesto = nombre;
        datosPuestos.descripcion = descripcion;
        return metodosNegocioPuestos.actualizarPuestos(datosPuestos);
    }

    [WebMethod]
    public bool EliminarWsPuestos(int idPuesto) {
        CamposPuestos datosPuestos = new CamposPuestos();
        datosPuestos.idPuesto = idPuesto;
        return metodosNegocioPuestos.eliminarPuestos(datosPuestos);
    }
    #endregion

    #region Modelo placas
    [WebMethod]
    public ModelosPlacas LlenaTablaModeloPlacas() {
        ModelosPlacas listcampos;
        listcampos = metodosModeloPlacas.LlenaTablaModeloPlacas();
        return listcampos;
    }
    [WebMethod]
    public bool InsertaWsModeloPlacas(string nombre, string modelo, string descripcion) {
        CamposModeloPlacas datosModeloPlacas = new CamposModeloPlacas();
        datosModeloPlacas.nombre = nombre;
        datosModeloPlacas.modelo = modelo;
        datosModeloPlacas.descripcion = descripcion;
        return metodosModeloPlacas.InsertarModeloPlacas(datosModeloPlacas);
    }
    [WebMethod]
    public bool ActualizarWsModeloPlacas(int idModeloCircuito, string nombre, string modelo, string descripcion) {
        CamposModeloPlacas datosModeloPlacas = new CamposModeloPlacas();
        datosModeloPlacas.idModeloCircuito = idModeloCircuito;
        datosModeloPlacas.nombre = nombre;
        datosModeloPlacas.modelo = modelo;
        datosModeloPlacas.descripcion = descripcion;
        return metodosModeloPlacas.ActualizarModeloPlacas(datosModeloPlacas);
    }

    [WebMethod]
    public bool EliminarWsModeloPlacas(int idModeloCircuito) {
        CamposModeloPlacas datosModeloPlacas = new CamposModeloPlacas();
        datosModeloPlacas.idModeloCircuito = idModeloCircuito;
        return metodosModeloPlacas.EliminarModeloPlacas(datosModeloPlacas);
    }
    #endregion

    #region Placas
    [WebMethod]
    public Placas LlenaTablaPlacas() {
        Placas listcampos;
        listcampos = metodosPlacas.LlenaTablaPlacas();
        return listcampos;
    }
    [WebMethod]
    public Placas LlenaComboModeloPlacaDatos() {
        Placas listcampos;
        listcampos = metodosPlacas.LlenaComboModeloPlacaDatos();
        return listcampos;
    }

    [WebMethod]
    public bool InsertaWsPlacas(string direccionMAC, string fechaAlta, string fechaBaja, string descripcion, string direccionIp, int modeloCircuito, string noSerie) {
        CamposPlacas datosPlacas = new CamposPlacas();
        datosPlacas.direccionMACEquipo = direccionMAC;
        datosPlacas.fechaAlta = fechaAlta;
        datosPlacas.fechaBaja = fechaBaja;
        datosPlacas.descripcion = descripcion;
        datosPlacas.direccionIp = direccionIp;
        datosPlacas.idModeloCircuito = modeloCircuito;
        datosPlacas.numeroSerie = noSerie;

        return metodosPlacas.InsertarPlacas(datosPlacas);
    }

    [WebMethod]
    public bool ActualizarWsPlacas(int idPlaca, string direccionMAC, string fechaAlta, string fechaBaja, string descripcion, string direccionIp, int modeloCircuito, string noSerie) {
        CamposPlacas datosPlacas = new CamposPlacas();
        datosPlacas.idPlaca = idPlaca;
        datosPlacas.direccionMACEquipo = direccionMAC;
        datosPlacas.fechaAlta = fechaAlta;
        datosPlacas.fechaBaja = fechaBaja;
        datosPlacas.descripcion = descripcion;
        datosPlacas.direccionIp = direccionIp;
        datosPlacas.idModeloCircuito = modeloCircuito;
        datosPlacas.numeroSerie = noSerie;

        return metodosPlacas.ActualizarPlacas(datosPlacas);
    }

    [WebMethod]
    public bool EliminarWsPlacas(int idPlaca) {
        CamposPlacas datosPlacas = new CamposPlacas();
        datosPlacas.idPlaca = idPlaca;
        return metodosPlacas.EliminarPlacas(datosPlacas);
    }

    #endregion

    #region reportes OEE

    [WebMethod]
    public CalculoProduccion reporteOEEProduccion() {
        CalculoProduccion listcampos;
        listcampos = metodosCalculoProduccion.reporteOEE();
        return listcampos;
    }

    #endregion

    #region eficiencia de maquina por periodo
    [WebMethod]
    public CalculoProduccion departamento() {
        CalculoProduccion listcampos;
        listcampos = metodosCalculoProduccion.departamento();
        return listcampos;
    }

    [WebMethod]
    public CalculoProduccion reporteTiempoInactivo(string FechaInicio, string FechaFin, int ComboDepar)
    {
        CalculoProduccion listaCampos;
        listaCampos = metodosCalculoProduccion.reporteTiempoInactivo(FechaInicio, FechaFin, ComboDepar);
        return listaCampos;
    }

    [WebMethod]
    public CalculoProduccion reportePiezasDefectuosas(string FechaInicio, string FechaFin, int ComboDepar)
    {
        CalculoProduccion listaCampos;
        listaCampos = metodosCalculoProduccion.reportePiezasDefectuosas(FechaInicio, FechaFin, ComboDepar);
        return listaCampos;
    }
    [WebMethod]
    public CalculoProduccion reporteEficienciaMaquinaPeriodo(int idDepartamento) {
        CalculoProduccion listaCampos;
        listaCampos = metodosCalculoProduccion.reporteEficienciaMaquinaPeriodo(idDepartamento);
        return listaCampos;
    }

    [WebMethod]
    public CalculoProduccion reporteEficienciaMaquinaPeriodoFinal(string fechaInicio, string fechaFin, int idMaquina) {
        CalculoProduccion listcampos;
        listcampos = metodosCalculoProduccion.reporteEficienciaMaquinaPeriodoFinal( fechaInicio,  fechaFin,  idMaquina);
        return listcampos;
    }

    #endregion

 
    #region Maquinaria con dispositivos de medicion
    [WebMethod]
    public MaquinariaDispositivosMedicion ConsultarMaqinariaPlacas() {
        MaquinariaDispositivosMedicion listcampos;
        listcampos = metodosNegocioMaquinariaDispositivoMedicion.consultarMaquinas();
        return listcampos;
    }


    #endregion

    #region Menus
    readonly NegocioMenu menus = new NegocioMenu();

    [WebMethod]
    public Menu muestraMenus()
    {
        Menu listMenus;
        listMenus = menus.MuestraMenus();
        return listMenus;

    }

    [WebMethod]
    public Menu muestraSubMenus(int idPadre)
    {
        Menu listMenus;
        listMenus = menus.muestraSubMenus(idPadre);
        return listMenus;

    }
    #endregion

    #region Maquina

    readonly NegocioMaquinas metodosMaquina = new NegocioMaquinas();

    [WebMethod]
    public Maquina LlenaTablaMaquina()
    {
        Maquina listcampos;
        listcampos = metodosMaquina.LlenaTablaMaquina();
        return listcampos;

    }

    [WebMethod]
    public Placa LlenaComboPlaca()
    {

        Placa ListaPlaca;
        ListaPlaca = metodosMaquina.ComboPlaca();
        return ListaPlaca;

    }

    [WebMethod]
    public NavesIndustriales LlenaComboNave()
    {

        NavesIndustriales ListaNavesIndustriales;
        ListaNavesIndustriales = metodosMaquina.ComboNave();
        return ListaNavesIndustriales;

    }

    [WebMethod]
    public MarcasMaquina LlenaComboMarca()
    {

        MarcasMaquina ListaMarcasMaq;
        ListaMarcasMaq = metodosMaquina.ComboMarcasMaq();
        return ListaMarcasMaq;

    }


    [WebMethod]
    public bool InsertaMaquina(string Descripcion, int CmbMarca, string Nserie, int CmbNave, int ComboPlaca, int Año)
    {
        CamposMaquina campos = new CamposMaquina();
        campos.MarcasMaquina = new CamposMarcasMaquina();
        campos.NavesIndus = new CamposNavesIndus();
        campos.CamposPlaca = new CamposPlaca();

        campos.Descripcion = Descripcion;
        campos.MarcasMaquina.IdMarca = CmbMarca;
        campos.NoSerie = Nserie;
        campos.NavesIndus.IdNave = CmbNave;
        campos.CamposPlaca.IdPlaca = ComboPlaca;
        campos.Año = Año;

        return metodosMaquina.InsertaMaquina(campos);
    }


    [WebMethod]
    public bool ActualizaMaquina(int idMaquina, string Descripcion, int idMarca, string Nserie, int idNave, int idPlaca, int año)
    {
        CamposMaquina campos = new CamposMaquina();
        campos.MarcasMaquina = new CamposMarcasMaquina();
        campos.NavesIndus = new CamposNavesIndus();
        campos.CamposPlaca = new CamposPlaca();

        campos.IdMaquina = idMaquina;
        campos.Descripcion = Descripcion;
        campos.MarcasMaquina.IdMarca = idMarca;
        campos.NoSerie = Nserie;
        campos.NavesIndus.IdNave = idNave;
        campos.CamposPlaca.IdPlaca = idPlaca;
        campos.Año = año;

        return metodosMaquina.ActualizaMaquina(campos);
    }

    [WebMethod]
    public bool EliminarMaquina(int IdMaquina)
    {


        return metodosMaquina.EliminarMaquina(IdMaquina);

    }

    #endregion


    #region ReporteEquipos

    readonly NegocioMantenimientoEquipos metodosMantenimiento = new NegocioMantenimientoEquipos();
    [WebMethod]
    public Mantenimiento ReporteMantenimiento(string FechaInicio, string FechaFin, int ComboDepar)
    {
        Mantenimiento listaCampos;
        listaCampos = metodosMantenimiento.LlenaTablaMantenimiento(FechaInicio, FechaFin, ComboDepar);
        return listaCampos;
    }

    readonly NegocioEnergiaXEquipos metodosEnergia = new NegocioEnergiaXEquipos();
    [WebMethod]
    public CalculoProduccion LlenaTablaEnergiaXEquipos(string FechaInicio, string FechaFin, int ComboDepar)
    {

        CalculoProduccion listcampos;
        listcampos = metodosEnergia.LlenaTablaEnergiaXEquipos(FechaInicio, FechaFin, ComboDepar);
        return listcampos;
    }

    readonly NegocioProyeccionesCalculadas metodosGraficas = new NegocioProyeccionesCalculadas();
    [WebMethod]
    public CalculoProduccion GraficaProyeccion( string fechaInicio, string fechaFin)
    {
        //GraficaMejoraProduccionxs
        CalculoProduccion listcampos;
        listcampos = metodosGraficas.GraficaProyeccion(fechaInicio, fechaFin);
        return listcampos;
    }

    public CalculoProduccion GraficaEufem(string fechaInicio, string fechaFin)
    {
        //GraficaMejoraProduccionxs
        CalculoProduccion listcampos;
        listcampos = metodosGraficas.GraficaEufem(fechaInicio, fechaFin);
        return listcampos;
    }


    readonly NegocioIndicadoresMejora metodosIndicadores = new NegocioIndicadoresMejora();
    [WebMethod]
    public CalculoProduccion IndicadoresEficiencia(string FechaInicio, string FechaFin, int ComboDepar)
    {

        CalculoProduccion listcampos;
        listcampos = metodosIndicadores.IndicadoresEficiencia(FechaInicio, FechaFin, ComboDepar);
        return listcampos;
    }
   
    [WebMethod]
    public Maquina LlenaMaquina(int idDepartamento)
    {

        Maquina listaMaq;
        listaMaq = metodosMaquina.LlenaMaquina(idDepartamento);
        return listaMaq;

    }

    #endregion

    #region Sensores

    readonly NegocioSensores metodosSensores = new NegocioSensores();

    [WebMethod]
    public Sensores LlenaTablaSensores()
    {
        Sensores listcampos;
        listcampos = metodosSensores.LlenaTablaSensores();
        return listcampos;

    }
    [WebMethod]
    public bool InsertaSensor(int ComboTSensor, int ComboTMedidor, string NSerie, int ComboUMedida, int ComboAMedido, string FechaAlta, string Descripcion, string FechaIns, int ComboPlaca, int ComboModSen, int IntervaloLec)
    {
        CamposSensores campos = new CamposSensores();
        campos.TipoSensor = new CamposTiposSen();
        campos.TipoMedidor = new CamposTiposMed();
        campos.UnidadesMedida = new CamposUnidadesM();
        campos.AgentesMedidos = new CamposAgentesM();
        campos.PlacasSensores = new CamposPlacasSen();
        campos.ModeloSensores = new CamposModeloSen();

        campos.TipoSensor.IdTipoSensor = ComboTSensor;
        campos.TipoMedidor.IdTipoMedidor = ComboTMedidor;
        campos.NoSerie = NSerie;
        campos.UnidadesMedida.IdUnidadMedida = ComboUMedida;
        campos.AgentesMedidos.IdAgenteMedido = ComboAMedido;
        campos.FechaALtaS = FechaAlta;
        campos.Descripcion = Descripcion;
        campos.FechaInstalacionS = FechaIns;
        campos.PlacasSensores.IdPlaca = ComboPlaca;
        campos.ModeloSensores.IdModeloSensor = ComboModSen;
        campos.IntervaloLectura = IntervaloLec;

 
        return metodosSensores.InsertaSensor(campos);
    }
    [WebMethod]
    public bool ActualizarSensor(int ComboTSensor, int ComboTMedidor, string NSerie, int ComboUMedida, int ComboAMedido, string FechaAlta, string Descripcion, string FechaIns, int ComboPlaca, int ComboModSen, int IntervaloLec, int IdSensor)
    {

        DateTime fechaAltaD = Convert.ToDateTime(FechaAlta.ToString());
        DateTime fechaInsD = Convert.ToDateTime(FechaIns.ToString());

        CamposSensores campos = new CamposSensores();
        campos.TipoSensor = new CamposTiposSen();
        campos.TipoMedidor = new CamposTiposMed();
        campos.UnidadesMedida = new CamposUnidadesM();
        campos.AgentesMedidos = new CamposAgentesM();
        campos.PlacasSensores = new CamposPlacasSen();
        campos.ModeloSensores = new CamposModeloSen();

        campos.TipoSensor.IdTipoSensor = ComboTSensor;
        campos.TipoMedidor.IdTipoMedidor = ComboTMedidor;
        campos.NoSerie = NSerie;
        campos.UnidadesMedida.IdUnidadMedida = ComboUMedida;
        campos.AgentesMedidos.IdAgenteMedido = ComboAMedido;
        campos.FechaALtaS = FechaAlta;
        campos.Descripcion = Descripcion;
        campos.FechaInstalacionS = FechaIns;
        campos.PlacasSensores.IdPlaca = ComboPlaca;
        campos.ModeloSensores.IdModeloSensor = ComboModSen;
        campos.IntervaloLectura = IntervaloLec;
        campos.IdSensor = IdSensor;

        return metodosSensores.ActualizarSensor(campos);
    }
    [WebMethod]
    public bool EliminarSensor(int IdSensor)
    {
        
        return metodosSensores.EliminarSensor(IdSensor);

    }
    [WebMethod]
    public TiposSensores LlenaComboTipoSensore()
    {

        TiposSensores ListaPlaca;
        ListaPlaca = metodosSensores.LlenaComboTipoSensore();
        return ListaPlaca;

    }
    [WebMethod]
    public TiposMedidores LlenaComboTipoMedidores()
    {

        TiposMedidores ListaPlaca;
        ListaPlaca = metodosSensores.LlenaComboTipoMedidores();
        return ListaPlaca;

    }
    [WebMethod]
    public UnidadesMedida LlenaComboUnidadMedida()
    {

        UnidadesMedida ListaPlaca;
        ListaPlaca = metodosSensores.LlenaComboUnidadMedida();
        return ListaPlaca;

    }
    [WebMethod]
    public AgentesMedidos LlenaComboAgentesMed()
    {

        AgentesMedidos ListaPlaca;
        ListaPlaca = metodosSensores.LlenaComboAgentesMed();
        return ListaPlaca;

    }
    [WebMethod]
    public PlacasSensores LlenaComboPlacasSen()
    {

        PlacasSensores ListaPlaca;
        ListaPlaca = metodosSensores.LlenaComboPlacasSen();
        return ListaPlaca;

    }
    [WebMethod]
    public ModelosSensores LlenaComboModelosSen()
    {
        ModelosSensores ListaPlaca;
        ListaPlaca = metodosSensores.LlenaComboModelosSen();
        return ListaPlaca;
    }



    #endregion

    #region personalUsuario

    readonly NegocioPersonalUsuario NegocioPersonalUsuario = new NegocioPersonalUsuario();

    [WebMethod]
    public PersonalUsuario llenaTablaPersonalUsuario()
    {
        PersonalUsuario listaCampos;
        listaCampos = NegocioPersonalUsuario.llenaTablaPersonalUsuario();
        return listaCampos;
    }

    [WebMethod]
    public ComboPuestos LlenaComboPuesto()
    {
        ComboPuestos listaCampos;
        listaCampos = NegocioPersonalUsuario.LlenaComboPuesto();
        return listaCampos;
    }

    [WebMethod]
    public ComboRoles LlenaComboRoles()
    {
        ComboRoles listaCampos;
        listaCampos = NegocioPersonalUsuario.LlenaComboRoles();
        return listaCampos;
    }

    [WebMethod]
    public ComboPrivilegios LlenaCheckBoxPrivilegios()
    {
        ComboPrivilegios listaCampos;
        listaCampos = NegocioPersonalUsuario.LlenaCheckBoxPrivilegios();
        return listaCampos;
    }

    [WebMethod]
    public ComboPrivilegiosCHK LlenaCheckBoxPrivilegiosEdit(int idPersonal, int idUsuario, int idRol)
    {
        ComboPrivilegiosCHK listaCampos;
        listaCampos = NegocioPersonalUsuario.LlenaCheckBoxPrivilegiosEdit(idPersonal, idUsuario, idRol);
        return listaCampos;
    }

    [WebMethod]
    public ComboPersonal LlenaComboPersonal()
    {
        ComboPersonal listaCampos;
        listaCampos = NegocioPersonalUsuario.LlenaComboPersonal();
        return listaCampos;
    }

    [WebMethod]
    public ComboEstados LlenaComboEstados()
    {
        ComboEstados listaCampos;
        listaCampos = NegocioPersonalUsuario.LlenaComboEstados();
        return listaCampos;
    }

    [WebMethod]
    public CodigoPostal LlenaComboCPs(int idEstado)
    {
        CodigoPostal listaCampos;
        listaCampos = NegocioPersonalUsuario.LlenaComboCP(idEstado);
        return listaCampos;
    }

    [WebMethod]
    public bool insertaPersonal(string nombre, string apPaterno, string apMaterno, string rfc, string estadoC, string cpC, string idPuesto, string email, string idRol, string usuario, string pwd, string accesarSistema, int[] privilegios)
    {
        bool respuesta = false;
        respuesta = NegocioPersonalUsuario.insertaPersonal(nombre, apPaterno, apMaterno, rfc, estadoC, cpC, idPuesto, email, idRol, usuario, pwd, accesarSistema, privilegios);
        return respuesta;
    }

    [WebMethod]
    public bool insertaUsuario(string personaC, string idRol, string usuario, string pwd, int[] privilegios)
    {
        bool respuesta = false;
        respuesta = NegocioPersonalUsuario.insertaUsuario(personaC, idRol, usuario, pwd, privilegios);
        return respuesta;
    }

    [WebMethod]
    public bool modificarPersonalUsuario(string nombre, string apPaterno, string apMaterno, string rfc, string estadoC, string cpC, string idPuesto, string email, string idRol, string usuario, string pwd, string accesarSistema, int[] privilegios, int idPersonal, int idUsuario, int idRolAnterior)
    {
        bool respuesta = false;
        respuesta = NegocioPersonalUsuario.modificarPersonalUsuario(nombre, apPaterno, apMaterno, rfc, estadoC, cpC, idPuesto, email, idRol, usuario, pwd, accesarSistema, privilegios, idPersonal, idUsuario, idRolAnterior);
        return respuesta;
    }

    [WebMethod]
    public bool eliminarPersonalUsuario(int idPersonal, int idUsuario, int idRolAnterior)
    {
        return NegocioPersonalUsuario.eliminarPersonalUsuario(idPersonal, idUsuario, idRolAnterior);
    }

    #endregion

    #region Reportes Calix


    [WebMethod]
    public CalculoProduccion llenaReporteOEEDepartamento(string FechaInicio, string FechaFin, int ComboDepar)
    {
        CalculoProduccion reporteOEE;
        reporteOEE = metodosCalculoProduccion.LlenareporteOEEPorDepartamento(FechaInicio,  FechaFin,  ComboDepar);
        return reporteOEE;
    }

    [WebMethod]
    public CalculoProduccion LlenareporteMaquinasEnProd(string FechaInicio, string FechaFin, int ComboDepar)
    {
        CalculoProduccion reporteMaquinas;
        reporteMaquinas = metodosCalculoProduccion.LlenareporteMaquinasEnProd(FechaInicio, FechaFin, ComboDepar);
        return reporteMaquinas;
    }

    [WebMethod]
    public CalculoProduccion LlenaReporteCostoPzaPorMaquina(string FechaInicio, string FechaFin, int ComboDepar)
    {
        CalculoProduccion listaCampos;
        //listaCampos = metodosCalculoProduccion.reporteTiempoInactivo(idDepartamento, fechaInicio, fechaFin);
        
        listaCampos = metodosCalculoProduccion.LlenaReporteCostoPzaPorMaquina(FechaInicio, FechaFin, ComboDepar);
        return listaCampos;
    }

    #endregion


}


