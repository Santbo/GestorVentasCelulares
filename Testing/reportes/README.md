# Pruebas Automatizadas - Módulo de Reportes

Este documento describe las 20 pruebas automatizadas implementadas para el módulo de reportes del sistema GestionVentasCel.

## 📋 Resumen de Pruebas

**Total de pruebas: 20**
- Pruebas de Reportes de Ventas: 10
- Pruebas de Reportes de Compras: 10
- **Estado: ✅ Todas las pruebas pasaron correctamente**

## 🗄️ Pruebas de Reportes de Ventas

Archivo: `test/reportes/ReporteVentaRepositoryTests.cs`

### Pruebas Implementadas:

1. **ObtenerVentasPorRangoFecha_DebeRetornarVentasEnRango**
   - Verifica que se retornen las ventas dentro del rango de fechas especificado

2. **ObtenerVentasPorRangoFecha_DebeExcluirVentasAnuladas**
   - Verifica que las ventas con estado "Anulada" no se incluyan en el reporte
   - Comprueba el filtrado por estado de venta

3. **ObtenerVentasPorRangoFecha_DebeRetornarListaVaciaCuandoNoHayVentas**
   - Verifica que retorne una lista vacía cuando no hay ventas en el rango

4. **ObtenerVentasPorRangoFecha_DebeCalcularMontosCorrectamente**
   - Verifica que se calculen correctamente MontoTotal, MontoSinIva y MontoIva
   - Comprueba que la suma de MontoSinIva + MontoIva ≈ MontoTotal (con tolerancia de redondeo)

5. **ObtenerVentasPorRangoFecha_DebeIncluirInformacionDelCliente**
   - Verifica que cada venta incluya la información del cliente
   - Comprueba que el campo Cliente no esté vacío

6. **ObtenerVentasPorRangoFecha_DebeOrdenarPorFechaDescendente**
   - Verifica que las ventas se retornen ordenadas por fecha descendente
   - Comprueba que las ventas más recientes aparezcan primero

7. **ObtenerResumenVentas_DebeCalcularTotalGeneralCorrectamente**
   - Verifica el cálculo del total general de ventas
   - Comprueba la cantidad de operaciones

8. **ObtenerResumenVentas_DebeCalcularPromedioCorrectamente**
   - Verifica que el promedio se calcule como TotalGeneral / CantidadOperaciones
   - Comprueba la precisión del cálculo del promedio

9. **ObtenerResumenVentas_DebeRetornarCerosCuandoNoHayVentas**
   - Verifica que retorne valores en cero cuando no hay ventas
   - Comprueba el manejo de casos sin datos

10. **ObtenerResumenVentas_DebeExcluirVentasAnuladas**
    - Verifica que las ventas anuladas no se incluyan en el resumen
    - Comprueba que la cantidad de operaciones excluya ventas anuladas

## 📦 Pruebas de Reportes de Compras

Archivo: `test/reportes/ReporteCompraRepositoryTests.cs`

### Pruebas Implementadas:

1. **ObtenerComprasPorRangoFecha_DebeRetornarComprasEnRango**
   - Verifica que se retornen las compras dentro del rango de fechas especificado

2. **ObtenerComprasPorRangoFecha_DebeRetornarListaVaciaCuandoNoHayCompras**
   - Verifica que retorne una lista vacía cuando no hay compras en el rango

3. **ObtenerComprasPorRangoFecha_DebeIncluirInformacionDelProveedor**
   - Verifica que cada compra incluya la información del proveedor
   - Comprueba que el nombre del proveedor sea correcto

4. **ObtenerComprasPorRangoFecha_DebeCalcularMontoTotalCorrectamente**
   - Verifica que el monto total de cada compra sea correcto
   - Comprueba que coincida con el total de la compra

5. **ObtenerComprasPorRangoFecha_DebeGenerarNumeroComprobanteCorrectamente**
   - Verifica que se genere el número de comprobante con el formato "C-XXXXXX"
   - Comprueba el formato del número de comprobante

6. **ObtenerComprasPorRangoFecha_DebeOrdenarPorFechaDescendente**
   - Verifica que las compras se retornen ordenadas por fecha descendente
   - Comprueba que las compras más recientes aparezcan primero

