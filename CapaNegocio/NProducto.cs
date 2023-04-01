﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
	public class NProducto
	{
		Producto objproducto = new Producto();
		public void agregarProducto(EProducto eProducto)
		{
			objproducto.addProducto(eProducto);
		}

		public DataTable mostrarProductoProveedor()
		{
			DataTable tabla=new DataTable();
			tabla = objproducto.mostrarProductoProveedor();
			return tabla;
		}

		public DataTable mostrarProductosDrop(EProducto producto)
		{
			DataTable tabla=new DataTable();
			tabla = objproducto.mostrarProductosDrop(producto);
			return tabla;
		}
        public bool eliminarProductoP(EProducto Producto)
        {
           return objproducto.eliminarProductoP(Producto);
        }
		public DataTable mostrarAll()
		{
			DataTable tabla = new DataTable();
			tabla = objproducto.mostrarAll();
			return tabla;
		}


	}
}
