using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio {
    public class NegocioCalculoProduccion {

        DatosCalculoProduccion clasedatos = new DatosCalculoProduccion();

        public CalculoProduccion reporteOEE() {
            CalculoProduccion listadatos;
            listadatos = clasedatos.reporteOEE();
            return listadatos;
        }
        public CalculoProduccion departamento() {
            CalculoProduccion listadatos;
            listadatos = clasedatos.departamento();
            return listadatos;
        }
        public CalculoProduccion reporteEficienciaMaquinaPeriodo(int idDepartamento) {
            CalculoProduccion listadatos;
            listadatos = clasedatos.reporteEficienciaMaquinaPeriodo(idDepartamento);
            return listadatos;
        }
        public CalculoProduccion reporteEficienciaMaquinaPeriodoFinal(string fechaInicio, string fechaFin, int idMaquina) {
            CalculoProduccion listadatos;
            listadatos = clasedatos.reporteEficienciaMaquinaPeriodoFinal( fechaInicio,  fechaFin,  idMaquina);
            return listadatos;
        }
        public CalculoProduccion reportePiezasDefectuosas(string FechaInicio, string FechaFin, int ComboDepar) {
            CalculoProduccion listadatos;
            listadatos = clasedatos.reportePiezasDefectuosas(FechaInicio, FechaFin, ComboDepar);
            return listadatos;
        }
        public CalculoProduccion reporteTiempoInactivo(string FechaInicio, string FechaFin, int ComboDepar) {
            CalculoProduccion listadatos;
            listadatos = clasedatos.reporteTiempoInactivo(FechaInicio, FechaFin, ComboDepar);
            return listadatos;
        }

        public CalculoProduccion LlenareporteOEEPorDepartamento(string FechaInicio, string FechaFin, int ComboDepar)
        {
            CalculoProduccion listadatos;
            listadatos = clasedatos.ReporteOEEPorDepartamento(FechaInicio, FechaFin, ComboDepar);
            return listadatos;
        }

        public CalculoProduccion LlenareporteMaquinasEnProd(string FechaInicio, string FechaFin, int ComboDepar)
        {
            CalculoProduccion listadatos;
            listadatos = clasedatos.ReporteMaquinasEnProduccion(FechaInicio, FechaFin, ComboDepar);
            return listadatos;
        }

        public CalculoProduccion LlenaReporteCostoPzaPorMaquina(string FechaInicio, string FechaFin, int ComboDepar)
        {
            CalculoProduccion listadatos;
            listadatos = clasedatos.LlenaReporteCostoPzaPorMaquina(FechaInicio, FechaFin, ComboDepar);
            return listadatos;
         
        }

    }
}