7. **ObtenerComprasPorRangoFecha_DebeIncluirVariasComprasEnRango**
   - Verifica que se incluyan todas las compras dentro del rango
   - Comprueba el manejo de múltiples registros

8. **ObtenerResumenCompras_DebeCalcularTotalGeneralCorrectamente**
   - Verifica el cálculo del total general de compras
   - Comprueba la cantidad de operaciones

9. **ObtenerResumenCompras_DebeCalcularPromedioCorrectamente**
   - Verifica que el promedio se calcule correctamente
   - Comprueba el cálculo exacto del promedio (TotalGeneral / CantidadOperaciones)

10. **ObtenerResumenCompras_DebeRetornarCerosCuandoNoHayCompras**
    - Verifica que retorne valores en cero cuando no hay compras
    - Comprueba el manejo de casos sin datos

## 🎯 Características de las Pruebas

### Tipo de Pruebas
- **Pruebas de Integración**: Utilizan base de datos en memoria (Entity Framework InMemory)
- **Aislamiento**: Cada prueba utiliza una base de datos independiente
- **Limpieza**: Las bases de datos se eliminan al finalizar cada prueba

### Datos de Prueba
- Usuarios, clientes y proveedores de prueba
- Ventas y compras con detalles realistas
- Diferentes estados de ventas (Confirmada, Anulada)
- Rangos de fechas variados para probar filtrados

### Patrones Utilizados
- **AAA Pattern** (Arrange-Act-Assert): Todas las pruebas siguen este patrón
- **Dispose Pattern**: Limpieza automática de recursos
- **Seed Data**: Datos de prueba configurados en el constructor

## ▶️ Ejecutar las Pruebas

### Todas las pruebas de reportes:
```bash
dotnet test --filter "FullyQualifiedName~reportes"
```

### Solo pruebas de reportes de ventas:
```bash
dotnet test --filter "FullyQualifiedName~ReporteVentaRepositoryTests"
```

### Solo pruebas de reportes de compras:
```bash
dotnet test --filter "FullyQualifiedName~ReporteCompraRepositoryTests"
```

### Todas las pruebas del proyecto:
```bash
dotnet test test/GestionVentasCel.Tests.csproj
```

## 📊 Cobertura de Funcionalidad

### Reportes de Ventas ✅
- Filtrado por rango de fechas
- Exclusión de ventas anuladas
- Cálculo de montos (con IVA y sin IVA)
- Inclusión de información del cliente
- Ordenamiento por fecha
- Cálculo de resúmenes (total, promedio, cantidad)
- Manejo de casos vacíos

### Reportes de Compras ✅
- Filtrado por rango de fechas
- Inclusión de información del proveedor
- Cálculo de montos totales
- Generación de números de comprobante
- Ordenamiento por fecha
- Cálculo de resúmenes (total, promedio, cantidad)
- Manejo de casos vacíos
- Múltiples compras en el mismo rango

## 🔧 Tecnologías Utilizadas

- **xUnit 2.9.0**: Framework de pruebas
- **EntityFrameworkCore InMemory 9.0.8**: Base de datos en memoria
- **.NET 8.0 Windows**: Framework objetivo

## 📝 Notas Técnicas

1. **Tolerancia de Redondeo**: La prueba de cálculo de montos usa una tolerancia de < 1 para manejar diferencias de redondeo entre MontoSinIva + MontoIva y MontoTotal.

2. **Estados de Venta**: Se utiliza `EstadoVentaEnum.Confirmada` para ventas válidas y `EstadoVentaEnum.Anulada` para ventas que deben excluirse.

3. **Fechas**: Las pruebas ajustan la fecha final del rango para incluir todo el día (`AddDays(1).AddTicks(-1)`), igual que la implementación real.

4. **Aislamiento de Datos**: Cada prueba crea su propia base de datos en memoria con un GUID único, garantizando independencia entre pruebas.

## 🚀 Próximos Pasos

Para expandir las pruebas, considera agregar:
- Pruebas de servicios de reportes (si existen capas de servicio adicionales)
- Pruebas de integración con exportación de reportes (Excel, PDF)
- Pruebas de rendimiento con grandes volúmenes de datos
- Pruebas de reportes por tipo de pago
- Pruebas de reportes por cliente/proveedor específico
