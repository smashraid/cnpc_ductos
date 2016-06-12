﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CNPC.SISDUC.DAL;
using System.Collections.Generic;
using CNPC.SISDUC.Model;
using CNPC.SISDUC.BLL;

namespace CNPC.SISDUC.Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LeerDeExcelDO()
        {
            List<Oleoducto> listaOriginal = null;

            int totalRegistrosEsperado = 2;
            using (ArchivoExterno archivo = new ArchivoExterno())
            {
                listaOriginal = archivo.LeerRegistrosExcel(@"F:\Datos\CNPC\solicitado\Oleoductos para BD.xlsx");
            }
            Assert.AreEqual<int>(totalRegistrosEsperado, listaOriginal.Count);
        }
        [TestMethod]
        public void GuardarDeExcelDO()
        {
            bool esperado = true;
            bool resultado = false;
            using (ArchivoExterno archivo = new ArchivoExterno())
            {
                resultado = archivo.CopiarRegistros(@"F:\Datos\CNPC\solicitado\Oleoductos para BD.xlsx");
            }
            Assert.AreEqual<bool>(esperado, resultado);
        }

        [TestMethod]
        public void FilterByName()
        {
            int totalPage = 3;
            int resultado = 0;
            using (Oleoductos objTest = new Oleoductos())
            {
                resultado = objTest.FilterByName("", 3, 3).TotalPages;
            }
            Assert.AreEqual<int>(totalPage, resultado);
        }
    }
}
