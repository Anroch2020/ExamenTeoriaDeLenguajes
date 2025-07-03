# Gestión de Flota de Vehículos Eléctricos

## Descripción del Proyecto

Este proyecto es una aplicación de consola desarrollada en C# que simula la gestión de una flota de vehículos eléctricos, incluyendo autos, motocicletas y bicicletas. La aplicación demuestra la aplicación de los paradigmas de **Programación Orientada a Objetos (POO)** y **Programación Funcional** para resolver un problema de manera eficiente y escalable.

El sistema permite listar vehículos, filtrar información según el estado de su batería, calcular consumos y realizar acciones como la carga de la batería a través de un menú interactivo en la consola.

---

## Principales Conceptos Demostrados

### 1. Programación Orientada a Objetos (POO)

El diseño del sistema se basa en los pilares fundamentales de la POO:

-   **Abstracción:** Se define una clase `abstract class VehiculoElectrico` que agrupa los atributos y comportamientos comunes a todos los vehículos (marca, modelo, carga, etc.).
-   **Herencia:** Se crean clases específicas (`AutoElectrico`, `MotocicletaElectrica`, `BicicletaElectrica`) que heredan de `VehiculoElectrico`, extendiendo la funcionalidad base.
-   **Polimorfismo:** El método `CargarBateria()` se declara como `abstract` en la clase base y se sobrescribe (`override`) en cada subclase para simular diferentes comportamientos de carga (lenta, normal, rápida). De igual manera, `ConsumoPorKm()` devuelve un valor distinto para cada tipo de vehículo.
-   **Encapsulamiento:** La propiedad `CargaActual` está protegida para asegurar que su valor se mantenga siempre entre 0 y 100, controlando el acceso a través de un campo privado.

### 2. Programación Funcional

Para la manipulación y consulta de la colección de vehículos, se utilizan características de la programación funcional disponibles en C# a través de LINQ (Language-Integrated Query):

-   **Funciones de Orden Superior:** Se emplean métodos como `Where`, `Select`, `Sum`, `FirstOrDefault` y `ForEach` que toman funciones (expresiones lambda) como argumentos para procesar la lista de vehículos.
-   **Expresiones Lambda:** Se utilizan para definir de manera concisa y clara la lógica de los filtros y proyecciones. Por ejemplo: `flota.Where(v => v.CargaActual < 20)`.

---

## Características de la Aplicación

La aplicación cuenta con un menú interactivo en la consola que ofrece las siguientes funcionalidades:

1.  **Ver toda la flota:** Muestra una lista completa de los vehículos, incluyendo su tipo, marca, modelo y nivel de carga actual.
2.  **Filtrar vehículos con batería baja:** Identifica y muestra los vehículos cuya carga es inferior al 20%.
3.  **Listar marcas con buena carga:** Extrae y muestra las marcas de los vehículos que tienen más del 50% de batería.
4.  **Calcular consumo total:** Suma el consumo por kilómetro de todos los vehículos para obtener el consumo total de la flota.
5.  **Cargar un vehículo:** Simula el proceso de carga, seleccionando un vehículo con batería baja y llevándola al 100%.
6.  **Salir:** Termina la ejecución del programa.

---

## Cómo Ejecutar el Proyecto

### Prerrequisitos

-   Tener instalado el SDK de .NET (versión 8.0 o superior recomendada).

### Pasos para la ejecución

1.  Clona o descarga este repositorio.
2.  Abre una terminal o consola en el directorio raíz del proyecto.
3.  Ejecuta el siguiente comando:

    ```bash
    dotnet run
    ```

4.  La aplicación se compilará y se iniciará, mostrando el menú interactivo en la consola.

---

## Estructura del Código

Todo el código fuente se encuentra en el archivo `Program.cs` y está organizado de la siguiente manera:

-   **Definición de Clases (POO):**
    -   `VehiculoElectrico` (clase base abstracta)
    -   `AutoElectrico` (subclase)
    -   `MotocicletaElectrica` (subclase)
    -   `BicicletaElectrica` (subclase)
-   **Lógica de la Aplicación (`Program`):**
    -   `Main()`: Contiene la lógica del menú interactivo, la creación de la lista inicial de vehículos y el uso de LINQ para implementar las funcionalidades.
